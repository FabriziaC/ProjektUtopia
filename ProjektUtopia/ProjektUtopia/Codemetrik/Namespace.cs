using System.Collections.Generic;
namespace ProjektUtopia
{
  public class Namespace
  {
    public string Name;
    public int Startline;
    public int Lenght;
    public List<Class> Classes;
    public string Code { get; set; }
    

    public Namespace(string head, string code)
    {
            Classes = Helper.GetAllClasses(code);
            Code = Helper.ReplaceRegex(code,RegexString.classWithModifiers);
            Name = Helper.ReplaceRegex(head,RegexString.namespacePartial);
    }    

    public Namespace()
    {}

    public void AddNewClass(Class klasse)
    {
            Classes.Add(klasse);
    }
    public void AddNewClasses(List<Class> classes)
    {
            Classes.AddRange(classes);
    }
    
    public void FillClasses()
    {
        //Fill Clases from txt files later maybe todo
    }
    public void AddNewGlobal() { /*toDO*/}

  }
}
