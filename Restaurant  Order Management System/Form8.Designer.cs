namespace Restaurant__Order_Management_System
{
    partial class Meals_Manegment_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Meals_Manegment_Form));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Upload_Photo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Box_Male_Name = new System.Windows.Forms.TextBox();
            this.txtBox_Male_Price = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Viewer = new System.Windows.Forms.PictureBox();
            this.richTextBox_Male_Info = new System.Windows.Forms.RichTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Viewer)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btn_Upload_Photo
            // 
            this.btn_Upload_Photo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Upload_Photo.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Upload_Photo.Location = new System.Drawing.Point(12, 107);
            this.btn_Upload_Photo.Name = "btn_Upload_Photo";
            this.btn_Upload_Photo.Size = new System.Drawing.Size(130, 27);
            this.btn_Upload_Photo.TabIndex = 2;
            this.btn_Upload_Photo.Text = "Upload Photo";
            this.btn_Upload_Photo.UseVisualStyleBackColor = false;
            this.btn_Upload_Photo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Price";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "name";
            // 
            // txt_Box_Male_Name
            // 
            this.txt_Box_Male_Name.Location = new System.Drawing.Point(12, 152);
            this.txt_Box_Male_Name.Name = "txt_Box_Male_Name";
            this.txt_Box_Male_Name.Size = new System.Drawing.Size(147, 24);
            this.txt_Box_Male_Name.TabIndex = 6;
            this.txt_Box_Male_Name.TextChanged += new System.EventHandler(this.txt_Box_Male_Name_TextChanged);
            // 
            // txtBox_Male_Price
            // 
            this.txtBox_Male_Price.Location = new System.Drawing.Point(12, 193);
            this.txtBox_Male_Price.Name = "txtBox_Male_Price";
            this.txtBox_Male_Price.Size = new System.Drawing.Size(147, 24);
            this.txtBox_Male_Price.TabIndex = 7;
            this.txtBox_Male_Price.TextChanged += new System.EventHandler(this.txtBox_Male_Price_TextChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Ok.Font = new System.Drawing.Font("Ink Free", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Ok.Location = new System.Drawing.Point(364, 202);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(105, 26);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(188, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "info";
            // 
            // pictureBox_Viewer
            // 
            this.pictureBox_Viewer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox_Viewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Viewer.Location = new System.Drawing.Point(12, 0);
            this.pictureBox_Viewer.Name = "pictureBox_Viewer";
            this.pictureBox_Viewer.Size = new System.Drawing.Size(130, 111);
            this.pictureBox_Viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Viewer.TabIndex = 1;
            this.pictureBox_Viewer.TabStop = false;
            // 
            // richTextBox_Male_Info
            // 
            this.richTextBox_Male_Info.Font = new System.Drawing.Font("Ink Free", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Male_Info.Location = new System.Drawing.Point(189, 17);
            this.richTextBox_Male_Info.Name = "richTextBox_Male_Info";
            this.richTextBox_Male_Info.Size = new System.Drawing.Size(278, 170);
            this.richTextBox_Male_Info.TabIndex = 11;
            this.richTextBox_Male_Info.Text = "";
            this.richTextBox_Male_Info.TextChanged += new System.EventHandler(this.richTextBox_Male_Info_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Tajawal", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Middle Eastern Cuisine",
            "Fast Food",
            "Asian Cuisine,",
            "Hot Drink",
            "Cold Drink",
            "My Order"});
            this.comboBox1.Location = new System.Drawing.Point(191, 193);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 26);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox_Meal_Type_SelectedIndexChanged);
            // 
            // Meals_Manegment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::Restaurant__Order_Management_System.Properties.Resources.لقطة_شاشة_2025_01_15_050712;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(468, 229);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox_Male_Info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txtBox_Male_Price);
            this.Controls.Add(this.txt_Box_Male_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Upload_Photo);
            this.Controls.Add(this.pictureBox_Viewer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Meals_Manegment_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Meal";
            this.Load += new System.EventHandler(this.Meal_Manegment_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Viewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Viewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Upload_Photo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Box_Male_Name;
        private System.Windows.Forms.TextBox txtBox_Male_Price;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_Male_Info;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}