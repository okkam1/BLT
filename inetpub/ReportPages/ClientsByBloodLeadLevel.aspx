<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ClientsByBloodLeadLevel.aspx.cs" Inherits="ReportPages_ResearchSubjectByAge" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb"%>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DD">

        <h2 class="DDSubHeader">Clients by Blood Lead Level </h2>
       
       <table>
            <tr>
                <td>Minimum Blood Lead Level: <br /> <em>(xx.x)</em></td>
                <td><asp:TextBox ID="tbMinLeadValue" runat="server" tooltip="Minimum blood lead Value (Optional)"></asp:TextBox></td>
                  <asp:CompareValidator
                    id="CompareValidator1" runat="server" 
                    Type="Double"
                    Operator="DataTypeCheck"
                    ControlToValidate="tbMinLeadvalue" 
                    ErrorMessage="Please enter a decimal value." ForeColor="Red">
                </asp:CompareValidator>

                <td>Maximum Blood Lead Level: <br /> <em>(xx.x)</em></td>
                <td><asp:TextBox ID="tbMaxLeadValue" runat="server" tooltip="Maximum blood lead Value (Optional)" ></asp:TextBox>

                <asp:CompareValidator
                    id="CompareValidator2" runat="server" 
                    Type="Double"
                    Operator="DataTypeCheck"
                    ControlToValidate="tbMaxLeadvalue" 
                    ErrorMessage="Please enter a decimal value." ForeColor="Red">
                </asp:CompareValidator>

                </td>

                            <td>
                                <asp:Button runat="server" ID="btnApplyLeadValueFilter" 
                                    Text="Apply Blood Lead Level Range Filter &gt;&gt;" 
                                    OnClick="btnApplyLeadValueFilter_Click" />
                            </td>
            </tr>
        

        </table>

        <p>&nbsp;</p>

       
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportPath="Reports\ClientsByBloodLeadLevelOcean.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ClientsByBloodLeadLevelDataSet1" Name="ClientsByBloodLeadLevelDataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>

        
        <asp:SqlDataSource ID="ClientsByBloodLeadLevelDataSet1" runat="server" ConnectionString="<%$ ConnectionStrings:csLCCHP%>" SelectCommand="usp_SLAllBloodTestResults2" SelectCommandType="StoredProcedure">
         <SelectParameters>
                <asp:Parameter Name="Min_Lead_Value" Type="Double"></asp:Parameter>
                <asp:Parameter Name="Max_Lead_Value" Type="Double"></asp:Parameter>
            </SelectParameters>

        </asp:SqlDataSource>

        </div>


</asp:Content>