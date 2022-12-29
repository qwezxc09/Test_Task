using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPick.Model
{
    public class ScrollArgs
    {
        public string Direction { get; set; } = String.Empty;
        public double Offset { get; set; } = 0.0;
        public int Speed { get; set; } = 0;
    }
}
