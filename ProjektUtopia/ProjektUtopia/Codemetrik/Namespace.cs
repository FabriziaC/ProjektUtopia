using System.Collections.Generic;
namespace ProjektUtopia
{
  public class Namespace
  {
    public string Name { get; set; }
    public int Startline { get; set; }
    public int Lenght { get; set; }
    public List<Class> Classes { get; set; }
    public string Code { get; set; }

    private bool partial;


    public Namespace(string head, string code,int startline, bool partial = false)
    {
            Startline = startline;
            Classes = Helper.GetAllClasses(code,Startline);
            Code = Helper.ReplaceRegex(code,RegexString.classWithModifiers);
            Name = Helper.ReplaceRegex(head,RegexString.namespacePartial);
            this.partial = partial;
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
