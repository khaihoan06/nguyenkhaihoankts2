using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class frmEmployeeManager : Form
    {
        private BindingList<EmployeeModel> _employeeList = new BindingList<EmployeeModel>();

        public frmEmployeeManager()
        {
            InitializeComponent();
            SetupGrid();
            dgvEmployees.DataSource = _employeeList;
            _employeeList.ListChanged += (s, e) => UpdateStatusStrip();

            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (s, e) => lblTime.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            timer.Start();
        }

        private void SetupGrid()
        {
            dgvEmployees.AutoGenerateColumns = false;
            dgvEmployees.ReadOnly = true;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Columns.Clear();
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã NV", DataPropertyName = "EmployeeId" });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Họ Tên", DataPropertyName = "FullName" });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chức Vụ", DataPropertyName = "Position" });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Lương",
                DataPropertyName = "Salary",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đường Dẫn Ảnh", DataPropertyName = "AvatarPath" });
        }

        private void btnSelectAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh chân dung nhân viên";
                ofd.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.ImageLocation = ofd.FileName;
                    txtAvatarPath.Text = ofd.FileName;
                }
            }
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _employeeList.Add(new EmployeeModel
            {
                EmployeeId = txtEmpId.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Position = txtPosition.Text.Trim(),
                Salary = decimal.TryParse(txtSalary.Text.Trim(), out decimal sal) ? sal : 0,
                AvatarPath = txtAvatarPath.Text.Trim()
            });

            txtEmpId.Clear();
            txtFullName.Clear();
            txtPosition.Clear();
            txtSalary.Clear();
            txtAvatarPath.Clear();
            picAvatar.Image = null;
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow?.DataBoundItem is EmployeeModel emp)
            {
                if (!string.IsNullOrEmpty(emp.AvatarPath) && File.Exists(emp.AvatarPath))
                {
                    picAvatar.ImageLocation = emp.AvatarPath;
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
        }

        private void UpdateStatusStrip()
        {
            lblTotalEmployees.Text = $"Tổng số NV: {_employeeList.Count}";
            lblTotalSalary.Text = $"Tổng quỹ lương: {_employeeList.Sum(emp => emp.Salary):N0} VNĐ";
        }

        private void menuSaveCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = "DanhSachNhanVien.csv";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Mã NV,Họ Tên,Chức Vụ,Lương,Đường Dẫn Ảnh");
                    foreach (var emp in _employeeList)
                    {
                        sb.AppendLine($"{emp.EmployeeId},{emp.FullName},{emp.Position},{emp.Salary},{emp.AvatarPath}");
                    }
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void menuOpenCsv_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CSV File (*.csv)|*.csv";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _employeeList.Clear();
                    var lines = File.ReadAllLines(ofd.FileName);
                    for (int i = 1; i < lines.Length; i++)
                    {
                        var parts = lines[i].Split(',');
                        if (parts.Length >= 5)
                        {
                            _employeeList.Add(new EmployeeModel
                            {
                                EmployeeId = parts[0].Trim(),
                                FullName = parts[1].Trim(),
                                Position = parts[2].Trim(),
                                Salary = decimal.TryParse(parts[3], out decimal sal) ? sal : 0,
                                AvatarPath = parts[4].Trim()
                            });
                        }
                    }
                    MessageBox.Show("Nạp dữ liệu từ CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}