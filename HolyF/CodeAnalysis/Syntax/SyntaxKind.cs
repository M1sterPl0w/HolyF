namespace HolyF.CodeAnalysis.Syntax
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
        ExclamationMarkToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        ExclamationMarkEqualsToken,
        IdentifierToken,

        // Expressions
        LiteralExpression,
        BinaryExpression,
        ParenthesizedExpression,
        UnaryExpression,

        // Keywords
        TrueKeyword,
        FalseKeyword,
    }
}