using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// 構文木からシンタックスハイライト化されたテキストを生成します
    /// </summary>
    public class RebuilderFromAST : SourceCodeRebuilder, ISourceCodeRebuildFromColoredToken
    {
        private readonly List<StatementNode> statements;
        private int currentLine;
        private int currentColumn;
        public GenerateTokenList GenerateTokenList { get; }

        public RebuilderFromAST(List<StatementNode> statements)
        {
            this.statements = statements;
            GenerateTokenList = new GenerateTokenList();
        }

        /// <summary>
        /// ソースコードの再生成を開始します。この関数が処理の起点となります。
        /// </summary>
        public override void RebuildExecute()
        {
            currentLine = 1;
            currentColumn = 1;

            GenerateTokenList.ClearList();

            foreach(var statement in statements)
            {
                statement.ColoredTokenScan(this);
            }
        }

        /// <summary>
        /// 新しいトークンを読み込んでテキストを更新します。これは構文木のノードから呼び出します。
        /// </summary>
        /// <param name="cToken"></param>
        public void ImportColoredToken(ColoredToken cToken)
        {
            GenerateTokenList.Add(cToken);

            // 1. 行が合うまで改行します
            while (currentLine != cToken.LineCount)
            {
                SourceCodeReturn();
            }

            // 2. 空白を補完します
            FillSpaces(cToken.ColumnCount);

            // 3. トークンの内容を書き込みます
            AppendTextToToken(cToken);
        }

        /*
            以下補助メソッド
         */

        private void SourceCodeReturn()
        {
            // TokenConstantsで任意に指定した改行文字
            string returnSyntaxColor = TokenConstants.syntaxHighlightColors[TokenType.Return];

            // 改行文字と\nを追加します
            richSourceCode.Append($"<color={returnSyntaxColor}>{TokenConstants.returnText}</color>\n");

            currentLine++;
            currentColumn = 1;
        }
        private void FillSpaces(int cTokenColumnCount)
        {
            // 何文字補完すればよいか
            int spacesRequied = cTokenColumnCount - currentColumn;

            // 空白を補完します
            richSourceCode.Append(' ', spacesRequied);

            currentColumn += spacesRequied;
        }
        private void AppendTextToToken(ColoredToken cToken)
        {
            // トークンの内容を書き込みます
            richSourceCode.Append($"<color={cToken.ColorCode}>");
            richSourceCode.Append(cToken.Value);
            richSourceCode.Append("</color>");

            currentColumn += cToken.Value.Length;
        }
    }
}