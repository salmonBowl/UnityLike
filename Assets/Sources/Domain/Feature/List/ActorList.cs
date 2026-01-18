namespace UnityLike
{
    public class ActorList
    {
        private readonly ManagedList<Actor> actorList = new();

        /// <summary>
        /// Actorを登録します
        /// </summary>
        public void Add(Actor newActor) => actorList.Add(newActor);

        /// <summary>
        /// Actorを除外します
        /// </summary>
        public void Remove(Actor oldEntity) => actorList.Remove(oldEntity);

        /// <summary>
        /// 管理しているActorのSetUpメソッドを呼び出します
        /// </summary>
        public void SetUpAll()
        {
            actorList.ProcessAll(actor => actor.SetUp());
        }

        /// <summary>
        /// 管理しているActorのUpdateメソッドを呼び出します
        /// </summary>
        public void UpdateAll()
        {
            actorList.ProcessAll(actor => actor.Update());
        }
    }
}
