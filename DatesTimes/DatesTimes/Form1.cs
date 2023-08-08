using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DatesTimes
{
    public partial class frmDate : Form
    {
        public frmDate()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timTime.Enabled = true;
            DateTime today;
            today = DateTime.Now;
            lblDayOfWeek.Text = today.DayOfWeek.ToString();
            lblMonth.Text = today.ToString("MMMM");
            lblYear.Text = today.Year.ToString();
            lblDayOfMonth.Text = today.Day.ToString();
            lblTime.Text = today.ToLongTimeString();
        }
    }
}