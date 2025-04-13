using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private const int maxLength = 50;
        public string[] Output { get;  private set; }
        public Purple_2(string input) : base(input){}
        public override void Review()
        {
            if (Input == null) return;
            string tekst = Input;
            string[] objects = Input.Split(' ');

            int maxLinesAMount = objects.Length;
            string[] Lines = new string[maxLinesAMount]; //максимально возможное кол-во строк = кол-ву объектов (слов, цифр, знаков препинания и тд) в тексте
            StringBuilder current_line = new StringBuilder();
            int ind = 0;

            foreach (string obj in objects)
            {
                if (current_line.Length == 0)
                {
                    current_line.Append(obj);
                }
                else if (current_line.Length + obj.Length + 1 <= maxLength)
                {
                    current_line.Append(' ').Append(obj);
                }
                else
                {
                    Lines[ind++] = current_line.ToString();
                    current_line.Clear();
                    current_line.Append(obj);
                }
            }
            //добавляем последнюю строку отдельно, тк она не попадает в else, где мы добавляем строку в массив строк
            if(current_line.Length > 0)
            {
                Lines[ind++] = current_line.ToString();
            }
            Array.Resize(ref Lines, ind); //приводим массив к реальному количеству строк
            ExtraSpaces(Lines);
            Output = Lines;
        }
        private void ExtraSpaces(string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = lines[i].Split(' ');
                int current_spaces_amount = words.Length - 1;
                int nehvataet = maxLength - lines[i].Length;
                if (words.Length == 1)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < words.Length - 1; j++)
                    {
                        int neededamountnow = (nehvataet + current_spaces_amount - 1) / current_spaces_amount;
                        words[j] = words[j] + new string(' ', neededamountnow);
                        nehvataet -= neededamountnow;
                        current_spaces_amount--;
                    }
                }
                lines[i] = string.Join(" ", words);
            }
        }
        public override string ToString()
        {
            return Output != null && Output.Length > 0 ? string.Join(Environment.NewLine, Output) : string.Empty;
        }
    }
}
