<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="trash.aspx.cs" Inherits="TermProject.User.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Trash</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div>
                            <asp:GridView ID="gvFiles" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" OnRowDeleting="gvFiles_RowDeleting" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
                                <Columns>
                                    <asp:ImageField DataImageUrlField="ImagePath" ReadOnly="true" HeaderText="Image" ItemStyle-Height="50px" ItemStyle-Width="50px"
                                        ControlStyle-Width="50" ControlStyle-Height="50">
                                        <ControlStyle Height="50px" Width="50px"></ControlStyle>
                                        <ItemStyle Height="50px" Width="50px"></ItemStyle>
                                    </asp:ImageField>
                                    <asp:BoundField DataField="FileID" ReadOnly="true" HeaderText="File ID" SortExpression="title" />
                                    <asp:BoundField DataField="Title" HeaderText="File Name" SortExpression="title" />
                                    <asp:BoundField DataField="Timestamp" ReadOnly="true" HeaderText="Time Added" SortExpression="timestamp" />
                                    <asp:BoundField DataField="Length" ReadOnly="true" HeaderText="Size (Bytes)" SortExpression="length" />

                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Restore" />
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
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

