<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />

    <h2 class="DDSubHeader">Please Select:</h2>

    <div class="MainNavigation">
        <ul>
    <li>
        <asp:HyperLink runat="server" NavigateUrl="AddClient.aspx"><img src="images/onboard.jpg" />Onboard Research Subject </asp:HyperLink></li>
    <li>
        <a href="Reports.aspx"><img src="images/graph3.jpg" />View Reports</a></li>
    <!--<li>
        <a href="ManageData.aspx"><img src="images/data.jpg" width="80" />Manage Data</a></li>-->

            <li runat="server" id="datamangebullet">
                <asp:HyperLink runat="server" id ="datamanage" NavigateUrl="ManageData.aspx" ImageUrl="images/data.jpg" ImageWidth="80" Text="Manage Data">Manage Data</asp:HyperLink>
                <asp:HyperLink runat="server" id ="datamanage2" NavigateUrl="ManageData.aspx" Text="Manage Data">Manage Data</asp:HyperLink>
            </li>
            </ul>
        
   </div>

    
    <!--
    <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="false"
        CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
        <Columns>
            <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                <ItemTemplate>
                    <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    -->

</asp:Content>


