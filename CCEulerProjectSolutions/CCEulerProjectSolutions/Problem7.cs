using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem7 : EulerProb
    {
        public override Int64 Solve(string list)
        {
            return Helpers.GenerateHighestPrime(Convert.ToInt64(list));
        }

        public override Int64 SolveSample()
        {
            return this.Solve("6");
        }
    }
}
