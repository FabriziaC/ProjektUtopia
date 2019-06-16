using System.IO;

namespace ProjektUtopia
{
  public static class FileManager
  {
    public static string[] GetAllFilesOfFolder(string path) => System.IO.Directory.GetFiles(path, "*.cs");

    public static bool FileExist(string path) => File.Exists(path);

    public static bool DirectoryExist(string path) => Directory.Exists(path);
  }
}
