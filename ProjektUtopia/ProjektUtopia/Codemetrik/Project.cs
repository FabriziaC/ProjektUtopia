using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUtopia
{
    public class Project
    {
        public long LinesOfCode { get; set; }
        public long AmountOfComments { get; set; }
        public long AmountOfWronglyPlacedComments { get; set; }
        public List<Namespace> Namespaces{get;set;}
        //public List<string> Files {get;set;}
        public Project()
        {
            LinesOfCode = 0;
            AmountOfComments = 0;
            AmountOfWronglyPlacedComments = 0;
            Namespaces = new List<Namespace>();
        }

        public Project(string code)
        {
            LinesOfCode = Helper.CountAllLines(code);
            AmountOfComments = Helper.CountAllComments(code);
            AmountOfWronglyPlacedComments = Helper.CountAllWronglyPlacedComments(code);
            Namespaces = Helper.GetAllNameSpaces(code);
            string Rest = Helper.ReplaceRegex(code,RegexString.namespaces);
        }

    }
}
