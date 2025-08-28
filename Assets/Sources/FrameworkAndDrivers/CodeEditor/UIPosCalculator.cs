using UnityEngine;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class UIPosCalculator : MonoBehaviour, IUIPosCalculator
    {
        [SerializeField]
        private Canvas canvas;
        private RectTransform canvasTransform;

        public void MemberInitialize()
        {
            canvasTransform = canvas.GetComponent<RectTransform>();
        }

        public Vector2 GetMousePosOnUI()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasTransform, Input.mousePosition, canvas.worldCamera,
                out var mousePosition);
            return mousePosition;
        }
        public Vector2Int GetTextPosOnMouse(TMP_Text text)
        {
            int charIndex = GetCharIndexOnMouse(text);
            if (charIndex == -1)
                return new(0, 0);

            int line = text.textInfo.characterInfo[charIndex].lineNumber;
            int column = charIndex - text.textInfo.lineInfo[line].firstCharacterIndex;

            return new Vector2Int(column + 1, line + 1);
        }
        private int GetCharIndexOnMouse(TMP_Text text)
        {
            Vector2 mouseWorldPos = GetMousePosOnUI();

            // TMP_TextInfoのAPIを利用して座標からインデックスを取得
            int nearestIndex = TMP_TextUtilities.FindNearestCharacter(text, Input.mousePosition, canvas.worldCamera, false);

            // 文字の頂点座標から中心点を計算
            TMP_CharacterInfo charInfo = text.textInfo.characterInfo[nearestIndex];
            Vector2 charLocalPos = (charInfo.bottomLeft + charInfo.topRight) / 2;
            Vector2 charWorldPos = text.transform.TransformPoint(charLocalPos);

            // 距離で比較
            float distance = Vector2.Distance(mouseWorldPos, charWorldPos);
            if (distance < 0.5f)
                return nearestIndex;
            else
                return -1;
        }
    }
}