using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

namespace ProjektUtopia.Codemetrik.Classes
{
    public class TextAsProject : CodeAsText
    {
        #region Propserties
        public long LinesOfCode { get; set; }
        public long AmountOfComments { get; set; }
        public long AmountOfWronglyPlacedComments { get; set; }
        public List<txtFile> TextFiles { get; set; }


        #endregion

        #region Constructors
        public TextAsProject()
        {
             Initialiser();
        }

        public TextAsProject(string code,string path ="")
        {
            if (!string.IsNullOrEmpty(path) && String.IsNullOrEmpty(Parentname) )
            {
                //Filtere Projektnamen heraus
            }
            Initialiser();
            InitialiseFromCode(code,0);
            EvaluateCode();
        }

        #endregion

        private void Initialiser()
        {
            LinesOfCode = 0;
            AmountOfComments = 0;
            AmountOfWronglyPlacedComments = 0;

        }






        public void AddNewFileToCode(string code, string path = "")
        {
            InitialiseFromCode(code);
            TextFiles.Add(new txtFile(code, path));
            EvaluateCode();
        }

        public override void InitialiseFromCode(string code, int startline = 0)
        {
            if (String.IsNullOrEmpty(code))
            {
                return;
            }

            //Add imports that start with using //Delete duplicate Values later
            
        }

        public override void EvaluateCode()
        {
          
        }
    }
}
