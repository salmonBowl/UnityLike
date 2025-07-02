
namespace UnityLike.Entities.Compiler
{
    public enum TokenType
    {
        Identifier, // �ϐ���֐��Ȃǂ̎��ʎq

        // ���e����
        NumberLiteral,
        Null,
        True,
        False,

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
        SemiColon,

        // ���ʗ�
        LeftParen,
        RightParen,
        LeftBrace,
        RightBrace,
        LeftBracket,
        RightBracket,

        // �L�[���[�h

        // �g�ݍ��݌^ (�F�ŕ\�����܂�)
        TypeStandard, //int��float�Ȃǂ̕ϐ��ŁAvoid�Ȃǂ̊֐��錾�ɂ��Ă͂��̃G���W���Ŏg���Ȃ�
        TypeOther, // UnityEngine.Vector3�⎩��^�Ȃ�

        // ����\��
        If,
        Else,
        For,
        While,

        New,
        Public,
        Private,
    
        Unknown, // ���͒�����̓~�X�Ȃ�
        Return, // ���s�g�[�N��
        EOF // �I�[�g�[�N��
    }
}