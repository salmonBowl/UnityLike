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
            this.sourceCode = sourceCode ?? throw new ArgumentNullException("Compiler.Lexer.Lexer() : sourceCode��null�̕����񂪓n����܂���");
            currentIndex = 0;
            currentLine = 1;
            currentColumn = 1;
        }

        /// <summary>
        /// ���̃g�[�N���𐶐����ĕԂ��܂�
        /// ���̃��\�b�h�͎����͂̎�v�ȕ����ɂȂ�܂����A�����_�ł͖������ł�
        /// </summary>
        public Token GetNextToken()
        {
            // �󔒕������X�L�b�v���܂�
            // �܂����̓r���Ńt�@�C���̏I�[�ɒB������EOF��Ԃ��܂�
            while (true)
            {
                if (IsEndOfFile())
                {
                    return new Token(TokenType.EOF, "\0", currentLine, currentColumn);
                }

                // ���̕������󔒂��ǂ���
                if (Array.IndexOf(Constants.whiteSpaceChars, Peek()) == -1)
                {
                    break;
                }
                else
                {
                    // �󔒕����Ȃ�X�L�b�v���܂�
                    Consume();
                }
            }

            // �g�[�N���̌��o���s���Ă����܂�

            int tokenLine = currentLine;
            int tokenColumn = currentColumn;

            char firstChar = Peek();

            // ���ʎq
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
                // �L�q���Ă��Ȃ���O�͑S��TokenType.Unknown�Ƃ��ĕԂ��܂�

                string tokenValue = ReadWhile(firstChar, c => false);
                return new Token(TokenType.Unknown, tokenValue, tokenLine, tokenColumn);
            }
        }

        /// <summary>
        /// �e��ނ̃g�[�N�������o����ۂɋ��ʂ����������܂Ƃ߂܂���
        /// </summary>
        private string ReadWhile(char firstChar, Func<char, bool> predicate)
        {
            StringBuilder builder = new(firstChar);
            Consume();

            while (!IsEndOfFile() && predicate(Peek()))
                // IsEndOfFile�͕K�v�Ȃ����O�̂���
            {
                builder.Append(Peek());
                Consume();
            }

            return builder.ToString();
        }

        /// <summary>
        /// �ǂݎ��ʒu�͐i�߂��A��ǂ݂��Ď��̕�����Ԃ��܂�
        /// </summary>
        private char Peek()
        {
            if (IsEndOfFile()) // �t�@�C�����I���Ȃ�
            {
                // �I�[������Ԃ��܂�
                // \0 : string�̏I�[����
                return '\0';
            }
            return sourceCode[currentIndex];
        }

        /// <summary>
        /// ���݂̕���������A�ǂݎ��ʒu��1��ɐi�߂܂�
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private void Consume()
        {
            if (IsEndOfFile())
                throw new InvalidOperationException("Compiler.Lexer:ILexer.Consume() : ����ȏ�ǂݎ���i�߂��܂���");

            if (sourceCode[currentIndex] == '\n')
            {
                //�s�����ɐi�߂܂�

                currentLine++;
                currentColumn = 1;

                currentIndex++;
            }
            else
            {
                // �ʏ�
                // �ǂݎ��ʒu��i�߂܂�

                currentColumn++;
                currentIndex++;
            }
        }

        /// <summary>
        /// �t�@�C���̓ǂݎ��ʒu���I�[�ɒB�������𔻒肵�܂�
        /// </summary>
        private bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // �����_���ł͂Ȃ��s����
            // �����łȂ��̂͗�O������邽��
        }
    }
}