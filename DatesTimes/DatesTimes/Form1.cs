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

        private DateTime _today;

        public DateTime Today
        {
            get { return _today; }
            set { _today = value; }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timTime.Enabled = true;
        }

        private void timTime_Tick(object sender, EventArgs e)
        {
            Today = DateTime.Now;
            lblDayOfWeek.Text = Today.DayOfWeek.ToString();
            lblMonth.Text = Today.ToString("MMMM");
            lblYear.Text = Today.Year.ToString();
            lblDayOfMonth.Text = Today.Day.ToString();
            lblTime.Text = Today.ToLongTimeString();
        }
    }
}