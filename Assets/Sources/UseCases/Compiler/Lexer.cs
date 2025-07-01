using System;
using System.Text;
using System.Collections.Generic;
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

        #region dictionary�̒�`
        private readonly Dictionary<string, TokenType> twoCharOperators = new()
        {
            { "==", TokenType.EqualEquals },
            { "!=", TokenType.NotEquals },
            { "+=", TokenType.PlusEquals },
            { "-=", TokenType.MinusEquals },
            { "*=", TokenType.MultiplyEquals },
            { "/=", TokenType.DivideEquals },
            { "++", TokenType.Increment },
            { "--", TokenType.Decrement },
            { ">=", TokenType.GreaterThanOrEqual },
            { "<=", TokenType.LessThanOrEqual }
        };

        private readonly Dictionary<char, TokenType> oneCharOperators = new()
        {
            { '+', TokenType.Plus },
            { '-', TokenType.Minus },
            { '*', TokenType.Multiply },
            { '/', TokenType.Divide },
            { '=', TokenType.Equals },
            { '!', TokenType.Unknown }, // '!'�P�̂�Unknown�ł����A2������ != �ɂȂ�\��������܂�
            { '>', TokenType.GreaterThan },
            { '<', TokenType.LessThan }
        };
        #endregion

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
            // ����
            else if (char.IsDigit(firstChar))
            {
                string tokenValue = ReadWhile(firstChar, c => char.IsDigit(c));
                return new Token(TokenType.NumberLiteral, tokenValue, tokenLine, tokenColumn);
            }
            // ���Z�q
            else if (oneCharOperators.TryGetValue(firstChar, out TokenType oneCharTokenType))
            {
                Consume();
                return ReadOperatorToken(oneCharTokenType, firstChar, tokenLine, tokenColumn);
            }
            // ���s
            else if (firstChar == '\n')
            {
                Consume(); // ���s��Consume�ŏ����ł���
                return new Token(TokenType.Return, "\n", tokenLine, tokenColumn);
            }
            else
            {
                // �L�q���Ă��Ȃ���O�͑S��TokenType.Unknown�Ƃ��ĕԂ��܂�

                Consume();
                return new Token(TokenType.Unknown, firstChar.ToString(), tokenLine, tokenColumn);
            }
        }

        /// <summary>
        /// ���ʎq�⃊�e�����̃g�[�N�������o����ۂɋ��ʂ����������܂Ƃ߂܂���
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
        /// ���Z�q�̃g�[�N������ĂɌ��o���܂�
        /// </summary>
        /// <returns>�ŏI�I�ȃg�[�N���������ŕԂ��܂�</returns>
        private Token ReadOperatorToken(TokenType oneCharTokenType, char firstChar, int tokenLine, int tokenColumn)
        {
            // 1�����Ȃ�dictionary�Ɉ�����������

            // �K�v�Ȃ����O�̂���
            if (IsEndOfFile())
                return new Token(oneCharTokenType, firstChar.ToString(), tokenLine, tokenColumn);

            // 2�����ɂ����Ƃ��ɂ�dictionary�ɑ��݂��邩�ǂ��������o
            // 2����string�̐���
            string twoChars = firstChar.ToString() + Peek().ToString();

            if (twoCharOperators.TryGetValue(twoChars, out TokenType twoCharTokenType))
            {
                Consume();
                return new Token(twoCharTokenType, twoChars, tokenLine, tokenColumn);
            }
            else
            {
                return new Token(oneCharTokenType, firstChar.ToString(), tokenLine, tokenColumn);
            }
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