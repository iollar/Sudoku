using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    class DataGroup
    {
        protected int _index;
        protected string[] _value;
        public string this[int i]
        {
            get => _value[i];
            set => _value[i] = value;
        }
        public bool Contains(int number)
        {
            if (_value.Contains(number.ToString()))
                return true;
            return false;
        }
        public void Remove(int number)
        {
            for (int i = 0; i < 9; i++)
                if (_value[i].Length > 1)
                   _value[i] = _value[i].Replace(number.ToString(),"");
        }
        public void Remove(string numbers)
        {
            for (int i = 0; i < 9; i++)
                if (_value[i].Length > 1 && _value[i]!= numbers)
                    for (int j = 0; j < numbers.Length; j++)
                        _value[i] = _value[i].Replace(numbers[j].ToString(), "");
        }
        public void Remove(int number, int exceptSection)
        {
            for (int i = 0; i < 9; i++)
                if(i/3!=exceptSection)
                _value[i] = _value[i].Replace(number.ToString(), "");
        }
        public bool Unique(int number)
        {
            bool result = false;

            for (int i = 0; i < 9; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    if (result == true)
                        return false;
                    result = true;
                }

            return result;
        }
        public void UniqueToValue(int unique)
        {
            for (int i = 0; i < 9; i++)
                if (_value[i].Contains(unique.ToString()))
                    _value[i] = unique.ToString();
        }

        public void Stage3()
        {
            for (int i = 0; i < 8; i++)
                for (int j = i + 1; j < 9; j++)
                    if (_value[i] == _value[j])
                        if (_value[i].Length == 2)
                            this.Remove(_value[i]);
                        else
                            Stage3(j, 2);
                    
        }
        private void Stage3(int index, int k)
        {
            for (int i = index; i < 8; i++)
                for (int j = i + 1; j < 9; j++)
                    if (_value[i] == _value[j])
                        if (_value[i].Length == k)
                            this.Remove(_value[i]);
                        else
                            Stage3(j, k + 1);
        }
        public int NumberInRegion (int number)
        {
            //-1 - нигда не встретилось
            //-2 - встретилось больше, чем в одном цикле
            int RegionIndex = -1;

            for (int i = 0; i < 3; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    RegionIndex = 0;
                    break;
                }
            for (int i = 3; i < 6; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    if (RegionIndex == -1)
                    {
                        RegionIndex = 1;
                        break;
                    }
                    else
                    {
                        RegionIndex = -2;
                        break;
                    }
                }
            for (int i = 6; i < 9; i++)
                if (_value[i].Length > 1 && _value[i].Contains(number.ToString()))
                {
                    if (RegionIndex == -1)
                    {
                        RegionIndex = 2;
                        break;
                    }
                    else
                    {
                        RegionIndex = -2;
                        break;
                    };
                }

            return RegionIndex;
        }
    }
}
