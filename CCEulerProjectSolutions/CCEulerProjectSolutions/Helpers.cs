using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    class Helpers
    {
        static public List<Int64> GeneratePrimes(Int64 UpperBound)
        {
            //generate a table from 0 to UpperBound, each entry represents its index value
            //ie testField[2] represents the int 2, it will be set to true to indicate that it is truly a prime number
            //all multiples of 2 to UpperBound will be marked as false, since they can't be prime
            //we then move to the next index, i, and if it is still marked as true, repeat
            //if i is false, then try i+1

            List<Int64> retVal = new List<Int64>();

            bool[] testField = new bool[UpperBound + 1];

            //set all entries to true for now, we will set to false iteratively
            for (Int64 i = 0; i <= UpperBound; i++)
            {
                testField[i] = true;
            }

            //these can never be prime, we know
            testField[0] = false;
            testField[1] = false;

            for (Int64 i = 2; i <= UpperBound; i++)
            {
                //check to see if this number is still marked as true, if so, its a prime
                if (testField[i])
                {
                    //test every other field after this to see if its a multiple
                    //for (Int64 j = i + 1; j <= UpperBound; j++)
                    //{
                    //    //if the mod == 0, that means its a multiple and needs ot be set to false
                    //    if (j % i == 0)
                    //    {
                    //        testField[j] = false;
                    //    }
                    //}

                    int j = 2;
                    while (true)
                    {
                        if(i*j<=UpperBound)
                        {
                            testField[i * j] = false;
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    retVal.Add(i);
                }
            }

            return retVal;
        }
        static public Int64 SumPrimes(Int64 UpperBound)
        {
            //generate a table from 0 to UpperBound, each entry represents its index value
            //ie testField[2] represents the int 2, it will be set to true to indicate that it is truly a prime number
            //all multiples of 2 to UpperBound will be marked as false, since they can't be prime
            //we then move to the next index, i, and if it is still marked as true, repeat
            //if i is false, then try i+1

            Int64 retVal = 0;

            bool[] testField = new bool[UpperBound + 1];

            //set all entries to true for now, we will set to false iteratively
            for (Int64 i = 0; i <= UpperBound; i++)
            {
                testField[i] = true;
            }

            //these can never be prime, we know
            testField[0] = false;
            testField[1] = false;

            for (Int64 i = 2; i <= UpperBound; i++)
            {
                //check to see if this number is still marked as true, if so, its a prime
                if (testField[i])
                {
                    //test every other field after this to see if its a multiple
                    //for (Int64 j = i + 1; j <= UpperBound; j++)
                    //{
                    //    //if the mod == 0, that means its a multiple and needs ot be set to false
                    //    if (j % i == 0)
                    //    {
                    //        testField[j] = false;
                    //    }
                    //}

                    int j = 2;
                    while (true)
                    {
                        if (i * j <= UpperBound)
                        {
                            testField[i * j] = false;
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    retVal+=i;
                }
            }

            return retVal;
        }
        static public Int64 GenerateHighestPrime(Int64 Position)
        {
            Int64 retVal = -1;
            Int64 UpperBound = 1000000;
            Int64 counter = 0;

            bool[] testField = new bool[UpperBound + 1];

            //set all entries to true for now, we will set to false iteratively
            for (Int64 i = 0; i <= UpperBound; i++)
            {
                testField[i] = true;
            }

            //these can never be prime, we know
            testField[0] = false;
            testField[1] = false;

            for (Int64 i = 2; i <= UpperBound; i++)
            {
                                //check to see if this number is still marked as true, if so, its a prime
                if (testField[i])
                {
                    //test every other field after this to see if its a multiple
                    //for (Int64 j = i + 1; j <= UpperBound; j++)
                    //{
                    //    //if the mod == 0, that means its a multiple and needs ot be set to false
                    //    if (j % i == 0)
                    //    {
                    //        testField[j] = false;
                    //    }
                    //}

                    int j = 2;
                    while (true)
                    {
                        if (i * j <= UpperBound)
                        {
                            testField[i * j] = false;
                            j++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (i <= UpperBound && counter<Position)
                    { retVal = i; }
                    else { break; }
                    counter++;
                }
            }

            return retVal;
        }
        static public bool PalindromCheck(string toCheck)
        {
            bool retVal = false;

            string FrontHalf;
            string BackHalf;
            string ConstructedHalf;

            if (toCheck.Length == 0)
                return retVal;

            if (toCheck.Length % 2 == 0)
            {
                //this is the case for something such as 'abba'
                FrontHalf = toCheck.Substring(0, toCheck.Length / 2);
                BackHalf = toCheck.Substring(toCheck.Length / 2);
            }
            else
            {
                //this is for the case of something like 'aba' - it is still a palindrom, just not the one specified in the problem
                FrontHalf = toCheck.Substring(0, (int)Math.Floor((double)(toCheck.Length / 2)));
                BackHalf = toCheck.Substring((int)Math.Ceiling((double)(toCheck.Length / 2)) + 1);
            }

            ConstructedHalf = "";
            for (int i = FrontHalf.Length - 1; i >= 0; i--)
            {
                ConstructedHalf = ConstructedHalf + FrontHalf[i];
            }
            if (ConstructedHalf == BackHalf)
            {
                retVal = true;
            }

            return retVal;

        }
        static public Int64 MultiplyString(string toMultiply)
        {
            Int64 runningTotal = 1;
            for (int i = 0; i < toMultiply.Length; i++)
            {
                runningTotal = runningTotal * Convert.ToInt32(toMultiply[i].ToString());
            }

            return runningTotal;
        }
        static public int[,] StringToSquareArray(string spaceDelimitedArray, int squareRowNumber)
        {
            if (string.IsNullOrWhiteSpace(spaceDelimitedArray)
                || squareRowNumber <= 0) return new int[0, 0];

            int[,] inputSquare = new int[squareRowNumber, squareRowNumber];

            string[] splitArray = spaceDelimitedArray.Split(' ');

            if (splitArray.Length % squareRowNumber != 0) return new int[0, 0];

            for (int i = 0; i < squareRowNumber; i++)
            {
                for (int j = 0; j < squareRowNumber; j++)
                {
                    inputSquare[i, j] = Int32.Parse(splitArray[(i * squareRowNumber) + j]);
                }
            }

            return inputSquare;
        }
    }
}
