Imports System.Data.OleDb

Public Class AdminForm
    Private Sub TblusersBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TblusersBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TblusersBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Database51DataSet)

    End Sub

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Database51DataSet.tblusers' table. You can move, or remove it, as needed.
        Me.TblusersTableAdapter.Fill(Me.Database51DataSet.tblusers)

    End Sub
End Class