using System.Collections.Generic;

namespace ProjektUtopia
{
  public class TextAsClass : CodeAsText
  {
    public AccessModifiers AccessModifier;
    public Modifiers Modifiers;
    public List<string> Errors;
    public int Lenght { get; set; }
    private bool partial;

        /// <summary>
        /// Empty Konstruktor
        /// </summary>
        public TextAsClass()
        {

        }



        public override void InitialiseFromCode(string code, int startline)
        {
            Code = code;
            StartLine = startline;
        }

        public override void EvaluateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}
