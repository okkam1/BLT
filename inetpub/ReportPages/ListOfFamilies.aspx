﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ListOfFamilies.aspx.cs" Inherits="ReportPages_ListOfFamilies" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">List of Families</h2>
       
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\FamilyReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSourcePerson" Name="DataSetPerson" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SqlDataSourcePerson" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="SELECT * FROM [Person] where isClient=1"></asp:SqlDataSource>

        </div>

</asp:Content>
