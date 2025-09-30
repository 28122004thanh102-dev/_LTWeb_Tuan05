-- Tạo database
IF DB_ID(N'QL_NhanSu') IS NULL
BEGIN
    CREATE DATABASE QL_NhanSu;
END
GO

USE QL_NhanSu;
GO

-- Bỏ nếu đã tồn tại (dùng khi thử nhiều lần)
IF OBJECT_ID('dbo.tblEmployee','U') IS NOT NULL DROP TABLE dbo.tblEmployee;
IF OBJECT_ID('dbo.tblDepartment','U') IS NOT NULL DROP TABLE dbo.tblDepartment;
GO

-- Tạo bảng Department
CREATE TABLE dbo.tblDepartment
(
    DeptId INT NOT NULL PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL
);
GO

-- Tạo bảng Employee (Id là PK, DeptId là FK)
CREATE TABLE dbo.tblEmployee
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    Gender NVARCHAR(10) NULL,
    City NVARCHAR(200) NULL,
    DeptId INT NULL,
    CONSTRAINT FK_Employee_Department FOREIGN KEY (DeptId)
        REFERENCES dbo.tblDepartment(DeptId)
        ON DELETE SET NULL
        ON UPDATE CASCADE
);
GO

-- Dữ liệu mẫu cho Department (theo hình)
INSERT INTO dbo.tblDepartment (DeptId, Name) VALUES
(1, N'Khoa CNTT'),
(2, N'Khoa Ngoại Ngữ'),
(3, N'Khoa Tài Chính'),
(4, N'Khoa Thực Phẩm'),
(5, N'Phòng Đào Tạo');
GO

-- Dữ liệu mẫu cho Employee (ví dụ lấy theo hình - bạn có thể sửa tên/city/gender)
INSERT INTO dbo.tblEmployee (Name, Gender, City, DeptId) VALUES
(N'Nguyễn Hải Yến', N'Nữ', N'Đà Lạt', 1),
(N'Trương Mạnh Hùng', N'Nam', N'TP.HCM', 1),
(N'Đinh Duy Minh Nguyệt', N'Nam', N'Thái Bình', 2),
(N'Ngô Thị Nguyệt', N'Nữ', N'Long An', 2),
(N'Đào Minh Châu', N'Nữ', N'Bạc Liêu', 3),
(N'Phan Thị Ngọc Mai', N'Nữ', N'Bến Tre', 3),
(N'Trương Nguyễn Quỳnh Anh', N'Nữ', N'TP.HCM', 4),
(N'Lê Thanh Liêm', N'Nam', N'TP.HCM', 4),
(N'bbb', N'Nữ', N'TP.HCM', 5)
GO

-- Kiểm tra dữ liệu
SELECT * FROM dbo.tblDepartment ORDER BY DeptId;
SELECT * FROM dbo.tblEmployee ORDER BY Id;
GO
