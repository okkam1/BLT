
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditFamily.aspx.cs" Inherits="EditFamily" Trace="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Edit an Existing Family</h2>

        <table>

            <tr>
                <td>Family:</td>
                <td><asp:DropDownList ID="FamilyNameList" runat="server" ViewStateMode="Enabled" OnSelectedIndexChanged="FamilyNameList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <a href="AddFamily.aspx" class="small">Add a New Family</a>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="(Family name -- PRIMARY residence)" ErrorMessage="Please select a family" ControlToValidate="FamilyNameList" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>

<asp:Panel runat="server" ID="pnlEditAddress" Visible="false">
   
            <tr>
                <td>Family Last Name:</td>
                <td><asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" InitialValue="" ErrorMessage="Please Enter a Family Name" ControlToValidate="tbLastName" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
        <tr>
                <td>Address:</td>
            <td>
        <asp:TextBox ID="tbAddress" runat="server" Enabled="False"></asp:TextBox>
                
                
                <span class="small">
                    <asp:Button runat="server" ID="bEditCurrentAddress" Text="Edit Existing Address" OnClick="bEditCurrentAddress_Click" />
                    |
                    <asp:Button runat="server" ID="bAddNewAddress" Text="Add New Address" OnClick="bAddNewAddress_Click" />
                    </span>

                    
            </td>
            </tr>
<!--
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
            -->
            <tr>
                <td>Address Line 2:</td>
            <td>
        <asp:TextBox ID="tbAddressLine2" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>

        <tr>
                <td>City:</td>
            <td>
        <asp:TextBox ID="tbCity" runat="server" Enabled="False"></asp:TextBox></td>
            </tr>

        <tr>
                <td>State:</td>
            <td>
        <asp:DropDownList ID="ddlState" runat="server" Enabled="False">
            <asp:ListItem value="">-</asp:ListItem> 
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
        <asp:TextBox ID="tbZip" runat="server" Width="50px" Enabled="False"></asp:TextBox></td>
            </tr>

            <tr><td colspan="2"><hr /></td></tr>
            
   
        <tr>
                <td>Home Phone:</td>
            <td>
        <asp:TextBox ID="tbHomePhone" runat="server" MaxLength="10"></asp:TextBox>
                
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Exactly 10 Numbers Only" ForeColor="Red" ControlToValidate="tbHomePhone"
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>

            </td>
            </tr>
        
        
        <tr>
                <td>Work Phone:</td>
            <td>
        <asp:TextBox ID="tbWorkPhone" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
        ErrorMessage="Exactly 10 Numbers Only" ForeColor="Red" ControlToValidate="tbWorkPhone"
        ValidationExpression="^[0-9]{10}$"></asp:RegularExpressionValidator>


            </td>
            </tr>
        
            <tr><td colspan="2"><hr /></td></tr>
            
            <tr>
                <td>Number of Smokers:</td>
            <td>

                <asp:DropDownList ID="ddlSmokers" runat="server">
            <asp:ListItem Value="0">0</asp:ListItem>
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
            </tr>
       

            <tr>
                <td>Number of Pets:</td>
            <td>

                <asp:DropDownList ID="ddlPets" runat="server" OnSelectedIndexChanged="ddlPets_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="0">0</asp:ListItem>
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
            </tr>
        

    

            <asp:Panel ID="pnlPets" runat="server" Visible="true">

        <tr>
                <td>Pets In and Out:</td>
            <td>

                <asp:RadioButtonList ID="RadioButtonListPetsInOut" runat="server" RepeatDirection="Horizontal" Enabled="False">
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                </asp:RadioButtonList>

            </td>
            </tr>

            </asp:Panel>
        
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
                <td>Family Notes:</td>
            <td>

                <asp:TextBox runat="server" ID="tbFamilyNotes" TextMode="MultiLine"></asp:TextBox>

            </td>
            </tr>
        
           </asp:Panel>

</table>
        <br /><br />
        
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" OnClick="Button1_Click" Text="Update Family Information" visible="false" />

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

            <asp:Button ID="Button1" runat="server" style="visibility:hidden;" />

        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Save and Continue &gt;&gt;" style="visibility:hidden;" />

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
