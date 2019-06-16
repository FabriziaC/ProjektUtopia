using System.IO;

namespace ProjektUtopia
{
  public static class Codemetrik
  {
    public static void Run(string[] pathList)
    {
      foreach (string path in pathList)
      {
        var textCode = GetCodeOfFile(path);
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
