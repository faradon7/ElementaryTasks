using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Collections;
using MyLibrary;

namespace NumericalSequence
{
    public class Counter : IEnumerable
    {
        //private List<double> repo = new List<double>();

        private double limit;

        private BigInteger inputNumber;

        public string Row { get; set; }

        public Counter()
        {

        }

        public IEnumerable GetSequence(string input, IUserCommunication communication)
        {
            BigInteger.TryParse(input, out inputNumber);

            double squareRoot = Math.Exp(BigInteger.Log(inputNumber) / 2);

            limit = Math.Floor(squareRoot);


            //communication.Print(this);
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
