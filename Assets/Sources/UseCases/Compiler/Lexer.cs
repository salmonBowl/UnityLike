using System;
using System.Text;
using Zenject;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public class Lexer : ILexer
    {
        private readonly string sourceCode;

        private int currentIndex;
        private int currentLine;
        private int currentColumn;

        [Inject]
        public Lexer(
            string sourceCode
            )
        {
            this.sourceCode = sourceCode ?? throw new ArgumentNullException("Compiler.Lexer.Lexer() : sourceCodeにnullの文字列が渡されました");
            currentIndex = 0;
            currentLine = 1;
            currentColumn = 1;
        }

        /// <summary>
        /// 次のトークンを生成して返します
        /// このメソッドは字句解析の主要な部分になりますが、現時点では未実装です
        /// </summary>
        public Token GetNextToken()
        {
            // 空白文字をスキップします
            // またその途中でファイルの終端に達したらEOFを返します
            while (true)
            {
                if (IsEndOfFile())
                {
                    return new Token(TokenType.EOF, "\0", currentLine, currentColumn);
                }

                // 次の文字が空白かどうか
                if (Array.IndexOf(Constants.whiteSpaceChars, Peek()) == -1)
                {
                    break;
                }
                else
                {
                    // 空白文字ならスキップします
                    Consume();
                }
            }

            // トークンの検出を行っていきます

            StringBuilder tokenValue = new();
            int tokenLine = currentLine;
            int tokenColumn = currentColumn;

            // 識別子
            for (int i = 0; true; i++)
            {
                if (i == 0)
                {
                    // 1文字目の検出なら

                    char nextChar = Peek();

                    if (char.IsLetter(nextChar))
                    {
                        // アルファベットならループを始めます
                        tokenValue.Append(nextChar);
                        Consume();
                    }
                    else
                    {
                        // 識別子を構成する文字以外なら次の検出に移ります
                        break;
                    }
                }
                else
                {
                    // 2文字目以降の読み取りなら

                    char nextChar = Peek();

                    /*
                        EOFの場合はnextCharに\0が入るため、問題なく動作する...はず...
                     */

                    if (char.IsLetter(nextChar) || Array.IndexOf(Constants.addIdentifierChars, nextChar) != -1)
                    {
                        tokenValue.Append(nextChar);
                        Consume();
                    }
                    else
                    {
                        return new Token(TokenType.Identifier, tokenValue.ToString(), tokenLine, tokenColumn);
                    }
                }
            }



            {
                // 記述していない例外は全てTokenType.Unknownとして返します

                char nextChar = Peek();
                Consume();

                return new Token(TokenType.Unknown, nextChar.ToString(), currentLine, currentColumn);
            }
        }

        /// <summary>
        /// 読み取り位置は進めず、先読みして次の文字を返します
        /// </summary>
        public char Peek()
        {
            if (IsEndOfFile()) // ファイルが終わるなら
            {
                // 終端文字を返します
                // \0 : stringの終端文字
                return '\0';
            }
            return sourceCode[currentIndex];
        }

        /// <summary>
        /// 現在の文字を消費し、読み取り位置を1つ先に進めます
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public void Consume()
        {
            if (IsEndOfFile())
                throw new InvalidOperationException("Compiler.Lexer:ILexer.Consume() : これ以上読み取りを進められません");

            if (sourceCode[currentIndex] == '\n')
            {
                //行を次に進めます

                currentLine++;
                currentColumn = 1;

                currentIndex++;
            }
            else
            {
                // 通常
                // 読み取り位置を進めます

                currentColumn++;
                currentIndex++;
            }
        }

        /// <summary>
        /// ファイルの読み取り位置が終端に達したかを判定します
        /// </summary>
        public bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // ラムダ式ではなく不等号
            // 等号でないのは例外を避けるため
        }
    }
}