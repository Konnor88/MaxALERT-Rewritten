Public Class AboutBoxNew

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim webAddress As String = "https://tmafe.com/maxalert"
        Process.Start(webAddress)
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

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Me.Close()
    End Sub
End Class