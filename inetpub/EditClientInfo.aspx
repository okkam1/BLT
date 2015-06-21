
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditClientInfo.aspx.cs" Inherits="EditClientInfo" Trace="false" EnableViewState="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Edit Existing Client Information</h2>

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

            </asp:Panel>
            
            
            <tr><td colspan="2"><hr /></td></tr>

            
            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="tbFirstName" runat="server" Width="300px"></asp:TextBox>


                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" InitialValue="" ErrorMessage="Please provide a first name" ControlToValidate="tbFirstName" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td>Last Name:</td>
                <td><asp:TextBox ID="tbLastName" runat="server" placeholder="Optional; if different than Family Last Name" Width="300px"></asp:TextBox>
                </td>
            </tr>
   
   
        <tr>
                <td>Middle Name:</td>
            <td>
        <asp:TextBox ID="tbMiddleName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Birth Date: <br /> <em>(MM/DD/YYYY)</em></td>
                <td><asp:TextBox ID="tbBirthDate" runat="server" placeholder="MM/dd/yyyy" tooltip="Date the client was born"></asp:TextBox>

<ajaxtoolkit:CalendarExtender ID="CalendarExtender2" 
    runat="server" 
    PopupPosition="Right"
    PopupButtonID="tbBirthDate" 
    TargetControlID="tbBirthDate" 
    Format="MM/dd/yyyy" >
</ajaxtoolkit:CalendarExtender>

<asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbBirthDate" 
    ErrorMessage="Please enter a valid date." ForeColor="Red">
</asp:CompareValidator>

<asp:CompareValidator ID="futureDateValidator" runat="server"  ControlToValidate="tbBirthDate"
ErrorMessage="Date must be today or a past date!"  Operator="LessThanEqual" Type="Date" ForeColor="Red">
</asp:CompareValidator>
                    
                    <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" InitialValue="" ErrorMessage="Please enter the birthdate" ControlToValidate="tbBirthDate" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
        
        <tr>
                <td>Gender:</td>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>

                <asp:RequiredFieldValidator ID="rfvGender" runat="server" ErrorMessage="Please select the gender" ControlToValidate="rblGender" ForeColor="Red"></asp:RequiredFieldValidator>
</td>
            </tr>
        
           <tr>
                <td>Client:</td>
            <td>
                <asp:RadioButtonList ID="rblClient" runat="server" RepeatDirection="Horizontal" ToolTip="Is the person a participant in the lead study program">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>

        <tr>
                <td>Primary Language:</td>
            <td>
        <asp:DropDownList ID="ddlLanguage" runat="server" ToolTip="Primary language spoken">
            <asp:ListItem>-</asp:ListItem>
        </asp:DropDownList> <a href="AddLanguage.aspx">Add Language</a>

                <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" InitialValue="-" ErrorMessage="Please select a language" ControlToValidate="ddlLanguage" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
            </tr>
        
        <tr>
                <td>Ethnicity:</td>
            <td>
        <asp:DropDownList ID="ddlEthnicity" runat="server" ViewStateMode="Enabled" ToolTip="Clients’ ethnic background"></asp:DropDownList>
                <a href="AddEthnicity.aspx" class="small">Add a New Ethnicity</a>

                <asp:RequiredFieldValidator ID="rfvEthnicity" runat="server" InitialValue="-" ErrorMessage="Please select an ethnicity" ControlToValidate="ddlEthnicity" ForeColor="Red"></asp:RequiredFieldValidator>



            </td>
            </tr>

      <%--  <tr>
                <td>Moved:</td>
            <td>
                <asp:RadioButtonList ID="rblMoved" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>--%>

            <tr>
                <td>Moved Out of County:</td>
            <td>

            <asp:RadioButtonList ID="rblOutOfSite" runat="server" RepeatDirection="Horizontal" ToolTip="Does the client live outside of Lake County?">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>

        <tr>
                <td>Travel:</td>
            <td>
            
                <asp:RadioButtonList ID="rblTravel" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList>


            </td>
            </tr>
            <tr>
                <td>Travel Notes:</td>
            <td>
                <asp:TextBox runat="server" ID="tbTravelNotes" TextMode="MultiLine"></asp:TextBox>
            </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>
            
            <tr>
                <td>Release Notes:</td>
            <td><asp:TextBox runat="server" ID="tbReleaseNotes" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
       

            <tr><td colspan="2"><hr /></td></tr>
            
            
        <tr>
                <td style="vertical-align:top;"><span style="vertical-align:top;">Add New Client Notes: <br />
                    <span class="small"><em>Historic notes are only available via Advanced Data Management</em></span></span>
                </td>
            <td style="vertical-align:top;">
                <asp:TextBox runat="server" ID="tbClientNotes" TextMode="MultiLine" Height="80px" Width="250px"></asp:TextBox>
            </td>
            </tr>
        
</table>

        <br /><br />
        <asp:Button ID="InsertButton" runat="server" OnClick="Button1_Click" Text="Update" />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

    <asp:Button ID="Button1" runat="server" style="visibility:hidden;" />

        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Update" style="visibility:hidden;" />

        <asp:Panel ID="ModalPanel" runat="server" Width="500px" Height="100px" BackColor="#CCFF99" BorderColor="Black" BorderWidth="1" HorizontalAlign="Center" ScrollBars="Vertical">
            <br />
<asp:Label ID="lbPopUp" runat="server" Text="success or failure message here"></asp:Label>
            <br /><br />
 
            
            <asp:Button ID="OKButton" runat="server" Text="Close" />
            
</asp:Panel>
 

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="Button2" 
 PopupControlID="ModalPanel" OkControlID="OKButton" />

        
        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />
        
    </div>
    
</asp:Content>
