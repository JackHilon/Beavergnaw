using System;
using System.Collections.Generic;

namespace Beavergnaw
{
    class Program
    {
        static void Main(string[] args)
        {
            // Beavergnaw 
            // https://open.kattis.com/problems/beavergnaw
            // double third =(double) 1 / 3;

            var answers = new List<double>();
            while(true)
            {
                var myParameters = Enter2Numbers();
                double myD = myParameters[0];
                double myV = myParameters[1];

                if (myD == 0 && myV == 0)
                    break;
                answers.Add(SmallDiameter(myD, myV));
            } // end while()

            PrintList(answers);
        
        }// end main


        private static void PrintList(List<double> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(String.Format("{0:0.000000000}", item));
                //Console.WriteLine(item);
            }
        }
        private static double SmallDiameter(double yourD, double yourV)
        {
            double first = FirstResult(yourD, yourV);
            double result = CubicRoot(first);
            return result;
        }

        private static double CubicRoot(double num)
        {
            double third =(double) 1 / 3;
            return Math.Pow(num, third);
        }

        private static double FirstResult(double yourD, double yourV)
        {
            double myD = yourD;
            double myV = yourV;

            double related = (6 / Math.PI) * myV;

            double result = Math.Pow(myD, 3) - related;
            return result;
        }
        
        private static double[] Enter2Numbers()
        {
            string[] arr = new string[2] { "", "" };
            double[] res = new double[2] { 0,0 };
            try
            {
                arr = Console.ReadLine().Split(' ', 2);
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = double.Parse(arr[i]);
                }
                if (InputConditions(res) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enter2Numbers();
            }
            return res;
        }
        private static bool InputConditions(double[] arr)
        {
            double D = arr[0];
            double V = arr[1];
            if (D < 0 || D > 100)
                return false;
            else if (V < 0 || V > 1000000)
                return false;
            else 
                return true;
        }
    }
}
