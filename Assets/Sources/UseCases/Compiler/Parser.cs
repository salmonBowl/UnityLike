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

        public Parser(Token[] tokenArray)
        {
            this.tokenArray = tokenArray;
            currentTokenIndex = 0;
        }

        /// <summary>
        /// �\����͏������s�����\�b�h�ł�
        /// </summary>
        public void ParseExcute()
        {

        }

        /// <summary>
        /// currentToken��expectedType�ƈ�v���邩�m�F���A��v����Ύ��̃g�[�N���֐i�߂܂�
        /// </summary>
        void Consume()
        {

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
    }
}
