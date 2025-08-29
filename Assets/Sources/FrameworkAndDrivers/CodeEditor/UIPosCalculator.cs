using UnityEngine;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class UIPosCalculator : MonoBehaviour, IUIPosCalculator
    {
        [SerializeField]
        private Canvas canvas;

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
            // TMP_TextInfoのAPIを利用して座標からインデックスを取得
            int nearestIndex = TMP_TextUtilities.FindNearestCharacter(text, Input.mousePosition, canvas.worldCamera, false);

            // 文字の頂点座標から中心点を計算
            TMP_CharacterInfo charInfo = text.textInfo.characterInfo[nearestIndex];
            Vector2 charLocalPos = (charInfo.bottomLeft + charInfo.topRight) / 2;
            Vector3 charWorldPos = text.transform.TransformPoint(charLocalPos);

            // マウスの座標を計算
            RectTransformUtility.ScreenPointToWorldPointInRectangle(
                text.rectTransform,
                Input.mousePosition,
                canvas.worldCamera,
                out Vector3 mouseWorldPos);

            // 距離で比較
            float distance = Vector3.Distance(mouseWorldPos, charWorldPos);
            float distanceMargin = 0.03f;

            if (distance < GetDistanceCameraToCanvas() * distanceMargin)
                return nearestIndex;
            else
                return -1;
        }
        private float GetDistanceCameraToCanvas()
        {
            // Planeを定義します
            Vector3 canvasNormal = canvas.transform.forward;
            Vector3 canvasPosition = canvas.transform.position;
            Plane canvasPlane = new(canvasNormal, canvasPosition);

            // カメラの位置
            Vector3 cameraPosition = canvas.worldCamera.transform.position;

            // 距離を計算します
            float distance = canvasPlane.GetDistanceToPoint(cameraPosition);

            return Mathf.Abs(distance);
        }
    }
}