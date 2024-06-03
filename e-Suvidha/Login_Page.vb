Imports System.Data.SqlClient

Imports System.Data
Imports System.Data.OleDb

Imports System.Drawing.Drawing2D

'for Hard disk number
Imports System.Collections
Imports System.Management

Public Class Login_Page
    Dim HDD_Serial As String
    Dim sqlLink As SqlConnection
    Dim a As String

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text
        Dim password As String = txtPassword.Text
        Dim companyname As String = cmbName.SelectedItem

        If companyname = "Om Sai Jeweller" And username = "OMJ" And password = "123456" And HDD_Serial = "YS20220700024616" And (Date.Today >= CDate("08/08/2023") And Date.Today < CDate("01/02/2024")) Then
            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Call hno()
            Timer1.Enabled = True
            Om_Sai_Jewellers.Show()
        Else
            MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Public Function hno()
        'E823_8FA6_BF53_0001_001B_448B_411A_1279.
        'Use system management reference
        Dim hdd As New ManagementObjectSearcher("select * from Win32_DiskDrive")
        For Each hd In hdd.Get
            HDD_Serial = hd("SerialNumber")
        Next
        Return (0)
    End Function

    Private Sub Login_Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CenterToScreen()
        roundCorners(Me)

        Call hno()
        MsgBox(HDD_Serial)
    End Sub

    Private Sub roundCorners(ByVal obj As Form)
        obj.FormBorderStyle = FormBorderStyle.None

        Dim DGP As New Drawing2D.GraphicsPath
        DGP.StartFigure()

        'TOP LEFT CORNER
        DGP.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        DGP.AddLine(40, 0, obj.Width - 40, 0)

        'TOP RIGHT CORNER
        DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)

        'BOTTOM RIGHT CORNER
        DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)

        'BOTTOM LEFT CORNER
        DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        DGP.CloseFigure()

        obj.Region = New Region(DGP)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Me.Opacity = Me.Opacity + 0.1
    '    If Me.Opacity = 1 And HDD_Serial = "YS20220700024616" And (Date.Today >= CDate("08/08/2023") And Date.Today < CDate("01/02/2024")) Then
    '        Timer1.Enabled = False
    '        Me.Hide()
    '        Om_Sai_Jewellers.Show()
    '    Else
    '        End
    '    End If
    'End Sub
End Class