
<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddLanguage.aspx.cs" Inherits="AddLanguage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">
    
        
        <h2 class="DDSubHeader">Add a NEW Language</h2>

        <table>
            <tr>
                <td>Language:</td>
                <td><asp:TextBox ID="Language" runat="server"></asp:TextBox></td>
            </tr>
   
        
</table>
        <br /><br />
        
        <asp:Button runat="server" ID="Back" Text="&lt;&lt; Back" OnClick="Back_Click" />

        &nbsp;&nbsp;&nbsp;
        
        <asp:Button ID="Insert" runat="server" OnClick="Insert_Click" Text="Insert New Language" />
    
        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />

</div>    
</asp:Content>
