using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFunctionStatic
{
    public class FunctionStatic
    {
        public static void disposeAllFromButNotThis(Form frmParent)
        {
            foreach(Form f in frmParent.MdiChildren)
            {
                f.Dispose();
                f.Close();
            }
        }

        public static int getRowSelectedGridControl(GridControl grid)
        {
            GridView gridView = grid.FocusedView as GridView;
            int row = gridView.GetSelectedRows()[0];
            return row;
        }

        public static string getValueRowSelectedGridControl(GridControl grid, int numCell)
        {
            int row = getRowSelectedGridControl(grid);
            if (row >= 0)
            {
                GridView gridView = grid.FocusedView as GridView;
                return gridView.GetRowCellValue(row, gridView.Columns[numCell].FieldName).ToString();
            }

            return null;
        }
    }
}
