Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Giravee_Khata_Payment_Details
    Dim sqlLink As SqlConnection
    Dim currentTime As System.DateTime = System.DateTime.Now
    Dim yourIdValue As Double
    Dim settlementId As Double

    Dim balanceFinal As Double

    Private Sub Giravee_Khata_Payment_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Call intialization()

        Call GoldSilver()
        Call DataGrids()

        Me.Size = New Size(1280, 530)
        'Me.DataGridView1.Size = New Size(1400, 400)

        CenterToScreen()
    End Sub

    Private Sub GoldSilver()
        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        str = "SELECT * from tblGoldSilver"

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        For Each dr In dt.Rows
            txtGold.Text = dt.Rows(0)("goldAmount").ToString().Trim()
            txtSilver.Text = dt.Rows(0)("silverAmount").ToString().Trim()
            yourIdValue = dt.Rows(0)("id").ToString().Trim()
        Next
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Try

            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()

            sqlquery.CommandText = "UPDATE tblGoldSilver SET goldAmount=@GoldAmount, silverAmount=@SilverAmount WHERE id=@id"

            sqlquery.Parameters.AddWithValue("@GoldAmount", txtGold.Text)
            sqlquery.Parameters.AddWithValue("@SilverAmount", txtSilver.Text)
            sqlquery.Parameters.AddWithValue("@Id", yourIdValue)

            sqlquery.ExecuteNonQuery()
            sqlconn.Close()

        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        End Try
        
    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT * from tblGiraveeKhata"
        str = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,amountReceived,otherName,mobileNo from tblGiraveeKhata WHERE status = 0"

        'str = "SELECT * from tblGiraveeKhata WHERE status = 0"

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
            DataGridView1.ColumnCount = 19

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
            DataGridView1.Columns(13).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(13).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(13).Name = "amountReceived"
            DataGridView1.Columns(13).HeaderText = "Amount Received"
            DataGridView1.Columns(13).DataPropertyName = "amountReceived"
            DataGridView1.Columns(13).ReadOnly = True

            DataGridView1.Columns(14).Width = 70
            DataGridView1.Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(14).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(14).Name = "Total"
            DataGridView1.Columns(14).HeaderText = "Total"
            DataGridView1.Columns(14).DataPropertyName = "Total"
            DataGridView1.Columns(14).ReadOnly = True

            DataGridView1.Columns(15).Width = 70
            DataGridView1.Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(15).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(15).Name = "Bala"
            DataGridView1.Columns(15).HeaderText = "Balance"
            DataGridView1.Columns(15).DataPropertyName = "Bala"
            DataGridView1.Columns(15).ReadOnly = True

            'Dim balanceColumn As DataGridViewColumn = DataGridView1.Columns(15)
            'With balanceColumn
            '    .Width = 70
            '    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '    .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            '    .Name = "Bala"
            '    .HeaderText = "Balance"
            '    .DataPropertyName = "Bala"
            '    .ReadOnly = True
            'End With

            'If DataGridView1.Rows(e.rowIndex).Cells(15).Value < 0 Then
            '    balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            'Else
            '    balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(0, 254, 255)
            'End If

            DataGridView1.Columns(16).Width = 70
            DataGridView1.Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(16).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(16).Name = "otherName"
            DataGridView1.Columns(16).HeaderText = "3rd Party"
            DataGridView1.Columns(16).DataPropertyName = "otherName"
            DataGridView1.Columns(16).ReadOnly = True

            DataGridView1.Columns(17).Width = 70
            DataGridView1.Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(17).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(17).Name = "mobileNo"
            DataGridView1.Columns(17).HeaderText = "Mobile"
            DataGridView1.Columns(17).DataPropertyName = "mobileNo"
            DataGridView1.Columns(17).ReadOnly = True

            DataGridView1.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(18).Name = "id"
            DataGridView1.Columns(18).Width = 50
            DataGridView1.Columns(18).HeaderText = "ID"
            DataGridView1.Columns(18).DataPropertyName = "id"
            DataGridView1.Columns(18).ReadOnly = True

            Dim btnPay As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btnPay)
            btnPay.HeaderText = "Pay"
            btnPay.Text = "Pay"
            btnPay.Name = "btnPay"
            btnPay.Width = 50
            btnPay.UseColumnTextForButtonValue = True
            btnPay.CellTemplate.Style.BackColor = System.Drawing.SystemColors.GradientActiveCaption

            Dim btnSet As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btnSet)
            btnSet.HeaderText = "Set"
            btnSet.Text = "Set"
            btnSet.Name = "btnSet"
            btnSet.Width = 50
            btnSet.UseColumnTextForButtonValue = True
            btnSet.CellTemplate.Style.BackColor = System.Drawing.SystemColors.GradientActiveCaption

            Dim btnEdit As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btnEdit)
            btnEdit.HeaderText = "Edit"
            btnEdit.Text = "Edit"
            btnEdit.Name = "btnEdit"
            btnEdit.Width = 50
            btnEdit.UseColumnTextForButtonValue = True
            btnEdit.CellTemplate.Style.BackColor = System.Drawing.SystemColors.GradientActiveCaption

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


        For i = 0 To DataGridView1.RowCount() - 1
            'Check condition
            If DataGridView1.Rows(i).Cells("actualWeight").Value = 5.0 Then
                DataGridView1.Rows(i + 1).Cells("purity").Value = DataGridView1.Rows(i + 1).Cells("actualWeight").Value * 100
            End If
        Next

        For i = 0 To DataGridView1.RowCount() - 1

            'DataGridView1.Rows(i).Cells("Days").Value = DateDiff("d", "#" & DataGridView1.Rows(i).Cells("currentDate").Value & "#", "#" & currentTime("dd/MM/yyyy") & "#")
            DataGridView1.Rows(i).Cells("Days").Value = DateDiff("d", "#" & DataGridView1.Rows(i).Cells("currentDate").Value & "#", "#" & System.DateTime.Now.ToString("dd/MM/yyyy") & "#")
            DataGridView1.Rows(i).Cells("PerDay").Value = (DataGridView1.Rows(i).Cells("Days").Value) * 0.03
            DataGridView1.Rows(i).Cells("Total").Value = DataGridView1.Rows(i).Cells("amountDisbursed").Value + DataGridView1.Rows(i).Cells("PerDay").Value
            DataGridView1.Rows(i).Cells("Bala").Value = Math.Round(DataGridView1.Rows(i).Cells("actualValue").Value - DataGridView1.Rows(i).Cells("Total").Value, 2)
            'balanceFinal = DataGridView1.Rows(i).Cells("Bala").Value

            'If DataGridView1.Rows(i).Cells("Bala").Value < 0 Then
            '    DataGridView1.Columns(14).DefaultCellStyle.BackColor = Color.FromArgb(254, 0, 0)
            'Else
            '    DataGridView1.Columns(14).DefaultCellStyle.BackColor = Color.FromArgb(254, 255, 0)
            'End If
        Next
    End Sub

    Private Sub DataGridView1_RowPrePaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridView1.RowPrePaint
        Dim dgv As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        'If dgv.Cells("Bala").Value < 0 Then
        '    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Red
        'Else
        '    DataGridView1.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Green
        'End If


        Dim balanceColumn As DataGridViewColumn = DataGridView1.Columns(15)
        With balanceColumn
            .Width = 70
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Name = "Bala"
            .HeaderText = "Balance"
            .DataPropertyName = "Bala"
            .ReadOnly = True
        End With

        If DataGridView1.Rows(e.RowIndex).Cells(15).Value < 0 Then
            balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(232, 0, 0)
        Else
            balanceColumn.DefaultCellStyle.BackColor = Color.FromArgb(0, 136, 0)
        End If
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 21 Then
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            recno = DataGridView1.Rows(i).Cells("ID").Value()


            GiraveeEdit.Show()
            Me.Enabled = False
        End If
        If e.ColumnIndex = 20 Then
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            Dim recno2 As Integer
            recno2 = Convert.ToInt32(DataGridView1.Rows(i).Cells("ID").Value())

            Dim resultDlg As DialogResult
            resultDlg = MessageBox.Show("DO you want to sattle this account", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If resultDlg = DialogResult.Yes Then
                Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"

                Using sqlconn As New OleDb.OleDbConnection(connString)
                    sqlconn.Open()

                    Dim sqlquery As New OleDb.OleDbCommand("UPDATE tblGiraveeKhata SET status = 1 WHERE id=@id", sqlconn)
                    sqlquery.Parameters.AddWithValue("@id", recno2) ' Replace "@id" with the appropriate column name in the table

                    sqlquery.ExecuteNonQuery()
                    sqlconn.Close()
                End Using
            End If
            Call DataGrids()
        End If
        If e.ColumnIndex = 19 Then
            Dim j As Integer
            j = DataGridView1.CurrentRow.Index

            totbal1 = DataGridView1.Rows(j).Cells("BALA").Value()
            amtrec = DataGridView1.Rows(j).Cells("AMOUNTRECEIVED").Value()

            'recno1 = DataGridView1.Rows(j).Cells("ID").Value()
            recno1 = DataGridView1.Rows(j).Cells("mobileNo").Value()

            intDay = DataGridView1.Rows(e.RowIndex).Cells(12).Value
            amtrec = DataGridView1.Rows(e.RowIndex).Cells(13).Value
            totamt = DataGridView1.Rows(e.RowIndex).Cells(14).Value
            totbal = DataGridView1.Rows(e.RowIndex).Cells(15).Value
            '    MsgBox(DataGridView1.Rows(e.RowIndex).Cells(13).Value)

            Interest_Payment.Show()
            Me.Enabled = False
        End If

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

    Private Sub listSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listSearch.SelectedIndexChanged
        If (listComponent.SelectedItem = "Clients") Then
            Try
                Dim str As String

                Dim find As String = listSearch.Text
                str = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,amountReceived,otherName,mobileNo,Bala FROM tblGiraveeKhata WHERE status = 0 AND clientName LIKE '%" + CStr(find) + "%'"

                Dim adp As New OleDbDataAdapter(str, connString)

                '      Dim dr As DataRow
                Dim dt As DataTable
                Dim ds As New DataSet
                adp.Fill(ds)
                dt = ds.Tables(0)
                DataGridView1.DataSource = dt

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If (listComponent.SelectedItem = "Mobile") Then
            Try
                Dim strMobile As String

                Dim findMobile As String = listSearch.Text
                strMobile = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,amountReceived,otherName,mobileNo,Bala FROM tblGiraveeKhata WHERE status = 0 AND mobileNo LIKE '%" + CStr(findMobile) + "%'"

                Dim adp As New OleDbDataAdapter(strMobile, connString)

                '      Dim dr As DataRow
                Dim dt As DataTable
                Dim ds As New DataSet
                adp.Fill(ds)
                dt = ds.Tables(0)
                DataGridView1.DataSource = dt

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

        If (listComponent.SelectedItem = "Third Party") Then
            Try
                Dim strOtherName As String

                Dim findOtherName As String = listSearch.Text
                strOtherName = "SELECT id,clientName,currentDate,itemType,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,amountReceived,otherName,mobileNo,Bala FROM tblGiraveeKhata WHERE status = 0 AND otherName LIKE '%" + CStr(findOtherName) + "%'"

                Dim adp As New OleDbDataAdapter(strOtherName, connString)

                '      Dim dr As DataRow
                Dim dt As DataTable
                Dim ds As New DataSet
                adp.Fill(ds)
                dt = ds.Tables(0)
                DataGridView1.DataSource = dt

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class