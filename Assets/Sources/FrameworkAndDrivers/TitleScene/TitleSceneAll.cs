
/*
    タイトルのシーンの処理を担当するクラス
    シーンがやること少ないのでこれだけで完結させるクラス、素晴らしい
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneAll : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] Button buttonNewStart;
    [SerializeField] Button buttonLoad;

    [SerializeField] RectTransform UnityIcon;

    bool isFadeOut;
    float panelAlpha;

    float angleDegDestination = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        isFadeOut = false;
        panelAlpha = 0f;
        buttonNewStart.interactable = true;
        buttonLoad.interactable = true;
    }
    void Update()
    {
        // 滑らかに角度を変化させます
        // フェードアウトに関係なく動作
        UnityIcon.rotation = Quaternion.Lerp(
            Quaternion.Euler(0, 0, angleDegDestination),
            UnityIcon.rotation,
            0.9f
            );

        if (isFadeOut) // シーン遷移のフェードアウト
        {
            if (panelAlpha == 1)
            {
                SceneManager.LoadScene(1);
            }

            IncreasePanelAlpha(1.05f);
            SetPanelColorAlpha(panelAlpha);
        }
    }
    void IncreasePanelAlpha(float increaseRatio)
    {
        // フェードアウトの終端速度を調整します
        // 反比例のグラフを少し下にずらすような計算
        float adjustIncreaseSpeed = 1.03f;

        panelAlpha += (adjustIncreaseSpeed - panelAlpha) * (increaseRatio - 1);
        panelAlpha = Mathf.Clamp01(panelAlpha);
    }
    void SetPanelColorAlpha(float panelAlpha)
    {
        Color panelColor = panel.color;
        panelColor.a = panelAlpha;
        panel.color = panelColor;
    }

    public void ButtonCreateNewProjectPointerEnter()
    {
        if (!isFadeOut)
        angleDegDestination = -120;
    }
    public void ButtonLoadProjectPointerEnter()
    {
        if (!isFadeOut)
        angleDegDestination = 120;
    }
    public void ButtonPointerExit()
    {
        if (!isFadeOut)
        angleDegDestination = 0;
    }

    public void CreateNewProject()
    {
        isFadeOut = true;
    }
    public void LoadProject()
    {
        isFadeOut = true;
    }
}
