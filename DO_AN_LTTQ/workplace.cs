using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_LTTQ
{
    public partial class workplace : Form
    {
        private TextBox input;
        private Label l;
        public string save_path;
        public workplace()
        {
            InitializeComponent();
            spd_cbb.SelectedIndex = 1;
            data_type_cbb.SelectedIndex = 0;
            input_type_cbb.SelectedIndex = 0;
        }
        public void update_label(string lb)
        {
            projectname_label.Text = lb;
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White, 3);
            e.Graphics.DrawLine(p, 0, 38, 33, 38);
            e.Graphics.DrawLine(p, 272, 38, 1400, 38);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void check_totalnode()
        {

        }
        private void input_type_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (input_type_cbb.SelectedIndex)
            {
                case 0:
                    {
                        if (panel2.Controls.Contains(input))
                            panel2.Controls.Remove(input);
                        l = new Label();
                        l.Text = "Total node: ";
                        l.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        l.ForeColor = Color.White;
                        l.Location = new Point(11, 310);
                        panel2.Controls.Add(l);

                        input = new TextBox();
                        input.Height = 100;
                        input.Width = 50;
                        input.Location = new Point(125, 310);
                        panel2.Controls.Add(input);
                        input.MaxLength = 4;
                        input.KeyPress += new KeyPressEventHandler(height_tb_KeyPress);
                        break;
                    }
                case 1:
                    {
                        if (panel2.Controls.Contains(input))
                        {
                            panel2.Controls.Remove(l);
                            panel2.Controls.Remove(input);
                        }
                        input = new TextBox();
                        input.Height = 150;
                        input.Width = 255;
                        input.Multiline = true;
                        input.ScrollBars = ScrollBars.Vertical;
                        input.Location = new Point(55, 320);
                        panel2.Controls.Add(input);
                        break;
                    }
                case 2:
                    {
                        if (panel2.Controls.Contains(input))
                        {
                            panel2.Controls.Remove(l);
                            panel2.Controls.Remove(input);
                        }
                        OpenFileDialog open = new OpenFileDialog();
                        open.InitialDirectory = @"C:\";
                        open.Filter = "Text|*.txt";
                        if (open.ShowDialog() == DialogResult.OK)
                        {

                        }
                        break;
                    }
            }
        }

        private void height_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void width_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            step_lbl.Text = "Step: " + trackBar1.Value.ToString() + "/" + trackBar1.Maximum.ToString();
        }
    }
}
