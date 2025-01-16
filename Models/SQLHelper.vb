Imports System
Imports System.Threading.Tasks
Imports System.Security.Claims
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Security
Imports System.Data.SqlClient
Public Class SQLHelper
    Public Shared Function SelectDataTable(ByVal sql As String) As DataTable

        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim da As New SqlDataAdapter(sql, cn)
        Dim dt As New DataTable

        Try
            cn.Open()
            da.Fill(dt)
        Catch ex As Exception
        Finally
            If ConnectionState.Open Then cn.Close()
        End Try
        Return dt
    End Function
    Public Shared Function SelectBoolean(ByVal sql As String)
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim dr As SqlDataReader
        Dim result As Boolean
        Dim cmd As New SqlCommand(sql, cn)
        Try
            cn.Open()
            dr = cmd.ExecuteReader
            If dr.Read() Then ' if there is a record return true
                result = True
            End If
        Catch ex As Exception
            If Not ConnectionState.Closed Then cn.Close()
            result = False
        Finally
            If Not ConnectionState.Closed Then cn.Close()
        End Try
        Return result
    End Function
    Public Shared Function SelectString(ByVal sql As String) As String

        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand(sql, cn)
        Dim result As String

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                result = dr.GetValue(0)
            End If
        Catch ex As Exception
        Finally
            If ConnectionState.Open Then cn.Close()
        End Try
        Return result
    End Function
    Public Shared Function SelectInteger(ByVal sql As String) As Integer

        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand(sql, cn)
        Dim result As Integer

        Try
            cn.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                result = dr.GetValue(0)
            End If
        Catch ex As Exception
        Finally
            If ConnectionState.Open Then cn.Close()
        End Try
        Return result
    End Function
    Public Shared Function Insert(ByVal InsertString As String) As String
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)

        Dim result As String
        Dim cmd As New SqlCommand(InsertString, cn)
        Try
            cn.Open()
            result = cmd.ExecuteScalar()
        Catch ex As Exception
            If Not ConnectionState.Closed Then cn.Close()
            result = False ' an error occured
        Finally
            If Not ConnectionState.Closed Then cn.Close()
        End Try
        Return result
    End Function
    Public Shared Function Update(ByVal UpdateString As String) As Boolean
        Dim result As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim cmd As New SqlCommand(UpdateString, cn)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            If Not ConnectionState.Closed Then cn.Close()
            result = False
        Finally
            If Not ConnectionState.Closed Then cn.Close()
        End Try
        Return result
    End Function
    Public Shared Function Delete(ByVal DeleteString As String) As Boolean
        Dim result As Boolean
        Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString)
        Dim cmd As New SqlCommand(DeleteString, cn)
        Try
            cn.Open()
            cmd.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            If ConnectionState.Open Then cn.Close()
            result = False
        Finally
            If ConnectionState.Open Then cn.Close()
        End Try
        Return result
    End Function
End Class
