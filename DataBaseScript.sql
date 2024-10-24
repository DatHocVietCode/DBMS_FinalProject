USE [master]
GO
/****** Object:  Database [PetShop]    Script Date: 10/24/2024 11:22:16 PM ******/
CREATE DATABASE [PetShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PetShop', FILENAME = N'C:\Users\LAPTOP\PetShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PetShop_log', FILENAME = N'C:\Users\LAPTOP\PetShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PetShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PetShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PetShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PetShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PetShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PetShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PetShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PetShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PetShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PetShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PetShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PetShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PetShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PetShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PetShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PetShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PetShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PetShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PetShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PetShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PetShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PetShop] SET  MULTI_USER 
GO
ALTER DATABASE [PetShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PetShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PetShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PetShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PetShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PetShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PetShop] SET QUERY_STORE = OFF
GO
USE [PetShop]
GO
/****** Object:  UserDefinedFunction [dbo].[TinhTongTien]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[TinhTongTien](@makhachhang int = null, @mahoadon int)
returns decimal(18,2)
as
begin 
	declare @DTL int = 0;  -- Gán giá trị mặc định cho DTL nếu không tìm thấy
	declare @ChietKhau float = 0; -- Giá trị mặc định
 
	-- Nếu @MaKH không NULL, lấy Diem_Tich_Luy
	if @makhachhang is not null
	begin
    	set @DTL = (select Diem_Tich_Luy
                	from KhachHang
                	where Ma_Khach_Hang = @makhachhang)
	end
	
	-- Xác định chiết khấu
	if (@DTL >= 1000)
    	set @ChietKhau = 0.15;
	else if (@DTL >= 500)
    	set @ChietKhau = 0.1;
	else if (@DTL >= 300)
    	set @ChietKhau = 0.07;
	else if (@DTL >= 100)
    	set @ChietKhau = 0.05;
	else if (@DTL >= 10)
    	set @ChietKhau = 0.02;

	declare @tongtien int
	SET @tongtien = (
    	SELECT SUM(CTHD.So_Luong * Gia_Khuyen_Mai)
    	FROM ChiTietHoaDon CTHD
    	JOIN SanPhamVaDichVu SPDV ON CTHD.Ma_SPDV = SPDV.Ma_SPDV
    	WHERE CTHD.Ma_Hoa_Don = @mahoadon
	) * (1 - @ChietKhau)
	 return @tongtien
end
GO
/****** Object:  Table [dbo].[SanPhamVaDichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamVaDichVu](
	[Ma_SPDV] [int] NOT NULL,
	[Ten] [nvarchar](100) NOT NULL,
	[Mo_Ta] [nvarchar](max) NULL,
	[Gia_Ban_Goc] [decimal](18, 2) NOT NULL,
	[Gia_Khuyen_Mai] [decimal](18, 2) NOT NULL,
 CONSTRAINT [SPDV_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_SPDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuCung]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuCung](
	[Ma_Thu_Cung] [int] NOT NULL,
	[Loai] [nvarchar](100) NULL,
	[Giong] [nvarchar](100) NULL,
	[Ngay_Sinh] [datetime] NULL,
	[Gioi_Tinh] [nvarchar](10) NULL,
	[Mau_Sac] [nvarchar](100) NULL,
	[Can_Nang] [decimal](18, 2) NULL,
	[Tinh_Trang_Suc_Khoe] [nvarchar](max) NULL,
	[Trang_Thai] [nvarchar](100) NULL,
	[So_Lan_Tiem] [int] NOT NULL,
 CONSTRAINT [TC_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Thu_Cung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[XemChiTietThuCung]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[XemChiTietThuCung] (@idthucung int)
returns table
as
return (
	select spdv.Ma_SPDV, spdv.Ten, spdv.Mo_Ta, spdv.Gia_Ban_Goc, spdv.Gia_Khuyen_Mai,
	tc.Can_Nang, tc.Gioi_Tinh, tc.Giong, tc.Loai, tc.Mau_Sac, tc.Ngay_Sinh, tc.So_Lan_Tiem, tc.Tinh_Trang_Suc_Khoe, tc.Trang_Thai
	from ThuCung tc join SanPhamVaDichVu spdv on tc.Ma_Thu_Cung = spdv.Ma_SPDV
	where tc.Ma_Thu_Cung = @idthucung
)
GO
/****** Object:  Table [dbo].[HinhAnh]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnh](
	[Ma_SPDV] [int] NOT NULL,
	[Duong_Dan] [varchar](255) NOT NULL,
 CONSTRAINT [HA_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_SPDV] ASC,
	[Duong_Dan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[LayHinhAnh]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[LayHinhAnh] (@idspdv int)
returns table
as 
return
(select Duong_Dan
	from HinhAnh
	where HinhAnh.Ma_SPDV = @idspdv)
GO
/****** Object:  Table [dbo].[VatPham]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VatPham](
	[Ma_Vat_Pham] [int] NOT NULL,
	[Thuong_Hieu] [nvarchar](100) NULL,
	[Han_Su_Dung] [datetime] NULL,
	[So_Luong_Ton_Kho] [int] NULL,
 CONSTRAINT [VP_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Vat_Pham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[XemChiTietVatPham]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create function [dbo].[XemChiTietVatPham] (@idVatPham int)
returns table
as
return (
	select spdv.Ma_SPDV, spdv.Ten, spdv.Mo_Ta, spdv.Gia_Ban_Goc, spdv.Gia_Khuyen_Mai,
	vp.Thuong_Hieu, vp.So_Luong_Ton_Kho, vp.Han_Su_Dung
	from VatPham vp join SanPhamVaDichVu spdv on vp.Ma_Vat_Pham = spdv.Ma_SPDV
	where vp.Ma_Vat_Pham = @idVatPham
)

GO
/****** Object:  View [dbo].[DanhSachThuCung]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DanhSachThuCung] AS
SELECT 
    TC.Ma_Thu_Cung,
    SPDV.Ten AS Ten_San_Pham,
    TC.Loai,
    TC.Giong,
    TC.Gioi_Tinh,
    TC.Trang_Thai,
    SPDV.Gia_Ban_Goc,
    SPDV.Gia_Khuyen_Mai,
    (SELECT TOP 1 HA.Duong_Dan 
     FROM HinhAnh HA 
     WHERE HA.Ma_SPDV = SPDV.Ma_SPDV) AS Hinh_Anh
FROM 
    ThuCung TC
JOIN 
    SanPhamVaDichVu SPDV
ON 
    TC.Ma_Thu_Cung = SPDV.Ma_SPDV;
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Ma_Khach_Hang] [int] IDENTITY(6,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[SDT] [varchar](10) NULL,
	[Diem_Tich_Luy] [int] NULL,
 CONSTRAINT [KH_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Khach_Hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DanhSachKhachHang]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DanhSachKhachHang] AS
SELECT 
    Ma_Khach_Hang,
    Ten,
    SDT,
    Diem_Tich_Luy
FROM 
    KhachHang;
GO
/****** Object:  View [dbo].[DanhSachVatPham]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[DanhSachVatPham] AS
SELECT 
    VP.Ma_Vat_Pham,
    SPDV.Ten AS Ten_San_Pham,
    VP.Thuong_Hieu,
    VP.Han_Su_Dung,
    VP.So_Luong_Ton_Kho,
    SPDV.Gia_Ban_Goc,
    SPDV.Gia_Khuyen_Mai,
    (SELECT TOP 1 HA.Duong_Dan 
     FROM HinhAnh HA 
     WHERE HA.Ma_SPDV = SPDV.Ma_SPDV) AS Hinh_Anh
FROM 
    VatPham VP
JOIN 
    SanPhamVaDichVu SPDV
ON 
    VP.Ma_Vat_Pham = SPDV.Ma_SPDV;

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[Ma_Dich_Vu] [int] NOT NULL,
	[Thoi_Gian_Thuc_Hien] [int] NULL,
	[So_Luong_Phong_Trong] [int] NULL,
 CONSTRAINT [DV_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Dich_Vu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongDichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongDichVu](
	[Ma_Phong] [int] NOT NULL,
	[Ma_Dich_Vu] [int] NULL,
	[Trang_Thai] [nvarchar](100) NULL,
	[Thoi_Gian_Bat_Dau] [datetime] NULL,
	[Thoi_Gian_Ket_Thuc] [datetime] NULL,
 CONSTRAINT [PDV_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Phong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[DanhSachPhongDichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DanhSachPhongDichVu] AS
SELECT 
    PD.Ma_Phong,
    PD.Ma_Dich_Vu,
    SPDV.Ten AS Ten_Dich_Vu,
    PD.Trang_Thai,
    PD.Thoi_Gian_Bat_Dau,
    PD.Thoi_Gian_Ket_Thuc,
    SPDV.Gia_Ban_Goc,
    SPDV.Gia_Khuyen_Mai,
    (SELECT TOP 1 HA.Duong_Dan 
     FROM HinhAnh HA 
     WHERE HA.Ma_SPDV = SPDV.Ma_SPDV) AS Hinh_Anh
FROM 
    PhongDichVu PD
JOIN 
    DichVu DV ON PD.Ma_Dich_Vu = DV.Ma_Dich_Vu
JOIN 
    SanPhamVaDichVu SPDV ON DV.Ma_Dich_Vu = SPDV.Ma_SPDV;
GO
/****** Object:  View [dbo].[DanhSachDichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DanhSachDichVu] AS
SELECT 
	dv.Ma_Dich_Vu,
	dv.So_Luong_Phong_Trong,
	dv.Thoi_Gian_Thuc_Hien,
	spdv.Gia_Ban_Goc,
	spdv.Gia_Khuyen_Mai,
	spdv.Mo_Ta,
		spdv.Ten as Ten_San_Pham,
	(SELECT TOP 1 HA.Duong_Dan 
     FROM HinhAnh HA 
     WHERE HA.Ma_SPDV = SPDV.Ma_SPDV) AS Hinh_Anh
FROM 
	DichVu dv
join SanPhamVaDichVu spdv on dv.Ma_Dich_Vu = spdv.Ma_SPDV
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[Ma_Hoa_Don] [int] IDENTITY(1,1) NOT NULL,
	[Ma_Nhan_Vien] [int] NULL,
	[Ma_Khach_Hang] [int] NULL,
	[Tong_Tien] [decimal](18, 2) NULL,
	[Trang_Thai] [nvarchar](100) NULL,
	[Giam_Gia] [decimal](18, 2) NULL,
	[Thoi_Gian_Lap] [datetime] NOT NULL,
 CONSTRAINT [HD_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Hoa_Don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[Ma_Hoa_Don] [int] NOT NULL,
	[Ma_SPDV] [int] NOT NULL,
	[So_Luong] [int] NULL,
 CONSTRAINT [CTHD_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Hoa_Don] ASC,
	[Ma_SPDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[XemChiTietHoaDon]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[XemChiTietHoaDon] (@idhoadon INT)
RETURNS TABLE
AS
RETURN
(
    SELECT hd.Ma_Hoa_Don, hd.Ma_Khach_Hang, hd.Giam_Gia, hd.Tong_Tien, 
           cthd.Ma_SPDV, cthd.So_Luong, spdv.Gia_Khuyen_Mai,
		   spdv.Ten,
		   cthd.So_Luong * spdv.Gia_Khuyen_Mai as Thanh_Tien
    FROM ChiTietHoaDon cthd
    JOIN HoaDon hd 
        ON cthd.Ma_Hoa_Don = hd.Ma_Hoa_Don
    JOIN SanPhamVaDichVu spdv 
        ON cthd.Ma_SPDV = spdv.Ma_SPDV
    WHERE cthd.Ma_Hoa_Don = @idhoadon
);
GO
/****** Object:  UserDefinedFunction [dbo].[LocHoaDonTheoThoiGianLap]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[LocHoaDonTheoThoiGianLap] (@ThoiGianLap DATETIME)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM HoaDon
    WHERE Thoi_Gian_Lap = @ThoiGianLap
);
GO
/****** Object:  Table [dbo].[BangPhanCa]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangPhanCa](
	[Buoi] [nvarchar](50) NOT NULL,
	[Ngay_Lam_Viec] [date] NOT NULL,
	[Ma_Nhan_Vien] [int] NOT NULL,
 CONSTRAINT [BPC_IsKey] PRIMARY KEY CLUSTERED 
(
	[Buoi] ASC,
	[Ngay_Lam_Viec] ASC,
	[Ma_Nhan_Vien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CaLamViec]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaLamViec](
	[Buoi] [nvarchar](50) NOT NULL,
	[Ngay_Lam_Viec] [date] NOT NULL,
	[Thoi_Gian_Bat_Dau] [time](7) NOT NULL,
	[Thoi_Gian_Ket_Thuc] [time](7) NOT NULL,
 CONSTRAINT [CLV_IsKey] PRIMARY KEY CLUSTERED 
(
	[Buoi] ASC,
	[Ngay_Lam_Viec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[Ma_Nhan_Vien] [int] NOT NULL,
	[Ho_Ten] [nvarchar](100) NOT NULL,
	[Ngay_Sinh] [date] NOT NULL,
	[Gioi_Tinh] [nvarchar](100) NOT NULL,
	[Dia_Chi] [nvarchar](100) NOT NULL,
	[SDT] [varchar](10) NOT NULL,
	[Luong] [decimal](18, 2) NOT NULL,
	[Cong_Viec] [nvarchar](100) NOT NULL,
	[Ma_NQL] [int] NULL,
 CONSTRAINT [NV_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Nhan_Vien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[Ten_Dang_Nhap] [varchar](10) NOT NULL,
	[Ma_Nhan_Vien] [int] NULL,
	[Mat_Khau] [varchar](100) NOT NULL,
	[Quyen] [varchar](10) NOT NULL,
 CONSTRAINT [TK_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ten_Dang_Nhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (6, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (7, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (8, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (9, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (10, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (11, 1, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (12, 2, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (13, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (14, 3, 4)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (14, 6, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (15, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (15, 3, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (16, 2, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (16, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (17, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (17, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (20, 8, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (21, 8, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (23, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (24, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (25, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (26, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (27, 5, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (27, 6, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (28, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (28, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (28, 11, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (29, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (29, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (31, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (38, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (39, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (39, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (39, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (40, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (40, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (41, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (42, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (42, 4, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (43, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (46, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (51, 9, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (52, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (55, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (55, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (56, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (56, 12, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (57, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (58, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (58, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (59, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (59, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (60, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (60, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (60, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (60, 6, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (61, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (61, 4, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (63, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (64, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (65, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (66, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (67, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (68, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (69, 1, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (70, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (71, 3, 4)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (72, 1, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (73, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (73, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (74, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (75, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (76, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (77, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (77, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (78, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (81, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (81, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (82, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (82, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (83, 5, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (84, 2, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (85, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (86, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (86, 13, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (86, 14, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (87, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (88, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (88, 13, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (89, 2, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (89, 3, 2)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (90, 18, 8)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (91, 21, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (92, 1, 3)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (93, 2, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (95, 3, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (95, 4, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (96, 1, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (98, 14, 1)
INSERT [dbo].[ChiTietHoaDon] ([Ma_Hoa_Don], [Ma_SPDV], [So_Luong]) VALUES (99, 15, 1)
GO
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (19, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (20, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (21, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (22, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (23, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (24, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (25, NULL, NULL)
INSERT [dbo].[DichVu] ([Ma_Dich_Vu], [Thoi_Gian_Thuc_Hien], [So_Luong_Phong_Trong]) VALUES (26, NULL, NULL)
GO
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (1, N'assets\images\thucung\1\1878-phoc-soc-trang-mat-gau-truong-thanh-size-mini-duc-10th2m-16tr-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (1, N'assets\images\thucung\1\1878-phoc-soc-trang-mat-gau-truong-thanh-size-mini-duc-10th2m-16tr-2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (1, N'assets\images\thucung\1\1878-phoc-soc-trang-mat-gau-truong-thanh-size-mini-duc-10th2m-16tr-3.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (2, N'assets\images\thucung\2\5fcc8c5bfede23807acf.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (2, N'assets\images\thucung\2\abb6f64b84ce599000df.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (3, N'assets\images\thucung\3\6735B0AB-DF78-45E6-8B3B-9269F86D700A.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (3, N'assets\images\thucung\3\98E8BBC1-FC87-45F0-98B7-00F8C4B425A8.jpeg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (3, N'assets\images\thucung\3\BCCA86C2-F468-4D93-B0F9-E1C1F3386790.jpeg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (4, N'assets\images\thucung\4\meo-aln-mau-xx-2th1m-duc-va-cai-35-6m-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (4, N'assets\images\thucung\4\meo-aln-mau-xx-2th1m-duc-va-cai-35-6m-2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (5, N'assets\images\thucung\5\d.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (5, N'assets\images\thucung\5\f.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (5, N'assets\images\thucung\5\g.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (6, N'assets\images\thucung\6\2-bengal-1252-2048x1366.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (7, N'assets\images\thucung\7\1863-corgi-mat-xanh-duc-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (7, N'assets\images\thucung\7\1863-corgi-mat-xanh-duc-2-2048x1838.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (7, N'assets\images\thucung\7\1863-corgi-mat-xanh-duc-3-2014x2048.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (8, N'assets\images\thucung\8\1773-2048x1365.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (9, N'assets\images\thucung\9\anh-meo-ba-tu-292929.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (9, N'assets\images\thucung\9\anh-meo-ba-tu-29292988977.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (10, N'assets\images\thucung\10\z5625614256150_cc8dc907e1c6c2d3b2797b14f099e1f2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (11, N'assets\images\thucung\11\anh-cho-phu-quoc-9229297788.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (11, N'assets\images\thucung\11\anh-cho-phu-quoc-9229298788.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (12, N'assets\images\thucung\12\cho-boxer.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (13, N'assets\images\vatpham\13\ezgif-3-ba043b5167.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (14, N'assets\images\vatpham\14\Sua-cho-Esbilac-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (14, N'assets\images\vatpham\14\Sua-cho-Esbilac-2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (15, N'assets\images\vatpham\15\60-sua-bot-DrKyan-cho-cho-110g-50k-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (15, N'assets\images\vatpham\15\60-sua-bot-DrKyan-cho-cho-110g-50k-2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (15, N'assets\images\vatpham\15\60-sua-bot-DrKyan-cho-cho-110g-50k-3.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (15, N'assets\images\vatpham\15\60-sua-bot-DrKyan-cho-cho-110g-50k-4.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (16, N'assets\images\vatpham\16\16-luoc-chai-long-cho-meo-PetGrooming-tang-kem-luoc-nho-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (16, N'assets\images\vatpham\16\16-luoc-chai-long-cho-meo-PetGrooming-tang-kem-luoc-nho-2-2048x1536.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (17, N'assets\images\vatpham\17\3-xuong-gam-thit-ga-Taotaopet-100-gram-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (17, N'assets\images\vatpham\17\3-xuong-gam-thit-ga-Taotaopet-100-gram-2-2048x1536.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (18, N'assets\images\vatpham\18\Nuoc-hoa-freshy-luu-huong-7-ngay-160k-1.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (18, N'assets\images\vatpham\18\Nuoc-hoa-freshy-luu-huong-7-ngay-160k-2.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (18, N'assets\images\vatpham\18\Nuoc-hoa-freshy-luu-huong-7-ngay-160k-3.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (18, N'assets\images\vatpham\18\Nuoc-hoa-freshy-luu-huong-7-ngay-160k-4.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (19, N'assets\images\dichvu\19\trong-giu-cho-meo_1612248539.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (20, N'assets\images\dichvu\20\cham-soc-thu-cung_1612248557.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (21, N'assets\images\dichvu\21\cuu-ho-thu-cung_1612248570.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (22, N'assets\images\dichvu\22\khach-san-cho-meo_1612242262.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (23, N'assets\images\dichvu\23\dich-vu-spa-cho-cho-meo_1612248623.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (24, N'assets\images\dichvu\24\tam-cho-cho-meo_1612248603.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (25, N'assets\images\dichvu\25\cat-tia-long-cho-meo_1612248645.jpg')
INSERT [dbo].[HinhAnh] ([Ma_SPDV], [Duong_Dan]) VALUES (26, N'assets\images\dichvu\26\thoi-trang-thu-cung_1612249248.jpg')
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (1, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T15:59:05.883' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (2, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:00:41.943' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (3, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:02:28.010' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (4, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:05:03.003' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (5, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:06:00.917' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (6, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:14:31.903' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (7, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:14:40.130' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (8, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:02:53.890' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (9, NULL, 0, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:14:43.063' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (10, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:15:02.920' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (11, NULL, NULL, CAST(24000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:16:00.050' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (12, NULL, NULL, CAST(24000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:17:45.920' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (13, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:23:07.713' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (14, NULL, NULL, CAST(92000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:23:42.700' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (15, NULL, NULL, CAST(52000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:19:25.503' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (16, NULL, NULL, CAST(48000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:20:21.837' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (17, NULL, NULL, CAST(40000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:25:27.563' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (20, NULL, NULL, CAST(30000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:40:14.703' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (21, NULL, NULL, CAST(10000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T20:55:12.433' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (23, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:26:45.760' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (24, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:28:46.407' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (25, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:29:36.473' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (26, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:30:19.080' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (27, NULL, NULL, CAST(62000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:32:01.107' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (28, NULL, NULL, CAST(45000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:34:03.637' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (29, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:38:18.733' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (31, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:41:43.917' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (38, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-23T22:50:19.993' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (39, NULL, NULL, CAST(36000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-23T23:21:14.010' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (40, NULL, NULL, CAST(32000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-23T23:52:42.080' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (41, NULL, 1, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:03:08.880' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (42, NULL, 0, CAST(22000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T19:40:46.037' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (43, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:07:28.357' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (44, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:08:59.207' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (45, NULL, NULL, CAST(20000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:14:29.873' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (46, NULL, NULL, CAST(20000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:15:01.440' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (47, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:15:32.907' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (48, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:16:26.217' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (49, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:17:27.663' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (50, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:19:48.610' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (51, NULL, NULL, CAST(40000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:25:10.097' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (52, NULL, 1, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:27:03.743' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (55, NULL, NULL, CAST(24000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:37:45.083' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (56, NULL, 1, CAST(26000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:53:21.833' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (57, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:57:38.980' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (58, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:58:28.133' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (59, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:59:04.900' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (60, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T00:59:16.563' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (61, NULL, 2, CAST(20900000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T19:39:53.497' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (62, NULL, 1, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:05:52.333' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (63, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:09:06.930' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (64, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:10:09.453' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (65, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:12:02.120' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (66, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:13:10.870' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (67, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T01:17:23.513' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (68, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T01:23:48.893' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (69, NULL, NULL, CAST(16000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T01:27:50.517' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (70, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:40:21.343' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (71, NULL, NULL, CAST(48000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:41:50.527' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (72, NULL, 1, CAST(24000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:42:04.407' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (73, NULL, 1, CAST(19000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:42:19.283' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (74, NULL, 1, CAST(7600000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:43:11.877' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (75, NULL, 1, CAST(11160000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:43:19.983' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (76, NULL, 1, CAST(22320000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:51:52.373' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (77, NULL, 1, CAST(18000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:52:12.300' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (78, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:54:32.250' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (79, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:58:05.587' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (80, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-24T09:58:33.470' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (81, NULL, 0, CAST(20000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:59:09.263' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (82, NULL, 2, CAST(20000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:59:32.283' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (83, NULL, 3, CAST(36000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:59:47.103' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (84, NULL, 1, CAST(21600000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T09:59:57.980' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (85, NULL, 5, CAST(12000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T10:00:12.137' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (86, NULL, 1, CAST(11443500.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T10:49:16.990' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (87, NULL, 1, CAST(10800000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T10:55:57.393' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (88, NULL, 4, CAST(16360000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T11:02:13.820' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (89, NULL, 5, CAST(38000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T12:50:00.143' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (90, NULL, 1, CAST(1156000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T12:55:29.567' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (91, NULL, 1, CAST(76500.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T13:56:11.193' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (92, NULL, 1, CAST(20400000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T18:26:47.213' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (93, NULL, 0, CAST(8000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T18:39:11.247' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (95, NULL, 0, CAST(22000000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T19:40:36.433' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (96, NULL, 0, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-24T22:40:30.677' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (98, NULL, 0, CAST(535000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T23:01:43.430' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (99, NULL, 0, CAST(50000.00 AS Decimal(18, 2)), N'Đã thanh toán', NULL, CAST(N'2024-10-24T23:01:53.683' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (0, N'Khách vãng lai', NULL, NULL)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (1, N'Võ Phan Tấn Đạt', N'0703622531', 1303)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (2, N'Hồ Nhựt Tân', N'099999998', 200)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (3, N'Huỳnh Vịt Đan', N'099999997', 360)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (4, N'Huỳnh Tuấn Kịt', N'0999999986', 163)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (5, N'Nguyễn Hòn Sơn', N'0999999985', 500)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (6, N'Tris', N'0', 0)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (7, N'Dat', N'0', 0)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (8, N'Kiu be', N'123456789', 0)
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (9, N'KhachHangA', N'0987654321', 0)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (1, N'Chó Phốc sóc màu trắng mặt gấu trưởng thành', N'Chó Ph?c sóc màu tr?ng m?t g?u tru?ng thành size mini mã PS1878 s? h?u ngo?i hình vô cùng dáng yêu và cu?n hút. B? lông dày và bông xù màu tr?ng m?m m?i nhu bông, t?o c?m giác ?m áp. Khuôn m?t tròn trinh v?i dôi m?t to sáng và bi?u c?m hi?n lành, t?o nên nét gi?ng chú g?u. Ðôi tai nh? và d?ng d?ng, cùng v?i mui den bóng, làm tang thêm v? ng? nghinh. ', CAST(10000000.00 AS Decimal(18, 2)), CAST(8000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (2, N'Chó Poodle nâu đỏ size toy mã PD977', N'Chó Poodle nâu d? size toy mã PD977 c?c k? thông minh và nang d?ng ho?t bát. Bé dã du?c tiêm 3 mui vaccine, hi?n dang có s?n t?i Pet House.', CAST(10000000.00 AS Decimal(18, 2)), CAST(8000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (3, N'Chó Golden Retriever', N'Chó Golden Retriever dễ huấn luyện, rất trung thành và thân thiện với trẻ em. Đã tiêm đủ vaccine.', CAST(15000000.00 AS Decimal(18, 2)), CAST(12000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (4, N'Mèo Anh lông ngắn', N'Mèo Anh lông ngắn có bộ lông dày, tính cách hiền lành và dễ gần. Đã được tiêm phòng đầy đủ.', CAST(12000000.00 AS Decimal(18, 2)), CAST(10000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (5, N'Chó Husky', N'Chó Husky thích hợp với người yêu thích vận động. Bé đã tiêm 2 mũi vaccine.', CAST(20000000.00 AS Decimal(18, 2)), CAST(18000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (6, N'Mèo Bengal', N'Mèo Bengal với bộ lông đặc biệt và tính cách năng động. Đã tiêm vaccine đầy đủ.', CAST(25000000.00 AS Decimal(18, 2)), CAST(22000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (7, N'Chó Corgi', N'Chó Corgi nổi tiếng với tính cách vui vẻ và thân thiện. Đã được tiêm phòng 3 mũi.', CAST(18000000.00 AS Decimal(18, 2)), CAST(15000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (8, N'Chó Pug', N'Chó Pug với tính cách đáng yêu, thích nghi tốt với môi trường sống nhỏ. Đã tiêm 3 mũi vaccine.', CAST(12000000.00 AS Decimal(18, 2)), CAST(10000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (9, N'Mèo Ba Tư', N'Mèo Ba Tư với bộ lông dài và mềm mại, tính cách điềm tĩnh. Đã được tiêm phòng đầy đủ.', CAST(22000000.00 AS Decimal(18, 2)), CAST(20000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (10, N'Chó Chihuahua', N'Chó Chihuahua nhỏ nhắn, rất dễ thương và thích hợp với cuộc sống trong căn hộ. Đã tiêm đủ vaccine.', CAST(8000000.00 AS Decimal(18, 2)), CAST(6000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (11, N'Chó Phú Quốc', N'Chó Phú Quốc có khả năng bơi lội tốt, rất thông minh và trung thành. Đã được tiêm phòng đầy đủ.', CAST(15000000.00 AS Decimal(18, 2)), CAST(13000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (12, N'Chó Boxer', N'Chó Boxer mạnh mẽ, thích chơi đùa và rất trung thành. Đã được tiêm phòng 2 mũi.', CAST(16000000.00 AS Decimal(18, 2)), CAST(14000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (13, N'Dầu tắm trị nấm cho chó mèo Fungamyl 200ml', N'Dầu tắm Fungamyl 200ml là dòng sản phẩm giúp ngăn ngừa bệnh ve rận, kí sinh cùng các bệnh tróc vảy, rụng lông do vi khuẩn nấm gây nên. Với hiệu quả nhanh chóng, an toàn đối với sức khoẻ các boss nhỏ nên người nuôi có thể an tâm sử dụng.', CAST(200000.00 AS Decimal(18, 2)), CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (14, N'Sữa chó Esbilac bổ sung dưỡng chất cho chó sơ sinh 340g', N'Sữa chó Esbilac là dòng sữa dành cho chó sơ sinh, chó non để sử dụng thay cho nguồn sữa mẹ. Đây là nguồn sữa cực kỳ thiết yếu với các trường hợp chó mất mẹ, bị mẹ bỏ hoặc đang bị suy dinh dưỡng, thiếu chất.', CAST(600000.00 AS Decimal(18, 2)), CAST(535000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (15, N'Sữa Dr Kyan cho chó con và chó trưởng thành hộp 110g', N'Sữa Dr Kyan cho chó giúp bổ sung thêm nhiều năng lượng, Vitamin và khoáng chất cho cún yêu nhà bạn. Ngoài những bữa ăn hàng ngày, bạn có thể sử dụng sữa DR Kyan như bữa phụ để giúp cún nhà bạn cảm thấy ngon miệng hơn, nạp thêm được nhiều chất dinh dưỡng hơn. Song song sử dụng sữa kèm các bữa ăn chính sẽ góp phần cho cún cơ thể phát triển khoẻ mạnh, toàn diện.', CAST(50000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (16, N'Lược chải lông Pet Grooming dành cho chó mèo', N'Lược chải lông Pet Grooming là một trong những món phụ kiện không thể thiếu của các sen, giúp lông của thú cưng mềm mượt, không bết, không rối. Đặc biệt, với các giống chó mèo lông dài, lược chải lông lại càng thể hiện rõ tầm quan trọng của mình. Khi chải lông thường xuyên, bạn sẽ hạn chế được tình trạng lông rụng dính vào giường chiếu, ghế sofa. Không chỉ ảnh hưởng mặt thẩm mỹ, lông chó mèo còn có thể gây dị ứng cho một số người.', CAST(40000.00 AS Decimal(18, 2)), CAST(38000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (17, N'Xương gặm thịt gà Taotaopet', N'Xương gặm thịt gà Taotaopet được thiết kế với độ cứng vừa phải, giúp các bé cún gặm và giảm stress trong quá trình mọc răng. Ngoài ra, đây cũng là một sản phẩm tuyệt vời giúp loại bỏ mảng bám trên răng, giúp cơ hàm của cún mạnh khỏe hơn.', CAST(40000.00 AS Decimal(18, 2)), CAST(39000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (18, N'Nước hoa Freshy cho chó mèo lưu hương 7 ngày', N'Nước hoa Freshy cho chó mèo là dòng nước hoa nổi tiếng chất lượng, được nhiều người yêu thích. Sản phẩm đem đến mùi mùi hương dịu nhẹ cho các boss. Mùi hương cực kỳ đa dạng phù hợp với phong cách của thú cưng và chủ nhân, dễ dàng lựa chọn. Ngoài ra, sản phẩm còn có khả năng lưu hương lên tới 7 ngày.', CAST(200000.00 AS Decimal(18, 2)), CAST(170000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (19, N'Dịch vụ trông giữ chó mèo', N'Dịch vụ trông giữ chó mèo ngày nay là một trong những giải pháp cứu cánh cho các “sen” khi không thể dành thời gian để chăm sóc các boss, đặc biệt là những trường hợp bất khả kháng như có việc đột xuất, về quê, tết…', CAST(1100000.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (20, N'Chăm sóc thú cưng', N'Chăm sóc thú cưng là các công việc liên quan đến việc chăm sóc và “làm đẹp” lại cho thú cưng thông qua các công việc như: cắt tỉa, cạo lông, nhuộm, tắm và vệ sinh cho chó mèo. Ngoài ra ngày nay còn có thêm các hoạt động như: dịch vụ khách sạn cho thú cưng, tư vấn dinh dưỡng, cứu hộ thú cưng….', CAST(500000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (21, N'Cứu hộ thú cưng', N'Chó, mèo, thú cưng nói chung là một người bạn thân thiết của con người, là một người bạn một thành viên trong gia đình thú cưng được chăm sóc và bảo hộ như một con người.', CAST(100000.00 AS Decimal(18, 2)), CAST(90000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (22, N'Khách sạn chó mèo', N'Dịch vụ khách sạn chó mèo là một trong những giải pháp hữu ích cho giúp bạn giải quyết mọi khó khăn, lo lắng trong mỗi dịp lễ, tết, đi du lịch cùng gia đình, hay cả những chuyến công tác đột xuất.', CAST(2000000.00 AS Decimal(18, 2)), CAST(1999999.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (23, N'Spa cho thú cưng', N'Spa thú cưng là một trong những dịch vụ chăm sóc thú cưng và làm đẹp cho thú cưng được rất nhiều mọi người yêu thích và lựa chọn, đặc biệt tại các thành phố lớn, mô hình dịch vụ spa thú cưng ngày một trở nên phổ biến bởi nhu cầu nuôi thú cưng ngày một phát triển.', CAST(300000.00 AS Decimal(18, 2)), CAST(250000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (24, N'Dịch vụ tắm cho chó mèo', N'Chó mèo đều là những loài vật thích hoạt động nên nó có thể dễ dàng bị lấm bẩn. Việc giữ cho bộ lông được sạch sẽ có thể ngăn ngừa các bệnh về đường ruột, hô hấp và bảo vệ sức khỏe cho cả chủ nhân của nó. ', CAST(200000.00 AS Decimal(18, 2)), CAST(190000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (25, N'Dịch vụ cắt tỉa lông chó mèo', N'Để đảm bảo sức khỏe cho các boss cũng như tránh những trường hợp thú cưng nhà bạn bị nhiễm các bệnh về da như: ký sinh trùng, bọ chét, ve rận…. thì việc cắt tỉa lông cho chó đóng vai trò vô cùng quan trọng. ', CAST(100000.00 AS Decimal(18, 2)), CAST(90000.00 AS Decimal(18, 2)))
INSERT [dbo].[SanPhamVaDichVu] ([Ma_SPDV], [Ten], [Mo_Ta], [Gia_Ban_Goc], [Gia_Khuyen_Mai]) VALUES (26, N'Thời trang thú cưng', N'Ngoài việc bảo vệ sức khỏe cho thú cưng thì quần áo cho thú cưng luôn được các gia chủ lựa chọn như là một cách thể hiện tình tình yêu thương và phong cách thời trang thú cưng riêng cho boss. Khi diện những bộ quần áo xinh xắn chắc chắn thú cưng của bạn càng đáng yêu và được nhiều người yêu thích hơn.', CAST(100000.00 AS Decimal(18, 2)), CAST(100000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (1, N'Chó', N'Chó Phốc', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Cái', N'Xám', CAST(2.00 AS Decimal(18, 2)), N'Tốt', N'Đã bán', 7)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (2, N'Chó', N'Chó Poodle', CAST(N'2022-01-02T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(2.00 AS Decimal(18, 2)), N'Tốt', N'Đã bán', 7)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (3, N'Chó', N'Golden Retriever', CAST(N'2022-05-01T00:00:00.000' AS DateTime), N'Cái', N'Vàng', CAST(25.00 AS Decimal(18, 2)), N'Tốt', N'Đã bán', 5)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (4, N'Mèo', N'Anh lông ngắn', CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Đực', N'Tram', CAST(4.50 AS Decimal(18, 2)), N'Tốt', N'Đã bán', 6)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (5, N'Chó', N'Husky', CAST(N'2022-04-20T00:00:00.000' AS DateTime), N'Cái', N'Xám', CAST(20.00 AS Decimal(18, 2)), N'Tốt', N'Đã bán', 2)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (6, N'Mèo', N'Bengal', CAST(N'2022-07-10T00:00:00.000' AS DateTime), N'Đực', N'Nâu', CAST(5.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 4)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (7, N'Chó', N'Corgi', CAST(N'2022-03-30T00:00:00.000' AS DateTime), N'Cái', N'Vàng', CAST(10.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 3)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (8, N'Chó', N'Pug', CAST(N'2022-08-12T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(7.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 3)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (9, N'Mèo', N'Ba Tư', CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'Đực', N'Kem', CAST(6.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 4)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (10, N'Chó', N'Chihuahua', CAST(N'2022-09-18T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(3.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 1)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (11, N'Chó', N'Phú Quốc', CAST(N'2022-11-20T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(18.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 5)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (12, N'Chó', N'Boxer', CAST(N'2022-10-15T00:00:00.000' AS DateTime), N'Đực', N'Hồng', CAST(30.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 2)
GO
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (13, N'Fungamyl', CAST(N'2025-02-01T00:00:00.000' AS DateTime), 97)
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (14, N'Esbilac', CAST(N'2026-07-01T00:00:00.000' AS DateTime), 98)
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (15, N'Dr Kyan', CAST(N'2024-12-10T00:00:00.000' AS DateTime), 999)
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (16, N'Pet Grooming', NULL, 1000)
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (17, N'Taotaopet', CAST(N'2025-01-10T00:00:00.000' AS DateTime), 1000)
INSERT [dbo].[VatPham] ([Ma_Vat_Pham], [Thuong_Hieu], [Han_Su_Dung], [So_Luong_Ton_Kho]) VALUES (18, N'Freshy', CAST(N'2026-01-01T00:00:00.000' AS DateTime), 992)
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (N'Chưa thanh toán') FOR [Trang_Thai]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT (getdate()) FOR [Thoi_Gian_Lap]
GO
ALTER TABLE [dbo].[BangPhanCa]  WITH CHECK ADD  CONSTRAINT [FK_BPC_CLV] FOREIGN KEY([Buoi], [Ngay_Lam_Viec])
REFERENCES [dbo].[CaLamViec] ([Buoi], [Ngay_Lam_Viec])
GO
ALTER TABLE [dbo].[BangPhanCa] CHECK CONSTRAINT [FK_BPC_CLV]
GO
ALTER TABLE [dbo].[BangPhanCa]  WITH CHECK ADD  CONSTRAINT [FK_BPC_NV] FOREIGN KEY([Ma_Nhan_Vien])
REFERENCES [dbo].[NhanVien] ([Ma_Nhan_Vien])
GO
ALTER TABLE [dbo].[BangPhanCa] CHECK CONSTRAINT [FK_BPC_NV]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HD] FOREIGN KEY([Ma_Hoa_Don])
REFERENCES [dbo].[HoaDon] ([Ma_Hoa_Don])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_HD]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_SPDV] FOREIGN KEY([Ma_SPDV])
REFERENCES [dbo].[SanPhamVaDichVu] ([Ma_SPDV])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_CTHD_SPDV]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DV_SPDV] FOREIGN KEY([Ma_Dich_Vu])
REFERENCES [dbo].[SanPhamVaDichVu] ([Ma_SPDV])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DV_SPDV]
GO
ALTER TABLE [dbo].[HinhAnh]  WITH CHECK ADD  CONSTRAINT [FK_HA_SPDV] FOREIGN KEY([Ma_SPDV])
REFERENCES [dbo].[SanPhamVaDichVu] ([Ma_SPDV])
GO
ALTER TABLE [dbo].[HinhAnh] CHECK CONSTRAINT [FK_HA_SPDV]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HD_KH] FOREIGN KEY([Ma_Khach_Hang])
REFERENCES [dbo].[KhachHang] ([Ma_Khach_Hang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HD_KH]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HD_NV] FOREIGN KEY([Ma_Nhan_Vien])
REFERENCES [dbo].[NhanVien] ([Ma_Nhan_Vien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HD_NV]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NQL_NV] FOREIGN KEY([Ma_NQL])
REFERENCES [dbo].[NhanVien] ([Ma_Nhan_Vien])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NQL_NV]
GO
ALTER TABLE [dbo].[PhongDichVu]  WITH CHECK ADD  CONSTRAINT [FK_PDV_DV] FOREIGN KEY([Ma_Dich_Vu])
REFERENCES [dbo].[DichVu] ([Ma_Dich_Vu])
GO
ALTER TABLE [dbo].[PhongDichVu] CHECK CONSTRAINT [FK_PDV_DV]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TK_NV] FOREIGN KEY([Ma_Nhan_Vien])
REFERENCES [dbo].[NhanVien] ([Ma_Nhan_Vien])
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TK_NV]
GO
ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD  CONSTRAINT [FK_TC_SPDV] FOREIGN KEY([Ma_Thu_Cung])
REFERENCES [dbo].[SanPhamVaDichVu] ([Ma_SPDV])
GO
ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [FK_TC_SPDV]
GO
ALTER TABLE [dbo].[VatPham]  WITH CHECK ADD  CONSTRAINT [FK_VP_SPDV] FOREIGN KEY([Ma_Vat_Pham])
REFERENCES [dbo].[SanPhamVaDichVu] ([Ma_SPDV])
GO
ALTER TABLE [dbo].[VatPham] CHECK CONSTRAINT [FK_VP_SPDV]
GO
ALTER TABLE [dbo].[CaLamViec]  WITH CHECK ADD  CONSTRAINT [Check_ThoiGian_CLV] CHECK  (([Thoi_Gian_Bat_Dau]<=[Thoi_Gian_Ket_Thuc]))
GO
ALTER TABLE [dbo].[CaLamViec] CHECK CONSTRAINT [Check_ThoiGian_CLV]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [Check_SoLuongPhongTrong_DV] CHECK  (([So_Luong_Phong_Trong]>=(0)))
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [Check_SoLuongPhongTrong_DV]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [Check_ThoiGianThucHien_DV] CHECK  (([Thoi_Gian_Thuc_Hien]>=(0)))
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [Check_ThoiGianThucHien_DV]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [Check_GiamGia_HD] CHECK  (([Giam_Gia]>=(0)))
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [Check_GiamGia_HD]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [Check_TongTien_HD] CHECK  (([Tong_Tien]>=(0)))
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [Check_TongTien_HD]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [Check_TrangThai_HD] CHECK  (([Trang_Thai]=N'Chưa thanh toán' OR [Trang_Thai]=N'Đã thanh toán'))
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [Check_TrangThai_HD]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [Check_DiemTichLuy_KH] CHECK  (([Diem_Tich_Luy]>=(0)))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [Check_DiemTichLuy_KH]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [Check_GioiTinh_NV] CHECK  (([Gioi_Tinh]=N'Nữ' OR [Gioi_Tinh]=N'Nam'))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [Check_GioiTinh_NV]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [Check_Luong_NV] CHECK  (([Luong]>=(0)))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [Check_Luong_NV]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [Check_SDT_NV] CHECK  ((len([SDT])=(10) AND NOT [SDT] like '%[^0-9]%'))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [Check_SDT_NV]
GO
ALTER TABLE [dbo].[PhongDichVu]  WITH CHECK ADD  CONSTRAINT [Check_ThoiGian_PDV] CHECK  (([Thoi_Gian_Bat_Dau]<=[Thoi_Gian_Ket_Thuc]))
GO
ALTER TABLE [dbo].[PhongDichVu] CHECK CONSTRAINT [Check_ThoiGian_PDV]
GO
ALTER TABLE [dbo].[PhongDichVu]  WITH CHECK ADD  CONSTRAINT [Check_TrangThai_PDV] CHECK  (([Trang_Thai]=N'Chưa sẵn sàng' OR [Trang_Thai]=N'Sẵn sàng'))
GO
ALTER TABLE [dbo].[PhongDichVu] CHECK CONSTRAINT [Check_TrangThai_PDV]
GO
ALTER TABLE [dbo].[SanPhamVaDichVu]  WITH CHECK ADD  CONSTRAINT [Check_GiaBanGoc_SPDV] CHECK  (([Gia_Ban_Goc]>=(0)))
GO
ALTER TABLE [dbo].[SanPhamVaDichVu] CHECK CONSTRAINT [Check_GiaBanGoc_SPDV]
GO
ALTER TABLE [dbo].[SanPhamVaDichVu]  WITH CHECK ADD  CONSTRAINT [Check_GiaKhuyenMai_SPDV] CHECK  (([Gia_Khuyen_Mai]>=(0)))
GO
ALTER TABLE [dbo].[SanPhamVaDichVu] CHECK CONSTRAINT [Check_GiaKhuyenMai_SPDV]
GO
ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD  CONSTRAINT [Check_GioiTinh_TC] CHECK  (([Gioi_Tinh]=N'Cái' OR [Gioi_Tinh]=N'Đực'))
GO
ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [Check_GioiTinh_TC]
GO
ALTER TABLE [dbo].[ThuCung]  WITH CHECK ADD  CONSTRAINT [Check_SoLanTiem_TC] CHECK  (([So_Lan_Tiem]>=(0)))
GO
ALTER TABLE [dbo].[ThuCung] CHECK CONSTRAINT [Check_SoLanTiem_TC]
GO
ALTER TABLE [dbo].[VatPham]  WITH CHECK ADD  CONSTRAINT [Check_SoLuongTonKho_VP] CHECK  (([So_Luong_Ton_Kho]>=(0)))
GO
ALTER TABLE [dbo].[VatPham] CHECK CONSTRAINT [Check_SoLuongTonKho_VP]
GO
/****** Object:  StoredProcedure [dbo].[proc_TaoHoaDonMoi]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_TaoHoaDonMoi]
AS
BEGIN
    DECLARE @id_hoadon INT;
    INSERT INTO HoaDon (Ma_Nhan_Vien, Ma_Khach_Hang, Trang_Thai)
    VALUES (NULL, NULL, N'Chưa thanh toán');  -- Chỉ định giá trị cho Trang_Thai

    SELECT @id_hoadon = SCOPE_IDENTITY();

    SELECT @id_hoadon AS MaHoaDonMoiNhat;
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_ThemChiTietHoaDon]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_ThemChiTietHoaDon] 
       @id_hoadon INT, 
    @id_vatpham INT, 
    @ten NVARCHAR(255), 
    @dongia DECIMAL(18,2)
AS
BEGIN
    DECLARE @SoLuongMoi INT;
    DECLARE @thanhtien DECIMAL(18,2);  -- Biến để lưu giá trị thành tiền

    -- Cập nhật số lượng sản phẩm trong ChiTietHoaDon
    UPDATE ChiTietHoaDon
    SET So_Luong = So_Luong + 1
    WHERE Ma_SPDV = @id_vatpham AND Ma_Hoa_Don = @id_hoadon;

    -- Kiểm tra xem có bản ghi nào được cập nhật không
    IF @@ROWCOUNT = 0
    BEGIN
        -- Nếu không có bản ghi nào, thêm mới sản phẩm vào ChiTietHoaDon
        INSERT INTO ChiTietHoaDon (Ma_Hoa_Don, Ma_SPDV, So_Luong)
        VALUES (@id_hoadon, @id_vatpham, 1);
        SET @SoLuongMoi = 1; -- Số lượng mới là 1
    END
    ELSE
    BEGIN
        -- Nếu đã có bản ghi, lấy số lượng mới
        SELECT @SoLuongMoi = So_Luong 
        FROM ChiTietHoaDon 
        WHERE Ma_SPDV = @id_vatpham AND Ma_Hoa_Don = @id_hoadon;
    END

    -- Tính thành tiền
    SET @thanhtien = @SoLuongMoi * @dongia;

    -- Trả về giá trị thành tiền
    SELECT @thanhtien AS ThanhTien;  -- Sử dụng SELECT để trả về giá trị
END;
GO
/****** Object:  StoredProcedure [dbo].[proc_ThemThanhVien]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_ThemThanhVien] 
@ten nvarchar(max),
@sdt varchar(10),
@dtl int
as
begin
	insert into KhachHang(Ten, SDT, Diem_Tich_Luy)
	values (@ten, @sdt, @dtl)
end
GO
/****** Object:  StoredProcedure [dbo].[proc_TimKiemSanPhamVaDichVu]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_TimKiemSanPhamVaDichVu]
    @tenview VARCHAR(255),
    @tencot VARCHAR(255),
    @tukhoa NVARCHAR(255),
    @ValueA NVARCHAR(255) = NULL,                -- Giá trị bắt đầu của khoảng
    @ValueB NVARCHAR(255) = NULL,     
    @SortColumnGiaTien NVARCHAR(255) = NULL,    -- Cột sắp xếp đầu tiên, mặc định NULL
    @SortOrderGiaTien NVARCHAR(4) = NULL,        -- Thứ tự sắp xếp cột đầu tiên, mặc định NULL
    @SortColumnTen NVARCHAR(255) = NULL,         -- Cột sắp xếp thứ hai, mặc định NULL
    @SortOrderTen NVARCHAR(4) = NULL              -- Thứ tự sắp xếp cột thứ hai, mặc định NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    DECLARE @Params NVARCHAR(MAX) = N'@tukhoa NVARCHAR(255)';

    -- Bắt đầu câu lệnh SQL với phần SELECT
    SET @SQL = N'SELECT * FROM ' + QUOTENAME(@tenview) + 
                ' WHERE ' + QUOTENAME(@tencot) + 
                ' COLLATE Vietnamese_CI_AI LIKE ''%'' + @tukhoa + ''%''';
    
    -- Kiểm tra các điều kiện cho khoảng giá trị
    IF @ValueA IS NOT NULL AND @ValueB IS NOT NULL AND TRY_CONVERT(DECIMAL(18, 2), @ValueA) < TRY_CONVERT(DECIMAL(18, 2), @ValueB)
    BEGIN
        -- Thêm điều kiện BETWEEN với chuyển đổi kiểu dữ liệu
        SET @SQL += N' AND ' + QUOTENAME(@SortColumnGiaTien) + ' BETWEEN CONVERT(DECIMAL(18, 2), @ValueA) AND CONVERT(DECIMAL(18, 2), @ValueB)';
    END

    -- Thực hiện câu lệnh ORDER BY
    IF @SortColumnGiaTien IS NOT NULL AND @SortOrderGiaTien IS NOT NULL
    BEGIN
        SET @SQL += N' ORDER BY ' + QUOTENAME(@SortColumnGiaTien) + ' ' + @SortOrderGiaTien;
    END

    IF @SortColumnTen IS NOT NULL AND @SortOrderTen IS NOT NULL
    BEGIN
		IF @SortColumnGiaTien IS NOT NULL AND @SortOrderGiaTien IS NOT NULL
			SET @SQL += N', ' + QUOTENAME(@SortColumnTen) + ' ' + @SortOrderTen;
		else
			SET @SQL += N' ORDER BY ' + QUOTENAME(@SortColumnTen) + ' ' + @SortOrderTen;
    END

    -- Thực thi câu lệnh SQL
        -- Thực thi câu lệnh SQL
    EXEC sp_executesql @SQL, 
        N'@tukhoa NVARCHAR(255), @ValueA NVARCHAR(255), @ValueB NVARCHAR(255)', 
        @tukhoa, @ValueA, @ValueB;
END
GO
/****** Object:  StoredProcedure [dbo].[proc_TimKiemTheoTen]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proc_TimKiemTheoTen]
    @tenview VARCHAR(255),
    @tencot VARCHAR(255),
    @tukhoa NVARCHAR(255)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);
    SET @SQL = N'SELECT * FROM ' + QUOTENAME(@tenview) + 
                ' WHERE ' + QUOTENAME(@tencot) + 
                ' LIKE ''%'' + @tukhoa + ''%''';
    EXEC sp_executesql @SQL, N'@tukhoa NVARCHAR(255)', @tukhoa;
END
GO
/****** Object:  StoredProcedure [dbo].[proc_XoaHoaDonDangLap]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_XoaHoaDonDangLap]
   	@id_hoadon INT
as
begin
   	delete from ChiTietHoaDon
   	where Ma_Hoa_Don = @id_hoadon
 
   	delete from HoaDon
   	where Ma_Hoa_Don = @id_hoadon
end
GO
/****** Object:  Trigger [dbo].[trg_CapNhatTongTien]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CapNhatTongTien]
ON [dbo].[ChiTietHoaDon]
AFTER INSERT, update, delete
AS
BEGIN

	 DECLARE @mahoadon INT;
	-- Gán giá trị từ bảng ảo inserted
	SELECT @mahoadon = Ma_Hoa_Don FROM inserted;

	-- Nếu @mahoadon là NULL, gán giá trị từ bảng ảo deleted
	IF @mahoadon IS NULL
		SELECT @mahoadon = Ma_Hoa_Don FROM deleted;

	-- Cập nhật thời gian lập hóa đơn
	UPDATE HoaDon
	SET Thoi_Gian_Lap = GETDATE()
	WHERE Ma_Hoa_Don = @mahoadon;

END;
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ENABLE TRIGGER [trg_CapNhatTongTien]
GO
/****** Object:  Trigger [dbo].[trg_XoaHoaDon]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_XoaHoaDon]
ON [dbo].[HoaDon]
INSTEAD OF DELETE
AS
BEGIN
    -- Xóa các bản ghi trong ChiTietHoaDon liên quan đến Ma_Hoa_Don trong bảng HoaDon
    DELETE FROM ChiTietHoaDon
    WHERE Ma_Hoa_Don IN (SELECT Ma_Hoa_Don FROM deleted);

    -- Sau đó xóa bản ghi trong bảng HoaDon
    DELETE FROM HoaDon
    WHERE Ma_Hoa_Don IN (SELECT Ma_Hoa_Don FROM deleted);
END;

GO
ALTER TABLE [dbo].[HoaDon] ENABLE TRIGGER [trg_XoaHoaDon]
GO
/****** Object:  Trigger [dbo].[trig_CapNhatTongTien]    Script Date: 10/24/2024 11:22:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trig_CapNhatTongTien]
ON [dbo].[HoaDon]
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @tongtien DECIMAL(18,2);
    DECLARE @makhachhang INT;
    DECLARE @mahoadon INT;

    -- Sử dụng bảng ảo để lấy giá trị
    SELECT @makhachhang = Ma_Khach_Hang FROM inserted;
    SELECT @mahoadon = Ma_Hoa_Don FROM inserted;

    -- Gọi hàm TinhTongTien
    SET @tongtien = dbo.TinhTongTien(@makhachhang, @mahoadon);

    -- Cập nhật tổng tiền trong bảng HoaDon
    UPDATE HoaDon
    SET Tong_Tien = @tongtien
    WHERE Ma_Hoa_Don = @mahoadon;

	-- Xử lý cho việc thay đổi đối với trạng thái hóa đơn

	DECLARE @Ma_Hoa_Don INT, 
            @Ma_Khach_Hang INT, 
            @Tong_Tien DECIMAL(18, 2), 
            @Trang_Thai_Moi NVARCHAR(100), 
            @Trang_Thai_Cu NVARCHAR(100);

    -- Lấy thông tin từ hóa đơn vừa được cập nhật
    SELECT @Ma_Hoa_Don = Ma_Hoa_Don, 
           @Ma_Khach_Hang = Ma_Khach_Hang, 
           @Tong_Tien = Tong_Tien, 
           @Trang_Thai_Moi = Trang_Thai
    FROM inserted;

    -- Lấy trạng thái cũ của hóa đơn từ bảng deleted
    SELECT @Trang_Thai_Cu = Trang_Thai
    FROM deleted
    WHERE Ma_Hoa_Don = @Ma_Hoa_Don;

    -- Ngăn chặn việc thay đổi hóa đơn đã thanh toán
    IF @Trang_Thai_Cu = N'Đã thanh toán'
    BEGIN
        -- Rollback transaction để không cho phép cập nhật hóa đơn đã thanh toán
        ROLLBACK TRANSACTION;
        RAISERROR(N'Không thể thay đổi hóa đơn đã thanh toán!', 16, 1);
        RETURN; -- Exit the trigger
    END

    -- Nếu hóa đơn mới cập nhật thành "Đã thanh toán", thực hiện tích điểm và cập nhật các bảng liên quan
    IF @Trang_Thai_Moi = N'Đã thanh toán'
    BEGIN
        -- Cập nhật điểm tích lũy cho khách hàng (giả sử 1 điểm cho mỗi 100.000 VNĐ)
        UPDATE KhachHang
        SET Diem_Tich_Luy = Diem_Tich_Luy + FLOOR(@Tong_Tien / 100000)
        WHERE Ma_Khach_Hang = @Ma_Khach_Hang;

        -- Cập nhật số lượng tồn kho cho vật phẩm (VatPham)
        UPDATE VatPham
        SET So_Luong_Ton_Kho = So_Luong_Ton_Kho - ChiTietHoaDon.So_Luong
        FROM ChiTietHoaDon
        WHERE ChiTietHoaDon.Ma_Hoa_Don = @Ma_Hoa_Don
          AND VatPham.Ma_Vat_Pham = ChiTietHoaDon.Ma_SPDV;  

        -- Cập nhật trạng thái thú cưng nếu thú cưng được bán
        UPDATE ThuCung
        SET Trang_Thai = N'Đã bán'
        WHERE Ma_Thu_Cung IN (
            SELECT Ma_SPDV
            FROM ChiTietHoaDon
            WHERE Ma_Hoa_Don = @Ma_Hoa_Don
            AND Ma_SPDV = ThuCung.Ma_Thu_Cung
        );
    END
END;
GO
ALTER TABLE [dbo].[HoaDon] ENABLE TRIGGER [trig_CapNhatTongTien]
GO
USE [master]
GO
ALTER DATABASE [PetShop] SET  READ_WRITE 
GO
