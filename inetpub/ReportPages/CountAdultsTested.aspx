<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeFile="CountAdultsTested.aspx.cs" Inherits="ReportPages_CountAdultsTested" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
            <h2 class="DDSubHeader">Count of Adults Tested</h2>
       
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\CountAdultsTested.rdl">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="AdultsTested" Name="AdultsTested" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="AdultsTested" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP %>" SelectCommand="usp_SlCountAdults" SelectCommandType="StoredProcedure">
        </asp:SqlDataSource>

      </div>


   </asp:Content>