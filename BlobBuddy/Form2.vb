
Imports System.Timers

Public Class NameForm

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

    End Sub

    Private Delegate Sub CloseFormCallback()

    Private Sub CloseForm()

    End Sub

    Private Sub OnTimedEvent(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        '  CloseForm()
    End Sub

    Private Sub NameForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If TextBox1.Text = "" Then
            My.Settings.Name = Environment.UserName
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Form1.Timer2.Start()
        My.Settings.Name = TextBox1.Text
        Form1.Text = "Welcome to MaxOpolis, " + My.Settings.Name + "!"
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub NameForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class