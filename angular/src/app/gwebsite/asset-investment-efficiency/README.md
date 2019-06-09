# [Nhóm 6] Quản lý hiệu quả đầu tư tài sản cố định
### Thành viên nhóm
* Nguyễn Tiến Dũng (16520259)
* Nguyễn Việt Tiến (16521233)
* Hồ Nguyễn Nhật Tiến (16521218)
### Hướng dẫn cài đặt
* Build + Run api và angular app như bình thường.
* Riêng api, sau khi thực hiện lệnh `Update-Database`, tiến hành vào thư mục `app\gwebsite\asset-investment-efficiency\sql` của angular app, đổi tên server trong file `DbScript.bat` như sau:
```
sqlcmd -S <TÊN SERVER> -i DbScript.sql
PAUSE
```
Sau khi hoàn tất, tiến hành lưu lại và thực thi file này để tạo database demo.