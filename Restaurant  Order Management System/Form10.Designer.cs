namespace Restaurant__Order_Management_System
{
    partial class Edit_Meal_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Edit_Meal_Form));
            this.pictureBox_Viewer = new System.Windows.Forms.PictureBox();
            this.richTextBox_Male_Info = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.txtBox_Male_Price = new System.Windows.Forms.TextBox();
            this.txt_Box_Male_Name = new System.Windows.Forms.TextBox();
            this.btn_Upload_Photo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Viewer)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Viewer
            // 
            this.pictureBox_Viewer.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox_Viewer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Viewer.Location = new System.Drawing.Point(6, -2);
            this.pictureBox_Viewer.Name = "pictureBox_Viewer";
            this.pictureBox_Viewer.Size = new System.Drawing.Size(130, 111);
            this.pictureBox_Viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Viewer.TabIndex = 2;
            this.pictureBox_Viewer.TabStop = false;
            // 
            // richTextBox_Male_Info
            // 
            this.richTextBox_Male_Info.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold);
            this.richTextBox_Male_Info.Location = new System.Drawing.Point(159, 22);
            this.richTextBox_Male_Info.Name = "richTextBox_Male_Info";
            this.richTextBox_Male_Info.Size = new System.Drawing.Size(278, 156);
            this.richTextBox_Male_Info.TabIndex = 17;
            this.richTextBox_Male_Info.Text = "";
            this.richTextBox_Male_Info.TextChanged += new System.EventHandler(this.richTextBox_Male_Info_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(163, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "info";
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Ok.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold);
            this.btn_Ok.Location = new System.Drawing.Point(358, 202);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(105, 26);
            this.btn_Ok.TabIndex = 15;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // txtBox_Male_Price
            // 
            this.txtBox_Male_Price.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtBox_Male_Price.Location = new System.Drawing.Point(6, 191);
            this.txtBox_Male_Price.Name = "txtBox_Male_Price";
            this.txtBox_Male_Price.Size = new System.Drawing.Size(147, 33);
            this.txtBox_Male_Price.TabIndex = 14;
            this.txtBox_Male_Price.TextChanged += new System.EventHandler(this.txtBox_Male_Price_TextChanged);
            // 
            // txt_Box_Male_Name
            // 
            this.txt_Box_Male_Name.Font = new System.Drawing.Font("Tajawal", 10.2F, System.Drawing.FontStyle.Bold);
            this.txt_Box_Male_Name.Location = new System.Drawing.Point(6, 150);
            this.txt_Box_Male_Name.Name = "txt_Box_Male_Name";
            this.txt_Box_Male_Name.Size = new System.Drawing.Size(147, 33);
            this.txt_Box_Male_Name.TabIndex = 13;
            this.txt_Box_Male_Name.TextChanged += new System.EventHandler(this.txt_Box_Male_Name_TextChanged);
            // 
            // btn_Upload_Photo
            // 
            this.btn_Upload_Photo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btn_Upload_Photo.Font = new System.Drawing.Font("Tajawal", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Upload_Photo.Location = new System.Drawing.Point(6, 105);
            this.btn_Upload_Photo.Name = "btn_Upload_Photo";
            this.btn_Upload_Photo.Size = new System.Drawing.Size(130, 27);
            this.btn_Upload_Photo.TabIndex = 12;
            this.btn_Upload_Photo.Text = "Upload Photo";
            this.btn_Upload_Photo.UseVisualStyleBackColor = false;
            this.btn_Upload_Photo.Click += new System.EventHandler(this.btn_Upload_Photo_Click);
            // 
            // Edit_Meal_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = global::Restaurant__Order_Management_System.Properties.Resources.لقطة_شاشة_2025_01_20_233648;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(468, 229);
            this.Controls.Add(this.richTextBox_Male_Info);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txtBox_Male_Price);
            this.Controls.Add(this.txt_Box_Male_Name);
            this.Controls.Add(this.btn_Upload_Photo);
            this.Controls.Add(this.pictureBox_Viewer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Edit_Meal_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Form10_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Viewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Viewer;
        private System.Windows.Forms.RichTextBox richTextBox_Male_Info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox txtBox_Male_Price;
        private System.Windows.Forms.TextBox txt_Box_Male_Name;
        private System.Windows.Forms.Button btn_Upload_Photo;
    }
}