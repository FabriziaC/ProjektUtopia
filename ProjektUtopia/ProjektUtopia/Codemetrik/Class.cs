using System.Collections.Generic;

namespace ProjektUtopia
{
  public class Class
  {
    public string Name;
    public AccessModifiers AccessModifiers;
    public Modifiers Modifiers;
    public List<Propertie> Properties;
    public List<Method> MethodLists;
    public List<string> Errors;

    /// <summary>
    /// Empty Konstruktor
    /// </summary>
    public Class()
    {
            Properties = new List<Propertie>();
            MethodLists = new List<Method>();
            Errors = new List<string>();
    }

    /// <summary>
    /// Konstruktor responsible for filling the class by it self
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public Class(string name, string code)
    {

    }

    public Class(string name, AccessModifiers accessModifiers, Modifiers modifiers, List<Propertie> properties,List<Method> methods)
    {
            Name = name;
            AccessModifiers = accessModifiers;
            Modifiers = modifiers;
            Properties = properties;
            MethodLists = methods;
    }
    public void AddNewPropetie(Propertie propertie)
    {
            Properties.Add(propertie);
    }
    public void AddNewMethode(Method method)
    {
            MethodLists.Add(method);
    }
    public void AddNewMethods(List<Method> methods)
        {
            MethodLists.AddRange(methods);
        }


  }
}
