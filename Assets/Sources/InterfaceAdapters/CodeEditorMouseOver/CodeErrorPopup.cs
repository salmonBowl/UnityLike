using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.Compiler;

namespace UnityLike.InterfaceAdapters.CodeEditorMouseOver
{
    /// <summary>
    /// 文字へのマウスオーバーでエラー内容が表示されるシステムを実装します
    /// </summary>
    public class CodeErrorPopup
    {
        private readonly CompileData data;
        private readonly IPopupView view;

        [Inject]
        public CodeErrorPopup(CompileData data, IPopupView popup)
        {
            this.data = data;
            view = popup;
        }

        /// <summary>
        /// エラーの内容をポップアップします
        /// </summary>
        /// <param name="lineMousePos">マウスオーバーされている文字の位置を指定します</param>
        /// <param name="columnMousePos">マウスオーバーされている文字の位置を指定します</param>
        public void MessagePopUp(int lineMousePos, int columnMousePos)
        {
            string tokenMessage = GetTokenMessageFromCharPos(lineMousePos, columnMousePos);
            
            view.SetText(tokenMessage);

            if (tokenMessage == string.Empty)
                view.ShowPopup();
            else
                view.HidePopup();
        }

        public void EnterMouseOver()
        {
            view.HidePopup();
        }

        /// <summary>
        /// 行番号・列番号から、その場所にあるトークンが持つエラーメッセージを取得します
        /// </summary>
        /// <param name="lineMousePos"></param>
        /// <param name="columnMousePos"></param>
        /// <returns>トークンが見つかれば中身のメッセージを、そうでなければstring.Emptyを返します</returns>
        private string GetTokenMessageFromCharPos(int lineMousePos, int columnMousePos)
        {
            List<ColoredToken> tokens = data.ColoredTokens;
            foreach(var token in tokens)
            {
                // 行きすぎたらその場所にトークンは存在しない
                if (lineMousePos < token.LineCount)
                    return string.Empty;

                // 行が合うまでスキップ
                if (lineMousePos != token.LineCount)
                    continue;

                // 列が合うまでスキップ
                if (columnMousePos < token.ColumnCount)
                    continue;

                // mousePosを含むトークンが見つかった場合、その中身のメッセージを返す
                int tokenEndColumn = token.ColumnCount + token.Value.Length;
                if (columnMousePos < tokenEndColumn)
                {
                    return token.ErrorMessage;
                }
                else
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }
    }
}