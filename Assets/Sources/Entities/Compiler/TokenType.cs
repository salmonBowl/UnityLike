
namespace UnityLike.Entities.Compiler
{
    public enum TokenType
    {
        Identifier, // 変数や関数などの識別子

        NumberReteral, // 数字

        Unknown, // 入力中や入力ミスなど

        EOF // 終端文字トークン
    }
}