using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
        public class Problem1 : EulerProb
        {
            /// <summary>
            /// Will Find the sum of all the multiples of comma-sepeerate values in string[1..n] below string[0]
            /// </summary>
            /// <param name="list">0=ceiling, 1..n=multiples</param>
            /// <returns>sum of all numbers</returns>
            public override Int64 Solve(string list)
            {
                Int64 retVal = 0;
                string[] temp = list.Split(',');
#if DEBUG
                List<int> debugList = new List<int>();
#endif
                try
                {
                    int tempCeiling = 0;
                    while (tempCeiling < Convert.ToInt32(temp[0]))
                    {
                        for (int i = 1; i < temp.Length; i++)
                        {
                            if ((tempCeiling % Convert.ToInt32(temp[i])) == 0)
                            { retVal += tempCeiling; break; }
                        }
                        tempCeiling++;
                    }
                }
                catch (Exception ex) { retVal = -1; Console.WriteLine(ex.ToString()); }

                return retVal;
            }

            public override Int64 SolveSample()
            {
                return Solve("10, 3, 5");
            }
        }
    
}
