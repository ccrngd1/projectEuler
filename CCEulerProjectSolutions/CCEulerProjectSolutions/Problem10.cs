using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem10 : EulerProb
    {
        public override Int64 Solve(string list)
        {
            Int64 temp = Helpers.SumPrimes(Convert.ToInt64(list));

            return temp;
        }

        public override Int64 SolveSample()
        {
            return this.Solve("10");
        }
    }
}
