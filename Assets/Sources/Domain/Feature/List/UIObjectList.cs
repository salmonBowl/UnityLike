namespace UnityLike
{
    public class UIObjectList
    {
        private readonly ManagedList<UIObject> uiObjectList = new();

        /// <summary>
        /// Actorを登録します
        /// </summary>
        public void Add(UIObject newActor) => uiObjectList.Add(newActor);

        /// <summary>
        /// Actorを除外します
        /// </summary>
        public void Remove(UIObject oldEntity) => uiObjectList.Remove(oldEntity);

        /// <summary>
        /// 管理しているActorのSetUpメソッドを呼び出します
        /// </summary>
        public void SetUpAll()
        {
            uiObjectList.ProcessAll(actor => actor.SetUp());
        }

        /// <summary>
        /// 管理しているActorのUpdateメソッドを呼び出します
        /// </summary>
        public void UpdateAll()
        {
            uiObjectList.ProcessAll(actor => actor.Update());
        }
    }
}
