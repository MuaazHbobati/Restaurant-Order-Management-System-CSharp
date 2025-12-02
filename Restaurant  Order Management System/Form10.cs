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
    public partial class Edit_Meal_Form : Form
    {
        private clsMeal meal;
        private OpenFileDialog openFileDialog1 = new OpenFileDialog();

        private string _meal_Name;
        private string _meal_info;
        private string _meal_price;
        private string _meal_photo;

        private string meal_Name
        {
            set { _meal_Name = value; }
            get { return _meal_Name; }
        }
        private string meal_info
        {
            set { _meal_info = value; }
            get { return _meal_info; }
        }
        private string meal_price
        {
            set { _meal_price = value; }
            get { return _meal_price; }
        }
        private string meal_photo
        {
            set { _meal_photo = value; }
            get { return _meal_photo; }
        }


        
        public Edit_Meal_Form(clsMeal meal)
        {
            InitializeComponent();
            this.meal = meal;

            InitializeMealDetails();
        }

        private void InitializeMealDetails()
        {
            txt_Box_Male_Name.Text = meal.Name;
            txtBox_Male_Price.Text = meal.Price.Replace(" $", "");
            richTextBox_Male_Info.Text = meal.Information;
            if (!string.IsNullOrEmpty(meal.Image_Path))
            {
                pictureBox_Viewer.Image = Image.FromFile(meal.Image_Path);
                meal_photo = meal.Image_Path;
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void btn_Upload_Photo_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                pictureBox_Viewer.Image = System.Drawing.Image.FromFile(filePath);
                meal_photo = filePath;
            }
        }

        private void txt_Box_Male_Name_TextChanged(object sender, EventArgs e)
        {
            meal_Name = txt_Box_Male_Name.Text;
        }

        private void txtBox_Male_Price_TextChanged(object sender, EventArgs e)
        {
            meal_price = txtBox_Male_Price.Text;
        }

        private void richTextBox_Male_Info_TextChanged(object sender, EventArgs e)
        {
            meal_info = richTextBox_Male_Info.Text;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(meal_photo))
            {
                meal.Image_Path = meal_photo;
            }

            if (!string.IsNullOrWhiteSpace(meal_Name))
            {
                meal.Name = meal_Name;
            }

            if (!string.IsNullOrWhiteSpace(meal_info))
            {
                meal.Information = meal_info;
            }

            if (!string.IsNullOrWhiteSpace(meal_price))
            {
                if (!float.TryParse(meal_price, out float price))
                {
                    clsMeal_Management.Note(Restaurant_Order_Management_System_Form.Is_Arabic ?
               "يرجى إدخال سعر صحيح." : "Please enter a valid price.");
                    return;
                }             

                meal.Price = meal_price + " $";
            }

            if (pictureBox_Viewer.Image == null || string.IsNullOrWhiteSpace(meal.Information) || string.IsNullOrWhiteSpace(meal.Name) || string.IsNullOrWhiteSpace(meal.Price))
            {
                clsMeal_Management.Note(Restaurant_Order_Management_System_Form._Is_Arabic ?
                     "يرجى تعبئة جميع المعلومات" : "Please fill in all the information");
                return;
            }

            this.Close();
        }
    }
}