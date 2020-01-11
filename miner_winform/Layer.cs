using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace miner_winform
{
    public class Layer
    {
        public int ZCoordinate { get; set; }
        
        public Layer(int zCoordinate)
        {
            ZCoordinate = zCoordinate;
        }

    }
}
