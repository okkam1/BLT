<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BloodTestResultsDataGrid.aspx.cs" Inherits="BloodTestResultsDataGrid" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>BloodTestResultsDataGrid</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DataGrid ID="Grid" runat="server" PageSize="25" AllowPaging="True" DataKeyField="BloodTestResultsID"
AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanged="Grid_PageIndexChanged" OnCancelCommand="Grid_CancelCommand"
OnDeleteCommand="Grid_DeleteCommand" OnEditCommand="Grid_EditCommand" OnUpdateCommand="Grid_UpdateCommand">
<Columns>
<asp:BoundColumn HeaderText="BloodTestResultsID" DataField="BloodTestResultsID">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="isBaseline" DataField="isBaseline">
</asp:BoundColumn>
<asp:BoundColumn HeaderText="PersonID" DataField="PersonID">
</asp:BoundColumn>
<asp:BoundColumn DataField="SampleDate" HeaderText="SampleDate">
</asp:BoundColumn>
<asp:BoundColumn DataField="LabSubmissionDate" HeaderText="LabSubmissionDate">
</asp:BoundColumn>
<asp:BoundColumn DataField="LeadValue" HeaderText="LeadValue">
</asp:BoundColumn>
<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit">
</asp:EditCommandColumn>
<asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete">
</asp:ButtonColumn>
</Columns>
<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
<AlternatingItemStyle BackColor="White" />
<ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
</asp:DataGrid>
<br />
<br />
<table>
<tr>
<td>
<asp:Label ID="lblBloodTestResultsID" runat="server" Text="BloodTestResultsID"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
</td>
<td>
<asp:Label ID="lblisBaseline" runat="server" Text="isBaseline"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
</td>
<td>
<asp:Label ID="lblPersonID" runat="server" Text="PersonID"></asp:Label>
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
</td>
<td>
<asp:Label ID="lblSampleDate" runat="server" Text="SampleDate"></asp:Label>
<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
</td>
<td>
<asp:Label ID="lblLabSubmissionDate" runat="server" Text="LabSubmissionDate"></asp:Label>
<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox> 
</td>
<td>
<asp:Label ID="lblLeadValue" runat="server" Text="LeadValue"></asp:Label>
<asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
</td>
</tr>
</table>
<asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
<asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" />
<asp:Button ID="btnOk" runat="server" Text="OK" OnClick="btnOk_Click" />
</div>
<div>
<!--
<asp:DataGrid ID="Grid1" runat="server" PageSize="5" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
<Columns>
<asp:BoundColumn HeaderText="BloodTestResultsID" DataField="BloodTestResultsID"></asp:BoundColumn>
<asp:BoundColumn HeaderText="isBaseline" DataField="isBaseline"></asp:BoundColumn>
<asp:BoundColumn HeaderText="PersonID" DataField="PersonID"></asp:BoundColumn>
<asp:BoundColumn DataField="SampleDate" HeaderText="SampleDate"></asp:BoundColumn>
<asp:BoundColumn DataField="LabSubmissionDate" HeaderText="LabSubmissionDate"></asp:BoundColumn>
<asp:BoundColumn DataField="LeadValue" HeaderText="LeadValue"> </asp:BoundColumn>
</Columns>
<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
<SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
<PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
<AlternatingItemStyle BackColor="White" />
<ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
<HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
</asp:DataGrid>
-->
</div>
</form>
</body>
</html>