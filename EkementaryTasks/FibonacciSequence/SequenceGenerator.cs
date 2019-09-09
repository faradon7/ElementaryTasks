using System;
using System.Collections;
using System.Collections.Generic;
using Helpers;
using Interfaces;

namespace FibonacciSequence
{
    public class SequenceGenerator : IEnumerable
    {
        #region fields

        private double ln5d2 = Math.Log(5) / 2; // Ln(5) / 2

        private double lnFi = Math.Log((1 + Math.Sqrt(5)) / 2);  //The natural logarithm of a Fi, where Fi is a "Golden Ratio"

        private double from = 0.0;

        private double to = 0.0;

        double biggerNearest = 0.0;

        double nextNumber = 0.0;

        double sum = 0.0;

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

            biggerNearest = FindNearestNumber(from, out k);

            nextNumber = GetByPositionNumber(k + 1);

            return this as IEnumerable;
        }

        public double FindNearestNumber(double n, out double k)
        {
            // Finding the nearest bigger Fibonacci number bye the Binet's formula

            k = Math.Round((ln5d2 + Math.Log(n)) / lnFi);   // number of Fibonacci sequence member

            double nearest = Math.Round(Math.Exp(k * lnFi - ln5d2)); // nearest bigger Fibonacci number

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
