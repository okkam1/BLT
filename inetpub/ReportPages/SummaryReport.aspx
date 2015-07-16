<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SummaryReport.aspx.cs" Inherits="ReportPages_SummaryReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Summary Report</h2>
       

                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\SummaryReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SummaryReportDataSet1" Name="SummaryReportDataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SummaryReportDataSet1" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="usp_SlSummaryReport" SelectCommandType="StoredProcedure">
        
        
        </asp:SqlDataSource>

        </div>

</asp:Content>
