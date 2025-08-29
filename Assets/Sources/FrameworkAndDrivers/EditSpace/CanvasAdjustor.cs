using UnityEngine;

public class CanvasAdjustor : MonoBehaviour
{
    [SerializeField]
    private float editorSize = 0.1f;

    private Canvas canvas;
    private RectTransform myTransform;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        myTransform = GetComponent<RectTransform>();
        if (!canvas)
            Debug.LogError("このファイルはcanvasにアタッチしてください");
    }
    void Update()
    {
        // 向きの制御
        Quaternion cameraRotation = canvas.worldCamera.transform.rotation;
        transform.rotation = cameraRotation;

        // 大きさの制御
        float distanceCameraToCanvas = GetDistanceCameraToCanvas();
        myTransform.localScale = distanceCameraToCanvas * editorSize * Vector3.one;
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
