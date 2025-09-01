using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    /// <summary>
    /// ノード生成時の補助になるメソッドを集めたクラスです
    /// </summary>
    public class ASTFactory
    {
        public static IdentifierNode IdentifierNode(Token identifier)
        {
            return new IdentifierNode(TokenToColoredToken(identifier));
        }
        public static MemberAccessNode MemberAccessNode(VariableNode parent, Token dot, Token member)
        {
            ColoredToken cDot = TokenToColoredToken(dot);
            ColoredToken cMember = TokenToColoredToken(member);
            cMember.IsMember();
            return new MemberAccessNode(parent, cDot, cMember);
        }
        public static IntLiteralNode NumberLiteralNode(Token number)
        {
            int value = int.Parse(number.Value);
            return new IntLiteralNode(value, TokenToColoredToken(number));
        }

        /// <summary>
        /// TokenからUnknownExpressionNodeを生成します
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UnknownExpressionNode UnknownNode(Token token)
        {
            ColoredToken cToken = TokenToColoredToken(token);
            cToken.HasError("無効な単語です");
            return new UnknownExpressionNode(cToken);
        }

        public static ParenNode ParenNode(Token leftParen, ExpressionNode content, Token rightParen)
        {
            ColoredToken cLeftParen = TokenToColoredToken(leftParen);
            ColoredToken cRightParen = TokenToColoredToken(rightParen);
            return new ParenNode(cLeftParen, content, cRightParen);
        }

        public static UnaryExpressionNode UnaryExpressionNode(Token @operator, ExpressionNode operand)
        {
            TokenType operatorTokenType = @operator.TokenType;
            ColoredToken cOperator = TokenToColoredToken(@operator);
            return new UnaryExpressionNode(operatorTokenType, cOperator, operand);
        }

        public static BinaryExpressionNode BinaryExpressionNode(ExpressionNode leftNode, Token @operator, ExpressionNode rightNode)
        {
            TokenType operatorTokenType = @operator.TokenType;
            ColoredToken cOperator = TokenToColoredToken(@operator);
            return new BinaryExpressionNode(leftNode, operatorTokenType, cOperator, rightNode);
        }

        public static TypeNode TypeNode(Token type)
        {
            return new TypeNode(TokenToColoredToken(type));
        }

        public static NewExpressionNode NewNode(Token newToken, Token typeToken, Token leftParen, List<ExpressionNode> arguments, List<Token> commas, Token rightParen)
        {
            ColoredToken cNewToken = TokenToColoredToken(newToken);
            ColoredToken cTypeToken = TokenToColoredToken(typeToken);
            ColoredToken cLeftParen = TokenToColoredToken(leftParen);
            ColoredToken cRightParen = TokenToColoredToken(rightParen);

            ExpressionNode[] argumentArray = arguments.ToArray();
            ColoredToken[] cCommas = new ColoredToken[commas.Count];
            for (int i = 0; i < commas.Count; i++)
            {
                cCommas[i] = TokenToColoredToken(commas[i]);
            }

            return new NewExpressionNode(cNewToken, cTypeToken, cLeftParen, argumentArray, cCommas, cRightParen);
        }

        /// <summary>
        /// TokenをColoredTokenに変換します。その際TokenConstantsのdictionaryを参照します。
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static ColoredToken TokenToColoredToken(Token token)
        {
            return new ColoredToken(token.Value, token.LineCount, token.ColumnCount, GetColorFromToken(token));
        }

        static string GetColorFromToken(Token token)
        {
            if (TokenConstants.syntaxHighlightColors.ContainsKey(token.TokenType) == false)
            {
                throw new System.Collections.Generic.KeyNotFoundException(
                    "SourceCodeRebuilder : 指定されたTokenTypeにつける色がConstantsで登録されていません");
            }

            string syntaxColor = TokenConstants.syntaxHighlightColors[token.TokenType];
            return syntaxColor;
        }
    }
}