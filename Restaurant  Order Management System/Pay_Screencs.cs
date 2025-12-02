using Restaurant__Order_Management_System;
using Restaurant_Order_Management_System;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class Pay_Screencs : Form
    {
        private DataTable dataTable;
        private string sum_price;
        private Label label;
        private string Username;
        private string Choice;

        Form12 form12 = new Form12();
        Form13 form13 = new Form13();
        Form14 form14 = new Form14();

        private Label AboutLabel = new Label();

        public Pay_Screencs(DataTable dataTable, string sum_price, string username, string Choise)
        {
            InitializeComponent();
            this.dataTable = dataTable;
            this.sum_price = sum_price;
            Username = username;
            this.Choice = Choise;
        }

        private void Pay_Screencs_Load(object sender, EventArgs e)
        {
            btn_Save_Invoice.Hide();

            panel2.Visible = (Choice == "Delivery orders" || Choice == "طلبات مع توصيل");
            btn_Save_Invoice.Visible = Form12.Is_Payed || Form13.Is_Payed || Form14.Is_Payed;
            if (btn_Save_Invoice.Visible)
            {
                this.Invalidate();
            }

            DataGridView dataGridView = new DataGridView
            {
                Width = 345,
                Height = 200,
                ColumnHeadersVisible = true,
                ReadOnly = true,
                BackgroundColor = Color.DarkSlateGray
            };

            dataGridView.DataSource = dataTable;
            dataGridView.DefaultCellStyle.Font = new Font("Tajawal", 8, FontStyle.Bold);
            dataGridView.DefaultCellStyle.ForeColor = Color.White;
            dataGridView.DefaultCellStyle.BackColor = Color.DarkSlateGray;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.LightSlateGray;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            this.Controls.Add(dataGridView);
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns[0].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "الاسم" : "Name";
                if (dataGridView.Columns.Count > 1)
                {
                    dataGridView.Columns[1].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "السعر" : "Price";
                }
                if (dataGridView.Columns.Count > 2)
                {
                    dataGridView.Columns[2].HeaderText = Restaurant_Order_Management_System_Form.Is_Arabic ? "الكمية" : "Quantity";
                }
            }

            dataGridView.Invalidate();
            dataGridView.Refresh();

            label = new Label
            {
                Text = sum_price,
                Location = new Point(650, 1),
                Font = new Font("Tajawal", 9, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            this.Controls.Add(label);
            label.BringToFront();

            if (clsLogin.Get_Num_Client_Of_Login(Username) > 5)
            {
                Label label8 = new Label
                {
                    Text = "The Price After Discount:",
                    Location = new Point(373, 25),
                    Font = new Font("Centaur", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                this.Controls.Add(label8);
                label8.BringToFront();

                Label label11 = new Label
                {
                    Text = clsMeal_Management.Get_Total_Price_Of_Meals_After_Discount(),
                    Location = new Point(650, 25),
                    Font = new Font("Centaur", 9, FontStyle.Bold),
                    ForeColor = Color.White,
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                this.Controls.Add(label11);
                label11.BringToFront();

                if (Restaurant_Order_Management_System_Form._Is_Arabic)
                {
                    btn_Done.Text = "إنهاء";

                    AboutLabel.Text = "لقد حصلت على خصم 10$ على كل المشتريات من كل الأصناف، لأنك" +
                                      " .من الزبائن المميزين " +
                                      ".هذا الخصم فعال مدى الحياة على هذا الحساب";

                    AboutLabel.Font = new Font("Tajawal", 10);
                    AboutLabel.Location = new Point(380, 85);
                    AboutLabel.ForeColor = Color.White;
                    AboutLabel.BackColor = Color.Transparent;
                    AboutLabel.AutoSize = false;
                    AboutLabel.MaximumSize = new Size(500, 0);
                    AboutLabel.Size = new Size(420, 125);
                    AboutLabel.TextAlign = ContentAlignment.TopLeft;
                    AboutLabel.AutoEllipsis = true;

                    this.Controls.Add(AboutLabel);
                    AboutLabel.BringToFront();

                    label2.Text = "يرجى اختيار طريقة االدفع";


                    label1.Text = ":السعر";
                    label1.Location = new Point(729, 1);
                    label.Location = new Point(373, 1);

                    label8.Text = ":السعر بعد الخصم";
                    label8.Location = new Point(658, 25);
                    label11.Location = new Point(373, 25);


                    Label label7 = new Label
                    {
                        Text = "10$" + "                                                             " + ":قيمة الخصم",
                        Location = new Point(372, 50),
                        Font = new Font("Centaur", 9, FontStyle.Bold),
                        ForeColor = Color.White,
                        AutoSize = true,
                        BackColor = Color.Transparent
                    };
                    this.Controls.Add(label7);
                    label7.BringToFront();

                }
                else
                {
                    AboutLabel.Text = "You have received a $10 discount on all purchases from" +
                                      " all categories, because you are one of our" +
                                      " valued customers.\nThis discount is valid for life " +
                                      "on this account.";

                    AboutLabel.Font = new Font("Tajawal", 10);
                    AboutLabel.Location = new Point(350, 85);
                    AboutLabel.ForeColor = Color.White;
                    AboutLabel.BackColor = Color.Transparent;
                    AboutLabel.AutoSize = false;
                    AboutLabel.MaximumSize = new Size(500, 0);
                    AboutLabel.Size = new Size(420, 125);
                    AboutLabel.TextAlign = ContentAlignment.TopLeft;
                    AboutLabel.AutoEllipsis = true;

                    this.Controls.Add(AboutLabel);
                    AboutLabel.BringToFront();

                    Label label7 = new Label
                    {
                        Text = "Discount Amount:" + "                                 " + "10$",
                        Location = new Point(372, 50),
                        Font = new Font("Centaur", 9, FontStyle.Bold),
                        ForeColor = Color.White,
                        AutoSize = true,
                        BackColor = Color.Transparent
                    };
                    this.Controls.Add(label7);
                    label7.BringToFront();
                }
            }
        }

        private void btn_Pay_MouseEnter(object sender, EventArgs e)
        {
            btn_Done.BackColor = Color.SteelBlue;
        }

        private void btn_Pay_MouseLeave(object sender, EventArgs e)
        {
            btn_Done.BackColor = Color.Transparent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            form12.ShowDialog();
            if (Form12.Is_Payed == true)
            {
                this.Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            form13.ShowDialog();
            if (Form13.Is_Payed == true)
            {
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            form14.ShowDialog();
            if (Form13.Is_Payed == true)
            {
                this.Close();
            }
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            if (Form12.Is_Payed || Form13.Is_Payed || Form14.Is_Payed)
            {
                this.Close();
            }
            else
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
                "يرجى اختيار طريقة دفع والدفع أولاً." : "Please choose a payment method and pay first.");
            }
        }

        private void btn_Save_Invoice_Click(object sender, EventArgs e)
        {
            Save_DataGridView_As_Image(DashboardForm.dataGridView);
        }

        private void Save_DataGridView_As_Image(DataGridView Data_Grid_View)
        {
            int width = Data_Grid_View.Width;
            int height = Data_Grid_View.Height;

            Bitmap bitmap = new Bitmap(width, height);
            Data_Grid_View.DrawToBitmap(bitmap, new Rectangle(0, 0, width, height));
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "DataGridViewImage.png");
            bitmap.Save(filePath, ImageFormat.Png);

            clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
            "تم حفظ الفاتورة بشكل صورة على سطح المكتب" : "The invoice has been saved as an image on the desktop");
        }

        private void Pay_Screencs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Form12.Is_Payed || Form13.Is_Payed || Form14.Is_Payed)
            {
                Form12.Is_Payed = false;
                Form13.Is_Payed = false;
                Form14.Is_Payed = false;
            }
        }
    }
}
