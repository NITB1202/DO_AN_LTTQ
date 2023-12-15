using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DO_AN_LTTQ
{
    public partial class choose_location : Form
    {
        bool isDragging;
        int mouseX, mouseY;

        string select = @"C:\DataStructureVisualizations";
        string path;

        public start_page spage;
        public choose_location()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private bool check_invalid(string str)
        {
            char[] invalid = { '\\', '/', ':', '*', '?', '"', '<', '>', '|', ' ' };
            foreach (char c in str)
            {
                if (invalid.Contains(c))
                    return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            spage.Show();
            this.Close();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            spage.Show();
            this.Close();
        }

        private void done_button_Click(object sender, EventArgs e)
        {
            //tao thu muc
            if (path == null)
            {
                errorProvider1.SetIconAlignment(project_name_bar, ErrorIconAlignment.MiddleRight);
                errorProvider1.SetIconPadding(project_name_bar, 5);
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProvider1.SetError(project_name_bar, "Invalid or empty project name");
                done_button.Enabled = false;
                return;
            }
            Directory.CreateDirectory(path);
            //tao file.dsv
            string file_path = path + "\\" + project_name_bar.Text + ".dsv";
            FileStream temp = File.Create(file_path);
            temp.Close();
            //mo man hinh lam viec chinh
            workplace wp = new workplace();
            wp.update_label(project_name_bar.Text);
            wp.save_path = file_path;
            wp.ShowDialog();
            spage.Close();
        }

        private void more_button_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.InitialDirectory = @"C:\";
                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    string select = dialog.SelectedPath;
                    project_location_bar.Text = dialog.SelectedPath;
                }
            }
        }
        private void done_button_EnabledChanged(object sender, EventArgs e)
        {
            if (!done_button.Enabled)
                done_button.BackColor = Color.DimGray;
            else
                done_button.BackColor = Color.Black;
        }
        private void project_name_bar_TextChanged(object sender, EventArgs e)
        {
            //kiem tra ten project co hop le hay khong
            string str = project_name_bar.Text;
            path = select + "\\" + project_name_bar.Text;

            if (str.Length == 0 || check_invalid(str) || Directory.Exists(path))
            {
                errorProvider1.SetIconAlignment(project_name_bar, ErrorIconAlignment.MiddleRight);
                errorProvider1.SetIconPadding(project_name_bar, 5);
                errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

                //set loi
                if (Directory.Exists(path))
                    errorProvider1.SetError(project_name_bar, "The project already exists");
                else
                    errorProvider1.SetError(project_name_bar, "Invalid or empty project name");
                done_button.Enabled = false;
            }
            else
            {
                errorProvider1.Clear();
                done_button.Enabled = true;
            }
        }

        private void choose_location_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                done_button.PerformClick();
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
