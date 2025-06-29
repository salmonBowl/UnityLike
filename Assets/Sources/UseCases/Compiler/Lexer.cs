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

            int tokenLine = currentLine;
            int tokenColumn = currentColumn;

            char firstChar = Peek();

            // 識別子
            if (char.IsLetter(firstChar))
            {
                string tokenValue = ReadWhile(firstChar, c => char.IsLetterOrDigit(c) || c == '_');
                return new Token(TokenType.Identifier, tokenValue, tokenLine, tokenColumn);
            }
            else if (char.IsDigit(firstChar))
            {
                string tokenValue = ReadWhile(firstChar, c => char.IsDigit(c));
                return new Token(TokenType.NumberLiteral, tokenValue, tokenLine, tokenColumn);
            }
            else if (firstChar == '+')
            {
                Consume();
                char nextChar = Peek();

                if (nextChar == '=')
                {
                    Consume();
                    return new Token(TokenType.PlusEquals, "+=", tokenLine, tokenColumn);
                }
                else if (nextChar == '+')
                {
                    Consume();
                    return new Token(TokenType.Increment, "++", tokenLine, tokenColumn);
                }
                else
                {
                    return new Token(TokenType.Plus, "+", tokenLine, tokenColumn);
                }
            }
            else if (firstChar == '-')
            {
                Consume();
                char nextChar = Peek();

                if (nextChar == '=')
                {
                    Consume();
                    return new Token(TokenType.MinusEquals, "-=", tokenLine, tokenColumn);
                }
                else if (nextChar == '-')
                {
                    Consume();
                    return new Token(TokenType.Decrement, "--", tokenLine, tokenColumn);
                }
                else
                {
                    return new Token(TokenType.Minus, "-", tokenLine, tokenColumn);
                }
            }
            else if (firstChar == '*')
            {
                Consume();
                char nextChar = Peek();

                if (nextChar == '=')
                {
                    Consume();
                    return new Token(TokenType.MultiplyEquals, "*=", tokenLine, tokenColumn);
                }
                else
                {
                    return new Token(TokenType.Multiply, "*", tokenLine, tokenColumn);
                }
            }
            else if (firstChar == '/')
            {
                Consume();
                char nextChar = Peek();

                if (nextChar == '=')
                {
                    Consume();
                    return new Token(TokenType.DivideEquals, "/=", tokenLine, tokenColumn);
                }
                else
                {
                    return new Token(TokenType.Divide, "/", tokenLine, tokenColumn);
                }
            }
            else
            {
                // 記述していない例外は全てTokenType.Unknownとして返します

                string tokenValue = ReadWhile(firstChar, c => false);
                return new Token(TokenType.Unknown, tokenValue, tokenLine, tokenColumn);
            }
        }

        /// <summary>
        /// 各種類のトークンを検出する際に共通した処理をまとめました
        /// </summary>
        private string ReadWhile(char firstChar, Func<char, bool> predicate)
        {
            StringBuilder builder = new(firstChar);
            Consume();

            while (!IsEndOfFile() && predicate(Peek()))
                // IsEndOfFileは必要ないが念のため
            {
                builder.Append(Peek());
                Consume();
            }

            return builder.ToString();
        }

        /// <summary>
        /// 読み取り位置は進めず、先読みして次の文字を返します
        /// </summary>
        private char Peek()
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
        private void Consume()
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
        private bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // ラムダ式ではなく不等号
            // 等号でないのは例外を避けるため
        }
    }
}