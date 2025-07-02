using System;
using System.Text;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /*
        SourceCodeRebuilder
            トークン列からソースコードを再構成するクラスです
            
            SourceCodeRebuilder(Token[])
            
            RebuildExecute()
            GetSourceCodeRebuild()
            GetRichSourceCode()
     */
    public class SourceCodeRebuilder
    {
        private readonly Token[] tokenArray;
        private readonly StringBuilder sourceCode;
        private readonly StringBuilder richSourceCode; //メンバー関数の.Appendしか使わないためreadonly

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
                //UnityEngine.Debug.Log("currentToken : " + currentToken);
                // 1. 空白を補完します
                int spaceRequiedCount = currentToken.ColumnCount - currentColumn;
                currentColumn += spaceRequiedCount;
                sourceCode.Append(' ', spaceRequiedCount);
                richSourceCode.Append(' ', spaceRequiedCount);

                // 2. EOFなら終わります
                if (currentToken.TokenType == TokenType.EOF)
                {
                    break;
                }

                // 3. 改行なら改行します
                if (RebuildExecuteReturn(currentToken, ref currentLine, ref currentColumn))
                {
                    continue;
                }

                // 4. BackSlashなら特殊な操作をします
                if (RebuildExecuteBackSlash(currentToken, ref currentColumn))
                {
                    continue;
                }

                // 5. 通常のトークンならトークンを書き込みます
                // sourceCode
                sourceCode.Append(currentToken.Value);
                // richSourceCode
                RichSourceCodeAppendRichText(currentToken);
                // 次のために文字位置を進める
                currentColumn += currentToken.Value.Length;
            }

            return;
        }
        private bool RebuildExecuteReturn(Token currentToken, ref int currentLine, ref int currentColumn)
        {
            if (currentToken.TokenType == TokenType.Return)
            {
                // 改行トークンを使って改行を判定します
                // 改行トークン以外による不正な改行を次のブロックで判定します

                // sourceCode
                sourceCode.Append('\n');
                // richSourceCode
                // 表示上では任意の改行文字(returnText)を生成します
                string returnSyntaxColor = Constants.syntaxHighlightColors[TokenType.Return];
                richSourceCode.Append($"<color={returnSyntaxColor}>{Constants.returnText}</color>\n");

                currentLine++;
                currentColumn = 1;

                return true;
            }
            else if (currentToken.LineCount != currentLine)
            {
                // 不正な改行を判定します
                // どのExeptionを使うのか分からなかった
                throw new Exception("SourceCodeRebuilder : 改行トークンのない不正な改行を検出しました");
            }

            return false;
        }
        private bool RebuildExecuteBackSlash(Token currentToken, ref int currentColumn)
        {
            if (currentToken.TokenType == TokenType.BackSlash)
            {
                // BackSlashには\→\<s></s>という操作を加えます
                // これはInputFieldの表示バグを防ぐためで、sourceCodeのみに必要になります

                // sourceCode
                sourceCode.Append("\\<s></s>");

                currentColumn += 1; // \分の1だけです

                return true;
            }
            
            return false;
        }
        private void RichSourceCodeAppendRichText(Token currentToken)
        {
            if (Constants.syntaxHighlightColors.ContainsKey(currentToken.TokenType) == false)
            {
                throw new System.Collections.Generic.KeyNotFoundException(
                    "SourceCodeRebuilder : 指定されたTokenTypeにつける色がConstantsで登録されていません");
            }

            string syntaxColor = Constants.syntaxHighlightColors[currentToken.TokenType]
                ?? throw new Exception("SourceCodeRebuilder : 取得したsyntaxColorがnullです");

            richSourceCode.Append($"<color={syntaxColor}>");
            richSourceCode.Append(currentToken.Value);
            richSourceCode.Append("</color>");
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