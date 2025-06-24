using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ScrollViewの子になっているInputFieldにアタッチします
/// </summary>
public class InputFieldMouseScrollToScrollViewDo : MonoBehaviour
{
    [SerializeField] ScrollRect parentScrollView;

    void Start()
    {
        if (parentScrollView == null)
            Debug.LogError("InputField.IFMSTSVD : parentScrollViewがアタッチされていません");
    }

    /// <summary>
    /// InputField上でスクロールが発生したら呼び出されます
    /// </summary>
    /// <param name="e">InputFieldのイベントデータ</param>
    public void OnScroll(PointerEventData e)
    {
        // 親のScrollViewにイベントを渡します
        ExecuteEvents.Execute(parentScrollView.gameObject, e, ExecuteEvents.scrollHandler);

        // InputFieldのスクロールを無効化
        e.Use();
    }
}
