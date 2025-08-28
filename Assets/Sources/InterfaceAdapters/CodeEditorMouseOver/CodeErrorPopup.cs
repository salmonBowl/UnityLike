using System.Collections.Generic;

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
        public void MessagePopUp(int mousePosX, int mousePosY)
        {
            UnityEngine.Debug.Log(mousePosY + ", " + mousePosY);
            string tokenMessage = GetTokenMessageFromCharPos(mousePosX, mousePosY);
            
            view.SetText(tokenMessage);

            if (tokenMessage == string.Empty)
                view.HidePopup();
            else
                view.ShowPopup();
        }

        public void EnterMouseOver()
        {
            view.HidePopup();
        }

        /// <summary>
        /// マウスの座標から、その場所にあるトークンが持つエラーメッセージを取得します
        /// </summary>
        /// <param name="mousePosX"></param>
        /// <param name="mousePosY"></param>
        /// <returns>トークンが見つかれば中身のメッセージを、そうでなければstring.Emptyを返します</returns>
        private string GetTokenMessageFromCharPos(int localMousePosX, int localMousePosY)
        {
            List<ColoredToken> tokens = data.ColoredTokens;

            foreach(var token in tokens)
            {
                if (IsOverTokenToMousePos(token, localMousePosX, localMousePosY))
                {
                    return token.ErrorMessage;
                }
            }
            return string.Empty;
        }

        private bool IsOverTokenToMousePos(ColoredToken token, int localMousePosX, int localMousePosY)
        {
            // 矩形の範囲を整理します
            int rectXMin = token.ColumnCount + token.Value.Length - 1;
            int rectXMax = token.ColumnCount;
            int rectY = token.LineCount;

            // 当たり判定を行います
            bool isOverX = IsPointInRangeInt(localMousePosX, rectXMin, rectXMax);
            bool isOverY = IsPointInRangeInt(localMousePosY, rectY, rectY);

            // x, y ともに衝突している時、マウスがトークンに触れていることが分かります
            return isOverX && isOverY;
        }

        private bool IsPointInRangeInt(int target, int rangeNum1, int rangeNum2)
        {
            return (rangeNum1 - target) * (rangeNum2 - target) <= 0;
            /*
             * 範囲から出ている時には(rangeNum1-target)と(rangeNum2-tartget)が同符号になります
             * 範囲内、つまり異符号の時、その積は負になります
             */
        }
    }
}