'------------------------------------------------------------
'Copyright © 2015 HowyoungZhou
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
Public Class HSXML
    Public Function Read(ByVal Path As String, ByVal Name As String) As String
        Dim before As String
        Dim after As String
        Dim all As String
        Dim before_i As Double
        Dim after_i As Double
        Dim left_found As Boolean
        Dim right_found As Boolean
        Dim found_text As String
        Dim text As String = My.Computer.FileSystem.ReadAllText(Path)
        before = "<" & Name & ">"
        after = "<" & Name & "/>"
        all = text
        left_found = False
        right_found = False
        For before_i = before.Length To all.Length
            Dim s1 As String = Strings.Left(all, before_i)
            Dim s2 As String = Strings.Right(s1, before.Length)
            If s2 = before Then
                left_found = True
                Exit For
            End If
        Next
        If left_found = False Then
            Return "NOTFOUND"
        Else
            all = Strings.Right(all, all.Length - before_i)
            For after_i = after.Length To all.Length
                Dim s1 As String = Strings.Left(all, after_i)
                Dim s2 As String = Strings.Right(s1, after.Length)
                If s2 = after Then
                    right_found = True
                    Exit For
                End If
            Next
            If right_found = False Then
                Return "NOTFOUND"
            Else
                found_text = Strings.Left(all, after_i - after.Length)
                Return found_text
            End If
        End If
    End Function

    Public Function Write(ByVal Name As String, ByVal Text As String, ByVal Path As String) As Boolean
        Try
            If My.Computer.FileSystem.FileExists(Path) = True Then
                If My.Computer.FileSystem.ReadAllText(Path).Contains("HSXML V1.0") = False Then My.Computer.FileSystem.WriteAllText(Path, "HSXML V1.0" & vbCrLf, False)
            Else
                My.Computer.FileSystem.WriteAllText(Path, "HSXML V1.0" & vbCrLf, False)
            End If
            My.Computer.FileSystem.WriteAllText(Path, "<" & Name & ">" & Text & "<" & Name & "/>" & vbCrLf, True)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Count(ByVal Path As String) As Integer
        Dim txtbox As New System.Windows.Forms.TextBox
        With txtbox
            .Text = My.Computer.FileSystem.ReadAllText(Path)
            .Multiline = True
        End With
        Dim linetxt As String = "*"
        Dim i As Integer = 0
        Dim getcount As Integer = 0
        Do Until linetxt = Nothing
            Try
                linetxt = txtbox.Lines(i)
                If linetxt.Contains("<") And linetxt.Contains("/") And linetxt.Contains(">") Then getcount = getcount + 1
                i = i + 1
            Catch ex As Exception
                Exit Do
            End Try
        Loop
        Return getcount
    End Function

    Public Function Verify(ByVal Path As String, ByVal Name As String) As Boolean
        Dim before As String
        Dim after As String
        Dim all As String
        Dim before_i As Double
        Dim after_i As Double
        Dim left_found As Boolean
        Dim right_found As Boolean
        Dim found_text As String
        Dim text As String = My.Computer.FileSystem.ReadAllText(Path)
        before = "<" & Name & ">"
        after = "<" & Name & "/>"
        all = text
        left_found = False
        right_found = False
        For before_i = before.Length To all.Length
            Dim s1 As String = Strings.Left(all, before_i)
            Dim s2 As String = Strings.Right(s1, before.Length)
            If s2 = before Then
                left_found = True
                Exit For
            End If
        Next
        If left_found = False Then
            Return False
        Else
            all = Strings.Right(all, all.Length - before_i)
            For after_i = after.Length To all.Length
                Dim s1 As String = Strings.Left(all, after_i)
                Dim s2 As String = Strings.Right(s1, after.Length)
                If s2 = after Then
                    right_found = True
                    Exit For
                End If
            Next
            If right_found = False Then
                Return False
            Else
                found_text = Strings.Left(all, after_i - after.Length)
                Return True
            End If
        End If
    End Function
End Class
