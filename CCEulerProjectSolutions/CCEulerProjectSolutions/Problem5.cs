﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Problem5 : EulerProb
    {
        public override string Solve(string list)
        {
            Int64 retVal = -1;
            Int64 MaxDivisor = Convert.ToInt64(list);

            int indexer = (int)MaxDivisor;
            while (true)
            {
                bool AllTrue = true;
                for (int j = 1; j <= MaxDivisor; j++)
                {
                    if (indexer % j == 0)
                    {

                    }
                    else
                    {
                        AllTrue = false;
                        indexer = indexer + (int)MaxDivisor;
                        break;
                    }
                }

                if (AllTrue)
                {
                    return indexer.ToString();
                }
            }
        }

        public override string SolveSample()
        {
            return this.Solve("10");
        }
    }
}
