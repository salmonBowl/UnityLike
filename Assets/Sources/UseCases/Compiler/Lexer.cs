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
            this.sourceCode = sourceCode ?? throw new ArgumentNullException("Compiler.Lexer.Lexer() : sourceCode��null�̕����񂪓n����܂���");
            currentIndex = 0;
            currentLine = 1;
            currentColumn = 1;
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
        /// <exception cref="InvalidOperationException">�t�@�C�����I�[�ɒB���Ă����Ԃœǂݎ���i�߂悤�Ƃ��Ă��܂�</exception>
        public void Consume()
        {
            if (IsEndOfFile())
                throw new InvalidOperationException("Compiler.Lexer:ILexer.Consume() : ����ȏ�ǂݎ��ʒu��i�߂��܂���");

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

        public bool IsEndOfFile()
        {
            return (sourceCode.Length <= currentIndex);
            // �����_���ł͂Ȃ��s����
            // �����łȂ��̂͗�O������邽��
        }

        /// <summary>
        /// ���̃g�[�N���𐶐����ĕԂ��܂�
        /// ���̃��\�b�h�͎����͂̎�v�ȕ����ɂȂ�܂����A�����_�ł͖������ł�
        /// </summary>
        public Token GetNextToken()
        {
            if (IsEndOfFile())
            {
                return new Token(TokenType.EOF, );
            }

            char nextChar = Peek();
            Consume();

            return new Token(TokenType.Unknown, );
        }
    }
}