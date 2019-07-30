using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUtopia.Codemetrik.Classes
{
    public class txtFile
    {
        public List<TextAsNamespace> NamespaceNodes { get; private set; }

        public List<txtUsingDerective> UsingNodes { get; private set; }

        public List<txtComments> CommentNodes { get; private set; }

        public string FileName { get; private set; }

        public int LinesOfCode { get; private set; }

        public txtFile(string code, string path)
        {
            LinesOfCode = Helper.CountAllLines(code);
            UsingNodes = Helper.GetObjects<txtUsingDerective>(code,RegexString.usingDirectives).Distinct<txtUsingDerective>().ToList();
            NamespaceNodes = Helper.GetObjects<TextAsNamespace>(code, RegexString.namespaces);
            string temp = Helper.ReplaceRegex(Helper.ReplaceRegex(code, RegexString.usingDirectives), RegexString.namespaces);
            CommentNodes.AddRange(Helper.GetAllComments(temp,code));
            //FileName rausfischen
        }

        


    }
}
