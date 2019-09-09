using System;
using System.Collections.Generic;
using System.Numerics;
using System.Collections;


namespace NumericalSequence
{
    public class NaturalSequenceGenerator : IEnumerable
    {
        //private List<double> repo = new List<double>();

        private double limit;

        private BigInteger inputNumber;

        public string Row { get; set; }

        public NaturalSequenceGenerator()
        {

        }

        public IEnumerable GetSequence(string input)
        {
            BigInteger.TryParse(input, out inputNumber);

            double squareRoot = Math.Exp(BigInteger.Log(inputNumber) / 2);

            limit = Math.Floor(squareRoot);

            return this as IEnumerable;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (double i = 0; i <= limit; i++)
            {
                yield return i;
            }
        }
    }
}
