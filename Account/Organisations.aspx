<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Organisations.aspx.vb" Inherits="autobooks.Organisations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="row">
          <div class=" d-flex align-items-strech">
            <div class="card w-100">
              <div class="card-body">
                <div class="d-sm-flex d-block align-items-center justify-content-between mb-9">
                  <div class="mb-3 mb-sm-0">
                    <h5 class="card-title fw-semibold">My Organisations</h5>
                  </div>
                    <asp:TextBox runat="server" ID="OrgName" CssClass="form-control w-25 ti-align-right" Visible="false" ></asp:TextBox> &nbsp;
                    
                     <asp:Button class="btn btn-primary btn-md" runat="server" ID="add"  Text="Add Organisation"/>
                </div>
                
                <div>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="OrgName"
                                        CssClass="text-danger" ErrorMessage="Organisation Name required." />
                    
                    <div class="table-responsive">
                    <asp:GridView ID="OrganisationList" runat="server" CssClass="table text-nowrap mb-0 align-middle">
                        <HeaderStyle CssClass="text-dark fs-4" />
                    </asp:GridView>
                      </div>
                   
                </div>
              </div>
            </div>
          </div>
       

</asp:Content>
