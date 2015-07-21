﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ClientFollowUp.aspx.cs" Inherits="ReportPages_ClientFollowUp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Summary Report</h2>

        <table>
                        <tr>
                <td>Start Date: <br /> <em>(MM/DD/YYYY)</em></td>
                <td><asp:TextBox ID="tbStartDate" runat="server" placeholder="MM/dd/yyyy" tooltip="Start Date of the Date Range (Optional)"></asp:TextBox>

<ajaxtoolkit:CalendarExtender ID="CalendarExtender2" 
    runat="server" 
    PopupPosition="Right"
    PopupButtonID="tbStartDate" 
    TargetControlID="tbStartDate" 
    Format="MM/dd/yyyy" >
</ajaxtoolkit:CalendarExtender>

<asp:CompareValidator
    id="dateValidator" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbStartDate" 
    ErrorMessage="Please enter a valid date." ForeColor="Red">
</asp:CompareValidator>

                </td>

                <td>End Date: <br /> <em>(MM/DD/YYYY)</em></td>
                <td><asp:TextBox ID="tbEndDate" runat="server" placeholder="MM/dd/yyyy" tooltip="End Date of the Date Range (Optional)" ></asp:TextBox>

<ajaxtoolkit:CalendarExtender ID="CalendarExtender1" 
    runat="server" 
    PopupPosition="Right"
    PopupButtonID="tbEndDate" 
    TargetControlID="tbEndDate" 
    Format="MM/dd/yyyy" >
</ajaxtoolkit:CalendarExtender>

<asp:CompareValidator
    id="CompareValidator1" runat="server" 
    Type="Date"
    Operator="DataTypeCheck"
    ControlToValidate="tbEndDate" 
    ErrorMessage="Please enter a valid date." ForeColor="Red">
</asp:CompareValidator>

                </td>

                            <td>
                                <asp:Button runat="server" ID="btnApplyDate" Text="Apply Date Range Filter &gt;&gt;" OnClick="btnApplyDate_Click" />
                            </td>
            </tr>
        

        </table>

        <p>&nbsp;</p>

    <div class="DD">

        <h2 class="DDSubHeader">Clients For Follow Up</h2>
       
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\ClientFollowUp.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ClientFollowUpDataSet1" Name="ClientFollowUpDataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        <asp:SqlDataSource ID="ClientFollowUpDataSet1" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="usp_SlClientFollowUp" SelectCommandType="StoredProcedure">
        
            <SelectParameters>
                <asp:Parameter Name="StartDate" Type="String"></asp:Parameter>
                <asp:Parameter Name="EndDate" Type="String"></asp:Parameter>
            </SelectParameters>

        </asp:SqlDataSource>

        </div>

</asp:Content>
