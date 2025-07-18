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

            // try-catch�Ƃ������@�ŊԈ�������@�Ȃ�UnknownStatementNode��Ԃ��悤�ɂ��܂�
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

            // ���������������Ԃɓǂݍ���ł��������ł�
            // �������Ԉ���Ă����u�̊֐�����SyntaxErrorException���o����܂�

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
        private StatementNode ParseAssignmentStatement()
        {
            Usecase u = new(this);

            // �����

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
