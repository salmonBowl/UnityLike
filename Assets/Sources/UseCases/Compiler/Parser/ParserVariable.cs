using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        private List<ExpressionNode> ParseArgumentList(out List<Token> commas)
        {
            List<ExpressionNode> arguments = new();
            commas = new();

            if (CurrentTokenType == TokenType.RightParen)
            {
                // ˆø”‚È‚µ‚Ìê‡
                return arguments;
            }

            arguments.Add(ParseExpression());
            while (CurrentTokenType == TokenType.Comma)
            {
                commas.Add(CurrentToken);
                Consume();
                
                arguments.Add(ParseExpression());
            }

            return arguments;
        }
    }
}
