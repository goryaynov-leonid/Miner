using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miner_winform
{
    public class Cell
    {
        public bool HasMine { get; set; }
        public CellType TypeCell { get; set; }
        public int NeighboursCount { get; set; }
    }
}
