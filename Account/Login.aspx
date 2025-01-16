<%@ Page Title="Log in" Language="vb" AutoEventWireup="false" MasterPageFile="~/blank.Master" CodeBehind="Login.aspx.vb" Inherits="autobooks.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

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
                                <p class="text-center">Sign In</p>
                                <p class="text-center">
                                          <asp:PlaceHolder runat="server" ID="ErrorMessage">
                                              <asp:Literal runat="server" ID="FailureText" />
                                          </asp:PlaceHolder>
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
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                                </div>
                                <div class="d-flex align-items-center justify-content-between mb-4">
                                    <div class="form-check">
                                         <asp:CheckBox class="form-check-input primary" runat="server" ID="RememberMe" />
                                    <asp:Label class="form-check-label text-dark" for="flexCheckChecked" runat="server" AssociatedControlID="RememberMe">Remeber this Device</asp:Label>
                                    </div>
                                    <a class="text-primary fw-bold" href="./index.html">Forgot Password ?</a>
                                </div>
                               <asp:Button runat="server" OnClick="Login" Text="Sign In" CssClass="btn btn-primary w-100 
                                   py-8 fs-4 mb-4 rounded-2" />
                                <div class="d-flex align-items-center justify-content-center">
                                    <p class="fs-4 mb-0 fw-bold">New?</p>
                                     <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled" class="text-primary fw-bold ms-2">Create an account</asp:HyperLink>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  </div>

     <div class="row">
            

            <div class="col-md-4">
                <section id="socialLoginForm">
                    <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
                </section>
            </div>
        </div>

</asp:Content>
