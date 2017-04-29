<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="accountSetting.ascx.cs" Inherits="TermProject.accountSetting" %>

<div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Account Setting</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div style="text-align: center">
                        <asp:Button ID="btnChangePW" runat="server" Text="Change My Password" OnClick="btnChangePW_Click" />
                        &nbsp&nbsp
                        <asp:Button ID="btnChangeAccountInfo" runat="server" Text="Edit Account Information" OnClick="btnChangeAccountInfo_Click" />
                        </div>
                        <div id="dvChangePW" visible="false" runat="server" style="text-align:center">
                            <br />
                            <asp:Label ID="lblCurrentPW" runat="server" Text="Current Password: "></asp:Label>
                            &nbsp&nbsp
                            <asp:TextBox ID="txtCurrentPW" TextMode="Password"  runat="server"></asp:TextBox>
                            <br /><br />
                            <asp:Label ID="lblNewPW" runat="server" Text="New Password: "></asp:Label>
                            &nbsp&nbsp
                            <asp:TextBox ID="txtNewPW" TextMode="Password" runat="server"></asp:TextBox>
                            <br /><br />
                            <asp:Label ID="lblConfirm" runat="server" Text="Confirm new password: "></asp:Label>
                            &nbsp&nbsp
                            <asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
                            <br /><br />
                            <asp:Button ID="btnUpdatePW" runat="server" Text="Update Password" OnClick="btnUpdatePW_Click" />
                            <br />
                            <asp:Label id ="lblUpdatePWError" ForeColor="Red" runat="server"></asp:Label>
                        </div>

                        <div id="dvEditInfo" runat="server" visible="false" style="text-align:center">
                            <br />
                            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
                            &nbsp&nbsp
                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            <br /><br />
                            <asp:Label ID="lblName" runat="server" Text="Name: "></asp:Label>
                            &nbsp&nbsp
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <br /><br />

                            <asp:Button ID="btnUpdateInfo" runat="server" Text="Update Account Information" OnClick="btnUpdateInfo_Click" />
                            <br />
                            <asp:Label id ="lblUpdateInfoError" ForeColor="Red" runat="server"></asp:Label>

                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>