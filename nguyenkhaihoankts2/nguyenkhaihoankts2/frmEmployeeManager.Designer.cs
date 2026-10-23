namespace WinFormsApp
{
    partial class frmEmployeeManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnSelectAvatar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtEmpId = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblPos = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.lblSal = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtAvatarPath = new System.Windows.Forms.TextBox();
            this.btnAddEmp = new System.Windows.Forms.Button();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalEmployees = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalSalary = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuFile });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenCsv,
            this.menuSaveCsv,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // menuOpenCsv
            // 
            this.menuOpenCsv.Name = "menuOpenCsv";
            this.menuOpenCsv.Size = new System.Drawing.Size(180, 22);
            this.menuOpenCsv.Text = "Mở file CSV";
            this.menuOpenCsv.Click += new System.EventHandler(this.menuOpenCsv_Click);
            // 
            // menuSaveCsv
            // 
            this.menuSaveCsv.Name = "menuSaveCsv";
            this.menuSaveCsv.Size = new System.Drawing.Size(180, 22);
            this.menuSaveCsv.Text = "Lưu file CSV";
            this.menuSaveCsv.Click += new System.EventHandler(this.menuSaveCsv_Click);
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(180, 22);
            this.menuExit.Text = "Thoát";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(20, 40);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(120, 140);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // btnSelectAvatar
            // 
            this.btnSelectAvatar.Location = new System.Drawing.Point(20, 190);
            this.btnSelectAvatar.Name = "btnSelectAvatar";
            this.btnSelectAvatar.Size = new System.Drawing.Size(120, 30);
            this.btnSelectAvatar.TabIndex = 2;
            this.btnSelectAvatar.Text = "Chọn ảnh";
            this.btnSelectAvatar.UseVisualStyleBackColor = true;
            this.btnSelectAvatar.Click += new System.EventHandler(this.btnSelectAvatar_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(170, 45);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(52, 17);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "Mã NV:";
            // 
            // txtEmpId
            // 
            this.txtEmpId.Location = new System.Drawing.Point(260, 42);
            this.txtEmpId.Name = "txtEmpId";
            this.txtEmpId.Size = new System.Drawing.Size(200, 23);
            this.txtEmpId.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(170, 80);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 17);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Họ tên:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(260, 77);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 23);
            this.txtFullName.TabIndex = 6;
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Location = new System.Drawing.Point(170, 115);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(57, 17);
            this.lblPos.TabIndex = 7;
            this.lblPos.Text = "Chức vụ:";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(260, 112);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(200, 23);
            this.txtPosition.TabIndex = 8;
            // 
            // lblSal
            // 
            this.lblSal.AutoSize = true;
            this.lblSal.Location = new System.Drawing.Point(170, 150);
            this.lblSal.Name = "lblSal";
            this.lblSal.Size = new System.Drawing.Size(48, 17);
            this.lblSal.TabIndex = 9;
            this.lblSal.Text = "Lương:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(260, 147);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(200, 23);
            this.txtSalary.TabIndex = 10;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(170, 185);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(81, 17);
            this.lblPath.TabIndex = 11;
            this.lblPath.Text = "Đường dẫn:";
            // 
            // txtAvatarPath
            // 
            this.txtAvatarPath.Location = new System.Drawing.Point(260, 182);
            this.txtAvatarPath.Name = "txtAvatarPath";
            this.txtAvatarPath.ReadOnly = true;
            this.txtAvatarPath.Size = new System.Drawing.Size(320, 23);
            this.txtAvatarPath.TabIndex = 12;
            // 
            // btnAddEmp
            // 
            this.btnAddEmp.Location = new System.Drawing.Point(600, 178);
            this.btnAddEmp.Name = "btnAddEmp";
            this.btnAddEmp.Size = new System.Drawing.Size(120, 30);
            this.btnAddEmp.TabIndex = 13;
            this.btnAddEmp.Text = "Thêm NV";
            this.btnAddEmp.UseVisualStyleBackColor = true;
            this.btnAddEmp.Click += new System.EventHandler(this.btnAddEmp_Click);
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(20, 230);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowTemplate.Height = 24;
            this.dgvEmployees.Size = new System.Drawing.Size(740, 210);
            this.dgvEmployees.TabIndex = 14;
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalEmployees,
            this.lblTotalSalary,
            this.lblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 456);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 24);
            this.statusStrip1.TabIndex = 15;
            // 
            // lblTotalEmployees
            // 
            this.lblTotalEmployees.Name = "lblTotalEmployees";
            this.lblTotalEmployees.Size = new System.Drawing.Size(107, 19);
            this.lblTotalEmployees.Text = "Tổng số NV: 0";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(130, 19);
            this.lblTotalSalary.Text = "Tổng quỹ lương: 0 VNĐ";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(57, 19);
            this.lblTime.Text = "00:00:00";
            // 
            // frmEmployeeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 480);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.btnAddEmp);
            this.Controls.Add(this.txtAvatarPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.lblSal);
            this.Controls.Add(this.txtPosition);
            this.Controls.Add(this.lblPos);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtEmpId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnSelectAvatar);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEmployeeManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Hồ Sơ Nhân Sự & Lương";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpenCsv;
        private System.Windows.Forms.ToolStripMenuItem menuSaveCsv;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnSelectAvatar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtEmpId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label lblSal;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtAvatarPath;
        private System.Windows.Forms.Button btnAddEmp;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalEmployees;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalSalary;
        private System.Windows.Forms.ToolStripStatusLabel lblTime;
    }
}