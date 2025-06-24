
/*
    タイトルのシーンの処理を担当するクラス
    全く責務分離してないけどシーンがやること少ないのでゆるして
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TitleSceneAll : MonoBehaviour
{
    [SerializeField] Image panel;
    [SerializeField] Button buttonEldenEnd;
    [SerializeField] TextMeshProUGUI textEldenEnd;

    bool IsTitleUpdate;
    float panelAlpha;
    int counterPressEnd;

    void Start()
    {
        Application.targetFrameRate = 60;
        IsTitleUpdate = true;
        panelAlpha = 0f;
        counterPressEnd = 0;
        buttonEldenEnd.interactable = true;
    }
    void Update()
    {
        if (!IsTitleUpdate)
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

    public void EldenStart()
    {
        IsTitleUpdate = false;
    }
    public void EldenEnd()
    {
        string dispMessage;

        counterPressEnd++;
        switch (counterPressEnd)
        {
            case 0:
                dispMessage = "エルデン終了";
                break;
            case 1:
                dispMessage = "本当に終了しますか?";
                break;
            case 2:
                dispMessage = "え、本当に終了しますか?";
                break;
            case 3:
                dispMessage = "なぜ終了しますか?";
                break;
            case 4:
                dispMessage = "私の提供したエルデンリングはそんなに面白くありませんでしたか?";
                break;
            case 5:
                DateTime today = DateTime.Now;
                dispMessage = $"{today.Month}月{today.Day}日：次回、このメッセージはもう表示されないかもしれません。1分でいいので、どうか読み飛ばさないでください。今日は{today.Month}月{today.Day}日で、私たち非営利団体は、あなたのご支援を必要としています。 これはとても重要なことなのです。エルデンリングが設立されたとき、それは広告なしで無償でプレイできる最初のオンラインスペースのひとつでした。この場所はあなたのものです。寄付をしてくださるのはプレイヤーのわずか2％です。¥300でも¥2,000でも、あなたのご寄付には価値があります。 エルデンリングとその姉妹ゲームを運営するエルデン財団より";
                break;
            case 6:
                dispMessage = "エルデン終了に失敗しました";
                buttonEldenEnd.interactable = false;
                break;
            default:
                dispMessage = "エルデン終了はエラーです";
                break;
        }

        textEldenEnd.text = dispMessage;
    }
}
