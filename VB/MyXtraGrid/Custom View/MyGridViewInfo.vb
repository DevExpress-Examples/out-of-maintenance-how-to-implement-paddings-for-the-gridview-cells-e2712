Imports System
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Drawing

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

		Public Overrides Function CalcRowHeight(ByVal graphics As Graphics, ByVal rowHandle As Integer, ByVal visibleIndex As Integer, ByVal min As Integer, ByVal level As Integer, ByVal useCache As Boolean, ByVal columns As GridColumnsInfo) As Integer
			Dim height As Integer = MyBase.CalcRowHeight(graphics, rowHandle, visibleIndex, min, level, useCache, columns)
			Dim paddingHeight As Integer = View.CellPadding.Vertical
			Return height + paddingHeight
		End Function
		Public Overrides Function CalcColumnBestWidth(ByVal column As DevExpress.XtraGrid.Columns.GridColumn) As Integer
			Dim width As Integer = MyBase.CalcColumnBestWidth(column)
			Dim paddingWidth As Integer = View.CellPadding.Horizontal
			Return width + paddingWidth
		End Function

		Protected Overrides Function CalcRowCellDrawInfoCore(ByVal ri As GridDataRowInfo, ByVal ci As GridColumnInfoArgs, ByVal cell As GridCellInfo, ByVal nextColumn As GridColumnInfoArgs, ByVal calcEditInfo As Boolean, ByVal nextRow As GridRow, ByVal allowCache As Boolean) As GridCellInfo
			Dim result As GridCellInfo = MyBase.CalcRowCellDrawInfoCore(ri, ci, cell, nextColumn, calcEditInfo, nextRow, allowCache)
			Dim rect As Rectangle = cell.CellValueRect
			rect.X += View.CellPadding.Left
			rect.Width -= View.CellPadding.Horizontal
			rect.Y += View.CellPadding.Top
			rect.Height -= View.CellPadding.Vertical
			cell.CellValueRect = rect
			Return result
		End Function
	End Class
End Namespace
