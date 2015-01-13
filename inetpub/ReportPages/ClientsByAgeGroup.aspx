<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClientsByAgeGroup.aspx.cs" Inherits="ReportPages_ResearchSubjectByAge" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Clients by Age Group</h2>
       
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\CountClientsByAgeGroup.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="CountByAgeGroupDataSet" Name="CountByAgeGroupDataSet" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        
        <asp:SqlDataSource ID="CountByAgeGroupDataSet" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="usp_SlCountPeopleByAgeGroup" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        </div>

</asp:Content>