<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="TermProject.User.WebForm6" %>

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
    function submit()
    {
        var updateOption = document.getElementById("option").value;

        var params = "option=" + option;
        // Open a new asynchronous request, set the callback function, and send the request.
        xmlhttp.open("POST", "AJAX_PostProcess.aspx", true);
        xmlhttp.onreadystatechange = onComplete;
        // set the HTTP request headers for the information being sent using POST
        xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        xmlhttp.setRequestHeader("Content-length", params.length);
        xmlhttp.send(params);
    }
    // Callback function used to update the page when the server completes a response
    // to an asynchronous request.
    function onComplete()
    {  
        //Response is READY and Status is OK
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            //document.getElementById("content_area").innerHTML = xmlhttp.responseText;
        }
    }
    </script>

    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Upgrade Storage</strong></h3>
                </div>
                <div class="panel-body">
                    <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_top">
                        <input type="hidden" name="cmd" value="_s-xclick">
                        <input type="hidden" name="hosted_button_id" value="Q8MBAL485YKZS">
                        <h3><strong>DEAL OF THE CENTURY!!!
                        </strong>
                        </h3>
                        <h3 style="font-size: medium">For limited time, upgrade your Cloud storage.
                        </h3>
                        <h3 style="font-size: medium"><strong>Option 1</strong>: 10 MB for $9.99
                        </h3>
                        <h3 style="font-size: medium"><strong>Option 2</strong>: 30 MB for $19.99
                        </h3>
                        <h3 style="font-size: medium"><strong>Option 3</strong>: 50 MB for $29.99
                        </h3>
                        <h3 style="font-size: medium"><strong>Tax included. No refunds! </strong>
                        </h3>
                        <div class="text-center">
                        <input type="hidden" name="on0" value="Price Option"><strong><span style="font-size: x-large">Choose an option Below</span></strong></div>
                        <h3>
                            <select name="os0" id="option">
                                <option value="Option 1">Option 1 - 10MB for $9.99 USD</option>
                                <option value="Option 2">Option 2 - 30MB for $19.99 USD</option>
                                <option value="Option 3">Option 3 - 50MB for $29.99 USD</option>
                            </select>
                        </h3>
                        <input type="hidden" name="currency_code" value="USD">
                        <h3>
                            <input type="image" src="https://www.sandbox.paypal.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!" onclick="submit()">
                        </h3>
                        <img alt="" border="0" src="https://www.sandbox.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        For PayPal test account, user name: pikewall05-buyer@gmail.com, password: TermProject.
        Thomas: Request extra credit for this feature.
    </p>
</asp:Content>
