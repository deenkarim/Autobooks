Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.SqlClient

Public Class Item
    Public Shared Property SelectedOrg As String

    Public Shared Function CountOrg(admin As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim result As Integer = 0
        Dim sql As String = $"SELECT COUNT(id) FROM Item where admin='{admin}'"

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
    Public Shared Function GetItems(id As Integer, Optional ByVal ItemID As Integer = -1, Optional ByVal Status As Integer = 0) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim sql As String = $"SELECT ID, [Item Name],SKU, [Product Type], Rate AS Price FROM Items where OrganisationID={id}"
        If Not ItemID = -1 Then sql = $"SELECT TOP 1 ID, [Item Name],SKU, [Product Type], Rate AS Price, Description, Status FROM Items where OrganisationID={id} AND ID={ItemID}"
        If Not Status = 0 Then sql += sql & " AND NOT Status='Deactive'"
        Dim dataTable As New DataTable()
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(sql, connection)
                Dim adapter As New SqlDataAdapter(command)
                adapter.Fill(dataTable)
            End Using
        End Using
        Return dataTable

    End Function


    Public Shared Function CreateItem(OrgID As String, ItemName As String, SKU As String, Description As String, Rate As String,
                                          TaxName As String, TaxPercent As String, TaxType As String, ProductType As String, Status As String, Optional ByVal ID As Integer = -1) As String
        Dim sqlStr As String
        If ID = -1 Then

            sqlStr = $"INSERT INTO Items (OrganisationID, [Item Name], SKU, Description, Rate, [Tax1 Name], [Tax1 Percentage],  
                                [Tax1 Type],[Product Type],[Status]) 
                                VALUES ('{OrgID}', '{ItemName}', '{SKU}', 
                                        '{Description}', '{Rate}', '{TaxName}', '{TaxPercent}',
                                        '{TaxType}', '{ProductType}','{Status}'
                                       )"
        Else
            sqlStr = $"UPDATE Items SET OrganisationID ='{OrgID}', [Item Name]='{ItemName}', SKU='{SKU}',
                                Description='{Description}', Rate='{Rate}', [Tax1 Name]='{TaxName}', [Tax1 Percentage]='{TaxPercent}', 
                                [Tax1 Type]='{TaxType}', [Product Type]='{ProductType}', [Status]='{Status}'                             
                                WHERE ID='{ID}'"
        End If

        Return SQLHelper.Insert(sqlStr)
    End Function

End Class
