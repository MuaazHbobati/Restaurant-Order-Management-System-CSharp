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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant__Order_Management_System
{
    public partial class Form14 : Form
    {
        private Form15 form15 = new Form15();
        private Label label = new Label();
        private Label label1 = new Label();
        private Label label2 = new Label();
        public static bool _Is_Payed;
        public static bool Is_Payed
        {
            set { _Is_Payed = value; }
            get { return _Is_Payed; }
        }

        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            clsResturant_Managementcs.Set_Language(btn_Back, "Back", "رجوع");
            clsResturant_Managementcs.Set_Language(btn_continue, "Continue", "استمرار");

            if (Restaurant_Order_Management_System_Form._Is_Arabic)
            {
                label.Text = "خيار الدفع هذا فعال فقط في حال اخترت خيار توصيل الطلبات، " +
                    "يمكنك الدفع لعامل توصيل الطلبات حين استلام الطلب نقداً.";

                label.Font = new Font("Tajawal", 11);
                label.Location = new Point(25, 5);
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
                label.AutoSize = true;
                label.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                label.TextAlign = ContentAlignment.TopLeft;
                label.RightToLeft = RightToLeft.Yes;

                this.Controls.Add(label);
                label.BringToFront();


                label2.Text = "سيوصل الطلب الخاص بك أقرب عامل توصيل على العنوان التالي: " + "\n" + clsLogin.Get_Location(User_Login_Form.Username);
                label2.Font = new Font("Tajawal", 11);
                label2.Location = new Point(50, 115);
                label2.ForeColor = Color.White;
                label2.BackColor = Color.Transparent;
                label2.AutoSize = true;
                label2.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                label2.TextAlign = ContentAlignment.TopLeft;
                label2.RightToLeft = RightToLeft.Yes;

                this.Controls.Add(label2);
                label2.BringToFront();
            }
            else
            {
                label.Text = "This payment option is only valid if you choose the delivery option." +
                    " You can pay the delivery person in cash upon receiving your order.";

                label.Font = new Font("Times New Roman", 11);
                label.Location = new Point(5, 5);
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
                label.AutoSize = true;
                label.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                label.TextAlign = ContentAlignment.TopLeft;

                this.Controls.Add(label);
                label.BringToFront();


                label2.Text = "Your order will be delivered by the nearest delivery person to the following address: " + "\n" + clsLogin.Get_Location(User_Login_Form.Username);
                label2.Font = new Font("Tajawal", 11);
                label2.Location = new Point(5, 115);
                label2.ForeColor = Color.White;
                label2.BackColor = Color.Transparent;
                label2.AutoSize = true;
                label2.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                label2.TextAlign = ContentAlignment.TopLeft;
                label2.RightToLeft = RightToLeft.No;

                this.Controls.Add(label2);
                label2.BringToFront();
            }           
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            Is_Payed = true;
            form15.ShowDialog();
            this.Close();
        }
    }
}