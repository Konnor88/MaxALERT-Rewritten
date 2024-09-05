Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)


    End Sub

 

    Private Sub TableLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)

    End Sub

    Private Sub LogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "https://www.tmafe.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim webAddress As String = "https://www.tmafe.com/msagent"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim webAddress As String = "https://www.tmafe.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim webAddress As String = "https://cosmictoons.neocities.org/"
        Process.Start(webAddress)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "<<< Credits" Then
            Button2.Text = "Credits >>>"
            Me.ClientSize = New Size(263, 364)
            Button2.Hide()
        Else
            Button2.Text = "<<< Credits"
            Me.ClientSize = New Size(263, 217)
        End If
    End Sub


End Class
