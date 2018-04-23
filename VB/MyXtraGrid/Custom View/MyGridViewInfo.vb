Imports System
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Namespace MyXtraGrid
    Public Class MyGridViewInfo
        Inherits GridViewInfo

        Public Sub New(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
            MyBase.New(gridView)
        End Sub

        Public Shadows ReadOnly Property View() As MyGridView
            Get
                Return TryCast(MyBase.View, MyGridView)
            End Get
        End Property

        Public Overrides Function CalcRowHeight(ByVal graphics As Graphics, ByVal rowHandle As Integer, ByVal min As Integer, ByVal level As Integer, ByVal useCache As Boolean, ByVal columns As GridColumnsInfo) As Integer
            Dim height As Integer = MyBase.CalcRowHeight(graphics, rowHandle, min, level, useCache, columns)
            Dim paddingHeight As Integer = View.CellPadding.Vertical
            Return height + paddingHeight
        End Function
        Public Overrides Function CalcColumnBestWidth(ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As Integer
            Dim width As Integer = MyBase.CalcColumnBestWidth(column)
            Dim paddingWidth As Integer = View.CellPadding.Horizontal
            Return width + paddingWidth
        End Function

        Protected Overrides Sub CalcRowCellDrawInfoCore(ByVal ri As GridDataRowInfo, ByVal ci As DevExpress.XtraGrid.Drawing.GridColumnInfoArgs, ByVal cell As GridCellInfo, ByVal nextColumn As DevExpress.XtraGrid.Drawing.GridColumnInfoArgs, ByVal calcEditInfo As Boolean)
            MyBase.CalcRowCellDrawInfoCore(ri, ci, cell, nextColumn, calcEditInfo)
            Dim rect As Rectangle = cell.CellValueRect
            rect.X += View.CellPadding.Left
            rect.Width -= View.CellPadding.Horizontal
            rect.Y += View.CellPadding.Top
            rect.Height -= View.CellPadding.Vertical
            cell.CellValueRect = rect
        End Sub
    End Class
End Namespace
