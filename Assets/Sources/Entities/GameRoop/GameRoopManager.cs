
namespace UnityLike.Entities.GameRoop
{
    public class GameRoopManager
    {
        public GameRoopStatement Statement { get; private set; }

        public void SetStatement(GameRoopStatement value)
        {
            Statement = value;
        }
    }
}