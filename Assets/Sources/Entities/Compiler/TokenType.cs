
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
            ���ʗ� �܂ŐV�K�ǉ�
            ����̃V���^�b�N�X�n�C���C�g�����͂܂���������Ă��܂���
         */

        // �֐����s�̂��߂ɕK�v�Ȃ���
        COLON,
        COMMA,

        // �g�ݍ��݌^ (�F�ŕ\�����܂�)
        TYPE_STANDARD, //int��float�Ȃǂ̕ϐ��ŁAvoid�Ȃǂ̊֐��錾�͂��̃G���W���Ŏg���Ȃ�

        // �L�[���[�h
        IF,
        ELSE,
        FOR,
        WHILE,
        NEW,
        NULL,
        TRUE,
        FALSE,
        PUBLIC,
        PRIVATE,

        // ���ʗ�
        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACE,
        RIGHT_BRACE,
        LEFT_BRACKET,
        RIGHT_BRACKET,
    
        Unknown, // ���͒�����̓~�X�Ȃ�

        Return, // ���s�g�[�N��
        EOF // �I�[�g�[�N��
    }
}