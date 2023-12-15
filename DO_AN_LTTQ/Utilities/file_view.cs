using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_LTTQ.Utilities
{
    public partial class file_view : UserControl
    {
        public Label file_name;
        public Label date_modify;
        public string path;
        public start_page startpage;
        public file_view()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        private void file_view_Click(object sender, EventArgs e)
        {
            startpage.load_file(path);
        }

        private void file_name_Click(object sender, EventArgs e)
        {
            startpage.load_file(path);
        }

        private void date_modify_Click(object sender, EventArgs e)
        {
            startpage.load_file(path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            startpage.load_file(path);
        }
    }
}
