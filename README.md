Для первого запуска программы необходимо выполнить следующие шаги:
1. Установить СУБД MS SQL Server 2008 R2.
2. Скопировать файлы БД ([DietDB.mdf](https://drive.google.com/file/d/1oi5ikQ1GN5Kdby4nf6xkROe-ZfSMHS-x/view?usp=sharing) и [DietDB_log.ldf](https://drive.google.com/file/d/1vLkPS0U4FKXQizCRa7ztqlzsJYD5sOTB/view?usp=sharing)) в папку Data (по умолчанию путь: C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA).
3. Открыть «Среда Microsoft SQL Server Management Studio» (Пуск -> Microsoft SQL Server 2008 R2).
4. Скопировать из открывшегося окна имя сервера.
5. Нажать «Соединить».
6. В обозревателе объектов (левая часть окна среды Microsoft SQL Server Management Studio) нажать правой кнопкой мыши по строке «Базы данных», выбрать пункт меню «Присоединить...».
7. В открывшемся окне нажать «Добавить», выбрать из списка файл БД DietDB.mdf, нажать «ОК».
8. Удостоверившись, что БД была подключена, нажать «ОК».
9. Открыть исходный код программы (решение) в среде разработки Visual Studio.
10. В файле Program.cs в 9 строке заменить параметр DataSource на скопированное в п.4 имя сервера. Строка будет выглядеть следующим образом: public static SqlConnection sqlConnection = new SqlConnection(@"Data Source=ИМЯСЕРВЕРА;Initial Catalog=DietDB;Integrated Security=True");.
11. Собрать решение (Сборка -> Собрать решение).
12. Далее запустить программу можно из среды Visual Stidio через режим запуска отладки (Отладка -> Начать отладку; альтернатива – клавиша F5) или через открытие exe-файла с программой из папки с решением (DSS_Diet\DSS_Diet\bin\Debug\netcoreapp3.1\DSS_Diet.exe).
