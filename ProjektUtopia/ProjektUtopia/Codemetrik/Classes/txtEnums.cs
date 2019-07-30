using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUtopia
{
    public class EnumsAsText : CodeAsText
    {

        public List<string> EnumValues { get; set; }

        public override void EvaluateCode()
        {
            throw new NotImplementedException();
        }

        public override void InitialiseFromCode(string code, int startline = 0)
        {
            //throw new NotImplementedException();
        }
    }
}
