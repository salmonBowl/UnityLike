using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections.Generic;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.Test
{
    public class ParserTest
    {
        [Test]
        public void TestParser_Declaration()
        {
            string source = "int x = 0;";
            TestParseStatements(source);
        }
        [Test]
        public void TestParser_Assignment()
        {
            string source = "x = x + 1;";
            TestParseStatements(source);
        }

        private void TestParseStatements(string source)
        {
            Lexer lexer = new(source);
            Token[] tokenArray = GenerateTokenArray(lexer);
            Parser parser = new(tokenArray);
            parser.Parse();

            StatementNode firstParsedStatement = parser.GetParsedStatements()[0];

            firstParsedStatement.LogThis();

            string expectedText = source;
            string parsedText = firstParsedStatement.ToPrettyString();
            Assert.AreEqual(expectedText, parsedText);
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
