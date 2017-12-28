﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AutoCompleteTest.aspx.cs" Inherits="autoCompleteTest" Trace="true" EnableViewState="true" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server"></asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="DD">

    <h2 class="DDSubHeader">Find Client(s) in Lead Research Study</h2>

    <fieldset style="width:300px">
    <legend>Search Fields</legend>
    <p> PersonID: 
        <asp:TextBox ID="tbPersonID" runat="server"></asp:TextBox>
    </p>
    <p> First Name:
        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchFirstName"
        MinimumPrefixLength="2"
        CompletionInterval="25" EnableCaching="false" CompletionSetCount="10"
        TargetControlID="tbFirstName"
        ID="AutoCompleteExtender4" runat="server" FirstRowSelected = "false" UseContextKey="True">
        </ajaxToolkit:AutoCompleteExtender>
    </p>
    <p> Last Name:
        <asp:TextBox ID="tbLastName" runat="server" onkeyup="SetContextKey()"></asp:TextBox>
        <ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchLastName"
        MinimumPrefixLength="2"
        CompletionInterval="25" EnableCaching="false" CompletionSetCount="10"
        TargetControlID="tbLastName"
        ID="AutoCompleteExtender3" runat="server" FirstRowSelected = "false" UseContextKey="True">
        </ajaxToolkit:AutoCompleteExtender>
    </p>
    <p>
    Month: <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlMonth_SelectedIndexChanged">
            <asp:ListItem>-</asp:ListItem>
            <asp:ListItem>Jan</asp:ListItem>
            <asp:ListItem>Feb</asp:ListItem>
            <asp:ListItem>Mar</asp:ListItem>
            <asp:ListItem>Apr</asp:ListItem>
            <asp:ListItem>May</asp:ListItem>
            <asp:ListItem>Jun</asp:ListItem>
            <asp:ListItem>Jul</asp:ListItem>
            <asp:ListItem>Aug</asp:ListItem>
            <asp:ListItem>Sept</asp:ListItem>
            <asp:ListItem>Oct</asp:ListItem>
            <asp:ListItem>Nov</asp:ListItem>
            <asp:ListItem>Dec</asp:ListItem>
        </asp:DropDownList>  
    Day: <asp:DropDownList ID="ddlDay" runat="server">
            <asp:ListItem>-</asp:ListItem>
        </asp:DropDownList>
    Year: <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList>
     </p>
     <p>
     <asp:Button ID="SearchByTagButton" runat="server" Text="SEARCH"
            onclick="SearchByTagButton_Click" align=right/>
     </p>
     
    </fieldset>
<asp:CustomValidator ID="Validator" runat="server" ErrorMessage="* Required" ClientValidationFunction = "Validate" />
        <p>&nbsp;</p>

    <asp:GridView ID="gvClients" runat="server" AllowSorting="true" AllowPaging="true"
        AutoGenerateEditButton="false" DataKeyNames="PersonId"
        AutoGenerateColumns="false" AutoGenerateDeleteButton="false" AutoGenerateSelectButton="False" CssClass="DD">
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="ID" DataField="PersonID" SortExpression="PersonID" />
            <asp:BoundField ReadOnly="true" HeaderText="First Name" DataField="FirstName" SortExpression="FirstName" />
            <asp:BoundField ReadOnly="true" HeaderText="Last Name" DataField="LastName" SortExpression="LastName" />
            <asp:BoundField ReadOnly="true" HeaderText="Birth Date" DataField="BirthDate" SortExpression="BirthDate" />

        <%-- Hyperink to edit client info --%>
        <asp:hyperlinkfield datatextfield="PersonId"
        datanavigateurlfields="PersonId" HeaderText="EditClientInfo"
        datanavigateurlformatstring="EditClientInfo.aspx?pid={0}"  Target="_blank" SortExpression="PersonID"/>
        <%-- Hyperink to edit blood lead results info --%>
        <asp:hyperlinkfield datatextfield="PersonId"
        datanavigateurlfields="PersonId" HeaderText="EditBloodLeadResults"
        datanavigateurlformatstring="EditBloodLeadResults.aspx?pid={0}"  Target="_blank" SortExpression="PersonID"/>
        <%-- Hyperink to edit questionnaire info --%>
        <asp:hyperlinkfield datatextfield="PersonId"
        datanavigateurlfields="PersonId" HeaderText="EditQuestionnaire"
        datanavigateurlformatstring="EditQuestionnaire.aspx?pid={0}"  Target="_blank" SortExpression="PersonID"/>
    </Columns>

    </asp:GridView>
    
        <p>&nbsp;</p>

 <script type = "text/javascript">
     function SetContextKey() {
         $find('<%=AutoCompleteExtender3.ClientID%>').set_contextKey($get("<%=tbFirstName.ClientID %>").value);
    }
</script>
</div>

    </div>

    </asp:Content>