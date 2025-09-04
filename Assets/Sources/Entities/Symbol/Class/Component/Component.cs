
namespace UnityLike.Entities.Symbol
{
    public abstract class Component : Class
    {
        public override Instance GetInitalInstance()
        {
            throw new System.InvalidProgramException("コンポーネントが生成されようとしています");
        }
    }
}
