'Fallon Smith
'RCET 0265
'Spring 2022
'Etch-A-Sketch
'

Option Explicit On
Option Strict On

Public Class EtchASketch
    Dim currentcolor As Color
    Private Sub EtchASketch_Load(sender As Object, e As EventArgs) Handles Me.Load
        currentcolor = Color.Black
    End Sub

    Sub Shake()
        Dim ShakeAmount = 100
        'Moves screen when called
        For i = 1 To 10

            Me.Top += ShakeAmount
            Me.Left += ShakeAmount
            System.Threading.Thread.Sleep(100)
            ShakeAmount *= -1
        Next
    End Sub
    Sub DrawWaveforms()
        'clear pciture box
        DrawingPictureBox.Refresh()

        'Draw lines for wavefroms
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim pn As New Pen(Color.Black)

        Dim x As Integer
        Dim y As Integer

        'spacing between adjacent lines
        Dim intSpacing As Integer = 40


        ' Draw the horizontal lines
        x = DrawingPictureBox.Width
        For y = 0 To DrawingPictureBox.Height Step intSpacing
            g.DrawLine(pn, New Point(0, y), New Point(x, y))
        Next

        ' Draw the vertical lines
        y = DrawingPictureBox.Height
        For x = 0 To DrawingPictureBox.Width Step intSpacing
            g.DrawLine(pn, New Point(x, 0), New Point(x, y))
        Next

        Sinewave()
        Cosinewave()
        Tangentwave()

    End Sub
    Sub Sinewave()
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim x, y, ymax, oldY, oldX As Integer
        Dim pen As New Pen(Color.Green)
        ymax = DrawingPictureBox.Height
        x = DrawingPictureBox.Width
        oldY = ymax
        For x = 0 To 360 Step 1

            y = CInt(ymax * Math.Sin(x * (Math.PI / 180)) * -1) + ymax


            Sketch(oldX, oldY, x, y)

            oldX = x
            oldY = y

        Next
        g.Dispose()
        pen.Dispose()
    End Sub
    Sub Cosinewave()
        Dim G As Graphics = DrawingPictureBox.CreateGraphics
        Dim x, y, ymax, oldY, oldX As Integer
        Dim pen As New Pen(Color.Blue)
        ymax = DrawingPictureBox.Height
        x = DrawingPictureBox.Width
        oldY = ymax
        For x = 0 To 360 Step 1


            y = CInt(ymax * Math.Cos(x * (Math.PI / 180)) * -1) + ymax + 25

            Sketch(oldX, oldY, x, y)
            oldX = x
            oldY = y

        Next
        g.Dispose()
        Pen.Dispose()
    End Sub
    Sub Tangentwave()
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim x, y, ymax, oldY, oldX As Integer
        Dim pen As New Pen(Color.HotPink)
        Me.currentcolor = Color.Red
        ymax = 100
        x = 45
        oldY = ymax

        For x = 0 To 360 Step 1


            Try

                y = CInt(ymax * Math.Tan(x * (Math.PI / 180)) * -1) + ymax + 25
                Sketch(oldX, oldY, x, y)
                oldY = y
                oldX = x
            Catch ex As Exception

            End Try

        Next


        g.Dispose()
        pen.Dispose()
    End Sub
    Sub PickPenColor()
        ColorDialog.ShowDialog()
        Me.currentcolor = ColorDialog.Color
    End Sub
    Sub Sketch(startX As Integer, startY As Integer, endX As Integer, endY As Integer)
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Me.currentcolor)
        'Static oldX, oldY As Integer
        g.DrawLine(pen, startX, startY, endX, endY)
        g.Dispose()
        pen.Dispose()
    End Sub
    Public Sub GraphicsForm_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseMove, DrawingPictureBox.MouseDown
        Static oldX, oldY As Integer
        'Me.Text = $"({e.X},{e.Y}) Button:{e.Button.ToString()}"

        Select Case e.Button.ToString
            Case "Left"
                Sketch(oldX, oldY, e.X, e.Y)
            Case "Middle"
                PickPenColor()
        End Select

        oldX = e.X
        oldY = e.Y

    End Sub
    'Button Events
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DrawWaveformsButton_Click(sender As Object, e As EventArgs) Handles DrawWaveformsButton.Click
        DrawWaveforms()
    End Sub

    Private Sub SelectColorButton_Click(sender As Object, e As EventArgs) Handles SelectColorButton.Click
        PickPenColor()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DrawingPictureBox.Refresh()
        Shake()
    End Sub

    Private Sub ClearButton_KeyDown(sender As Object, e As KeyEventArgs) Handles ClearButton.KeyDown
        If e.KeyCode = Keys.Escape Then
            DrawingPictureBox.Refresh()
            Shake()
        End If

    End Sub

    Private Sub DrawWaveformsButton_KeyDown(sender As Object, e As KeyEventArgs) Handles DrawWaveformsButton.KeyDown
        If e.KeyCode = Keys.Enter Then
            DrawWaveforms()
        End If
    End Sub

    'Top Menu strip handlers
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        DrawingPictureBox.Refresh()
        Shake()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutForm.Show()
        Me.Hide()
    End Sub

    Private Sub SelectColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem.Click
        PickPenColor()
    End Sub
    Private Sub DrawWaveformsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawWaveformsToolStripMenuItem.Click
        DrawWaveforms()
    End Sub


    'Context Menu Handlers
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        AboutForm.Show()
        Me.Hide()
    End Sub

    Private Sub ClearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem1.Click
        DrawingPictureBox.Refresh()
        Shake()
    End Sub
    Private Sub DrawWaveformToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DrawWaveformToolStripMenuItem.Click
        DrawWaveforms()
    End Sub

    Private Sub SelectColorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelectColorToolStripMenuItem1.Click
        PickPenColor()
    End Sub

End Class
