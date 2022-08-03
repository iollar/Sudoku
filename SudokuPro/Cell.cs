using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuPro
{
    class Cell
    {
        private int _ColumnIndex;
        private int _RowIndex;
        private TextBox _tb;

        public Cell( int rowIndex, int columnIndex, TextBox tb)
        {
            _ColumnIndex = columnIndex;
            _RowIndex = rowIndex;
            _tb = tb;
        }

        public TextBox TextBox { get => _tb; set => _tb = value; }
    }
}
