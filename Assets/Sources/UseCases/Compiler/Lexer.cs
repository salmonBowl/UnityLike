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

            StringBuilder tokenValue = new();
            int tokenLine = currentLine;
            int tokenColumn = currentColumn;

            // ���ʎq
            for (int i = 0; true; i++)
            {
                if (i == 0)
                {
                    // 1�����ڂ̌��o�Ȃ�

                    char nextChar = Peek();

                    if (char.IsLetter(nextChar))
                    {
                        // �A���t�@�x�b�g�Ȃ烋�[�v���n�߂܂�
                        tokenValue.Append(nextChar);
                        Consume();
                    }
                    else
                    {
                        // ���ʎq���\�����镶���ȊO�Ȃ玟�̌��o�Ɉڂ�܂�
                        break;
                    }
                }
                else
                {
                    // 2�����ڈȍ~�̓ǂݎ��Ȃ�

                    char nextChar = Peek();

                    /*
                        EOF�̏ꍇ��nextChar��\0�����邽�߁A���Ȃ����삷��...�͂�...
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
                // �L�q���Ă��Ȃ���O�͑S��TokenType.Unknown�Ƃ��ĕԂ��܂�

                char nextChar = Peek();
                Consume();

                return new Token(TokenType.Unknown, nextChar.ToString(), currentLine, currentColumn);
            }
        }

        /// <summary>
        /// �ǂݎ��ʒu�͐i�߂��A��ǂ݂��Ď��̕�����Ԃ��܂�
        /// </summary>
        public char Peek()
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
        public void Consume()
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
        public bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // �����_���ł͂Ȃ��s����
            // �����łȂ��̂͗�O������邽��
        }
    }
}