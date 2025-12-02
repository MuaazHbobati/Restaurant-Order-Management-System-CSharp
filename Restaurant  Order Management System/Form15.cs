using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant__Order_Management_System
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            btn_Add.Text = Restaurant_Order_Management_System_Form.Is_Arabic ? "إضافة" : "Add";
            btn_Back.Text = Restaurant_Order_Management_System_Form.Is_Arabic ? "رجوع" : "Back";

            Label Tips = new Label();

            if (Restaurant_Order_Management_System_Form.Is_Arabic)
            {
                Tips.Text = "هل تريد اضافة اكرامية بقيمة $5 لدعم المطعم واستمراره؟";
                Tips.Font = new Font("Tajawal", 8, FontStyle.Bold);
            }
            else
            {
                Tips.Text = "Would you like to add a $5 tip to support \n the restaurant's continuation?";
                Tips.Font = new Font("Centaur", 8, FontStyle.Bold);
            }

            Tips.Location = new Point(10, 10);
            Tips.ForeColor = Color.White;
            Tips.AutoSize = true;
            Tips.BackColor = Color.Transparent;
            this.Controls.Add(Tips);

            this.Invalidate();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
    }
}
