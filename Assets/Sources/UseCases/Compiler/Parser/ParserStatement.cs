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
                    TokenType.TypePrimitive => ParseVariableDeclarationStatement(),
                    TokenType.TypeOther => ParseVariableDeclarationStatement(),
                    TokenType.Identifier => ParseAssignmentStatement(),
                    TokenType.If => ParseIfStatement(),
                    TokenType.While => ParseWhileStatement(),
                    TokenType.LeftBrace => ParseScope(),
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
            ColoredToken semicolon;

            if (CurrentTokenType == TokenType.SemiColon)
            {
                semicolon = u.Semicolon();
                return new VariableDeclarationStatementNode(typeNode, identifierNode, semicolon);
            }

            // 宣言時初期化
            ColoredToken equals =
                u.Equals();
            ExpressionNode expressionNode =
                u.Expression();
            semicolon =
                u.Semicolon();

            return new VariableDeclarationStatementNode
                (typeNode, identifierNode, equals, expressionNode, semicolon);
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

            return new AssignmentStatementNode(variableNode, equals, expressionNode, semicolon);
        }
        private IfStatementNode ParseIfStatement()
        {
            Usecase u = new(this);

            // if式

            ColoredToken @if =
                u.If();
            ColoredToken leftParen =
                u.LeftParen();
            ExpressionNode condition =
                u.Expression();
            ColoredToken rightParen =
                u.RightParen();

            if (CurrentTokenType == TokenType.Return)
                Consume();

            StatementNode thenStatement = ParseStatement();

            if (CurrentTokenType != TokenType.Else)
                return new IfStatementNode(@if, leftParen, condition, rightParen, thenStatement);

            if (CurrentTokenType == TokenType.Return)
                Consume();

            ColoredToken @else =
                u.Else();

            if (CurrentTokenType == TokenType.Return)
                Consume();

            StatementNode elseStatement = ParseStatement();

            return new IfStatementNode(@if, leftParen, condition, rightParen, thenStatement, @else, elseStatement);
        }
        private IfStatementNode ParseWhileStatement()
        {
            Usecase u = new(this);

            // while式

            ColoredToken @while =
                u.While();
            ColoredToken leftParen =
                u.LeftParen();

            if (CurrentTokenType == TokenType.RightParen)
                throw new SyntaxErrorException("値が必要です");

            ExpressionNode condition =
                u.Expression();
            ColoredToken rightParen =
                u.RightParen();

            StatementNode statement = ParseStatement();

            return new IfStatementNode(@while, leftParen, condition, rightParen, statement);
        }
        private ScopeNode ParseScope()
        {
            Usecase u = new(this);

            // スコープ

            ColoredToken leftBrace =
                u.LeftBrace();

            List<StatementNode> statements = new();

            SkipReturn();
            while (CurrentTokenType is not TokenType.EOF and not TokenType.RightBrace)
            {
                statements.Add(ParseStatement());

                SkipReturn();
            }

            ColoredToken rightBrace =
                u.RightBrace();

            return new ScopeNode(leftBrace, statements, rightBrace);
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
