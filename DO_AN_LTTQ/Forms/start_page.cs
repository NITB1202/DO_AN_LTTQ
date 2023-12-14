using System.Net.NetworkInformation;
using System;
using System.IO;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DO_AN_LTTQ
{
    public partial class start_page : Form
    {
        bool isDragging;
        int mouseX, mouseY;

        public choose_location cl;
        public workplace wp;
        public start_page()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void subtract_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void new_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            cl=new choose_location();
            cl.spage = this;
            cl.Show();
        }
        private void open_button_Click(object sender, EventArgs e)
        {
            string defaultPath = @"C:\DataStructureVisualizations"; // duong dan mac dinh

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = defaultPath;
            openFileDialog.Filter = "DSV File|*.dsv|All Files|*.*";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".dsv")
                {
                    wp = new workplace();
                    wp.save_path = openFileDialog.FileName;
                    wp.update_label(Path.GetFileNameWithoutExtension(wp.save_path));
                    wp.load_file(wp.save_path);
                    this.Hide();
                    wp.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("Can't open file","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void task_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }
        private void task_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Cursor = Cursors.Hand;
                int deltaX = e.X - mouseX;
                int deltaY = e.Y - mouseY;
                this.Location = new System.Drawing.Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }
        private void task_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
            Cursor = Cursors.Default;
        }

    }
}