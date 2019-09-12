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

        private const double invariableFormulaPart = 0.80471895621705014;       //Math.Log(5) / 2

        private const double logarithmFromFi = 0.48121182505960347;        //Math.Log((1 + Math.Sqrt(5)) / 2) 
                                                                //The natural logarithm of a Fi, where Fi is a "Golden Ratio" 
        private int from = 0;

        private int to = 0;

        public int GreaterNearest = 0;

        public int NextNumber = 0;

        private int sum = 0;

        #endregion

        public SequenceGenerator()
        {
        }

        #region methods

        private static int GetByPositionNumber(int k)
        {
            return (int)Math.Round(
                Math.Exp(k * logarithmFromFi - invariableFormulaPart));
        }

        public IEnumerable<int> GetSequence(int start, int end)
        {
            from = start;
            to = end;

            int k = 0;

            GreaterNearest = FindNearestNumber(from, out k);

            if (GreaterNearest > to)
            {
                GreaterNearest = 0;
            }
            else
            {
                NextNumber = GetByPositionNumber(k + 1);
            }

            return this as IEnumerable<int>;
        }

        private static int FindNearestNumber(double n, out int k)
        {
            // Finding the nearest bigger Fibonacci number bye the Binet's formula

            k = (int)Math.Round((invariableFormulaPart + Math.Log(n)) / logarithmFromFi);      // number of Fibonacci sequence member

            int nearest = (int)Math.Round(Math.Exp(k * logarithmFromFi - invariableFormulaPart));      // nearest bigger Fibonacci number

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
            if (GreaterNearest != 0)
            {
                yield return GreaterNearest;

                if (NextNumber <= to)
                {
                    yield return NextNumber;
                }

                while ((sum = GreaterNearest + NextNumber) <= to)
                {

                    GreaterNearest = NextNumber;
                    NextNumber = sum;

                    yield return sum;
                }
            }

            yield break;
        }

        #endregion
    }
}
