
namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectSelection
    {
        private GameObjectPrefab selectedGameObject;

        /// <summary>
        /// selectedGameObjectを変更します
        /// </summary>
        /// <param name="target">変更するオブジェクト</param>
        public void ChangeSelected(GameObjectPrefab target)
        {
            InActiveSelected();

            selectedGameObject = target;

            ActiveSelected();
        }

        /// <summary>
        /// 選択しているオブジェクトを非アクティブにします
        /// </summary>
        private void InActiveSelected()
        {
            if (!selectedGameObject)
                return;

            // エディターを閉じる
            selectedGameObject.EditorSetActive(false);
            // ハイライトを非表示
            selectedGameObject.HighlightSetActive(false);
        }

        /// <summary>
        /// 選択しているオブジェクトをアクティブにします
        /// </summary>
        private void ActiveSelected()
        {
            if (!selectedGameObject)
                return;

            // ハイライトを表示
            selectedGameObject.HighlightSetActive(true);
            // エディターを開く
            selectedGameObject.EditorSetActive(true);
        }
    }
}
