namespace DO_AN_LTTQ.AllDataStructureClass
{
    abstract class DataStructure
    {
        //cac but quan ly viec ve
        protected Pen pen = new Pen(Color.Black, 4);
        protected SolidBrush brush = new SolidBrush(Color.Black);
        protected Font font_data = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point); //font chu du lieu
        protected Font font_label = new Font("Segoe UI Historic", 12, FontStyle.Bold, GraphicsUnit.Point); //font chu label

        //timer chay animation
        public System.Windows.Forms.Timer timer;

        //bien quan li do hoa thuat toan duoc chon
        public int select_op = -1;

        // cac bien quan ly animation
        public int frame = 0;
        public int total_frame = 0;
        public int enable = -1;//bien cho chep chay animation dung voi thuat toan duoc chon
        public bool runningAnimation = false;
        public bool update_data = false;
        public Image play_image = Properties.Resources.play_32px;
        public Image pause_image = Properties.Resources.pause_32px;
        //lay dia chi cua nhung nhung thu se tac dong tren form
        protected Panel draw_range;
        protected RichTextBox code_tb;
        protected TrackBar step_trb;
        protected Label current_step;
        protected Label total_step;
        protected Button play_button;
        protected int selected_datatype;
        protected ComboBox speed_cbb;

        protected Color item_color = Color.Transparent;
        //thong tin cho label
        protected Font lb_font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
        protected Color lb_foreColor = Color.White;

        //thong tin cho textbox
        protected Font tb_font = new Font("Segoe UI", 10);
        protected int startx_tb = 45;
        protected Point first_tb_location = new Point(45, 12);
        protected int line = 12; //dung bien nay de them cai textbox tiep theo cung dong

        //thong tin picture box
        protected Image symbol = Properties.Resources.diamonds_40px;
        protected Point sb_location = new Point(8, 10);
        protected Size sb_size = new Size(30, 30);

        //thong tin panel option
        protected int opx = 3;
        protected int op_height = 50;//vi tri cua option tiep theo bang so thu tu option*op_height
        protected Size op_size = new Size(612, 50);
        public DataStructure()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;

        }
        public virtual void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            draw_range = dr;
            code_tb = c;
            step_trb = strb;
            current_step = cs;
            total_step = ts;
            selected_datatype = dt.SelectedIndex;
            play_button = pb;
            speed_cbb = spd;

            step_trb.Value = 0;
            switch (speed_cbb.SelectedIndex)
            {
                case 0:
                    {
                        timer.Interval = 2000;
                        break;
                    }
                case 1:
                    {
                        timer.Interval = 1000;
                        break;
                    }
                case 2:
                    {
                        timer.Interval = 500;
                        break;
                    }
            }
        }
        public abstract void ModifyPanel(Panel interact_panel);
        public abstract void Draw(PaintEventArgs e);
        public abstract void ChooseOption(object sender, EventArgs e);
        public bool CheckValue(TextBox tb)
        {
            string str = tb.Text;
            if (str.Contains(" "))
                return false;

            switch (selected_datatype)
            {
                case 0:
                    return IsValidInt(str);
                case 1:
                    return IsValidFloat(str);
                case 2:
                    return IsValidSingleCharacter(str);
                default:
                    return false;
            }
        }
        private bool IsValidInt(string str)
        {
            return int.TryParse(str, out _);
        }
        private bool IsValidFloat(string str)
        {
            return float.TryParse(str, out _);
        }
        private bool IsValidSingleCharacter(string str)
        {
            return str.Length == 1;
        }
        public void ShowError()
        {
            MessageBox.Show("Invalid input. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public abstract void RunAlgorithms();
        public void updateStep(int n)
        {
            code_tb.Clear();
            step_trb.Value = 0;
            total_step.Text = n.ToString();
            total_frame = n;
            step_trb.Maximum = n;
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            frame++;
            if (frame > total_frame)
            {
                timer.Stop();
                play_button.BackgroundImage = Properties.Resources.play_32px;
                runningAnimation = false;
                enable = -1;
                return;
            }
            runningAnimation = true;
            draw_range.Invalidate();
        }
        public void HighlightCurrentLine(int line)
        {
            // Đặt màu sắc của dòng hiện tại thành màu vàng
            int start = code_tb.GetFirstCharIndexFromLine(line);
            int length = code_tb.Lines[line].Length;
            code_tb.Select(start, length);

            Point caretLocation = code_tb.GetPositionFromCharIndex(start);

            //neu text vuot qua vung nhin
            if (!code_tb.ClientRectangle.Contains(caretLocation))
                code_tb.ScrollToCaret();

            code_tb.SelectionColor = Color.Yellow;
        }
        public void TurnOffHighlight()
        {
            code_tb.SelectAll();
            code_tb.SelectionColor = Color.White;
        }
        public void SetIndent()
        {
            for (int i = 0; i < code_tb.Lines.Length; i++)
            {
                code_tb.SelectionStart = code_tb.GetFirstCharIndexFromLine(i);
                code_tb.SelectionLength = code_tb.Lines[i].Length;
                code_tb.SelectionIndent = 20;
            }
        }
        public abstract void UpdateDataStructure();
        public abstract int GetEnable();
        public abstract void UpdateLocation();
    }
}
