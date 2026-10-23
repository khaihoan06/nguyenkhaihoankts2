using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmWarehouseAnalytics : Form
    {
        private CancellationTokenSource _cts;

        public frmWarehouseAnalytics()
        {
            InitializeComponent();
            cboWarehouse.Items.AddRange(new string[] { "Kho Tổng Hà Nội", "Kho Đà Nẵng", "Kho TP. Hồ Chí Minh" });
            cboWarehouse.SelectedIndex = 0;
            btnCancel.Enabled = false;
        }

        private async void btnGenerateReport_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            btnGenerateReport.Enabled = false;
            btnCancel.Enabled = true;
            pgbStatus.Value = 0;
            lblPercent.Text = "0%";

            var progress = new Progress<int>(percent =>
            {
                pgbStatus.Value = percent;
                lblPercent.Text = $"{percent}%";
            });

            try
            {
                var data = await Task.Run(() => ComputeReportData(_cts.Token, progress), _cts.Token);
                dgvReportData.DataSource = data;
                MessageBox.Show("Hoàn tất tổng hợp báo cáo kho!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Đã hủy tác vụ tải dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pgbStatus.Value = 0;
                lblPercent.Text = "Đã hủy";
            }
            finally
            {
                btnGenerateReport.Enabled = true;
                btnCancel.Enabled = false;
                _cts?.Dispose();
                _cts = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private List<dynamic> ComputeReportData(CancellationToken token, IProgress<int> progress)
        {
            var result = new List<dynamic>();
            for (int i = 1; i <= 100; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(45); // 45ms x 100 = 4.5 giây
                progress?.Report(i);
            }

            for (int i = 1; i <= 25; i++)
            {
                result.Add(new
                {
                    Mã_Mặt_Hàng = $"MH{i:D03}",
                    Tên_Vật_Tư = $"Thiết bị viễn thông #{i}",
                    Tồn_Kho = (i * 17) % 200 + 15,
                    Đơn_Giá = (i * 150000),
                    Tổng_Giá_Trị = ((i * 17) % 200 + 15) * (i * 150000)
                });
            }

            return result;
        }
    }
}