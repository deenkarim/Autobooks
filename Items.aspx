<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Items.aspx.vb" Inherits="autobooks.Items"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="row">
         <div class="col">
             <asp:PlaceHolder ID="CustomerTable" runat="server" Visible="false">
                 <div class="table-responsive">
                     <asp:GridView ID="tblCustomers" runat="server" CssClass="table text-nowrap mb-0">
                         <HeaderStyle CssClass="text-dark fs-4" />
                     </asp:GridView>
                 </div>
             </asp:PlaceHolder>
         </div>
      
    <asp:PlaceHolder ID="NewC" runat="server" Visible="false" >
       <asp:TextBox ID="txtID" runat="server"   Visible="false" Text="-1"></asp:TextBox>
        <div class="card">

            <div class="card-body">
                 <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Type</label>
                     <div class="form-check form-check-inline">
                         <asp:RadioButtonList ID="Type" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                           
                             <asp:ListItem Value="1" class="radio-inline" Selected="True">&nbsp;&nbsp; Goods</asp:ListItem>
                             
                             <asp:ListItem Value="2" class="radio-inline">&nbsp;&nbsp; Services</asp:ListItem>
                         </asp:RadioButtonList>
                     </div>
                </div>
                <div class="mb-3">
                    <div class="row">
                            <label for="exampleInputEmail1" class="form-label">Name</label>
                        <div class="col">
                           <asp:TextBox ID="txtName" runat="server" CssClass="form-control"  ></asp:TextBox>
                        </div> 
                    </div>
                </div>
                 <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">SKU</label>
                    <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Price</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
                </div>
             <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Status</label>
                     <div class="form-check form-check-inline">
                         <asp:DropDownList ID="ddlStatus" runat="server" class="form-select form-control-lg">
                             <asp:ListItem Value="Active"  Selected="True" class="form-select">Active</asp:ListItem>
                             <asp:ListItem Value="Deactive" class="form-select">Deactive</asp:ListItem>
                         </asp:DropDownList>
                       
                     </div>
                </div>
            </div>
  </div>

    </asp:PlaceHolder>
    
    
   

   
     

        
    </div>

</asp:Content>
