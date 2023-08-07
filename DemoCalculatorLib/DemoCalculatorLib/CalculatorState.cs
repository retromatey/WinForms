using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCalculatorLib
{
    /*
     * Things to work on:
     * - Prevent a number starting with a zero.
     */
    public class CalculatorState
    {
        private readonly List<CalculatorOperation> _operations;
        public List<CalculatorOperation> Operations { get { return _operations; } }

        private readonly List<double> _operands;
        public List<double> Operands { get { return _operands; } }

        private double _currentTotal = 0;
        public double CurrentTotal
        {
            get { return _currentTotal; }
        }

        private string _currentInput = string.Empty;
        public string CurrentInput
        {
            get { return _currentInput; }
        }

        public CalculatorState()
        {
            _operations = new List<CalculatorOperation>();
            _operands = new List<double>();
            _currentTotal = 0;
        }

        public void ConcatNumToCurrentInput(string numStr)
        {
            if (char.IsDigit(numStr[0]))
            {
                _currentInput += numStr;
            }
        }

        public void InsertOperationSet(string inputStr, CalculatorOperation operation)
        {
            bool noop = operation == CalculatorOperation.Equals && Operands.Count == 0;
            
            if (!noop)
            {
                if (operation != CalculatorOperation.Equals)
                {
                    CalculatorOperation lastOperation = Operations.Count > 0
                        ? Operations[Operations.Count - 1]
                        : CalculatorOperation.None; 
                    
                    if (lastOperation == CalculatorOperation.Equals)
                    {
                        Operations[Operations.Count - 1] = operation;
                        //Operations.Add(CalculatorOperation.Equals);
                    }
                    else
                    {
                        double input = ParseInputStr(inputStr);
                        Operands.Add(input);
                        Operations.Add(operation);
                    }
                }
                else
                {
                    CalculatorOperation lastOperation = Operations[Operations.Count - 1];

                    if (lastOperation == CalculatorOperation.Equals)
                    {
                        lastOperation = Operations[Operations.Count - 2];
                        Operations[Operations.Count - 1] = lastOperation;
                        Operations.Add(CalculatorOperation.Equals);

                        double lastOperand = Operands[Operands.Count - 1];
                        Operands.Add(lastOperand);
                    }
                    else
                    {
                        double input = ParseInputStr(inputStr);
                        Operands.Add(input);
                        Operations.Add(operation);
                    }
                }

                CalulateTotal();
                ClearCurrentInput();
            }
        }

        public void ClearCurrentInput()
        {
            _currentInput = string.Empty;
        }

        public void ClearAll()
        {
            Operations.Clear();
            Operands.Clear();
            ClearCurrentInput();
            CalulateTotal();
        }

        public void CalulateTotal()
        {
            double result = Operands.Count > 0 ? Operands[0] : 0;

            for (int operandIndex = 1; operandIndex < Operands.Count; operandIndex++)
            {
                int operationIndex = operandIndex - 1;
                CalculatorOperation operation = Operations[operationIndex];

                double operand = Operands[operandIndex];

                switch (operation)
                {
                    case CalculatorOperation.Add:
                        result += operand;
                        break;

                    case CalculatorOperation.Subtract:
                        result -= operand;
                        break;

                    case CalculatorOperation.Multiply:
                        result *= operand;
                        break;

                    case CalculatorOperation.Divide:
                        if (operand == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        else
                        {
                            result /= operand;
                        }
                        break;

                    case CalculatorOperation.Equals:
                    case CalculatorOperation.None:
                    default:
                        break;
                }
            }

            _currentTotal = result;
        }

        private double ParseInputStr(string inputStr)
        {
            if (!string.IsNullOrEmpty(inputStr))
            {
                double result;
                bool canParse = double.TryParse(inputStr, out result);

                if (canParse)
                {
                    return result;
                }
                else
                {
                    string error = string.Format("Error parsing {0}", inputStr);
                    throw new CalculatorException(error);
                }
            }
            else
            {
                throw new CalculatorException("Invalid input");
            }
        }

        public string GetCurrentTotalStr()
        {
            string result = _currentTotal.ToString();

            if (!string.IsNullOrEmpty(result) && result.Contains("."))
            {
                result = result.TrimEnd('.', '0');
            }

            return result;
        }
    }

    public class CalculatorException : Exception
    {
        public CalculatorException(string message) : base(message) { }
    }

    public class CalculatorOperationUtil
    {
        public static string ConvertToString(CalculatorOperation op)
        {
            string result = string.Empty;

            switch (op)
            {
                case CalculatorOperation.Add:
                    result = "+";
                    break;

                case CalculatorOperation.Subtract:
                    result = "-";
                    break;

                case CalculatorOperation.Multiply:
                    result = "*";
                    break;

                case CalculatorOperation.Divide:
                    result = "/";
                    break;

                case CalculatorOperation.Equals:
                    result = "=";
                    break;

                case CalculatorOperation.None:
                default:
                    break;
            }

            return result;
        }
    }

    public enum CalculatorOperation
    {
        None = 0,
        Add,
        Subtract,
        Multiply,
        Divide,
        Equals,
    }
}
