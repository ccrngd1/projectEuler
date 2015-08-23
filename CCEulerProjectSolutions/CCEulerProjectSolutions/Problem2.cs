using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    public class Problem2 : EulerProb
    {
        /// <summary>
        /// Sum all even numbers in Fibonacci sequence below list[0]
        /// </summary>
        /// <param name="list">param[0]=ceiling to add to</param>
        /// <returns></returns>
        public override Int64 Solve(string list)
        {
#if DEBUG
            List<int> debugList = new List<int>();
#endif
            int tempCeiling = 1;
            Int64 retVal = 0;
            int last1 = 1, last2 = 1;
            string[] temp = list.Split(',');
            while (tempCeiling < Convert.ToInt32(temp[0]))
            {
#if DEBUG
                debugList.Add(tempCeiling);
#endif
                if (tempCeiling % 2 == 0)
                    retVal += tempCeiling;
                tempCeiling = last1 + last2;
                last2 = last1;
                last1 = tempCeiling;
            }
            return retVal;
        }

        public override Int64 SolveSample()
        {
            return this.Solve("10");
        }
    }
}
