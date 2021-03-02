Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports System.Text
Imports System.Net
Public Class LoginForm
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\Database51.accdb")
    Public email As String
    Public user As String
    Dim Code As String
    Private cursurmove As Point
    Private oo As Boolean
    Private Sub Guna2GradientButton1_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton1.Click
        If Guna2TextBox1.Text = "" Or Guna2TextBox2.Text = "" Then
            MsgBox("Enter Username And Password !")
        Else
            Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM tblusers WHERE [USERNAME] = '" & Guna2TextBox1.Text & "' AND [PASSWORD] = '" & GetHash(Guna2TextBox2.Text) & "' ", con)
            Dim ds As New OleDbDataAdapter(cmd)
            Dim Table As New DataTable
            ds.Fill(Table)
            Try
                If Table.Rows(0)("USERTYPE") = "0" Then
                    Me.Hide()
                    AdminForm.Show()
                Else
                    Dim sdr As OleDbDataReader = cmd.ExecuteReader()
                    If (sdr.Read() = True) Then
                        email = sdr("EMAIL")
                        Me.Hide()
                        UserForm.Show()
                    End If
                End If
            Catch ex As Exception
                MsgBox("username or password is wrong")
            End Try
        End If
    End Sub
    Shared Function GetHash(theInput As String) As String
        Using hasher As MD5 = MD5.Create()
            Dim dbytes As Byte() =
                 hasher.ComputeHash(Encoding.UTF8.GetBytes(theInput))
            Dim sBuilder As New StringBuilder()
            For n As Integer = 0 To dbytes.Length - 1
                sBuilder.Append(dbytes(n).ToString("X2"))
            Next n
            Return sBuilder.ToString()
        End Using
    End Function
    Private Sub Guna2CustomRadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CustomRadioButton1.CheckedChanged
        If Guna2CustomRadioButton1.Checked = True Then
            Guna2TextBox2.UseSystemPasswordChar = False
        Else
            Guna2TextBox2.UseSystemPasswordChar = True
        End If
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
    End Sub

    Private Sub Guna2GradientButton2_Click(sender As Object, e As EventArgs) Handles Guna2GradientButton2.Click
        Me.Hide()
        RegisterForm.Show()
    End Sub
    Private Sub Guna2TextBox1_Click(sender As Object, e As EventArgs) Handles Guna2TextBox1.Click
        Guna2TextBox1.Text = ""
    End Sub

    Private Sub Guna2TextBox2_Click(sender As Object, e As EventArgs) Handles Guna2TextBox2.Click
        Guna2TextBox2.Text = ""
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
