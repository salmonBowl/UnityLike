using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// 構文木からソースコードを復元すると同時にトークン列を抽出します
    /// </summary>
    public class GenerateTokenList
    {
        private List<ColoredToken> tokens;
        
        /// <summary>
        /// リストを初期化します
        /// </summary>
        public void ClearList()
        {
            tokens = new();
        }

        /// <summary>
        /// トークンをリストに追加します
        /// </summary>
        /// <param name="token"></param>
        public void Add(ColoredToken token)
        {
            tokens.Add(token);
        }

        /// <summary>
        /// 抽出したトークン列を取得します
        /// </summary>
        /// <returns></returns>
        public List<ColoredToken> GetData()
        {
            return tokens;
        }
    }
}