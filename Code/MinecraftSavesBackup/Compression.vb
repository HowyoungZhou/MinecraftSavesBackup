'------------------------------------------------------------
'Copyright © 2015 HowyoungZhou
'------------------------------------------------------------
'SharpZipLib
'Copyright © 2001 Mike Krueger
'------------------------------------------------------------
'You may copy and distribute verbatim copies of the Program's
'source code as you receive it, in any medium, provided that
'you conspicuously and appropriately publish on each copy an
'appropriate copyright notice and disclaimer of warranty.
'------------------------------------------------------------
'您可以对所收受的本程序源代码，无论以何种媒介，复制与发布其完
'整的复制物，然而您必须符合以下要件：以显著及适当的方式在每一
'份复制物上发布适当的著作权标示及无担保声明。
'------------------------------------------------------------
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Core

Public Class Compression
    Public Shared Sub DecompressZip(ByVal zipPath As String, ByVal folderPath As String, Optional ByVal password As String = Nothing, Optional ByVal overwrite As Boolean = True)
        Dim z As New ZipInputStream(File.OpenRead(zipPath))
        If password <> Nothing Then z.Password = password
        If folderPath = Nothing Then
            folderPath = Application.StartupPath
        End If
        If Not folderPath.EndsWith("\") Then folderPath &= "\"
        If Not Directory.Exists(folderPath) Then Directory.CreateDirectory(folderPath)

        Dim t As ZipEntry
        Dim fp As String

        Do
            t = z.GetNextEntry
            If t Is Nothing Then Exit Do
            fp = folderPath & t.Name
            If t.IsDirectory AndAlso Not Directory.Exists(fp) Then
                Directory.CreateDirectory(fp)
            ElseIf t.IsFile Then
                If (Not File.Exists(fp)) OrElse (File.Exists(fp) And overwrite) Then
                    Dim sw As FileStream = File.Create(fp)
                    Dim size As Integer
                    Dim data(2048) As Byte
                    Do
                        size = z.Read(data, 0, data.Length)
                        If size = 0 Then Exit Do
                        sw.Write(data, 0, size)
                    Loop
                    sw.Close()
                    File.SetLastWriteTime(fp, t.DateTime)
                End If

            End If
        Loop

        z.Close()
    End Sub

    Public Shared Sub CompressFolder(ByVal folderPath As String, ByVal zipPath As String, Optional ByVal level As Integer = 9, Optional ByVal password As String = Nothing)

        If Not Directory.Exists(folderPath) Then Return
        If folderPath.EndsWith("\") Then folderPath &= "\"

        Dim z As New ZipOutputStream(File.Create(zipPath))
        z.SetLevel(level)
        If password <> Nothing Then z.Password = password

        Dim fn As String, buffer(4096) As Byte
        Dim di As Integer = folderPath.Length + 1

        For Each f As String In Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly)
            fn = f.Remove(0, di)
            z.PutNextEntry(New ZipEntry(fn))
            Using fs As FileStream = File.OpenRead(f)
                StreamUtils.Copy(fs, z, buffer)
            End Using
        Next

        For Each d As String In Directory.GetDirectories(folderPath, "*", SearchOption.AllDirectories)
            fn = d.Remove(0, di) & "\"
            z.PutNextEntry(New ZipEntry(fn))
            For Each f As String In Directory.GetFiles(d, "*", SearchOption.TopDirectoryOnly)
                fn = f.Remove(0, di)
                z.PutNextEntry(New ZipEntry(fn))
                Using fs As FileStream = File.OpenRead(f)
                    StreamUtils.Copy(fs, z, buffer)
                End Using
            Next
        Next

        z.Close()
    End Sub
End Class