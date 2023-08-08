using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class frmMainForm : Form
    {
        public frmMainForm()
        {
            InitializeComponent();
        }

        private DateTime _start;

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private DateTime _stop;

        public DateTime Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        private TimeSpan _elapsedTime;

        public TimeSpan ElapsedTime
        {
            get { return _elapsedTime; }
            set { _elapsedTime = value; }
        }




        private void btnStart_Click(object sender, EventArgs e)
        {
            Start = DateTime.Now;
            txtStart.Text = Start.ToLongTimeString();
            txtStop.Text = string.Empty;
            txtElapsed.Text = string.Empty;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop = DateTime.Now;
            txtStop.Text = Stop.ToLongTimeString();
            ElapsedTime = Stop.Subtract(Start);
            txtElapsed.Text = ElapsedTime.Seconds.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}