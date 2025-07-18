using System.Collections.Generic;
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
        /// 構文解析処理を行うメソッドです
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

        #region 補助メソッド

        void Consume()
        {
            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : 範囲外のConsumeが行われました");

            if (tokenArray[currentTokenIndex - 1].TokenType == TokenType.EOF)
                throw new System.InvalidOperationException("Parser : EOFから先に進めようとしています");
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
        #endregion
    }
}
