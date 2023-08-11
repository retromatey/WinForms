using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FlashingLabel
{
    public partial class FlashingLabel : Label
    {
        private Timer _flashTimer;

        public Timer FlashTimer
        {
            get { return _flashTimer; }
            set { _flashTimer = value; }
        }

        public FlashingLabel()
        {
            //InitializeComponent();
            BackColor = Color.White;
            ForeColor = Color.Red;
            BorderStyle = BorderStyle.Fixed3D;

            FlashTimer = new Timer();
            FlashTimer.Tick += new EventHandler(timFlash_Tick);
            FlashTimer.Enabled = false;
            FlashTimer.Interval = 500;
        }

        public void StartFlash()
        {
            FlashTimer.Enabled = true;
        }

        public void StopFlash()
        {
            FlashTimer.Enabled = false;
        }

        private void timFlash_Tick(object sender, EventArgs e)
        {
            ForeColor = ForeColor == Color.Red
                      ? Color.White
                      : Color.Red;

            //BackColor = BackColor == Color.Red
            //          ? Color.White
            //          : Color.Red;
        }
    }
}