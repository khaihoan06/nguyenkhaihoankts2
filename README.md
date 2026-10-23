# BÁO CÁO BÀI TẬP / ĐỒ ÁN

## THÔNG TIN SINH VIÊN

- **Họ và tên:** Nguyễn Khải Hoàn 
- **Mã số sinh viên:** 24810320086
- **Lớp:** D19QTANM1
- **Tên môn học:** Lập trình C# / Windows Forms
- **Tên bài tập:** TEST 02 - Lập trình Windows Forms Thực hành Nâng cao

---

## KẾT QUẢ THỰC HÀNH CHI TIẾT

### BÀI 1: QUẢN LÝ ĐẶT PHÒNG KHÁCH SẠN
- **Kỹ thuật thực hiện:** 
  - Khai báo cột DataGridView bằng code (`AutoGenerateColumns = false`).
  - Quản lý đồng bộ 2 chiều bằng `BindingList<BookingModel>` và `BindingSource`.
  - Kiểm tra hợp lệ dữ liệu nhập bằng `ErrorProvider`.


| ![Main]<img width="680" height="407" alt="Screenshot 2026-10-23 145626" src="https://github.com/user-attachments/assets/41c63e2c-ffe4-40cc-b44d-2d9a7eba239f" />
 | ![Error]<img width="657" height="401" alt="Screenshot 2026-10-23 145901" src="https://github.com/user-attachments/assets/917fa173-2c82-4dd2-9f87-8dd98ae6c0f5" />
 | ![Result]<img width="656" height="403" alt="Screenshot 2026-10-23 145819" src="https://github.com/user-attachments/assets/2c8b530a-b60b-4713-a734-4828332577b3" />

 |

---

### BÀI 2: QUẢN LÝ HỒ SƠ NHÂN SỰ & THÔNG TIN LƯƠNG
- **Kỹ thuật thực hiện:** 
  - `OpenFileDialog` nạp ảnh chân dung nhân viên vào `PictureBox` và lưu đường dẫn.
  - `SaveFileDialog` và `OpenFileDialog` đọc/ghi dữ liệu chuẩn file `.csv`.
  - Tự động cập nhật tổng số nhân viên và quỹ lương lên `StatusStrip`.

| Giao diện & Avatar | Hộp thoại Đọc / Ghi CSV | Danh sách nạp từ CSV |

| :---: | :---: | :---: |
| ![Main] <img width="623" height="404" alt="a1" src="https://github.com/user-attachments/assets/ab400fb1-f039-4e6f-b8b2-742e23bac449" />
| ![CSV]<img width="601" height="376" alt="a2" src="https://github.com/user-attachments/assets/9327993c-06fa-4347-bcd7-30a0835aec0f" />
 | ![Result]<img width="485" height="390" alt="a3" src="https://github.com/user-attachments/assets/0ef960f8-7efa-46e1-b86c-6c44a63a47d5" />
 |

---

### BÀI 3: HỆ THỐNG MDI QUẢN LÝ TRƯỜNG HỌC & ĐÀO TẠO
- **Kỹ thuật thực hiện:** 
  - Form cha `IsMdiContainer = true`.
  - Duyệt mảng `MdiChildren` kiểm tra form mở sẵn để ngăn chặn duplicate (mở lặp lại), gọi `.Activate()`.
  - Điều hướng sắp xếp cửa sổ (`LayoutMdi`: Cascade, Tile Horizontal, Tile Vertical).

| Khung MDI & Form con | Xếp tầng (Cascade / Tile) | Ngăn chặn Duplicate Form |
| :---: | :---: | :---: |
| ![MDI]<img width="641" height="473" alt="Screenshot 2026-10-23 150910" src="https://github.com/user-attachments/assets/c0789212-b6dd-4f3a-a255-13152b93d178" />
 | ![Cascade]<img width="445" height="284" alt="Screenshot 2026-10-23 150921" src="https://github.com/user-attachments/assets/79145894-5ffa-40a6-8895-5f962f00438a" />
 | ![Prevent Duplicate]<img width="643" height="479" alt="Screenshot 2026-10-23 150946" src="https://github.com/user-attachments/assets/9c1df1f6-5e35-4ceb-b334-f36cb94de8f3" />
|

---

### BÀI 4: TỔNG HỢP BÁO CÁO KHO HÀNG (ASYNC / AWAIT)
- **Kỹ thuật thực hiện:** 
  - Dùng `await Task.Run(...)` đưa tác vụ quét nặng xuống Background Thread giúp Form không bị đơ giật (Not Responding).
  - Cập nhật tiến độ `ProgressBar` và `%` mượt mà qua `IProgress<int>`.
  - Hủy tác vụ an toàn bằng `CancellationTokenSource`.

| Đang tải (Không đơ Form) | Hủy tác vụ thành công | Kết quả tổng hợp báo cáo |
| :---: | :---: | :---: |
| ![Running]<img width="619" height="369" alt="image" src="https://github.com/user-attachments/assets/b68715e7-92ce-40f7-a7c7-dacafcc45f0c" />
 | ![Cancel]<img width="614" height="368" alt="image" src="https://github.com/user-attachments/assets/acf2e8f5-fa5d-4a3e-b756-399121fac0b0" />
 | ![Result]<img width="617" height="366" alt="image" src="https://github.com/user-attachments/assets/0ff48955-bc13-4a88-aa20-309f24e189ad" />
 |

---

### BÀI 5: MÔ PHỎNG GIÁM SÁT IOT REAL-TIME (CROSS-THREAD SAFETY)
- **Kỹ thuật thực hiện:** 
  - Task chạy ngầm định kỳ 2 giây sinh ngẫu nhiên nhiệt độ từ 30°C - 42°C.
  - Xử lý Thread Safety bằng `this.InvokeRequired` và `this.Invoke()` (tránh lỗi `InvalidOperationException`).
  - Đổi màu nhãn cảnh báo (đỏ nếu > 37°C, xanh nếu bình thường) và ghi log vào DataGridView.

| Trạng thái Bình thường | Cảnh báo Vượt ngưỡng | Bảng Log & Đếm chu kỳ |
| :---: | :---: | :---: |
| ![Normal]<img width="488" height="351" alt="image" src="https://github.com/user-attachments/assets/a0d664f8-8f31-484d-94a0-96585e400b16" />
 | ![Warning]<img width="485" height="348" alt="image" src="https://github.com/user-attachments/assets/fb6d3d9a-000f-45da-8afa-e16b103a0087" />
 | ![Result]<img width="475" height="344" alt="image" src="https://github.com/user-attachments/assets/741ceb84-94da-4580-bebe-3f2881963859" />
 |

---


