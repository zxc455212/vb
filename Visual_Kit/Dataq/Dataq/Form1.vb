﻿Public Class Form1
    Class DataFrame
        Private Columns As New List(Of String)
        Private Items As New List(Of IEnumerable(Of String))

        Default Property Item(ByVal index As String) As IEnumerable(Of String)
            Get
                Return Me.Items(Me.Columns.IndexOf(index))
            End Get
            Set(ByVal value As IEnumerable(Of String))
                If Me.Columns.Contains(index) = False Then
                    Me.Columns.Add(index)
                    Me.Items.Add(value)
                Else
                    Me.Items(Me.Columns.IndexOf(index)) = value
                End If
            End Set
        End Property

        Default Property Item(ByVal index As Integer)
            Get
                Return Me(Me.Columns(index))
            End Get
            Set(ByVal value)
                Me(Me.Columns(index)) = value
            End Set
        End Property

        Shared Operator +(ByVal Data As DataFrame, ByVal value As Integer)
            Dim Output = Data.Items.Select(Function(x) x.Select(Function(y) (y + value).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, Data.Columns)
        End Operator

        Shared Operator -(ByVal Data As DataFrame, ByVal value As Integer)
            Dim Output = Data.Items.Select(Function(x) x.Select(Function(y) (y - value).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, Data.Columns)
        End Operator

        Shared Operator *(ByVal a As DataFrame, ByVal b As Integer)
            Dim Output = a.Items.Select(Function(x) x.Select(Function(y) (y * b).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, a.Columns)
        End Operator

        Shared Operator /(ByVal a As DataFrame, ByVal b As Integer)
            Dim Output = a.Items.Select(Function(x) x.Select(Function(y) (Int(y / b)).ToString).AsEnumerable).ToList
            Return New DataFrame(Output, a.Columns)
        End Operator

        Sub New(ByVal a As List(Of IEnumerable(Of String)), ByVal Columns As List(Of String))
            Me.Items = a
            Me.Columns = Columns
        End Sub

        Sub New()

        End Sub
    End Class

    Class JSON
        Shared Function parse(ByVal obj As Test)

        End Function

        Shared Function stringify(ByVal obj As Test)
            Dim res As String = ""
            Dim key = obj.GetType().GetFields().Select(Function(x) x.Name).ToArray
            Dim d = obj.GetType
        End Function
    End Class


    Class Test
        Public User As String = "admin"
        Public Password As String = "1234"
    End Class

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Data As New Test

        Dim d = JSON.stringify(Data)

        Dim DF As New DataFrame
        DF("A") = {1, 2, 3, 4}
        DF("B") = {5, 6, 7, 8}

        Dim A = DF("A")

        DF("A") = {1, 3, 5, 7}

        Dim DF2 = DF * 2

        Dim A0 = DF(0)
    End Sub
End Class