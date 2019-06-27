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
    }
}
