## Quy định

**Áp dụng kể từ lần merge code kế tiếp (sau commit [80b44f]), ai đang vi phạm trong đợt merge code
lần này phải sửa lại nếu muốn được merge lần kế tiếp**

Các trường hợp sẽ không nhận code:

- Build chương trình lỗi, chỗ nào lỗi chưa làm xong thì comment lại
- Build chương trình chạy nhưng console có lỗi
- Không đặt tên label, button... bằng tiếng việt
- Không đặt tên label, button... bằng tên biến hay gì đó trong code
    - VD: không đặt tên button là CreateNewHoSoThau (thật sự k cần phải đề ra quy tắc này tại mọi người làm lố quá) 
- Mỗi lần nhóm trưởng merge code thì nhánh nào trễ quá 12h ngày sẽ KHÔNG merge
    Cho nên trước khi code nhớ pull về và trc khi đẩy lên pull về một lần nữa:
    Không bắt buộc nhưng nên làm theo nếu không muốn vi phạm quy tắc này

Tất cả các trường hợp vi phạm không được merge sẽ **xem như là chưa làm**


## Checkout

- Update database and run host
    - Open visual studio
    - Choose ...MVC.Host as default project
    - Build and run
    - Open package manager console
    ```
    Update-Database
    ```

- Run application
```
npm install # if needed
npm start
```

checkout -> ~~rename server~~ ->
Update-Database -> run web.host ->
~~refresh~~ -> npm start

## Update server name in config files when checking out
- Copy all files in `hooks/` to `.git/hooks/`


[80b44f]: https://github.com/catrom/AssetManagement/commit/80b44f661266a59e70b9bd4c01853757862d71aa