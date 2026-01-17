namespace UnityLike
{
    /// <summary>
    /// Sceneの種類を表すクラスです。enumの仕組みをクラスで表現しています。
    /// </summary>
    public abstract class SceneType
    {
        // SceneType.TitleとSceneType.Titleが一致していることを検出します
        public bool IsMatchFor(SceneType opponent)
        {
            var currentType = GetType();
            var opponentType = opponent.GetType();

            return currentType == opponentType;
        }

        // == に関するオペレーター定義
        public static bool operator ==(SceneType a, SceneType b) => a.IsMatchFor(b);
        public static bool operator !=(SceneType a, SceneType b) => !a.IsMatchFor(b);
        public override int GetHashCode() => GetType().GetHashCode();
        public override bool Equals(object obj) => (obj is SceneType other) && (this == other);

        // 新しいSceneを生成します。現状未使用。
        //public abstract Scene CreateScene();

        public class Title : SceneType
        {
            /*public override Scene CreateScene()
            {
                return new TitleScene();
            }*/
        }

        public class Game : SceneType
        {
            /*public override Scene CreateScene()
            {
                return new GameScene();
            }*/
        }
    }
}
