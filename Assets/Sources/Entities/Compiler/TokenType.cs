
namespace UnityLike.Entities.Compiler
{
    public enum TokenType
    {
        Identifier, // 変数や関数などの識別子

        // リテラル
        NumberLiteral,
        Null,
        True,
        False,

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
        SemiColon,

        // 括弧類
        LeftParen,
        RightParen,
        LeftBrace,
        RightBrace,
        LeftBracket,
        RightBracket,

        // キーワード

        // 組み込み型 (青色で表示します)
        TypeStandard, //intやfloatなどの変数で、voidなどの関数宣言についてはこのエンジンで使われない
        TypeOther, // UnityEngine.Vector3や自作型など

        // 制御構文
        If,
        Else,
        For,
        While,

        New,
        Public,
        Private,
    
        Unknown, // 入力中や入力ミスなど
        Return, // 改行トークン
        EOF // 終端トークン
    }
}