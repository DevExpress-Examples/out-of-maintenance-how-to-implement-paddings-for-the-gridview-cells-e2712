Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.Utils

Namespace MyXtraGrid
    Partial Public Class Form1
        Inherits Form


        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As New DataTable()
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("MultiLine", GetType(String))
            tbl.Columns.Add("Date", GetType(Date))
            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() { String.Format("Name{0}", i), i, String.Format("Line1{0}Line2{0}{1}", Environment.NewLine, i), Date.Now.AddDays(i) })
            Next i
            Return tbl
        End Function


        Public Sub New()
            InitializeComponent()
            myGridControl1.DataSource = CreateTable(20)
        End Sub

        Private Sub spinEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles spinEdit1.EditValueChanged
            myGridView1.CellPadding = New Padding(CInt((spinEdit1.Value)))
        End Sub

    End Class
End Namespace