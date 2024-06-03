Imports System.Data
Imports System.Data.OleDb

Public Class GiraveeEdit

    Private Sub GiraveeEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()

        ' Me.TopMost = True
        txtInterest.Text = 36

        If connString.State = ConnectionState.Open Then connString.Close()
        connString.Open()

        Dim str As String

        str = "SELECT * from tblGiraveeKhata where id=" & recno

        Dim adp As New OleDbDataAdapter(str, connString)

        '      Dim dr As DataRow
        Dim dt As DataTable
        Dim ds As New DataSet
        adp.Fill(ds)
        dt = ds.Tables(0)

        For Each dr In dt.Rows
            txtClientName.Text = dr("clientName").ToString()
            txtAddress.Text = dr("address").ToString()
            txtMobileNo.Text = dr("mobileNo").ToString()
            txt3rdPersoneName.Text = dr("otherName").ToString()
            listType.Text = dr("itemType").ToString()
            txtParticular.Text = dr("particular").ToString()
            txtActualWeight.Text = dr("actualWeight").ToString()
            txtPercent.Text = dr("ppercent").ToString()
            txtPurity.Text = dr("purity").ToString()
            txtCurrentPrice.Text = dr("currentPrice").ToString()
            txtActualValue.Text = dr("actualValue").ToString()
            txtInterest.Text = dr("iinterest").ToString()
            txtAmountDisbursed.Text = dr("amountDisbursed").ToString()
            txtRemarks.Text = dr("p_remarks").ToString()
        Next
        connString.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Giravee_Khata_Payment_Details.Enabled = True
        Me.Close()
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

            sqlquery.CommandText = "UPDATE tblGiraveeKhata SET clientName=@ClientName,address=@Address,mobileNo=@MobileNo,otherName=@OtherName,itemType=@ItemType,particular=@Particular,actualWeight=@ActualWeight,ppercent=@Ppercent,purity=@Purity,currentPrice=@CurrentPrice,actualValue=@ActualValue,iinterest=@Iinterest,amountDisbursed=@AmountDisbursed,p_remarks=@P_Remarks WHERE id=@id"
            'sqlquery.CommandText = "UPDATE tblGiraveeKhata SET clientName=@ClientName WHERE id=@id"


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
            sqlquery.Parameters.AddWithValue("@id", recno)

            sqlquery.ExecuteNonQuery()
            sqlconn.Close()

        Catch EX As Exception
            MsgBox("An error occurred: " & EX.Message)
        End Try
    End Sub

    Private Sub txtActualWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtActualWeight.TextChanged
        txtPurity.Text = (Val(txtActualWeight.Text) * Val(txtPercent.Text)) / 100
        txtActualValue.Text = Val(txtCurrentPrice.Text) * Val(txtPurity.Text)
    End Sub

    Private Sub txtCurrentPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCurrentPrice.TextChanged
        'txtActualValue.Text = Val(txtCurren tPrice.Text) * Val(txtPurity.Text)
        Dim a As Decimal
        a = Val(txtCurrentPrice.Text) * Val(txtPurity.Text)
        txtActualValue.Text = a.ToString()
    End Sub

    Private Sub txtAmountDisbursed_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountDisbursed.TextChanged
        If (txtAmountDisbursed.Text > txtActualValue.Text) Then
            MsgBox("Disbursed Amount is more than Actual Amount")
        End If
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
End Class