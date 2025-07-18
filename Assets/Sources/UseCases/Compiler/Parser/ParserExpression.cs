using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    partial class Parser
    {
        /// <summary>
        /// UnknownExpressionNode��Ԃ��܂�
        /// </summary>
        /// <returns></returns>
        private UnknownExpressionNode AsUnknown()
        {
            return new UnknownExpressionNode(CurrentToken.Value);
        }

        // �\���؂��ċA�I�Ȋ֐��Ăяo���ɂ��\�����Ă����܂�
        // �G���g���|�C���g : ParseExpression();
        /*
         *  �� : 5 * (1 + 1)
         *      
         *      ParseStartExpression();
         *      ...
         *      ParseAdditiveExpression();
         *      ParseMultipleExpression(); �� BinaryExpressionNode(leftExpression, *, ParseStartExpression()) �𐶐�
         *      leftExpression = ParseUnaryExpression();
         *      ParsePrimaryExpression(); �� NumberLiteralNode(5) �𐶐�
         *      
         *      ParseStartExpression();
         *      ParseParenExpression(); �� ParenNode(content) �𐶐�
         *      content = ParseStartExpression();
         *      ...
         *      ParseAdditiveExpression(); �� BynaryExpressionNode(leftExpression, + , ParseStartExpression()) �𐶐�
         *      leftExpression = ParseUnaryExpression();
         *      ParsePrimaryExpression() �� NumberLiteralNode(1) �𐶐�
         *      
         *      ParseStartExpression();
         *      ...
         *      ParsePrimaryExpression(); �� NumberLiteral(1) �𐶐�
         *      
         *      ��
         *      
         *      Bynary(Number(5), *, Paren(Binary(Number(1), + ,Number(1)))) �Ƃ����`�̍\���؂��A
         *      �ŏ���ParseStartExpression�̖߂�l�Ƃ��ĕԂ����
         */

        /*
            ���ʎq�V�X�e���𖢎���
            TokenType.TypeStandard�ŉ��u�����Ă��܂�
         */

        /// <summary>
        /// �ċA�Ăяo���̊J�n�n�_
        /// currentToken����悪�ǂ�ȍ\���ɂȂ��Ă���̂����ċA�I�ɉ�͂��Ă����܂�
        /// </summary>
        private ExpressionNode ParseExpression()
        {
            // �ł��D�揇�ʂ̒Ⴂ���Z�q���Ăяo���܂�

            return ParseAdditiveExpression();
        }

        /// <summary>
        /// �ċA�Ăяo���̏I�[�n�_
        /// ���e�����⎯�ʎq�ȂǁAcurrentToken�ɑ΂���\���؂̍\���������Ō��肳��܂�
        /// </summary>
        private ExpressionNode ParsePrimaryExpression()
        {
            return CurrentTokenType switch
            {
                TokenType.Identifier => ConsumeWithGenerate(),
                TokenType.NumberLiteral => ConsumeWithGenerate(),
                TokenType.LeftParen => ParseParenExpression(),
                _ => AsUnknown()
            };
        }

        private ExpressionNode ParseParenExpression()
        {
            if (CurrentTokenType == TokenType.LeftParen)
                Consume();
            else
                return AsUnknown();

            ExpressionNode content = ParseExpression();

            if (CurrentTokenType == TokenType.RightParen)
                Consume();
            else
                return AsUnknown();

            return new ParenNode(content);
        }
        private ExpressionNode ParseUnaryExpression()
        {
            if (CurrentTokenType == TokenType.Minus)
            {
                Consume();
                return new UnaryExpressionNode(TokenType.Minus, ParsePrimaryExpression());
            }
            else
            {
                return ParsePrimaryExpression();
            }
        }
        private ExpressionNode ParseMultitiveExpression()
        {
            ExpressionNode leftExpression = ParseUnaryExpression();

            if (CurrentTokenType == TokenType.Multiply)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Multiply, ParseExpression());
            }
            else if (CurrentTokenType == TokenType.Divide)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Divide, ParseExpression());
            }
            else
            {
                return leftExpression;
            }
        }
        private ExpressionNode ParseAdditiveExpression()
        {
            ExpressionNode leftExpression = ParseMultitiveExpression();

            if (CurrentTokenType == TokenType.Plus)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Plus, ParseExpression());
            }
            else if (CurrentTokenType == TokenType.Minus)
            {
                Consume();
                return new BinaryExpressionNode(leftExpression, TokenType.Minus, ParsePrimaryExpression());
            }
            else
            {
                return leftExpression;
            }
        }
    }
}