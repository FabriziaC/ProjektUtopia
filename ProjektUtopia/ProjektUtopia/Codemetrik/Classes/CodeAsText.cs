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
        
        /// <summary>
        /// Initialise the Properties of this class with a text snippet that starts at a given line inside a bigger string
        /// </summary>
        /// <param name="code"></param>
        /// <param name="startline"></param>
        abstract public void InitialiseFromCode(string code, int startline = 0);

        /// <summary>
        /// Look through Properties and check if there are any Errors or Warnings
        /// </summary>
        abstract public void EvaluateCode();
    }
}
