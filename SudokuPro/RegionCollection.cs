using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuPro
{
    class RegionCollection
    {
        Region[] _region;
        public RegionCollection()
        {
            _region = new Region[9];
            for (int i = 0; i < _region.Length; i++)
                _region[i] = new Region(i);
        }
        
        public Region this[int i]
        {
            get => _region[i];
            set => _region[i] = value;
        }
    }
}
