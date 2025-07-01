
namespace UnityLike.Entities.Compiler
{
    public enum TokenType
    {
        Identifier, // 変数や関数などの識別子

        NumberLiteral, // 数字

        // 算術演算子
        Plus,
        Minus,
        Multiply,
        Divide,

        // 代入演算子
        Equals,
        PlusEquals,
        MinusEquals,
        MultiplyEquals,
        DivideEquals,
        Increment,
        Decrement,

        // 比較演算子
        EqualEquals,
        NotEquals,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual,

        /*
            制御構文 まで新規追加
            これのシンタックスハイライト部分はまだ実装されていません
         */

        // 点
        Dot,
        Comma,

        // 括弧類
        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACE,
        RIGHT_BRACE,
        LEFT_BRACKET,
        RIGHT_BRACKET,

        // キーワード

        // 組み込み型 (青色で表示します)
        TypeStandard, //intやfloatなどの変数で、voidなどの関数宣言はこのエンジンで使われない

        // 制御構文
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

    
        Unknown, // 入力中や入力ミスなど

        Return, // 改行トークン
        EOF // 終端トークン
    }
}