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

        private void project_panel_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 255, 255, 255));
            e.Graphics.DrawLine(pen, 10, 32, 540, 32);
        }

        private void new_button_Click(object sender, EventArgs e)
        {
            Form2 p = new Form2();
            Hide();
            p.ShowDialog();
            Close();
        }
        private void subtract_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}