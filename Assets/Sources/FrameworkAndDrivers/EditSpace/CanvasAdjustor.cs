using UnityEngine;

public class CanvasAdjustor : MonoBehaviour
{
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
        Quaternion cameraRotation = canvas.worldCamera.transform.rotation;
        transform.rotation = cameraRotation;
    }
}
