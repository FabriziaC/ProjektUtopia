using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektUtopia
{
    public class TextAsProject : CodeAsText
    {
        public long LinesOfCode { get; set; }
        public long AmountOfComments { get; set; }
        public long AmountOfWronglyPlacedComments { get; set; }

        public List<TextAsNamespace> Namespaces{get;set;}
        public List<TextAsMethod> Methods { get; set; }
        public List<TextAsClass> Classes { get; set; }

        //public List<string> Files {get;set;}
        public TextAsProject()
        {
              Initialiser();
        }

        public TextAsProject(string code)
        {
            Initialiser();
            InitialiseFromCode(code,0);
            EvaluateCode();
        }

        private void Initialiser()
        {
            LinesOfCode = 0;
            AmountOfComments = 0;
            AmountOfWronglyPlacedComments = 0;
            Methods = new List<TextAsMethod>();
            Namespaces = new List<TextAsNamespace>();
            Classes = new List<TextAsClass>();
        }


        public void AddNewFileToCode(string code)
        {
            InitialiseFromCode(code, 0);
            EvaluateCode();
        }

        public override void InitialiseFromCode(string code, int startline)
        {
            //Add Everything to existing Properties
            List<TextAsNamespace> tempSpace = Helper.GetObjects<TextAsNamespace>(code,RegexString.namespaces,0);
            List<TextAsClass> tempClass = new List<TextAsClass>();
            List<TextAsMethod> tempMethods = new List<TextAsMethod>();
            tempSpace.ForEach(space => tempClass = Helper.GetObjects<TextAsClass>(space.Code,RegexString.classWithModifiers,0));
            tempClass.ForEach(tmpclass => tempMethods = Helper.GetObjects<TextAsMethod>(tmpclass.Code,RegexString.methods ,tmpclass.StartLine));
            //...and so on for variables , enums and propperties
            Namespaces.AddRange(tempSpace);
            Classes.AddRange(tempClass);
            Methods.AddRange(tempMethods);
            //...
        }

        public override void EvaluateCode()
        {
            LinesOfCode += Helper.CountAllLines(Code);
            AmountOfComments += Helper.CountAllComments(Code);
            AmountOfWronglyPlacedComments += Helper.CountAllWronglyPlacedComments(Code);
        }
    }
}
