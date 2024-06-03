Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Interest_Payment
    Dim sqlLink As SqlConnection


    Private Sub Interest_Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CenterToScreen()

        sqlLink = New SqlConnection()

        txtInterest.Text = 36

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT * from tblGiraveeKhata where id=" & recno1
        str = "SELECT * from tblGiraveeKhata where mobileNo=" & recno1

        Dim adp As New OleDbDataAdapter(str, connString)

        'Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)


        For Each dr In dt.Rows
            'txtBillDate.Text = dr("currentDate").ToString()
            txtClientName.Text = dr("clientName").ToString()
            txtInterest.Text = dr("PerDay").ToString()
            txtAmountDisbursed.Text = dr("amountDisbursed").ToString()
            'txtTotalAmount.Text = dr("Total").ToString()
            txtMobileNo.Text = dr("mobileNo").ToString()

            'txtBalance.Text = dr("Bala").ToString()
            'txtBalance.Text = totbal
            txtAmountReceived.Text = amtrec

        Next

        txtTotalAmount.Text = totamt
        TextBox1.Text = totbal
        txtBalance.Text = Val(txtTotalAmount.Text) - Val(txtAmountReceived.Text)

        Call DataGrids()
        intialization()

    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT id,currentDate,amountReceived,p_remarks from  tblInterestPayment"
        ''str = "SELECT id,currentDate,amountReceived,p_remarks from tblGiraveeKhata"
        'str = "SELECT id,currentDate,amountReceived,p_remarks from tblInterestPayment"
        str = "SELECT id,currentDate,amountReceived,p_remarks from  tblInterestPayment where mobileNo=" & recno1
        'str = "SELECT * from  tblInterestPayment where mobileNo=" & recno1

        Dim adp As New OleDbDataAdapter(str, connString)

        'Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        intialization()
        DataGridView1.DataSource = dt

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Giravee_Khata_Payment_Details.Enabled = True
        Me.Close()
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

            sqlquery.CommandText = "INSERT INTO tblInterestPayment(currentDate,amountReceived,p_remarks,mobileNo)" &
                                          "Values(@CurrentDate,@AmountReceived,@P_Remarks,@MobileNo)"

            'sqlquery.CommandText = "INSERT INTO tblGiraveeKhata(currentDate,clientName,address,mobileNo,otherName,itemType,particular,actualWeight,Ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed)" & _
            '                             "Values(@CurrentDate,@ClientName,@Address,@MobileNo,@OtherName,@ItemType,@Particular,@ActualWeight,@Ppercent,@Purity,@CurrentPrice,@ActualValue,@Iinterest,@AmountDisbursed)"

            sqlquery.Parameters.AddWithValue("@CurrentDate", txtCurrentDate.Text)
            sqlquery.Parameters.AddWithValue("@AmountReceived", txtPay.Text)
            sqlquery.Parameters.AddWithValue("@P_Remarks", txtRemarks.Text)
            sqlquery.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text)

            sqlquery.ExecuteNonQuery()
            sqlconn.Close()

            MsgBox("Data inserted successfully!", MsgBoxStyle.Information)

            Call DataGrids()


        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        Finally
            sqlLink.Close()
        End Try


        'UPDATE tblGiraveeKhata
        Try
            Dim variable As String
            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()

            ' Use parameters to prevent SQL injection
            variable = "UPDATE tblGiraveeKhata SET Bala = @Bala, amountReceived = @TotalAmount WHERE mobileNo = @MobileNo"

            Dim cmd As OleDbCommand = New OleDbCommand(variable, sqlconn)
            'cmd.Parameters.AddWithValue("@CurrentDate", txtCurrentDate.Text)
            cmd.Parameters.AddWithValue("@Bala", Val(txtPay.Text) + Val(TextBox1.Text))
            cmd.Parameters.AddWithValue("@TotalAmount", Val(txtAmountReceived.Text) + Val(txtPay.Text))
            cmd.Parameters.AddWithValue("@MobileNo", recno1)

            cmd.ExecuteNonQuery()
            sqlconn.Close()

            MsgBox("Data Updated successfully!", MsgBoxStyle.Information)

            Call intialization()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try





        'UPDATE tblBalancePayment
        Try
            Dim variablePayment As String
            Dim sqlconnPayment As New OleDb.OleDbConnection
            Dim sqlqueryPayment As New OleDb.OleDbCommand
            Dim connString As String
            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconnPayment.ConnectionString = connString
            sqlqueryPayment.Connection = sqlconnPayment
            sqlconnPayment.Open()

            variablePayment = "UPDATE tblBalancePayment SET finalBalance = @FinalBalance, amountReceived = @AmountReceived WHERE mobileNo = @MobileNo"

            Dim cmdPayment As OleDbCommand = New OleDbCommand(variablePayment, sqlconnPayment)
            cmdPayment.Parameters.AddWithValue("@FinalBalance", txtBalance.Text)
            cmdPayment.Parameters.AddWithValue("@AmountReceived", Val(txtAmountReceived.Text) + Val(txtPay.Text))
            cmdPayment.Parameters.AddWithValue("@MobileNo", recno1)

            cmdPayment.ExecuteNonQuery()
            sqlconnPayment.Close()

            MsgBox("Data Updated successfully!", MsgBoxStyle.Information)

            Call intialization()

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        End Try

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
            DataGridView1.ColumnCount = 4

            'Add Columns
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(0).DataPropertyName = "id"
            DataGridView1.Columns(0).Visible = False

            DataGridView1.Columns(1).Width = 100
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(1).Name = "currentDate"
            DataGridView1.Columns(1).HeaderText = "Date"
            DataGridView1.Columns(1).DataPropertyName = "currentDate"
            DataGridView1.Columns(1).ReadOnly = True

            DataGridView1.Columns(2).Width = 70
            DataGridView1.Columns(2).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(2).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(2).Name = "amountReceived"
            DataGridView1.Columns(2).HeaderText = "Amount Received"
            DataGridView1.Columns(2).DataPropertyName = "amountReceived"
            DataGridView1.Columns(2).ReadOnly = True

            DataGridView1.Columns(3).Width = 70
            DataGridView1.Columns(3).DefaultCellStyle.BackColor = Color.FromArgb(193, 254, 255)
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(3).Name = "p_remarks"
            DataGridView1.Columns(3).HeaderText = "Remarks"
            DataGridView1.Columns(3).DataPropertyName = "p_remarks"
            DataGridView1.Columns(3).ReadOnly = True

            Dim btnDel As New DataGridViewButtonColumn()
            DataGridView1.Columns.Add(btnDel)
            btnDel.HeaderText = "Del"
            btnDel.Text = "Del"
            btnDel.Name = "btnDel"
            btnDel.Width = 50
            btnDel.UseColumnTextForButtonValue = True
            btnDel.CellTemplate.Style.BackColor = System.Drawing.SystemColors.GradientActiveCaption

            DataGridView1.ReadOnly = False
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

    Private Sub txtPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPay.TextChanged
        txtBalance.Text = Val(txtBalance.Text) - Val(txtPay.Text)
    End Sub


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


        Dim connString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"

        If e.ColumnIndex = 4 Then
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            Dim recno2 As Integer
            Dim amountRec As Integer
            recno2 = Convert.ToInt32(DataGridView1.Rows(i).Cells("ID").Value())
            amountRec = Convert.ToInt32(DataGridView1.Rows(i).Cells("amountReceived").Value())


            Dim resultDlg As DialogResult
            resultDlg = MessageBox.Show("Do you want to delete this Remark?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If resultDlg = DialogResult.Yes Then


                Using sqlconn As New OleDb.OleDbConnection(connString)
                    sqlconn.Open()

                    ' DELETE query from tblInterestPayment
                    Dim deleteQuery As New OleDb.OleDbCommand("DELETE FROM tblInterestPayment WHERE id=@id AND mobileNo=" & recno1, sqlconn)
                    deleteQuery.Parameters.AddWithValue("@id", recno2)
                    deleteQuery.ExecuteNonQuery()

                    ' UPDATE query for tblGiraveeKhata
                    Dim updateGiraveeQuery As New OleDb.OleDbCommand("UPDATE tblGiraveeKhata SET Bala=@Amount, amountReceived=@AmtReceived WHERE mobileNo=" & recno1, sqlconn)
                    '     updateGiraveeQuery.Parameters.AddWithValue("@id", recno2)
                    ' Use the amount directly without the select query
                    '    Dim amountReceived As Decimal = 0 ' Replace with the appropriate value or variable
                    updateGiraveeQuery.Parameters.AddWithValue("@Amount", totbal1 - Val(amountRec))
                    updateGiraveeQuery.Parameters.AddWithValue("@AmtReceived", amtrec - Val(amountRec))
                    updateGiraveeQuery.ExecuteNonQuery()

                    '' UPDATE query for tblBalancePayment
                    'Dim j As Integer
                    'j = DataGridView1.CurrentRow.Index

                    'Dim updateBalanceQuery As New OleDb.OleDbCommand("UPDATE tblBalancePayment SET finalBalance=@FinalAmount, amountReceived=@AmtReceived WHERE mobileNo=" & recno1, sqlconn)
                    'finalBal = DataGridView1.Rows(j).Cells("FINALBALANCE").Value()
                    'amtreceived = DataGridView1.Rows(j).Cells("AMOUNTRECEIVED").Value()
                    ''     updateGiraveeQuery.Parameters.AddWithValue("@id", recno2)
                    '' Use the amount directly without the select query
                    ''    Dim amountReceived As Decimal = 0 ' Replace with the appropriate value or variable
                    'updateBalanceQuery.Parameters.AddWithValue("@FinalAmount", finalBal + Val(amountRec))
                    'updateBalanceQuery.Parameters.AddWithValue("@AmtReceived", amtreceived - Val(amountRec))
                    'updateBalanceQuery.ExecuteNonQuery()

                    sqlconn.Close()
                End Using
            End If
            Call DataGrids()
        End If
    End Sub
End Class