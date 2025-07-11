using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// 構文解析をします
    /// 受け取ったトークン列から構文列へ変換し、その際に不明な書式があれば検出します
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
        /// 構文解析処理を行うメソッドです
        /// </summary>
        public void ParseExcute()
        {

        }

        /// <summary>
        /// currentTokenがexpectedTypeと一致するか確認し、一致すれば次のトークンへ進めます
        /// </summary>
        void Consume()
        {

        }

        /// <summary>
        /// トークンを先読みします
        /// </summary>
        /// <param name="offset">どれだけ先を読むのか指定します。0だとcurrentToken</param>
        private Token Peek(int offset)
        {
            int returnTokenIndex = currentTokenIndex + offset;
            if (tokenArray.Length < returnTokenIndex)
            {
                throw new System.IndexOutOfRangeException("配列外のトークンを参照しようとしています");
            }
            
            return tokenArray[returnTokenIndex];
        }
    }
}
