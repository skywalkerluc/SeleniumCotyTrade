namespace ModuleView
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Access = new System.Windows.Forms.Button();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CheckExistence = new System.Windows.Forms.Button();
            this.lb_ExistingPeople = new System.Windows.Forms.ListBox();
            this.btn_ExcelData = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.btn_CreateUsers = new System.Windows.Forms.Button();
            this.btn_Help = new System.Windows.Forms.Button();
            this.btn_JustEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Access
            // 
            this.btn_Access.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Access.Location = new System.Drawing.Point(185, 60);
            this.btn_Access.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Access.Name = "btn_Access";
            this.btn_Access.Size = new System.Drawing.Size(134, 47);
            this.btn_Access.TabIndex = 0;
            this.btn_Access.Text = "Access CotyTrade";
            this.btn_Access.UseVisualStyleBackColor = false;
            this.btn_Access.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Path
            // 
            this.txt_Path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Path.Location = new System.Drawing.Point(96, 21);
            this.txt_Path.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(671, 20);
            this.txt_Path.TabIndex = 2;
            this.txt_Path.TextChanged += new System.EventHandler(this.txt_Path_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Document path:";
            // 
            // btn_CheckExistence
            // 
            this.btn_CheckExistence.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_CheckExistence.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CheckExistence.Location = new System.Drawing.Point(361, 60);
            this.btn_CheckExistence.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CheckExistence.Name = "btn_CheckExistence";
            this.btn_CheckExistence.Size = new System.Drawing.Size(135, 47);
            this.btn_CheckExistence.TabIndex = 4;
            this.btn_CheckExistence.Text = "Check for existence...";
            this.btn_CheckExistence.UseVisualStyleBackColor = false;
            this.btn_CheckExistence.Click += new System.EventHandler(this.button2_Click);
            // 
            // lb_ExistingPeople
            // 
            this.lb_ExistingPeople.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_ExistingPeople.FormattingEnabled = true;
            this.lb_ExistingPeople.Location = new System.Drawing.Point(11, 129);
            this.lb_ExistingPeople.Margin = new System.Windows.Forms.Padding(2);
            this.lb_ExistingPeople.Name = "lb_ExistingPeople";
            this.lb_ExistingPeople.Size = new System.Drawing.Size(843, 290);
            this.lb_ExistingPeople.TabIndex = 5;
            // 
            // btn_ExcelData
            // 
            this.btn_ExcelData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_ExcelData.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ExcelData.Enabled = false;
            this.btn_ExcelData.Location = new System.Drawing.Point(20, 60);
            this.btn_ExcelData.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ExcelData.Name = "btn_ExcelData";
            this.btn_ExcelData.Size = new System.Drawing.Size(134, 47);
            this.btn_ExcelData.TabIndex = 6;
            this.btn_ExcelData.Text = "Get Excel Data";
            this.btn_ExcelData.UseVisualStyleBackColor = false;
            this.btn_ExcelData.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Browse.BackColor = System.Drawing.SystemColors.Control;
            this.btn_Browse.Location = new System.Drawing.Point(775, 21);
            this.btn_Browse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(79, 21);
            this.btn_Browse.TabIndex = 7;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = false;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // btn_CreateUsers
            // 
            this.btn_CreateUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_CreateUsers.BackColor = System.Drawing.SystemColors.Control;
            this.btn_CreateUsers.Location = new System.Drawing.Point(542, 60);
            this.btn_CreateUsers.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CreateUsers.Name = "btn_CreateUsers";
            this.btn_CreateUsers.Size = new System.Drawing.Size(135, 47);
            this.btn_CreateUsers.TabIndex = 8;
            this.btn_CreateUsers.Text = "Create...";
            this.btn_CreateUsers.UseVisualStyleBackColor = false;
            this.btn_CreateUsers.Click += new System.EventHandler(this.btn_CreateUsers_Click);
            // 
            // btn_Help
            // 
            this.btn_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Help.Location = new System.Drawing.Point(833, 424);
            this.btn_Help.Name = "btn_Help";
            this.btn_Help.Size = new System.Drawing.Size(21, 20);
            this.btn_Help.TabIndex = 9;
            this.btn_Help.Text = "?";
            this.btn_Help.UseVisualStyleBackColor = true;
            this.btn_Help.Click += new System.EventHandler(this.btn_Help_Click);
            // 
            // btn_JustEdit
            // 
            this.btn_JustEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_JustEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btn_JustEdit.Location = new System.Drawing.Point(714, 60);
            this.btn_JustEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_JustEdit.Name = "btn_JustEdit";
            this.btn_JustEdit.Size = new System.Drawing.Size(135, 47);
            this.btn_JustEdit.TabIndex = 10;
            this.btn_JustEdit.Text = "Just Edit";
            this.btn_JustEdit.UseVisualStyleBackColor = false;
            this.btn_JustEdit.Click += new System.EventHandler(this.btn_JustEdit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(860, 447);
            this.Controls.Add(this.btn_JustEdit);
            this.Controls.Add(this.btn_Help);
            this.Controls.Add(this.btn_CreateUsers);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_ExcelData);
            this.Controls.Add(this.lb_ExistingPeople);
            this.Controls.Add(this.btn_CheckExistence);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.btn_Access);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Excel2CotyTrade";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Access;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CheckExistence;
        private System.Windows.Forms.ListBox lb_ExistingPeople;
        private System.Windows.Forms.Button btn_ExcelData;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_CreateUsers;
        private System.Windows.Forms.Button btn_Help;
        private System.Windows.Forms.Button btn_JustEdit;
    }
}

