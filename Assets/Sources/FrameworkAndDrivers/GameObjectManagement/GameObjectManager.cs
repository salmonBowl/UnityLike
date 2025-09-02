using System.Collections.Generic;
using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : MonoBehaviour, IChangeSelected, ICodeExecute
    {
        [SerializeField] private GameObject gameObjectPrefab;

        private readonly List<GameObjectPrefab> gameObjects = new();
        private GameObjectPrefab selectedGameObject;

        public void AddGameObject(GameObject model)
        {
            GameObjectPrefab g = GameObjectPrefab.Instantiate(gameObjectPrefab, model);
            gameObjects.Add(g);
        }

        public void ChangeSelected(GameObjectPrefab target)
        {
            // 元々選択していたオブジェクトの選択を外します
            if (selectedGameObject)
            {
                // エディターを閉じる
                selectedGameObject.EditorSetActive(false);
                // ハイライトを非表示
                selectedGameObject.HighlightSetActive(false);
            }

            // selectedGameObjectを変更します
            selectedGameObject = target;

            // 新しく選択するオブジェクトを選択します
            if (target)
            {
                // ハイライトを表示
                target.HighlightSetActive(true);
                // エディターを非表示
                target.EditorSetActive(true);
            }
        }

        public void ExecuteVoidStart()
        {
            foreach(var gameObject in gameObjects)
            {
                gameObject.ExecuteVoidStart();
            }
        }
        public void ExecuteVoidUpdate()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.ExecuteVoidUpdate();
            }
        }
    }
}
