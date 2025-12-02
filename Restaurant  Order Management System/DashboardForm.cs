using System.Drawing;
using System.Windows.Forms;
using System;
using Restaurant_Order_Management_System;
using System.Data;
using System.Linq;
using Restaurant__Order_Management_System;
using System.Collections.Generic;
using System.IO;

namespace Restaurant__Order_Management_System
{
    public partial class DashboardForm : Form
    {
        Form11 form11 = new Form11();
        private Action displayCurrentMealsAction;

        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;

        public static Label labelsum_num = new Label();
        private Label welcomeLabel;
        private Label label2 = new Label();

        private Label labelsum = new Label();
        private Panel panel2, panel3, panel4, panel5;
        private Panel panel_choose = new Panel();


        public static DataGridView dataGridView;
        private DataGridViewRow totalRow;

        public static string _Order_History = @"Main_Folder\List_Meals_type\Payment History.txt";
        public static bool _Is_Darke_Mode = false;
        public static bool _Is_Hide = false;

        private string _User_Choice = "";
        public static string _Search = "";
        private string _Username;

        public static string Order_History
        {
            set { _Order_History = value; }
            get { return _Order_History; }
        }
        public static bool Is_Darke_Mode
        {
            set { _Is_Darke_Mode = value; }
            get { return _Is_Darke_Mode; }
        }
        public static bool Is_Hide
        {
            set { _Is_Hide = value; }
            get { return _Is_Hide; }
        }
        private string User_Choice
        {
            set { _User_Choice = value; }
            get { return _User_Choice; }
        }
        public static string Search
        {
            set { _Search = value; }
            get { return _Search; }
        }
        private string Username
        {
            set { _Username = value; }
            get { return _Username; }
        }

        public DashboardForm() { }
        public DashboardForm(string Username)
        {
            this.Username = Username;
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(DashboardForm_FormClosing);
            dataGridView = new DataGridView
            {
                Width = 275,
                Height = 368,
                Location = new Point(1036, 115),
                ColumnCount = 3,

                ColumnHeadersVisible = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                BackgroundColor = Color.Teal,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Tajawal", 8, FontStyle.Bold),

                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Tajawal", 8, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.DarkSlateGray
                },
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            };

            dataGridView.DefaultCellStyle.Font = new Font("Tajawal", 8, FontStyle.Bold);
            dataGridView.DefaultCellStyle.ForeColor = Color.DarkSlateGray;

            dataGridView.Columns[0].Name = "Name";
            dataGridView.Columns[1].Name = "Price";
            dataGridView.Columns[2].Name = "Quantity";

            dataGridView.Columns[0].HeaderText = Restaurant_Order_Management_System_Form._Is_Arabic ? "الاسم" : "Name";
            dataGridView.Columns[1].HeaderText = Restaurant_Order_Management_System_Form._Is_Arabic ? "السعر" : "Price";
            dataGridView.Columns[2].HeaderText = Restaurant_Order_Management_System_Form._Is_Arabic ? "الكمية" : "Quantity";

            clsMeal_Management.Pay_List_Changed += Update_DataGridView;
            clsMeal_Management.Pay_List_Changed += Update_Total_Price;

            this.Controls.Add(dataGridView);

            labelsum.Location = new Point(1090, 490);
            labelsum.ForeColor = Color.DarkSlateGray;
            labelsum.BackColor = Color.Transparent;
            labelsum.Font = new Font("Tajawal", 10, FontStyle.Bold);
            if (Restaurant_Order_Management_System_Form._Is_Arabic)
            {
                labelsum.Text = ":المجموع";
                labelsum.Location = new Point(1220, 490);
                labelsum_num.Location = new Point(1115, 491);
            }
            else
            {
                labelsum.Text = "Total:";
                labelsum_num.Location = new Point(1220, 491);
                labelsum_num.BringToFront();
            }

            labelsum_num.Text = clsMeal_Management.Get_Total_Price_Of_Meals_string();
            labelsum_num.ForeColor = labelsum.ForeColor;
            labelsum_num.BackColor = labelsum.BackColor;
            labelsum_num.Font = labelsum.Font;

