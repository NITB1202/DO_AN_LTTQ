using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DO_AN_LTTQ.Forms
{
    public partial class splash_screen : Form
    {
        System.Windows.Forms.Timer timer;
        int sec = 0;
        public splash_screen()
        {
            InitializeComponent();
            DoubleBuffered = true;
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            sec++;
            if (sec == 3)
            {
                timer.Stop();
                this.Close();
            }
        }
    }
}
