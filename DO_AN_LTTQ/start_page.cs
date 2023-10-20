namespace DO_AN_LTTQ
{
    public partial class start_page : Form
    {
        public start_page()
        {
            InitializeComponent();
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
            string defaultPath = @"C:\"; // duong dan mac dinh

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = defaultPath;
            openFileDialog.Filter = "All Files|*.*";
            openFileDialog.Title = "Select Files";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // xu li khi chon tep
                string filePath = openFileDialog.FileName;
                // thuc hien hanh dong
                try
                {
                    // Đọc nội dung của tệp
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string fileContent = sr.ReadToEnd();
                        // Hiển thị nội dung tệp lên form

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}