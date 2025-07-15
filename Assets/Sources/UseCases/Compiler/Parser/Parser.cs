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
     */
    public class Parser
    {
        private readonly Token[] tokenArray;
        private int currentTokenIndex;

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

        }

        #region �⏕���\�b�h

        void Consume()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : �͈͊O��Consume���s���܂���");
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
        private UnknownNode AsUnknown()
        {
            return new UnknownNode(CurrentToken.Value);
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

        #region AST

        // �\���؂��ċA�I�Ȋ֐��Ăяo���ɂ��\�����Ă����܂�

        /// <summary>
        /// �ċA�Ăяo���̊J�n�n�_
        /// currentToken����悪�ǂ�ȍ\���ɂȂ��Ă���̂����ċA�I�ɉ�͂��Ă����܂�
        /// </summary>
        private ExpressionNode ParseStartExpression()
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

            ExpressionNode content = ParseStartExpression();

            if (CurrentTokenType == TokenType.RightParen)
                Consume();
            else
                return AsUnknown();

            return content;
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
                return new BinaryExpressionNode(leftExpression, TokenType.Multiply, ParsePrimaryExpression());
            else if (CurrentTokenType == TokenType.Divide)
                return new BinaryExpressionNode(leftExpression, TokenType.Divide, ParsePrimaryExpression());
            else
                return leftExpression;
        }
        private ExpressionNode ParseAdditiveExpression()
        {
            ExpressionNode leftExpression = ParseMultitiveExpression();

            if (CurrentTokenType == TokenType.Plus)
                return new BinaryExpressionNode(leftExpression, TokenType.Plus, ParsePrimaryExpression());
            else if (CurrentTokenType == TokenType.Minus)
                return new BinaryExpressionNode(leftExpression, TokenType.Minus, ParsePrimaryExpression());
            else
                return leftExpression;
        }

        #endregion
    }
}
