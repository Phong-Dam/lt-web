# 🎵 Music Search Application

## Giới thiệu

Đây là ứng dụng tìm kiếm bài hát với tính năng tự động hoàn thành thông minh, cho phép tìm kiếm theo tên bài hát hoặc ca sĩ và xem video trực tiếp. Ứng dụng được xây dựng trên nền tảng ASP.NET Core, với Entity Framework Core để tương tác cơ sở dữ liệu SQL Server, cùng giao diện người dùng mượt mà và trực quan.

## Tính năng chính

- **Trang chủ tích hợp**: Trang tìm kiếm bài hát đã được tích hợp làm trang chính cho ứng dụng.
- **Tìm kiếm thời gian thực**: Kết quả tìm kiếm hiển thị ngay khi người dùng gõ mà không cần nhấn Enter.
- **Hỗ trợ tiếng Việt**: Xử lý tốt các ký tự có dấu, cho phép tìm kiếm không dấu (ví dụ: "noi na" vẫn tìm được "Nơi Này Có Anh").
- **Trình phát video nội tuyến**: Nhúng video YouTube trực tiếp trên trang mà không cần chuyển hướng.
- **Giao diện tối ưu**: Thiết kế sạch sẽ với đổ bóng và bo tròn góc, tương thích với nhiều kích thước màn hình.
- **Sắp xếp theo độ phổ biến**: Hiển thị kết quả theo lượt xem với định dạng phù hợp.
- **Hỗ trợ đa ngôn ngữ**: Chuyển đổi dễ dàng giữa tiếng Việt và tiếng Anh thông qua tệp tài nguyên chuyên dụng.

## Công nghệ sử dụng

### Backend
- **ASP.NET Core**: Xây dựng các API tìm kiếm và xử lý dữ liệu.
- **Entity Framework Core**: ORM để tương tác với cơ sở dữ liệu.
- **SQL Server**: Lưu trữ thông tin bài hát và số liệu thống kê.

### Frontend
- **HTML5 & CSS3**: Cấu trúc và định dạng giao diện.
- **Bootstrap 5**: Framework CSS cho giao diện đáp ứng.
- **jQuery**: Xử lý AJAX và tương tác DOM.
- **Bootstrap Icons**: Bộ biểu tượng trực quan.

## Cài đặt và chạy

### Yêu cầu hệ thống
- **.NET SDK** (phiên bản 8.0 trở lên)
- **SQL Server** (phiên bản 2019 trở lên)
- **Visual Studio** hoặc **VS Code** với C# extension

### Bước cài đặt
1. Clone repository:
   ```
   git clone https://github.com/Phong-Dam/lt-web.git
   cd lt-web
   ```

2. Khôi phục các gói phụ thuộc:
   ```
   dotnet restore
   ```

3. Cấu hình cơ sở dữ liệu:
   - Mở file `appsettings.json` và điều chỉnh connection string phù hợp với SQL Server của bạn.

4. Chạy ứng dụng:
   ```
   dotnet run
   ```

5. Truy cập ứng dụng:
   - Mở trình duyệt và truy cập địa chỉ `https://localhost:5001` hoặc `http://localhost:5000`

## Cách sử dụng

1. **Tìm kiếm bài hát**:
   - Nhập tên bài hát hoặc ca sĩ vào ô tìm kiếm
   - Kết quả sẽ hiển thị ngay khi bạn gõ

2. **Xem video**:
   - Nhấp vào bài hát trong kết quả tìm kiếm
   - Video YouTube sẽ tự động được nhúng và phát

3. **Chuyển đổi ngôn ngữ**:
   - Sử dụng nút chuyển đổi ngôn ngữ ở góc trên bên phải để thay đổi giữa tiếng Việt và tiếng Anh

## Cấu trúc mã nguồn

- **Controllers/**: Chứa các controller xử lý yêu cầu HTTP
  - `HomeController.cs`: Xử lý trang chủ và tìm kiếm
- **Models/**: Chứa các model cho dữ liệu
  - `Song.cs`: Mô hình dữ liệu bài hát
  - `ApplicationDbContext.cs`: DbContext cho Entity Framework
  - `StringUtils.cs`: Tiện ích xử lý chuỗi và dấu tiếng Việt
- **Views/**: Chứa các view Razor
  - `Home/Index.cshtml`: Trang tìm kiếm chính
  - `Home/_SearchResults.cshtml`: Partial view cho kết quả tìm kiếm
- **Resources/**: Chứa tài nguyên đa ngôn ngữ
  - `LanguageResource.cs`: Quản lý chuỗi đa ngôn ngữ
## Thành viên nhóm

| Họ và tên            | Vai trò                   | GitHub                                          |
| -------------------- | ------------------------- | ----------------------------------------------- |
| Đàm Chiến Phong      | Backend Developer         | [@Phong-Dam](https://github.com/Phong-Dam)      |
| Nguyễn Đình Bảo      | Frontend & UI/UX Designer | [@Dinh-Bao](https://github.com/jeetinh)         |
| Nguyễn Phúc Thịnh    | Project Management        | [@Thjnhz](https://github.com/Thjnhz)            |

## Đóng góp

Mọi đóng góp đều được chào đón! Nếu bạn có bất kỳ đề xuất nào, phát hiện lỗi hoặc muốn thêm tính năng mới, vui lòng mở một issue hoặc gửi một pull request.