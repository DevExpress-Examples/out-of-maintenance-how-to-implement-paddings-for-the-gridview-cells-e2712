using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace MyXtraGrid {
    [System.ComponentModel.DesignerCategory("")]
	public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView {
		public MyGridView() : this(null) {}
		public MyGridView(DevExpress.XtraGrid.GridControl grid) : base(grid) {
			// put your initialization code here
		}
		protected override string ViewName { get { return "MyGridView"; } }

        private Padding _CellPadding= new Padding();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Padding CellPadding
        {
            get { return _CellPadding; }
            set { _CellPadding = value; LayoutChanged(); }
        }

	}
}
