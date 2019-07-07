using System.Collections.Generic;

namespace ProjektUtopia
{
  public class TextAsMethod : CodeAsText
  {
    public AccessModifiers AccessModifier { get; internal set; }
    public Modifiers Modifiers { get; internal set; }
    public string ReturnValue { get; internal set; }
    public string NotFilteredOut { get;internal  set; }    
    public int Lenght { get; internal set; }
    public TextAsMethod()
    {

    }

    public TextAsMethod(string name, AccessModifiers accessModifiers, Modifiers modifiers, string returnValue)
        {
            Name = name;
            AccessModifier = accessModifiers;
            Modifiers = modifiers;
            ReturnValue = returnValue;



        }
    
    public TextAsMethod(string code, int startLine)
        {
            StartLine = startLine;
            Lenght = Helper.CountAllLines(code);
            NotFilteredOut = Helper.ReturnMatch(code,RegexString.curvedBracketContent);
            code = Helper.ReplaceRegex(code,RegexString.curvedBracketContent);
            AccessModifier = Helper.GetAccesModifier(code);
            if(AccessModifier != AccessModifiers.None)
                code = Helper.ReplaceRegex(code,RegexString.accesModifier);
            Modifiers = Helper.GetModifiers(code);
            if (Modifiers != Modifiers.None)
                code = Helper.ReplaceRegex(code, RegexString.staticModifier);
            //needs a more elegant solution later
            List<string> ReturnAndName = Helper.ReturnAllMatches(code,@"w+");
            ReturnValue = ReturnAndName[0];
            Name = ReturnAndName[1];
        }

        public override void InitialiseFromCode(string code, int startline)
        {
            throw new System.NotImplementedException();
        }

        public override void EvaluateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
