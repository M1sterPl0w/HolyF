namespace HolyF.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {

        public BoundUnaryOperator Op { get; }
        public BoundExpression Operand { get; }

        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;
        public override Type Type => Op.ResultType;

        public BoundUnaryExpression(BoundUnaryOperator op, BoundExpression operand)
        {
            Op = op;
            Operand = operand;
        }
    }
}