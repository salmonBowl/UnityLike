using UnityEngine;

public class CanvasAdjustor : MonoBehaviour
{
    [SerializeField]
    private float editorSize = 0.1f;
    [SerializeField]
    private Transform followTarget;

    private Canvas canvas;
    private RectTransform myTransform;

    void Start()
    {
        if (!followTarget)
            Debug.Log("followTargetがアタッチされていません");

        canvas = GetComponent<Canvas>();
        myTransform = GetComponent<RectTransform>();
        if (!canvas)
            Debug.LogError("このファイルはcanvasにアタッチしてください");

        GameObject uiCamera = GameObject.Find("Camera_UI");
        if (!uiCamera)
            Debug.LogError("Camera_UIが見つかりませんでした");

        canvas.worldCamera = uiCamera.GetComponent<Camera>();
        if (!canvas.worldCamera)
            Debug.LogError("Camera_UIにCameraが見つかりませんでした");

        // 親子関係を解除し、元々親だったtransformの影響を受けないようにします
        transform.SetParent(null);
    }
    void Update()
    {
        // 位置の制御
        transform.position = followTarget.position;

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
