using System;
using System.Text;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /*
        SourceCodeRebuilder
            トークン列からソースコードを再構成するクラスです

            BaseクラスにしてRebuilderFromTokensに移動しました

            RebuildExecute()
            GetSourceCodeRebuild()
            GetRichSourceCode()
     */
    public abstract class SourceCodeRebuilder
    {
        protected readonly StringBuilder sourceCode = new();
        protected readonly StringBuilder richSourceCode = new(); //メンバー関数の.Appendしか使わないためreadonly

        public abstract void RebuildExecute();

        /// <summary>
        /// 再構成したソースコードを取得します
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetSourceCodeRebuild()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return sourceCode.ToString();
        }

        /// <summary>
        /// リッチテキスト化されたソースコードを取得します
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetRichSourceCode()
        {
            if (sourceCode == null)
            {
                throw new InvalidOperationException("SourceCodeRebuilder : Executeの前にGetが呼ばれました");
            }
            return richSourceCode.ToString();
        }
    }
}