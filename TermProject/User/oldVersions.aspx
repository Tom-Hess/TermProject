<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="oldVersions.aspx.cs" Inherits="TermProject.User.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Previous File Versions</strong></h3>
                </div>
                <div class="panel-body" style="text-align:center">
                    <form id="form1" runat="server">
                        <div>
                            <asp:GridView ID="gvFiles" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowCommand="gvFiles_RowCommand" >
                                <Columns>
                                    <asp:BoundField DataField="fileID" ReadOnly="true" HeaderText="File ID" SortExpression="title" />
                                    <asp:BoundField DataField="title" HeaderText="File Name" SortExpression="title" />
                                    <asp:BoundField DataField="timestamp" ReadOnly="true" HeaderText="Time Uploaded" SortExpression="timestamp" />
                                    <asp:BoundField DataField="length" ReadOnly="true" HeaderText="Size (Bytes)" SortExpression="length" />

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnRestore" runat="server" 
                                            CommandName="Restore" 
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Restore" />
                                        </ItemTemplate> 
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" runat="server" 
                                            CommandName="DeleteRow" 
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Delete" />
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
                        </div>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                        <br /><br />
                        <asp:Button ID="btnEmptyFiles" runat="server" Text="Delete all Files" OnClick="btnEmptyFiles_Click"/>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
