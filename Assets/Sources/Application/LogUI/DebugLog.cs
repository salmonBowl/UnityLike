using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.LogUI
{
    public class DebugLog : MonoBehaviour
    {
        public static DebugLog Instance { get; private set; }

        [SerializeField] private GameObject logTextPrefab;
        [SerializeField] private Transform logParent; // LogPanelのTransform
        [SerializeField] private int maxLogLines = 10;
        [SerializeField] private float fadeoutTime = 1f;
        [SerializeField] private float fadeoutMarginTime = 4f;

        private readonly Queue<Log> logs = new();

        private DebugLog()
        {
            Instance = this;
        }

        public void AddLog(string message)
        {
            // VerticalLayoutGroupの子としてログを生成
            GameObject newLogObject = Instantiate(logTextPrefab, logParent);
            newLogObject.transform.SetAsFirstSibling();

            TMP_Text textComponent = newLogObject.GetComponent<TMP_Text>();
            textComponent.text = message;
            textComponent.alpha = 1f;

            // 構造体の設定
            Log newLog = new()
            {
                GameObject = newLogObject,
                Text = textComponent,
                ElapsedTime = Time.time,
            };

            // 新しいログを追加
            logs.Enqueue(newLog);

            // 最大行数を超えたらDequeueを削除
            if (logs.Count > maxLogLines)
            {
                Log oldestLog = logs.Dequeue();
                Destroy(oldestLog.GameObject);
            }
        }

        void Update()
        {
            LogsWhiteOutUpdate();
            LogsFadeOutUpdate();
        }

        private void LogsWhiteOutUpdate()
        {
            // 各ログを白色へ
            foreach (var log in logs)
            {
                Color color = log.Text.color;

                float whiteOutTime = 1.2f;
                float newBlue = Mathf.Min(1, color.b + Time.deltaTime / whiteOutTime);
                color.b = newBlue;

                log.Text.color = color;
            }
        }
        private void LogsFadeOutUpdate()
        {
            // 各ログの透明化処理
            foreach (var log in logs)
            {
                float elapsedTime = Time.time - log.ElapsedTime;

                if (elapsedTime > fadeoutMarginTime)
                {
                    Color color = log.Text.color;

                    float newAlpha = Mathf.Max(0, color.a - Time.deltaTime / fadeoutTime);
                    color.a = newAlpha;

                    log.Text.color = color;
                }
            }
        }
    }

    struct Log
    {
        public GameObject GameObject;
        public TMP_Text Text;
        public float ElapsedTime; // ログが出力されてからの経過時間
    }
}
