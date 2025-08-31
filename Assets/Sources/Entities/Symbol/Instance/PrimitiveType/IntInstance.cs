
namespace UnityLike.Entities.Symbol
{
    public class IntInstance : NumberInstance
    {
        public override Class Type => IntClass.Single;

        public IntInstance(int value)
        {
            Value = value;
        }

        public override float AsFloat()
        {
            return (float)Value;
        }
    }
}
