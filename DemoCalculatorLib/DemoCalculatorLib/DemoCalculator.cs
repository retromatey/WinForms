using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DemoCalculatorLib
{
    public partial class DemoCalculator : UserControl
    {
        private readonly CalculatorState _calculatorState;
        public CalculatorState CalculatorState
        {
            get { return _calculatorState; }
        }

        public DemoCalculator()
        {
            InitializeComponent();
            _calculatorState = new CalculatorState();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CalculatorState.CurrentInput))
            {
                // Clear everything (current input, history, etc)
                CalculatorState.ClearAll();
            }
            else
            {
                // Clear entry
                CalculatorState.ClearCurrentInput();
            }

            textBox1.Text = CalculatorState.CurrentInput;
        }

        private void equalsButton_Click(object sender, EventArgs e)
        {
            CalculatorState.InsertOperationSet(CalculatorState.CurrentInput, CalculatorOperation.Equals);
            textBox1.Text = CalculatorState.GetCurrentTotalStr();

            //listView1.Items.Add("test");
        }

        private void changeSignButton_Click(object sender, EventArgs e)
        {

        }



        private void OperatorButtonClicked(CalculatorOperation operation)
        {
            CalculatorState.InsertOperationSet(CalculatorState.CurrentInput, operation);
            textBox1.Text = CalculatorState.GetCurrentTotalStr();
        }

        private void additionButton_Click(object sender, EventArgs e)
        {
            OperatorButtonClicked(CalculatorOperation.Add);
        }

        private void divisionButton_Click(object sender, EventArgs e)
        {
            OperatorButtonClicked(CalculatorOperation.Divide);
        }

        private void multiplicationButton_Click(object sender, EventArgs e)
        {
            OperatorButtonClicked(CalculatorOperation.Multiply);
        }

        private void subtractionButton_Click(object sender, EventArgs e)
        {
            OperatorButtonClicked(CalculatorOperation.Subtract);
        }


        private void decimalButton_Click(object sender, EventArgs e)
        {
        }



        #region Number Buttons

        private void NumberButtonClicked(string numStr)
        {
            CalculatorState.ConcatNumToCurrentInput(numStr);
            textBox1.Text = CalculatorState.CurrentInput;
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("0");
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("1");
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("2");
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("3");
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("4");
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("5");
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("6");
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("7");
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("8");
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            NumberButtonClicked("9");
        }

        #endregion Number Buttons
    }
}