namespace ProjektUtopia
{
  public enum AccessModifiers
  {
    Public,
    Protected,
    Internal,
    Private,
    PrivateInternal,
    PrivateSealed,
    None
  }

  public enum Modifiers
  {
    Abstract,
    Async,
    Const,
    Event,
    Extern,
    In,
    Out,
    Override,
    Readonly,
    Sealed,
    Static,
    Unsafe,
    Virtial,
    Volatile,
    None
  }

    /// <summary>
    /// XML for Documentation, Regular as in /* Single Or Multiline */ , Generic SingelLiners // 
    /// </summary>
    public enum CommentNodeType
    {
        Xml,Regular,Generic

    }
}
