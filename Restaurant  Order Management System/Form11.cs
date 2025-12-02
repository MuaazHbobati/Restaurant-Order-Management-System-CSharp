using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class Form11 : Form
    {
        private Label AboutLabel = new Label();
        public Form11()
        {
            InitializeComponent();
        }
        private void Form11_Load(object sender, EventArgs e)
        {
            if (Restaurant_Order_Management_System_Form.Is_Arabic)
            {
                AboutLabel.Text = "نظام إدارة طلبات المطاعم هو مشروع تطبيق سطح مكتب يستخدم نموذج ويندوز بدأ في أوائل عام 2025. " +
                    "الهدف من المشروع هو توفير برنامج شامل لإدارة واستلام طلبات المطاعم." +
                    "\r\n\r\nمهمتنا هي ضمان أن يتمكن البرنامج من توفير واجهة ممتازة للتفاعل مع النظام،" +
                    " وتقديم تجربة مستخدم استثنائية، والتعامل بكفاءة مع جميع أنواع الطلبات" +
                    ".\r\n\r\nالمشروع مدار بالكامل بواسطة معاذ حبوباتي، طالب في كلية هندسة المعلوماتية - هندسة البرمجيات." +
                    "\r\n\r\nإذا كان لديك أي أسئلة أو ترغب في معرفة المزيد عنا، فلا تتردد في التواصل معنا.\r\n";

                AboutLabel.Font = new Font("Tajawal", 9);
                AboutLabel.Location = new Point(20, 201);
                AboutLabel.ForeColor = Color.White;
                AboutLabel.BackColor = Color.Transparent;
                AboutLabel.AutoSize = true;
                AboutLabel.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                AboutLabel.TextAlign = ContentAlignment.TopLeft;
                AboutLabel.RightToLeft = RightToLeft.Yes;    

                this.Controls.Add(AboutLabel);
                AboutLabel.BringToFront();

                UpdateLabel2Text();
            }
            else
            {
                AboutLabel.Text = "Restaurant Order Management System is a Windows Forms Desktop" +
                " Application project that began in early 2025." +
                " The goal of the project is to provide a comprehensive program" +
                " for managing and receiving restaurant orders.\r\n\r\nOur mission" +
                " is to ensure the program can provide an excellent interface for system" +
                " interaction, offer an exceptional user experience, and efficiently" +
                " handle all types of orders.\r\n\r\nThe project is entirely managed " +
                "by Muaaz Hbobati, a student at the Faculty of Informatics Engineering" +
                " - Software Engineering.\r\n\r\nIf you have any questions or would like " +
                "to learn more about us, feel free to reach out to us.\r\n";

                AboutLabel.Font = new Font("Times New Roman", 9);
                AboutLabel.Location = new Point(21, 201);
                AboutLabel.ForeColor = Color.White;
                AboutLabel.BackColor = Color.Transparent;
                AboutLabel.AutoSize = true;
                AboutLabel.MaximumSize = new Size(this.ClientSize.Width - 40, 0);
                AboutLabel.TextAlign = ContentAlignment.TopLeft;

                this.Controls.Add(AboutLabel);
                AboutLabel.BringToFront();
            }
        }

        private void UpdateLabel2Text()
        {
            label2.Invalidate();
            label2.Update();
            label2.Refresh();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"https://www.Linkedin.com/in/mohammed-mouaz-hbobati-54a2992a1");
        }
    }
}