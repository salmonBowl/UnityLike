using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public interface ILexer
    {
        /// <summary>
        /// 次の文字が何なのかを取得します
        /// </summary>
        char Peek();

        /// <summary>
        /// 現在の文字を消費し、読み取り位置を1つ先に進めます
        /// </summary>
        void Consume();

        /// <summary>
        /// ファイルを読み取りが終端に達したかを判定します
        /// </summary>
        bool IsEndOfFile();

        /// <summary>
        /// 次のトークンを生成し返します
        /// 字句解析の主要なメソッドです
        /// </summary>
        Token GetNextToken();
    }
}