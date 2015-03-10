﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BloodTestResults.aspx.cs" Inherits="BloodTestResults" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Blood Lead Test Results <asp:Label runat="server" ID="lblHeader"></asp:Label></h2>

        <table>

            <tr>
                <td>Sample Date:</td>
                <td><asp:TextBox ID="tbSampleDate" runat="server"></asp:TextBox>

<ajaxtoolkit:CalendarExtender ID="CalendarExtender2" 
    runat="server" 
    PopupPosition="Right"
    PopupButtonID="tbSampleDate" 
    TargetControlID="tbSampleDate" 
    Format="MM/dd/yyyy">
</ajaxtoolkit:CalendarExtender>

                    <asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbSampleDate" 
    ErrorMessage="Please enter a valid sample date." ForeColor="Red">
</asp:CompareValidator>

                </td>
            </tr>

            <tr>
                <td>Lab Date:</td>
                <td><asp:TextBox ID="tbLabDate" runat="server"></asp:TextBox>

                    
<ajaxtoolkit:CalendarExtender ID="CalendarExtender1" 
    runat="server" 
    PopupPosition="Right"
    PopupButtonID="tbLabDate" 
    TargetControlID="tbLabDate" 
    Format="MM/dd/yyyy">
</ajaxtoolkit:CalendarExtender>

                                        <asp:CompareValidator
    id="CompareValidator1" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbLabDate" 
    ErrorMessage="Please enter a valid lab date." ForeColor="Red">
</asp:CompareValidator>

                    
                    
                </td>
            </tr>
                 
            <tr>

            <tr>
                <td>Lab:</td>
            <td>
                <asp:DropDownList ID="ddlLab" runat="server">
                    <asp:ListItem>-</asp:ListItem>
                </asp:DropDownList>  <a href="AddLab.aspx">Add Lab</a>

                <asp:RequiredFieldValidator ID="rfvLab" runat="server" InitialValue="-" ErrorMessage="Please select a lab" ControlToValidate="ddlLab" ForeColor="Red"></asp:RequiredFieldValidator>

            
            </td>
            </tr>
        

            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Blood Lead Result (Pb):</td>
                <td><asp:TextBox ID="tbBloodLeadResult" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cvBloodLeadResult" runat="server" ControlToValidate="tbBloodLeadResult" Type="Double" Operator="DataTypeCheck" ErrorMessage="Value must be a number!" ForeColor="Red" />
                </td>
            </tr>

            <tr>
                <td>Flag:</td>
                <td>

                    <asp:DropDownList ID="ddlFlag" runat="server">
                    <asp:ListItem>30</asp:ListItem> 
                    <asp:ListItem>60</asp:ListItem>
                    <asp:ListItem>90</asp:ListItem> 
                    <asp:ListItem>180</asp:ListItem> 
                    <asp:ListItem Selected="True">365</asp:ListItem>
                    </asp:DropDownList>

                    <asp:CompareValidator ID="cvFlag" runat="server" ControlToValidate="ddlFlag" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" />
                </td>
            </tr>

            <tr>
                <td>Test Type:</td>
                <td><asp:TextBox ID="tbTestType" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cvTestType" runat="server" ControlToValidate="tbTestType" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" />
                </td>
            </tr>
       
            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Client Status Code:</td>
                <td><asp:TextBox ID="tbChildStatusCode" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cvChildStatusCode" runat="server" ControlToValidate="tbChildStatusCode" Type="Integer" Operator="DataTypeCheck" ErrorMessage="Value must be an integer!" ForeColor="Red" />
                </td>
            </tr>

            <tr>
                <td>Hemoglobin:</td>
                <td><asp:TextBox ID="tbHemoglobin" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="cvHemoglobin" runat="server" ControlToValidate="tbHemoglobin" Type="Double" Operator="DataTypeCheck" ErrorMessage="Value must be a number!" ForeColor="Red" />
                </td>
            </tr>

</table>

        <br /><br />
        <asp:Button ID="Insert" runat="server" OnClick="Button1_Click" Text="Save and Done" />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

            <asp:Button ID="Button1" runat="server" style="visibility:hidden;" />

        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Save and Continue &gt;&gt;" style="visibility:hidden;" />

        <asp:Panel ID="ModalPanel" runat="server" Width="500px" Height="100px" BackColor="#CCFF99" BorderColor="Black" BorderWidth="1" HorizontalAlign="Center" ScrollBars="Vertical">
            <br />
<asp:Label ID="lbPopUp" runat="server" Text="success or failure message here"></asp:Label>
            <br /><br />
 
            
            <asp:Button ID="OKButton" runat="server" Text="Close" />
            <asp:Button ID="NextButton" runat="server" Text="Done &gt;&gt;" Visible="false" OnClick="NextButton_Click" />

</asp:Panel>
 

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="Button2" 
 PopupControlID="ModalPanel" OkControlID="OKButton" />

    
        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />
        

    </div>
    
</asp:Content>

