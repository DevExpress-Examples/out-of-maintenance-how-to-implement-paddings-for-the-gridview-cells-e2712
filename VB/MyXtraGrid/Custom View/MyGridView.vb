Imports System
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace MyXtraGrid
	<System.ComponentModel.DesignerCategory("")>
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView

		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			' put your initialization code here
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property

		Private _CellPadding As New Padding()

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
		Public Property CellPadding() As Padding
			Get
				Return _CellPadding
			End Get
			Set(ByVal value As Padding)
				_CellPadding = value
				LayoutChanged()
			End Set
		End Property

	End Class
End Namespace
