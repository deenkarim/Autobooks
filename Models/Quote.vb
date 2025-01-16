Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.SqlClient
Public Class Quote
    Public Shared Function Create(CustomerID As String, QuoteNo As String, QuoteDate As String, ExpiryDate As String, Subject As String, Status As String,
                                         Shipping As String, Adjustment As String, Description As String, Notes As String,
                                         Terms As String, OrgID As String, ID As Integer) As String

        Dim sqlStr As String
        If ID = -1 Then
            sqlStr = $"INSERT INTO Quotes ([CustomerID] ,[Quote Number] ,[Quote Date],[Expiry Date],[Subject] ,[Status] ,[Shipping Charge], 
                                            [Adjustment] ,[Description] ,[Notes], [TermsConditions], [OrganisationID])
                                VALUES('{CustomerID}', '{QuoteNo}', '{QuoteDate}', '{ExpiryDate}', '{Subject}', '{Status}', '{Shipping}',
                                        '{Adjustment}', '{Description}','{Notes}', '{Terms}', '{OrgID}'
                                       )"
        Else
            sqlStr = $"UPDATE Quotes SET OrganisationID ='{OrgID}',
                                [CustomerID]='{CustomerID}', [Quote Number]='{QuoteNo}', [Quote Date]='{QuoteDate}', [Expiry Date]='{ExpiryDate}', 
                                Subject='{Subject}', Status='{Status}', [Shipping Charge]='{Shipping}',[Adjustment]='{Adjustment}', 
                                [Description]='{Description}',[Notes]='{Notes}',[TermsConditions]='{Terms}',[OrganisationID]='{OrgID}'
                                WHERE ID='{ID}'"
        End If
        ' also insert each item part of quote
        Return SQLHelper.Insert(sqlStr)
    End Function

    Public Shared Function Load(id As Integer, Optional ByVal qID As Integer = -1) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        Dim sql As String = $"SELECT ID,[Quote Number] FROM Quotes where OrganisationID={id}"
        If Not qID = -1 Then sql = $"SELECT TOP 1 * FROM Quotes where OrganisationID={id} AND ID={qID}"
        Return SQLHelper.SelectDataTable(sql)
    End Function
End Class
