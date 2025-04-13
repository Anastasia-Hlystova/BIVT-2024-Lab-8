using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;
        public Purple_1(string input) : base(input) 
        {
            _output = "";
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_input))
            {
                _output = _input;
                return;
            }
            var result = new StringBuilder();
            int sotcw = -1; //sotcw - start of the current word

            for (int i = 0; i < _input.Length; i++)
            {
                if (IsLetter(_input[i]))
                {
                    if (sotcw == -1)
                        sotcw = i;
                }
                else
                {
                    if (sotcw != -1)
                    {
                        string word = _input.Substring(sotcw, i - sotcw);
                        char[] reversed = word.ToCharArray();
                        Array.Reverse(reversed);
                        result.Append(reversed);
                        sotcw = -1;
                    }
                    result.Append(_input[i]);
                }
            }

            if (sotcw != -1)
            {
                string word = _input.Substring(sotcw);
                char[] reversed = word.ToCharArray();
                Array.Reverse(reversed);
                result.Append(reversed);
            }

            _output = result.ToString();

        }
        public override string ToString()
        {
            return _output;
        }
    }
}
