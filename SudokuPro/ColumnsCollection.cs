using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    class ColumnsCollection
    {
        Column[] _column;
        public ColumnsCollection()
        {
            _column = new Column[9];
            for (int i = 0; i < _column.Length; i++)
                _column[i] = new Column();
        }
        public Column this[int i]
        {
            get => _column[i];
            set => _column[i] = value;
        }
    }
}
