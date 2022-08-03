using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    class DataSudoku
    {

        
        private string[,] _data;
        private string[,] _solveData;
        private string[,] _oldData;
        private RegionCollection _region;
        private ColumnsCollection _columns;
        private RowsCollection _rows;
        private int[] _rInd;
        private int[] _iterationOfSolution = new int[4];

        public DataSudoku()
        {
            _solveData = new string[9, 9];
            _oldData = new string[9, 9];
            _data = new string[9, 9];
            _region = new RegionCollection();
            _columns = new ColumnsCollection();
            _rows = new RowsCollection();
        }
        public string[,] Data { get => _data; }
        public int[] IterationOfSolution { get => _iterationOfSolution; set => _iterationOfSolution = value; }
        public string[,] OldData { get => _oldData; set => _oldData = value; }
        public string[,] SolveData { get => _solveData; set => _solveData = value; }

        public void Generate(string difficulty)
        {

            Random r = new Random(DateTime.Now.Millisecond);
            int n;
            

            //заполнение поля
            n = 1;
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int i2 = 0; i2 < 3; i2++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (n > 9)
                            n -= 9;
                        _data[i1 * 3 + i2, j] = (n).ToString();
                        //FillDataGroups(_data[j, i], j, i);
                        n++;
                    }
                    n += 3;
                }
                n += 1;
            }
            n = r.Next(0, 2);
            if (r.Next(0, 2) == 0)
                for (int i = 0; i < 9; i++)
                    for (int j = 0; j < 9; j++) ;
            //_data[i, j] = _rows[i, j];

            //перетасовка строк
            string s;
            n = r.Next(0, 50);
            for (int i = 0; i < n; i++)
            {
                int c = r.Next(0, 3) * 3, a = 0, b = 0;
                while (a == b) { a = c + r.Next(0, 3); b = c + r.Next(0, 3); }

                for (int j = 0; j < 9; j++)
                {
                    s = _data[a, j];
                    _data[a, j] = _data[b, j];
                    _data[b, j] = s;
                }
            }

            //перетасовка столбцов
            n = r.Next(0, 50);
            for (int i = 0; i < n; i++)
            {
                int c = r.Next(0, 3) * 3, a = 0, b = 0;
                while (a == b) { a = c + r.Next(0, 3); b = c + r.Next(0, 3); }

                for (int j = 0; j < 9; j++)
                {
                    s = _data[j, a];
                    _data[j, a] = _data[j, b];
                    _data[j, b] = s;
                }
            }
            //перетасовка регионов по горизонтали
            n = r.Next(0, 6);
            for (int k = 0; k < n; k++)
            {
                int a = 0, b = 0;
                while (a == b) { a = r.Next(0, 3); b = r.Next(0, 3); }

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        s = _data[j, a * 3 + i];
                        _data[j, a * 3 + i] = _data[j, b * 3 + i];
                        _data[j, b * 3 + i] = s;
                    }
            }
            //перетасовка регионов по вертикали
            n = r.Next(0, 6);
            for (int k = 0; k < n; k++)
            {
                int a = 0, b = 0;
                while (a == b) { a = r.Next(0, 3); b = r.Next(0, 3); }

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 9; j++)
                    {
                        s = _data[a * 3 + i, j];
                        _data[a * 3 + i, j] = _data[b * 3 + i, j];
                        _data[b * 3 + i, j] = s;
                    }
            }

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    _solveData[i, j] = _data[i, j];

            //удаление
            List<int> nn = Enumerable.Range(0, 81).ToList();

            string oldCellValue;
            bool test = true;
            int a2 = 0;
            Fill(_oldData);
            while (nn.Count > 0 && test)
            {
                a2 = nn[r.Next(0, nn.Count)];
                nn.Remove(a2);

                oldCellValue = _data[a2 / 9, a2 % 9];
                _data[a2 / 9, a2 % 9] = "123456789";
                FillDataGroups();
                Solution();
                if (Done())
                {
                    switch (difficulty)
                    {
                        case "easy":
                            if (_iterationOfSolution[1] > 0 || _iterationOfSolution[2] > 0 || _iterationOfSolution[3] > 0)
                                test = false;
                            break;
                        case "medium":
                            if (_iterationOfSolution[2] > 0 || _iterationOfSolution[3] > 0)
                                test = false;
                            break;
                    }
                    _solveData[a2 / 9, a2 % 9] = null; _solveData[a2 / 9, a2 % 9] = null;
                    if (!test)
                    {
                        break;
                    }
                    else
                    {
                        _data[a2 / 9, a2 % 9] = oldCellValue;
                        if (nn.Count == 0) ;


                    }
                }
            }
        }
        public void Fill(string[,] values)//ok
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    string value;

                    if (values[i,j]==null || values[i, j].Length == 0)
                        value = "123456789";
                    else
                        value = values[i, j];
                    _data[i, j] = value;
                    FillDataGroupsCell(value, i, j);
                }
        }
        public void FillDataGroupsCell(string value, int rowIndex, int columnIndex)//ok
        {
            _rInd = RegionIndex(rowIndex, columnIndex);

            _rows[rowIndex][columnIndex] = value;
            _columns[columnIndex][rowIndex] = value;
            _region[_rInd[0]][_rInd[1]] = value;
        }
        public void FillDataGroups()//ok
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    _rInd = RegionIndex(i, j);

                    _rows[i][j] = _data[i,j];
                    _columns[j][i] = _data[i, j];
                    _region[_rInd[0]][_rInd[1]] = _data[i, j];
                }
        }
        private bool RefreshData()//ok
        {
            string oldData;
            bool result = false;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    oldData = _data[i, j];
                    _rInd = RegionIndex(i, j);
                    _data[i, j] = Intersection(_rows[i][j], _columns[j][i], _region[_rInd[0]][_rInd[1]]);
                    result = result || oldData != _data[i, j];
                }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    FillDataGroupsCell(_data[i, j], i, j);
            return result;
        }

        public string Intersection(string firstSet, string secondSet, string thirdSet)
        {
            string result = "";
            foreach (char ch in firstSet)
                if (secondSet.Contains(ch) && thirdSet.Contains(ch))
                    result += ch;
            return result;
        }
        public bool Done()
        {
            //bool result = false;
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (_data[i,j].Length != 1)
                        return false;
            return true;
        }
        public bool Stage1()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 1; j < 10; j++)
                {
                    if (_region[i].Contains(j))
                        _region[i].Remove(j);
                    if (_rows[i].Contains(j))
                        _rows[i].Remove(j);
                    if (_columns[i].Contains(j))
                        _columns[i].Remove(j);
                }
           return RefreshData();
        }
        public bool Stage2()
        {
            for (int i = 0; i < 9; i++)
                for (int j = 1; j < 10; j++)
                {
                    if (_region[i].Unique(j))
                        _region[i].UniqueToValue(j); 
                    if (_rows[i].Unique(j))
                        _rows[i].UniqueToValue(j);
                    if (_columns[i].Unique(j))
                        _columns[i].UniqueToValue(j);
                }
            return RefreshData();
        }
        public bool Stage3()
        {
            for (int i = 0; i < 9; i++)
            {
                _region[i].Stage3();
                _rows[i].Stage3();
                _columns[i].Stage3();
            }
            return RefreshData();
        }
        public bool Stage4()
        {
            int k;
            for (int i = 0; i < 3; i++)
               for (int j = 0; j < 3; j++)
                    for (int n = 1; n < 10; n++)
                    {
                        k = _region[i*3 + j].NumberInRow(n);

                        if(k>=0)
                        { _rows[i*3 + k].Remove(n, j); }

                        k = _region[i*3 + j].NumberInColumn(n);

                        if (k >= 0)
                        { _columns[j*3 +k].Remove(n, i); }
                    }
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int n = 1; n < 10; n++)
                    {
                        k = _rows[i * 3 + j].NumberInRegion(n);

                        if (k >= 0)
                        { _region[i * 3 + k].RemoveByRow(n, j); }

                        k = _columns[i * 3 + j].NumberInRegion(n);

                        if (k >= 0)
                        { _region[i + k * 3].RemoveByColumn(n, j); }
                    }

            return RefreshData();
        }
        public void Solution()
        {
            _iterationOfSolution = new int[] { 0, 0, 0, 0 };
            do
            {
                do
                {
                    do
                    {
                        do
                        {
                            
                            _iterationOfSolution[0]++;
                        }
                        while (Stage1());
                        _iterationOfSolution[0]--;
                        _iterationOfSolution[1]++;
                    }
                    while (Stage2());
                    _iterationOfSolution[1]--;
                    _iterationOfSolution[2]++;
                }
                while (Stage3());
                _iterationOfSolution[2]--;
                _iterationOfSolution[3]++;
            }
            while (Stage4());
            _iterationOfSolution[3]--;
        }
        public void Perebor1(int iStart, int jStart) 
        {
        }
        public void Perebor(int iStart, int jStart)
        {
           if (jStart > 8)
           { jStart = 0; iStart += 1; }
            if (iStart < 9)
            {
                string oldData = _data[iStart, jStart];

                if (oldData.Length == 1)
                    Perebor(iStart, jStart + 1);
                else if (oldData.Length == 0)
                    return;
                else //if (_data.Length > 1)
                    foreach (char ch in oldData)
                    {
                        _data[iStart, jStart] = ch.ToString();

                        ///////////////
                        /////////////
                        ////////////
                        FillDataGroupsCell(_data[iStart, jStart], iStart, jStart);

                        Solution();
                        if (Done()) return;
                        ////////////////
                        ///////////////
                        //////////////
                        
                        //F11
                        else Perebor(iStart, jStart + 1);


                        ////////////////
                        ///////////////
                        //////////////
                        for (int i = iStart; i < 9; i++)
                            for (int j = jStart; j < 9; j++)
                                _data[i, j] = _oldData[i, j];
                        for (int i = iStart; i < 9; i++)
                            for (int j = jStart; j < 9; j++)
                                FillDataGroupsCell(_data[i, j], i, j);
                        Solution();
                        ////////////////
                        ///////////////
                        //////////////
                        
                        //F11
                        Perebor(iStart, jStart);
                    }
            }
            return;
        }
        public int[] RegionIndex(int i, int j)
        {
            int[] result = new int[2] { 0, 0 };
            RegionIndex(i, ref result);
            result[0] *= 3;
            result[1] *= 3;
            RegionIndex(j, ref result);
            return result;
        }
        public void RegionIndex(int i, ref int[] result)
        {
            if (i > 5)
                result[0] += 2;
            else if (i > 2)
                result[0] += 1;
            if (i % 3 == 2)
                result[1] += 2;
            else if (i % 3 == 1)
                result[1] += 1;
        }
        //public SquaresCollection Squares { get => _squares; set => _squares=value; }
        //public ColumnsCollection Columns { get => _columns; }
        //public RowsCollection Rows { get => _rows; }

        //public string[,] Value { get; set; }
        private int TernarySystemConvertor(int a, int b)
        {
            //columnIndex /= 3;
            //rowIndex /= 3;
            return a / 3 * 3 + b / 3;
        }

    }
}
