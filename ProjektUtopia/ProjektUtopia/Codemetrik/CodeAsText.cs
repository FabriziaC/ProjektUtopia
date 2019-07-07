using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUtopia
{
    public abstract class CodeAsText
    {
        public string Name { get; set; }
        public string Parentname { get; set; }
        public string Code { get; set; }
        public int StartLine { get; set; }
        abstract public void InitialiseFromCode(string code, int startline);
        abstract public void EvaluateCode();
    }
}
