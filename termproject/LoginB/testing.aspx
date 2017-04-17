<%@ Page Title="" Language="C#" MasterPageFile="~/LoginB/login.Master" AutoEventWireup="true" CodeBehind="testing.aspx.cs" Inherits="TermProject.LoginB.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px">
        <div class="col-md-10 col-md-offset-1">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <br />
                    <h3 class="panel-title"><strong>Testing Page</strong></h3>
                </div>
                <div class="panel-body">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <p>
                                Web Method 1: get account info. Input: Email. Output: a person class
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblEmail" Text="Email: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            <asp:Button runat="server" ID="btnMethod1" Text="Method 1 Submit" OnClick="btnMethod1_Click" />
                            <asp:Label runat="server" ID="lblMsg1" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lbl1" Text="Email: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1email" Text=""></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lbl2" Text="Name: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1Name" Text=""></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lbl3" Text="Password: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1password" Text=""></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lbl4" Text="StorageSpace: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1StorageSpace" Text=""></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lbl5" Text="StorageUsed: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1StorageUsed" Text=""></asp:Label>
                            <br />
                            <asp:Label runat="server" ID="lbl6" Text="AccountType: "></asp:Label>
                            <asp:Label runat="server" ID="lblM1AccountType" Text=""></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 2: Update account. Require execution of Web Method 1. Input: Person Class and old email. Output: None. To see the result of the method, do Web Method 1.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label2" Text="NewEmail: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM2newEmail"></asp:TextBox>
                            <asp:Button runat="server" ID="btnM2submit" Text="Method 2 Submit" OnClick="btnM2submit_Click" />
                            <asp:Label runat="server" ID="lblM2Msg" Text=""></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 3: get a file and upload a file. Input: File. Output: boolean. Result will be displayed in the label below. File will be upload into Web Method 1's user's cloud.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:FileUpload ID="fuUpload" runat="server" />
                            <br />
                            <asp:Button runat="server" ID="btnM3submit" Text="Method 3 Submit" OnClick="btnM3submit_Click" />
                            <asp:Label runat="server" ID="lblM3msg" Text=""></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 4: get a user's cloud. Input: AccountID. Output: DataSet of history. 
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label1" Text="ID: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM4ID"></asp:TextBox>
                            <asp:Button runat="server" ID="btnM4submit" Text="Method 4 Submit" OnClick="btnM4submit_Click" />
                            <asp:Label runat="server" ID="lblM4msg" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:GridView ID="gvM4" runat="server"></asp:GridView>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 5: Update a file's name. Input: FileID, which can be retrieved from Web Method 4, and new file name. 
                                Output: none. User Web Method 4 to verify the result. 
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label3" Text="FileID: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM5ID"></asp:TextBox>
                            <asp:Label runat="server" ID="Label5" Text="New File Name: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM5name"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM5submit" Text="Method 5 Submit" OnClick="btnM5submit_Click" />
                            <asp:Label runat="server" ID="lblM5msg" Text=""></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 6: get file upload history of an account. Input: user's email, start and end date. 
                                Output: DataSet of the history. 
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label4" Text="Email Address: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM6email"></asp:TextBox>
                            <asp:Label runat="server" ID="lblFrom" Text="From Date: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM6from"></asp:TextBox>
                            <asp:Label runat="server" ID="lblTo" Text="To Date: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM6to"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM6msg" Text="Method 6 Submit" OnClick="btnM6msg_Click" />
                            <asp:Label runat="server" ID="lblM6msg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <div>
                            <asp:GridView ID="gvM6" runat="server"></asp:GridView>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 7: delete a file from user's cloud. Input: FileID. Output: none. User Web Method 4 verify the result.
                            </p>
                            
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label6" Text="FileID: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM7ID"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM7Submit" Text="Method 7 Submit" OnClick="btnM7Submit_Click" />
                            <asp:Label runat="server" ID="lblM7msg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />

                        <div class="form-group">
                            <p>
                                Web Method 8: update user's storageUsed. Input: Email and size to increase or decrease (positvie for increase, negative for decrease). Output: none. Use Method 1 to verify result.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label7" Text="Email: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM8email"></asp:TextBox>
                            <asp:Label runat="server" ID="Label9" Text="Size: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM8size"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM8submit" Text="Method 8 Submit" OnClick="btnM8submit_Click" />
                            <asp:Label runat="server" ID="lblM8msg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 9: get all account's info. Input: None. Output: DataSet of all acount.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM9submit" Text="Method 9 Submit" OnClick="btnM9submit_Click" />
                            <asp:Label runat="server" ID="lblM9msg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:GridView ID="gvM9" runat="server"></asp:GridView>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 10: update a user's storage capacity. Input: ID and size. Output: None. Use Method 1 to verify the result.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="Label8" Text="ID: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM10ID"></asp:TextBox>
                            <asp:Label runat="server" ID="Label10" Text="Size: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM10size"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="btnM10submit" Text="Method 10 Submit" OnClick="btnM10submit_Click"  />
                            <asp:Label runat="server" ID="lblM10msg" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
                        <div class="form-group">
                            <p>
                                Web Method 11: delete an account. Input: ID. Output: Number of rows affected by this action. Use Method 1 to verify result of this acction.
                            </p>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblM10ID" Text="ID: "></asp:Label>
                            <asp:TextBox runat="server" ID="txtM11ID"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Button runat="server" ID="Button1" Text="Method 10 Submit" OnClick="btnM10submit_Click"  />
                            <asp:Label runat="server" ID="Label13" Text="" ForeColor="#FF3300"></asp:Label>
                        </div>
                        <br />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
