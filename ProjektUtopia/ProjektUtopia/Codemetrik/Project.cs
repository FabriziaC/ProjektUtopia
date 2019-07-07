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
        public List<Method> Methods { get; set; }
        public List<Class> Classes { get; set; }

        //public List<string> Files {get;set;}
        public Project()
        {
              Initialiser();
        }

        public Project(string code)
        {
            Initialiser();
            AddNewFileToCode(code);
        }

        private void Initialiser()
        {
            LinesOfCode = 0;
            AmountOfComments = 0;
            AmountOfWronglyPlacedComments = 0;
            Methods = new List<Method>();
            Namespaces = new List<Namespace>();
            Classes = new List<Class>();
        }


        public void AddNewFileToCode(string code)
        {   
            //Add Everything to existing Properties
            LinesOfCode += Helper.CountAllLines(code);
            AmountOfComments  += Helper.CountAllComments(code);
            AmountOfWronglyPlacedComments += Helper.CountAllWronglyPlacedComments(code);
            List<Namespace> tempSpace = Helper.GetAllNameSpaces(code);
            List<Class> tempClass = new List<Class>();
            List<Method> tempMethods = new List<Method>();
            tempSpace.ForEach(space => tempClass = Helper.GetAllClasses(space.Code,space.Startline));
            tempClass.ForEach(tmpclass => tempMethods = Helper.GetMethods(tmpclass.Code,tmpclass.StartLine)) ;
            //...and so on for variables , enums and propperties
            Namespaces.AddRange(tempSpace);
            Classes.AddRange(tempClass);
            Methods.AddRange(tempMethods);
            //...
        }



    }
}
