using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        public string Output { get; private set; }
        private (string, char)[] _codes;

        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _codes = codes;
        }
        public override void Review()
        {
            if(Input == null || _codes == null) return;
            Output = Input;
            foreach (var code in _codes)
            {
                if(code.Item1 == null || code.Item2 == default(char)) continue;
                Output = Output.Replace(code.Item2.ToString(), code.Item1);
            }
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
