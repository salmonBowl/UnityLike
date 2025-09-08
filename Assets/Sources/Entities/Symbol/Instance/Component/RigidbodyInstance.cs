using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class RigidbodyInstance : NonOperationInstance
    {
        public override Class Type => RigidbodyClass.Single;

        public RigidbodyInstance(UnityEngine.Rigidbody rigidbody)
        {
            Variable Mass = new("mass", FloatClass.Single);
            Variable UseGravity = new("useGravity", BoolClass.Single);
            Variable IsKinematic = new("isKinematic", new BoolClass());
            Variable Velocity = new("velocity", Vector3Class.Single);
            
            Member.AddMember(Mass, UseGravity, IsKinematic, Velocity);

            Mass.Value = new FloatInstance(rigidbody.mass);
            UseGravity.Value = new BoolInstance(rigidbody.useGravity);
            IsKinematic.Value = new BoolInstance(rigidbody.isKinematic);
            Velocity.Value = new Vector3Instance(rigidbody.linearVelocity);
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen)
        {
            void ArgCheck(params string[] expected)
            {
                int argCount = expected.Length;
                if (args.Length != argCount)
                {
                    throw new InvalidArgumentException(expected.Length, rightParen);
                }
                for (int i = 0; i < argCount; i++)
                {
                    if (!Castable(args[i], expected[i]))
                    {
                        throw new ArgumentInvalidTypeException(expected[i], nameToken);
                    }
                }
            }

            // ŠÖ”ŽÀs‚Ì‚½‚ß‚Éƒƒ“ƒo[•Ï”‚ðŽæ“¾‚µ‚Ä‚¨‚«‚Ü‚·
            //Vector3 position = ((Vector3Instance)GetMember("position")).AsVector3();
            //Vector3 eulerAngles = ((Vector3Instance)GetMember("eulerAngles")).AsVector3();

            switch (name)
            {
                case "AddForce":
                    ArgCheck("Vector3");
                    Vector3Instance add = (Vector3Instance)args[0];
                    Vector3Instance velocity = (Vector3Instance)GetMember("position");
                    SetMember("velocity", velocity.Add(add));
                    return null;
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
