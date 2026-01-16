using UnityEngine;

public class InputFieldScrollControll : MonoBehaviour
{
    [SerializeField] private RectTransform textArea;

    void Start()
    {
        if (!textArea)
            Debug.LogError("textAreaがアタッチされていません");
    }

    // InputFieldから選択を外した時、左端へスクロールされるようにします
    public void OnInputFieldDeselect()
    {
        RectTransform caret = (RectTransform)textArea.Find("Caret");
        if (!caret)
            Debug.LogError("オブジェクト名'Caret'が見つかりませんでした");
        RectTransform text = (RectTransform)textArea.Find("Text");
        if (!text)
            Debug.LogError("オブジェクト名'Text'が見つかりませんでした");

        Vector2 correctPos = new(0, caret.offsetMin.y);

        // 座標を書き換えます
        caret.offsetMin = correctPos;
        text.offsetMin = correctPos;
    }
}
