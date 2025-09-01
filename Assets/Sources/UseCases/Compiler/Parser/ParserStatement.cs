using System.Collections.Generic;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class Parser
    {
        /*
            エントリポイント : ParseStatement()
            構文を解析して一つのStatementNodeを返します
         */
        /*
            構文解析をUseCaseで行いたい
         */

        private StatementNode ParseStatement()
        {
            // 最初のTokenTypeを見てどの種類の解析を行うか決定します

            // try-catchという方法で間違った文法ならUnknownStatementNodeを返すようにします
            int startTokenIndex = currentTokenIndex;
            try
            {
                return CurrentTokenType switch
                {
                    TokenType.TypeStandard => ParseVariableDeclarationStatement(),
                    TokenType.Identifier => ParseAssignmentStatement(),
                    _ => ParseUnknownStatement("文法が正しくありません")
                };
            }
            catch (SyntaxErrorException e)
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement(e.Message);
            }
        }
        private StatementNode ParseVariableDeclarationStatement()
        {
            Usecase u = new(this);

            // 正しい書式を順番に読み込んでいく処理です
            // 書式が間違っているとuの関数内でSyntaxErrorExceptionが出されます

            // 変数宣言

            TypeNode typeNode =
                u.Type();
            IdentifierNode identifierNode =
                u.Identifier();
            ColoredToken semicolon =
                u.Semicolon();

            if (semicolon != null)
                return new VariableDeclarationStatementNode(typeNode, identifierNode, semicolon);

            // 宣言時初期化
            ColoredToken equals =
                u.Equals();
            ExpressionNode expressionNode =
                u.Expression();
            semicolon =
                u.Semicolon();

            if (semicolon != null)
                return new VariableDeclarationStatementNode
                    (typeNode, identifierNode, equals, expressionNode, semicolon);

            throw new SyntaxErrorException(";が必要です");
        }
        private StatementNode ParseAssignmentStatement()
        {
            Usecase u = new(this);

            // 代入式

            VariableNode variableNode =
                u.Variable();
            ColoredToken equals =
                u.Equals();
            ExpressionNode expressionNode =
                u.Expression();
            ColoredToken semicolon =
                u.Semicolon();

            if (semicolon != null)
                return new AssignmentStatementNode(variableNode, equals, expressionNode, semicolon);

            throw new SyntaxErrorException(";が必要です");
        }
        private UnknownStatementNode ParseUnknownStatement(string errorMessage)
        {
            List<Token> tokens = new();
            while (true)
            {
                if (CurrentTokenType == TokenType.EOF)
                {
                    break;
                }
                if (CurrentTokenType == TokenType.Return)
                {
                    Consume();
                    continue;
                }
                if (CurrentTokenType == TokenType.SemiColon)
                {
                    tokens.Add(CurrentToken);
                    Consume();
                    break;
                }

                tokens.Add(CurrentToken);
                Consume();
            }
            return new UnknownStatementNode(tokens.ToArray(), errorMessage);
        }
    }
}
