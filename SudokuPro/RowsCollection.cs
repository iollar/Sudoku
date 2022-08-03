using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    class RowsCollection
    {
        Row[] _row;
        public RowsCollection()
        {
            _row = new Row[9];
            for (int i=0; i< _row.Length;i++)
                _row[i] = new Row();
        }
        public Row this[int i]
        {
            get => _row[i];
            set => _row[i] = value;
        }
    }
}
