using System.Collections.Generic;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// �\����͂����܂�
    /// �󂯎�����g�[�N���񂩂�\����֕ϊ����A���̍ۂɕs���ȏ���������Ό��o���܂�
    /// </summary>
    /*
        public:
            void Parse();
            List<StatementNode> GetParsedStatements();
     */
    public class Parser
    {
        private readonly Token[] tokenArray;
        private int currentTokenIndex;

        private List<StatementNode> statements;

        private Token CurrentToken => tokenArray[currentTokenIndex];
        private TokenType CurrentTokenType => CurrentToken.TokenType;

        public Parser(Token[] tokenArray)
        {
            this.tokenArray = tokenArray;
            currentTokenIndex = 0;
        }

        /// <summary>
        /// �\����͏������s�����\�b�h�ł�
        /// </summary>
        public void Parse()
        {
            statements = new();
            while (CurrentTokenType != TokenType.EOF)
            {
                statements.Add(ParseStatement());
            }
        }
        public List<StatementNode> GetParsedStatements()
        {
            return statements;
        }

        #region �⏕���\�b�h

        void Consume()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : �͈͊O��Consume���s���܂���");

            if (tokenArray[currentTokenIndex - 1].TokenType == TokenType.EOF)
                throw new System.InvalidOperationException("Parser : EOF�����ɐi�߂悤�Ƃ��Ă��܂�");
        }
        ExpressionNode ConsumeWithGenerate()
        {
            ExpressionNode retval = CurrentTokenType switch
            {
                TokenType.Identifier => new IdentifierNode(CurrentToken.Value),
                TokenType.NumberLiteral => new NumberLiteralNode(int.Parse(CurrentToken.Value)),
                _ => null,
            };

            Consume();

            return retval;
        }

        /// <summary>
        /// UnknownNode��Ԃ��܂�
        /// </summary>
        /// <returns></returns>
        private UnknownExpressionNode AsUnknown()
        {
            return new UnknownExpressionNode(CurrentToken.Value);
        }

        /// <summary>
        /// �g�[�N�����ǂ݂��܂�
        /// </summary>
        /// <param name="offset">�ǂꂾ�����ǂނ̂��w�肵�܂��B0����currentToken</param>
        private Token Peek(int offset)
        {
            int returnTokenIndex = currentTokenIndex + offset;
            if (tokenArray.Length < returnTokenIndex)
            {
                throw new System.IndexOutOfRangeException("�z��O�̃g�[�N�����Q�Ƃ��悤�Ƃ��Ă��܂�");
            }
            
            return tokenArray[returnTokenIndex];
        }
        #endregion

        #region AST - Expression

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

        #endregion

        #region AST - Statement

        /*
            �G���g���|�C���g : ParseStatement()
            �\������͂��Ĉ��StatementNode��Ԃ��܂�
         */

        private StatementNode ParseStatement()
        {
            if (CurrentTokenType == TokenType.TypeStandard || CurrentTokenType == TokenType.TypeOther)
            {
                return ParseVariableDeclarationStatement();
            }
            else
            {
                return ParseUnknownStatement();
            }
        }
        private StatementNode ParseVariableDeclarationStatement()
        {
            int startTokenIndex = currentTokenIndex;
            UnknownStatementNode Unknown()
            {
                currentTokenIndex = startTokenIndex;
                return ParseUnknownStatement();
            }

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

            // =
            if (CurrentTokenType == TokenType.Equals)
            {
                Consume();
            }
            else
            {
                return Unknown();
            }

            // cemicolon or init
            if (CurrentTokenType == TokenType.SemiColon)
            {
                Consume();
                return new VariableDeclarationStatementNode(typeNode, identifierNode);
            }
            else
            {
                // Expression
                ExpressionNode expressionNode = ParseExpression();

                // cemicolon
                if (CurrentTokenType == TokenType.SemiColon)
                    Consume();
                else
                    return Unknown();

                return new VariableDeclarationStatementNode(typeNode, identifierNode, expressionNode);
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

        #endregion
    }
}
