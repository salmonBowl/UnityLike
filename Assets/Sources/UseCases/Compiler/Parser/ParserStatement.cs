using System.Collections.Generic;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
    {
        /*
            �G���g���|�C���g : ParseStatement()
            �\������͂��Ĉ��StatementNode��Ԃ��܂�
         */
        /*
            �\����͂�UseCase�ōs������
         */

        private StatementNode ParseStatement()
        {
            // �ŏ���TokenType�����Ăǂ̎�ނ̉�͂��s�������肵�܂�

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

            // �֐��ɑΉ����鏑�������Ԃɓǂݍ���ł�������
            // SyntaxErrorException��u���Ŏg���āA�Ԉ�������@�Ȃ�UnknownStatementNode��Ԃ��悤�ɂ��܂�
            try
            {
                // �ϐ��錾

                TypeNode typeNode = 
                    u.Type();
                IdentifierNode identifierNode = 
                    u.Identifier();

                if (u.Cemicolon())
                    return new VariableDeclarationStatementNode(typeNode, identifierNode);

                // �錾��������
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
             �ȑO�̃R�[�h
            // ���[�J���֐�Unknown���`
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

            // �Z�~�R�������Ȃ���Ώ����������

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