<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Customers.aspx.vb" Inherits="autobooks.Customers" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="NewC" runat="server" Visible="false">
         <asp:TextBox ID="txtID" runat="server"   Visible="false" Text="-1"></asp:TextBox>
        <div class="card">

            <div class="card-body">
                 <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Customer Type</label>
                     <div class="form-check form-check-inline">
                         <asp:RadioButtonList ID="CustomerType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                           
                             <asp:ListItem Value="1" class="radio-inline" Selected="True">&nbsp;&nbsp; Business</asp:ListItem>
                             
                             <asp:ListItem Value="2" class="radio-inline">&nbsp;&nbsp; Individual</asp:ListItem>
                         </asp:RadioButtonList>
                     </div>
                </div>
                <div class="mb-3">

                    <div class="row">
 <label for="exampleInputEmail1" class="form-label">Contact</label>
                        
                        <div class="col">
                            <asp:DropDownList ID="ddlTitle" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                <asp:ListItem Value="Miss">Miss</asp:ListItem>
                                <asp:ListItem Value="Dr">Dr</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtFName" runat="server" CssClass="form-control" placeholder="First Name" ></asp:TextBox>
                        </div>
                        <div class="col">
                            <asp:TextBox ID="txtSName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Company Name</label>
                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Company Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                 <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Company Phone</label>
                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
             
            </div>
  </div>

     <!-- extra fields -->
            <ul class="nav nav-tabs mb-3" id="pills-tab" role="tablist">
  <li class="nav-item" role="presentation">
    <button class="nav-link active" id="pills-other-tab" data-bs-toggle="pill" data-bs-target="#pills-other" type="button" role="tab" aria-controls="pills-home" aria-selected="true">Other Details</button>
  </li>
  <li class="nav-item" role="presentation">
    <button class="nav-link" id="pills-address-tab" data-bs-toggle="pill" data-bs-target="#pills-address" type="button" role="tab" aria-controls="pills-profile" aria-selected="false">Address</button>
  </li>
  <li class="nav-item" role="presentation">
    <button class="nav-link" id="pills-notes-tab" data-bs-toggle="pill" data-bs-target="#pills-notes" type="button" role="tab" aria-controls="pills-contact" aria-selected="false">Notes</button>
  </li>
</ul>
<div class="tab-content" id="pills-tabContent">
  <div class="tab-pane fade show active" id="pills-other" role="tabpanel" aria-labelledby="pills-other-tab">
         <div class="card">
            <div class="card-body">
                 <div class="mb-3">
                    <div class="row align-items-start">
                         <div class="col-6 col-sm-2">
                        <label for="exampleInputEmail1" class="form-label">Currency</label>                        
                             </div>
                        <div class="col-6 col-sm-2">
                            <asp:DropDownList ID="ddlCurrency" runat="server" CssClass="form-control" AutoPostBack="true">
                                <asp:ListItem Value="GBP">GBP</asp:ListItem>
                                <asp:ListItem Value="EUR">EUR</asp:ListItem>
                                <asp:ListItem Value="USD">USD</asp:ListItem>
                                <asp:ListItem Value="AUD">AUD</asp:ListItem>
                                <asp:ListItem Value="CAD">CAD</asp:ListItem>
                            </asp:DropDownList>
                        </div>             
                    </div>
                </div>
                <div class="mb-3">
                    <div class="row align-items-start">
                        <div class="col-6 col-sm-2">
                            <label for="exampleInputPassword1" class="form-label">Opening Balance</label>
                        </div>
                        <div class="col-6 col-sm-2">
                            <div class="input-group">
                                <span class="input-group-prepend">
                                    <div class="input-group-text bg-transparent border-right-0">
                                        <asp:Label ID="lblCurrency" runat="server" Text="GBP"></asp:Label>
                                    </div>
                                </span>
                                <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control"></asp:TextBox>


                            </div>

                        </div>
                    </div>
                </div>
                <div class="mb-3">
                    <div class="row align-items-start">
                        <div class="col-6 col-sm-2">
                            <label for="exampleInputPassword1" class="form-label">Payment Terms</label>
                        </div>
                        <div class="col-6 col-sm-2">

                            <asp:DropDownList ID="ddlPaymentTerms" runat="server" CssClass="form-control">
                                <asp:ListItem Value="Net 15">Net 15</asp:ListItem>
                                <asp:ListItem Value="Net 30">Net 30</asp:ListItem>
                                <asp:ListItem Value="Net 45">Net 45</asp:ListItem>
                                <asp:ListItem Value="Net 60">Net 60</asp:ListItem>
                                <asp:ListItem Value="Reciept" Selected="true">Due on Reciept</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
         </div>
  </div>
    <div class="tab-pane fade" id="pills-address" role="tabpanel" aria-labelledby="pills-address-tab">
          <div class="card">
            <div class="card-body">
                 <div class="mb-3">
                    <div class="row align-items-start">
                         <div class="col-6 col-sm-2">
                        <label for="exampleInputEmail1" class="form-label">Address</label>                        
                             </div>
                        <div class="col-6 col-sm-5">
                             <asp:TextBox ID="txtAddress1" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" ></asp:TextBox>

                        </div>             
                    </div>
                     <div class="row">
                         <div class="col-6 col-sm-2">&nbsp;</div>
                           <div class="col-6 col-sm-5"></div>   
                     </div>
                     <div class="row">
                         <div class="col-6 col-sm-2">&nbsp;</div>
                           <div class="col-6 col-sm-5">
                             <asp:TextBox ID="txtAddress2" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" ></asp:TextBox>
                        </div>   
                     </div>
                </div>
                <div class="mb-3">
                    <div class="row align-items-start">
                        <div class="col-6 col-sm-2">
                            <label for="exampleInputPassword1" class="form-label">City</label>
                        </div>
                        <div class="col-6 col-sm-5">
                             <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="mb-3">
                    <div class="row align-items-start">
                        <div class="col-6 col-sm-2">
                            <label for="exampleInputPassword1" class="form-label">State / County</label>
                        </div>
                        <div class="col-6 col-sm-5">
                            <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>
                  <div class="mb-3">
                    <div class="row align-items-start">
                        <div class="col-6 col-sm-2">
                            <label for="exampleInputPassword1" class="form-label">Zip / Post Code</label>
                        </div>
                        <div class="col-6 col-sm-5">
                            <asp:TextBox ID="txtPostcode" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
         </div>
    </div>
  <div class="tab-pane fade" id="pills-notes" role="tabpanel" aria-labelledby="pills-notes-tab">  
      <div class="card">
            <div class="card-body">
                 <div class="mb-3">
                    <div class="row">
                         <div class="col-6 col-sm-2">
                        <label for="exampleInputEmail1" class="form-label">Notes</label>                        
                             </div>
                        <div class="col-6 col-sm-6">
                            <asp:TextBox ID="txtNotes" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" ></asp:TextBox>
                        </div>             
                    </div>
                </div>
            </div>
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
