using System;
using System.Linq;

namespace CCEulerProjectSolutions
{
    public class NumbersToWords : EulerProb
    {

        private static readonly string[] SingleDigits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        private static readonly string[] TwoDigits = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] TensMultiple = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static readonly string[] HundredsPower = { "", "thousand", "million", "billion", "trillion" };

        private static string FindWords(int[] convertedNumber)
        {
            var finalNumberWords = "";

            if (convertedNumber.All(c => c == 0)) return "zero";

            //walk the number backward
            int hundredsPowerTracker = 0;
            for (int j = (convertedNumber.Length - 1) / 3; j >= 0; j--)
            {
                string temp = "";
                int actualIndexLocation = j * 3;
                bool isSpecialTensDigit = false;

                //0%3=0
                //1%3=1
                //2%3=2
                //3%3=0

                if (convertedNumber.Length >= actualIndexLocation && convertedNumber[actualIndexLocation] != 0) //hundreds 
                {
                    temp = SingleDigits[convertedNumber[actualIndexLocation]] + " hundred ";
                }

                if (convertedNumber.Length >= actualIndexLocation + 1) //tens
                {
                    if (convertedNumber[actualIndexLocation + 1] == 1)
                    {
                        temp += TwoDigits[convertedNumber[actualIndexLocation + 2]] + " ";
                        isSpecialTensDigit = true;
                    }
                    else
                    {
                        temp += TensMultiple[convertedNumber[actualIndexLocation + 1]] + " ";
                    }
                }

                if (convertedNumber.Length > actualIndexLocation + 2 && !isSpecialTensDigit) //ones
                {
                    if (convertedNumber[actualIndexLocation + 2] == 0)
                    {
                        //    if (string.IsNullOrWhiteSpace(temp) && hundredsPowerTracker==0) temp = "zero";
                    }
                    else
                    {
                        temp += SingleDigits[convertedNumber[actualIndexLocation + 2]] + " ";
                    }
                }

                if (!string.IsNullOrWhiteSpace(temp))
                    temp += HundredsPower[hundredsPowerTracker] + " ";

                finalNumberWords = temp + finalNumberWords;

                hundredsPowerTracker++;
            }

            return finalNumberWords;
        }

        public override string Solve(string list)
        {
            string inputNumber = list;

            Console.WriteLine(inputNumber[0]);

            string negativePrefix = "";
            string finalNumberWords = "";

            //if the first character is a negative sign ('-'), then we rip it off and save that we need to call
            //this final result negative
            if (inputNumber[0] == '-')
            {
                negativePrefix = "negative";
                inputNumber = inputNumber.Substring(1, inputNumber.Length - 2);
            }

            while (inputNumber.Length % 3 != 0)
            {
                inputNumber = "0" + inputNumber;
            }

            //it is better to store off the string as an array of numbers so we can walk through them
            //and use them as indexes into our arrays
            int[] convertedNumber = new int[inputNumber.Length];

            //have to iterate through our original string version of the number
            for (int i = 0; i < inputNumber.Length; i++)
            {
                //'0' has an int value of 48
                //so if we subtract '0' from all our characters
                //we get the real value left over without casting to int
                convertedNumber[i] = inputNumber[i] - '0';
            }

            finalNumberWords = negativePrefix + FindWords(convertedNumber);

            return finalNumberWords;
        }

        public override string SolveSample()
        {
            return Solve("100");
        }
    }
}
