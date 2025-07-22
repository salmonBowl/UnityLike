using NUnit.Framework;
using System.Collections.Generic;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.Test
{
    public class ParserTest
    {
        readonly string mockSourceCode = 
            "int x = 0;" +
            "x = x + 1;" +
            "" +
            "";

        Token[] tokenArray;

        [SetUp]
        public void SetupTokenArray()
        {
            Lexer lexer = new(mockSourceCode);
            tokenArray = GenerateTokenArray(lexer);
        }

        [Test]
        public void TestParser()
        {
            Parser parser = new(tokenArray);

            parser.Parse();

            foreach(StatementNode statement in parser.GetParsedStatements())
            {
                statement.LogThis();
            }
        }

        private Token[] GenerateTokenArray(Lexer lexer)
        {
            List<Token> tokenList = new();
            Token currentToken;

            while ((currentToken = lexer.GetNextToken()).TokenType != TokenType.EOF)
            {
                tokenList.Add(currentToken);
            }
            tokenList.Add(currentToken);

            return tokenList.ToArray();
        }
    }
}
