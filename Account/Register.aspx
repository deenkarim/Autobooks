<%@ Page Title="Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/blank.Master" CodeBehind="Register.aspx.vb" Inherits="autobooks.Register" %>

<%@ Import Namespace="autobooks" %>
<%@ Import Namespace="Microsoft.AspNet.Identity" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <!--  Body Wrapper -->
    <div class="page-wrapper" id="main-wrapper" data-layout="vertical" data-navbarbg="skin6" data-sidebartype="full"
        data-sidebar-position="fixed" data-header-position="fixed">
        <div
            class="position-relative overflow-hidden radial-gradient min-vh-100 d-flex align-items-center justify-content-center">
            <div class="d-flex align-items-center justify-content-center w-100">
                <div class="row justify-content-center w-100">
                    <div class="col-md-8 col-lg-6 col-xxl-3">
                        <div class="card mb-0">
                            <div class="card-body">
                                <a href="~/" class="text-nowrap logo-img text-center d-block py-3 w-100">
                                    <img src="../../assets/images/logos/dark-logo.svg" width="180" alt="">
                                </a>
                                <p class="text-center">Create a new account</p>
                                <p class="text-center">
                                    <asp:Literal runat="server" ID="ErrorMessage" /></p>
                                <p class="text-center">
                                    <asp:ValidationSummary runat="server" CssClass="text-danger" />
                                </p>

                                <div class="mb-3">
                                    <label for="exampleInputtext1" class="form-label">Email</label>
                                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                        CssClass="text-danger" ErrorMessage="The email field is required." />

                                </div>
                                <div class="mb-4">
                                    <label for="exampleInputPassword1" class="form-label">Password</label>
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                                        CssClass="text-danger" ErrorMessage="The password field is required." />
                                </div>
                                <div class="mb-4">
                                    <label for="exampleInputPassword1" class="form-label">Confirm Password</label>
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />

                                </div>

                                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Signup" CssClass="btn btn-primary w-100 py-8 fs-4 mb-4 rounded-2" />
                                <div class="d-flex align-items-center justify-content-center">
                                    <p class="fs-4 mb-0 fw-bold">Already have an Account?</p>
                                    <a runat="server" class="text-primary fw-bold ms-2" href="~/Account/Login">Sign in</a>

                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
