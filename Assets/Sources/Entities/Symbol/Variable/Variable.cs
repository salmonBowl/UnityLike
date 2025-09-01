
namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// 変数を表します。インスタンスを情報として格納します。
    /// </summary>
    public class Variable
    {
        public string Name { get; }
        public Class Type { get; }
        public Instance Value { get; set; }

        // 他の情報を後々追加予定

        public Variable(string name, Class type)
        {
            Name = name;
            Type = type;
        }
    }
}
