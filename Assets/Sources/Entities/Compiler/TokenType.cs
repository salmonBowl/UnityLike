
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

        /*
            ����\�� �܂ŐV�K�ǉ�
            ����̃V���^�b�N�X�n�C���C�g�����͂܂���������Ă��܂���
         */

        // �_
        Dot,
        Comma,

        // ���ʗ�
        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACE,
        RIGHT_BRACE,
        LEFT_BRACKET,
        RIGHT_BRACKET,

        // �L�[���[�h

        // �g�ݍ��݌^ (�F�ŕ\�����܂�)
        TypeStandard, //int��float�Ȃǂ̕ϐ��ŁAvoid�Ȃǂ̊֐��錾�͂��̃G���W���Ŏg���Ȃ�

        // ����\��
        If,
        Else,
        For,
        While,
        New,
        Null,
        True,
        False,
        Public,
        Private,

    
        Unknown, // ���͒�����̓~�X�Ȃ�

        Return, // ���s�g�[�N��
        EOF // �I�[�g�[�N��
    }
}