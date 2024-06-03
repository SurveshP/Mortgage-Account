Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Giravee_Details
    Dim sqlLink As SqlConnection

    Private Sub Giravee_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call intialization()

        Me.Size = New Size(1400, 500)
        CenterToScreen()
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
            DataGridView1.ColumnCount = 16

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

            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(3).Name = "itemType"
            DataGridView1.Columns(3).HeaderText = "Particulars"
            DataGridView1.Columns(3).DataPropertyName = "itemType"
            DataGridView1.Columns(3).ReadOnly = True

            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(4).DefaultCellStyle.BackColor = Color.FromArgb(255, 224, 191)
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(4).Name = "actualWeight"
            DataGridView1.Columns(4).HeaderText = "Actual Weight"
            DataGridView1.Columns(4).DataPropertyName = "actualWeight"
            DataGridView1.Columns(4).ReadOnly = True

            DataGridView1.Columns(5).Width = 50
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(5).Name = "ppercent"
            DataGridView1.Columns(5).HeaderText = "Purity %"
            DataGridView1.Columns(5).DataPropertyName = "ppercent"
            DataGridView1.Columns(5).ReadOnly = True

            DataGridView1.Columns(6).Width = 70
            DataGridView1.Columns(6).DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 254)
            DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(6).Name = "purity"
            DataGridView1.Columns(6).HeaderText = "Purity"
            DataGridView1.Columns(6).DataPropertyName = "purity"
            DataGridView1.Columns(6).ReadOnly = True

            DataGridView1.Columns(7).Width = 70
            DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(7).Name = "currentPrice"
            DataGridView1.Columns(7).HeaderText = "Rate"
            DataGridView1.Columns(7).DataPropertyName = "currentPrice"
            DataGridView1.Columns(7).ReadOnly = True

            DataGridView1.Columns(8).Width = 70
            DataGridView1.Columns(8).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 126)
            DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(8).Name = "actualValue"
            DataGridView1.Columns(8).HeaderText = "Actual Value"
            DataGridView1.Columns(8).DataPropertyName = "actualValue"
            DataGridView1.Columns(8).ReadOnly = True

            DataGridView1.Columns(9).Width = 70
            DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(9).Name = "iinterest"
            DataGridView1.Columns(9).HeaderText = "Interest Rate"
            DataGridView1.Columns(9).DataPropertyName = "iinterest"
            DataGridView1.Columns(9).ReadOnly = True

            DataGridView1.Columns(10).Width = 90
            DataGridView1.Columns(10).DefaultCellStyle.BackColor = Color.FromArgb(195, 254, 188)
            DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(10).Name = "amountDisbursed"
            DataGridView1.Columns(10).HeaderText = "Amount Disbursed"
            DataGridView1.Columns(10).DataPropertyName = "amountDisbursed"
            DataGridView1.Columns(10).ReadOnly = True

            DataGridView1.Columns(11).Width = 50
            DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(11).Name = "Days"
            DataGridView1.Columns(11).HeaderText = "Days"
            DataGridView1.Columns(11).DataPropertyName = "Days"
            DataGridView1.Columns(11).ReadOnly = True

            DataGridView1.Columns(12).Width = 70
            DataGridView1.Columns(12).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(12).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(12).Name = "PerDay"
            DataGridView1.Columns(12).HeaderText = "Interest"
            DataGridView1.Columns(12).DataPropertyName = "PerDay"
            DataGridView1.Columns(12).ReadOnly = True

            DataGridView1.Columns(13).Width = 70
            DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(13).Name = "Total"
            DataGridView1.Columns(13).HeaderText = "Total"
            DataGridView1.Columns(13).DataPropertyName = "Total"
            DataGridView1.Columns(13).ReadOnly = True

            DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(14).Name = "Bala"
            DataGridView1.Columns(14).HeaderText = "Balance"
            DataGridView1.Columns(14).DataPropertyName = "Bala"
            DataGridView1.Columns(14).ReadOnly = True

            DataGridView1.Columns(15).Width = 70
            DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(15).Name = "mobileNo"
            DataGridView1.Columns(15).HeaderText = "Mobile"
            DataGridView1.Columns(15).DataPropertyName = "mobileNo"
            DataGridView1.Columns(15).ReadOnly = True


        Catch ex As Exception

        End Try

        Return 0
    End Function

    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        'If dgv.Cells("Bala").Value < 0 Then
        '    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        'Else
        '    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green
        'End If


        Dim balanceColumn As DataGridViewColumn = DataGridView1.Columns(14)
        With balanceColumn
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Name = "Bala"
            .HeaderText = "Balance"
            .DataPropertyName = "Bala"
            .ReadOnly = True
        End With

        If DataGridView1.Rows(e.RowIndex).Cells(14).Value < 0 Then
            balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(232, 0, 0)
        Else
            balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(0, 136, 0)
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.ColumnIndex = -1 AndAlso e.RowIndex > -1 AndAlso e.RowIndex < DataGridView1.Rows.Count Then
            Dim indexString As String = (e.RowIndex + 1).ToString
            Dim sz As SizeF = e.Graphics.MeasureString(indexString, DataGridView1.Font)
            Dim pt As New PointF(e.CellBounds.Width - sz.Width - 8, e.CellBounds.Y + (e.CellBounds.Height / 2 - sz.Height / 2))
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)
            e.Graphics.DrawString(indexString, DataGridView1.Font, Brushes.Black, pt)
            e.Handled = True
        End If


        'For i = 0 To DataGridView1.RowCount() - 1
        '    'Check condition
        '    If DataGridView1.Rows(i).Cells("actualWeight").Value = 5.0 Then
        '        DataGridView1.Rows(i + 1).Cells("purity").Value = DataGridView1.Rows(i + 1).Cells("actualWeight").Value * 100
        '    End If
        'Next

        For i = 0 To DataGridView1.RowCount() - 1

            DataGridView1.Rows(i).Cells("Days").Value = DateDiff("d", "#" & DataGridView1.Rows(i).Cells("currentDate").Value & "#", "#" & System.DateTime.Now.ToString("dd/MM/yyyy") & "#")
            DataGridView1.Rows(i).Cells("PerDay").Value = (DataGridView1.Rows(i).Cells("Days").Value) * 0.03
            DataGridView1.Rows(i).Cells("Total").Value = DataGridView1.Rows(i).Cells("amountDisbursed").Value + DataGridView1.Rows(i).Cells("PerDay").Value
            DataGridView1.Rows(i).Cells("Bala").Value = Math.Round(DataGridView1.Rows(i).Cells("actualValue").Value - DataGridView1.Rows(i).Cells("Total").Value, 2)
        Next
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim maxDate As DateTime = DateTime.Parse(txtCurrentDate.Text)

        If connString.State = ConnectionState.Open Then
            connString.Close()
        End If

        connString.Open()

        Dim str As String
        str = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed from tblGiraveeKhata WHERE currentDate >= @startDate AND currentDate <= @endDate"

        Dim cmd As New OleDbCommand(str, connString)
        cmd.Parameters.AddWithValue("@startDate", txtBillDate.Text)
        cmd.Parameters.AddWithValue("@endDate", maxDate.ToShortDateString())

        Dim adp As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        adp.Fill(dt)

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

End Class