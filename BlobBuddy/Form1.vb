Option Explicit On

Imports AgentObjects
Imports AxAgentObjects
Imports System.IO
Imports System.Text
Imports System.Media
Imports System.Diagnostics
Imports AgentServerObjects
Imports System.Management

Public Class Form1
    Private WithEvents processCheckTimer As Timer
    Private notifyIcon As NotifyIcon
    Dim MaxALERT As IAgentCtlCharacterEx
    Shared Random As New Random
    Dim i As Integer
    Private player As New SoundPlayer()
    Public WithEvents AgentControl As Agent
    Const DATAPATH = "MaxALERT.acs"

    Private Sub NotifyIcon_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Show()

        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RandomSpeechTimer.Start()
        If My.Settings.TrackBarValue = 1 Then
            Me.RandomSpeechTimer.Interval = 60000
        End If
        If My.Settings.TrackBarValue = 2 Then
            Me.RandomSpeechTimer.Interval = 120000
        End If
        If My.Settings.TrackBarValue = 3 Then
            Me.RandomSpeechTimer.Interval = 300000
        End If
        If My.Settings.isRandomSpeech = False Then
            RandomSpeechTimer.Dispose()
        End If
        StartProcessCheckTimer()

        If My.Settings.BuildString = False Then
            Label3.Hide()
        Else
            Label3.Show()
        End If
        If My.Settings.Theme = 1 Then
            Me.BlobBG.Show()
            Me.Label2.Show()
            Me.BonziBG.Hide()
            Me.Label3.BackColor = Color.FromArgb(0, 127, 14)
            Me.Label3.ForeColor = Color.White
            Me.ComputerUpdate.Show()

            Me.JungleUpdate.Hide()
            Me.ComputerBackgroundOptimizer.Show()
            Me.JungleBGModule.Hide()
        End If
        If My.Settings.Theme = 2 Then
            Me.BlobBG.Hide()
            Me.BonziBG.Show()
            Me.ComputerUpdate.Hide()
            Me.JungleUpdate.Show()
            Me.ComputerBackgroundOptimizer.Hide()
            Me.JungleBGModule.Show()
            Me.Label2.Hide()
            Me.Label3.BackColor = Color.FromArgb(0, 127, 14)
            Me.Label3.ForeColor = Color.White
        End If
        'THIS IS THE FIRST RUN

        If My.Settings.isFirstRun Then
            My.Settings.isFirstRun = False
            My.Settings.Save()

            AxAgent1.Characters.Load("MaxALERT", DATAPATH)
            MaxALERT = AxAgent1.Characters("MaxALERT")
            MaxALERT.LanguageID = &H409
            Timer1.Enabled = True ' Enable the Timer control
            MaxALERT.MoveTo(320, 240)
            MaxALERT.Show()
            Me.Show()
            MaxALERT.Play("Wave")
            MaxALERT.Speak("Well! \emp\ Hello there!")
            MaxALERT.Speak("\Map=""I Don't believe we have been properly introduced.""=""I don't believe we've been properly introduced.""\")
            MaxALERT.Play("Explain2")
            MaxALERT.Speak("I'm Max!")
            MaxALERT.Play("Restpose")
            MaxALERT.Speak("What is \emp\ your name?")



        Else

            AxAgent1.Characters.Load("MaxALERT", DATAPATH)
            MaxALERT = AxAgent1.Characters("MaxALERT")
            MaxALERT.LanguageID = &H409
            MaxALERT.MoveTo(320, 240)
            MaxALERT.Show()

            'THIS IS NOT THE FIRST RUN

            ' TIME CHECK
            Dim currentTime As DateTime = DateTime.Now
            Dim startTime As TimeSpan
            Dim endTime As TimeSpan
            startTime = TimeSpan.Parse("21:00")
            endTime = TimeSpan.Parse("06:00")
            If currentTime.TimeOfDay >= TimeSpan.Parse("21:00") OrElse currentTime.TimeOfDay < TimeSpan.Parse("06:00") Then
                ' Time between 9 PM and 6 AM
                Dim random As New Random()
                Dim randomNumber64 As Integer = random.Next(1, 6)

                Select Case randomNumber64
                    Case 1
                        MaxALERT.Play("Surprised")
                        MaxALERT.Speak("Do you ever sleep, " + My.Settings.Name + "?")

                    Case 2
                        MaxALERT.Play("Surprised")
                        MaxALERT.Speak("Wait! Why are you up so late?")
                        MaxALERT.Play("Restpose")
                    Case 3

                        MaxALERT.Speak("I \emp\ really think you should be in bed, but okay, I’m here to protect you.")
                        MaxALERT.Play("Restpose")
                    Case 4
                        MaxALERT.Play("Surprised")
                        MaxALERT.Speak("Surprised to see you up this late, " + My.Settings.Name + "!")
                        MaxALERT.Play("Restpose")
                    Case 5
                        MaxALERT.Play("gesturedown")
                        MaxALERT.Speak("I'm really tired, " + My.Settings.Name + ". Can't it wait?")
                        MaxALERT.Play("Restpose")
                End Select
            Else
                Me.Text = "Welcome to MaxOpolis, " + My.Settings.Name + "!"

                Dim random As New Random()
                Dim randomNumber As Integer = random.Next(1, 6)

                Select Case randomNumber
                    Case 1
                        MaxALERT.Play("Wave")
                        MaxALERT.Speak("Top of the morning, " + My.Settings.Name + "!")
                        MaxALERT.Play("Restpose")
                    Case 2
                        MaxALERT.Play("Acknowledge")
                        MaxALERT.Speak("Well, you called, and I came.")
                        MaxALERT.Play("Restpose")
                    Case 3
                        MaxALERT.Play("Pleased")
                        MaxALERT.Speak("Nice to see you again, " + My.Settings.Name + "!")
                        MaxALERT.Play("Restpose")
                    Case 4
                        MaxALERT.Play("Wave")
                        MaxALERT.Speak("Hello, " + My.Settings.Name + "! I'm ready to protect you from malware!")
                        MaxALERT.Play("Restpose")
                    Case 5
                        MaxALERT.Play("Wave")
                        MaxALERT.Speak("Welcome back, " + My.Settings.Name + "! I've missed you!")
                        MaxALERT.Play("Restpose")

                End Select
            End If
        End If

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        MaxALERT.Hide()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If MaxALERT.Visible Then
            Timer3.Start()
            MaxALERT.StopAll()

            Dim random As New Random()
            Dim randomNumber32 As Integer = random.Next(1, 7)

            Select Case randomNumber32
                Case 1
                    MaxALERT.Play("Wave")
                    MaxALERT.Speak("It hurts me to say goodbye, " + My.Settings.Name + ".")
                    MaxALERT.Hide()
                Case 2
                    MaxALERT.Play("Wave")
                    MaxALERT.Speak("Until next time my friend!")
                    MaxALERT.Hide()
                Case 3
                    MaxALERT.Play("Wave")
                    MaxALERT.Speak("Until next time, " + My.Settings.Name + ".")
                    MaxALERT.Hide()
                Case 4
                    MaxALERT.Play("Acknowledge")
                    MaxALERT.Speak("Well, I've fulfilled my duties. Bye for now.")
                    MaxALERT.Hide()
                Case 5
                    MaxALERT.Play("Acknowledge")
                    MaxALERT.Speak("It looks like my work here is done. See you later.")
                    MaxALERT.Hide()
                Case 6
                    MaxALERT.Play("wave")
                    MaxALERT.Speak("I hope to see you again soon, " + My.Settings.Name + ".")
                    MaxALERT.Hide()
            End Select
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        AboutBoxNew.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim webAddress As String = "https://tmafe.com/maxalert"
        Process.Start(webAddress)
    End Sub


    Private Sub SpeakPic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SpeakPic.Click
        UtilPanel1.Show()
        UtilPanel3.Hide()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SpeakBox.Text = "" Then
            MaxALERT.Speak("Please put text in the text box!")
        Else
            MaxALERT.Speak("\Chr=""Normal""\" + SpeakBox.Text)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MaxALERT.Stop()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        UtilPanel1.Hide()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        HandlePictureBox4ClickEvent()


    End Sub


    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If SpeakBox.Text = "" Then
            MaxALERT.Speak("Please put text in the text box!")
        Else
            MaxALERT.Speak("\Chr=""Whisper""\" + SpeakBox.Text)
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        If SpeakBox.Text = "" Then
            MaxALERT.Speak("Please put text in the text box!")
        Else
            MaxALERT.Think(SpeakBox.Text)
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        MaxALERT.Speak("\Chr=""Normal""\" + "Voice reset! Use this button again if Double Agent or Microsoft Agent glitch out again! Click the Goodbye button if it still some how continues to glitch out.")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If SpeakBox.Text = "" Then
            MaxALERT.Speak("Please put text in the text box!")
        Else
            MaxALERT.Speak("\Chr=""Monotone""\" + SpeakBox.Text)
        End If
    End Sub


    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        HandlePictureBox5ClickEvent()

    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        MaxALERT.StopAll()
        player.Stop()

    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        UtilPanel1.Hide()
        UtilPanel3.Show()
      
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If MaxALERT.Visible Then
            MaxALERT.Speak("Hey! I am already here!")
        Else
            MaxALERT.Show()
        End If
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If ComboBox1.Text = "" Then

            MaxALERT.Speak("Select an animation first!")
        Else
            MaxALERT.Play(ComboBox1.Text)
        End If

    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        UtilPanel1.Hide()

        UtilPanel3.Hide()
    End Sub

    Private Sub AxAgent1_Command(ByVal sender As Object, ByVal e As AxAgentObjects._AgentEvents_CommandEvent) Handles AxAgent1.Command

        Select Case sender

            Case "ACO"
                MaxALERT.Speak("Test")
                AgentControl.PropertySheet.Visible = True
        End Select
    End Sub


    Private Sub AxAgent1_DblClick(ByVal sender As Object, ByVal e As AxAgentObjects._AgentEvents_DblClickEvent) Handles AxAgent1.DblClick
        Dim random5 As New Random()
        Dim randomNumber As Integer = random5.Next(1, 5)
        Select Case randomNumber
            Case 1
                MaxALERT.Speak("Hey! Don't double click me!")
            Case 2
                MaxALERT.Speak("Don't do that!")
            Case 3
                MaxALERT.Speak("Please don't double click!")
            Case 4
                MaxALERT.Speak("Stop!")
        End Select

    End Sub

    Private Sub AxAgent1_DragComplete(ByVal sender As Object, ByVal e As AxAgentObjects._AgentEvents_DragCompleteEvent) Handles AxAgent1.DragComplete
        Dim random5 As New Random()
        Dim randomNumber As Integer = random5.Next(1, 26)
        Select Case randomNumber
            ' temp solution, maybe perm if it just works?
            Case 1

            Case 2

            Case 3

            Case 4
                MaxALERT.Speak("Woah! Put me down!")
            Case 5

            Case 6

            Case 7

            Case 8

            Case 9

            Case 10

            Case 11

            Case 12

            Case 13

            Case 14
                MaxALERT.Speak("I'm not sure I like this spot!")
            Case 15

            Case 16

            Case 17

            Case 18

            Case 19

            Case 20

            Case 21

            Case 22

            Case 23

            Case 24

            Case 25

        End Select
    End Sub


    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        MaxALERT.Speak("\Map=""Look for the Mash file you want to open! If it has Me in it, you might wanna hide me before opening it.""=""Look for the MASH file you want to open! If it has me in it, you might wanna hide me before opening it.""\")
        If My.Settings.is64bit = 2 Then
            Dim result As MsgBoxResult = MsgBox("Is your computer 64-bit?", MsgBoxStyle.YesNo Or MessageBoxIcon.Question, "MaxALERT Rewritten")


            If result = MsgBoxResult.Yes Then
                My.Settings.is64bit = 1
                My.Settings.Save()
            ElseIf result = MsgBoxResult.No Then
                My.Settings.is64bit = 0
                My.Settings.Save()
            End If
        End If
        If My.Settings.is64bit = 1 Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "Microsoft Agent Scripting Helper files|*.msh"
            Dim programFilesDir As String
            programFilesDir = Path.Combine("C:\Program Files (x86)", "bellcraft.com\MASH\")
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim selectedFilePath As String = openFileDialog1.FileName
                Dim executablePath As String = "C:\Program Files (x86)\BellCraft.com\MASH\MASHPlay.exe"
                Process.Start(executablePath, selectedFilePath)
            End If
        End If
        If My.Settings.is64bit = 0 Then
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.Filter = "Microsoft Agent Scripting Helper files|*.msh"
            Dim programFilesDir As String
            programFilesDir = Path.Combine("C:\Program Files", "bellcraft.com\MASH\")
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                Dim selectedFilePath As String = openFileDialog1.FileName
                Dim executablePath As String = "C:\Program Files\BellCraft.com\MASH\MASHPlay.exe"
                Process.Start(executablePath, selectedFilePath)
            End If
        End If
     
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        MaxALERT.Speak("Look for the audio file you want to open! Only wave files are supported.")
        OpenFileDialog2.Filter = ".WAV files|*.wav"
        OpenFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then

            player.SoundLocation = OpenFileDialog2.FileName
            player.Play()
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        OptionsForm.Show()
    End Sub

    Private Sub MaxALERTBG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlobBG.Click

    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        MaxALERT.Speak("Alright, lets share it!")
        Dim webAddress As String = "https://twitter.com/intent/tweet?url=https%3A%2F%2Ftmafe.com%2Fmaxalert&text=Check+out+this+awesome+program!+&via=TMAFE_Official/"
        Process.Start(webAddress)

    End Sub


    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        MaxALERT.Speak("Sure! As long as you are not using it for a worm virus!")
        MaxALERT.Play("Pleased")
        Dim webAddress As String = "mailto:info@example.com?&subject=&cc=&bcc=&body=https://tmafe.com/maxalert"
        Process.Start(webAddress)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        Dim form2 As New NameForm()
        form2.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        MaxALERT.Play("Explain2")
        MaxALERT.Speak("Nice to meet you, " + My.Settings.Name + "!")
        MaxALERT.Speak("Since this is the first time we have met, I’d like to tell you a little about myself.")
        MaxALERT.Play("Explain")
        MaxALERT.Speak("I am your friend, protector, and MaxALERT! I have the ability to protect you from viruses and even learn from you. The more we browse, search, and travel the Internet together, the smarter I’ll become!")
        MaxALERT.Play("Restpose")
        MaxALERT.Speak("Well, not that I’m not \emp\ already smart.")
        MaxALERT.Play("Pleased")
        MaxALERT.Play("Explain")
        MaxALERT.Speak("Because the Internet can feel like a jungle at times, I can help you find what you are looking for and even make suggestions as to where we should go to find it! The more time we spend together, the closer we’ll become!")
        MaxALERT.Play("Explain2")
        MaxALERT.Speak("But however, you can never be too safe. There can be viruses and hackers waiting to attack you, but luckily, that’s where my antivirus functionality comes in! I can scan your computer for and delete viruses, and I can even alert you from hackers! Hence the name, MaxALERT.")
        MaxALERT.Play("Explain3")
        MaxALERT.Speak("I may be one of the smallest friends you have " + My.Settings.Name + " , but I will always try and make up for that with my big heart!")
        MaxALERT.Play("Pleased")
        MaxALERT.Play("Scout")
        MaxALERT.Speak("Am I rambling?")
        MaxALERT.Play("Acknowledge")
        MaxALERT.Speak("Alrighty then " + My.Settings.Name + ", feel free to look around.")
    End Sub

    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Me.Close()
    End Sub
    Private Sub CheckBandicam()
        Dim processes() As Process = Process.GetProcessesByName("Bandicam")

        If processes.Length > 0 Then
            MaxALERT.Speak("Why are you recording me?")
        End If
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Me.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Dim webAddress As String = "https://www.tmafe.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub ComputerUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComputerUpdate.Click
        MaxALERT.Speak("Launching MaxALERT Rewritten web page...")
        Dim webAddress As String = "https://tmafe.com/maxalert"
        Process.Start(webAddress)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        MaxALERT.Speak("Ok, searching for your term:")
        If My.Settings.isGoogleSearch = True Then
            Dim webAddress As String = "https://www.google.com/search?q=" + KeywordTextBox.Text
            Process.Start(webAddress)
        Else

            Dim webAddress As String = "https://duckduckgo.com/?q=" + KeywordTextBox.Text
            Process.Start(webAddress)
        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If URLTextBox.Text = "http://nhc.noaa.gov" OrElse URLTextBox.Text = "https://nhc.noaa.gov" Then
            MaxALERT.Speak("Hurricanes are interesting!")
        End If
        If URLTextBox.Text = "http://google.com" OrElse URLTextBox.Text = "https://google.com" Then
            MaxALERT.Speak("Ok, lets Google!")
        End If
        If URLTextBox.Text = "http://tmafe.com" OrElse URLTextBox.Text = "https://tmafe.com" Then
            MaxALERT.Speak("What an awesome website!")
        End If
        If URLTextBox.Text = "http://youtube.com" OrElse URLTextBox.Text = "https://youtube.com" Then
            MaxALERT.Speak("Gonna watch some videos, huh?")
        End If
        If URLTextBox.Text = "http://apple.com" OrElse URLTextBox.Text = "https://apple.com" Then
            MaxALERT.Speak("Interesting!")
        End If
        If URLTextBox.Text = "http://microsoft.com" OrElse URLTextBox.Text = "https://microsoft.com" Then
            MaxALERT.Speak("Oh wow, the people who discontinued us agents! Anyways.")
        End If
        If URLTextBox.Text = "http://amazon.com" OrElse URLTextBox.Text = "https://amazon.com" Then
            MaxALERT.Speak("Hey! Buy me some crackers!")
        End If
        If URLTextBox.Text = "http://reddit.com" OrElse URLTextBox.Text = "https://reddit.com" Then
            MaxALERT.Speak("Sure, I guess i'll do it.")
        End If
        If URLTextBox.Text = "http://bonzi.link" OrElse URLTextBox.Text = "https://bonzi.link" Then
            MaxALERT.Speak("This seems oddly familiar!")
        End If
        If URLTextBox.Text = "http://bing.com" OrElse URLTextBox.Text = "https://bing.com" Then
            MaxALERT.Speak("Huh. It rhymes with Wing. Anyways.")
        End If
        If URLTextBox.Text = "http://quora.com" OrElse URLTextBox.Text = "https://quora.com" Then
            MaxALERT.Speak("Alright.")
        End If
        If URLTextBox.Text = "http://tiktok.com" OrElse URLTextBox.Text = "https://tiktok.com" Then
            MaxALERT.Speak("Uh, ok.")
        End If
        MaxALERT.Speak("Navigating to the URL:")
        Dim webAddress As String = URLTextBox.Text
        Process.Start(webAddress)
    End Sub
    Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Dim tabPage As TabPage = TabControl1.TabPages(e.Index)
        Dim tabBounds As Rectangle = TabControl1.GetTabRect(e.Index)
        Dim paddedBounds As Rectangle = tabBounds

        ' Modify the tab bounds to create padding
        paddedBounds.Inflate(-2, -2)

        ' Fill the background
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 192)), tabBounds)

        ' Set the text color
        Dim textColor As Color = Color.Black

        ' Draw the tab text
        TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font, paddedBounds, textColor, TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter Or TextFormatFlags.WordEllipsis)

    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        If My.Settings.AvPath = "NONE" Then
            MaxALERT.Play("Explain")
            MaxALERT.Speak("Please select the .EXE file of your antivirus inside of its install path! You can change this later!")
            Dim openFileDialog1 As New OpenFileDialog()
            openFileDialog1.InitialDirectory = "C:\"
            openFileDialog1.Filter = "Executable Files|*.exe"
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                My.Settings.AvPath = openFileDialog1.FileName
                My.Settings.Save()
            End If
        Else
            Try
                MaxALERT.Speak("Launching your antivirus program!")
                Process.Start(My.Settings.AvPath)
            Catch ex As Exception
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("Woah! My program almost crashed! Please make your AV path is correct!")
                MaxALERT.Play("Restpose")
            End Try
        End If
    End Sub


    Private Sub StartProcessCheckTimer()
        processCheckTimer = New Timer()
        processCheckTimer.Interval = 1000 ' Check every second
        processCheckTimer.Start()
    End Sub

    Private Sub processCheckTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles processCheckTimer.Tick
        Dim processes As Process() = Process.GetProcessesByName("spysheriff")

        If processes.Length > 0 Then
            For Each process As Process In processes
                Try
                    process.Kill()
                    MaxALERT.Play("Surprised")
                    MaxALERT.Speak(My.Settings.Name + "! I have successfully terminated the following threat: Win32.Rogue.SpySheriff")
                    ThreatDetected.Show()
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If processCheckTimer IsNot Nothing Then
            processCheckTimer.Stop()
            processCheckTimer.Dispose()
        End If
    End Sub

    Private Sub RandomSpeechTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RandomSpeechTimer.Tick
        Dim random128 As New Random()
        Dim randomNumber As Integer = random128.Next(1, 22)
        Select Case randomNumber
            Case 1

                MaxALERT.Speak(My.Settings.Name + "! Where did the time go?")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Can’t you just feel us getting closer with every new day!")
                MaxALERT.Play("Pleased")
            Case 2
                MaxALERT.Play("Scout")
                MaxALERT.Speak("Don’t mind me, I’m just searching for viruses to delete.")
                MaxALERT.Play("Restpose")
            Case 3
                MaxALERT.Play("Scout")
                MaxALERT.Speak("Hey! Where did you go?")
                MaxALERT.Play("Restpose")
            Case 4
                MaxALERT.Play("Explain2")
                MaxALERT.Speak(My.Settings.Name + "! I’ve noticed you’ve been looking sharp as a tack these days!")
                MaxALERT.Play("Pleased")
            Case 5
                MaxALERT.Play("Blink")
                MaxALERT.Speak("Polly want a cracker!")
            Case 6
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Ah! What a nice day to do nothing!")
            Case 7
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Why not listen to some waves? Or watch some Mash files? They’re \emp\ sure to entertain you!")
                MaxALERT.Play("Restpose")
            Case 8
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Do you ever wonder if us Microsoft Agents support Midis?")
                MaxALERT.Play("Blink")
            Case 9
                MaxALERT.Speak("Hey, what are you doing?")
            Case 10
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("You're so fun to be around, " + My.Settings.Name + "!")

            Case 11
                MaxALERT.Play("Wave")
                MaxALERT.Speak("Hey " + My.Settings.Name + ", you're looking quite nice today!")
                MaxALERT.Play("Pleased")
                ' temp solution, maybe perm again? its working so...
            Case 12
                HandlePictureBox5ClickEvent()
            Case 13
                HandlePictureBox4ClickEvent()
            Case 14
                HandlePictureBox5ClickEvent()
            Case 15
                HandlePictureBox4ClickEvent()
            Case 16
                HandlePictureBox5ClickEvent()
            Case 17
                HandlePictureBox4ClickEvent()
            Case 18
                HandlePictureBox5ClickEvent()
            Case 19
                HandlePictureBox4ClickEvent()
            Case 20
                HandlePictureBox4ClickEvent()
            Case 21
                HandlePictureBox4ClickEvent()
        End Select
    End Sub
    Private Sub HandlePictureBox4ClickEvent()
        Dim random2 As New Random()
        Dim randomNumber As Integer = random2.Next(1, 26)

        Select randomNumber
            Case 1
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("A joke? Sure, why not?")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("A horse walks into a bar. The bartender asks, why the long face?")
                MaxALERT.Speak("Get it, because horses have long faces?")

            Case 2
                MaxALERT.Speak("Okay, if you’re sure.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("What is a pumpkin's favorite sport? Squash!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("It took me a while to get that one, but when I did I could not stop laughing!")
            Case 3
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("A joke? Sure, I've got a funny one.")
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("And what’s the deal with airline food? This stuff’s so bad, you might aswell be eating dirt! It’s like, just give me bags of peanuts I can’t even open, because I’d rather do that than eat dirt.")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("First time I heard that, I nearly fell out of my palm tree laughing!")
            Case 4
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("If you insist.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Why did the frog cross the road? Because you’re controlling him! You’re playing a game of Frogger!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("Don’t forget to tell me your score!")
            Case 5
                MaxALERT.Speak(My.Settings.Name + "? I didn't know you liked my jokes so much.")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Two muffins are in an oven. One looks at the other and says, boy it’s hot in here! And the other one says, unbelievable! It’s a talking muffin!")
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("It’d surprise me too if \emp\ I saw a muffin speak to me!")
            Case 6
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("Alright, here we go.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("What did the beaver say to the tree? It’s been nice gnawing you!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("Some of these jokes were written by Bonzi. Blame him.")
            Case 7
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Ok, " + My.Settings.Name + ", this one's sure to make you laugh!")
                MaxALERT.Speak("What do Java and Brew have in common? You can drink them both!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("I'm more of a Palm person, myself.")
            Case 8
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("You asked for it, you got it!")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Why do they call HTML HyperText? Too much Java!")
                MaxALERT.Play("restpose")
                MaxALERT.Speak("Bonzi wrote that one. Send all complaints to him.")

            Case 9
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("This one’s for all of you computer enthusiasts out there!")
                MaxALERT.Speak("What is a computer virus? A terminal illness!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("There’s a problem I \emp\ know I can handle!")
            Case 10
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("Ok, if you're sure.")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("What type of fruit is always grumpy? A crab apple!")
                MaxALERT.Play("restpose")
                MaxALERT.Speak("That was one of Bonzi’s jokes. Sorry.")
            Case 11
                MaxALERT.Speak("Ok, here goes.")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("A mystic dwarf escaped from a jail. People reported that there was a small medium at large.")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("There’s a size for everyone!")
            Case 12
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("I've been waiting to do this one, " + My.Settings.Name + "!")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Two antennas met on a roof, fell in love, and got married. The \emp\ ceremony wasn’t much, but the reception was incredible!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("There's plenty more where \emp\ that came from, " + My.Settings.Name + "!")
            Case 13
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("I didn’t think you liked my jokes \emp\ this much, " + My.Settings.Name + "!")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("And what’s the deal with keyboards? These aren’t keys, I can’t unlock \emp\ anything with this thing! I guess the \emp\ inventor of keyboards thought that they’d be the key to typing.")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Get it, because keys have multiple meanings?")
            Case 14
                MaxALERT.Speak("Let's go!")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("And what’s the deal with New York? It’s almost 400 years old! Last \emp\ I checked, that’s not very new.")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Did I mention there’s this new game console out there? It was released in 1977! …okay, maybe it’s not new.")
            Case 15
                MaxALERT.Speak("Okay, " + My.Settings.Name + ", I've got one.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Why can’t a bike stand up on its own? Because it’s two-tired!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("It sounds like ‘too tired!’ It’s almost the same words!")
            Case 16
                MaxALERT.Speak("Anything for you, " + My.Settings.Name + "!")
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Why couldn’t the plush doll eat his dinner? Because he’s been stuffed for years!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Get it, because he’s a plush doll?")
            Case 17
                MaxALERT.Play("Explain")
                MaxALERT.Speak("This one’s sure to make you laugh! What’s the perfect detective for your computer? Microsoft Agents!")
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("Hey! I fall under that category!")

            Case 18
                MaxALERT.Speak("A joke? Sure, I got a ton of them.")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("What do you call cheese that isn’t yours? Nacho cheese!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("That one's a classic!")
            Case 19
                MaxALERT.Speak("Sure thing, " + My.Settings.Name + ".")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("What do you say to a two-headed alien? Hello! Hello!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("That was another one of Bonzi’s jokes. Sorry.")
            Case 20
                MaxALERT.Speak("OK, I’ve got a good one for you.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Knock knock! Who’s there? Pencil! Pencil who? Pencil keep your legs warm!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("That one was kinda corny, I’m sorry.")
            Case 21
                MaxALERT.Speak("OK, here goes.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("What is the difference between a hill and a pill? A hill is hard to get up, and a pill is hard to get down!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("That was one of Bonzi’s jokes, and believe it or not, I actually kinda chuckled at that one!")
            Case 22
                MaxALERT.Speak("A joke? Sure thing, " + My.Settings.Name + "!")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Knock knock! Who’s there? Dishes! Dishes who? Dishes the worst meatloaf I have ever eaten!")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("Whoever made that meatloaf should consider finding a new hobby!")
            Case 23
                MaxALERT.Speak("Ok, " + My.Settings.Name + ", I've got one for you.")
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("What happens when you throw a green rock at the Red Sea? It gets wet!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Gotta love anti-humor!")
            Case 24
                MaxALERT.Speak("A joke? Sure thing!")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Why couldn’t the kid get into the pirate movie? Because it was rated arr!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Get it, because it’s about pirates?")
            Case 25
                MaxALERT.Speak("A joke? Why not!")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("If you were locked out of your house, how would you get in? Sing a song until you found the right key!")
                MaxALERT.Play("Blink")
                MaxALERT.Speak("That was yet another Bonzi joke. I’m really sorry.")
        End Select
    End Sub
    Private Sub HandlePictureBox5ClickEvent()
        Dim random3 As New Random()
        Dim randomNumber As Integer = random3.Next(1, 21)

        Select Case randomNumber
            Case 1
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("Whoa, this is crazy! Did you know that Windows 2000 was never meant for consumers? The closest thing was Windows ME, which was more like a buggy Windows 98.")

            Case 2
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Here’s some knowledge for you. Did you know that the oldest versions of Windows were DOS based? It went on like this until NT for businesses, and XP for everyone else.")
            Case 3
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Did you know that the first digital computer was invented in 1946?")
                MaxALERT.Play("Restpose")
                MaxALERT.Speak("I wouldn’t imagine they were able to do much back then.")
            Case 4
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Here’s something that might interest you! Did you know that in the 1980s, the Commodore 64 was the best selling computer of all time?")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("It makes sense, because not only are the games good, but Dang do those soundtracks slap!")
            Case 5
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Here’s a fun fact! Did you know that the computer mouse was named after its resemblance to the rodent of the same name? It’s mostly in the wire, which looks like a tail.")
                MaxALERT.Play("Restpose")
            Case 6
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Did you know that the first game console, the Brown Box, was made in 1967? It wasn’t released publicly though. The first \emp\ publicly released game console, the Magnavox Odyssey, was released in 1972!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Five years! That’s a long gap!")
            Case 7
                MaxALERT.Speak("Here's an interesting one.")
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Did you know that my fellow colleague, BonziBUDDY, originally used a green parrot named Peedy instead of the purple gorilla Bonzi?")
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("Maybe I'm \emp\ related to that parrot!")
            Case 8
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Did you know that the USB was invented in 1996? That’s an entire year after the release of Windows 95!")
            Case 9
                MaxALERT.Play("Acknowledge")
                MaxALERT.Speak("It's learning time!")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Did you know that the first polygonal computer animation was in 1972? It featured a hand, a heart valve, and even a face!")
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("For 1972, even \emp\ I’m impressed!")
            Case 10
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Did you know that Windows 1.0 wasn’t publicly released? The first publicly released version was Windows 1.01.")
            Case 11
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Well this is an interesting one, " & My.Settings.Name & "! Did you know that the invention of HDMI goes all the way back to 2002! Who knew that high definition existed for that long?")
            Case 12
                MaxALERT.Speak("Alrighty " & My.Settings.Name & ", here’s a fact for you.")
                MaxALERT.Play("Explain2")
                MaxALERT.Speak(" Did you know that the Fairchild Channel F was the first game console to truly utilize game cartridges?")
            Case 13
                MaxALERT.Speak("Do you like playing games, " & My.Settings.Name & "? If so, this fact is all about such! ")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Did you know that the first arcade video game, Computer Space, was released in 1971?")
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("That's a year before the first game console for consumers, the Magnavox Odyssey!")
            Case 14
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Did you know that Java 2 Micro Edition, often shortened to J2ME, was introduced in 1999?")
                MaxALERT.Play("Blink")
                MaxALERT.Speak("Speaking of Java, I could use a cup right now!")
            Case 15
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Did you know that the Binary Runtime Environment for Wireless, often shortened to Brew, started development in 1999? It was officially introduced 2 years later, in 2001!")
                MaxALERT.Play("Blink")
                MaxALERT.Speak("Speaking of Brew, I could use one right now!")
            Case 16
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Did you know that Palm OS was introduced in 1996? That’s \emp\ way before J2ME and Brew were introduced!")
            Case 17
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("This one’s sure to impress you as much as it impressed me!")
                MaxALERT.Play("Explain2")
                MaxALERT.Speak("Did you know that composite video was invented in 1954! Yes, you heard that right!")
                MaxALERT.Play("Surprised")
                MaxALERT.Speak("And this whole time, I thought it was invented in the 80’s!")

            Case 18
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("It’s learning time! Did you know that the Video Home System, more commonly known as VHS, was invented in 1976? It was the competitor to Betamax, and it ended up winning!")
                MaxALERT.Play("Pleased")
                MaxALERT.Speak("Go VHS!")
            Case 19
                MaxALERT.Play("Explain")
                MaxALERT.Speak("Did you know that the Atari 2600 was the first super popular game console? It wasn’t \emp\ always like that, though. It didn’t really gain popularity until the release of Space Invaders for the system, which is considered by many to be the ‘killer app’.")

            Case 20
                MaxALERT.Speak("It’s time for an amazing fact!")
                MaxALERT.Play("Explain3")
                MaxALERT.Speak("Did you know that the DVD was invented in 1995? It didn’t get an official release until a year later, though.")
        End Select
    End Sub

    Private Sub JungleUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JungleUpdate.Click
        MaxALERT.Speak("Launching MaxALERT Rewritten web page...")
        Dim webAddress As String = "https://tmafe.com/maxalert"
        Process.Start(webAddress)
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MaxALERT.Play("Explain3")
        MaxALERT.Speak("From the Utility Panel, I can play any animation you want. Simply select any animation from the drop down menu and click on the play button.")
        MaxALERT.Play("Restpose")
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MaxALERT.Play("Explain")
        MaxALERT.Speak("From the Utility Panel, I can say anything you like. Simply enter what you would like me to say and click on the Think, Whisper, Monotone, or Speak buttons.")
        MaxALERT.Play("Explain2")
        MaxALERT.Speak("And remember " + My.Settings.Name + ", let’s keep it clean!")
        MaxALERT.Play("Pleased")
    End Sub
End Class

