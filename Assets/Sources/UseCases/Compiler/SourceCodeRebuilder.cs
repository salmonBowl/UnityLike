using System;
using System.Text;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public class SourceCodeRebuilder
    {
        private readonly Token[] tokenArray;
        private readonly StringBuilder sourceCode;
        private readonly StringBuilder richSourceCode; //�����o�[�֐������g��Ȃ�����readonly

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
                    // ���s�g�[�N�����g���ĉ��s�𔻒肵�܂�
                    // ���s�g�[�N���ȊO�ɂ��s���ȉ��s�����̃u���b�N�Ŕ��肵�܂�

                    sourceCode.Append('\n');
                    richSourceCode.Append("<color=\"blue\">\\n</color>\n");
                }
                else if (currentToken.LineCount != currentLine)
                {
                    // �s���ȉ��s�𔻒肵�܂�
                    // �ǂ�Exeption���g���̂�������Ȃ�����
                    throw new Exception("SourceCodeRebuilder : ���s�g�[�N���̂Ȃ��s���ȉ��s�����o���܂���");
                }

                // �󔒂�⊮���܂�
                int spaceRequiedCount = currentToken.ColumnCount - currentColumn;
                sourceCode.Append(' ', spaceRequiedCount);
                richSourceCode.Append(' ', spaceRequiedCount);

                // �g�[�N�����������݂܂�

                // sourceCode
                sourceCode.Append(currentToken.Value);
                // richSourceCode
                RichSourceCodeAppendRichText(currentToken);
            }

            return;
        }
        private void RichSourceCodeAppendRichText(Token currentToken)
        {
            if (Constants.syntaxHighlightColors.ContainsKey(currentToken.TokenType) == false)
            {
                throw new System.Collections.Generic.KeyNotFoundException(
                    "SourceCodeRebuilder : �w�肳�ꂽTokenType�ɂ���F��Constants�œo�^����Ă��܂���");
            }

            string syntaxColor = Constants.syntaxHighlightColors[currentToken.TokenType]
                ?? throw new Exception("SourceCodeRebuilder : �擾����syntaxColor��null�ł�");

            richSourceCode.Append($"<color={syntaxColor}>");
            richSourceCode.Append(currentToken.Value);
            richSourceCode.Append("</color>");
        }

        /// <summary>
        /// �č\�������\�[�X�R�[�h���擾���܂�
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetSourceCodeRebuild()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Execute�̑O��Get���Ă΂�܂���");
            }
            return sourceCode.ToString();
        }

        /// <summary>
        /// ���b�`�e�L�X�g�����ꂽ�\�[�X�R�[�h���擾���܂�
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetRichSourceCode()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Execute�̑O��Get���Ă΂�܂���");
            }
            return richSourceCode.ToString();
        }
    }
}