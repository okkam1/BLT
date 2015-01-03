
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddClient.aspx.cs" Inherits="AddChild" Trace="false" EnableViewState="true"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Onboard Lead Research Subject</h2>

        <table>
            <tr>
                <td>Family:</td>
                <td><asp:DropDownList ID="FamilyNameList" runat="server" ViewStateMode="Enabled"></asp:DropDownList>
                <a href="AddFamily.aspx" class="small">Add a New Family</a>
                    
                    <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" InitialValue="-" ErrorMessage="Please select a family" ControlToValidate="FamilyNameList" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>

            <tr>
                <td>First Name:</td>
                <td><asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox></td>
            </tr>
   
        <tr>
                <td>Middle Name:</td>
            <td>
        <asp:TextBox ID="tbMiddleName" runat="server" Width="50px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Birth Date:</td>
                <td><asp:TextBox ID="tbBirthDate" runat="server"></asp:TextBox>

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
        
            <tr><td colspan="2"><hr /></td></tr>

        <tr>
                <td>Language:</td>
            <td>
        <asp:DropDownList ID="ddlLanguage" runat="server">
            <asp:ListItem>-</asp:ListItem>
        </asp:DropDownList> <a href="AddLanguage.aspx">Add Language</a>

                <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" InitialValue="-" ErrorMessage="Please select a language" ControlToValidate="ddlLanguage" ForeColor="Red"></asp:RequiredFieldValidator>

            </td>
            </tr>
        
        <tr>
                <td>Child ID:</td>
            <td>
        <asp:TextBox ID="tbChildID" runat="server" Width="20px"></asp:TextBox></td>
            </tr>

        <tr>
                <td>Ethnicity:</td>
            <td>
        <asp:TextBox ID="tbEthnicity" runat="server"></asp:TextBox></td>
            </tr>

        <tr>
                <td>Moved:</td>
            <td>
                <asp:RadioButtonList ID="rblMoved" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>

                    <tr>
                <td>Smoker:</td>
            <td>
            
                <asp:RadioButtonList ID="rblSmoker" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>


            </td>
            </tr>

        <tr>
                <td>Travel:</td>
            <td>
            
                <asp:RadioButtonList ID="rblTravel" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>


            </td>
            </tr>

        <tr>
                <td>Travel Notes:</td>
            <td>
                <asp:TextBox runat="server" ID="tbTravelNotes" TextMode="MultiLine"></asp:TextBox>
            </td>
            </tr>

        <tr>
                <td>Out of Site:</td>
            <td>

            <asp:RadioButtonList ID="rblOutOfSite" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>
            
            <tr>
                <td>Hobby:</td>
            <td>
            <asp:RadioButtonList ID="rblHobby" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            </tr>
        
            <tr>
                <td>Hobby Notes:</td>
            <td><asp:TextBox runat="server" ID="tbHobbyNotes" TextMode="MultiLine"></asp:TextBox></td>
            </tr>

        <tr><td colspan="2"><hr /></td></tr>

        <tr>
                <td>Child Notes:</td>
            <td>
                <asp:TextBox runat="server" ID="tbChildNotes" TextMode="MultiLine"></asp:TextBox>
            </td>
            </tr>
        
</table>

        <br /><br />
        <asp:Button ID="InsertButton" runat="server" OnClick="Button1_Click" Text="Save and Continue &gt;&gt;" />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

    <asp:Button ID="Button1" runat="server" style="visibility:hidden;" />

        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Save and Continue &gt;&gt;" style="visibility:hidden;" />

        <asp:Panel ID="ModalPanel" runat="server" Width="500px" Height="100px" BackColor="#CCFF99" BorderColor="Black" BorderWidth="1" HorizontalAlign="Center" ScrollBars="Vertical">
            <br />
<asp:Label ID="lbPopUp" runat="server" Text="success or failure message here"></asp:Label>
            <br /><br />
 
            
            <asp:Button ID="OKButton" runat="server" Text="Close" />
            <asp:Button ID="NextButton" runat="server" Text="Next &gt;&gt;" Visible="false" OnClick="NextButton_Click" />

</asp:Panel>
 

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="Button2" 
 PopupControlID="ModalPanel" OkControlID="OKButton" />

        
        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />
        
    </div>
    
</asp:Content>
