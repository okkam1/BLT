

<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div>
        
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" CssClass="DD" Width="500px"></asp:PasswordRecovery> 
    </div>

</asp:Content>
