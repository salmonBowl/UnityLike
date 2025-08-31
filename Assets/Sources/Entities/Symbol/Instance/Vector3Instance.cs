
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Instance : Instance
    {
        public override Class Type => Vector3Class.Instance;

        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }

        public Vector3Instance(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override Instance GetMember(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
        public override void SetMember(string member, Instance value, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
