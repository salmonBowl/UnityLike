using System;
using Zenject;

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
            this.sourceCode = sourceCode ?? throw new ArgumentException();
            currentIndex = 0;
            currentLine = 1;
            currentColumn = 1;
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
        /// <exception cref="ArgumentException">ファイルが終端に達している状態で読み取りを進めようとしています</exception>
        public void Consume()
        {
            if (IsEndOfFile())
                throw new ArgumentException();

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

        public bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // ラムダ式ではなく不等号
            // 等号でないのは例外を避けるため
        }

        /// <summary>
        /// 次のトークンを生成して返します
        /// このメソッドは字句解析の主要な部分になりますが、現時点では未実装です
        /// </summary>
        public Token GetNextToken()
        {
            return;
        }
    }
}