            this.Controls.Add(labelsum);
            this.Controls.Add(labelsum_num);

            panel_choose.Size = new Size(11, 51);
            panel_choose.BackColor = Color.LightSeaGreen;
        }


        private void DashboardForm_Load(object sender, EventArgs e)
        {
            Form12.Is_Payed = false;
            Form13.Is_Payed = false;
            Form14.Is_Payed = false;

            Font font = new Font("Tajawal", 10, FontStyle.Bold);

            if (Restaurant_Order_Management_System_Form._Is_Arabic)
            {
                Search_Box.Text = "بحث";

                btn_Middle_Eastern_Cuisine.Text = "المطبخ الشرقي";
                btn_Fast_Food.Text = "وجبات سريعة";
                btn_Asian_Cuisine.Text = "المطبخ الآسيوي";
                btn_Hot_Drinke.Text = "مشروبات ساخنة";
                btn_Cold_Drinke.Text = "مشروبات باردة";
                btn_My_Order.Text = "طلباتي";

                if (this.Controls.Contains(label1))
                {
                    this.Controls.Remove(label1);
                }

                label2.Text = "حولنا";
                label2.Location = new Point(1235, 718);
                label2.Visible = true;
                label2.AutoSize = true;
                label2.ForeColor = Color.DarkSlateGray;
                label2.Font = font;
                label2.BackColor = Color.Transparent;
                this.Controls.Add(label2);
                label2.BringToFront();

                btn_Middle_Eastern_Cuisine.TextAlign = ContentAlignment.MiddleRight;
                btn_Middle_Eastern_Cuisine.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Fast_Food.TextAlign = ContentAlignment.MiddleRight;
                btn_Fast_Food.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Asian_Cuisine.TextAlign = ContentAlignment.MiddleRight;
                btn_Asian_Cuisine.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Hot_Drinke.TextAlign = ContentAlignment.MiddleRight;
                btn_Hot_Drinke.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Cold_Drinke.TextAlign = ContentAlignment.MiddleRight;
                btn_Cold_Drinke.ImageAlign = ContentAlignment.MiddleLeft;

                btn_My_Order.TextAlign = ContentAlignment.MiddleRight;
                btn_My_Order.ImageAlign = ContentAlignment.MiddleLeft;

                button1.TextAlign = ContentAlignment.MiddleRight;
                button1.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Pay_Meals.Text = "شراء الوجبات";
            }
            else
            {
                Search_Box.Text = "Search";
            }

            Search_Box.ForeColor = Color.Gray;
            Search_Box.Font = font;

            welcomeLabel = new Label();

            if (Restaurant_Order_Management_System_Form.Is_Arabic)
            {
                welcomeLabel.Text = "!" + User_Login_Form.Username + " ،أهلاً";
                welcomeLabel.Font = new Font("Tajawal", 14, FontStyle.Bold);
            }
            else
            {
                welcomeLabel.Text = "Welcome, " + User_Login_Form.Username + "!";
                welcomeLabel.Font = new Font("Centaur", 14, FontStyle.Bold);
            }

            welcomeLabel.Location = new Point(5, 5);
            welcomeLabel.ForeColor = Color.DarkSlateGray;
            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.AutoSize = true;

            this.Controls.Add(welcomeLabel);

            Font font1 = new Font("Tajawal", 8, FontStyle.Bold);

            radioButton1 = new RadioButton
            {
                Text = "In-restaurant orders",
                Font = font1,
                ForeColor = Color.DarkSlateGray,
                Location = new Point(1078, 551),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            radioButton1.CheckedChanged += (s, args) =>
            {
                if (radioButton1.Checked)
                {
                    User_Choice = radioButton1.Text;
                }
            };
            this.Controls.Add(radioButton1);

            radioButton2 = new RadioButton
            {
                Text = "Delivery orders",
                Font = font1,
                ForeColor = Color.DarkSlateGray,
                Location = new Point(1078, 581),
                AutoSize = true,
                BackColor = Color.Transparent,
                Checked = true
            };

            User_Choice = Restaurant_Order_Management_System_Form.Is_Arabic ? "طلبات مع توصيل" : "Delivery orders";

            radioButton2.CheckedChanged += (s, args) =>
            {
                if (radioButton2.Checked)
                {
                    User_Choice = radioButton2.Text;
                }
            };
            this.Controls.Add(radioButton2);

            radioButton3 = new RadioButton
            {
                Text = "Special orders",
                Font = font1,
                ForeColor = Color.DarkSlateGray,
                Location = new Point(1078, 611),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            radioButton3.CheckedChanged += (s, args) =>
            {
                if (radioButton3.Checked)
                {
                    User_Choice = radioButton3.Text;
                }
            };
            this.Controls.Add(radioButton3);

            if (Restaurant_Order_Management_System_Form._Is_Arabic)
            {
                radioButton1.Text = "طلبات في المطعم";
                radioButton2.Text = "طلبات مع توصيل";
                radioButton3.Text = "طلبات خاصة";

                radioButton1.TextAlign = ContentAlignment.MiddleRight;
                radioButton1.RightToLeft = RightToLeft.Yes;
                radioButton2.TextAlign = ContentAlignment.MiddleRight;
                radioButton2.RightToLeft = RightToLeft.Yes;
                radioButton3.TextAlign = ContentAlignment.MiddleRight;
                radioButton3.RightToLeft = RightToLeft.Yes;

                radioButton1.Location = new Point(1144, 551);
                radioButton2.Location = new Point(1150, 581);
                radioButton3.Location = new Point(1178, 611);

                label3.Text = "اختر نوع الطلب";
                label3.Location = new Point(1179, 525);
            }

            Reset_Dark_Mode();
        }

        private void Update_DataGridView()
        {
            dataGridView.Rows.Clear();
            foreach (clsMeal meal in clsMeal_Management.Pay_List)
            {
                string[] row = new string[] { meal.Name, meal.Price, meal.Num_Order_From_Meal.ToString() };
                dataGridView.Rows.Add(row);
            }
        }

        private void Update_Total_Price()
        {
            labelsum_num.Text = clsMeal_Management.Get_Total_Price_Of_Meals_string();
        }

        public string Get_User_Choice()
        {
            return User_Choice;
        }

        private void Male_Viewer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 261);
            this.Controls.Add(panel_choose);


            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Asian_Cuisine_List, false, false);

