using System.Collections.Generic;
namespace ProjektUtopia
{
  public class Namespace
  {
    List<Class> _class;

        public Namespace()
        {
        }

    public string Name;
    List<Class> _class;


    public Namespace() { }
        public Namespace(string name, List<Class> classes)
        {
            Name = name;
        }

    public string Name;
    List<Class> _class;


    public Namespace() { }
    public Namespace(string name, List<Class> classes)
    {
      Name = name;
            _class = classes;
    }

    public void AddNewClass(List<Class> classes)
    {
            _class = classes;
    }

    public void AddNewClass(List<Class> classes)
    {
            _class = classes;
    }
  }
}
