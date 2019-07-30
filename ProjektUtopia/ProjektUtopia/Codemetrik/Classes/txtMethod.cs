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


    
    public TextAsMethod(string code, int startLine)
    {
            InitialiseFromCode(code,startLine);
    }

    public override void InitialiseFromCode(string code, int startLine)
    {
        StartLine = startLine;
        Code = code;
    }

    public override void EvaluateCode()
    {
        //throw new System.NotImplementedException();
    }
  }
}
