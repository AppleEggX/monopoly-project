using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly;

namespace Monopoly
{
    public class RollingDie
    {
        //should it be public or private?
        public Random randomOutcome = new Random();
        public int sidesCount;

        public void SetDieSideCount(int asidesCount)
        {
            sidesCount = asidesCount;
        }
        public int GetDieSideCount()
        {
            return sidesCount;
        }

        public int Roll()
        {
            return randomOutcome.Next(1, sidesCount + 1);
        }
    }
}
