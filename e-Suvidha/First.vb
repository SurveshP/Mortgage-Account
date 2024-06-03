'for Hard disk number
Imports System.Collections
Imports System.Management

Public Class First
    Dim HDD_Serial As String
    Private Sub First_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call hno()
        Timer1.Enabled = True
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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity + 0.1
        If Me.Opacity = 1 And HDD_Serial = "S314JB0H158757" And (Date.Today >= CDate("08/08/2023") And Date.Today < CDate("01/02/2024")) Then
            Timer1.Enabled = False
            Me.Hide()
            Om_Sai_Jewellers.Show()
        Else
            End
        End If
    End Sub
End Class