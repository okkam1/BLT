﻿
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditQuestionnaire.aspx.cs" Inherits="EditQuestionnaire" Trace="false" EnableViewState="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Edit Existing Client Questionnaire Information</h2>

        <table>
            <tr>
                <td style="width:100px">Family:</td>
                <td><asp:DropDownList ID="FamilyNameList" runat="server" ViewStateMode="Enabled" OnSelectedIndexChanged="FamilyNameList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
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
        DataSourceID="SqlDataSource1" AutoGenerateEditButton="true" DataKeyNames="QuestionnaireID"
        AutoGenerateColumns="true" AutoGenerateDeleteButton="false" AutoGenerateSelectButton="False" CssClass="DD">

      </asp:GridView>

      <asp:SqlDataSource ID="SqlDataSource1" Runat="server" SelectCommandType="StoredProcedure" SelectCommand="usp_SlEditQuestionnaireWebScreenInformation"

          UpdateCommandType="StoredProcedure"
        
          UpdateCommand="usp_upQuestionnaireWebScreen"

          DeleteCommand="delete from Questionnaire where [QuestionnaireID] = @QuestionnaireID"

          InsertCommand="Insert into Questionnaire (LeadValue, SampleDate) Values (@LeadValue, @SampleDate)"

        ConnectionString="<%$ ConnectionStrings:csLCCHP %>" >

          <UpdateParameters>
              <asp:Parameter Type="String" Name="QuestionnaireID"></asp:Parameter>
          </UpdateParameters>

          <SelectParameters>
              <asp:Parameter Type="Int32" Name="PersonID"></asp:Parameter>
          </SelectParameters>



      </asp:SqlDataSource>

                    <asp:Label runat="server" ID="gridText"></asp:Label>
                    </td></tr>

                <tr><td>
                    <br />
                    <asp:Button ID="btnInsertResults" runat="server" OnClick="Button1_Click" Text="Insert New Questionnaire" Visible="false" />


</td>
            </tr>

            </asp:Panel>
            </table>
    </div>

                <asp:Panel ID="ModalPanel" runat="server" Width="500px" Height="100px" BackColor="#CCFF99" BorderColor="Black" BorderWidth="1" HorizontalAlign="Center" ScrollBars="Vertical" Visible="false">
            <br />
<asp:Label ID="lbPopUp" runat="server" Text="success or failure message here"></asp:Label>
            <br /><br />

            <asp:Button ID="OKButton" runat="server" Text="OK" />
            
</asp:Panel>
 

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="btnInsertResults" 
 PopupControlID="ModalPanel" OkControlID="OKButton" />




        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />

    
</asp:Content>

