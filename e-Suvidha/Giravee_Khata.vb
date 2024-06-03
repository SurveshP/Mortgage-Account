Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Public Class Giravee_Khata
    Dim sqlLink As SqlConnection
    Dim a As String

    Private Sub Giravee_Khata_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = Om_Sai_Jewellers
        Me.CenterToScreen()
        sqlLink = New SqlConnection()
        Me.Size = New Size(1100, 530)
        Call DataGrids()
        Call SearchName()

        'listClientSearch.Items.Insert(0, "Select Name")
        
        txtInterest.Text = 36

        intialization()

    End Sub

    Public Function intialization()
        Try
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font(DataGridView1.Font, FontStyle.Bold)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)

            DataGridView1.DefaultCellStyle.Font = New Font("Times New Roman", 12, FontStyle.Bold, GraphicsUnit.Point)

            Me.DataGridView1.RowTemplate.Height = 25

            DataGridView1.AutoGenerateColumns = False
            DataGridView1.AllowUserToAddRows = False

            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False

            DataGridView1.RowHeadersVisible = False

            'Set Columns Count 
            ' DataGridView1.ColumnCount = 5


            'Add Columns
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).Name = "ID"
            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(0).DataPropertyName = "ID"
            DataGridView1.Columns(0).Visible = False

            DataGridView1.Columns(1).Width = 225
            DataGridView1.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(1).Name = "clientName"
            DataGridView1.Columns(1).HeaderText = "Cleint Name"
            DataGridView1.Columns(1).DataPropertyName = "clientName"
            DataGridView1.Columns(1).ReadOnly = True

            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(2).Name = "amountDisbursed"
            DataGridView1.Columns(2).HeaderText = "Amount"
            DataGridView1.Columns(2).DataPropertyName = "amountDisbursed"
            DataGridView1.Columns(2).ReadOnly = True

            DataGridView1.Columns(3).Width = 70
            DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(3).Name = "itemType"
            DataGridView1.Columns(3).HeaderText = "Type"
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
            DataGridView1.Columns(4).Visible = False

            DataGridView1.Columns(6).Width = 50
            DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(6).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(6).Name = "p_remarks"
            DataGridView1.Columns(6).HeaderText = "Remark"
            DataGridView1.Columns(6).DataPropertyName = "p_remarks"
            DataGridView1.Columns(6).ReadOnly = True
            DataGridView1.Columns(6).Visible = False

            DataGridView1.Columns(7).Width = 50
            DataGridView1.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(7).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(7).Name = "address"
            DataGridView1.Columns(7).HeaderText = "Address"
            DataGridView1.Columns(7).DataPropertyName = "address"
            DataGridView1.Columns(7).ReadOnly = True
            DataGridView1.Columns(7).Visible = False

            DataGridView1.Columns(8).Width = 50
            DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(8).Name = "mobileNo"
            DataGridView1.Columns(8).HeaderText = "Mobile Number"
            DataGridView1.Columns(8).DataPropertyName = "mobileNo"
            DataGridView1.Columns(8).ReadOnly = True
            DataGridView1.Columns(8).Visible = False

            DataGridView1.Columns(9).Width = 50
            DataGridView1.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(9).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(9).Name = "otherName"
            DataGridView1.Columns(9).HeaderText = "Other Name"
            DataGridView1.Columns(9).DataPropertyName = "otherName"
            DataGridView1.Columns(9).ReadOnly = True
            DataGridView1.Columns(9).Visible = False

            DataGridView1.Columns(10).Width = 50
            DataGridView1.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(10).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(10).Name = "purity"
            DataGridView1.Columns(10).HeaderText = "Purity %"
            DataGridView1.Columns(10).DataPropertyName = "purity"
            DataGridView1.Columns(10).ReadOnly = True
            DataGridView1.Columns(10).Visible = False

            DataGridView1.Columns(11).Width = 50
            DataGridView1.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(11).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataGridView1.Columns(11).Name = "actualValue"
            DataGridView1.Columns(11).HeaderText = "Actual Value"
            DataGridView1.Columns(11).DataPropertyName = "actualValue"
            DataGridView1.Columns(11).ReadOnly = True
            DataGridView1.Columns(11).Visible = False


        Catch ex As Exception

        End Try

        Return 0
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()

            sqlquery.CommandText = "INSERT INTO tblGiraveeKhata(currentDate,clientName,address,mobileNo,otherName,itemType,particular,actualWeight,ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed,p_remarks,amountReceived,Bala)" &
                                          "Values(@CurrentDate,@ClientName,@Address,@MobileNo,@OtherName,@ItemType,@Particular,@ActualWeight,@Percent,@Purity,@CurrentPrice,@ActualValue,@Iinterest,@AmountDisbursed,@P_Remarks,@AmountReceived,@Balance)"

            'sqlquery.CommandText = "INSERT INTO tblGiraveeKhata(currentDate,clientName,address,mobileNo,otherName,itemType,particular,actualWeight,Ppercent,purity,currentPrice,actualValue,iinterest,amountDisbursed)" & _
            '                             "Values(@CurrentDate,@ClientName,@Address,@MobileNo,@OtherName,@ItemType,@Particular,@ActualWeight,@Ppercent,@Purity,@CurrentPrice,@ActualValue,@Iinterest,@AmountDisbursed)"

            sqlquery.Parameters.AddWithValue("@CurrentDate", txtCurrentDate.Text)
            sqlquery.Parameters.AddWithValue("@ClientName", txtClientName.Text)
            sqlquery.Parameters.AddWithValue("@Address", txtAddress.Text)
            sqlquery.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text)
            sqlquery.Parameters.AddWithValue("@OtherName", txt3rdPersoneName.Text)
            sqlquery.Parameters.AddWithValue("@ItemType", listType.Text)
            sqlquery.Parameters.AddWithValue("@Particular", txtParticular.Text)
            sqlquery.Parameters.AddWithValue("@ActualWeight", txtActualWeight.Text)
            sqlquery.Parameters.AddWithValue("@Ppercent", txtPercent.Text)
            sqlquery.Parameters.AddWithValue("@Purity", txtPurity.Text)
            sqlquery.Parameters.AddWithValue("@CurrentPrice", txtCurrentPrice.Text)
            sqlquery.Parameters.AddWithValue("@ActualValue", txtActualValue.Text)
            sqlquery.Parameters.AddWithValue("@Iinterest", txtInterest.Text)
            sqlquery.Parameters.AddWithValue("@AmountDisbursed", txtAmountDisbursed.Text)
            sqlquery.Parameters.AddWithValue("@P_Remarks", txtRemarks.Text)
            sqlquery.Parameters.AddWithValue("@AmountReceived", 0)
            sqlquery.Parameters.AddWithValue("@Balance", txtBal.Text)

            sqlquery.ExecuteNonQuery()
            sqlconn.Close()



            Call DataGrids()
            Call SearchName()


        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        Finally
            sqlLink.Close()
        End Try



        'SECOND TABLE FOR PAYMENT
        Try

            Dim sqlconnPayment As New OleDb.OleDbConnection
            Dim sqlqueryPayment As New OleDb.OleDbCommand
            Dim connStringPayment As String

            connStringPayment = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconnPayment.ConnectionString = connStringPayment
            sqlqueryPayment.Connection = sqlconnPayment
            sqlconnPayment.Open()

            sqlqueryPayment.CommandText = "INSERT INTO tblBalancePayment(mobileNo,actualValue,amountDisbursed)" &
                                          "Values(@MobileNo,@ActualValue,@AmountDisbursed)"

            sqlqueryPayment.Parameters.AddWithValue("@MobileNo", txtMobileNo.Text)
            sqlqueryPayment.Parameters.AddWithValue("@ActualValue", txtActualValue.Text)
            sqlqueryPayment.Parameters.AddWithValue("@AmountDisbursed", txtAmountDisbursed.Text)

            sqlqueryPayment.ExecuteNonQuery()
            sqlconnPayment.Close()


        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        Finally
            sqlLink.Close()
        End Try

        '    Me.DataGridView1.Rows.Add(txtCurrentDate.Text, txtClientName.Text)
    End Sub

    Private Sub SearchName()
        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        str = "SELECT clientName from tblGiraveeKhata"

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        For Each dr In dt.Rows
            listClientSearch.Items.Add(dr("clientName"))

        Next
    End Sub

    Private Sub DataGrids()

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        'str = "SELECT id,clientName,amountDisbursed,itemType from tblGiraveeKhata  ORDER BY id"
        'str = "SELECT id,clientName,amountDisbursed,itemType,actualWeight,amountDisbursed,otherName,mobileNo,p_remarks,address,purity,actualValue from tblGiraveeKhata ORDER BY id"
        str = "SELECT id,clientName,amountDisbursed,itemType,actualWeight,amountDisbursed,otherName,mobileNo,p_remarks,address,purity,actualValue from tblGiraveeKhata WHERE status = 0 ORDER BY id"

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        DataGridView1.DataSource = dt


    End Sub

    Private Sub listClientSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listClientSearch.SelectedIndexChanged


        Try
            Dim str As String

            Dim find As String = listClientSearch.Text
            str = "SELECT clientName,amountDisbursed,itemType,actualWeight,amountDisbursed,otherName,mobileNo,p_remarks,address,purity,actualValue FROM tblGiraveeKhata WHERE status = 0 AND clientName LIKE '%" + CStr(find) + "%'"

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


    End Sub

    Private Sub listType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listType.SelectedIndexChanged
        If (listType.SelectedItem = "Gold") Then
            txtPercent.Text = 72
            Call GoldAmount()
        Else
            txtPercent.Text = 45
            Call SilverAmount()
        End If


    End Sub

    Private Sub GoldAmount()
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
            txtCurrentPrice.Text = dt.Rows(0)("goldAmount").ToString().Trim()
        Next
    End Sub

    Private Sub SilverAmount()
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
            txtCurrentPrice.Text = dt.Rows(0)("silverAmount").ToString().Trim()
        Next
    End Sub

    Private Sub txtActualWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActualWeight.TextChanged
        txtPurity.Text = (Val(txtActualWeight.Text) * Val(txtPercent.Text)) / 1000
        txtActualValue.Text = Val(txtCurrentPrice.Text) * Val(txtPurity.Text)
    End Sub

    Private Sub txtCurrentPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentPrice.TextChanged
        'txtActualValue.Text = Val(txtCurren tPrice.Text) * Val(txtPurity.Text)
        Dim a As Decimal
        a = Val(txtCurrentPrice.Text) * Val(txtPurity.Text)
        txtActualValue.Text = a.ToString()
    End Sub

    Private Sub txtAmountDisbursed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountDisbursed.TextChanged
        If (Val(txtAmountDisbursed.Text) > Val(txtActualValue.Text)) Then
            MsgBox("Disbursed Amount is more than Actual Amount")
        End If
        txtBal.Text = Math.Round(Val(txtActualValue.Text) - Val(txtAmountDisbursed.Text))
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try

            Dim sqlconn As New OleDb.OleDbConnection
            Dim sqlquery As New OleDb.OleDbCommand
            Dim connString As String

            connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai"
            sqlconn.ConnectionString = connString
            sqlquery.Connection = sqlconn
            sqlconn.Open()

            sqlquery.CommandText = "DELETE FROM tblUsers WHERE clientName = @ClientName"

            sqlquery.Parameters.AddWithValue("@ClientName", txtClientName.Text)

            sqlquery.ExecuteNonQuery()
            sqlconn.Close()



            Call DataGrids()
            Call SearchName()


        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        Finally
            sqlLink.Close()
        End Try
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        'TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value
        txtClientName.Text = DataGridView1.CurrentRow.Cells(1).Value
        txtAmountDisbursed.Text = DataGridView1.CurrentRow.Cells(2).Value
        txtParticular.Text = DataGridView1.CurrentRow.Cells(3).Value
        txtActualWeight.Text = DataGridView1.CurrentRow.Cells(4).Value
        txtRemarks.Text = DataGridView1.CurrentRow.Cells(6).Value
        txtAddress.Text = DataGridView1.CurrentRow.Cells(7).Value
        txtMobileNo.Text = DataGridView1.CurrentRow.Cells(8).Value
        txt3rdPersoneName.Text = DataGridView1.CurrentRow.Cells(9).Value
        txtPurity.Text = DataGridView1.CurrentRow.Cells(10).Value
        txtActualValue.Text = DataGridView1.CurrentRow.Cells(11).Value
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Me.Refresh()
        'txtCurrentDate.Text = ""
        txtClientName.Text = ""
        txtAddress.Text = ""
        txtMobileNo.Text = ""
        txt3rdPersoneName.Text = ""
        listType.Text = ""
        txtParticular.Text = ""
        txtActualWeight.Text = ""
        txtPercent.Text = ""
        txtPurity.Text = ""
        txtCurrentPrice.Text = ""
        txtActualValue.Text = ""
        'txtInterest.Text = ""
        txtAmountDisbursed.Text = ""
        txtRemarks.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class