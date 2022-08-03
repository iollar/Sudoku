using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    unsafe class Region: DataGroup
    {
        public Region(int i)
        {
            _value = new string[9];
            _index = i;
        }
        public int NumberInRow(int number)
        {
            //-1 - нигда не встретилось
            //-2 - встретилось больше, чем в одном цикле
            int RowIndex = -1;

            for (int i = 0; i <3; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    RowIndex = 0;
                    break;
                }
            for (int i = 3; i < 6; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    if (RowIndex == -1)
                    {
                        RowIndex = 1;
                        break;
                    }
                    else
                    {
                        RowIndex = -2;
                        break;
                    }
                }
            for (int i = 6; i < 9; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    if (RowIndex == -1)
                    {
                        RowIndex = 2;
                        break;
                    }
                    else
                    {
                        RowIndex = -2;
                        break;
                    };
                }
            
            return RowIndex;
        }
        public int NumberInColumn(int number)
        {
            //-1 - нигда не встретилось
            //-2 - встретилось больше, чем в одном цикле
            int ColumnIndex = -1;
            bool test = false;

            for (int i = 0; i < 9; i += 3)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    ColumnIndex = 0;
                    break;
                }

            for (int i = 1; i < 9; i += 3)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                    if (ColumnIndex == -1)
                    {
                        ColumnIndex = 1;
                        break;
                    }
                    else
                    { ColumnIndex = -2;
                        break;
                    }
            for (int i = 2; i < 9; i += 3)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                    if (ColumnIndex == -1)
                    {
                        ColumnIndex = 2;
                        break;
                    }
                    else
                    { ColumnIndex = -2;
                        break;
                    }
            return ColumnIndex;

        }
        public void RemoveByRow(int number, int exceptSection)
        {
            for (int i = 0; i < 9; i++)
                if (i / 3 != exceptSection)
                    _value[i] = _value[i].Replace(number.ToString(), "");
        }
        public void RemoveByColumn(int number, int exceptSection)
        {
            for (int i = 0; i < 9; i++)
                if (i % 3 != exceptSection)
                    _value[i] = _value[i].Replace(number.ToString(), "");
        }
    }
}
