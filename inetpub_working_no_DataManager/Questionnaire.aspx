
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Questionnaire.aspx.cs" Inherits="Questionnaire" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">
    
        
        <h2 class="DDSubHeader">Lead Research Subject Questionnaire <asp:Label runat="server" ID="lblHeader"></asp:Label></h2>

        <table>

            <tr>
                <td>Date:</td>
                <td><asp:TextBox ID="tbQuestionnaireDate" runat="server"></asp:TextBox>

                    <ajaxtoolkit:CalendarExtender ID="CalendarExtender1"   
    runat="server"   
    PopupPosition="Right"  
    PopupButtonID="tbQuestionnaireDate"   
    TargetControlID="tbQuestionnaireDate"   
    Format="MM/dd/yyyy">  
</ajaxtoolkit:CalendarExtender>

                                        <asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbQuestionnaireDate" 
    ErrorMessage="Please enter a valid date." ForeColor="Red">
</asp:CompareValidator>

                    <asp:RequiredFieldValidator ID="rfvQuestionnaireDate" runat="server" InitialValue="" ErrorMessage="Please enter the date" ControlToValidate="tbQuestionnaireDate" ForeColor="Red"></asp:RequiredFieldValidator>
      
                </td>
            </tr>
   
            <tr>
                <td>Paint Peeling:</td>
                <td>
                    <asp:RadioButtonList ID="rblPaintPeeling" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

                </td>
            </tr>

            <tr>
                <td>Paint Bldg Age:</td>
                <td>
                    <asp:DropDownList ID="ddlPaintAge" runat="server">
                    </asp:DropDownList>

                </td>
            </tr>
   
            <tr>
                <td>Visit Remodel:</td>
                <td>
                    <asp:RadioButtonList ID="rblVisitRemodel" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

                </td>
            </tr>
        
            <tr>
                <td>Remodel <br />Building Age:</td>
                <td>
                    <asp:DropDownList ID="ddlBuildingAge" runat="server">
                        
                    </asp:DropDownList>
                </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Vitamins:</td>
                <td>
                    <asp:RadioButtonList ID="rblVitamins" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Hand Wash:</td>
                <td>
                    <asp:RadioButtonList ID="rblHandWash" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

                </td>
            </tr>

            <tr>
                <td>Bottle:</td>
                <td>
<asp:RadioButtonList ID="rblBottle" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Mini Blinds:</td>
                <td>
<asp:RadioButtonList ID="rblMiniBlinds" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Nursing:</td>
                <td>
<asp:RadioButtonList ID="rblNursing" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Pacifier:</td>
                <td>
<asp:RadioButtonList ID="rblPacifier" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Bite Nails:</td>
                <td>
<asp:RadioButtonList ID="rblBiteNails" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Eats Outdoors:</td>
                <td>
<asp:RadioButtonList ID="rblEatOutdoors" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Non-Food <br />in Mouth:</td>
                <td>
<asp:RadioButtonList ID="rblNonFoodInMouth" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Eats Non-Food:</td>
                <td>
<asp:RadioButtonList ID="rblEatsNonFood" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Suck Thumb:</td>
                <td>
<asp:RadioButtonList ID="rblSucksThumb" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Mouthing:</td>
                <td>
<asp:RadioButtonList ID="rblMouthing" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            
            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Review:</td>
                <td>
<asp:RadioButtonList ID="rblReview" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Entered</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>

            <tr>
                <td>Daycare:</td>
                <td>
                    <asp:RadioButtonList ID="rblDayCare" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

                </td>
            </tr>

            <tr>
                <td>Daycare Notes:</td>
                <td><asp:TextBox runat="server" ID="tbDaycareNotes" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
   
            <tr><td colspan="2"><hr /></td></tr>

            <tr>
                <td>Other Notes:</td>
                <td><asp:TextBox runat="server" ID="tbQuestionnaireNotes" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
   
            <tr>
                <td>Source:</td>
                <td>
<asp:RadioButtonList ID="rblSource" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>


</table>

        <br /><br />
        <asp:Button ID="Insert" runat="server" OnClick="Button1_Click" Text="Save and Continue &gt;&gt;" />
    
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
