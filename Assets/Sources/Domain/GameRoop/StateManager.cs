
namespace UnityLike.Entities.GameRoop
{
    public class StateManager
    {
        public GameRoopState State { get; private set; }

        public void SetStatement(GameRoopState value)
        {
            State = value;
        }
    }
}