using System;
using System.Data;
using System.Windows.Forms;

namespace MyXtraGrid {
    public partial class Form1 : Form {
        private DataTable CreateTable(int RowCount) {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("MultiLine", typeof(string));
            tbl.Columns.Add("Date", typeof(DateTime));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, String.Format("Line1{0}Line2{0}{1}", Environment.NewLine, i), DateTime.Now.AddDays(i) });
            return tbl;
        }
        public Form1() {
            InitializeComponent();
            myGridControl1.DataSource = CreateTable(20);
            myGridView1.UserCellPadding = new Padding(10);
        }
        private void spinEdit1_EditValueChanged(object sender, EventArgs e) {
            myGridView1.UserCellPadding = new Padding((int)spinEdit1.Value);
        }
    }
}