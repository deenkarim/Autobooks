Public Class Customers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'load table
            LoadTable()
            SetTable(True)
        End If

    End Sub
    Public Sub LoadTable()
        tblCustomers.DataSource = Customer.GetCustomers(Gen.SelectedOrg)
        tblCustomers.DataBind()
    End Sub
    Public Sub SaveCustomer()
        'check if ID exists and update or insert
        Customer.CreateCustomer(Gen.SelectedOrg, txtCompanyName.Text, ddlTitle.SelectedValue, txtFName.Text, txtSName.Text,
                                txtEmail.Text, txtPhone.Text, ddlPaymentTerms.SelectedValue, "", ddlCurrency.SelectedValue,
                                txtNotes.Text, txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, "", txtPostcode.Text,
                                CustomerType.SelectedValue, txtBalance.Text, txtID.Text)

        'update table
        LoadTable()
        SetTable(True)
        EmptyEditor()


    End Sub
    Public Sub SetTable(ByVal show As Boolean)
        CustomerTable.Visible = show
    End Sub
    Public Sub SetEditor(ByVal show As Boolean)
        NewC.Visible = show
    End Sub
    Public Sub EmptyEditor()
        For Each c As Control In NewC.Controls
            Dim cc As TextBox = TryCast(c, TextBox)
            If Not cc Is Nothing Then cc.Text = ""
            Dim dd As DropDownList = TryCast(c, DropDownList)
            If Not dd Is Nothing Then dd.SelectedIndex = 0
            Dim rr As RadioButtonList = TryCast(c, RadioButtonList)
            If Not rr Is Nothing Then rr.SelectedIndex = 0
        Next
        txtID.Text = "-1"
        lblCurrency.Text = "GBP"
    End Sub

    Private Sub tblCustomers_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles tblCustomers.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes("onclick") = Page.ClientScript.GetPostBackClientHyperlink(tblCustomers, "Select$" & e.Row.RowIndex)
            e.Row.Attributes.Add("onmouseover", "this.style.cursor ='pointer';")

        End If

    End Sub
    Private Sub tblCustomers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tblCustomers.SelectedIndexChanged
        'load editor and details
        SetTable(False)
        SetEditor(True)
        'load form
        Dim Index As Integer = tblCustomers.SelectedRow.Cells(0).Text
        Dim d As DataTable = Customer.GetCustomers(Gen.SelectedOrg, Index)
        For Each i As Data.DataRow In d.Rows
            'load in data
            txtID.Text = i(0).ToString
            Try
                CustomerType.SelectedValue = i(42).ToString
            Catch ex As Exception

            End Try

            ddlTitle.SelectedValue = i(5).ToString
            txtFName.Text = i(6).ToString
            txtSName.Text = i(7).ToString
            txtCompanyName.Text = i(4).ToString
            txtEmail.Text = i(8).ToString
            txtPhone.Text = i(9).ToString
            ddlCurrency.SelectedValue = i(15).ToString
            lblCurrency.Text = ddlCurrency.SelectedValue
            ' ddlCurrency.Enabled = False
            Try
                ddlPaymentTerms.SelectedValue = i(11).ToString
            Catch ex As Exception

            End Try

            txtAddress1.Text = i(20).ToString
            txtAddress2.Text = i(44).ToString
            txtCity.Text = i(21).ToString
            txtState.Text = i(22).ToString
            txtPostcode.Text = i(24).ToString
            txtNotes.Text = i(16).ToString
            txtBalance.Text = i(43).ToString


        Next
        Dim masterPage As SiteMaster = TryCast(Me.Master, SiteMaster)
        If masterPage IsNot Nothing Then masterPage.setButtons(1)

        ' Dim message As String = "Row Index: " & index & "\nName: " & name + "\nCountry: " & country
        ' ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('" + message + "');", True)
    End Sub


    Private Sub ddlCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCurrency.SelectedIndexChanged
        lblCurrency.Text = ddlCurrency.SelectedValue
    End Sub
End Class