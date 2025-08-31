
namespace UnityLike.Entities.Symbol
{
    public class FloatInstance : NumberInstance
    {
        public override Class Type => FloatClass.Single;

        public FloatInstance(float value)
        {
            Value = value;
        }

        public override float AsFloat()
        {
            return (float)Value;
        }
    }
}
