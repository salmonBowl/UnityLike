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

        void Start()
        {
            if (Instance == null)
                Instance = this;
        }

        public void AddLog(string message)
        {
            // VerticalLayoutGroupの子としてログを生成
            GameObject newLogObject = Instantiate(logTextPrefab, logParent);
            newLogObject.transform.SetAsFirstSibling();

            // 構造体の設定
            Log newLog = new()
            {
                GameObject = newLogObject,
                Text = newLogObject.GetComponent<TMP_Text>(),
                ElapsedTime = Time.time,
            };
            newLog.Text.text = message;
            newLog.Text.alpha = 1f;

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
            LogsFadeOutUpdate();
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
