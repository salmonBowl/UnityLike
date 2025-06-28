using Zenject;

namespace UnityLike.UseCases.Compiler
{
    public class Lexer
    {
        private readonly string sourceCode;

        private int currntIndex;
        private int currentColumn;

        [Inject]
        public Lexer(
            string sourceCode
            )
        {
            this.sourceCode = sourceCode;
        }



    }
}