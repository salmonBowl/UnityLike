
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Instance : Instance
    {
        public override Class Type => Vector3Class.Single;

        public Vector3Instance(float x, float y, float z)
        {
            Variable X = new("x", Type);
            Variable Y = new("y", Type);
            Variable Z = new("z", Type);
            Member.AddMember(X, Y, Z);

            X.Value = new FloatInstance(x);
            Y.Value = new FloatInstance(y);
            Z.Value = new FloatInstance(z);
        }

        public override Variable GetMember(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
