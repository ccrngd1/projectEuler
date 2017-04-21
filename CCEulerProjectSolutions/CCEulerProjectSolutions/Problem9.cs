using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem9 : EulerProb
    {
        public override string Solve(string list)
        {
            Int64 Sum = Convert.ToInt64(list);
            int a = 0;
            int b = 0;

            for (a = 1; a < 501; a++)
            {
                for (b = 1; b < 501; b++)
                {
                    if (a * a + b * b == (Sum - b - a) * (Sum - b - a))
                    {
                        return (a * b * (Sum-b-a)).ToString();
                    }
                }
            }
            return "-1";
        }

        public override string SolveSample()
        {
            return this.Solve("12");
        }
    }
}
