Module MyModu

    Public connString As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Ocx\omSai.ocx;Persist Security Info=True;Jet OLEDB:Database Password=OmSai")
    Public recno As Integer
    Public recno1 As Integer
    Public recno2 As Integer

    Public intDay As Double
    Public totamt As Double
    Public totbal As Double
    Public totbal1 As Double
    Public amtrec As Double


    Public finalBal As Double
    Public amtreceived As Double

End Module
