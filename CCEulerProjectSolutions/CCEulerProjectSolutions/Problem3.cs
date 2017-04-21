using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    public class Problem3 : EulerProb
    {
        public override string Solve(string list)
        {
#if DEBUG

#endif

            List<Int64> retVal = new List<Int64>();

            Int64 CompositeNumber = Convert.ToInt64(list);
            Int64 top = (long)Math.Sqrt(CompositeNumber);

            List<Int64> factors = new List<Int64>();
            List<Int64> SomePrimes = new List<Int64>();

            SomePrimes = Helpers.GeneratePrimes(top);

            int i = 0;
            try
            {

                for (i = SomePrimes.Count-1; i >0; i--)
                {
                    if (CompositeNumber % SomePrimes[i] == 0)
                    {
                        retVal.Add(SomePrimes[i]);
                    }
                }
            }
            catch { throw; }

            if (retVal.Count > 0)
            {
                return retVal[0].ToString();
            }
            else
            {
                return "-1";
            }   
        }

        public override string SolveSample()
        {
            return this.Solve("13195");
        }
    }
}
