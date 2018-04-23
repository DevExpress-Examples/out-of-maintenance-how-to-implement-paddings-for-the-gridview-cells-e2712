using System;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Drawing;

namespace MyXtraGrid {
	public class MyGridViewInfo : GridViewInfo {
		public MyGridViewInfo(DevExpress.XtraGrid.Views.Grid.GridView gridView) : base(gridView) {}

        public new MyGridView View { get { return base.View as MyGridView; } }

        public override int CalcRowHeight(Graphics graphics, int rowHandle, int visibleIndex, int min, int level, bool useCache, GridColumnsInfo columns)
        {
            int height = base.CalcRowHeight(graphics, rowHandle, visibleIndex, min, level, useCache, columns);
            int paddingHeight = View.CellPadding.Vertical;
            return height + paddingHeight;
        }
        public override int CalcColumnBestWidth(DevExpress.XtraGrid.Columns.GridColumn column)
        {
            int width = base.CalcColumnBestWidth(column);
            int paddingWidth = View.CellPadding.Horizontal;
            return width + paddingWidth;
        }

        protected override GridCellInfo CalcRowCellDrawInfoCore(GridDataRowInfo ri, GridColumnInfoArgs ci, GridCellInfo cell, GridColumnInfoArgs nextColumn, bool calcEditInfo, GridRow nextRow, bool allowCache)
        {
            GridCellInfo result = base.CalcRowCellDrawInfoCore(ri, ci, cell, nextColumn, calcEditInfo, nextRow, allowCache);
            Rectangle rect = cell.CellValueRect;
            rect.X += View.CellPadding.Left;
            rect.Width -= View.CellPadding.Horizontal;
            rect.Y += View.CellPadding.Top;
            rect.Height -= View.CellPadding.Vertical;
            cell.CellValueRect = rect;
            return result;
        }
	}
}
