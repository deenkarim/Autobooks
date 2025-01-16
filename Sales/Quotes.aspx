<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Quotes.aspx.vb" Inherits="autobooks.Quotes" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="NewC" runat="server" Visible="false">
         <asp:TextBox ID="txtID" runat="server"   Visible="false" Text="-1"></asp:TextBox>
        <div class="card">

            <div class="card-body">
                 <div class="mb-3">

                     <div class="row">
                         <label for="exampleInputEmail1" class="form-label">Customer</label>
                         <div class="col">
                             <asp:DropDownList ID="ddlCustomer"   runat="server" CssClass="form-control selectpicker" aria-label="Default select example" data-live-search="true"  AutoPostBack="true">
                             </asp:DropDownList>
                         </div>
                     </div>
                 </div>
                <div class="mb-3">

                    <div class="row">

                        <label for="exampleInputEmail1" class="form-label">Quote #</label>

                        <div class="col">
                            <asp:TextBox ID="txtQuoteNo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="mb-3">
                    <div class="row">
                        <div class="col">
                    <label for="exampleInputPassword1" class="form-label">Quote Date</label>
                            </div>
                         <div class="col">
                    <asp:TextBox ID="txtQuoteDate" runat="server" CssClass="form-control" type="date" ></asp:TextBox>
                             </div>
                         <div class="col">
                        <label for="exampleInputPassword1" class="form-label">Expiry Date</label>
                             </div>
                              <div class="col">
                    <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" type="date" ></asp:TextBox>
                                  </div>
                        </div>

                </div>
               
                 <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Subject</label>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
             
                 <div class="mb-3">
                      
                         <asp:Table ID="tblItems" runat="server" CssClass="table text-nowrap mb-0 align-middle">
                             <asp:TableHeaderRow CssClass="text-dark fs-4">
                                 <asp:TableHeaderCell>
                                        <h6 class="fw-semibold mb-0">Item Details</h6>
                                 </asp:TableHeaderCell>
                                 <asp:TableHeaderCell>
                          <h6 class="fw-semibold mb-0">Quantity</h6>
                                 </asp:TableHeaderCell>
                                 <asp:TableHeaderCell>
                          <h6 class="fw-semibold mb-0">Rate</h6>
                                 </asp:TableHeaderCell>
                                 <asp:TableHeaderCell>
                          <h6 class="fw-semibold mb-0">Discount</h6>
                                 </asp:TableHeaderCell>
                                 <asp:TableHeaderCell>
                          <h6 class="fw-semibold mb-0">Amount</h6>
                                 </asp:TableHeaderCell>
                             </asp:TableHeaderRow>

                             <asp:TableRow>
                                 <asp:TableCell>
                                     <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control selectpicker" aria-label="Default select example" data-live-search="true" AutoPostBack="true">
                                     </asp:DropDownList>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                                 </asp:TableCell>
                                 <asp:TableCell>
                                     <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
                                 </asp:TableCell>
                             </asp:TableRow>
                         </asp:Table>
                </div>
                 <div class="mb-3">
                     <asp:Button runat="server" ID="addItem" class="btn btn-primary " Text="Add Line" />
                     </div>

            </div>
  </div>
     
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="CustomerTable" runat="server" Visible="false">
        <div class="table-responsive">
            <asp:GridView ID="tblCustomers" runat="server" CssClass="table text-nowrap mb-0">
                <HeaderStyle CssClass="text-dark fs-4" />
            </asp:GridView>
        </div>
    </asp:PlaceHolder>


</asp:Content>
