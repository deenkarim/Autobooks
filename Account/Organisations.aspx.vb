Imports Microsoft.AspNet.Identity

Public Class Organisations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        OrganisationList.DataSource = Gen.GetOrgansiations(Context.User.Identity.GetUserName())
        OrganisationList.DataBind()

    End Sub

    Private Sub add_Click(sender As Object, e As EventArgs) Handles add.Click
        If OrgName.Visible Then
            Dim result As String = Gen.CreateOrganisation(OrgName.Text, Context.User.Identity.GetUserName())
            ' add org name to database
            'refresh list
            OrganisationList.DataSource = Gen.GetOrgansiations(Context.User.Identity.GetUserName())
            OrganisationList.DataBind()
            OrgName.Visible = False
            add.Text = "Add Organisation"

        Else
            OrgName.Visible = True
            add.Text = "+"

        End If
    End Sub
End Class