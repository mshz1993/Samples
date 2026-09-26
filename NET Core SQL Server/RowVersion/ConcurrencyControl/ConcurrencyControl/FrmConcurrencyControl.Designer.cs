namespace ConcurrencyControl
{
    partial class FrmConcurrencyControl
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtStudentID1 = new System.Windows.Forms.TextBox();
            this.lblStudentID1 = new System.Windows.Forms.Label();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.groupBoxStudentProperty = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCurrentRowversion = new System.Windows.Forms.Label();
            this.txtCurrentRowversion = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.txtHomeAddress = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblStudentID2 = new System.Windows.Forms.Label();
            this.txtStudentID2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxStudentProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(214, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "جستجو";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtStudentID1
            // 
            this.txtStudentID1.Location = new System.Drawing.Point(295, 25);
            this.txtStudentID1.Name = "txtStudentID1";
            this.txtStudentID1.Size = new System.Drawing.Size(100, 21);
            this.txtStudentID1.TabIndex = 1;
            // 
            // lblStudentID1
            // 
            this.lblStudentID1.AutoSize = true;
            this.lblStudentID1.Location = new System.Drawing.Point(401, 28);
            this.lblStudentID1.Name = "lblStudentID1";
            this.lblStudentID1.Size = new System.Drawing.Size(67, 13);
            this.lblStudentID1.TabIndex = 2;
            this.lblStudentID1.Text = "کد دانش آموز";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.lblStudentID1);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Controls.Add(this.txtStudentID1);
            this.groupBoxSearch.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(474, 59);
            this.groupBoxSearch.TabIndex = 3;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "جستجوی دانش آموز";
            // 
            // groupBoxStudentProperty
            // 
            this.groupBoxStudentProperty.Controls.Add(this.label1);
            this.groupBoxStudentProperty.Controls.Add(this.btnCancel);
            this.groupBoxStudentProperty.Controls.Add(this.btnSave);
            this.groupBoxStudentProperty.Controls.Add(this.lblCurrentRowversion);
            this.groupBoxStudentProperty.Controls.Add(this.txtCurrentRowversion);
            this.groupBoxStudentProperty.Controls.Add(this.lblPhone);
            this.groupBoxStudentProperty.Controls.Add(this.txtPhone);
            this.groupBoxStudentProperty.Controls.Add(this.lblHomeAddress);
            this.groupBoxStudentProperty.Controls.Add(this.txtHomeAddress);
            this.groupBoxStudentProperty.Controls.Add(this.lblLastName);
            this.groupBoxStudentProperty.Controls.Add(this.txtLastName);
            this.groupBoxStudentProperty.Controls.Add(this.lblFirstName);
            this.groupBoxStudentProperty.Controls.Add(this.txtFirstName);
            this.groupBoxStudentProperty.Controls.Add(this.lblStudentID2);
            this.groupBoxStudentProperty.Controls.Add(this.txtStudentID2);
            this.groupBoxStudentProperty.Enabled = false;
            this.groupBoxStudentProperty.Location = new System.Drawing.Point(12, 77);
            this.groupBoxStudentProperty.Name = "groupBoxStudentProperty";
            this.groupBoxStudentProperty.Size = new System.Drawing.Size(474, 200);
            this.groupBoxStudentProperty.TabIndex = 4;
            this.groupBoxStudentProperty.TabStop = false;
            this.groupBoxStudentProperty.Text = "مشخصات دانش آموز";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(309, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "لغو";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(390, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "ذخیره";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCurrentRowversion
            // 
            this.lblCurrentRowversion.AutoSize = true;
            this.lblCurrentRowversion.Location = new System.Drawing.Point(401, 131);
            this.lblCurrentRowversion.Name = "lblCurrentRowversion";
            this.lblCurrentRowversion.Size = new System.Drawing.Size(62, 13);
            this.lblCurrentRowversion.TabIndex = 14;
            this.lblCurrentRowversion.Text = "Tiem Stamp";
            // 
            // txtCurrentRowversion
            // 
            this.txtCurrentRowversion.Location = new System.Drawing.Point(253, 128);
            this.txtCurrentRowversion.Name = "txtCurrentRowversion";
            this.txtCurrentRowversion.ReadOnly = true;
            this.txtCurrentRowversion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCurrentRowversion.Size = new System.Drawing.Size(142, 21);
            this.txtCurrentRowversion.TabIndex = 13;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(401, 104);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(28, 13);
            this.lblPhone.TabIndex = 12;
            this.lblPhone.Text = "تلفن";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(253, 101);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(142, 21);
            this.txtPhone.TabIndex = 11;
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.AutoSize = true;
            this.lblHomeAddress.Location = new System.Drawing.Point(401, 77);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(54, 13);
            this.lblHomeAddress.TabIndex = 10;
            this.lblHomeAddress.Text = "آدرس خانه";
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.Location = new System.Drawing.Point(24, 74);
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.Size = new System.Drawing.Size(371, 21);
            this.txtHomeAddress.TabIndex = 9;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(172, 53);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(65, 13);
            this.lblLastName.TabIndex = 8;
            this.lblLastName.Text = "نام خانوادگی";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(24, 47);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(142, 21);
            this.txtLastName.TabIndex = 7;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(401, 50);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(20, 13);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "نام";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(253, 47);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(142, 21);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblStudentID2
            // 
            this.lblStudentID2.AutoSize = true;
            this.lblStudentID2.Location = new System.Drawing.Point(401, 23);
            this.lblStudentID2.Name = "lblStudentID2";
            this.lblStudentID2.Size = new System.Drawing.Size(67, 13);
            this.lblStudentID2.TabIndex = 4;
            this.lblStudentID2.Text = "کد دانش آموز";
            // 
            // txtStudentID2
            // 
            this.txtStudentID2.Location = new System.Drawing.Point(295, 20);
            this.txtStudentID2.Name = "txtStudentID2";
            this.txtStudentID2.ReadOnly = true;
            this.txtStudentID2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStudentID2.Size = new System.Drawing.Size(100, 21);
            this.txtStudentID2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 16;
            this.label1.Text = "مسعود طاهری\r\nwww.NikAmooz.com";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmConcurrencyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 288);
            this.Controls.Add(this.groupBoxStudentProperty);
            this.Controls.Add(this.groupBoxSearch);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmConcurrencyControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "کنترل همزمانی";
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxStudentProperty.ResumeLayout(false);
            this.groupBoxStudentProperty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtStudentID1;
        private System.Windows.Forms.Label lblStudentID1;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.GroupBox groupBoxStudentProperty;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblStudentID2;
        private System.Windows.Forms.TextBox txtStudentID2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCurrentRowversion;
        private System.Windows.Forms.TextBox txtCurrentRowversion;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblHomeAddress;
        private System.Windows.Forms.TextBox txtHomeAddress;
        private System.Windows.Forms.Label label1;
    }
}

