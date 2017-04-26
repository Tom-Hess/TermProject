<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="TermProject.User.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Upgrade Storage Capacity</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <h3>
                                Deal of the Century!!! 100 GB of cloud storage for only $19.99! 
                                Upgrade your cloud NOW!!! Click the button to proceed to checkout. 
                                SMASH THAT BUTTON NOW!!!
                            </h3>
                            <h3>
                                <asp:Button runat="server" ID="btn" Text="Checkout" OnClick="btn_Click"  /> 
                            </h3>
                            
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
