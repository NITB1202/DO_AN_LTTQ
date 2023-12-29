using System.Net.NetworkInformation;
using System;
using System.IO;
using Microsoft.VisualBasic.Devices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DO_AN_LTTQ.Utilities;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Diagnostics;

namespace DO_AN_LTTQ
{
    public partial class start_page : Form
    {
        bool isDragging;
        int mouseX, mouseY;

        public choose_location cl;
        public workplace wp;
        public List<FileInfo> file_list;
        public start_page()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            wp = new workplace();
            file_list = new List<FileInfo>();
            GetFile();
            AddToPanel(file_list);
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
            cl = new choose_location();
            cl.spage = this;
            cl.Show();
        }
        private void open_button_Click(object sender, EventArgs e)
        {
            string defaultPath = @"C:\DataStructureVisualizations"; // duong dan mac dinh
            if (!Directory.Exists(defaultPath))
                defaultPath = @"C:\";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = defaultPath;
            openFileDialog.Filter = "DSV File|*.dsv|All Files|*.*";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(openFileDialog.FileName) == ".dsv")
                    load_file(openFileDialog.FileName);
                else
                    MessageBox.Show("Can't open file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void GetFile()
        {
            string path = @"C:\DataStructureVisualizations";
            if (Directory.Exists(path))
            {
                DirectoryInfo direc_info = new DirectoryInfo(path);
                FileInfo[] file_main = direc_info.GetFiles();
                foreach (FileInfo f in file_main)
                    if (Path.GetExtension(f.Name) == ".dsv")
                        file_list.Add(f);
                DirectoryInfo[] child_direc = direc_info.GetDirectories();
                foreach (DirectoryInfo direc in child_direc)
                {
                    FileInfo[] files = direc.GetFiles();
                    foreach (FileInfo file in files)
                        if (Path.GetExtension(file.Name) == ".dsv")
                            file_list.Add(file);
                }
            }
        }
        private void AddToPanel(List<FileInfo> list)
        {
            foreach (FileInfo file in list)
            {
                file_view fv = new file_view();
                fv.file_name.Text = Path.GetFileNameWithoutExtension(file.Name);
                fv.date_modify.Text = file.LastAccessTime.ToString();
                fv.path = file.FullName;
                fv.startpage = this;
                file_panel.Controls.Add(fv);
            }
        }
        public void load_file(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("The file has been removed or changed location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            wp.save_path = path;
            wp.update_label(Path.GetFileNameWithoutExtension(wp.save_path));
            wp.load_file(wp.save_path);
            this.Hide();
            wp.ShowDialog();
            this.Close();
        }
        private void search_bar_TextChanged(object sender, EventArgs e)
        {
            file_panel.Controls.Clear();
            if (search_bar.Text.Length == 0)
                AddToPanel(file_list);
            else
            {
                string str = search_bar.Text;
                str = str.ToLower();
                List<FileInfo> fit_file = new List<FileInfo>();
                foreach (FileInfo file in file_list)
                {
                    string name = Path.GetFileNameWithoutExtension(file.Name);
                    name = name.ToLower();
                    if (name.Length >= str.Length)
                        name = name.Substring(0, str.Length);
                    if (str == name)
                        fit_file.Add(file);
                }
                AddToPanel(fit_file);
            }

        }

        private void support_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "cmd",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Mở trình duyệt web khi link được click
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();
                process.StandardInput.WriteLine("start https://docs.google.com/forms/d/e/1FAIpQLSdS0i8A6Gr7AuaHuFqliABDYnrWIu-jlfJ_JKYfJNLN1mBxGQ/viewform");
                process.StandardInput.Flush();
                process.StandardInput.Close();
                process.WaitForExit();
            }
        }
    }
}