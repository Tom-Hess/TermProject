<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="cloud.aspx.cs" Inherits="TermProject.User.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>File Cloud</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div>
                            <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvFiles_RowCancelingEdit" OnRowEditing="gvFiles_RowEditing" OnRowUpdating="gvFiles_RowUpdating" OnRowDeleting="gvFiles_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="File ID" SortExpression="title" />
                                    <asp:BoundField DataField="title" HeaderText="File Name" SortExpression="title" />
                                    <asp:BoundField DataField="type" ReadOnly="true" HeaderText="Type" SortExpression="type" />
                                    <asp:BoundField DataField="timestamp" ReadOnly="true" HeaderText="Time Added" SortExpression="timestamp" />
                                    <asp:BoundField DataField="length" ReadOnly="true" HeaderText="Size" SortExpression="length" />

                                    <asp:CommandField ButtonType="Button" HeaderText="Rename File" ShowEditButton="True" ShowHeader="True" />


                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />


                                </Columns>

                            </asp:GridView>
                        </div>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
