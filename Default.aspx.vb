Imports System.Data.SqlClient

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub db_Click(sender As Object, e As EventArgs) Handles db.Click
        Dim databaseName As String = "NewDatabase2"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        'aspnet-autobooks-20230806100312
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Create a new command to execute SQL commands
                Dim command As New SqlCommand($"CREATE DATABASE {databaseName}", connection)
                command.ExecuteNonQuery()
                dblabel.Text = databaseName

            End Using
        Catch ex As Exception
            dblabel.Text = ex.Message

            'Console.WriteLine($"Error creating database: {ex.Message}")
        End Try
    End Sub
End Class