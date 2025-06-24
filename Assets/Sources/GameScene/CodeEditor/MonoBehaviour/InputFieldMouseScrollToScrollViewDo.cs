using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputFieldMouseScrollToScrollViewDo : MonoBehaviour
{
    [SerializeField] ScrollRect parentScrollView;

    void Start()
    {
        if (parentScrollView == null)
            Debug.LogError("InputField.IFMSTSVD : parentScrollViewがアタッチされていません");
    }

    public void OnScroll(PointerEventData e)
    {
        ExecuteEvents.Execute(parentScrollView.gameObject, e, ExecuteEvents.scrollHandler);
    }
}
