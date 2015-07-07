<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddEthnicity.ascx.cs" Inherits="AddEthnicity" %>


    <div class="DD">
    
        
        <h2 class="DDSubHeader">Add a NEW Ethnicity</h2>

        <table>
            <tr>
                <td>Ethnicity:</td>
                <td><asp:TextBox ID="tbEthnicity" runat="server"></asp:TextBox></td>
            </tr>
   
        
</table>
        <br /><br />
        
        &nbsp;&nbsp;&nbsp;
        
        <asp:Button ID="btnInsert" runat="server" OnClick="Insert_Click" Text="Insert New Ethnicity" CausesValidation="false" />

        <asp:RequiredFieldValidator ID="rfvNewEthnicity" runat="server" InitialValue="" ErrorMessage="Please select a New Ethnicity" ControlToValidate="tbEthnicity" ForeColor="Red"></asp:RequiredFieldValidator>
    
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />

        <br /><br />
        <asp:Label ID="lbOutput" runat="server" Text=""></asp:Label>
        <br />

</div>    

