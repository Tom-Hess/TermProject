<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="userForum.aspx.cs" Inherits="TermProject.User.WebForm8" %>

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
        function addQuestion() {
            var question = document.getElementById("txtQuestion").value;
            var params = "question=" + question;

            // Open a new asynchronous request, set the callback function, and send the request.
            xmlhttp.open("POST", "userForum.aspx", true);
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

                        <table>
                            <tr>
                                <td>Question: </td>
                                <td>
                                    <input type="text" id="txtQuestion" required="required" /></td>
                            </tr>
                        </table>
                        <br />
                        <input type="button" value="add" onclick="addQuestion();" />
                    </form>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        This page utilize custom user control and AJAX
    </p>
</asp:Content>
