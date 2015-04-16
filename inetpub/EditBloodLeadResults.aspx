﻿
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditBloodLeadResults.aspx.cs" Inherits="EditBloodLeadResults" Trace="true" EnableViewState="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Edit Existing Client Blood Lead Test Information</h2>

        <table>
            <tr>
                <td style="width:100px">Family:</td>
                <td><asp:DropDownList ID="FamilyNameList" runat="server" ViewStateMode="Enabled" OnSelectedIndexChanged="FamilyNameList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <a href="AddFamily.aspx" class="small">Add a New Family</a>
                    
                    <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" InitialValue="(Family name -- PRIMARY residence)" ErrorMessage="Please select a family" ControlToValidate="FamilyNameList" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <asp:Panel runat="server" ID="pnlFamilyMembers" Visible="false">
            <tr>
                <td>Family Members:</td>
                <td><asp:DropDownList ID="ddlFamilyMembers" runat="server" ViewStateMode="Enabled" AutoPostBack="True" OnSelectedIndexChanged="ddlFamilyMembers_SelectedIndexChanged"></asp:DropDownList>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="(Family name -- PRIMARY residence)" ErrorMessage="Please select a family" ControlToValidate="FamilyNameList" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>

            
            
            
            <tr><td colspan="2"><hr /></td></tr>

    
            <tr>
                <td colspan="2">

        <asp:GridView ID="GridView1" AllowSorting="true" AllowPaging="true" Runat="server"
        DataSourceID="SqlDataSource1" AutoGenerateEditButton="true" DataKeyNames="BloodTestResultsID"
        AutoGenerateColumns="false" AutoGenerateDeleteButton="false" AutoGenerateSelectButton="False" CssClass="DD">

        <Columns>
          <asp:BoundField ReadOnly="true" HeaderText="TestResultsID" DataField="BloodTestResultsID" SortExpression="au_id" />
          
            <asp:BoundField ReadOnly="true" HeaderText="PersonID" DataField="PersonID" SortExpression="PersonID" />

            <asp:BoundField HeaderText="SampleDate" DataField="SampleDate" SortExpression="SampleDate" />

            <asp:BoundField HeaderText="Lab Submission Date" DataField="LabSubmissionDate" SortExpression="LabSubmissionDate" />

            <asp:BoundField HeaderText="Lead Value" DataField="LeadValue" SortExpression="LeadValue" />

            <asp:BoundField HeaderText="Hbg" DataField="HemoglobinValue" SortExpression="HemoglobinValue" />

            <asp:BoundField HeaderText="Blood Test Costs" DataField="BloodTestCosts" SortExpression="BloodTestCosts" />
        </Columns>
      </asp:GridView>

      <asp:SqlDataSource ID="SqlDataSource1" Runat="server" SelectCommand="SELECT [BloodTestResultsID]
      ,[isBaseline]
      ,[PersonID]
      ,[SampleDate]
      ,[LabSubmissionDate]
      ,[LeadValue]
      ,[LeadValueCategoryID]
      ,[HemoglobinValue]
      ,[HemoglobinValueCategoryID]
      ,[HematocritValueCategoryID]
      ,[LabID]
      ,[BloodTestCosts]
      ,[SampleTypeID]
      ,[TakenAfterPropertyRemediationCompleted]
      ,[ModifiedDate]
      ,[CreatedDate]
      ,[HematocritValue]
      ,[ExcludeResult]
      ,[HistoricBloodTestResultsID]
      ,[HistoricLabResultsID]
  FROM [LCCHPDev].[dbo].[BloodTestResults] WHERE [PersonID] = @PersonID"
        
          UpdateCommand="UPDATE [BloodTestResults] SET [LeadValue] = @LeadValue, [SampleDate] = @SampleDate, [LabSubmissionDate] = @LabSubmissionDate, [HemoglobinValue] = @HemoglobinValue, [BloodTestCosts] = @BloodTestCosts WHERE [BloodTestResultsID] = @BloodTestResultsID"

          DeleteCommand="delete from BloodTestResults where [BloodTestResultsID] = @BloodTestResultsID"

          InsertCommand="Insert into BloodTestResults (LeadValue, SampleDate) Values (@LeadValue, @SampleDate)"

        ConnectionString="<%$ ConnectionStrings:csLCCHP %>" >

          <UpdateParameters>
              <asp:Parameter Type="String" Name="BloodTestResultsID"></asp:Parameter>
          </UpdateParameters>

          <SelectParameters>
              <asp:Parameter Type="String" Name="PersonID"></asp:Parameter>
          </SelectParameters>

      </asp:SqlDataSource>

                    <asp:Label runat="server" ID="gridText"></asp:Label>
                    </td></tr>

                <tr><td>
                    <p>&nbsp;</p>
                    <asp:Button ID="btnInsertResults" runat="server" OnClick="Button1_Click" Text="Insert New Results" />


</td>
            </tr>

            </asp:Panel>
            </table>
    </div>

        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />

    
</asp:Content>
