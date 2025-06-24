using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
        ExecuteEvents.Execute(parentScrollView.gameObject, e, EventHandler );
    }
}
