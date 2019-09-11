using System;
using System.Collections;
using System.Collections.Generic;
using FileParser;
using Interfaces;

namespace FibonacciSequence
{
    public class SequenceGenerator : IEnumerable<int>
    {
        #region fields

        private double ln5d2 = Math.Log(5) / 2;     // Ln(5) / 2

        private double lnFi = Math.Log((1 + Math.Sqrt(5)) / 2);     //The natural logarithm of a Fi, where Fi is a "Golden Ratio"

        private int from = 0;

        private int to = 0;

        public int biggerNearest = 0;

        public int nextNumber = 0;

        private int sum = 0;

        #endregion

        public SequenceGenerator()
        {
        }

        #region methods

        public int GetByPositionNumber(int k)
        {
            return (int)Math.Round(Math.Exp(k * lnFi - ln5d2));
        }

        public IEnumerable<int> GetSequence(int start, int end)
        {
            from = start;
            to = end;

            int k = 0;

            biggerNearest = FindNearestNumber(from, out k);

            if (biggerNearest > to)
            {
                biggerNearest = 0;
            }
            else
            {
                nextNumber = GetByPositionNumber(k + 1);
            }

            return this as IEnumerable<int>;
        }

        public int FindNearestNumber(double n, out int k)
        {
            // Finding the nearest bigger Fibonacci number bye the Binet's formula

            k = (int)Math.Round((ln5d2 + Math.Log(n)) / lnFi);      // number of Fibonacci sequence member

            int nearest = (int)Math.Round(Math.Exp(k * lnFi - ln5d2));      // nearest bigger Fibonacci number

            if (nearest < n)        //if the nearest number less than required
            {
                nearest = GetByPositionNumber(k + 1);       // return next number of Fibonacci sequence
                k++;
            }

            return nearest;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (biggerNearest != 0)
            {
                yield return biggerNearest;

                if (nextNumber < to)
                {
                    yield return nextNumber;
                }

                while ((sum = biggerNearest + nextNumber) <= to)
                {

                    biggerNearest = nextNumber;
                    nextNumber = sum;

                    yield return sum;
                }
            }

            yield break;
        }

        #endregion
    }
}
