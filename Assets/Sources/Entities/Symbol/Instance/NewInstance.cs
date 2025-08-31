
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// new式でのインスタンス生成に使用します。new式の形をシングルトンのメンバー関数だと見立てる設計を取りました。
    /// </summary>
    public class NewInstance : Instance
    {
        public override Class Type => Vector3Class.Single;

        public override Variable GetMember(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
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
    }
}