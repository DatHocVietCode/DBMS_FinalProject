USE [master]
GO
/****** Object:  Database [PetShop]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[SanPhamVaDichVu]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[HinhAnh]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[ThuCung]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  View [dbo].[DanhSachThuCung]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[BangPhanCa]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[CaLamViec]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[DichVu]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 10/23/2024 9:14:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[Ma_Khach_Hang] [int] NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[SDT] [varchar](10) NULL,
	[Diem_Tich_Luy] [int] NULL,
 CONSTRAINT [KH_IsKey] PRIMARY KEY CLUSTERED 
(
	[Ma_Khach_Hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[PhongDichVu]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  Table [dbo].[VatPham]    Script Date: 10/23/2024 9:14:59 PM ******/
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
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (1, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T15:59:05.883' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (2, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:00:41.943' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (3, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:02:28.010' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (4, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:05:03.003' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (5, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:06:00.917' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (6, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:14:31.903' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (7, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T16:14:40.130' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (8, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:02:53.890' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (9, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:14:43.063' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (10, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:15:02.920' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (11, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:16:00.050' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (12, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:17:45.920' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (13, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:23:07.713' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (14, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T17:23:42.700' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (15, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:19:25.503' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (16, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:20:21.837' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (17, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:25:27.563' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (20, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T19:40:14.703' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (21, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T20:55:12.433' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (23, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:26:45.760' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (24, NULL, NULL, NULL, N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:28:46.407' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (25, NULL, NULL, CAST(12000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:29:36.473' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (26, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:30:19.080' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (27, NULL, NULL, CAST(18000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:32:01.107' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (28, NULL, NULL, CAST(13000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:34:03.637' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (29, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:38:18.733' AS DateTime))
INSERT [dbo].[HoaDon] ([Ma_Hoa_Don], [Ma_Nhan_Vien], [Ma_Khach_Hang], [Tong_Tien], [Trang_Thai], [Giam_Gia], [Thoi_Gian_Lap]) VALUES (31, NULL, NULL, CAST(8000000.00 AS Decimal(18, 2)), N'Chưa thanh toán', NULL, CAST(N'2024-10-22T21:41:43.917' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
INSERT [dbo].[KhachHang] ([Ma_Khach_Hang], [Ten], [SDT], [Diem_Tich_Luy]) VALUES (0, N'Khách vãng lai', NULL, NULL)
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
GO
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (1, N'Chó', N'Chó Phốc', CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Cái', N'Xám', CAST(2.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 7)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (2, N'Chó', N'Chó Poodle', CAST(N'2022-01-02T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(2.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 7)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (3, N'Chó', N'Golden Retriever', CAST(N'2022-05-01T00:00:00.000' AS DateTime), N'Cái', N'Vàng', CAST(25.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 5)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (4, N'Mèo', N'Anh lông ngắn', CAST(N'2022-06-15T00:00:00.000' AS DateTime), N'Đực', N'Tram', CAST(4.50 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 6)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (5, N'Chó', N'Husky', CAST(N'2022-04-20T00:00:00.000' AS DateTime), N'Cái', N'Xám', CAST(20.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 2)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (6, N'Mèo', N'Bengal', CAST(N'2022-07-10T00:00:00.000' AS DateTime), N'Đực', N'Nâu', CAST(5.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 4)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (7, N'Chó', N'Corgi', CAST(N'2022-03-30T00:00:00.000' AS DateTime), N'Cái', N'Vàng', CAST(10.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 3)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (8, N'Chó', N'Pug', CAST(N'2022-08-12T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(7.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 3)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (9, N'Mèo', N'Ba Tư', CAST(N'2022-02-25T00:00:00.000' AS DateTime), N'Đực', N'Kem', CAST(6.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 4)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (10, N'Chó', N'Chihuahua', CAST(N'2022-09-18T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(3.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 1)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (11, N'Chó', N'Phú Quốc', CAST(N'2022-11-20T00:00:00.000' AS DateTime), N'Cái', N'Nâu', CAST(18.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 5)
INSERT [dbo].[ThuCung] ([Ma_Thu_Cung], [Loai], [Giong], [Ngay_Sinh], [Gioi_Tinh], [Mau_Sac], [Can_Nang], [Tinh_Trang_Suc_Khoe], [Trang_Thai], [So_Lan_Tiem]) VALUES (12, N'Chó', N'Boxer', CAST(N'2022-10-15T00:00:00.000' AS DateTime), N'Đực', N'Hồng', CAST(30.00 AS Decimal(18, 2)), N'Tốt', N'Chưa bán', 2)
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
/****** Object:  StoredProcedure [dbo].[proc_TaoHoaDonMoi]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_ThemChiTietHoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_TimKiemSanPhamVaDichVu]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_TimKiemTheoTen]    Script Date: 10/23/2024 9:14:59 PM ******/
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
/****** Object:  StoredProcedure [dbo].[proc_XoaHoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_XoaHoaDon]
	@id_hoadon INT
as
begin
	delete from ChiTietHoaDon
	where Ma_Hoa_Don = @id_hoadon

	delete from HoaDon
	where Ma_Hoa_Don = @id_hoadon
end
GO
/****** Object:  Trigger [dbo].[trg_CapNhatTongTien]    Script Date: 10/23/2024 9:14:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CapNhatTongTien]
ON [dbo].[ChiTietHoaDon]
AFTER INSERT, update
AS
BEGIN
    declare @MaKH int;
    declare @DTL int = 0;  -- Gán giá trị mặc định cho DTL nếu không tìm thấy
    declare @ChietKhau float = 0; -- Giá trị mặc định

    -- Lấy Mã Khách Hàng, có thể NULL
    set @MaKH = (select distinct HD.Ma_Khach_Hang
                 from inserted i join HoaDon HD 
                 on i.Ma_Hoa_Don = HD.Ma_Hoa_Don)

    -- Nếu @MaKH không NULL, lấy Diem_Tich_Luy
    if @MaKH is not null
    begin
        set @DTL = (select Diem_Tich_Luy
                    from KhachHang
                    where Ma_Khach_Hang = @MaKH)
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
    
    -- Cập nhật tổng tiền hóa đơn
    UPDATE HoaDon
    SET Tong_Tien = (
        SELECT SUM(CTHD.So_Luong * Gia_Khuyen_Mai)
        FROM ChiTietHoaDon CTHD
        JOIN SanPhamVaDichVu SPDV ON CTHD.Ma_SPDV = SPDV.Ma_SPDV
        WHERE CTHD.Ma_Hoa_Don = HoaDon.Ma_Hoa_Don
    ) * (1 - @ChietKhau)
    WHERE Ma_Hoa_Don IN (SELECT Ma_Hoa_Don FROM inserted);
END;
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ENABLE TRIGGER [trg_CapNhatTongTien]
GO
/****** Object:  Trigger [dbo].[trg_CapNhatHoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[trg_CapNhatHoaDon]
ON [dbo].[HoaDon]
AFTER UPDATE
AS
BEGIN
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
ALTER TABLE [dbo].[HoaDon] ENABLE TRIGGER [trg_CapNhatHoaDon]
GO
/****** Object:  Trigger [dbo].[trg_XoaHoaDon]    Script Date: 10/23/2024 9:14:59 PM ******/
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
USE [master]
GO
ALTER DATABASE [PetShop] SET  READ_WRITE 
GO
