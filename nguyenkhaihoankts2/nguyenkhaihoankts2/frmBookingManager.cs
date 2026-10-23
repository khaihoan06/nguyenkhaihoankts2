using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class frmBookingManager : Form
    {
        private BindingList<BookingModel> _bookingList = new BindingList<BookingModel>();
        private BindingSource _bindingSource = new BindingSource();
        private int _idCounter = 1;

        public frmBookingManager()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupDataBinding();
            cboRoomType.Items.AddRange(new string[] { "Standard", "Deluxe", "VIP" });
            cboRoomType.SelectedIndex = 0;
            GenerateNewId();
        }

        private void SetupDataGridView()
        {
            dgvBookings.AutoGenerateColumns = false;
            dgvBookings.ReadOnly = true;
            dgvBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookings.MultiSelect = false;
            dgvBookings.Columns.Clear();

            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã Đặt", DataPropertyName = "BookingId" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên Khách", DataPropertyName = "CustomerName" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "CCCD", DataPropertyName = "IdentityCard" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại Phòng", DataPropertyName = "RoomType" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Ngày Nhận",
                DataPropertyName = "CheckInDate",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số Đêm", DataPropertyName = "StayDays" });
            dgvBookings.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Giá/Đêm",
                DataPropertyName = "PricePerNight",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });
        }

        private void SetupDataBinding()
        {
            _bindingSource.DataSource = _bookingList;
            dgvBookings.DataSource = _bindingSource;

            txtBookingId.DataBindings.Add("Text", _bindingSource, "BookingId", true, DataSourceUpdateMode.Never);
            txtCustomerName.DataBindings.Add("Text", _bindingSource, "CustomerName", true, DataSourceUpdateMode.Never);
            txtIdentityCard.DataBindings.Add("Text", _bindingSource, "IdentityCard", true, DataSourceUpdateMode.Never);
            cboRoomType.DataBindings.Add("SelectedItem", _bindingSource, "RoomType", true, DataSourceUpdateMode.Never);
            dtpCheckIn.DataBindings.Add("Value", _bindingSource, "CheckInDate", true, DataSourceUpdateMode.Never);
            numDays.DataBindings.Add("Value", _bindingSource, "StayDays", true, DataSourceUpdateMode.Never);
            txtPricePerNight.DataBindings.Add("Text", _bindingSource, "PricePerNight", true, DataSourceUpdateMode.Never, "0", "N0");
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                errorProvider1.SetError(txtCustomerName, "Tên khách hàng không được để trống!");
                isValid = false;
            }

            string cccd = txtIdentityCard.Text.Trim();
            if (!Regex.IsMatch(cccd, @"^(\d{9}|\d{12})$"))
            {
                errorProvider1.SetError(txtIdentityCard, "CCCD phải đủ 9 hoặc 12 chữ số!");
                isValid = false;
            }

            if (!decimal.TryParse(txtPricePerNight.Text.Replace(",", "").Trim(), out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtPricePerNight, "Giá phòng phải là số lớn hơn 0!");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var booking = new BookingModel
            {
                BookingId = txtBookingId.Text,
                CustomerName = txtCustomerName.Text.Trim(),
                IdentityCard = txtIdentityCard.Text.Trim(),
                RoomType = cboRoomType.SelectedItem?.ToString(),
                CheckInDate = dtpCheckIn.Value,
                StayDays = (int)numDays.Value,
                PricePerNight = decimal.Parse(txtPricePerNight.Text.Replace(",", "").Trim())
            };

            _bookingList.Add(booking);
            _bindingSource.MoveLast();
            btnClear_Click(sender, e);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookingModel currentBooking)
            {
                if (!ValidateInput()) return;

                currentBooking.CustomerName = txtCustomerName.Text.Trim();
                currentBooking.IdentityCard = txtIdentityCard.Text.Trim();
                currentBooking.RoomType = cboRoomType.SelectedItem?.ToString();
                currentBooking.CheckInDate = dtpCheckIn.Value;
                currentBooking.StayDays = (int)numDays.Value;
                currentBooking.PricePerNight = decimal.Parse(txtPricePerNight.Text.Replace(",", "").Trim());

                _bindingSource.ResetCurrentItem();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is BookingModel currentBooking)
            {
                var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn đặt phòng {currentBooking.BookingId}?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _bindingSource.RemoveCurrent();
                    btnClear_Click(sender, e);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            GenerateNewId();
            txtCustomerName.Clear();
            txtIdentityCard.Clear();
            cboRoomType.SelectedIndex = 0;
            dtpCheckIn.Value = DateTime.Today;
            numDays.Value = 1;
            txtPricePerNight.Clear();
            dgvBookings.ClearSelection();
        }

        private void GenerateNewId()
        {
            txtBookingId.Text = $"BK{_idCounter++:D3}";
        }
    }
}