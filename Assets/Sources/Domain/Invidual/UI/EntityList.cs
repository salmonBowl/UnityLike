namespace UnityLike
{
    /// <summary>
    /// IEntityを管理するクラスです
    /// </summary>
    public class EntityList
    {
        private readonly ManagedList<IEntity> entityList = new();

        /// <summary>
        /// Entityを登録します
        /// </summary>
        public void Add(IEntity newEntity) => entityList.Add(newEntity);

        /// <summary>
        /// Entityを除外します
        /// </summary>
        public void Remove(IEntity oldEntity) => entityList.Remove(oldEntity);

        /// <summary>
        /// 管理しているEntityのDrawメソッドを呼び出します
        /// </summary>
        public void DrawAll()
        {
            entityList.ProcessAll(entity => entity.DrawUpdate());
        }
    }
}
