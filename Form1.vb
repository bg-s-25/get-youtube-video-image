'
' Get YouTube Video Image -> Class FORM1
' Author: Bobby Georgiou
' Date: 2015
'
Public Class Form1
    Dim imgurl As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate(TextBox1.Text)
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            imgurl = WebBrowser1.Document.GetElementById("twitter:image").GetAttribute("content").ToString
        Catch ex As Exception
            Exit Sub
        End Try

        ' success
        PictureBox1.ImageLocation = imgurl
        WebBrowser1.Navigate("about:blank")
        Button2.Enabled = True
        Timer1.Stop()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        TextBox2.Text = My.Settings.SelectedPath
        SaveFileDialog1.InitialDirectory = My.Settings.SelectedPath
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text <> "" Then
            Button1.Enabled = True
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk
        PictureBox1.Image.Save(SaveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FolderBrowserDialog1.ShowDialog()
        My.Settings.SelectedPath = FolderBrowserDialog1.SelectedPath
        TextBox2.Text = FolderBrowserDialog1.SelectedPath
    End Sub
End Class
