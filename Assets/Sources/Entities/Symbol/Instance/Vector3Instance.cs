
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Instance : Instance
    {
        public override Class Type => Vector3Class.Single;

        public VariableTable Member { get; } = new(null);

        public Vector3Instance(float x, float y, float z)
        {
            Variable X = new("x", FloatInstance.Single);
            Variable Y = new("y", FloatInstance.Single);
            Variable Z = new("z", FloatInstance.Single);
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
