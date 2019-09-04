using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FibonacciSequence
{
    class Counter : IEnumerable
    {
        #region fields

        private double ln5d2 = 0.0; // Ln(5) / 2

        private double lnFi = 0.0; //The natural logarithm of a Fi, where Fi is a "Golden Ratio"

        private double from = 0.0;

        private double to = 0.0;

        double biggerNearest = 0.0;

        double nextNumber = 0.0;

        double sum = 0.0;

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


        public IEnumerable GetSequence(double start, double end)
        {
            from = start;
            to = end;

            double k = 0.0;

            biggerNearest = findNearestNumber(from, out k);

            nextNumber = GetByPositionNumber(k + 1);

            return this as IEnumerable;
        }

        private double findNearestNumber(double n, out double k)
        {
            // Finding the nearest bigger Fibonacci number bye the Binet's formula

            double nearest;

            k = Math.Round((ln5d2 + Math.Log(n)) / lnFi);   // number of Fibonacci sequence member

            nearest = Math.Round(Math.Exp(k * lnFi - ln5d2)); // nearest bigger Fibonacci number

            if (nearest < n) //if the nearest number less than required
            {
                nearest = GetByPositionNumber(k + 1); // return next number of Fibonacci sequence
            }
            return nearest;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return biggerNearest;

            yield return nextNumber;
            
            while ((sum = biggerNearest + nextNumber) <= to)
            {
                biggerNearest = nextNumber;

                nextNumber = sum;
                yield return sum;
            }
            yield break;
        }

        #endregion

    }
}
