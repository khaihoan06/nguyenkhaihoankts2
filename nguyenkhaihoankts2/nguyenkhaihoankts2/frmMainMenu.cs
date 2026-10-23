using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
            this.Text = "MENU TỔNG HỢP TEST 02";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Width = 450;
            this.Height = 440;

            string[] titles = {
                "Bài 1: Đặt Phòng Khách Sạn (2-Way Binding)",
                "Bài 2: Hồ Sơ Nhân Sự & Lương (CSV & Dialogs)",
                "Bài 3: Hệ Thống MDI Quản Lý Trường Học",
                "Bài 4: Báo Cáo Kho Hàng (Async/Await)",
                "Bài 5: Giám Sát IoT Real-time (Cross-Thread)"
            };

            for (int i = 0; i < titles.Length; i++)
            {
                var btn = new Button
                {
                    Text = titles[i],
                    Top = 25 + i * 65,
                    Left = 40,
                    Width = 350,
                    Height = 48,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular)
                };

                int index = i + 1;
                btn.Click += (s, e) => OpenLesson(index);
                this.Controls.Add(btn);
            }
        }

        // Bổ sung hàm này để hết lỗi CS0103 trong frmMainMenu.Designer.cs
        private void frmMainMenu_Load(object sender, EventArgs e)
        {
        }

        private void OpenLesson(int lessonNumber)
        {
            Form formToOpen = lessonNumber switch
            {
                1 => new frmBookingManager(),
                2 => new frmEmployeeManager(),
                3 => new frmSchoolMain(),
                4 => new frmWarehouseAnalytics(),
                5 => new frmIoTMonitor(),
                _ => null!
            };

            if (formToOpen != null)
            {
                formToOpen.ShowDialog();
            }
        }
    }
}