namespace ProjektUtopia
{
  public class Method
  {
<<<<<<< Updated upstream
=======
    public string Name { get; set; }
    public AccessModifiers Access_Modifiers { get; set; }
    public Modifiers Modifiers { get; set; }
    public string ReturnValue { get; set; } 
    public string Content { get; set; }

    public Method()
    {

    }


        public Method(string name, AccessModifiers access,Modifiers modifiers, string returnValue)
        {
            Name = name;
            Access_Modifiers = access;
            Modifiers = modifiers;
            ReturnValue = returnValue;
        }
>>>>>>> Stashed changes
  }
}
