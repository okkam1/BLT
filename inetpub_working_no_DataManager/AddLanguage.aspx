
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
        
        <asp:Button ID="btnInsert" runat="server" OnClick="Insert_Click" Text="Insert New Language" />
    
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

            <asp:Button ID="Button1" runat="server" style="visibility:hidden;" />

        <asp:Button ID="Button2" runat="server" OnClick="Insert_Click" Text="Save and Continue &gt;&gt;" style="visibility:hidden;" />

        <asp:Panel ID="ModalPanel" runat="server" Width="500px" Height="100px" BackColor="#CCFF99" BorderColor="Black" BorderWidth="1" HorizontalAlign="Center" ScrollBars="Vertical">
            <br />
<asp:Label ID="lbPopUp" runat="server" Text="success or failure message here"></asp:Label>
            <br /><br />
 
            
            <asp:Button ID="OKButton" runat="server" Text="Close" />
            <asp:Button ID="NextButton" runat="server" Text="Done &gt;&gt;" Visible="false" OnClick="Back_Click" />

</asp:Panel>
 

<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlId="Button2" 
 PopupControlID="ModalPanel" OkControlID="OKButton" />

        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />

</div>    
</asp:Content>
