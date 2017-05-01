<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="adminForum.aspx.cs" Inherits="TermProject.Admin.WebForm5" %>

<%@ Register Src="~/forum.ascx" TagName="forum" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var xmlhttp;
        try {
            // Code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        }
        catch (try_older_microsoft) {
            try {
                // Code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch (other) {
                xmlhttp = false;
                alert("Your browser doesn't support AJAX!");
            }
        }
        function submitAnswer() {
            var answer = document.getElementById("txtAnswer").value;
            var id = document.getElementById("txtID").value;
            var params = "question=" + question + "&id=" + id;

            // Open a new asynchronous request, set the callback function, and send the request.
            xmlhttp.open("POST", "adminForum.aspx", true);
            xmlhttp.onreadystatechange = onComplete;

            // set the HTTP request headers for the information being sent using POST
            xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlhttp.setRequestHeader("Content-length", params.length);
            xmlhttp.send(params);
        }

        // Callback function used to update the page when the server completes a response
        // to an asynchronous request.
        function onComplete() {
            //Response is READY and Status is OK
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                document.getElementById("Content2").innerHTML = xmlhttp.responseText;
            }
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
                        <br />
                        <uc1:forum ID="forum" runat="server" Visible="True" />
                        <br />
                        <div id="content_area">
                            <table>
                                <tr>
                                    <td>Question ID: </td>
                                    <td>
                                        <input type="text" id="txtID" required="required" /></td>
                                </tr>
                                <tr>
                                    <td>Answer: </td>
                                    <td>
                                        <input type="text" id="txtAnswer" required="required" /></td>
                                </tr>
                            </table>
                            <br />
                            <input type="button" value="submit" onclick="submitAnswer();" />
                        </div>
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
