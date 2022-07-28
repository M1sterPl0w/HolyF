namespace HolyF.CodeAnalysis
{
    public enum SyntaxKind
    {
        // Tokens
        EndOfFileToken,
        BadToken,
        WhitespaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,

        // Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression,
        UnaryExpression
    }
}