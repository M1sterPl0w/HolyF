using System.Collections;
using HolyF.CodeAnalysis.Syntax;

namespace HolyF.CodeAnalysis
{
    public class Diagnostic
    {
        public TextSpan Span { get; }
        public string Message { get; }

        public Diagnostic(TextSpan span, string message)
        {
            Span = span;
            Message = message;
        }

        public override string ToString() => Message;
    }

    public sealed class DiagnosticBag : IEnumerable<Diagnostic>
    {
        private readonly List<Diagnostic> _diagnostics = new List<Diagnostic>();

        public IEnumerator<Diagnostic> GetEnumerator() => _diagnostics.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal void AddRange(DiagnosticBag diagnostics)
        {
            _diagnostics.AddRange(diagnostics._diagnostics);
        }

        private void Report(TextSpan span, string message)
        {
            var diagnostic = new Diagnostic(span, message);
            _diagnostics.Add(diagnostic);
        }

        internal void ReportInvalidNumber(TextSpan span, string text, Type type)
        {
            var message = $"The number <{text}> isn't a valid <{type}>.";
            Report(span, message);
        }

        internal void ReportBadCharacter(int position, char character)
        {
            var message = $"Bad character input: <{character}>.";
            var span = new TextSpan(position, 1);
            Report(span, message);
        }

        internal void ReportUndefinedUnaryOperator(TextSpan span, string operatorText, Type operandType)
        {
            var message = $"Unary operator <{operatorText}> is not defined for type <{operandType}>";
            Report(span, message);
        }

        internal void ReportUnexpectedToken(TextSpan span, SyntaxKind actualKind, SyntaxKind expectedKind)
        {
            var message = $"Unexpected token <{actualKind}>, expected <{expectedKind}>.";
            Report(span, message);
        }

        internal void ReportUndefinedBinaryOperator(TextSpan span, string operatorText, Type leftType, Type rightType)
        {
            var message = $"Binary operator <{operatorText}> is not defined for type <{leftType}> and/or <{rightType}>";
            Report(span, message);
        }

        internal void ReportUndefinedName(TextSpan span, string name)
        {
            var message = $"Variable <{name}> doesn't exists";
            Report(span, message);
        }
    }
}