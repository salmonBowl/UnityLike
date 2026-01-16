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
                    TokenType.Identifier => ParseStatementByExpressionType(),
                    TokenType.TypePrimitive => ParseDeclarationOrStaticCall(),
                    TokenType.TypeOther => ParseDeclarationOrStaticCall(),
                    TokenType.If => ParseIfStatement(),
                    TokenType.While => ParseWhileStatement(),
                    TokenType.LeftBrace => ParseScope(),
                    _ => throw new SyntaxErrorException("文法が正しくありません")
                };
            }
            catch (SyntaxErrorException e)
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement(e.Message);
            }
        }
        private StatementNode ParseStatementByExpressionType()
        {
            Usecase u = new(this);
            // 正しい書式を順番に読み込んでいく処理です
            // 書式が間違っているとuの関数内でSyntaxErrorExceptionが出されます

            // 最初のExpressionNodeを解析します
            ExpressionNode expression = ParseMemberAccessExpression();

            // MemberFunction
            if (expression is MemberFunctionNode functionCallNode)
            {
                ColoredToken semicolon =
                    u.Semicolon();
                return new FunctionStatementNode(functionCallNode, semicolon);
            }
            // Assignment
            else if (expression is VariableNode variable)
            {
                ColoredToken equals =
                    u.Equals();
                ExpressionNode valueExpression =
                    u.Expression();
                ColoredToken semicolon =
                    u.Semicolon();

                return new AssignmentStatementNode(variable, equals, valueExpression, semicolon);
            }

            throw new SyntaxErrorException("文法が正しくありません");
        }
        private StatementNode ParseDeclarationOrStaticCall()
        {
            // 最初のトークンを記録
            Token typeToken = CurrentToken;
            Consume();

            // staticFunction
            if (CurrentTokenType == TokenType.Dot)
            {
                return ParseStaticFunctionStatement(ASTFactory.TypeNode(typeToken));
            }
            // declaration
            else if (CurrentTokenType == TokenType.Identifier)
            {
                return ParseVariableDeclarationStatement(ASTFactory.TypeNode(typeToken));
            }

            throw new SyntaxErrorException("文法が正しくありません");
        }
        private StatementNode ParseVariableDeclarationStatement(TypeNode typeNode)
        {
            Usecase u = new(this);

            // 変数宣言

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
        private FunctionStatementNode ParseStaticFunctionStatement(TypeNode @class)
        {
            Usecase u = new(this);

            ColoredToken dot =
                u.Dot();
            ColoredToken member =
                u.Member();
            ColoredToken leftParen =
                u.LeftParen();

            var arguments = ParseArgumentList(out var commas);

            ColoredToken rightParen =
                u.RightParen();

            MemberFunctionNode functionNode = ASTFactory.MemberFunctionNode
                (@class, dot, member, leftParen, arguments, commas, rightParen);
            ColoredToken semicolon =
                u.Semicolon();

            return new FunctionStatementNode(functionNode, semicolon);
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

            if (CurrentTokenType == TokenType.Return)
                Consume();

            if (CurrentTokenType != TokenType.Else)
                return new IfStatementNode(@if, leftParen, condition, rightParen, thenStatement);

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
