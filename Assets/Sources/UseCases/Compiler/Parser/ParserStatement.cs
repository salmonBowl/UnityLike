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

            return CurrentTokenType switch
            {
                TokenType.TypeStandard => ParseVariableDeclarationStatement(),
                TokenType.Identifier => ParseAssignmentStatement(),
                _ => ParseUnknownStatement()
            };
        }
        private StatementNode ParseVariableDeclarationStatement()
        {
            int startTokenIndex = currentTokenIndex;
            Usecase u = new(this);

            // 関数に対応する書式を順番に読み込んでいく処理
            // SyntaxErrorExceptionをu内で使って、間違った文法ならUnknownStatementNodeを返すようにします
            try
            {
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
            catch
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement();
            }
            /*
             以前のコード
            // ローカル関数Unknownを定義
            int startTokenIndex = currentTokenIndex;
            UnknownStatementNode Unknown()
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement();
            }*/
            /*
            // Type
            TypeNode typeNode;
            if (CurrentTokenType == TokenType.TypeStandard)
            {
                typeNode = new(CurrentToken.Value);
                Consume();
            }
            else
            {
                return Unknown();
            }

            // Identifier
            IdentifierNode identifierNode;
            if (CurrentTokenType == TokenType.Identifier)
            {
                identifierNode = new(CurrentToken.Value);
                Consume();
            }
            else
            {
                return Unknown();
            }

            // ;
            if (CurrentTokenType == TokenType.SemiColon)
            {
                Consume();
                return new VariableDeclarationStatementNode(typeNode, identifierNode);
            }

            // セミコロンがなければ初期化を解析

            // =
            if (CurrentTokenType == TokenType.Equals)
            {
                Consume();
            }
            else
            {
                return Unknown();
            }

            // Expression
            ExpressionNode expressionNode = ParseExpression();

            // ;
            if (CurrentTokenType == TokenType.SemiColon)
            {
                Consume();
                return new VariableDeclarationStatementNode(typeNode, identifierNode, expressionNode);
            }

            return Unknown();*/
        }
        private StatementNode ParseAssignmentStatement()
        {
            int startTokenIndex = currentTokenIndex;
            Usecase u = new(this);

            try
            {
                TypeNode typeNode =
                    u.Type();
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
            catch
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement();
            }
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