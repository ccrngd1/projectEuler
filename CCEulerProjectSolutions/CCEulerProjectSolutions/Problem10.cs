using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem10 : EulerProb
    {
        public override string Solve(string list)
        {
            Int64 temp = Helpers.SumPrimes(Convert.ToInt64(list));

            return temp.ToString();
        }

        public override string SolveSample()
        {
            return this.Solve("10");
        }
    }
}
