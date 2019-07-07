using System.Collections.Generic;

namespace ProjektUtopia
{
  public class TextAsClass : CodeAsText
  {
    public AccessModifiers AccessModifier;
    public Modifiers Modifiers;
    public List<Propertie> Properties;
    public List<TextAsMethod> MethodLists;
    public List<string> Errors;
    public int Lenght { get; set; }

        /// <summary>
        /// Empty Konstruktor
        /// </summary>
        public TextAsClass()
        {
            Properties = new List<Propertie>();
            MethodLists = new List<TextAsMethod>();
            Errors = new List<string>();
        }

    /// <summary>
    /// Konstruktor responsible for filling the class by it self
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public TextAsClass(string code)
    {
            TryFillClass(code);
    }

    public TextAsClass(string name, AccessModifiers accessModifiers, Modifiers modifiers, List<Propertie> properties,List<TextAsMethod> methods)
    {
            Name = name;
            AccessModifier = accessModifiers;
            Modifiers = modifiers;
            Properties = properties;
            MethodLists = methods;
    }
    
    public TextAsClass(string classHead, string body,int start,int lenght)
    {
            StartLine = start;
            Lenght = lenght;
            MethodLists = Helper.GetMethods(body);

            AccessModifier = Helper.GetAccesModifier(classHead);
            if (AccessModifier != AccessModifiers.None)
            {
                classHead = Helper.ReplaceRegex(classHead, RegexString.accesModifier);
            }
            Modifiers = Helper.GetModifiers(classHead);
            if (Modifiers != Modifiers.None)
            {
                classHead = Helper.ReplaceRegex(classHead, RegexString.classModifiers);
            }
            Name = classHead;
        }

    public void TryFillClass(string code)
        {
            MethodLists = Helper.GetMethods(code);
            code = Helper.ReplaceRegex(code, RegexString.methods);
            string classHead = Helper.ReturnMatch(code, RegexString.classHead);
            AccessModifier = Helper.GetAccesModifier(classHead);
            if (AccessModifier != AccessModifiers.None)
            {
                classHead = Helper.ReplaceRegex(classHead, RegexString.accesModifier);
            }
            Modifiers = Helper.GetModifiers(classHead);
            if (Modifiers != Modifiers.None)
            {
                classHead = Helper.ReplaceRegex(classHead, RegexString.classModifiers);
            }
            Name = classHead;
        }
    public void AddNewPropetie(Propertie propertie)
    {
            Properties.Add(propertie);
    }
    public void AddNewMethode(TextAsMethod method)
    {
            MethodLists.Add(method);
    }
    public void AddNewMethods(List<TextAsMethod> methods)
        {
            MethodLists.AddRange(methods);
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
