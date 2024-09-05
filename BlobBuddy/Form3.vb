Public Class OptionsForm

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.AvPath = "NONE"
        My.Settings.isFirstRun = True
        My.Settings.isGoogleSearch = False
        My.Settings.isRandomSpeech = True
        My.Settings.TrackBarValue = 2
        My.Settings.Name = Environment.UserName
        My.Settings.Theme = 2
        Form1.BlobBG.Show()
        Form1.Label2.Show()
        Form1.BonziBG.Hide()
        My.Settings.is64bit = 2
        My.Settings.Save()
        MsgBox("BlobBUDDY settings reset. IsFirstRun from FALSE to TRUE, Build string disabled, Search Engine set to DuckDuckGo, Computer set as default theme. Bit settings reset. Random speech settings set to default. Name configuration set to the current user! Please close and re-open the application!", MessageBoxIcon.Information)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.AvPath = AVPathTextbox.Text
        My.Settings.Save()
        If RadioButton2.Checked = True Then
            My.Settings.isGoogleSearch = True
            My.Settings.Save()
        Else
            My.Settings.isGoogleSearch = False
            My.Settings.Save()
        End If
        If RadioButton4.Checked = True Then
            Form1.BlobBG.Show()
            Form1.Label2.Show()
            Form1.BonziBG.Hide()
            Form1.Label3.BackColor = Color.FromArgb(0, 127, 14)
            Form1.Label3.ForeColor = Color.White
            Form1.ComputerUpdate.Show()
            Form1.JungleUpdate.Hide()
            Form1.ComputerBackgroundOptimizer.Show()
            Form1.JungleBGModule.Hide()
            My.Settings.Theme = 1
            My.Settings.Save()
        Else
            Form1.BlobBG.Hide()
            Form1.BonziBG.Show()
            Form1.ComputerUpdate.Hide()
            Form1.JungleUpdate.Show()
            Form1.ComputerBackgroundOptimizer.Hide()
            Form1.JungleBGModule.Show()
            Form1.Label2.Hide()
            Form1.Label3.BackColor = Color.FromArgb(0, 127, 14)
            Form1.Label3.ForeColor = Color.White

            My.Settings.Theme = 2
            My.Settings.Save()
        End If

        My.Settings.Name = TextBox1.Text
        My.Settings.Save()
        If CheckBox1.Checked Then
            Form1.Label3.Show()
            My.Settings.BuildString = True
            My.Settings.Save()
        Else
            Form1.Label3.Hide()
            My.Settings.BuildString = False
            My.Settings.Save()
        End If
        If RadioButton32.Checked = True Then
            My.Settings.is64bit = 0
            My.Settings.Save()
        End If
        If RadioButton64.Checked = True Then
            My.Settings.is64bit = 1
            My.Settings.Save()
        End If
        ' RANDOM TALK BAR
        If RandomTalkBar.Visible = False Then
            Form1.RandomSpeechTimer.Dispose()
            My.Settings.isRandomSpeech = False
            My.Settings.Save()
        Else
            Form1.RandomSpeechTimer.Start()
            My.Settings.isRandomSpeech = True
            My.Settings.Save()

        End If
        ' Random TALK BAR VALUE
        If RandomTalkBar.Value = 3 Then
            Form1.RandomSpeechTimer.Interval = 300000
            My.Settings.TrackBarValue = 3
            My.Settings.Save()
        End If
        If RandomTalkBar.Value = 2 Then
            Form1.RandomSpeechTimer.Interval = 120000
            My.Settings.TrackBarValue = 2
            My.Settings.Save()
        End If
        If RandomTalkBar.Value = 1 Then
            Form1.RandomSpeechTimer.Interval = 60000
            My.Settings.TrackBarValue = 1
            My.Settings.Save()
        End If

        MsgBox("Your settings have been applied!", MessageBoxIcon.Information)
    End Sub

    Private Sub OptionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AVPathTextbox.Text = My.Settings.AvPath
        ' RANDOM SPEECH CHECKBOX
        If My.Settings.isRandomSpeech = False Then
            CheckBox2.Checked = True
        End If
        'RANDOM SPEECH SLIDER
        If My.Settings.TrackBarValue = 1 Then
            RandomTalkBar.Value = 1
        End If
        If My.Settings.TrackBarValue = 2 Then
            RandomTalkBar.Value = 2
        End If
        If My.Settings.TrackBarValue = 3 Then
            RandomTalkBar.Value = 3
        End If
        'EVERYTHING ELSE
        If My.Settings.is64bit = 1 Then
            RadioButton64.Checked = True
        End If
        If My.Settings.is64bit = 0 Then
            RadioButton32.Checked = True
        End If
        If My.Settings.isGoogleSearch = True Then
            RadioButton2.Checked = True
        Else
            RadioButton1.Checked = True
        End If
        If My.Settings.Theme = 1 Then
            RadioButton4.Checked = True
        Else
            RadioButton3.Checked = True
        End If
        TextBox1.Text = My.Settings.Name
        If My.Settings.BuildString = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox2.Text = "85"
    End Sub


    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            RandomTalkBar.Visible = False
        Else
            RandomTalkBar.Visible = True
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = "C:\"
        openFileDialog1.Filter = "Executable Files|*.exe"
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Settings.AvPath = openFileDialog1.FileName
            AVPathTextbox.Text = openFileDialog1.FileName
            My.Settings.Save()
        End If
    End Sub
End Class