Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.SqlClient

Public Class Gen
    Public Shared Property SelectedOrg As String

    Public Shared Function CountOrg(admin As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim result As Integer = 0
        Dim sql As String = $"SELECT COUNT(id) FROM Organisation where admin='{admin}'"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(sql, connection)
                ' ExecuteScalar returns a single value
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                result = count

            End Using
        End Using
        Return result
    End Function
    Public Shared Function getQuotePrefix()
        Return SQLHelper.SelectString($"SELECT QuotePrefix FROM Organisation where id='{SelectedOrg}'")
    End Function
    Public Shared Function UpdateLastQuote(newQuote As String)
        Return SQLHelper.Insert($"UPDATE Organisation SET LastQuote='{newQuote}' where id='{SelectedOrg}'")
    End Function
    Public Shared Function getLastQuote()
        Return SQLHelper.SelectString($"SELECT LastQuote FROM Organisation where id='{SelectedOrg}'")
    End Function
    Public Shared Function lastOrg(admin As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim result As Integer = 0
        Dim sql As String = $"SELECT lastselected FROM Organisation where admin='{admin}'"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(sql, connection)
                ' ExecuteScalar returns a single value
                Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                result = count

            End Using
        End Using
        Return result
    End Function
    Public Shared Function GetOrgansiations(admin As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim sql As String = $"SELECT name as 'Organisation', id FROM Organisation where admin='{admin}'"
        Dim dataTable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(sql, connection)
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dataTable)

                ' Now you have the results in the DataTable
                'For Each row As DataRow In dataTable.Rows
                '    Console.WriteLine($"EmployeeID: {row("EmployeeID")}, FirstName: {row("FirstName")}, LastName: {row("LastName")}, Department: {row("Department")}")
                'Next
            End Using
        End Using
        Return dataTable

    End Function


    Public Shared Function CreateOrganisation(name As String, admin As String) As String
        Dim result As String = "NULL"
        Dim sqlStr As String = $"INSERT INTO Organisation (name, admin) VALUES ('{name}', '{admin}')"
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Create a new command to execute SQL commands
                Dim command As New SqlCommand(sqlStr, connection)
                command.ExecuteNonQuery()

                result = "CREATED"
            End Using
        Catch ex As Exception
            result = ex.Message
        End Try
        Return result
    End Function
    Public Shared Function ExecuteSQL(SQL As String) As String
        Dim result As String
        Try
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Create a new command to execute SQL commands
                Dim command As New SqlCommand(SQL, connection)
                command.ExecuteNonQuery()

                result = "SUCCESS"
            End Using
        Catch ex As Exception
            Result = ex.Message
        End Try
        Return result
    End Function
End Class
