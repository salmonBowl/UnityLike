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

        #region �⏕���\�b�h
        /// <summary>
        /// �\����͏������s�����\�b�h�ł�
        /// </summary>
        public void Parse()
        {

        }
        void Consume()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : �͈͊O��Consume���s���܂���");
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
        private Node ParseExpression()
        {
            // �ł��D�揇�ʂ̒Ⴂ���Z�q���Ăяo���܂�

            return ;
        }

        /// <summary>
        /// �ċA�Ăяo���̏I�[�n�_
        /// ���e�����⎯�ʎq�ȂǁAcurrentToken�ɑ΂���\���؂̍\���������Ō��肳��܂�
        /// </summary>
        private Node ParsePrimaryExpression()
        {
            return CurrentTokenType switch
            {
                TokenType.Identifier => new IdentifierNode(CurrentToken.Value),
                TokenType.NumberLiteral => new NumberLiteralNode(int.Parse(CurrentToken.Value)),
                TokenType.LeftParen => new ,
                _ => new UnknownNode()
            };
        }

        private Node ParseParenExpression()
        {
            if (CurrentTokenType == TokenType.LeftParen)
                Consume();
            else
                return new UnknownNode();
            Node  ParseExpression();
        }
        #endregion
    }
}
