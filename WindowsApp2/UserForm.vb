Imports System.Data.OleDb

Public Class UserForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database51.accdb")
    Dim M As String
    Private cursurmove As Point
    Private oo As Boolean
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End
    End Sub

    Private Sub UserForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT USERNAME,MONEY FROM tblusers WHERE [USERNAME] = '" & LoginForm.Guna2TextBox1.Text & "'", con)
        con.Open()
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            M = sdr("MONEY")
        End If
        Label4.Text = M
    End Sub

    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        Dim x As Double = M
        Dim y As Double = Guna2TextBox1.Text
        Dim str As String = x + y
        Dim cmd As OleDbCommand = New OleDbCommand("update tblusers set [MONEY] = '" + str + "' where [USERNAME] = '" + LoginForm.Guna2TextBox1.Text + "' ", con)
        If cmd.ExecuteNonQuery Then
            Label4.Text = str
            M = str
        End If
    End Sub

    Private Sub Guna2GradientButton3_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton3.Click
        Dim x As Double = M
        Dim y As Double = Guna2TextBox4.Text
        Dim str As String = x - y
        Dim cmd As OleDbCommand = New OleDbCommand("update tblusers set [MONEY] = '" + str + "' where [USERNAME] = '" + LoginForm.Guna2TextBox1.Text + "' ", con)
        If cmd.ExecuteNonQuery Then
            Label4.Text = str
            M = str
        End If
    End Sub
    Dim str2 As String
    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Dim x As Double = M
        Dim y As Double = Guna2TextBox2.Text
        str2 = x - y
        Dim cmd As OleDbCommand = New OleDbCommand("update tblusers set [MONEY] = '" + str2 + "' where [USERNAME] = '" + LoginForm.Guna2TextBox1.Text + "' ", con)
        If cmd.ExecuteNonQuery Then
            GetInfo()
        End If
    End Sub
    Sub GetInfo()
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT USERNAME,MONEY FROM tblusers WHERE USERNAME = '" & Guna2TextBox3.Text & "'", con)
        Dim sdr As OleDbDataReader = cmd.ExecuteReader()
        If (sdr.Read() = True) Then
            Transformation(sdr("MONEY"))
        End If
    End Sub
    Function Transformation(oldMoney As String)
        Dim x As Double = oldMoney
        Dim y As Double = Guna2TextBox2.Text
        Dim str As String = x + y
        Dim cmd As OleDbCommand = New OleDbCommand("update tblusers set [MONEY] = '" + str + "' where [USERNAME] = '" + Guna2TextBox3.Text + "' ", con)
        If cmd.ExecuteNonQuery Then
            MsgBox("Done")
            Label4.Text = str2
            M = str2
        End If
    End Function

    Private Sub Guna2TextBox1_Click(sender As Object, e As EventArgs) Handles Guna2TextBox1.Click
        Guna2TextBox1.Text = ""
    End Sub

    Private Sub Guna2TextBox4_Click(sender As Object, e As EventArgs) Handles Guna2TextBox4.Click
        Guna2TextBox4.Text = ""
    End Sub

    Private Sub Guna2TextBox3_Click(sender As Object, e As EventArgs) Handles Guna2TextBox3.Click
        Guna2TextBox3.Text = ""
    End Sub

    Private Sub Guna2TextBox2_Click(sender As Object, e As EventArgs) Handles Guna2TextBox2.Click
        Guna2TextBox2.Text = ""
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            Me.cursurmove = e.Location
        End If
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location += CType((e.Location - CType(Me.cursurmove, Size)), Size)
        End If
    End Sub
End Class