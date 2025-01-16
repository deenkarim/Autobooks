Imports System.Net.NetworkInformation
Imports System.Reflection

Public Class Quotes
    Inherits System.Web.UI.Page
    Public Shared SelectedCustomer As String
    Public Shared LastQuote As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            SelectedCustomer = -1
            'load table
            LoadTable()
            SetTable(True)
        End If

    End Sub
    Public Sub LoadTable()
        tblCustomers.DataSource = Quote.Load(Gen.SelectedOrg)
        tblCustomers.DataBind()
    End Sub
    Public Sub Save()
        Quote.Create(SelectedCustomer, txtQuoteNo.Text, txtQuoteDate.Text, txtExpiryDate.Text, txtSubject.Text, "", "", "", "", "", "", Gen.SelectedOrg, txtID.Text)
        Gen.UpdateLastQuote(Quotes.LastQuote + 1)
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

        Next
        txtID.Text = "-1"

    End Sub
    Sub setNew()
        EmptyEditor()
        PopulateCustomers() ' populate customer list
        PopulateItems()

        'create quote number
        Dim QuoteNo As String
        Dim pad As Integer = 7
        Quotes.LastQuote = Gen.getLastQuote
        pad = pad - LastQuote.Length
        QuoteNo = (LastQuote + 1).ToString.PadLeft(pad, "0")
        txtQuoteNo.Text = Gen.getQuotePrefix & QuoteNo


    End Sub
    Sub PopulateCustomers()
        ddlCustomer.Items.Clear()

        Dim d As DataTable = Customer.GetCustomers(Gen.SelectedOrg)
        ddlCustomer.Items.Add(New ListItem("Select a customer ", -1))
        For Each i As Data.DataRow In d.Rows
            'add customer to list
            Dim l As New ListItem
            l.Value = i(0).ToString
            l.Text = i(1).ToString & " - " & i(3).ToString & " " & i(4).ToString
            ddlCustomer.Items.Add(l)
        Next

    End Sub
    Sub PopulateItems()
        ddlItem.Items.Clear()

        Dim d As DataTable = Item.GetItems(Gen.SelectedOrg,, 1)
        ddlItem.Items.Add(New ListItem("Select a item ", -1))
        For Each i As Data.DataRow In d.Rows
            'add customer to list
            Dim l As New ListItem
            l.Value = i(0).ToString
            l.Text = i(1).ToString
            l.Attributes.Add(1, i(4).ToString)
            ddlItem.Items.Add(l)
        Next

    End Sub

    Private Sub ddlCustomer_TextChanged(sender As Object, e As EventArgs) Handles ddlCustomer.TextChanged
        SelectedCustomer = ddlCustomer.SelectedValue
    End Sub

    Private Sub ddlItem_TextChanged(sender As Object, e As EventArgs) Handles ddlItem.TextChanged
        'populate
        txtPrice.Text = ddlItem.SelectedItem.Attributes.Count

    End Sub

    Private Sub addItem_Click(sender As Object, e As EventArgs) Handles addItem.Click
        ' duplicate table row

    End Sub
End Class