Public Class Form1

    Private dao As UsuarioDao

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dao = New UsuarioDao()
        insertInListBox()
        Button3.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As New Usuario(TextBox1.Text, NumericUpDown1.Value)
        dao.insertUser(usuario)
        MessageBox.Show("Adicionado com sucesso!")
        insertInListBox()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Button3.Enabled = True
        Button1.Enabled = False
        Dim id As Integer = ListBox1.SelectedItem
        Dim usuario As Usuario = dao.getUser(id)
        Label3.Text = usuario.getNome()
        Label4.Text = usuario.getIdade()
        TextBox1.Text = usuario.getNome()
        NumericUpDown1.Value = usuario.getIdade()
    End Sub

    Private Sub insertInListBox()
        ListBox1.Items.Clear()
        Dim users As New List(Of Usuario)
        users = dao.listAllUsers()
        For Each aux As Usuario In users
            ListBox1.Items.Add(aux.getId)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dao.removeUser(ListBox1.SelectedItem)
        insertInListBox()
        Label3.Text = ""
        Label4.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim usuario As New Usuario(ListBox1.SelectedItem, TextBox1.Text, NumericUpDown1.Value)
        dao.updateUser(usuario)
        Button3.Enabled = False
        Button1.Enabled = True
        insertInListBox()
        Label3.Text = ""
        Label4.Text = ""
    End Sub
End Class
