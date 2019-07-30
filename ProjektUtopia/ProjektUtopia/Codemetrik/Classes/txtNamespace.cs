using System.Collections.Generic;
namespace ProjektUtopia.Codemetrik.Classes
{
  public class TextAsNamespace : CodeAsText
  {
        public List<EnumsAsText> EnumNodes { get; private set; }
        public List<TextAsClass> ClassNodes { get; private set; }
        public List<txtComments> CommentNodes { get; private set; }

        #region Constructors
        public TextAsNamespace(string code,int startline)
        {
            InitialiseFromCode(code, startline);
        }    

        public TextAsNamespace()
        {

        }

        #endregion

        public override void InitialiseFromCode(string code, int startline)
        {
            StartLine = startline;
            Code = code;
            EnumNodes = new List<EnumsAsText>();
            CommentNodes = new List<txtComments>();
            EvaluateCode();
        }

        public override void EvaluateCode()
        {
            EnumNodes = Helper.GetObjects<EnumsAsText>(Code,RegexString.enums,StartLine);
            ClassNodes = Helper.GetObjects<TextAsClass>(Code,RegexString.classWithModifiers,StartLine);
            string temp = Helper.ReplaceRegex(Helper.ReplaceRegex(Code, RegexString.enums), RegexString.classWithModifiers);
            CommentNodes.AddRange(Helper.GetAllComments(temp, Code,StartLine));
        }
    }
}
