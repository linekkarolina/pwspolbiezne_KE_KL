using System.Collections.Generic;

namespace Etap_0
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public class BasicMath
    {
        public float Average(List<float> numbers)
        {
            float sum = 0;

            foreach (float number in numbers)
            {
                sum += number;
            }

            return sum / numbers.Count;
        }

        public float Max(List<float> numbers)
        {
            float max = float.MinValue;
            {
                foreach (float number in numbers) 
                {
                    if (number > max)
                    {
                        max = number;
                    }
                }
            }
            return max;
        }
    }
}
