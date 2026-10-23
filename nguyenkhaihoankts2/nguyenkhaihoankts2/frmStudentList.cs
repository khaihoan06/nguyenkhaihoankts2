using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmStudentList : Form
    {
        public frmStudentList()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            var list = new List<dynamic>
            {
                new { MSSV = "22110001", HoTen = "Nguyễn Văn An", Lop = "D16CNPM1", ChuyenNganh = "Công nghệ phần mềm", DiemTB = 8.5 },
                new { MSSV = "22110002", HoTen = "Trần Thị Bình", Lop = "D16ANM1", ChuyenNganh = "Quản trị An ninh mạng", DiemTB = 8.8 },
                new { MSSV = "22110003", HoTen = "Lê Hoàng Long", Lop = "D16HTTT", ChuyenNganh = "Hệ thống thông tin", DiemTB = 7.9 },
                new { MSSV = "22110004", HoTen = "Phạm Xuân Đức", Lop = "D16ANM1", ChuyenNganh = "Quản trị An ninh mạng", DiemTB = 9.1 },
                new { MSSV = "22110005", HoTen = "Vũ Tuấn Kiệt", Lop = "D16CNPM2", ChuyenNganh = "Công nghệ phần mềm", DiemTB = 8.0 }
            };

            dgvStudents.DataSource = list;
        }
    }
}