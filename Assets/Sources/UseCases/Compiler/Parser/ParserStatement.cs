using System.Collections.Generic;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
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
                    _ => ParseUnknownStatement()
                };
            }
            catch
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement();
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

            if (u.Cemicolon())
                return new VariableDeclarationStatementNode(typeNode, identifierNode);

            // 宣言時初期化
            _ =
                u.Equals();
            ExpressionNode expressionNode =
                u.Expression();

            if (u.Cemicolon())
                return new VariableDeclarationStatementNode(typeNode, identifierNode, expressionNode);

            throw new SyntaxErrorException();
        }
        private StatementNode ParseAssignmentStatement()
        {
            Usecase u = new(this);

            // 代入式

            IdentifierNode identifierNode =
                u.Identifier();
            _ =
                u.Equals();
            ExpressionNode expressionNode =
                u.Expression();

            if (u.Cemicolon())
                return new AsignmentStatementNode(identifierNode, expressionNode);

            throw new SyntaxErrorException();
        }
        private UnknownStatementNode ParseUnknownStatement()
        {
            List<Token> tokens = new();
            while (true)
            {
                if (CurrentTokenType == TokenType.EOF)
                {
                    break;
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
            return new UnknownStatementNode(tokens.ToArray());
        }
    }
}
