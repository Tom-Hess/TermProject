<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="forum.ascx.cs" Inherits="TermProject.forum" %>


                        <asp:Label ID="lblMsg" runat="server" text=""></asp:Label>
                        <asp:GridView ID="gvForum" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True"
                            OnPageIndexChanging="gvForum_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="Id" ReadOnly="true" HeaderText="Question ID" SortExpression="Question ID" />
                                    <asp:BoundField DataField="Question" ReadOnly="true" HeaderText="Question"  />
                                    <asp:BoundField DataField="CUser" ReadOnly="true" HeaderText="User Email"  />
                                    <asp:BoundField DataField="Answer" HeaderText="Answer"  />
                                    <asp:BoundField DataField="Admin" ReadOnly="true" HeaderText="Admin" />
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
                    