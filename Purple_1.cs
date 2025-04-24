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
        public Purple_1(string input) : base(input){}
        public override void Review()
        {
            if (_input == null) return;
            if (string.IsNullOrEmpty(_input))
            {
                _output = _input;
                return;
            }
            var result = new StringBuilder();
            int sotcw = -1; //sotcw - start of the current word
            bool hasdigits = false;
            for (int i = 0; i < _input.Length; i++)
            {
                if (IsLetter(_input[i]) || char.IsDigit(_input[i]))
                {
                    if (sotcw == -1)
                    {
                        sotcw = i;
                        hasdigits = false;
                    }
                    if (char.IsDigit(_input[i]))
                    {
                        hasdigits = true;
                    }

                }
                else
                {
                    if (sotcw != -1)
                    {
                        string word = _input.Substring(sotcw, i - sotcw);
                        if (hasdigits) 
                        {
                            result.Append(word);
                        }
                        else 
                        { 
                            char[] reversed = word.ToCharArray();
                            Array.Reverse(reversed);
                            result.Append(reversed);
                        }
                        sotcw = -1;
                    }
                    result.Append(_input[i]);
                }
            }

            if (sotcw != -1)
            {
                string word = _input.Substring(sotcw);
                if (hasdigits)
                {
                    result.Append(word);
                }
                else
                {
                    char[] reversed = word.ToCharArray();
                    Array.Reverse(reversed);
                    result.Append(reversed);
                }
                
            }

            _output = result.ToString();

        }
        public override string ToString()
        {
            return _output;
        }
    }
}
