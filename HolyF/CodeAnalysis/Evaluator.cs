using HolyF.CodeAnalysis.Binding;

namespace HolyF.CodeAnalysis
{
    internal sealed class Evaluator
    {
        private readonly BoundExpression _root;
        private readonly Dictionary<VariableSymbol, object?> _variables;

        public Evaluator(BoundExpression root, Dictionary<VariableSymbol, object?> variables)
        {
            _root = root;
            _variables = variables;
        }

        public object? Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private object? EvaluateExpression(BoundExpression node)
        {
            if (node is BoundLiteralExpression n)
            {
                return n.Value;
            }
            else if (node is BoundVariableExpression v)
            {
                var value = _variables[v.Variable];
                return value;
            }
            else if (node is BoundAssignmentExpression a)
            {
                var value = EvaluateExpression(a.Expression);
                _variables[a.Variable] = value;
                return value;
            }
            else if (node is BoundUnaryExpression u)
            {
                var operand = EvaluateExpression(u.Operand);
                switch (u.Op.Kind)
                {
                    case BoundUnaryOperatorKind.Negation:
                        return operand != null ? -(int)operand : default;
                    case BoundUnaryOperatorKind.Identity:
                        return operand != null ? (int)operand : default;
                    case BoundUnaryOperatorKind.LogicalNegation:
                        return operand != null ? !(bool)operand : default;
                    default:
                        throw new Exception($"Unexpected unary operator <{u.Op.Kind}>");
                }
            }
            else if (node is BoundBinaryExpression b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);

                if (left != null && right != null)
                {
                    switch (b.Op.Kind)
                    {
                        case BoundBinaryOperatorKind.Addition:
                            return (int)left + (int)right;
                        case BoundBinaryOperatorKind.Subtraction:
                            return (int)left - (int)right;
                        case BoundBinaryOperatorKind.Multiplication:
                            return (int)left * (int)right;
                        case BoundBinaryOperatorKind.Division:
                            return (int)left / (int)right;
                        case BoundBinaryOperatorKind.LogicalAnd:
                            return (bool)left && (bool)right;
                        case BoundBinaryOperatorKind.LogicalOr:
                            return (bool)left || (bool)right;
                        case BoundBinaryOperatorKind.Equals:
                            return Equals(left, right);
                        case BoundBinaryOperatorKind.NotEquals:
                            return !Equals(left, right);
                        default:
                            throw new Exception($"Unexpected binary operator <{b.Op.Kind}>");
                    }
                };

                throw new Exception("Left and/or right value is <null>");
            }

            throw new Exception($"Unexpected node {node.Kind}");
        }
    }
}