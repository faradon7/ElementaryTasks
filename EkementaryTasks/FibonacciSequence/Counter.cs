using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FibonacciSequence
{
    class Counter /*: IEnumerable*/
    {
        #region fields

        private double ln5d2 = 0.0; // Ln(5) / 2

        private double lnFi = 0.0; //The natural logarithm of a Fi, where Fi is a "Golden Ratio"

        #endregion

        #region ctors

        public Counter()
        {
            ln5d2 = ln5d2 = Math.Log(5) / 2;

            lnFi = Math.Log((1 + Math.Sqrt(5)) / 2);
        }

        #endregion

        #region methods

        public double GetByPositionNumber(double k)
        {
            return Math.Round(Math.Exp(k * lnFi - ln5d2));

        }


        public void GetSequence(string start, string end)
        {
            double from = double.Parse(start);
            double to = double.Parse(end);

            double k = 0.0;
            double biggerNearest = findNearestNumber(from, out k);

            //double nextNumber = FindNearestNumber(biggerNearest + 1.0);
            double nextNumber = GetByPositionNumber(k + 1);

            double sum = 0.0;

            Console.Write(biggerNearest + " " + nextNumber);

            while ((sum = biggerNearest + nextNumber) <= to)
            {
                biggerNearest = nextNumber;

                nextNumber = sum;

                Console.Write(" " + sum + " ");
            }
        }

        private double findNearestNumber(double n, out double k)
        {
            // Finding the nearest bigger Fibonacci number bye the Binet's formula

            double /*k, */nearest;

            k = Math.Round((ln5d2 + Math.Log(n)) / lnFi);   // number of Fibonacci sequence member

            nearest = Math.Round(Math.Exp(k * lnFi - ln5d2)); // nearest bigger Fibonacci number

            if (nearest < n) //if the nearest number less than required
            {
                nearest = GetByPositionNumber(k + 1); // return next number of Fibonacci sequence
            }
            return nearest;
        }

        //public IEnumerable count(double u)
        //{
        //    for (double i = 0; i <= limit; i++)
        //    {
        //        yield return i;
        //    }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    for (double i = 0; i <= limit; i++)
        //    {
        //        yield return i;
        //    }
        //}

        #endregion

    }
}
