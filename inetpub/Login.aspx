<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" class="DD" Width="500px">
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="1.2em" ForeColor="White"  Height="25px" />
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" CssClass="LoginTextBox" />
            <TextBoxStyle Font-Size="0.8em" CssClass="LoginTextBox" />
            
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px"
    Font-Names="Verdana" Font-Size="1.2em" ForeColor="#284775" Width="100px" />
        
        </asp:Login>
       <asp:HyperLink runat="server" ID="forgotPasswordLink" NavigateUrl="~/ForgotPassword.aspx" CssClass="DD">Forgot Password?</asp:HyperLink>

    </div>

</asp:Content>
