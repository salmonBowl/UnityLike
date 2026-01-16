using UnityEngine;
using UnityEngine.EventSystems;

namespace UnityLike.FrameworkAndDrivers.EditSpace
{
    public class CameraOperate : MonoBehaviour
    {
        [SerializeField] private Texture2D mouseCursor_rotate;
        [SerializeField] private Texture2D mouseCursor_move;

        [Space(20)]

        [SerializeField] private float rotateSpeed;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float zoomSpeed;

        private float angleX = 0f;
        private float angleY = 0f;

        void Update()
        {
            if (Application.isFocused)
            {
                Cursor.SetCursor(null, Input.mousePosition, CursorMode.Auto);
                RightClickDrag();
                WheelDrag();
                MouseScroll();
            }
        }
        private void RightClickDrag()
        {
            if (Input.GetMouseButton(1))
            {
                // マウスの移動量を取得
                angleX += Input.GetAxis("Mouse X") * rotateSpeed;
                angleY -= Input.GetAxis("Mouse Y") * rotateSpeed;

                // Y軸の回転を制限
                angleY = Mathf.Clamp(angleY, -90f, 90f);

                transform.eulerAngles = new Vector3(angleY, angleX, 0);

                Cursor.SetCursor(mouseCursor_rotate, new Vector2(0, 0), CursorMode.Auto);
            }
        }
        private void WheelDrag()
        {
            if (Input.GetMouseButton(2))
            {
                // マウスの移動量を取得
                float moveX = Input.GetAxis("Mouse X") * -moveSpeed;
                float moveY = Input.GetAxis("Mouse Y") * -moveSpeed;

                // 横移動
                transform.Translate(moveX, moveY, 0);

                Cursor.SetCursor(mouseCursor_move, new Vector2(0, 0), CursorMode.Auto);
            }
        }
        private void MouseScroll()
        {
            // マウスがUIに触れているならスキップ
            if (EventSystem.current.IsPointerOverGameObject()) return;

            float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
            transform.position += scrollDelta * zoomSpeed * transform.forward;
        }
    }
}