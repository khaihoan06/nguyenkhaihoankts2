using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class frmIoTMonitor : Form
    {
        private CancellationTokenSource _cts;
        private int _signalCount = 0;

        public frmIoTMonitor()
        {
            InitializeComponent();
            SetupLogsGrid();
            btnStop.Enabled = false;
        }

        private void SetupLogsGrid()
        {
            dgvLogs.Columns.Clear();
            dgvLogs.Columns.Add("colTime", "Thời Gian");
            dgvLogs.Columns.Add("colTemp", "Nhiệt Độ (°C)");
            dgvLogs.Columns.Add("colStatus", "Đánh Giá");
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            statusConnection.Text = "Trạng thái: Đang kết nối...";

            Task.Run(() => SensorWorkerLoop(_cts.Token));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            statusConnection.Text = "Trạng thái: Đã ngắt kết nối";
        }

        private async Task SensorWorkerLoop(CancellationToken token)
        {
            var rand = new Random();
            try
            {
                while (!token.IsCancellationRequested)
                {
                    double temp = Math.Round(30.0 + rand.NextDouble() * 12.0, 1);
                    UpdateUi(temp);
                    await Task.Delay(2000, token);
                }
            }
            catch (TaskCanceledException) { }
        }

        private void UpdateUi(double temp)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateUi(temp)));
                return;
            }

            _signalCount++;
            statusCycleCount.Text = $"Chu kỳ tín hiệu: {_signalCount}";

            lblTemperature.Text = $"{temp:F1} °C";
            lblTemperature.ForeColor = (temp > 37.0) ? Color.Red : Color.ForestGreen;

            string evaluation = temp > 37.0 ? "Cảnh báo vượt ngưỡng" : "Bình thường";
            dgvLogs.Rows.Insert(0, DateTime.Now.ToString("HH:mm:ss"), $"{temp:F1}", evaluation);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _cts?.Cancel();
            base.OnFormClosing(e);
        }
    }
}