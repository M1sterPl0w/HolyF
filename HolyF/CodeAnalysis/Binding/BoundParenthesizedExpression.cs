namespace HolyF.CodeAnalysis.Binding
{
    internal sealed class BoundParenthesizedExpression : BoundExpression
    {
        public object Value { get; }

        public override BoundNodeKind Kind => BoundNodeKind.ParenthesizedExpression;
        public override Type Type => Value.GetType();

        public BoundParenthesizedExpression(object value)
        {
            Value = value;
        }
    }
}