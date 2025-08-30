
namespace UnityLike.Entities.Symbol
{
    public class IntInstance : Instance
    {
        public override Class Type => IntClass.Instance;
        
        public int Value { get; set; }

        public IntInstance(int value)
        {
            Value = value;
        }
    }
}
