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
                    // ���s�g�[�N�����g����

                    sourceCode.Append('\n');
                    richSourceCode.Append("<color=\"blue\">\\n</color>\n");
                }
                else if (currentToken.LineCount != currentLine)
                {

                }

                // �󔒂�⊮���܂�
                int spaceRequiedCount = currentToken.ColumnCount - currentColumn;
                sourceCode.Append(' ', spaceRequiedCount);
                richSourceCode.Append(' ', spaceRequiedCount);

                // �g�[�N�����������݂܂�
                sourceCode.Append(currentToken.Value);
            }

            return;
        }

        /// <summary>
        /// �č\�������\�[�X�R�[�h���擾���܂�
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GetSourceCodeRebuild()
        {
            if (sourceCode == null)
            {
                throw new System.InvalidOperationException("SourceCodeRebuilder : Execute�̑O��Get���Ă΂�܂���");
            }
            return sourceCode.ToString();
        }

        /// <summary>
        /// ���b�`�e�L�X�g�����ꂽ�\�[�X�R�[�h���擾���܂�
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException"></exception>
        public string GetRichSourceCode()
        {
            if (sourceCode == null)
            {
                throw new System.InvalidOperationException("SourceCodeRebuilder : Execute�̑O��Get���Ă΂�܂���");
            }
            return richSourceCode.ToString();
        }
    }
}