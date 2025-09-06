using UnityEngine;
using UnityEngine.EventSystems;

using UnityLike.FrameworkAndDrivers.GameObjectManagement;

namespace UnityLike.FrameworkAndDrivers.EditSpace
{
    [RequireComponent(typeof(Camera))]
    public class SelectObject : MonoBehaviour
    {
        [SerializeField] private GameObjectManager gameObjectManager;

        private Camera myCamera;

        void Start()
        {
            myCamera = GetComponent<Camera>();
            if (!myCamera)
                Debug.LogError("このファイルはカメラにアタッチしてください");
        }

        void Update()
        {
            if (Application.isFocused)
            {
                SelectObjectForRayCast();
            }
        }
        private void SelectObjectForRayCast()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // UIに触れているならスキップ
                if (EventSystem.current.IsPointerOverGameObject()) return;

                // マウス位置からRayを生成
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                {
                    GameObject targetObject = hit.collider.gameObject;

                    // オブジェクトが選択された場合、選択を変更する
                    if (targetObject.CompareTag("ObjectModel"))
                    {
                        GameObjectPrefab target = targetObject.GetComponentInParent<GameObjectPrefab>();

                        if (target == null)
                            Debug.LogError("予期しないオブジェクトが選択されました");

                        gameObjectManager.ChangeSelected(target);
                    }
                }
                else
                {
                    // 背景が選択された場合、選択を解除する
                    gameObjectManager.ChangeSelected(null);
                }
            }
        }
    }
}