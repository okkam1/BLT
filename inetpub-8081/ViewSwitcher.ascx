<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewSwitcher.ascx.cs" Inherits="ASP.ViewSwitcher" %>
<div id="viewSwitcher">
    <%: CurrentView %> view | <a href="<%: SwitchUrl %>">Switch to <%: AlternateView %></a>
</div>