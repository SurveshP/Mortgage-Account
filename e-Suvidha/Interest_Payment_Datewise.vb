Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Interest_Payment_Datewise
    Dim sqlLink As SqlConnection

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim maxDate As DateTime = DateTime.Parse(txtCurrentDate.Text)

        If connString.State = ConnectionState.Open Then
            connString.Close()
        End If

        connString.Open()

        Dim str As String
        str = "SELECT id,clientName,currentDate,amountDisbursed,mobileNo from tblGiraveeKhata WHERE currentDate >= @startDate AND currentDate <= @endDate"

        Dim cmd As New OleDbCommand(str, connString)
        cmd.Parameters.AddWithValue("@startDate", txtBillDate.Text)
        cmd.Parameters.AddWithValue("@endDate", maxDate.ToShortDateString())

        Dim adp As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Interest_Payment_Datewise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call intialization()

        'Call DataGrids()

        CenterToScreen()
    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT * from tblGiraveeKhata"
        str = "SELECT id,clientName,currentDate,itemType,actualWeight,amountDisbursed,mobileNo from tblGiraveeKhata"

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        DataGridView1.DataSource = dt


    End Sub

    Public Function intialization()
        Try
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Century", 12)

            DataGridView1.DefaultCellStyle.Font = New Font("Times New Roman", 12, GraphicsUnit.Point)

            Me.DataGridView1.RowTemplate.Height = 25

            DataGridView1.AutoGenerateColumns = False
            DataGridView1.AllowUserToAddRows = False

            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False

            'DataGridView1.RowHeadersVisible = False

            'Set Columns Count 
            DataGridView1.ColumnCount = 5

            'Add Columns
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(0).DataPropertyName = "id"
            DataGridView1.Columns(0).Visible = False

            DataGridView1.Columns(1).Width = 225
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(1).Name = "clientName"
            DataGridView1.Columns(1).HeaderText = "Cleint Name"
            DataGridView1.Columns(1).DataPropertyName = "clientName"
            DataGridView1.Columns(1).ReadOnly = True

            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(2).Name = "currentDate"
            DataGridView1.Columns(2).HeaderText = "Date"
            DataGridView1.Columns(2).DataPropertyName = "currentDate"
            DataGridView1.Columns(2).ReadOnly = True

            DataGridView1.Columns(3).Width = 90
            DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.FromArgb(195, 254, 188)
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(3).Name = "amountDisbursed"
            DataGridView1.Columns(3).HeaderText = "Amount Disbursed"
            DataGridView1.Columns(3).DataPropertyName = "amountDisbursed"
            DataGridView1.Columns(3).ReadOnly = True

            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(4).Name = "mobileNo"
            DataGridView1.Columns(4).HeaderText = "Mobile"
            DataGridView1.Columns(4).DataPropertyName = "mobileNo"
            DataGridView1.Columns(4).ReadOnly = True

        Catch ex As Exception

        End Try

        Return 0
    End Function

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.ColumnIndex = -1 AndAlso e.RowIndex > -1 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            Dim indexString As String = (e.RowIndex + 1).ToString
            Dim sz As SizeF = e.Graphics.MeasureString(indexString, DataGridView1.Font)
            Dim pt As New PointF(e.CellBounds.Width - sz.Width - 8, e.CellBounds.Y + (e.CellBounds.Height / 2 - sz.Height / 2))
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawString(indexString, DataGridView1.Font, Brushes.Black, pt)
            e.Handled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class