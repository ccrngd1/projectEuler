using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem4 : EulerProb
    {
        public override string Solve(string list)
        {
            Int64 retVal = -1;
            Int64 MaxMultiplicand = Convert.ToInt64(list);
            double  Cutoff = MaxMultiplicand * .1;
            Cutoff = (double)Math.Ceiling((decimal)Cutoff);           

            for (int i = (int)MaxMultiplicand; i > MaxMultiplicand-Cutoff; i--)
            {
                for (int j = (int)MaxMultiplicand; j > MaxMultiplicand - Cutoff; j--)
                {
                    if (Helpers.PalindromCheck((i * j).ToString()))
                        return (i * j).ToString();
                }
            }

            return retVal.ToString();
        }

        public override string SolveSample()
        {
            return this.Solve("99");
        }        
    }
}
