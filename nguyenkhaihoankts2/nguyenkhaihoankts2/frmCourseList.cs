using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmCourseList : Form
    {
        public frmCourseList()
        {
            InitializeComponent();
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            var list = new List<dynamic>
            {
                new { MaHocPhan = "IT201", TenHocPhan = "Lập trình .NET & C#", SoTinChi = 3, KhoaPhuTrach = "Khoa CNTT" },
                new { MaHocPhan = "IT305", TenHocPhan = "An toàn và Bảo mật hệ thống", SoTinChi = 3, KhoaPhuTrach = "Khoa An ninh mạng" },
                new { MaHocPhan = "IT102", TenHocPhan = "Cơ sở dữ liệu nâng cao", SoTinChi = 4, KhoaPhuTrach = "Khoa CNTT" },
                new { MaHocPhan = "IT401", TenHocPhan = "Quản trị mạng & Tường lửa", SoTinChi = 3, KhoaPhuTrach = "Khoa An ninh mạng" }
            };

            dgvCourses.DataSource = list;
        }
    }
}