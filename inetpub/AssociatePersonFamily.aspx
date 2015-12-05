<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssociatePersonFamily.aspx.cs" Inherits="AssociatePersonFamily" Trace="false" EnableViewState="true"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Associate Person to Family</h2>


    <table>
    <tr>
    <td>List People with Family Associations? </td>

    <td>
    <asp:RadioButtonList ID="rblWithoutFamily" runat="server" RepeatDirection="Horizontal" ToolTip="List Clients Without Family Associaionts" OnSelectedIndexChanged="rblWithoutFamily_Changed" AutoPostBack=true>
                    <asp:ListItem Value="1" Selected="True">No</asp:ListItem>
                    <asp:ListItem Value="0">Yes</asp:ListItem>
                </asp:RadioButtonList>
                </td>
    </tr>
    
        <tr><td colspan="2"><hr /></td></tr>
    
        <tr><td style="text-align:right">Person: </td>
    <td>
        <asp:DropDownList ID="ddlPeople" runat="server"></asp:DropDownList></td>
    </tr>


    <tr><td style="text-align:right">Family: </td>
    <td>
        <asp:DropDownList ID="ddlFamily" runat="server"></asp:DropDownList></td>
    </tr>
    
        <tr><td colspan="2"><hr /></td></tr>
    
        <tr><td colspan="2" style="text-align:right"><asp:Button ID="bAssociateFamilies" runat="server" Text="Associate >>" onClick="bAssociateFamilies_Click" /> </td></tr>

    </table>
    
    </div>
   
    <p class="DD"><asp:label ID="lbOutput" runat="server"></asp:label></p>
    
</asp:Content>
