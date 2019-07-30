namespace ProjektUtopia.Codemetrik.Classes
{
    public class txtComments : CodeAsText
    {
        public CommentNodeType CommentType { get; set; }

        public override void EvaluateCode()
        {
            throw new System.NotImplementedException();
        }

        public override void InitialiseFromCode(string code, int startline = 0)
        {
            //throw new System.NotImplementedException();
        }
    }
}