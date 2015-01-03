
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddFamily.aspx.cs" Inherits="AddFamily" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Add a NEW Family</h2>

        <table>
            <tr>
                <td>Family Last Name:</td>
                <td><asp:TextBox ID="tbLastName" runat="server"></asp:TextBox></td>
            </tr>
   
        <tr>
                <td>Street Number:</td>
            <td>
        <asp:TextBox ID="TextBoxStreetNumber" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Street Name:</td>
            <td>
        <asp:TextBox ID="TextBoxStreetName" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
                <td>Street Suffix:</td>
            <td>
                <asp:DropDownList ID="DropDownListStreetSuffix" runat="server">
                    <asp:ListItem Value="" Selected="True">Optional</asp:ListItem> 
                    <asp:ListItem>Avenue</asp:ListItem> 
                    <asp:ListItem>Boulevard</asp:ListItem>
                    <asp:ListItem>Drive</asp:ListItem> 
                    <asp:ListItem>Parkway</asp:ListItem> 
                    <asp:ListItem>Road</asp:ListItem>
                    <asp:ListItem>Street</asp:ListItem> 
                    </asp:DropDownList>

            </td>
            </tr>

            <tr>
                <td>Apartment Number:</td>
            <td>
        <asp:TextBox ID="TextBoxApartmentNumber" runat="server"></asp:TextBox></td>
            </tr>

        <tr>
                <td>City:</td>
            <td>
        <asp:TextBox ID="TextBoxCity" runat="server"></asp:TextBox></td>
            </tr>

        <tr>
                <td>State:</td>
            <td>
        <asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem value="AL">Alabama</asp:ListItem> 
            <asp:ListItem value="AK">Alaska</asp:ListItem> 
            <asp:ListItem value="AZ">Arizona</asp:ListItem> 
            <asp:ListItem value="AR">Arkansas</asp:ListItem> 
            <asp:ListItem value="CA">California</asp:ListItem> 
            <asp:ListItem value="CO" Selected="True">Colorado</asp:ListItem> 
            <asp:ListItem value="CT">Connecticut</asp:ListItem> 
            <asp:ListItem value="DC">D.C.</asp:ListItem> 
            <asp:ListItem value="DE">Delaware</asp:ListItem> 
            <asp:ListItem value="FL">Florida</asp:ListItem> 
            <asp:ListItem value="GA">Georgia</asp:ListItem> 
            <asp:ListItem value="HI">Hawaii</asp:ListItem> 
            <asp:ListItem value="ID">Idaho</asp:ListItem> 
            <asp:ListItem value="IL">Illinois</asp:ListItem> 
            <asp:ListItem value="IN">Indiana</asp:ListItem> 
            <asp:ListItem value="IA">Iowa</asp:ListItem> 
            <asp:ListItem value="KS">Kansas</asp:ListItem> 
            <asp:ListItem value="KY">Kentucky</asp:ListItem> 
            <asp:ListItem value="LA">Louisiana</asp:ListItem> 
            <asp:ListItem value="ME">Maine</asp:ListItem> 
            <asp:ListItem value="MD">Maryland</asp:ListItem> 
            <asp:ListItem value="MA">Massachusetts</asp:ListItem> 
            <asp:ListItem value="MI">Michigan</asp:ListItem> 
            <asp:ListItem value="MN">Minnesota</asp:ListItem> 
            <asp:ListItem value="MS">Mississippi</asp:ListItem> 
            <asp:ListItem value="MO">Missouri</asp:ListItem> 
            <asp:ListItem value="MT">Montana</asp:ListItem> 
            <asp:ListItem value="NE">Nebraska</asp:ListItem> 
            <asp:ListItem value="NV">Nevada</asp:ListItem> 
            <asp:ListItem value="NH">New Hampshire</asp:ListItem> 
            <asp:ListItem value="NJ">New Jersey</asp:ListItem> 
            <asp:ListItem value="NM">New Mexico</asp:ListItem> 
            <asp:ListItem value="NY">New York</asp:ListItem> 
            <asp:ListItem value="NC">North Carolina</asp:ListItem> 
            <asp:ListItem value="ND">North Dakota</asp:ListItem> 
            <asp:ListItem value="OH">Ohio</asp:ListItem> 
            <asp:ListItem value="OK">Oklahoma</asp:ListItem> 
            <asp:ListItem value="OR">Oregon</asp:ListItem> 
            <asp:ListItem value="PA">Pennsylvania</asp:ListItem> 
            <asp:ListItem value="RI">Rhode Island</asp:ListItem> 
            <asp:ListItem value="SC">South Carolina</asp:ListItem> 
            <asp:ListItem value="SD">South Dakota</asp:ListItem> 
            <asp:ListItem value="TN">Tennessee</asp:ListItem> 
            <asp:ListItem value="TX">Texas</asp:ListItem> 
            <asp:ListItem value="UT">Utah</asp:ListItem> 
            <asp:ListItem value="VT">Vermont</asp:ListItem> 
            <asp:ListItem value="VA">Virginia</asp:ListItem> 
            <asp:ListItem value="WA">Washington</asp:ListItem> 
            <asp:ListItem value="WV">West Virginia</asp:ListItem> 
            <asp:ListItem value="WI">Wisconsin</asp:ListItem> 
            <asp:ListItem value="WY">Wyoming</asp:ListItem> 

        </asp:DropDownList></td>
            </tr>
        

        <tr>
                <td>Zip:</td>
            <td>
        <asp:TextBox ID="TextBoxZip" runat="server" Width="50px"></asp:TextBox></td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>

        <tr>
                <td>Home Phone:</td>
            <td>
        <asp:TextBox ID="HomePhoneTextBox" runat="server" MaxLength="10"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Exactly 10 Numbers Only" ForeColor="Red" ControlToValidate="HomePhoneTextBox"
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>

            </td>
            </tr>
        
        
        <tr>
                <td>Work Phone:</td>
            <td>
        <asp:TextBox ID="WorkPhoneTextBox" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ErrorMessage="Exactly 10 Numbers Only" ForeColor="Red" ControlToValidate="WorkPhoneTextBox"
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>


            </td>
            </tr>
        
            <tr><td colspan="2"><hr /></td></tr>
