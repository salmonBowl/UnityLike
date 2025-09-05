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
        public static NumberLiteralNode NumberLiteralNode(Token number)
        {
            // 文字列が.またはfを含むかチェック
            if (number.Value.Contains('.') || number.Value.Contains('f'))
            {
                // float型として処理
                float floatValue;
                if (number.Value.EndsWith("f", System.StringComparison.OrdinalIgnoreCase))
                {
                    // fを取り除いてパース
                    floatValue = float.Parse(number.Value[..^1]);
                }
                else
                {
                    floatValue = float.Parse(number.Value);
                }
                return new FloatLiteralNode(floatValue, TokenToColoredToken(number));
            }
            else
            {
                // 整数として処理
                int intValue = int.Parse(number.Value);
                return new IntLiteralNode(intValue, TokenToColoredToken(number));
            }
        }
        public static BoolLiteralNode TrueLiteralNode(Token value)
        {
            return new BoolLiteralNode(true, TokenToColoredToken(value));
        }
        public static BoolLiteralNode FalseLiteralNode(Token value)
        {
            return new BoolLiteralNode(false, TokenToColoredToken(value));
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
                throw new KeyNotFoundException(
                    "SourceCodeRebuilder : 指定されたTokenTypeにつける色がConstantsで登録されていません");
            }

            string syntaxColor = TokenConstants.syntaxHighlightColors[token.TokenType];
            return syntaxColor;
        }
    }
}