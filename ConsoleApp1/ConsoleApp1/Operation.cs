using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Operation
    {
        List<char> _operators = new List<char> { '/', '*', '-', '+' };
        public Operation(string operationText)
        {
            var openParenthesisIndex = operationText.IndexOf("(");
            if (openParenthesisIndex > -1)
            {
                var endParenthesisIndex = operationText.IndexOf(")");

                var left = operationText.Substring(openParenthesisIndex + 1, endParenthesisIndex - 1);
                

                // Check if ended
                if (operationText.Length - 1 == endParenthesisIndex)
                {
                    Left = new Operation(left);
                    Value = Left.CalculateResult();
                }
                else
                {
                    var right = operationText.Substring(endParenthesisIndex + 2);
                    Operator = operationText.Substring(endParenthesisIndex + 1, 1);
                    OperationSide = OperationSideOfParent.NA;

                    Left = new Operation(left);
                    Right = new Operation(right);
                }
            }
            else
            {
                HandleOperations(operationText);
            }
        }

        private void HandleOperations(string operationText)
        {
            if (!operationText.Any(c => _operators.Contains(c)))
            {
                Value = double.Parse(operationText);
            }
            else
            {
                foreach (var op in _operators)
                {
                    var operatorIndex = operationText.IndexOf(op);
                    if (operatorIndex > -1)
                    {
                        var left = operationText.Substring(0, operatorIndex);
                        var right = operationText.Substring(operatorIndex + 1);
                        Operator = operationText.Substring(operatorIndex, 1);
                        OperationSide = OperationSideOfParent.NA;

                        Left = new Operation(left);
                        Right = new Operation(right);
                    }
                }
            }
        }

        public OperationSideOfParent OperationSide { get; set; }

        public Operation Left { get; set; }

        public Operation Right { get; set; }

        public string Operator { get; set; }

        public double? Value { get; set; }

        public double CalculateResult()
        {
            if (Value != null)
                return Value.Value;

            var leftValue = Left.CalculateResult();
            var rightValue = Right.CalculateResult();

            switch (Operator)
            {
                case "+": return leftValue + rightValue;
                case "-": return leftValue - rightValue;
                case "*": return leftValue * rightValue;
                case "/": return leftValue / rightValue;
            }

            throw new InvalidConstraintException();
        }
    }

    public enum OperationSideOfParent
    {
        NA,
        Left,
        Right
    }
}
