<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClientsByBloodLeadLevel.aspx.cs" Inherits="ReportPages_ResearchSubjectByAge" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Clients by Blood Lead Level
        </h2>
       
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" 
            Text="MinBLL" />
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
       
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\ClientsByBloodLeadLevelOcean.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ClientsByBloodLeadLevelDataSet" Name="ClientsByBloodLeadLevelDataSet" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        
        <asp:SqlDataSource ID="ClientsByBloodLeadLevelDataSet" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="usp_SLAllBloodTestResults" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        </div>


</asp:Content>