            displayCurrentMealsAction();
        }

        private void btn_Middle_Eastern_Cuisine_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(233, 148);
            this.Controls.Add(panel_choose);


            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Middle_Eastern_Cuisine_List, false, false);

            displayCurrentMealsAction();
        }

        private void btn_Fast_Food_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 207);
            this.Controls.Add(panel_choose);


            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Fast_Food_List, false, false);

            displayCurrentMealsAction();

        }

        private void btn_Hot_Drinke_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 322);
            this.Controls.Add(panel_choose);

            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Hot_Drink_List, false, false);

            displayCurrentMealsAction();
        }

        private void btn_Cold_Drinke_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 374);
            this.Controls.Add(panel_choose);

            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Cold_Drink_List, false, false);

            displayCurrentMealsAction();
            clsMeal_Management.DisplayMeals(Male_Viewer, clsMeal_Management.Cold_Drink_List, false, false);
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsMeal_Management.Reset_Meal_Orders();
            clsMeal_Management.Save_Meals_To_File();
        }

        private void btn_Middle_Eastern_Cuisine_MouseEnter(object sender, EventArgs e)
        {
            btn_Middle_Eastern_Cuisine.BackColor = Color.Teal;
        }

        private void btn_Middle_Eastern_Cuisine_MouseLeave(object sender, EventArgs e)
        {
            btn_Middle_Eastern_Cuisine.BackColor = Color.Transparent;
        }

        private void btn_Fast_Food_MouseEnter(object sender, EventArgs e)
        {
            btn_Fast_Food.BackColor = Color.Teal;
        }

        private void btn_Fast_Food_MouseLeave(object sender, EventArgs e)
        {
            btn_Fast_Food.BackColor = Color.Transparent;
        }

        private void btn_Asian_Cuisine_MouseEnter(object sender, EventArgs e)
        {
            btn_Asian_Cuisine.BackColor = Color.Teal;
        }

        private void btn_Asian_Cuisine_MouseLeave(object sender, EventArgs e)
        {
            btn_Asian_Cuisine.BackColor = Color.Transparent;
        }

        private void btn_Hot_Drinke_MouseEnter(object sender, EventArgs e)
        {
            btn_Hot_Drinke.BackColor = Color.Teal;
        }

        private void btn_Hot_Drinke_MouseLeave(object sender, EventArgs e)
        {
            btn_Hot_Drinke.BackColor = Color.Transparent;
        }

        private void btn_Cold_Drinke_MouseEnter(object sender, EventArgs e)
        {
            btn_Cold_Drinke.BackColor = Color.Teal;
        }

        private void btn_Cold_Drinke_MouseLeave(object sender, EventArgs e)
        {
            btn_Cold_Drinke.BackColor = Color.Transparent;
        }

        private void btn_My_Order_MouseEnter(object sender, EventArgs e)
        {
            btn_My_Order.BackColor = Color.Teal;
        }

        private void btn_My_Order_MouseLeave(object sender, EventArgs e)
        {
            btn_My_Order.BackColor = Color.Transparent;
        }

        private void btn_Pay_Meals_Click(object sender, EventArgs e)
        {
            clsResturant_Managementcs.Save_DataGridView_To_File(dataGridView, Username, @"Main_Folder\List_Meals_type\Payment History.txt");
            if (!(labelsum_num.Text == "0 $"))
            {
                DataTable table = Copy_DataGridView_To_DataTable(dataGridView);
                Pay_Screencs pay_Screencs = new Pay_Screencs(table, labelsum_num.Text, Username, Get_User_Choice());
                pay_Screencs.ShowDialog();

                Random random = new Random();
                int min = random.Next(1, 4);
                if (Form12.Is_Payed || Form13.Is_Payed || Form14.Is_Payed)
                {
                    clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
                    "يتم تحضير الوجبات، ستستغرق " + min.ToString() + "دقائق."
                                    :
                    "Meals are being prepared, it will take " + min.ToString() + " minutes.");
                }
            }
            else
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
                   "يجب أولاً طلب وجبة واحدة على الأقل."
                                    :
                   "You must order at least one meal first.");
            }
        }

        private DataTable Copy_DataGridView_To_DataTable(DataGridView dgv)
        {
            DataTable table = new DataTable();

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                Type columnType = column.ValueType ?? typeof(string);
                table.Columns.Add(column.Name, columnType);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dataRow = table.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                table.Rows.Add(dataRow);
            }

            return table;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Search_Box_TextChanged(object sender, EventArgs e)
        {
            Search = Search_Box.Text;
        }

        private void Search_Box_Enter(object sender, EventArgs e)
        {
            if (Search_Box.Text == "بحث" || Search_Box.Text == "Search")
            {
                Search_Box.Text = "";
                Search_Box.ForeColor = Color.Black;
            }
        }

        private void Search_Box_Leave(object sender, EventArgs e)
        {
            if (Search_Box.Text == "")
            {
                clsResturant_Managementcs.Set_Language(Search_Box, "Search", "بحث");
                Search_Box.ForeColor = Color.Gray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_choose.Hide();
            Is_Hide = true;
            clsMeal_Management.Display_Searched_Meals(Search, Male_Viewer, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form11.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_My_Order_Click(object sender, EventArgs e)
        {
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 426);
            this.Controls.Add(panel_choose);
            this.Invalidate();

            Male_Viewer.Controls.Clear();
            Male_Viewer.Visible = true;

            DataGridView orderDataGridView = new DataGridView
            {
                Width = Male_Viewer.Width - 50,
                Height = Male_Viewer.Height - 50,
                ColumnHeadersVisible = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                BackgroundColor = Color.Teal,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Tajawal", 8, FontStyle.Bold),

                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Tajawal", 8, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.DarkSlateGray
                },
            };

            orderDataGridView.Columns.Add("Name", Restaurant_Order_Management_System_Form._Is_Arabic ? "الاسم" : "Name");
            orderDataGridView.Columns.Add("Price", Restaurant_Order_Management_System_Form._Is_Arabic ? "السعر" : "Price");
            orderDataGridView.Columns.Add("Quantity", Restaurant_Order_Management_System_Form._Is_Arabic ? "الكمية" : "Quantity");
            orderDataGridView.Columns.Add("Status", Restaurant_Order_Management_System_Form._Is_Arabic ? "الحالة" : "Status");

            foreach (clsMeal meal in clsMeal_Management.Pay_List)
            {
                string[] row = new string[] { meal.Name, meal.Price, meal.Num_Order_From_Meal.ToString(), meal.Status };
                orderDataGridView.Rows.Add(row);
            }

            Male_Viewer.Controls.Add(orderDataGridView);
            orderDataGridView.BringToFront();
            Male_Viewer.Refresh();
        }

        private void ToggleSwitch_MouseEnter(object sender, EventArgs e)
        {
            CheckBox toggleSwitch = sender as CheckBox;
            if (!toggleSwitch.Checked)
            {
                toggleSwitch.BackColor = Color.SteelBlue;
            }
        }

        private void ToggleSwitch_MouseLeave(object sender, EventArgs e)
        {
            CheckBox toggleSwitch = sender as CheckBox;
            if (!toggleSwitch.Checked)
            {
                toggleSwitch.BackColor = Color.Transparent;
            }
        }

        private void btn_Pay_Meals_MouseEnter(object sender, EventArgs e)
        {
            btn_Pay_Meals.BackColor = Color.SteelBlue;
        }

        private void btn_Pay_Meals_MouseLeave(object sender, EventArgs e)
        {
            btn_Pay_Meals.BackColor = Color.Transparent;
        }

        private void btnDark_Mode_Click(object sender, EventArgs e)
        {
            if (Is_Darke_Mode)
            {
                Is_Darke_Mode = false;
                Enable_Light_Mode();
                btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\2394-dark-mode_48x48.ico");
            }
            else
            {
                Is_Darke_Mode = true;
                Enable_Dark_Mode();
                btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\لقطة شاشة 2025-01-25 184905.png");
            }
            btnDark_Mode.BackgroundImageLayout = ImageLayout.Stretch;

            displayCurrentMealsAction?.Invoke();
        }

        private void Enable_Dark_Mode()
        {
            this.BackColor = Color.FromArgb(44, 59, 60);

            foreach (Control control in this.Controls)
            {
                if (control is Label || control is Button || control is Panel || control is CheckBox || control is RadioButton)
                {
                    if (!(control == panel2 || control == panel3 || control == panel4 || control == panel5 || control == panel_choose))
                    {
                        control.BackColor = Color.Transparent;
                        control.ForeColor = Color.White;
                    }
                }
            }

            radioButton1.BackColor = Color.Transparent;
            radioButton1.ForeColor = Color.White;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.ForeColor = Color.White;
            radioButton3.BackColor = Color.Transparent;
            radioButton3.ForeColor = Color.White;
            welcomeLabel.ForeColor = Color.White;
        }

        private void Enable_Light_Mode()
        {
            this.BackColor = Color.White;

            foreach (Control control in this.Controls)
            {
                if (control is Label || control is Button || control is Panel || control is CheckBox || control is RadioButton)
                {
                    if (!(control == panel2 || control == panel3 || control == panel4 || control == panel5 || control == panel_choose))
                    {
                        control.BackColor = Color.Transparent;
                        control.ForeColor = Color.Black;
                    }
                }
            }

            radioButton1.BackColor = Color.Transparent;
            radioButton1.ForeColor = Color.Black;
            radioButton2.BackColor = Color.Transparent;
            radioButton2.ForeColor = Color.Black;
            radioButton3.BackColor = Color.Transparent;
            radioButton3.ForeColor = Color.Black;
            welcomeLabel.ForeColor = Color.Black;
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Reset_Dark_Mode();
        }

        private void Reset_Dark_Mode()
        {
            Is_Darke_Mode = false;
            Enable_Light_Mode();
            btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\2394-dark-mode_48x48.ico");
            btnDark_Mode.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}