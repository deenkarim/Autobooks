Imports System.Security.Policy
Imports Microsoft.AspNet.Identity

Public Class SiteMaster
    Inherits MasterPage
    Private Const AntiXsrfTokenKey As String = "__AntiXsrfToken"
    Private Const AntiXsrfUserNameKey As String = "__AntiXsrfUserName"
    Private _antiXsrfTokenValue As String

    Protected Sub Page_Init(sender As Object, e As EventArgs)
        ' The code below helps to protect against XSRF attacks
        Dim requestCookie = Request.Cookies(AntiXsrfTokenKey)
        Dim requestCookieGuidValue As Guid
        If requestCookie IsNot Nothing AndAlso Guid.TryParse(requestCookie.Value, requestCookieGuidValue) Then
            ' Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value
            Page.ViewStateUserKey = _antiXsrfTokenValue
        Else
            ' Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N")
            Page.ViewStateUserKey = _antiXsrfTokenValue

            Dim responseCookie = New HttpCookie(AntiXsrfTokenKey) With {
                 .HttpOnly = True,
                 .Value = _antiXsrfTokenValue
            }
            If FormsAuthentication.RequireSSL AndAlso Request.IsSecureConnection Then
                responseCookie.Secure = True
            End If
            Response.Cookies.[Set](responseCookie)
        End If

        AddHandler Page.PreLoad, AddressOf master_Page_PreLoad
    End Sub

    Protected Sub master_Page_PreLoad(sender As Object, e As EventArgs)
        If Not IsPostBack Then
            ' Set Anti-XSRF token
            ViewState(AntiXsrfTokenKey) = Page.ViewStateUserKey
            ViewState(AntiXsrfUserNameKey) = If(Context.User.Identity.Name, [String].Empty)
        Else
            ' Validate the Anti-XSRF token
            If DirectCast(ViewState(AntiXsrfTokenKey), String) <> _antiXsrfTokenValue OrElse DirectCast(ViewState(AntiXsrfUserNameKey), String) <> (If(Context.User.Identity.Name, [String].Empty)) Then
                Throw New InvalidOperationException("Validation of Anti-XSRF token failed.")
            End If
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Gen.CountOrg(Context.User.Identity.GetUserName()) > 0 Then
                ' show list else
                OrganisationList.DataSource = Gen.GetOrgansiations(Context.User.Identity.GetUserName())
                OrganisationList.DataTextField = "Organisation"
                OrganisationList.DataValueField = "id"
                OrganisationList.DataBind()
                OrganisationList.Visible = True
                OrgButton.Visible = False

                'set last known selected company or default to top

                If Gen.SelectedOrg Is Nothing Then
                    Gen.SelectedOrg = OrganisationList.SelectedValue
                Else
                    OrganisationList.SelectedValue = Gen.SelectedOrg
                End If


            Else
                OrganisationList.Visible = False
                OrgButton.Visible = True

            End If

            SetTitle()

        End If


    End Sub
    Public Sub SetTitle()
        Dim url As String = HttpContext.Current.Request.Url.AbsolutePath
        If url.ToLower.Contains("sales/customers") Then
            titlepage.Text = "Customers"
            subsales.Attributes.Add("class", "collapse show nav")
            acustomer.Attributes.Add("class", "sidebar-link active")
        End If

        If url.ToLower.Contains("sales/invoices") Then
            titlepage.Text = "Invoices"
            subsales.Attributes.Add("class", "collapse show nav")
            ainvoices.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("sales/quotes") Then
            titlepage.Text = "Quotes"
            subsales.Attributes.Add("class", "collapse show nav")
            aquotes.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("purchases/bills") Then
            titlepage.Text = "Bills"
            subpurchases.Attributes.Add("class", "collapse show nav")
            abills.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("purchases/expenses") Then
            titlepage.Text = "Expenses"
            subpurchases.Attributes.Add("class", "collapse show nav")
            aexpenses.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("purchases/orders") Then
            titlepage.Text = "Orders"
            subpurchases.Attributes.Add("class", "collapse show nav")
            aorders.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("purchases/suppliers") Then
            titlepage.Text = "Suppliers"
            subpurchases.Attributes.Add("class", "collapse show nav")
            asuppliers.Attributes.Add("class", "sidebar-link active")
        End If
        If url.ToLower.Contains("items") Then
            titlepage.Text = "Items"
            aitems.Attributes.Add("class", "sidebar-link active")
        End If

        If titlepage.Text.Length > 0 Then titleControl.Visible = True

    End Sub
    Protected Sub Unnamed_LoggingOut(sender As Object, e As LoginCancelEventArgs)
        Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie)
    End Sub

    Private Sub OrganisationList_TextChanged(sender As Object, e As EventArgs) Handles OrganisationList.TextChanged
        'update selected company 
        Gen.SelectedOrg = OrganisationList.SelectedValue
        'update platform 

    End Sub

    Private Sub createNew_Click(sender As Object, e As EventArgs) Handles createNew.Click
        Dim url As String = HttpContext.Current.Request.Url.AbsolutePath
        ' -------------------------------------------- SAVE --------------------------------------------
        If createNew.Text = "Save" Then
            setButtons(0)
            'save details
            'update page/table

            If Url.ToLower.Contains("sales/customers") Then
                Dim c As Customers = TryCast(Page, Customers)
                If c IsNot Nothing Then c.SaveCustomer()
            End If

            If url.ToLower.Contains("items") Then
                Dim c As Items = TryCast(Page, Items)
                If c IsNot Nothing Then c.Save()
            End If
            If url.ToLower.Contains("sales/quotes") Then
                Dim q As Quotes = TryCast(Page, Quotes)
                If q IsNot Nothing Then q.Save()
            End If

            'update page/table
            SetPanel("NewC", False)
            'update table
            Exit Sub
        End If
        ' -----------------------------------------LOAD FORMS -------------------------------------------
        setButtons(1)
        If url.ToLower.Contains("sales/customers") Then SetPanel("CustomerTable", False)
        If url.ToLower.Contains("items") Then SetPanel("CustomerTable", False)

        If url.ToLower.Contains("sales/quotes") Then
            Dim q As Quotes = TryCast(Page, Quotes)
            If q IsNot Nothing Then q.setNew()
            SetPanel("CustomerTable", False)

        End If

        SetPanel("NewC", True)
        SetTitle()


    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim url As String = HttpContext.Current.Request.Url.AbsolutePath

        If createNew.Text = "Save" Then
            ' close form and update
            setButtons(0)
            'save details
            SetPanel("NewC", False)
            'update page/table

            If Url.ToLower.Contains("sales/customers") Then
                Dim c As Customers = TryCast(Page, Customers)
                If c IsNot Nothing Then
                    c.SetTable(True)
                    c.EmptyEditor()
                End If
            End If
        End If


    End Sub
    Public Sub setButtons(ByVal switch As Integer)
        If switch = 0 Then
            createNew.Text = "+ New"
            createNew.CssClass = "btn btn-primary"
            btnClose.Visible = False
        ElseIf switch = 1 Then
            createNew.Text = "Save"
            createNew.CssClass = "btn btn-danger"
            btnClose.Visible = True
        End If
    End Sub
    Public Function SetPanel(ByVal name As String, ByVal show As Boolean)
        Try
            Dim ct As Control
            ct = MainContent.FindControl(name)
            CType(ct, PlaceHolder).Visible = show
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Sub OrganisationList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OrganisationList.SelectedIndexChanged
        Server.TransferRequest(Request.Url.AbsolutePath, False)

    End Sub
End Class