<%--        
        <tr>
                <td>Language:</td>
            <td>
        <asp:DropDownList ID="ddlLanguage" runat="server" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged">
            <asp:ListItem>-</asp:ListItem>
        </asp:DropDownList> <a href="AddLanguage.aspx">Add Language</a></td>
            </tr>
       
        
        
        <tr>
                <td>Medicaid:</td>
            <td>
                <asp:RadioButtonList ID="MedicaidRadioButtonList" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>


            </td>
            </tr>
        
            <tr>
                <td>Lead Dishes:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListLeadDishes" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>
        --%>
            <tr>
                <td>Pets:</td>
            <td>

                <asp:RadioButtonList ID="RadioButtonListPets" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>
        
        <tr>
                <td>Pets In and Out:</td>
            <td>

                <asp:RadioButtonList ID="RadioButtonListPetsInOut" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>
        
        <%--<tr>
                <td># Smokers:</td>
            <td>
                <asp:DropDownList ID="DropDownListSmokers" runat="server">
                    <asp:ListItem Value="">-</asp:ListItem>
                    <asp:ListItem>0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
        </asp:DropDownList>
            </td>
            </tr>--%>

            <tr><td colspan="2"><hr /></td></tr>
        
        <%--<tr>
                <td>Occupation:</td>
            <td>
        <asp:TextBox ID="TextBoxOccupation" runat="server"></asp:TextBox></td>
            </tr>
        
        <tr>
                <td>Occupation Notes:</td>
            <td>
                
                <asp:TextBox runat="server" ID="TextBoxOccupationNotes" TextMode="MultiLine"></asp:TextBox>
                
        </td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>
        --%>
        <tr>
                <td>Other Notes:</td>
            <td>

                <asp:TextBox runat="server" ID="TextBoxOtherNotes" TextMode="MultiLine"></asp:TextBox>

            </td>
            </tr>
        <%--
        <tr>
                <td>Incentive:</td>
            <td>
                <asp:RadioButtonList ID="RadioButtonListIncentive" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:RadioButtonList>


            </td>
            </tr>
            --%>
</table>
        <br /><br />
        <input id="back" type="button" value="&lt;&lt; Back" OnClick="javascript: history.back();" />
        
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Insert" runat="server" OnClick="Button1_Click" Text="Insert New Family" />

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
