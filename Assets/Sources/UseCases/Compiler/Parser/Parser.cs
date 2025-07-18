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
    public partial class Parser
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

                while (CurrentTokenType == TokenType.Return)
                    Consume();
            }
        }
        public List<StatementNode> GetParsedStatements()
        {
            return statements;
        }

        #region �⏕���\�b�h

        void Consume()
        {
            if (CurrentTokenType == TokenType.EOF)
                throw new System.InvalidOperationException("Parser : EOF�����ɐi�߂悤�Ƃ��Ă��܂�");

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
                _ => throw new System.NotSupportedException("Parser.ConsumeWithGenerate() : �ݒ肳��Ă��Ȃ�TokenType�ł�")
            };

            Consume();

            return retval;
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
    }
}
