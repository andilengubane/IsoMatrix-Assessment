using System;
using System.Linq;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace IsoMatrix.AssessmentTest
{
   public class StringCalculator
   {
        public static int Add(string numbers)
        {
            ValidateInputNumbers(numbers);

            var integers = ConvertStringToIntegers(numbers);
            var total = integers.Sum(x => x);
            return total;
        }

        private static void ValidateInputNumbers(string numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }
        }

        private static IEnumerable<int> ConvertStringToIntegers(string numbers)
        {
            var integers = new List<int>();

            if (numbers.Trim().Length == 0)
            {
                integers.Add(0);
            }
            else
            {
                var delimeters = FormatInputNumbers(ref numbers);

                integers = numbers.Split(delimeters.ToArray()).Where(x => x.Length > 0).Select(x => Convert.ToInt32(x)).ToList();

                var negativeNumbers = integers.Where(x => x < 0).ToList();
                if (negativeNumbers.Any())
                {
                    throw new ArgumentException(string.Format("negatives {0} not allowed",string.Join(",",negativeNumbers)));
                }
            }

            return integers;
        }

        private static List<char> FormatInputNumbers(ref string numbers)
        {
            var delimeters = new List<char>
            {
               ',', '\n'
            };

            if (numbers[0] == '/' && numbers[1] == '/' && numbers[3] == '\n')
            {
                delimeters.Add(numbers[2]);
                numbers = numbers.Remove(0,3);
            }
            return delimeters;
        }
    }
}
