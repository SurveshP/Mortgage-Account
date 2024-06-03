Imports System.Data
Imports System.Data.OleDb

Public Class Call_Logs_Edit

    Private Sub Call_Logs_Edit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()

        'txtBillDate.Text = Date.Now()

        ' Me.TopMost = True

        'If connString.State = ConnectionState.Open Then connString.Close()
        'connString.Open()

        'Dim str As String

        'str = "SELECT * from tblGiraveeKhata where id=" & recno1

        'Dim adp As New OleDbDataAdapter(str, connString)

        ''Dim dr As DataRow
        'Dim dt As DataTable
        'Dim ds As New DataSet
        'adp.Fill(ds)
        'dt = ds.Tables(0)

        'For Each dr In dt.Rows

        '    txtRemarks.Text = dr("p_remarks").ToString()

        'Next
        'connString.Close()
    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT * from tblGiraveeKhata"
        'str = "SELECT id,currentDate, p_remarks from tblGiraveeKhata"
        str = "SELECT id,currentDate, p_remarks from tblGiraveeKhata where id=" & recno

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        DataGridView1.DataSource = dt


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()

            sqlquery.CommandText = "UPDATE tblGiraveeKhata SET currentDate=@cCurrentDate, p_remarks=@cP_Remarks WHERE id=" & recno

            sqlquery.Parameters.AddWithValue("@cCurrentDate", txtCurrentDate.Text)
            sqlquery.Parameters.AddWithValue("@cP_Remarks", txtRemarks.Text)
            sqlquery.ExecuteNonQuery()
            sqlconn.Close()

        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        End Try

        DataGrids()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Call_Logs_Details.Enabled = True
        Me.Close()
    End Sub
End Class