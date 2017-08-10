using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSpellingInKazakh
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 100; i <= 500; i++)
            {
                Console.WriteLine(i + " - " + SpellNumberInKazakh(i));
            }
        }
        private static string SpellNumberInKazakh(int number)
        {
            if (number == 0) return "нөл";

            int iteration = 1;
            IEnumerable<string> list = new LinkedList<string>();
            while (number > 0)
            {
                LinkedList<string> tempList = new LinkedList<string>();
                int remainder = number % 1000;
                if (number >= 1000)
                {
                    switch (iteration)
                    {
                        case 1: tempList.AddLast("мың "); break;
                        case 2: tempList.AddLast("миллион "); break;
                        case 3: tempList.AddLast("миллиард "); break;
                    }
                }
                if (remainder >= 100)
                {
                    switch (remainder / 100)
                    {
                        case 1: tempList.AddLast("жүз "); break;
                        case 2: tempList.AddLast("екі жүз "); break;
                        case 3: tempList.AddLast("үш жүз "); break;
                        case 4: tempList.AddLast("төрт жүз "); break;
                        case 5: tempList.AddLast("бес жүз "); break;
                        case 6: tempList.AddLast("алты жүз "); break;
                        case 7: tempList.AddLast("жеті жүз "); break;
                        case 8: tempList.AddLast("сегіз жүз "); break;
                        case 9: tempList.AddLast("тоғыз жүз "); break;
                    }
                    remainder %= 100;
                }
                if (remainder >= 10)
                {
                    switch (remainder / 10)
                    {
                        case 1: tempList.AddLast("он "); break;
                        case 2: tempList.AddLast("жиырма "); break;
                        case 3: tempList.AddLast("отыз "); break;
                        case 4: tempList.AddLast("қырық "); break;
                        case 5: tempList.AddLast("елу "); break;
                        case 6: tempList.AddLast("алпыс "); break;
                        case 7: tempList.AddLast("жетпіс "); break;
                        case 8: tempList.AddLast("сексен "); break;
                        case 9: tempList.AddLast("тоқсан "); break;
                    }
                }
                switch (remainder % 10)
                {
                    case 1: tempList.AddLast("бір "); break;
                    case 2: tempList.AddLast("екі "); break;
                    case 3: tempList.AddLast("үш "); break;
                    case 4: tempList.AddLast("төрт "); break;
                    case 5: tempList.AddLast("бес "); break;
                    case 6: tempList.AddLast("алты "); break;
                    case 7: tempList.AddLast("жеті "); break;
                    case 8: tempList.AddLast("сегіз "); break;
                    case 9: tempList.AddLast("тоғыз "); break;
                }

                number /= 1000;
                iteration++;
                list = tempList.Concat(list);
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
            }
            return sb.ToString().Trim();
        }
    }
}