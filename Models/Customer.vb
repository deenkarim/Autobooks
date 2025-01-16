Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.SqlClient
Imports System.Web.Services

Public Class Customer
    Public Shared Property SelectedOrg As String

    Public Shared Function CountOrg(admin As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim result As Integer = 0
        Dim sql As String = $"SELECT COUNT(id) FROM Customers where admin='{admin}'"

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
    Public Shared Function GetCustomers(id As Integer, Optional ByVal ItemID As Integer = -1) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim sql As String = $"SELECT ID,[Company Name],Salutation, [First Name], [Last Name], EmailID AS Email, Phone FROM Customers where OrganisationID={id}"
        If Not ItemID = -1 Then sql = $"SELECT TOP 1 * FROM Customers where OrganisationID={id} AND ID={ItemID}"

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


    Public Shared Function CreateCustomer(OrgID As String, CompanyName As String, Title As String, FName As String, SName As String,
                                          Email As String, Phone As String, PaymentsTerms As String, CountryCode As String,
                                          CurrencyCode As String, Notes As String, BillingAddress As String, BillingAddress2 As String, BillingCity As String,
                                          BillingState As String, BillingCountry As String, BillingCode As String, Type As Integer, Balance As String, ID As Integer) As String

        Dim sqlStr As String
        If ID = -1 Then

            sqlStr = $"INSERT INTO Customers (OrganisationID, [Company Name], Salutation, [First Name], [Last Name], EmailID, Phone,
                                [Payments Terms],[Country Code],[Currency Code],[Notes],[Billing Address],[Billing City],[Billing State], 
                                [Billing Country],[Billing Code], Type,Balance, [Billing Address2])
                                VALUES('{OrgID}', '{CompanyName}', '{Title}', '{FName}', '{SName}', '{Email}', '{Phone}',
                                        '{PaymentsTerms}', '{CountryCode}','{CurrencyCode}', '{Notes}', '{BillingAddress}', '{BillingCity}','{BillingState}', 
                                        '{BillingCountry}', '{BillingCode}','{Type}', '{Balance}','{BillingAddress2}'
                                       )"
        Else
            sqlStr = $"UPDATE Customers SET OrganisationID ='{OrgID}',
                                [Company Name]='{CompanyName}', Salutation='{Title}', [First Name]='{FName}', [Last Name]='{SName}', 
                                EmailID='{Email}', Phone='{Phone}', [Payments Terms]='{PaymentsTerms}',[Country Code]='{CountryCode}', 
                                [Currency Code]='{CurrencyCode}',[Notes]='{Notes}',[Billing Address]='{BillingAddress}',[Billing City]='{BillingCity}',
                                [Billing State]='{BillingState}',[Billing Country]='{BillingCountry}',[Billing Code]='{BillingCode}',  [Type]='{Type}', 
                                Balance='{Balance}',[Billing Address2]='{BillingAddress2}'                            
                                WHERE ID='{ID}'"
        End If

        Return SQLHelper.Insert(sqlStr)
    End Function

End Class
