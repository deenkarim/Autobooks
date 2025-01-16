Imports System.Net.NetworkInformation
Imports Antlr.Runtime.Misc

Public Class Items
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'load table
            LoadTable()
            SetTable(True)
        End If
    End Sub
    Public Sub Save()
        'check if ID exists and update or insert
        Item.CreateItem(Gen.SelectedOrg, txtName.Text, txtSKU.Text, txtDescription.Text, txtPrice.Text, "", "", "", Type.SelectedValue, ddlStatus.SelectedValue, txtID.Text)

        'update table
        LoadTable()
        SetTable(True)
        EmptyEditor()

    End Sub
    Public Sub LoadTable()
        tblCustomers.DataSource = Item.GetItems(Gen.SelectedOrg)


        Try
            tblCustomers.Columns(1).Visible = False
        Catch ex As Exception

        End Try ' tblCustomers.Columns(0).Visible = False
        tblCustomers.DataBind()

    End Sub
    Public Sub EmptyEditor()
        txtID.Text = "-1"
        txtName.Text = ""
        txtSKU.Text = ""
        Type.SelectedValue = 1
        txtPrice.Text = ""
        txtDescription.Text = ""
        ddlStatus.SelectedValue = "Active"

    End Sub

    Public Sub SetTable(ByVal show As Boolean)
        CustomerTable.Visible = show
    End Sub
    Public Sub SetEditor(ByVal show As Boolean)
        NewC.Visible = show
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
        Dim d As DataTable = Item.GetItems(Gen.SelectedOrg, Index)
        For Each i As Data.DataRow In d.Rows
            'load in data
            txtID.Text = i(0).ToString
            txtName.Text = i(1).ToString
            txtSKU.Text = i(2).ToString
            Type.SelectedValue = i(3).ToString
            txtPrice.Text = i(4).ToString
            txtDescription.Text = i(5).ToString
            ddlStatus.SelectedValue = i(6).ToString
        Next
        Dim masterPage As SiteMaster = TryCast(Me.Master, SiteMaster)
        If masterPage IsNot Nothing Then masterPage.setButtons(1)

        ' Dim message As String = "Row Index: " & index & "\nName: " & name + "\nCountry: " & country
        ' ClientScript.RegisterStartupScript(Me.[GetType](), "alert", "alert('" + message + "');", True)
    End Sub

End Class