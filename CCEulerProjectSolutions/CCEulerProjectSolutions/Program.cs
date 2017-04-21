#define DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CCEulerProjectSolutions
{
    public abstract class EulerProb
    {
        public abstract string Solve(string list);
        public abstract string SolveSample();
    }

    class Program
    {
        static List<EulerProb> ProbCollection = new List<EulerProb>();
        static void Main(string[] args)
        {
            ProbCollection.Add(new Problem1());
            ProbCollection.Add(new Problem2());
            ProbCollection.Add(new Problem3());
            ProbCollection.Add(new Problem4());
            ProbCollection.Add(new Problem5());
            ProbCollection.Add(new Problem6());
            ProbCollection.Add(new Problem7());
            ProbCollection.Add(new Problem8());
            ProbCollection.Add(new Problem9());
            ProbCollection.Add(new Problem10());
            ProbCollection.Add(new Problem11());

            bool proceed = true;

            while (proceed)
            {
                Console.WriteLine("please enter the problem ID number you want to solve!");
                string temp = Console.ReadLine();

                try
                {
                    Console.WriteLine("please enter comma separated values for problem");
                    int prob = Convert.ToInt32(temp);
                    temp = Console.ReadLine();

                    Console.WriteLine("calculating...");
                    Console.WriteLine(ProbCollection[prob-1].Solve(temp));
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                Console.WriteLine("Do you want to continue? [y/N]");

                if (Console.ReadKey(true).Key.ToString().ToLower().Equals("n"))
                {
                    proceed = false ;
                }
            }
        }
    }    
}


