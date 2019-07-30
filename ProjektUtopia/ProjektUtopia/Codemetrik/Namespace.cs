using System.Collections.Generic;
namespace ProjektUtopia
{
  public class TextAsNamespace : CodeAsText
  {




        #region Constructors
        public TextAsNamespace(string head, string code,int startline)
    {
            StartLine = startline;
            Code = Helper.ReplaceRegex(code,RegexString.classWithModifiers);
            Name = Helper.ReplaceRegex(head,RegexString.namespacePartial);
    }    

    public TextAsNamespace()
    {}

        #endregion

        public override void InitialiseFromCode(string code, int startline)
        {
            
        }

        public override void EvaluateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
