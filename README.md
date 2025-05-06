# Hướng dẫn Build & Compile
## Bước 1: Tải git (nếu chưa có)
Kiểm tra xem đã có git trên máy chưa:
Mở terminal, nhập: ``git --version``
> Nếu chưa có hãy làm theo các bước sau:
		B1: Mở terminal.
		B2:  Nhập dòng lệnh sau ``winget install --id Git.Git -e --source winget`` và đợi tải xong.
## Bước 2: Thêm SSH-Key
- Tạo ssh-key để có thể dùng được lệnh push
	- Mở terminal gõ dòng lệnh sau:
		``ssh-keygen -t ed25519 -C "your_email@example.com"``
	- Nhấn enter 3 lần
	- Vào thư mục c:/Users/YOU/.ssh
	- Mở file ``id_ed25519.pub`` và copy toàn bộ nội dung
	- Vào trang github của bạn, Mở mục Settings -> Trong menu Access, chọn mục "SSH and GPG keys" -> Chọn New SSH key -> Đặt tên (Title) và dán nội dung file ``id_ed25519.pub`` trước đó vào mục Key -> Click "add SSH key"
## Bước 3: Tải project và Mở dự án
- Vào folder vừa tạo trước đó
- Click chuột phải chọn Open in terminal

LƯU Ý: Đối với LẦN ĐẦU clone project

- Nếu dùng SSH:
- Nhập lệnh ``git clone --recurse-submodules git@github.com:xuanquoc898/PBL3.git``
- Nếu dùng HTTPS:
- Nhập lệnh ``git clone --recurse-submodules https://github.com/xuanquoc898/PBL3.git``

> Dưới đây là bước mở dự án
- Sau khi tải xong, vào lại folder, Click chuột phải vào file D2R.sln chọn Open as... (Nếu chỉ dùng visual studio thì chỉ cần nháy đúp chuột) nếu sử dụng IDE khác như rider thì hãy chọn nó

## Bước 4: Push dự án sau khi hoàn thành phiên làm việc
- Nếu là lần đầu tiên mở dự án ngay sau khi vừa mới tải xuống hãy làm theo các bước sau.
	- Cấu hình người dùng:
		Gõ lệnh sau:
		``git config --global user.email "youremail@example.com"``
		``git config --global user.name "your name"``

- Sau khi đã thực hiện "lần đầu":
	- Kiểm tra các folder/file đã chỉnh sửa: ``git status`` (Hiện màu đỏ là các folder/file chưa được đẩy lên Git)
	- Thêm các file vào local repo: ``git add .``
	- Kiểm tra lại các folder/file đã chỉnh sửa đã được đẩy lên Git chưa: ``git status`` (Nếu hiện màu xanh là đã thành công)
	- Commit các file vừa thêm: ``git commit -m "your commit"``
		nên đặt tên commit theo chức năng làm được hoặc sửa được gì
	- Push lên repo trên github: ``git push origin main``
	- Nếu có conflict vui lòng báo ngay cho tui :)))
> Sau này mỗi lần push chỉ cần làm từ bước "Thêm các file vào local repo" trở về sau


## Pull dự án sau mỗi lần mở dự án
- Mở dự án như hướng dẫn trên.
- Mở terminal của IDE
LƯU Ý: Nếu không có update gì trong MaterialDesignToolKit thì thực hiện các bước sau:
- gõ lệnh sau: ``git pull origin main``
- Sau đó vào code như bình thường
- Nếu có conflict vui lòng liên hệ tui :)))
