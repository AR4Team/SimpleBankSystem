Imports System.Data.OleDb
Public Class RegisterForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database51.accdb")
    Private cursurmove As Point
    Private oo As Boolean
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        If Guna2TextBox1.Text = "" Or Guna2TextBox2.Text = "" Or Guna2TextBox3.Text = "" Or Guna2TextBox4.Text = "" Then
            MsgBox("Add ALL INFO !")
        Else
            Dim cmd2 As OleDbCommand = New OleDbCommand("SELECT * FROM tblusers WHERE [USERNAME] = '" & Guna2TextBox1.Text & "' AND [EMAIL] = '" & Guna2TextBox4.Text & "' ", con)
            Dim sdr As OleDbDataReader = cmd2.ExecuteReader()
            If (sdr.Read() = True) Then
                If Guna2TextBox1.Text = sdr("USERNAME") Then
                    MsgBox("Change Username")
                End If
                If Guna2TextBox4.Text = sdr("EMAIL") Then
                    MsgBox("Change Email")
                End If
            Else
                If Guna2TextBox2.Text = Guna2TextBox3.Text Then
                    Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO [tblusers] ([USERNAME] ,[PASSWORD] ,[USERTYPE] ,[MONEY] ,[EMAIL]) VALUES (@USERNAME, @PASSWORD, @USERTYPE , @MONEY , @EMAIL)", con)
                    cmd.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = Guna2TextBox1.Text
                    cmd.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = LoginForm.GetHash(Guna2TextBox2.Text)
                    cmd.Parameters.AddWithValue("@USERTYPE", OleDbType.VarChar).Value = "1"
                    cmd.Parameters.AddWithValue("@MONEY", OleDbType.VarChar).Value = "0"
                    cmd.Parameters.AddWithValue("@EMAIL", OleDbType.VarChar).Value = Guna2TextBox4.Text
                    If cmd.ExecuteNonQuery() Then
                        MsgBox("Account Created")
                        Me.Hide()
                        LoginForm.Show()
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End
    End Sub

    Private Sub RegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
    End Sub

    Private Sub Guna2CustomRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CustomRadioButton1.CheckedChanged
        If Guna2CustomRadioButton1.Checked = True Then
            Guna2TextBox2.UseSystemPasswordChar = False
            Guna2TextBox3.UseSystemPasswordChar = False
        End If
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        If e.Button = MouseButtons.Left Then
            Me.Location += CType((e.Location - CType(Me.cursurmove, Size)), Size)
        End If
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        If e.Button = MouseButtons.Left Then
            Me.cursurmove = e.Location
        End If
    End Sub
End Class