using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Class : Class
    {
        public static Vector3Class Instance => new();

        public override string Name => "Vector3";

        public override Instance NewInstance(Instance[] args, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            // 引数の数が3つであることを確認
            if (args.Length != 3)
            {
                throw new InvalidArgumentException(3, rightParen);
            }

            // 各引数の型をチェックし、値を代入
            if (args[0] is not NumberInstance numberX)
            {
                throw new ArgumentInvalidTypeException("float", argTokens[0]);
            }
            if (args[1] is not NumberInstance numberY)
            {
                throw new ArgumentInvalidTypeException("float", argTokens[1]);
            }
            if (args[2] is not NumberInstance numberZ)
            {
                throw new ArgumentInvalidTypeException("float", argTokens[2]);
            }

            float x = numberX.AsFloat();
            float y = numberY.AsFloat();
            float z = numberZ.AsFloat();
            return new Vector3Instance(x, y, z);
        }

        public override void TryMemberExists(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
