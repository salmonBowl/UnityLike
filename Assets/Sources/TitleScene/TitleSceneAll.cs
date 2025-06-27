
/*
    タイトルのシーンの処理を担当するクラス
    シーンがやること少ないのでこれだけで完結させるクラス、素晴らしい
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TitleSceneAll : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] Button buttonNewStart;
    [SerializeField] Button buttonLoad;

    [SerializeField] RectTransform UnityIcon;

    bool IsTitleUpdate;
    float panelAlpha;

    bool pointedButton = false;

    void Start()
    {
        Application.targetFrameRate = 60;
        IsTitleUpdate = true;
        panelAlpha = 0f;
        buttonNewStart.interactable = true;
        buttonLoad.interactable = true;
    }
    void Update()
    {
        if (IsTitleUpdate)
        {
            float angleDegDestination = pointedButton? 120 : 0;

            // 滑らかに角度を変化
            UnityIcon.rotation = Quaternion.Lerp(
                Quaternion.Euler(0, 0, angleDegDestination),
                UnityIcon.rotation,
                9.5f
                );
        }
        else // シーン遷移のフェードアウト
        {
            if (panelAlpha == 1)
            {
                SceneManager.LoadScene(1);
            }

            IncreasePanelAlpha(0.01f);
            SetPanelColorAlpha(panelAlpha);
        }
    }
    void IncreasePanelAlpha(float increase)
    {
        panelAlpha += increase;
        panelAlpha = Mathf.Clamp01(panelAlpha);
    }
    void SetPanelColorAlpha(float panelAlpha)
    {
        Color panelColor = panel.color;
        panelColor.a = panelAlpha;
        panel.color = panelColor;
    }

    public void ButtonPointerEnter()
    {
        pointedButton = true;
    }
    public void ButtonPointerExit()
    {
        pointedButton = false;
    }

    public void CreateNewProject()
    {
        IsTitleUpdate = false;
    }
    public void LoadProject()
    {
        IsTitleUpdate = false;
    }
}
