using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        private ExpressionNode ParseIdentifier()
        {
            VariableNode parent = ParseVariable();

            if (CurrentTokenType == TokenType.Dot)
            {
                return ParseMemberFunctionNode(parent);
            }

            return parent;
        }
        private VariableNode ParseVariable()
        {
            Token identifier = CurrentToken;
            if (CurrentTokenType == TokenType.Identifier)
                Consume();
            else
                throw new System.InvalidProgramException("不明な文字列です");

            return MemberAccess(ASTFactory.IdentifierNode(identifier));
        }
        private VariableNode MemberAccess(VariableNode parent)
        {
            int startTokenIndex = currentTokenIndex; // メンバーが変数ではなく関数だった場合戻ってくる必要があります

            Token dot = CurrentToken;
            if (CurrentTokenType == TokenType.Dot)
                Consume();
            else
                return parent; // .がなければメンバーアクセスの再帰取得を終了します

            Token member = CurrentToken;
            if (CurrentTokenType == TokenType.Identifier)
                Consume();
            else
                throw new SyntaxErrorException("無効なメンバー名です");

            if (CurrentTokenType == TokenType.LeftParen)
            {
                currentTokenIndex = startTokenIndex;
                return parent;
                /*
                    メンバーが関数だった場合、アクセスがなかった時と同じように、その親までの変数を返します
                    transform.Translate() => VariableNode(transform) => MemberFunction(VariableNode(transform))
                 */
            }
            else
            {
                return ASTFactory.MemberAccessNode(parent, dot, member);
            }
        }
        private MemberFunctionNode ParseMemberFunctionNode(VariableNode parent)
        {
            Token dot = CurrentToken;
            if (CurrentTokenType == TokenType.Dot)
                Consume();
            else
                throw new SyntaxErrorException("文法が正しくありません");

            Token member = CurrentToken;
            if (CurrentTokenType == TokenType.Identifier)
                Consume();
            else
                throw new SyntaxErrorException("無効なメンバー名です");

            Token leftParen = CurrentToken;
            Consume();

            List<ExpressionNode> arguments = new();
            List<Token> commas = new();

            Token rightParen = CurrentToken;
            if (CurrentTokenType == TokenType.RightParen)
            {
                Consume();
                return ASTFactory.MemberFunctionNode(parent, dot, member, leftParen, arguments, commas, rightParen);
            }

            ExpressionNode firstArg = ParseExpression();
            arguments.Add(firstArg);

            while (true)
            {
                rightParen = CurrentToken;
                if (CurrentTokenType == TokenType.RightParen)
                {
                    Consume();
                    break;
                }

                Token comma = CurrentToken;
                if (CurrentTokenType == TokenType.Comma)
                    Consume();
                else
                    throw new SyntaxErrorException(",が必要です");
                commas.Add(comma);

                ExpressionNode arg = ParseExpression();
                arguments.Add(arg);
            }
            return ASTFactory.MemberFunctionNode(parent, dot, member, leftParen, arguments, commas, rightParen);
        }
    }
}
