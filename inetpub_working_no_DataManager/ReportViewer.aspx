<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReportViewer.aspx.cs" Inherits="Reports" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">
       

        <h2 class="DDSubHeader">Local Reports</h2>

        List of Families
        
        <rsweb:ReportViewer ID="ReportViewer4" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\FamilyReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSetLiam" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="SELECT * FROM [Person]"></asp:SqlDataSource>

&nbsp;<rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
           <LocalReport ReportPath="Reports/FamilyReport.rdlc">
               <DataSources>
                   <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSetL" />
               </DataSources>
           </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="testingdb" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP %>" SelectCommand="usp_CountParticipantsByAge" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="LeadTrackingTestingDataSetTableAdapters.FamilyTableAdapter"></asp:ObjectDataSource>

        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData" TypeName="LeadTrackingTestingDataSetTableAdapters.FamilyTableAdapter"></asp:ObjectDataSource>

        
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetData" TypeName="LeadTrackingTestingLiamDataSetTableAdapters.FamilyTableAdapter"></asp:ObjectDataSource>

        
       <rsweb:ReportViewer ID="ReportViewer3" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
           <LocalReport ReportPath="Reports/CountSubjectsPie.rdlc">
               <DataSources>
                   <rsweb:ReportDataSource DataSourceId="testingdb" Name="DataSet1" />
               </DataSources>
           </LocalReport>
        </rsweb:ReportViewer>

        
        <h2 class="DDSubHeader">Available Reports</h2>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ProcessingMode="Remote" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <ServerReport ReportServerUrl="http://iago/ReportServer_PETRUCHIO" DisplayName="List of Familiesr" ReportPath="/BLDTA/ListOfFamilies" />
        </rsweb:ReportViewer>

        <ul>
        <li><a target="_blank" href="http://iago/ReportServer_PETRUCHIO/Pages/ReportViewer.aspx?%2fBLDTA%2fListOfFamilies&rs:Command=Render">List of Families</a></li>

        <li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fListOfSubjectsByLastName">List of Research Subjects by Last Name</a></li>


<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsPie">Number of Research Subjects by Age</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Number of children</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Number of nursing mothers</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Number of new clients</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Number of parents</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">All Lead levels above 5</a></li>
    
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Report on potential duplicates</a></li>
<li><a target="_blank" href="http://iago/Reports_PETRUCHIO/Pages/Report.aspx?ItemPath=%2fBLDTA%2fCountSubjectsBar">Reminder reports for retest for 30 / 60 / 90 days until 1 year from previous test</a></li>
    </ul>

        </div>

</asp:Content>
