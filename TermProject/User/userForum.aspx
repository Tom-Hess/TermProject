<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userForum.aspx.cs" Inherits="TermProject.User.WebForm8" %>

<%@ Register Src="~/forum.ascx" TagName="forum" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script language="javascript" type="text/javascript">
        function addQuestion() {
            return
        }
    </script>



    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Support Forum</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
                            <Services>
                            </Services>
                        </asp:ScriptManager>
                        <br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <%--<asp:GridView ID="gvForum" runat="server"></asp:GridView>--%>
                                <uc1:forum ID="forum" runat="server" Visible="True" />
                                <asp:Label runat="server" ID="lblMsg" Text=""></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAdd" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <table>
                            <tr>
                                <td>Question: </td>
                                <td>
                                    <input type="text" id="txtQuestion" runat="server" name="question" required="required" /></td>
                            </tr>
                        </table>
                        <br />
                        <div>
                            
                        </div>
                        <asp:Button runat="server" ID="btnAdd" Text="Add Question" OnClick="btnAdd_Click" />
                    </form>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        This page utilize custom user control and AJAX
    </p>
</asp:Content>
