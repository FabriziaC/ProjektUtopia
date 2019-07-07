using System.IO;
using System.Linq;

namespace ProjektUtopia
{
  public static class Codemetrik
  {
    public static void Run(string[] pathList)
    {
     TextAsProject currentProject = new TextAsProject();
      foreach (string path in pathList)
      {
        var textCode = GetCodeOfFile(path);
                //hier prüfen
                //Idea that it initializes everything by it´s self by giving each object a bit of code as well as the start line of that code snippet
                //Alternativ would be a diffrent dependency would maybe be easier for linq filtering
                currentProject.AddNewFileToCode(textCode);

            }
    }

    private static string GetCodeOfFile(string path)
    {
      FileStream fs = new FileStream(path, FileMode.Open);
      string textCode;
      try
      {        
        using (StreamReader sr = new StreamReader(fs))
        {
          textCode = sr.ReadToEnd();
        }
      }
      finally
      {
        fs.Dispose();
      } 

      return textCode;
    }
  }
}
