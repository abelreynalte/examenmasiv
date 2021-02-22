using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenMasiv.Helpers
{
    public static class Util
    {
        public static int[] generateNoRepeatingRandomNumbers(int size, int min, int max)
        {
            if (min > max)
            {
                int aux = min;
                min = max;
                max = aux;
            }
            if (size <= 0 || (max - min) < size - 1)
                return null;

            int[] numbers = new int[size];
            bool repeated;
            int number;
            int index = 0;

            while (index < numbers.Length)
            {
                repeated = false;
                number = generateNumberRandom(min, max);
                for (int i = 0; i < index; i++)
                {
                    if (numbers[i] == number) repeated = true;
                }
                if (!repeated)
                {
                    numbers[index] = number;
                    index++;
                }
            }

            return numbers;
        }
        public static int generateNumberRandom(int min, int max)
        {
            var _random = new Random();
            if (min > max)
            {
                int aux = min;
                min = max;
                max = aux;
            }

            return _random.Next(min, max + 1);
        }
    }
}
