using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        public string Output { get; private set; }
        public (string, char)[] Codes { get; private set; }

        public Purple_3(string input) : base(input)
        {
            Codes = new (string, char)[0];
        }
        public override void Review()
        {
            if (Input == null) return;
            var top5pairs = SelectTopPairs();
            char[] freecodes = FindCodes();
            Replace(top5pairs, freecodes);

        }
        private string[] SelectTopPairs()
        {
            string[] pairs = new string[Input.Legth];
            int[] counts = new int[Input.Legth];
            int pairCount = 0;
            int[] firstOccurrence = new int[Input.Length];
            for (int i = 0; i < Input.Length - 1; i++)
            {
                if (!IsLetter(Input[i]) || !IsLetter(Input[i + 1])) continue;

                string pair = Input.Substring(i, 2);
                bool found = false;

                // Проверяем, есть ли уже такая пара
                for (int j = 0; j < pairCount; j++)
                {
                    if (pairs[j] == pair)
                    {
                        counts[j]++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    pairs[pairCount] = pair;
                    counts[pairCount] = 1;
                    firstOccurrence[pairCount] = i;
                    pairCount++;
                }
            }

            for (int i = 0; i < pairCount - 1; i++)
            {
                for (int j = i + 1; j < pairCount; j++)
                {
                    if (counts[j] > counts[i] ||
                        (counts[j] == counts[i] && firstOccurrence[j] < firstOccurrence[i]))
                    {
                        (counts[i], counts[j]) = (counts[j], counts[i]);
                        (pairs[i], pairs[j]) = (pairs[j], pairs[i]);
                        (firstOccurrence[i], firstOccurrence[j]) = (firstOccurrence[j], firstOccurrence[i]);
                    }
                }
            }

            string[] result = new string[Math.Min(5, pairCount)];
            Array.Copy(pairs, result, result.Length);
            return result;
        }
        private char[] FindCodes()
        {
            char[] codes = new char[5];
            int count = 0;

            for (int c = 32; c <= 126 && count < 5; c++)
            {
                bool exists = false;
                for (int i = 0; i < Input.Length; i++)
                {
                    if (Input[i] == c)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    codes[count++] = (char)c;
                }
            }

            if (count < 5)
            {
                char[] result = new char[count];
                Array.Copy(codes, result, count);
                return result;
            }

            return codes;
        }
        private void Replace(string[]pairs, char[] codes)
        {
            StringBuilder answer = new StringBuilder(Input);
            (string, char)[] newCodes = new (string, char)[Math.Min(pairs.Length, codes.Length)];

            for (int i = 0; i < pairs.Length && i < codes.Length; i++)
            {
                string pair = pairs[i];
                char code = codes[i];

                // Замена всех вхождений пары
                int ind = 0;
                while (ind < answer.Length - 1)
                {
                    bool flag = true;
                    for (int j = 0; j < 2; j++)
                    {
                        if (ind + j >= answer.Length || answer[ind + j] != pair[j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        answer.Remove(ind, 2);
                        answer.Insert(ind, code);
                        ind++;
                    }
                    else
                    {
                        ind++;
                    }
                }

                newCodes[i] = (pair, code);
            }

            Output = answer.ToString();
            Codes = newCodes;
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
