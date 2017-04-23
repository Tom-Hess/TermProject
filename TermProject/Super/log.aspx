<%@ Page Title="" Language="C#" MasterPageFile="~/Super/Super.Master" AutoEventWireup="true" CodeBehind="log.aspx.cs" Inherits="TermProject.Super.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Administrator Log</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Administrator Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            <br />
                            <br />
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
                            <asp:GridView ID="gvLog" HorizontalAlign="Center" AutoGenerateColumns="False" 
                                runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="AccountID" ReadOnly="true" HeaderText="User ID" SortExpression="Id" />
                                    <asp:BoundField DataField="Action" ReadOnly="true" HeaderText="Action" />
                                    <asp:BoundField DataField="Timestamp" ReadOnly="true" HeaderText="Timestamp" />
                                    <asp:BoundField DataField="StorageCapacity" ReadOnly="true" HeaderText="Capacity"  />
                                </Columns>
                                <EditRowStyle BackColor="#2461BF" />
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
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
