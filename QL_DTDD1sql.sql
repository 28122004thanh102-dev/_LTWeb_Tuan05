CREATE DATABASE QL_DTTDD1;
GO
USE QL_DTTDD1;

CREATE TABLE Loai (
    MaLoai INT PRIMARY KEY,
    TenLoai NVARCHAR(50)
);

CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY,
    TenSP NVARCHAR(100),
    DuongDan NVARCHAR(200),
    Gia DECIMAL(18,2),
    MoTa NVARCHAR(MAX),
    MaLoai INT FOREIGN KEY REFERENCES Loai(MaLoai)
);

CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY,
    HoTen NVARCHAR(100),
    DienThoai NVARCHAR(20),
    GioiTinh NVARCHAR(10),
    SoThich NVARCHAR(200),
    Email NVARCHAR(100),
    MatKhau NVARCHAR(50)
);

CREATE TABLE GioHang (
    MaGH INT PRIMARY KEY,
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH),
    MaSP INT FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT,
    Ngay DATE
);

INSERT INTO Loai (MaLoai, TenLoai) VALUES
(1, 'Nokia'),
(2, 'Samsung'),
(3, 'Motorola'),
(4, 'LG'),
(5, 'Oppo');

INSERT INTO SanPham (MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai) VALUES
(101, 'Nokia N70', 'N70.jpg', 2000000, 'Nâng cấp BN', 1),
(102, 'Nokia N72', 'N72.jpg', 2100000, 'Nâng cấp BN, 2 màu Đen, Xám', 1),
(103, 'Samsung Galaxy A6', 'GalaxyA6.jpg', 5200000, 'Màu Đen, Xám, Đỏ, Bạc', 2),
(104, 'Samsung Galaxy J5', 'GalaxyJ5.jpg', 6000000, 'Nâng cấp BN, nhiều màu', 2),
(105, 'LG G7', 'LGG7.jpg', 8000000, 'Unlimited Extra', 4);

INSERT INTO KhachHang (MaKH, HoTen, DienThoai, GioiTinh, SoThich, Email, MatKhau) VALUES
(1, 'Nguyen Van A', '0912345678', 'Nam', 'Xem phim', 'vana@gmail.com', '123456'),
(2, 'Tran Thi B', '0987654321', 'Nữ', 'Nghe nhạc', 'thib@gmail.com', 'abcdef'),
(3, 'Le Van C', '0901122334', 'Nam', 'Chơi game', 'vanc@gmail.com', 'qwerty'),
(4, 'Pham Thi D', '0933445566', 'Nữ', 'Mua sắm', 'thid@gmail.com', 'pass123'),
(5, 'Hoang Van E', '0977554433', 'Nam', 'Thể thao', 'vane@gmail.com', '123abc');

INSERT INTO GioHang (MaGH, MaKH, MaSP, SoLuong, Ngay) VALUES
(1, 1, 101, 2, '2025-09-01'),
(2, 2, 103, 1, '2025-09-02'),
(3, 3, 104, 3, '2025-09-03'),
(4, 4, 102, 1, '2025-09-04'),
(5, 5, 105, 2, '2025-09-05');
