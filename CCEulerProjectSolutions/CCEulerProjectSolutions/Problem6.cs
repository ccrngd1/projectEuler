using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem6 : EulerProb
    {
        public override Int64 Solve(string list)
        {
            Int64 MaxNum = Convert.ToInt64(list);
            Int64 retVal = -1;

            int Sums = 0;
            int Squares = 0;

            for (int i = 1; i <= MaxNum; i++)
            {
                Sums += i;
                Squares = Squares + (i * i);
            }
            Sums = Sums * Sums;
            retVal = Sums - Squares;
            return retVal;
        }

        public override Int64 SolveSample()
        {
            return this.Solve("10");
        }
    }
}
