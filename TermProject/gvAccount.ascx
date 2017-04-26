<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="gvAccount.ascx.cs" Inherits="TermProject.gvAccount" %>

<asp:GridView ID="gvManagement" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
    OnRowCancelingEdit="gvManagement_RowCancelingEdit"
    OnRowEditing="gvManagement_RowEditing"
    OnRowUpdating="gvManagement_RowUpdating"
    OnRowDeleting="gvManagement_RowDeleting"
    OnRowCommand="gvManagement_RowCommand"
    OnPageIndexChanging="gvManagment_PageIndexChanging"
    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True">
    <Columns>
        <asp:BoundField DataField="AccountID" ReadOnly="true" HeaderText="User ID" SortExpression="User ID" />
        <asp:BoundField DataField="Name" ReadOnly="true" HeaderText="User Name" SortExpression="Name" />
        <asp:BoundField DataField="AccountType" ReadOnly="true" HeaderText="Account Type" />
        <asp:BoundField DataField="Email" ReadOnly="true" HeaderText="Email Address" SortExpression="Email" />
        <asp:BoundField DataField="StorageSpace" HeaderText="Storage Capacity" SortExpression="StorageSpace" />
        <asp:BoundField DataField="StorageUsed" ReadOnly="true" HeaderText="StorageUsed" SortExpression="StorageUsed" />
        <asp:CommandField ButtonType="Button" EditText="Modify" ShowEditButton="True" ShowHeader="True" HeaderText="Update Account" />
        <asp:TemplateField HeaderText="Delete Account" ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="Button1" runat="server" CausesValidation="False"
                    CommandName="Delete" Text="Delete" OnClientClick="return fnConfirmDelete();"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Reset Password" ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnReset" runat="server" CausesValidation="false"
                    CommandName="ResetPassword" Text="Reset Password"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Deactivate / Activate Account" ShowHeader="False">
            <ItemTemplate>
                <asp:Button ID="btnDeactiaveOrActiavate" runat="server" CausesValidation="false"
                    CommandName="activateORDeactiavate" Text="Switch"
                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
    <RowStyle BackColor="White" ForeColor="#003399" />
    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
    <SortedAscendingCellStyle BackColor="#EDF6F6" />
    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
    <SortedDescendingCellStyle BackColor="#D6DFDF" />
    <SortedDescendingHeaderStyle BackColor="#002876" />
</asp:GridView>
