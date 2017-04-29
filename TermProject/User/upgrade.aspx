<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="TermProject.User.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Upgrade</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post" target="_top">
                        <input type="hidden" name="cmd" value="_s-xclick">
                        <input type="hidden" name="hosted_button_id" value="Q8MBAL485YKZS">
                        <img alt="" border="0" src="https://www.sandbox.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">

                        <div class="form-group">
                            <h3>&nbsp;DEAL OF THE CENTURY!!!
                            </h3>
                        </div>
                        <div class="form-group" style="text-align: center">
                            <p>
                                For limited time, upgrade your cloud to 1 GB for low low price of $19.99!!! Shipping and handling included. 
                            </p>
                        </div>
                        <h3>
                            <input type="image" src="https://www.sandbox.paypal.com/en_US/i/btn/btn_buynowCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
                        </h3>

                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <p>
        For PayPal test account, user name: pikewall05-buyer@gmail.com, password: TermProject.
    </p>
</asp:Content>
