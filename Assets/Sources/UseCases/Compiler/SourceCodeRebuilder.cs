using System;
using System.Text;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public class SourceCodeRebuilder
    {
        private readonly Token[] tokenArray;
        private readonly StringBuilder sourceCode;
        private readonly StringBuilder richSourceCode; //メンバー関数しか使わないためreadonly

        public SourceCodeRebuilder(Token[] tokenArray)
        {
            this.tokenArray = tokenArray;
            sourceCode = new();
            richSourceCode = new();
        }

        public void RebuildExecute()
        {
            int currentLine = 1;
            int currentColumn = 1;

            foreach (Token currentToken in tokenArray)
            {
                if (currentToken.TokenType == TokenType.EOF)
                {
                    break;
                }

                if (currentToken.TokenType == TokenType.Return)
                {
                    // 改行トークンを使って改行を判定します
                    // 改行トークン以外による不正な改行を次のブロックで判定します

                    sourceCode.Append('\n');
                    richSourceCode.Append("<color=\"blue\">\\n</color>\n");
                }
                else if (currentToken.LineCount != currentLine)
                {
                    // 不正な改行を判定します
                    // どのExeptionを使うのか分からなかった
                    throw new Exception("SourceCodeRebuilder : 改行トークンが検出されていない不正な改行を検出しました");
                }

                // 空白を補完します
                int spaceRequiedCount = currentToken.ColumnCount - currentColumn;
                sourceCode.Append(' ', spaceRequiedCount);
                richSourceCode.Append(' ', spaceRequiedCount);

                // トークンを書き込みます
                sourceCode.Append(currentToken.Value);
            }

            return;
        }

        /// <summary>
        /// 再構成したソースコードを取得します
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetSourceCodeRebuild()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return sourceCode.ToString();
        }

        /// <summary>
        /// リッチテキスト化されたソースコードを取得します
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetRichSourceCode()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return richSourceCode.ToString();
        }
    }
}