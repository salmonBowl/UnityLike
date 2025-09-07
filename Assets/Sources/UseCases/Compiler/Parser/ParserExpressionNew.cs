using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        private ExpressionNode ParseNewExpression()
        {
            Token newToken = CurrentToken;
            if (CurrentTokenType == TokenType.New)
                Consume();
            else
                return AsUnknown();

            Token typeToken = CurrentToken;
            if (CurrentTokenType == TokenType.TypeOther)
                Consume();
            else if (CurrentTokenType == TokenType.TypePrimitive)
                throw new SyntaxErrorException("この型はnew式に使えません");
            else if (CurrentTokenType == TokenType.Identifier)
                throw new SyntaxErrorException($"'{CurrentToken.Value}'は型名ではありません");
            else
                throw new SyntaxErrorException("new式が正しくありません");

            Token leftParen = CurrentToken;
            if (CurrentTokenType == TokenType.LeftParen)
                Consume();
            else
                throw new SyntaxErrorException("()が必要です");

            var arguments = ParseArgumentList(out var commas);

            Token rightParen = CurrentToken;
            if (CurrentTokenType == TokenType.RightParen)
                Consume();
            else
                throw new SyntaxErrorException(")が必要です");

            return ASTFactory.NewNode(newToken, typeToken, leftParen, arguments, commas, rightParen);
        }
    }
}
