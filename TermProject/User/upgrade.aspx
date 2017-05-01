<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="TermProject.User.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Upgrade Storage</strong></h3>
                </div>
                <div class="panel-body">

                    <h3><strong>DEAL OF THE CENTURY!!!
                    </strong>
                    </h3>
                    <h3 style="font-size: medium">For limited time, permanently add 10 MB to your Cloud storage for low low price of $19.99. No refund, no restriction of number of upgrades. Tax included.
                    </h3>

                    <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_top">
                        <input type="hidden" name="cmd" value="_s-xclick">
                        <input type="hidden" name="hosted_button_id" value="Q8MBAL485YKZS">
                        <h3>
                            <input type="image" src="https://www.sandbox.paypal.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
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
        Thomas: Request extra credit for this feature. If Paypal didn't work first time, keep trying. Paypal developer site is not very stable.
    </p>
</asp:Content>
