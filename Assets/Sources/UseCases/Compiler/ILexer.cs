
namespace UnityLike.UseCases.Compiler
{
    public interface ILexer
    {
        /// <summary>
        /// ���̕��������Ȃ̂����擾���܂�
        /// </summary>
        char Peek();

        /// <summary>
        /// ���݂̕���������A�ǂݎ��ʒu��1��ɐi�߂܂�
        /// </summary>
        void Consume();

        /// <summary>
        /// ���̃g�[�N���𐶐����Ԃ��܂�
        /// �����͂̎�v�ȃ��\�b�h�ł�
        /// </summary>
        Token GetNextToken();

        /// <summary>
        /// �t�@�C����ǂݎ�肪�I�[�ɒB�������𔻒肵�܂�
        /// </summary>
        bool IsEndOfFile();
    }
}