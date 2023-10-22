using System.Net.NetworkInformation;
using System;
using System.IO;

namespace DO_AN_LTTQ
{
    public partial class start_page : Form
    {
        private workplace wp;
        public start_page()
        {
            InitializeComponent();
            wp = new workplace();
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
            choose_location f = new choose_location();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
        private void open_button_Click(object sender, EventArgs e)
        {
            string defaultPath = @"C:\DataStructureVisualizations"; // duong dan mac dinh

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = defaultPath;
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                wp.save_path = openFileDialog.FileName;
                wp.update_label(Path.GetFileNameWithoutExtension(wp.save_path));
                this.Hide();
                wp.ShowDialog();
                this.Close();
            }
        }
    }
}