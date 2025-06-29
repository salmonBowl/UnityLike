
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

        Unknown, // 入力中や入力ミスなど

        EOF // 終端文字トークン
    }
}