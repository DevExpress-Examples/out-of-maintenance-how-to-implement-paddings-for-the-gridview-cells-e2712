using System;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace MyXtraGrid {
	public class MyGridViewInfo : GridViewInfo {
		public MyGridViewInfo(DevExpress.XtraGrid.Views.Grid.GridView gridView) : base(gridView) {}

        public new MyGridView View { get { return base.View as MyGridView; } }

        public override int CalcRowHeight(Graphics graphics, int rowHandle, int min, int level, bool useCache, GridColumnsInfo columns)
        {
            int height = base.CalcRowHeight(graphics, rowHandle, min, level, useCache, columns);
            int paddingHeight = View.CellPadding.Vertical;
            return height + paddingHeight;
        }
        public override int CalcColumnBestWidth(DevExpress.XtraGrid.Columns.GridColumn column)
        {
            int width = base.CalcColumnBestWidth(column);
            int paddingWidth = View.CellPadding.Horizontal;
            return width + paddingWidth;
        }

        protected override void CalcRowCellDrawInfoCore(GridDataRowInfo ri, DevExpress.XtraGrid.Drawing.GridColumnInfoArgs ci, GridCellInfo cell, DevExpress.XtraGrid.Drawing.GridColumnInfoArgs nextColumn, bool calcEditInfo)
        {
            base.CalcRowCellDrawInfoCore(ri, ci, cell, nextColumn, calcEditInfo);
            Rectangle rect = cell.CellValueRect;
            rect.X += View.CellPadding.Left;
            rect.Width -= View.CellPadding.Horizontal;
            rect.Y += View.CellPadding.Top;
            rect.Height -= View.CellPadding.Vertical;
            cell.CellValueRect = rect;
        }
	}
}
