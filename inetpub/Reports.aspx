<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Available Reports</h2>

        <ul>
            <li><a href="ReportPages/ListOfClients.aspx">List of ALL Clients </a></li>
        </ul>

         <ul>   
            <li><a href="ReportPages/ClientsByAge.aspx">Count of Clients by Age</a></li>
            <li><a href="ReportPages/ClientsByAgeGroup.aspx">Count of Clients by Age Group</a></li>
            <li><a href="ReportPages/CountAdultsTested.aspx">Count of Adults Tested</a></li>
        </ul>

         <ul>   
            <li><a href="ReportPages/ListOfClients30.aspx">List of New Clients -- Last 30 Days</a></li>
            <li><a href="ReportPages/ListOfClients60.aspx">List of New Clients -- Last 60 Days</a></li>
            <li><a href="ReportPages/ListOfClients90.aspx">List of New Clients -- Last 90 Days</a></li>
        </ul>

         <ul>   
            <li><a href="ReportPages/ClientsByBloodLeadLevel.aspx">List of Clients By Blood Lead Level</a></li>

<!--
        <li><a href="#">List of Research Subjects by Last Name</a></li>
        <li><a href="#">Number of Research Subjects by Age</a></li>
        <li><a href="#">Number of children</a></li>
        <li><a href="#">Number of nursing mothers</a></li>
        <li><a href="#">Number of new clients</a></li>
        <li><a href="#">Number of parents</a></li>
        <li><a href="#">All Lead levels above 5</a></li>
    
        <li><a href="#">Report on potential duplicates</a></li>
        <li><a href="#">Reminder reports for retest for 30 / 60 / 90 days until 1 year from previous test</a></li>
-->
    </ul>

        </div>

</asp:Content>
