Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Call_Logs_Details
    Dim sqlLink As SqlConnection
    Dim currentTime As System.DateTime = System.DateTime.Now
    Dim yourIdValue As Double
    Dim settlementId As Double

    Private Sub Call_Logs_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call intialization()

        'Call GoldSilver()
        Call DataGrids()

        Me.Size = New Size(1450, 500)
        Me.DataGridView1.Size = New Size(1400, 400)

        CenterToScreen()
    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT * from tblGiraveeKhata"
        str = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,amountReceived,otherName,mobileNo,p_remarks from tblGiraveeKhata WHERE status = 0"

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
            DataGridView1.ColumnCount = 13

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

            DataGridView1.Columns(5).Width = 70
            DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 126)
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(5).Name = "actualValue"
            DataGridView1.Columns(5).HeaderText = "Actual Value"
            DataGridView1.Columns(5).DataPropertyName = "actualValue"
            DataGridView1.Columns(5).ReadOnly = True

            DataGridView1.Columns(6).Width = 90
            DataGridView1.Columns(6).DefaultCellStyle.BackColor = Color.FromArgb(195, 254, 188)
            DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(6).Name = "amountDisbursed"
            DataGridView1.Columns(6).HeaderText = "Amount Disbursed"
            DataGridView1.Columns(6).DataPropertyName = "amountDisbursed"
            DataGridView1.Columns(6).ReadOnly = True

            DataGridView1.Columns(7).Width = 70
            DataGridView1.Columns(7).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(7).Name = "amountReceived"
            DataGridView1.Columns(7).HeaderText = "Amount Received"
            DataGridView1.Columns(7).DataPropertyName = "amountReceived"
            DataGridView1.Columns(7).ReadOnly = True

            DataGridView1.Columns(8).Width = 70
            DataGridView1.Columns(8).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(8).Name = "PerDay"
            DataGridView1.Columns(8).HeaderText = "Interest"
            DataGridView1.Columns(8).DataPropertyName = "PerDay"
            DataGridView1.Columns(8).ReadOnly = True

            DataGridView1.Columns(9).Width = 70
            DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(9).Name = "Total"
            DataGridView1.Columns(9).HeaderText = "Total"
            DataGridView1.Columns(9).DataPropertyName = "Total"
            DataGridView1.Columns(9).ReadOnly = True

            DataGridView1.Columns(10).Width = 70
            DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(10).Name = "Bala"
            DataGridView1.Columns(10).HeaderText = "Balance"
            DataGridView1.Columns(10).DataPropertyName = "Bala"
            DataGridView1.Columns(10).ReadOnly = True

            DataGridView1.Columns(11).Width = 70
            DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(11).Name = "mobileNo"
            DataGridView1.Columns(11).HeaderText = "Mobile"
            DataGridView1.Columns(11).DataPropertyName = "mobileNo"
            DataGridView1.Columns(11).ReadOnly = True

            DataGridView1.Columns(11).Width = 70
            DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(11).Name = "p_remarks"
            DataGridView1.Columns(11).HeaderText = "Remarks"
            DataGridView1.Columns(11).DataPropertyName = "p_remarks"
            DataGridView1.Columns(11).ReadOnly = True

            DataGridView1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(12).Name = "id"
            DataGridView1.Columns(12).Width = 50
            DataGridView1.Columns(12).HeaderText = "ID"
            DataGridView1.Columns(12).DataPropertyName = "id"
            DataGridView1.Columns(12).ReadOnly = True

            Dim btnPay As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btnPay)
            btnPay.HeaderText = "Call"
            btnPay.Text = "Call"
            btnPay.Name = "btnCall"
            btnPay.Width = 50
            btnPay.UseColumnTextForButtonValue = True
            btnPay.CellTemplate.Style.BackColor = System.Drawing.SystemColors.GradientActiveCaption

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


        'For i = 0 To DataGridView1.RowCount() - 1
        '    'Check condition
        '    If DataGridView1.Rows(i).Cells("actualWeight").Value = 5.0 Then
        '        DataGridView1.Rows(i + 1).Cells("purity").Value = DataGridView1.Rows(i + 1).Cells("actualWeight").Value * 100
        '    End If
        'Next

        For i = 0 To DataGridView1.RowCount() - 1

            DataGridView1.Rows(i).Cells("Total").Value = DataGridView1.Rows(i).Cells("amountDisbursed").Value + DataGridView1.Rows(i).Cells("PerDay").Value
            DataGridView1.Rows(i).Cells("Bala").Value = Math.Round(DataGridView1.Rows(i).Cells("actualValue").Value - DataGridView1.Rows(i).Cells("Total").Value, 2)

            'If DataGridView1.Rows(i).Cells("Bala").Value < 0 Then
            '    DataGridView1.Columns(14).DefaultCellStyle.BackColor = Color.FromArgb(254, 0, 0)
            'Else
            '    DataGridView1.Columns(14).DefaultCellStyle.BackColor = Color.FromArgb(254, 255, 0)
            'End If
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub listComponent_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listComponent.SelectedIndexChanged
        If (listComponent.SelectedItem = "Clients") Then
            listSearch.Items.Clear()
            If connString.State = ConnectionState.Open Then connString.Close()
            connString.Open()

            Dim strClientName As String

            strClientName = "SELECT clientName from tblGiraveeKhata where status = 0"

            Dim adpClientName As New OleDbDataAdapter(strClientName, connString)

            '      Dim dr As DataRow
            Dim dtClientName As DataTable
            Dim dsClientName As New DataSet
            adpClientName.Fill(dsClientName)
            dtClientName = dsClientName.Tables(0)

            For Each drClientName In dtClientName.Rows
                listSearch.Items.Add(drClientName("clientName"))
            Next
        ElseIf (listComponent.SelectedItem = "Mobile") Then
            listSearch.Items.Clear()
            If connString.State = ConnectionState.Open Then connString.Close()
            connString.Open()

            Dim strMoblie As String

            strMoblie = "SELECT mobileNo from tblGiraveeKhata where status = 0"

            Dim adpMoblie As New OleDbDataAdapter(strMoblie, connString)

            '      Dim dr As DataRow
            Dim dtMoblie As DataTable
            Dim dsMoblie As New DataSet
            adpMoblie.Fill(dsMoblie)
            dtMoblie = dsMoblie.Tables(0)

            For Each drMoblie In dtMoblie.Rows
                listSearch.Items.Add(drMoblie("mobileNo"))
            Next
        Else
            listSearch.Items.Clear()
            If connString.State = ConnectionState.Open Then connString.Close()
            connString.Open()

            Dim strOtherName As String

            strOtherName = "SELECT OtherName from tblGiraveeKhata where status = 0"

            Dim adpOtherName As New OleDbDataAdapter(strOtherName, connString)

            '      Dim dr As DataRow
            Dim dtOtherName As DataTable
            Dim dsOtherName As New DataSet
            adpOtherName.Fill(dsOtherName)
            dtOtherName = dsOtherName.Tables(0)

            For Each drOtherName In dtOtherName.Rows
                listSearch.Items.Add(drOtherName("OtherName"))
            Next
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 13 Then
            Dim i As Integer = DataGridView1.CurrentRow.Index
            recno = DataGridView1.Rows(i).Cells("ID").Value()

            Call_Logs_Edit.Show()
            Me.Enabled = False
        End If
    End Sub
End Class