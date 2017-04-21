using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem7 : EulerProb
    {
        public override string Solve(string list)
        {
            return Helpers.GenerateHighestPrime(Convert.ToInt64(list)).ToString();
        }

        public override string SolveSample()
        {
            return this.Solve("6");
        }
    }
}
