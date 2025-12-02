using Restaurant__Order_Management_System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Restaurant__Order_Management_System
{
    public partial class Dashboard_For_Admain_Form : Form
    {
        public static string Order_History = @"Main_Folder\List_Meals_type\Payment History.txt";

        public TableLayoutPanel tableLayoutPanel;
        public static List<clsMeal> Meals_Manage = clsMeal_Management.All_Meals_List;

        public static bool _Is_Darke_Mode = false;
        public static bool Is_Hide = false;
        private bool Is_Event_Registered = false;

        private DataTable dataTable = new DataTable();       
        private DataGridView dataGridView1;

        private Panel panel_choose = new Panel();
        private Action displayCurrentMealsAction;

        public Dashboard_For_Admain_Form()
        {
            InitializeComponent();
        }

        private void Dashboard_For_Admain_Form_Load(object sender, EventArgs e)
        {
            btn_Add_New_Meal.Hide();
            ResetDarkMode();
            panel_choose.Size = new Size(11, 51);
            panel_choose.BackColor = Color.LightSeaGreen;
            Font font = new Font("Tajawal", 10, FontStyle.Bold);
            if (Restaurant_Order_Management_System_Form._Is_Arabic)
            {
                btn_Add_New_Meal.Text = "إضافة وجبة جديدة";
                btn_Meals_Management.Text = "إدارة الوجبات";
                btn_Order_History.Text = "سجلات الطلبات";
                btn_Detailed_Reports.Text = "تقارير تفصيلية";
                btn_Order_Management.Text = "إدارة الطلبات";

                btn_Meals_Management.TextAlign = ContentAlignment.MiddleRight;
                btn_Meals_Management.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Order_History.TextAlign = ContentAlignment.MiddleRight;
                btn_Order_History.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Detailed_Reports.TextAlign = ContentAlignment.MiddleRight;
                btn_Detailed_Reports.ImageAlign = ContentAlignment.MiddleLeft;

                btn_Order_Management.TextAlign = ContentAlignment.MiddleRight;
                btn_Order_Management.ImageAlign = ContentAlignment.MiddleLeft;

                label2.Text = "الوجبات";
                label1.Text = "التقارير";

                label1.Location = new Point(162, 240);
                label2.Location = new Point(159, 12);

                label1.Font = new Font("Tajawal", 12, FontStyle.Bold);
                label2.Font = new Font("Tajawal", 12, FontStyle.Bold);

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Meals_Management_Click(object sender, EventArgs e)
        {
            btn_Add_New_Meal.Visible = true;
            btn_Add_New_Meal.Font = new Font("Tajawal", 10, FontStyle.Bold);

            if (_Is_Darke_Mode)
            {
                btn_Add_New_Meal.BackColor = Color.FromArgb(44, 59, 60);
                btn_Add_New_Meal.ForeColor = Color.White;
            }
            else
            {
                btn_Add_New_Meal.BackColor = Color.White;
                btn_Add_New_Meal.ForeColor = Color.DarkSlateGray;
            }

            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 155);
            this.Controls.Add(panel_choose);

            displayCurrentMealsAction = () => clsMeal_Management.DisplayMeals(Male_Viewer_Admain, Meals_Manage, true, true);
            displayCurrentMealsAction();
        }

        private void btn_Order_Management_Click(object sender, EventArgs e)
        {
            btn_Add_New_Meal.Hide();
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 201);
            this.Controls.Add(panel_choose);

            displayCurrentMealsAction = () => clsResturant_Managementcs.DisplayMeals(Male_Viewer_Admain, clsMeal_Management.Pay_List, true, true);

            displayCurrentMealsAction();
        }

        private void btn_Order_History_Click(object sender, EventArgs e)
        {
            Male_Viewer_Admain.Controls.Clear();
            btn_Add_New_Meal.Hide();

            if (Is_Hide)
            {
                panel_choose.Show();
            }

            panel_choose.Location = new Point(235, 255);
            this.Controls.Add(panel_choose);

            Male_Viewer_Admain.Controls.Clear();
            Male_Viewer_Admain.Visible = true;

            dataGridView1 = new DataGridView
            {
                Width = Male_Viewer_Admain.ClientSize.Width - 20,
                Height = Male_Viewer_Admain.ClientSize.Height - 15,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ForeColor = Color.DarkSlateGray,
                Font = new Font("Tajawal", 8, FontStyle.Bold),
                ReadOnly = true,
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = Restaurant_Order_Management_System_Form.Is_Arabic ?
                   new Font("Tajawal", 8, FontStyle.Bold) :
                   new Font("Tajawal", 10, FontStyle.Bold),

                    ForeColor = Color.White,
                    BackColor = Color.DarkSlateGray
                }
            };

            DataTable dataTable = clsResturant_Managementcs.Load_Data_From_File(Order_History);
            DataTable reversedDataTable = dataTable.Clone();

            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                reversedDataTable.ImportRow(dataTable.Rows[i]);
            }
            dataGridView1.DataSource = reversedDataTable;
            Male_Viewer_Admain.Controls.Add(dataGridView1);

            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "التاريخ" : "Date";
            }
            if (dataGridView1.Columns.Count > 1)
            {
                dataGridView1.Columns[1].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "اسم المستخدم" : "Username";
            }
            if (dataGridView1.Columns.Count > 2)
            {
                dataGridView1.Columns[2].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "الاسم" : "Name";
            }
            if (dataGridView1.Columns.Count > 3)
            {
                dataGridView1.Columns[3].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "السعر" : "Price";
            }
            if (dataGridView1.Columns.Count > 4)
            {
                dataGridView1.Columns[4].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "الكمية" : "Quantity";
            }


            displayCurrentMealsAction = () => Male_Viewer_Admain.Controls.Add(dataGridView1);
            displayCurrentMealsAction();
        }

        private void btn_Detailed_Reports_Click(object sender, EventArgs e)
        {
            Male_Viewer_Admain.Controls.Clear();
            btn_Add_New_Meal.Hide();
            if (Is_Hide)
            {
                panel_choose.Show();
            }
            panel_choose.Location = new Point(235, 391);
            this.Controls.Add(panel_choose);
            Male_Viewer_Admain.Controls.Clear();

            tableLayoutPanel = new TableLayoutPanel
            {
                RowCount = 20,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                AutoSize = true,
                RightToLeft = Restaurant_Order_Management_System_Form._Is_Arabic ? RightToLeft.Yes : RightToLeft.No
            };

            for (int i = 0; i < 15; i++)
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            }

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            Color foreColor = _Is_Darke_Mode ? Color.White : Color.Black;

            Label labelsum = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "عدد الطلبات اليومية:" : "Daily Order Count:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            int dailyOrderCount = clsResturant_Managementcs.Get_Latest_Order_Count(Order_History);

            Label labelsumValue = new Label
            {
                Text = dailyOrderCount.ToString(),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label label = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "الوجبة الأكثر طلبًا:" : "Most Popular Meal:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            string MostPopularMeal = clsResturant_Managementcs.Get_Most_Popular_Meal(Order_History);
            Label MostMeal = new Label
            {
                Text = MostPopularMeal,
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label revenueLabel = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "الإيرادات اليومية:" : "Daily Revenue:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            double dailyRevenue = clsResturant_Managementcs.Calculate_Daily_Revenue(Order_History);
            Label revenueValue = new Label
            {
                Text = " $" + dailyRevenue.ToString("F2"),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Profits_Label = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "الأرباح اليومية:" : "Daily Profit:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Profits_Label_Value = new Label
            {
                Text = " $" + (dailyRevenue * 0.29).ToString("F2"),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Capital_Label = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "رأس المال:" : "Capital:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Capital_Label_Value = new Label
            {
                Text = " $" + (dailyRevenue * 0.71).ToString("F2"),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Num_Client_Label = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "عدد العملاء:" : "The Number of Client:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Num_Client_Label_Value = new Label
            {
                Text = "  " + clsLogin.Get_Num_Of_Client().ToString(),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Regular_Customer = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "عميل منتظم:" : "A Regular Customer:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Regular_Customer_Name = new Label
            {
                Text = "  " + clsLogin.Get_Regular_Customer_Name(),
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Tajawal", 10, FontStyle.Bold),
                AutoSize = true
            };

            Label Sales_Today = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "مبيعات اليوم:" : "Sales Today:",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Times New Roman", 12, FontStyle.Bold),
                AutoSize = true
            };

            Label Empty = new Label
            {
                Text = ""
            };

            Label Title = new Label
            {
                Text = Restaurant_Order_Management_System_Form._Is_Arabic ? "التقارير" : "Reports",
                ForeColor = foreColor,
                BackColor = Color.Transparent,
                Font = new Font("Times New Roman", 14, FontStyle.Bold),
                AutoSize = true,
                TextAlign = Restaurant_Order_Management_System_Form._Is_Arabic ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft
            };

            tableLayoutPanel.Controls.Add(Title, Restaurant_Order_Management_System_Form._Is_Arabic ? 1 : 0, 0);
            tableLayoutPanel.SetColumnSpan(Title, 2);
            tableLayoutPanel.Controls.Add(labelsum, 0, 2);
            tableLayoutPanel.Controls.Add(labelsumValue, 1, 2);
            tableLayoutPanel.Controls.Add(label, 0, 3);
            tableLayoutPanel.Controls.Add(MostMeal, 1, 3);
            tableLayoutPanel.Controls.Add(revenueLabel, 0, 4);
            tableLayoutPanel.Controls.Add(revenueValue, 1, 4);
            tableLayoutPanel.Controls.Add(Profits_Label, 0, 5);
            tableLayoutPanel.Controls.Add(Profits_Label_Value, 1, 5);
            tableLayoutPanel.Controls.Add(Capital_Label, 0, 6);
            tableLayoutPanel.Controls.Add(Capital_Label_Value, 1, 6);
            tableLayoutPanel.Controls.Add(Num_Client_Label, 0, 7);
            tableLayoutPanel.Controls.Add(Num_Client_Label_Value, 1, 7);
            tableLayoutPanel.Controls.Add(Regular_Customer, 0, 8);
            tableLayoutPanel.Controls.Add(Regular_Customer_Name, 1, 8);
            tableLayoutPanel.Controls.Add(Empty, 0, 9);
            tableLayoutPanel.Controls.Add(Empty, 0, 10);
            tableLayoutPanel.Controls.Add(Sales_Today, Restaurant_Order_Management_System_Form._Is_Arabic ? 1 : 0, 11);



            tableLayoutPanel.SetColumnSpan(Sales_Today, 2);

            List<clsMeal> mealsSoldToday = clsResturant_Managementcs.Get_Meals_Sold_To_day(Order_History);
            int currentRow = 13;

            foreach (clsMeal meal in mealsSoldToday)
            {
                if (meal.Name != "الاسم" && meal.Num_Order_From_Meal != 0)
                {
                    Label mealNameLabel = new Label
                    {
                        Text = meal.Name,
                        ForeColor = foreColor,
                        BackColor = Color.Transparent,
                        Font = new Font("Tajawal", 10, FontStyle.Bold),
                        AutoSize = true
                    };
                    Label mealQuantityLabel = new Label
                    {
                        Text = meal.Num_Order_From_Meal.ToString(),
                        ForeColor = foreColor,
                        BackColor = Color.Transparent,
                        Font = new Font("Tajawal", 10, FontStyle.Bold),
                        AutoSize = true
                    };

                    tableLayoutPanel.Controls.Add(mealNameLabel, 1, currentRow);
                    tableLayoutPanel.Controls.Add(mealQuantityLabel, 0, currentRow);
                    currentRow++;
                }
            }

            Male_Viewer_Admain.Controls.Add(tableLayoutPanel);

            displayCurrentMealsAction = () => Male_Viewer_Admain.Controls.Add(tableLayoutPanel);

            displayCurrentMealsAction();
            this.Invalidate();
        }

        private void Male_Viewer_Admain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Meals_Management_MouseEnter(object sender, EventArgs e)
        {
            btn_Meals_Management.BackColor = Color.Teal;
        }

        private void btn_Meals_Management_MouseLeave(object sender, EventArgs e)
        {
            btn_Meals_Management.BackColor = Color.Transparent;
        }

        private void btn_Order_Management_MouseEnter(object sender, EventArgs e)
        {
            btn_Order_Management.BackColor = Color.Teal;
        }

        private void btn_Order_Management_MouseLeave(object sender, EventArgs e)
        {
            btn_Order_Management.BackColor = Color.Transparent;
        }

        private void btn_Order_History_MouseEnter(object sender, EventArgs e)
        {
            btn_Order_History.BackColor = Color.Teal;
        }

        private void btn_Order_History_MouseLeave(object sender, EventArgs e)
        {
            btn_Order_History.BackColor = Color.Transparent;
        }

        private void btn_Detailed_Reports_MouseEnter(object sender, EventArgs e)
        {
            btn_Detailed_Reports.BackColor = Color.Teal;
        }

        private void btn_Detailed_Reports_MouseLeave(object sender, EventArgs e)
        {
            btn_Detailed_Reports.BackColor = Color.Transparent;
        }

        private void btnDark_Mode_Click(object sender, EventArgs e)
        {
            if (_Is_Darke_Mode)
            {
                _Is_Darke_Mode = false;
                Enable_Light_Mode();
                btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\2394-dark-mode_48x48.ico");
            }
            else
            {
                _Is_Darke_Mode = true;
                Enable_Dark_Mode();
                btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\لقطة شاشة 2025-01-25 184905.png");
            }
            btnDark_Mode.BackgroundImageLayout = ImageLayout.Stretch;

            Update_Detailed_Reports_Colors();
            displayCurrentMealsAction?.Invoke();
        }

        private void Update_Detailed_Reports_Colors()
        {
            if (tableLayoutPanel == null) return;

            Color foreColor = _Is_Darke_Mode ? Color.White : Color.Black;

            foreach (Control control in tableLayoutPanel.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = foreColor;
                }
            }
        }

        private void Enable_Dark_Mode()
        {
            this.BackColor = Color.FromArgb(44, 59, 60);

            foreach (Control control in this.Controls)
            {
                if (control is Label || control is Button || control is Panel)
                {
                    if (!(control == panel2 || control == panel3 || control == panel5 || control == panel_choose))
                    {
                        control.BackColor = Color.Transparent;
                        control.ForeColor = Color.White;
                    }
                }
                else if (control is DataGridView && control != dataGridView1)
                {
                    DataGridView dgv = control as DataGridView;
                    dgv.BackgroundColor = Color.FromArgb(44, 59, 60);
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                    dgv.DefaultCellStyle.BackColor = Color.FromArgb(44, 59, 60);
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 59, 60);
                }
            }
            btn_Add_New_Meal.BackColor = Color.FromArgb(44, 59, 60);
            btn_Add_New_Meal.ForeColor = Color.White;
        }

        private void Enable_Light_Mode()
        {
            this.BackColor = Color.White;
            foreach (Control control in this.Controls)
            {
                if (control is Label || control is Button || control is Panel)
                {
                    if (!(control == panel2 || control == panel3 || control == panel5 || control == panel_choose))
                    {
                        control.BackColor = Color.Transparent;
                        control.ForeColor = Color.Black;
                    }
                }
                else if (control is DataGridView)
                {
                    DataGridView dgv = control as DataGridView;
                    dgv.BackgroundColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.White;

                }
            }

            btn_Add_New_Meal.BackColor = Color.White;
            btn_Add_New_Meal.ForeColor = Color.DarkSlateGray;
        }

        private void Dashboard_For_Admain_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ResetDarkMode();
        }

        private void ResetDarkMode()
        {
            _Is_Darke_Mode = false;
            Enable_Light_Mode();
            btnDark_Mode.BackgroundImage = Image.FromFile(@"Main_Folder\Photo\2394-dark-mode_48x48.ico");
            btnDark_Mode.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Add_New_Meal_Click(object sender, EventArgs e)
        {
            btn_Add_New_Meal.Enabled = false;
            Meals_Manegment_Form meals_Manegment_Form = new Meals_Manegment_Form(Male_Viewer_Admain, true);
            DialogResult result = meals_Manegment_Form.ShowDialog();
            btn_Add_New_Meal.Enabled = true;

            if (result == DialogResult.OK)
            {
                btn_Meals_Management_Click(sender, e);
            }
        }

        private void Add_New_Meal_MouseEnter(object sender, EventArgs e)
        {
            btn_Add_New_Meal.BackColor = Color.SteelBlue;
        }

        private void Add_New_Meal_MouseLeave(object sender, EventArgs e)
        {
            btn_Add_New_Meal.BackColor = _Is_Darke_Mode ? Color.FromArgb(44, 59, 60) : Color.White;
        }
    }
}