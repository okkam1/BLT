<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditClient.aspx.cs" Inherits="EditClient" Trace="false" EnableViewState="true"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

        <h2 class="DDSubHeader">Edit Existing Client for Lead Research Study</h2>

        <div class="MainNavigation">
        <ul>
            <li>
            <asp:HyperLink ID="hlEditClientInfo" runat="server" NavigateUrl="EditClientInfo.aspx">Edit Existing Client Information</asp:HyperLink></li>
        
            <li>
            <asp:HyperLink ID="hlEditFamily" runat="server" NavigateUrl="EditFamily.aspx">Edit Existing Family Information </asp:HyperLink></li>

            <li>
            <asp:HyperLink ID="hlEditLab" runat="server" NavigateUrl="EditBloodLeadResults.aspx">Edit Existing Client Blood Level Information </asp:HyperLink></li>

        </ul>
        
        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />
        
    </div>
    
</asp:Content>
