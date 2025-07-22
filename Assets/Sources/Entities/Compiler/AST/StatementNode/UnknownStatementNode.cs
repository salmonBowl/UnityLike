
namespace UnityLike.Entities.Compiler
{
    public class UnknownStatementNode : StatementNode
    {
        public Token[] Tokens { get; }
        
        public UnknownStatementNode(Token[] tokens)
        {
            Tokens = tokens;
        }
        public override void LogThis()
        {
            foreach (var token in Tokens)
            {
                UnityEngine.Debug.Log(token.ToString());
            }
        }
    }
}