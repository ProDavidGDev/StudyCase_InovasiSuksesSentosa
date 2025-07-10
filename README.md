# Take-Home Test - Aplikasi Absensi Karyawan

Project submission untuk tes take-home developer intern. Aplikasi ini dibuat menggunakan ASP.NET Core MVC untuk mengelola dan menampilkan data absensi karyawan.

## Teknologi yang Digunakan
* ASP.NET Core 8 MVC(Web Framework)
* Entity Framework Core 8(Object-Relational Mapping)
* SQL Server Express(Database)
* C#(Programming Language(Backend))

## Tahap-Tahap Pelaksanaan Project

1.  **Clone Repositori**
    ```sh
    git clone [URL_GITHUB_ANDA]
    ```

2.  **Restore Database**
    - Buka SQL Server Management Studio atau gunakan SQL Server Object Explorer di Visual Studio.
    - Buat sebuah database baru (misalnya `CaseStudyDB`).
    - Jalankan skrip SQL yang ada di folder `Database` dengan urutan:
      1.  `1_Schema.sql` (untuk membuat tabel)
      2.  `2_Data.sql` (untuk mengisi data awal)

3.  **Update Connection String**
    - Buka file `appsettings.json`.
    - Pastikan `ConnectionStrings` sudah sesuai dengan nama server dan database yang Anda gunakan.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=CaseStudyDB;Trusted_Connection=True;"
    }
    ```

4.  **Jalankan Aplikasi**
    - Buka file `.sln` dengan Visual Studio 2022.
    - Tekan tombol `F5` atau tombol play hijau untuk menjalankan proyek.
