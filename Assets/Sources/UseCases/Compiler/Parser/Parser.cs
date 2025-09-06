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

            SkipReturn();
            while (CurrentTokenType != TokenType.EOF)
            {
                statements.Add(ParseStatement());

                SkipReturn();
            }
        }
        public List<StatementNode> GetParsedStatements()
        {
            return statements;
        }

        #region 補助メソッド

        void Consume()
        {
            if (CurrentTokenType == TokenType.EOF)
                throw new System.InvalidOperationException("Parser : EOFから先に進めようとしています");

            currentTokenIndex++;

            if (tokenArray.Length <= currentTokenIndex)
                throw new System.IndexOutOfRangeException("Parser : 範囲外のConsumeが行われました");
        }
        ExpressionNode ConsumeWithGenerate()
        {
            ExpressionNode retval;
            try
            {
                retval = CurrentTokenType switch
                {
                    TokenType.Identifier => ASTFactory.IdentifierNode(CurrentToken),
                    TokenType.NumberLiteral => ASTFactory.NumberLiteralNode(CurrentToken),
                    TokenType.True => ASTFactory.TrueLiteralNode(CurrentToken),
                    TokenType.False => ASTFactory.FalseLiteralNode(CurrentToken),
                    _ => throw new System.NotSupportedException("Parser.ConsumeWithGenerate() : 設定されていないTokenTypeです")
                };
            }
            catch (System.OverflowException)
            {
                return AsUnknown("値が大きすぎます");
            }

            Consume();

            return retval;
        }

        /// <summary>
        /// 改行トークンをスキップします
        /// </summary>
        private void SkipReturn()
        {
            while (CurrentTokenType == TokenType.Return)
                Consume();
        }
        #endregion
    }
}
