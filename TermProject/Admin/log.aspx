<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="TermProject.Admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Transaction History</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            <br /><br />
                            <asp:Label runat="server" ID="lblFrom" Text="From Date (Format: mm/dd/yyyy): "></asp:Label>
                            <asp:TextBox runat="server" ID="txtFrom"></asp:TextBox>
                            <asp:Label runat="server" ID="lblTo" Text="To Date: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtTo"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnFind" Text="Find" OnClick="btnFind_Click" />
                            <asp:Label runat="server" ID="lblMsg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
                        <div>
                            <asp:GridView ID="gvTransactionLog" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="ID" SortExpression="title" />
                                    <asp:BoundField DataField="title" HeaderText="File Name" SortExpression="title" />
                                    <asp:BoundField DataField="type" ReadOnly="true" HeaderText="Type" SortExpression="type" />
                                    <asp:BoundField DataField="timestamp" ReadOnly="true" HeaderText="Time Added" SortExpression="timestamp" />
                                    <asp:BoundField DataField="length" ReadOnly="true" HeaderText="Size" SortExpression="length" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
