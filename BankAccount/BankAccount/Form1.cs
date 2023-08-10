using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankAccount
{
    public partial class frmBankAccount : Form
    {
        private double _deposit;
        private int _months;
        private double _interest;
        private double _final;
        
        public double Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        public int Months
        {
            get { return _months; }
            set { _months = value; }
        }

        public double Interest
        {
            get { return _interest; }
            set { _interest = value; }
        }

        public double Final
        {
            get { return _final; }
            set { _final = value; }
        }

        public frmBankAccount()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBalance.Text = txtDeposit.Text = txtInterest.Text = txtNumMonths.Text = string.Empty;
            txtDeposit.Focus();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (txtDeposit.Text == "" || 
                txtInterest.Text == "" || 
                txtNumMonths.Text == "")
            {
                MessageBox.Show("Error Input", "Please fix the input", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                double interestRate;
                Deposit = Convert.ToDouble(txtDeposit.Text);
                Interest = Convert.ToDouble(txtInterest.Text);
                Months = Convert.ToInt32(txtNumMonths.Text);

                interestRate = Interest / 1200;

                if (Interest == 0)
                {
                    Final = Deposit * Months;
                }
                else
                {
                    Final = Deposit * (Math.Pow(1 + interestRate, Months) - 1) / interestRate;
                }

                //txtBalance.Text = Final.ToString("C");
                txtBalance.Text = string.Format("{0:f2}", Final);
            }
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;  // what is this exactly?
            }
            else if (e.KeyChar == 13)
            {
                txtInterest.Focus();
            }
            else if (e.KeyChar == '.')
            {
                if (txtDeposit.Text.IndexOf('.') == -1)
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

        private void txtInterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 13)
            {
                txtNumMonths.Focus();
            }
            else if (e.KeyChar == '.')
            {
                if (txtInterest.Text.IndexOf('.') == -1)
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

        private void txtNumMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}