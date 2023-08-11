using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NumericTextBox
{
    public partial class NumericTextBox : TextBox
    {
        private bool _hasDecimal;

        [Category("Behavior")]
        public bool HasDecimal
        {
            get { return _hasDecimal; }
            set { _hasDecimal = value; }
        }

        private bool _hasNegative;

        [Category("Behavior")]
        public bool HasNegative
        {
            get { return _hasNegative; }
            set { _hasNegative = value; }
        }

        public NumericTextBox()
        {
            //InitializeComponent();
            BackColor = Color.Yellow;
            ForeColor = Color.Blue;

            HasDecimal = true;
            HasNegative = false;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                if (HasDecimal)
                {
                    if (Text.IndexOf('.') == -1)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == '-')
            {
                if (HasNegative)
                {
                    if (Text.IndexOf('-') != -1 || SelectionStart != 0)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}