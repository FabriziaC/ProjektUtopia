namespace ProjektUtopia
{
  public class Method
  {
    public string Name;
    public AccessModifiers AccessModifiers;
    public Modifiers Modifiers;
    public string RetrunValue;
    private string notFilteredOut;

    public Method()
    {

    }

    public Method(string name, AccessModifiers accessModifiers, Modifiers modifiers, string returnValue)
        {
            Name = name;
            AccessModifiers = accessModifiers;
            Modifiers = modifiers;
            RetrunValue = returnValue;



        }

  }
}
