using System.Text;
using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public class SourceCodeRebuilder
    {
        private readonly Token[] tokenArray;
        private StringBuilder sourceCode;
        private StringBuilder richSourceCode;

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
                    // 改行トークンを使って

                    sourceCode.Append('\n');
                    richSourceCode.Append("<color=\"blue\">\\n</color>\n");
                }
                else if (currentToken.LineCount != currentLine)
                {

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
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GetSourceCodeRebuild()
        {
            if (sourceCode == null)
            {
                throw new System.InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return sourceCode.ToString();
        }

        /// <summary>
        /// リッチテキスト化されたソースコードを取得します
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GetRichSourceCode()
        {
            if (sourceCode == null)
            {
                throw new System.InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return richSourceCode.ToString();
        }
    }
}