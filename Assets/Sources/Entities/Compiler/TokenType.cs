
namespace UnityLike.Entities.Compiler
{
    public enum TokenType
    {
        Identifier, // �ϐ���֐��Ȃǂ̎��ʎq

        NumberLiteral, // ����

        // �Z�p���Z�q
        Plus,
        Minus,
        Multiply,
        Divide,

        // ������Z�q
        Equals,
        PlusEquals,
        MinusEquals,
        MultiplyEquals,
        DivideEquals,
        Increment,
        Decrement,

        // ��r���Z�q
        EqualEquals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,

        Unknown, // ���͒�����̓~�X�Ȃ�

        EOF // �I�[�����g�[�N��
    }
}