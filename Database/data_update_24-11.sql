USE [FastFood]
GO
/****** Object:  Table [dbo].[CongThucMonAn]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongThucMonAn](
	[MaMonAn] [int] NOT NULL,
	[MaNguyenLieu] [int] NOT NULL,
	[SoLuongSuDung] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC,
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaChiTietHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaHoaDon] [int] NULL,
	[MaMonAn] [int] NULL,
	[SoLuong] [int] NULL,
	[Gia] [decimal](10, 0) NULL,
	[ThanhTien] [decimal](10, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTietHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[MaChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[MaNhapKho] [int] NULL,
	[MaNguyenLieu] [int] NULL,
	[SoLuongNhap] [int] NULL,
	[DonGia] [decimal](18, 2) NULL,
	[ThanhTien]  AS ([SoLuongNhap]*[DonGia]),
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[MaChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[MaXuatKho] [int] NULL,
	[MaNguyenLieu] [int] NULL,
	[SoLuongXuat] [decimal](18, 2) NULL,
	[LydoXuat] [nvarchar](255) NULL,
	[DonGia] [decimal](18, 2) NULL,
	[ThanhTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucMonAn]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucMonAn](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DoanhThu](
	[MaDoanhThu] [int] IDENTITY(1,1) NOT NULL,
	[NgayGhiNhan] [datetime] NULL,
	[TongTien] [decimal](10, 2) NULL,
	[PhuongThucThanhToan] [nvarchar](50) NULL,
	[MaHoaDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDoanhThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [int] NULL,
	[NgayHoaDon] [datetime] NULL,
	[TongTien] [decimal](10, 0) NULL,
	[MaKhachHang] [int] NULL,
	[TenNhanVien] [nvarchar](255) NULL,
	[ThoiGian] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TenDangNhap] [nvarchar](50) NULL,
	[MatKhau] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonAn](
	[MaMonAn] [int] IDENTITY(1,1) NOT NULL,
	[TenMonAn] [nvarchar](255) NULL,
	[MoTa] [nvarchar](max) NULL,
	[Gia] [decimal](10, 0) NULL,
	[HinhAnh] [nvarchar](255) NULL,
	[MaDanhMuc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMonAn] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNguyenLieu] [int] IDENTITY(1,1) NOT NULL,
	[TenNguyenLieu] [nvarchar](255) NOT NULL,
	[DonViTinh] [nvarchar](50) NOT NULL,
	[GiaNhap] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhanvien](
	[TenNhanVien] [nvarchar](255) NOT NULL,
	[TenDangNhap] [nvarchar](255) NOT NULL,
	[MatKhau] [nvarchar](255) NOT NULL,
	[ChucVu] [nvarchar](100) NULL,
	[Luong] [decimal](10, 2) NULL,
	[Quyen] [nvarchar](50) NULL,
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhapKho]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhapKho](
	[MaNhapKho] [int] IDENTITY(1,1) NOT NULL,
	[NgayNhap] [datetime] NOT NULL,
	[TongTien] [decimal](18, 2) NULL,
	[MaNhanVien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhapKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TonKho]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TonKho](
	[MaNguyenLieu] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[NgayNhap] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNguyenLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[XuatKho]    Script Date: 24/11/2024 1:43:19 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[XuatKho](
	[MaXuatKho] [int] IDENTITY(1,1) NOT NULL,
	[NgayXuat] [date] NULL,
	[MaNhanVien] [int] NULL,
	[TongTien] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaXuatKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (1, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (1, 94, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (1, 95, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (1, 96, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (1, 97, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (2, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (2, 94, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (2, 95, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (2, 96, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (2, 97, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (3, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (3, 94, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (3, 95, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (3, 96, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (3, 97, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (5, 96, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (5, 100, 0)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (6, 134, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (6, 145, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (32, 98, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (32, 104, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (60, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (60, 95, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (60, 96, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (60, 97, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (61, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (61, 95, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (61, 96, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (61, 97, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (61, 98, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (62, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (62, 95, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (62, 96, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (62, 97, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (62, 99, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (63, 101, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (63, 180, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (64, 136, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (64, 170, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (65, 158, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (65, 182, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (66, 127, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (66, 136, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (67, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (67, 95, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (67, 96, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (67, 97, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (67, 100, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (68, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (68, 95, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (68, 96, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (68, 97, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (68, 101, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (69, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (69, 95, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (69, 96, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (69, 97, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (69, 102, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (70, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (70, 95, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (70, 96, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (70, 97, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (70, 103, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (71, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (71, 95, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (71, 96, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (71, 97, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (71, 104, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (127, 93, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (127, 105, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (127, 106, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (128, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (128, 107, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (129, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (129, 108, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (130, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (130, 109, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (131, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (131, 110, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (132, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (132, 111, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (133, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (133, 112, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (134, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (134, 113, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (135, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (135, 114, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (136, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (136, 115, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (137, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (137, 116, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (157, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (157, 117, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (158, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (158, 118, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (159, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (159, 119, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (160, 93, 2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (160, 120, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (161, 121, 0.1)
GO
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (161, 122, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (162, 121, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (162, 123, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (163, 121, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (163, 124, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (164, 121, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (164, 125, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (165, 121, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (165, 126, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (167, 121, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (167, 127, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (168, 121, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (168, 128, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (187, 129, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (187, 130, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (188, 131, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (188, 132, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (189, 133, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (189, 134, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (190, 135, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (190, 136, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (191, 137, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (191, 138, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (192, 135, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (192, 139, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (193, 140, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (193, 141, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (201, 142, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (201, 143, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (202, 140, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (202, 144, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (203, 145, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (203, 146, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (204, 147, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (204, 148, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (205, 149, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (205, 150, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (206, 151, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (206, 152, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (207, 153, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (207, 154, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (208, 155, 0.3)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (208, 156, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (209, 157, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (209, 158, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (210, 159, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (210, 160, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (211, 161, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (211, 162, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (212, 163, 0.2)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (212, 164, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (213, 165, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (213, 166, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (214, 167, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (214, 168, 1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (215, 169, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (215, 170, 0.4)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (216, 171, 0.1)
INSERT [dbo].[CongThucMonAn] ([MaMonAn], [MaNguyenLieu], [SoLuongSuDung]) VALUES (216, 172, 0.2)
GO
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] ON 

INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (201, 52, 32, 1, CAST(20000 AS Decimal(10, 0)), CAST(20000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (202, 52, 6, 1, CAST(35000 AS Decimal(10, 0)), CAST(35000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (203, 52, 216, 1, CAST(25000 AS Decimal(10, 0)), CAST(25000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (204, 52, 215, 1, CAST(30000 AS Decimal(10, 0)), CAST(30000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (205, 53, 5, 1, CAST(35000 AS Decimal(10, 0)), CAST(35000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (206, 53, 157, 1, CAST(20000 AS Decimal(10, 0)), CAST(20000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (207, 53, 204, 1, CAST(25000 AS Decimal(10, 0)), CAST(25000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (208, 54, 63, 1, CAST(50000 AS Decimal(10, 0)), CAST(50000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (209, 54, 163, 1, CAST(20000 AS Decimal(10, 0)), CAST(20000 AS Decimal(10, 0)))
INSERT [dbo].[ChiTietHoaDon] ([MaChiTietHoaDon], [MaHoaDon], [MaMonAn], [SoLuong], [Gia], [ThanhTien]) VALUES (210, 55, 128, 2, CAST(20000 AS Decimal(10, 0)), CAST(40000 AS Decimal(10, 0)))
SET IDENTITY_INSERT [dbo].[ChiTietHoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 

INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (615, 30, 93, 10, CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (616, 30, 94, 10, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (617, 30, 95, 10, CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (618, 30, 96, 10, CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (619, 30, 98, 10, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (620, 30, 99, 10, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (621, 30, 100, 10, CAST(8000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (622, 30, 101, 10, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (623, 30, 102, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (624, 30, 103, 10, CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (625, 30, 104, 10, CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (626, 30, 105, 10, CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (627, 30, 106, 10, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (628, 30, 107, 10, CAST(11500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (629, 30, 108, 10, CAST(9500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (630, 30, 109, 10, CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (631, 30, 110, 10, CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (632, 30, 111, 10, CAST(13500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (633, 30, 112, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (634, 30, 113, 10, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (635, 30, 114, 10, CAST(8500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (636, 30, 115, 10, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (637, 30, 116, 10, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (638, 30, 117, 10, CAST(19500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (639, 30, 118, 10, CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (640, 30, 119, 10, CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (641, 30, 120, 10, CAST(16500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (642, 30, 121, 10, CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (643, 30, 122, 10, CAST(9000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (644, 30, 123, 10, CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (645, 30, 124, 10, CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (646, 30, 125, 10, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (647, 30, 126, 10, CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (648, 30, 127, 10, CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (649, 30, 128, 10, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (650, 30, 129, 10, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (651, 30, 130, 10, CAST(9500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (652, 30, 131, 10, CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (653, 30, 132, 1, CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (654, 30, 133, 10, CAST(14500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (655, 30, 134, 10, CAST(18500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (656, 30, 135, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (657, 30, 136, 10, CAST(16500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (658, 30, 137, 10, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (659, 30, 138, 1, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (660, 30, 139, 10, CAST(8500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (661, 30, 140, 1, CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (662, 30, 141, 1, CAST(15500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (663, 30, 142, 1, CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (664, 30, 143, 2, CAST(20500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (665, 30, 144, 4, CAST(22500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (666, 30, 145, 23, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (667, 30, 146, 4, CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (668, 30, 147, 5, CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (669, 30, 148, 23, CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (670, 30, 149, 4, CAST(19500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (671, 30, 150, 6, CAST(20500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (672, 30, 152, 65, CAST(24500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (673, 30, 153, 3, CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (674, 30, 154, 5, CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (675, 30, 155, 234, CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (676, 30, 156, 5, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (677, 30, 157, 6, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (678, 30, 158, 3, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (679, 30, 159, 45, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (680, 30, 160, 4, CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (681, 30, 162, 5, CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (682, 30, 163, 3, CAST(32000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (683, 30, 164, 5, CAST(27000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (684, 30, 165, 35, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (685, 30, 166, 3, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (686, 30, 167, 2, CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (687, 30, 168, 5, CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (688, 30, 169, 5, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (689, 30, 170, 3, CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (690, 30, 171, 23, CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (691, 30, 172, 5, CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (692, 30, 174, 23, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (693, 30, 175, 4, CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (694, 30, 176, 5, CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (695, 30, 177, 3, CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (696, 30, 179, 2, CAST(28000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (697, 30, 180, 1, CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (698, 30, 181, 4, CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (699, 30, 182, 35, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (700, 31, 180, 1, CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (701, 31, 181, 1, CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (702, 31, 182, 1, CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuNhap] ([MaChiTiet], [MaNhapKho], [MaNguyenLieu], [SoLuongNhap], [DonGia]) VALUES (703, 31, 183, 1, CAST(12000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
GO
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] ON 

INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (126, 44, 98, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(25000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (127, 44, 104, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(17500.00 AS Decimal(18, 2)), CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (128, 44, 134, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(18500.00 AS Decimal(18, 2)), CAST(18500.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (129, 44, 145, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(18000.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (130, 44, 171, CAST(0.10 AS Decimal(18, 2)), N'Bán món ăn', CAST(20000.00 AS Decimal(18, 2)), CAST(2000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (131, 44, 172, CAST(0.20 AS Decimal(18, 2)), N'Bán món ăn', CAST(22000.00 AS Decimal(18, 2)), CAST(4400.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (132, 44, 169, CAST(0.10 AS Decimal(18, 2)), N'Bán món ăn', CAST(18000.00 AS Decimal(18, 2)), CAST(1800.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (133, 44, 170, CAST(0.40 AS Decimal(18, 2)), N'Bán món ăn', CAST(15000.00 AS Decimal(18, 2)), CAST(6000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (134, 45, 96, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(30000.00 AS Decimal(18, 2)), CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (135, 45, 100, CAST(0.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(8000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (136, 45, 93, CAST(2.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(10500.00 AS Decimal(18, 2)), CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (137, 45, 117, CAST(0.30 AS Decimal(18, 2)), N'Bán món ăn', CAST(19500.00 AS Decimal(18, 2)), CAST(5850.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (138, 45, 147, CAST(0.20 AS Decimal(18, 2)), N'Bán món ăn', CAST(14000.00 AS Decimal(18, 2)), CAST(2800.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (139, 45, 148, CAST(0.30 AS Decimal(18, 2)), N'Bán món ăn', CAST(23000.00 AS Decimal(18, 2)), CAST(6900.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (140, 46, 101, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(18000.00 AS Decimal(18, 2)), CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (141, 46, 180, CAST(1.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(17000.00 AS Decimal(18, 2)), CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (142, 46, 121, CAST(0.20 AS Decimal(18, 2)), N'Bán món ăn', CAST(14000.00 AS Decimal(18, 2)), CAST(2800.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (143, 46, 124, CAST(0.10 AS Decimal(18, 2)), N'Bán món ăn', CAST(10000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (144, 47, 93, CAST(4.00 AS Decimal(18, 2)), N'Bán món ăn', CAST(10500.00 AS Decimal(18, 2)), CAST(42000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (145, 47, 107, CAST(0.20 AS Decimal(18, 2)), N'Bán món ăn', CAST(11500.00 AS Decimal(18, 2)), CAST(2300.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (146, 48, 155, CAST(234.00 AS Decimal(18, 2)), NULL, CAST(13000.00 AS Decimal(18, 2)), CAST(3042000.00 AS Decimal(18, 2)))
INSERT [dbo].[ChiTietPhieuXuat] ([MaChiTiet], [MaXuatKho], [MaNguyenLieu], [SoLuongXuat], [LydoXuat], [DonGia], [ThanhTien]) VALUES (147, 49, 142, CAST(1.00 AS Decimal(18, 2)), NULL, CAST(10500.00 AS Decimal(18, 2)), CAST(10500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[DanhMucMonAn] ON 

INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (1, N'Hamburger', N'Image/hambuer.jpg')
INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (2, N'Pizza', N'Image/pizza.jpg')
INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (3, N'Gà rán', N'Image/garan.jpg')
INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (5, N'Sandwich', N'Image/sand.jpg')
INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (6, N'Bánh ngọt', N'Image/banhngot.jpg')
INSERT [dbo].[DanhMucMonAn] ([MaDanhMuc], [TenDanhMuc], [HinhAnh]) VALUES (7, N'Đồ uống', N'Image/douon.jpg')
SET IDENTITY_INSERT [dbo].[DanhMucMonAn] OFF
GO
SET IDENTITY_INSERT [dbo].[DoanhThu] ON 

INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (34, CAST(N'2024-11-24T12:46:50.860' AS DateTime), CAST(110000.00 AS Decimal(10, 2)), NULL, 52)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (35, CAST(N'2024-11-24T12:47:03.353' AS DateTime), CAST(80000.00 AS Decimal(10, 2)), NULL, 53)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (36, CAST(N'2024-11-24T12:47:41.760' AS DateTime), CAST(70000.00 AS Decimal(10, 2)), NULL, 54)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (37, CAST(N'2024-11-24T12:48:22.897' AS DateTime), CAST(40000.00 AS Decimal(10, 2)), NULL, 55)
SET IDENTITY_INSERT [dbo].[DoanhThu] OFF
GO
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [NgayHoaDon], [TongTien], [MaKhachHang], [TenNhanVien], [ThoiGian]) VALUES (51, 1, CAST(N'2024-11-24T00:00:00.000' AS DateTime), CAST(130000 AS Decimal(10, 0)), NULL, N'Hieu nghia', CAST(N'2024-11-24T12:46:12.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [NgayHoaDon], [TongTien], [MaKhachHang], [TenNhanVien], [ThoiGian]) VALUES (52, 1, CAST(N'2024-11-24T00:00:00.000' AS DateTime), CAST(110000 AS Decimal(10, 0)), NULL, N'Hieu nghia', CAST(N'2024-11-24T12:46:43.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [NgayHoaDon], [TongTien], [MaKhachHang], [TenNhanVien], [ThoiGian]) VALUES (53, 1, CAST(N'2024-11-24T00:00:00.000' AS DateTime), CAST(80000 AS Decimal(10, 0)), NULL, N'Hieu nghia', CAST(N'2024-11-24T12:46:43.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [NgayHoaDon], [TongTien], [MaKhachHang], [TenNhanVien], [ThoiGian]) VALUES (54, 1, CAST(N'2024-11-24T00:00:00.000' AS DateTime), CAST(70000 AS Decimal(10, 0)), NULL, N'Hieu nghia', CAST(N'2024-11-24T12:47:26.000' AS DateTime))
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaNhanVien], [NgayHoaDon], [TongTien], [MaKhachHang], [TenNhanVien], [ThoiGian]) VALUES (55, 1, CAST(N'2024-11-24T00:00:00.000' AS DateTime), CAST(40000 AS Decimal(10, 0)), NULL, N'Hieu nghia', CAST(N'2024-11-24T12:48:13.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [Email], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1, N' Nguyễn Văn A', N'vana@example.com', N'0123456789', N'123 Đường ABC', N'vana', N'password1')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [Email], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (2, N'Trần Thị B', N'btran@example.com', N'0987654321', N'456 Đường DEF', N'btran', N'password2')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[MonAn] ON 

INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (1, N'Burger tôm', N'', CAST(35000 AS Decimal(10, 0)), N'Image/1_tom.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (2, N'Burger cá', N'', CAST(35000 AS Decimal(10, 0)), N'Image/1_ca.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (3, N'Burger gà', N'', CAST(35000 AS Decimal(10, 0)), N'Image/1_ga.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (5, N'Burger bò', N'', CAST(35000 AS Decimal(10, 0)), N'Image/1_bo.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (6, N'Burger heo ', N'', CAST(35000 AS Decimal(10, 0)), N'Image/1_heo.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (32, N'Burger rau', N'', CAST(20000 AS Decimal(10, 0)), N'Image/1_rau.jpg', 1)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (60, N'Pizza bò băm', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_bo.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (61, N'Pizza hải sản', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_hs.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (62, N'Pizza hawai', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_hw.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (63, N'Pizza phô mai', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_pm.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (64, N'Pizza pepperoni', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_pep.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (65, N'Pizza gà', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_ga.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (66, N'Pizza margherita', N'', CAST(50000 AS Decimal(10, 0)), N'Image/2_ma.jpg', 2)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (67, N'Gà sốt cay', N'', CAST(40000 AS Decimal(10, 0)), N'Image/gacay.jpg', 3)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (68, N'Gà chua ngọt ', N'', CAST(40000 AS Decimal(10, 0)), N'Image/tải xuống.jpg', 3)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (69, N'Gà phô mai ', N'', CAST(40000 AS Decimal(10, 0)), N'Image/tải xuống (1).jpg', 3)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (70, N'Gà ớt xanh ', N'', CAST(40000 AS Decimal(10, 0)), N'Image/tải xuống (2).jpg', 3)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (71, N'gà truyền thống', N'', CAST(40000 AS Decimal(10, 0)), N'Image/tải xuống (3).jpg', 3)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (127, N'Marinara trứng luộc', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-0.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (128, N'sandwich bơ', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-1.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (129, N'sandwich kimchi', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-2.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (130, N'sandwich chuối', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-3.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (131, N'sandwich cá hồi', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-4.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (132, N'sandwich mâm xôi', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-5.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (133, N'sandwich kẹp', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-6.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (134, N'Katsu-sando', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-7.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (135, N'sandwich dâu tây', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-8.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (136, N'sandwich với mận', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-9.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (137, N'sandwich lúa mạch', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-10.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (157, N'sandwich với đậu nghiền', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-11.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (158, N'sandwich với bơ nghiền', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-12.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (159, N'sandwich với bắp cải', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-13.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (160, N'sandwich với gà hầm', N'', CAST(20000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-14.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (161, N'Bánh donut kem trứng', N'', CAST(20000 AS Decimal(10, 0)), N'Image/banh_donut_kem_trung_nhan_kem_beo_ngay_hap_dan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (162, N'Bánh kem phô mai ', N'', CAST(20000 AS Decimal(10, 0)), N'Image/mjMNZS0w-mon_banh_voi_huong_thom_sau_rieng_hap_dan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (163, N'Bánh vừng', N'', CAST(20000 AS Decimal(10, 0)), N'Image/banh_vung_la_mon_banh_ngot_de_lam_de_an.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (164, N'Bánh cupcake', N'', CAST(15000 AS Decimal(10, 0)), N'Image/cupcake_la_mon_banh_ngot_ngon_xinh_xan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (165, N'Bánh dừa', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_dua_thich_hop_dung_trong_tiec_tra_chieu.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (167, N'Bánh dorayaki', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_ran_doremon_khong_dau_mo_it_ngot_de_an.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (168, N'Bánh sữa chua', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_sua_chua_vi_chua_ngot_an_khong_bi_ngan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (187, N'TRÀ MATCHA ĐẬU', N'', CAST(15000 AS Decimal(10, 0)), N'Image/tra-matcha-dau-do-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (188, N'HỒNG TRÀ YAKULT', N'', CAST(15000 AS Decimal(10, 0)), N'Image/7_hongtra.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (189, N'TRÀ XANH DÂU TÂY', N'', CAST(25000 AS Decimal(10, 0)), N'Image/7_dau.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (190, N'TRÀ XANH CAM ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/7_camvang.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (191, N'TRÀ XANH BƯỞI', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-buoi-hong-ruby-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (192, N'TRÀ XANH CAM  
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-cam-dau-tay.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (193, N'TRÀ XANH CHANH', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-chanh-vang-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (201, N'TRÀ CHANH DÂY', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-chanh-day-thanh-long-do-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (202, N'TRÀ XANH CHANH', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-chanh-viet-quat-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (203, N'HỒNG TRÀ QUẤT', N'', CAST(30000 AS Decimal(10, 0)), N'Image/hong-tra-quat-do-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (204, N'TRÀ XANH XOÀI', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-xoai-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (205, N'TRÀ XANH DƯA HẤU
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-dua-hau-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (206, N'TRÀ XANH NHO ĐEN', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-nho-den-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (207, N'OOLONG PHÚ QUÝ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/olong-phu-quy-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (208, N'TRÀ XANH HOA NHÀI', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-hoa-nhai-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (209, N'OOLONG MỸ NHÂN', N'', CAST(30000 AS Decimal(10, 0)), N'Image/oolong-my-nhan-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (210, N'OOLONG XUÂN XANH', N'', CAST(25000 AS Decimal(10, 0)), N'Image/olong-xuan-xanh-kem-cheese-01(1).jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (211, N'TRÀ OOLONG HOA', N'', CAST(30000 AS Decimal(10, 0)), N'Image/oolong-hoa-hong-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (212, N'TRÀ GẠO LỨT', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-gao-lut-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (213, N'TRÀ OOLONG QUẾ ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/olong-que-hoa-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (214, N'TRÀ BÍCH LOA ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-bich-loa-xuan-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (215, N'TRÀ TIỂU LONG', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-tieu-long-chau-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (216, N'TRÀ SỮA NƯỚNG ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-sua-nuong-01.jpg', 7)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
GO
SET IDENTITY_INSERT [dbo].[NguyenLieu] ON 

INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (93, N'Bánh mì', N'Cái', CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (94, N'Gạo', N'Kg', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (95, N'Thịt bò', N'Kg', CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (96, N'Cà chua', N'Kg', CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (97, N'Lá rau', N'Cái', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (98, N'Nước tương', N'Lít', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (99, N'Đường', N'Kg', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (100, N'Muối', N'Kg', CAST(8000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (101, N'Tiêu', N'Kg', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (102, N'Tỏi', N'Kg', CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (103, N'Trứng', N'Cái', CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (104, N'Sữa', N'Lít', CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (105, N'Bơ', N'Kg', CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (106, N'Pho mai', N'Kg', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (107, N'Xúc xích', N'Cái', CAST(11500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (108, N'Dưa chuột', N'Kg', CAST(9500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (109, N'Hành tây', N'Kg', CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (110, N'Cà rốt', N'Kg', CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (111, N'Chanh', N'Cái', CAST(13500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (112, N'Gừng', N'Kg', CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (113, N'Cải bắp', N'Kg', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (114, N'Hạt tiêu', N'Kg', CAST(8500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (115, N'Bột mì', N'Kg', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (116, N'Cà phê', N'Kg', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (117, N'Soda', N'Lít', CAST(19500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (118, N'Nước ép cam', N'Lít', CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (119, N'Lá chanh', N'Cái', CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (120, N'Bánh xèo', N'Cái', CAST(16500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (121, N'Bánh bao', N'Cái', CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (122, N'Khoai tây', N'Kg', CAST(9000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (123, N'Bắp ngô', N'Kg', CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (124, N'Chả cá', N'Kg', CAST(10000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (125, N'Tôm', N'Kg', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (126, N'Mực', N'Kg', CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (127, N'Cải xoăn', N'Kg', CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (128, N'Gà', N'Kg', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (129, N'Cải thìa', N'Kg', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (130, N'Rau muống', N'Kg', CAST(9500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (131, N'Hạt chia', N'Kg', CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (132, N'Nước mắm', N'Lít', CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (133, N'Dầu ăn', N'Lít', CAST(14500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (134, N'Sữa đặc', N'Lít', CAST(18500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (135, N'Rựu vang', N'Lít', CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (136, N'Soda chanh', N'Lít', CAST(16500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (137, N'cốt chanh', N'Lít', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (138, N'Bánh tráng', N'Cái', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (139, N'Nấm hương', N'Kg', CAST(8500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (140, N'Dưa hấu', N'Kg', CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (141, N'Hạt chia', N'Kg', CAST(15500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (142, N'Bí đỏ', N'Kg', CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (143, N'Cơm gạo lứt', N'Kg', CAST(20500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (144, N'Quả lựu', N'Cái', CAST(22500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (145, N'Lạc', N'Kg', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (146, N'Dưa leo', N'Kg', CAST(17500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (147, N'Nước cốt dừa', N'Lít', CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (148, N'Cà phê hòa tan', N'Kg', CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (149, N'Măng', N'Kg', CAST(19500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (150, N'Kẹo', N'Kg', CAST(20500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (151, N'Mật ong', N'Kg', CAST(11500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (152, N'Hạnh nhân', N'Kg', CAST(24500.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (153, N'Bánh quy', N'Cái', CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (154, N'Bánh phở', N'Cái', CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (155, N'lạc rang', N'Kg', CAST(13000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (156, N'Xôi', N'Kg', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (157, N'Nước dừa', N'Lít', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (158, N'Bột năng', N'Kg', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (159, N'Chân gà', N'Kg', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (160, N'Bột nở', N'Kg', CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (161, N'Bánh m? sandwich', N'Cái', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (162, N'Cá hồi', N'Kg', CAST(35000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (163, N'Cá basa', N'Kg', CAST(32000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (164, N'Bò viên', N'Kg', CAST(27000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (165, N'Dầu hào ', N'Lít', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (166, N'Bơ đậu phộng', N'Kg', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (167, N'Bánh chuối', N'Cái', CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (168, N'Bánh su sê', N'Cái', CAST(24000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (169, N'Củ cải ', N'Kg', CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (170, N'Dậu nành', N'Kg', CAST(15000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (171, N'Dậu phộng', N'Kg', CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (172, N'Thịt gà ', N'Kg', CAST(22000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (173, N'Nấm kim châm', N'Kg', CAST(16000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (174, N'Bột quế', N'Kg', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (175, N'Dưa cải', N'Kg', CAST(14000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (176, N'ép cà rốt', N'Lít', CAST(25000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (177, N'bánh tart', N'Cái', CAST(21000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (178, N'Dưa hấu xanh', N'Kg', CAST(30000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (179, N'Cá ngừ', N'Kg', CAST(28000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (180, N'Tỏi đen', N'Kg', CAST(17000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (181, N'Bánh bông lan', N'Cái', CAST(23000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (182, N'Nước mía', N'Lít', CAST(19000.00 AS Decimal(18, 2)))
INSERT [dbo].[NguyenLieu] ([MaNguyenLieu], [TenNguyenLieu], [DonViTinh], [GiaNhap]) VALUES (183, N'Cải ngọt', N'Kg', CAST(12000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[NguyenLieu] OFF
GO
SET IDENTITY_INSERT [dbo].[nhanvien] ON 

INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Hieu nghia', N'admin', N'123', N'Admin', CAST(1000.00 AS Decimal(10, 2)), N'Admin', 1)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Nguyễn Văn A', N'userA', N'123', N'Quản lý', CAST(5000.00 AS Decimal(10, 2)), N'User', 2)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Le Van b', N'userC', N'123', N'Nhân viên', CAST(6000.00 AS Decimal(10, 2)), N'User', 4)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'nguyen hieu nghia', N'123', N'123', N'Nhân viên', CAST(10000.00 AS Decimal(10, 2)), N'Manager', 5)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'nghia', N'aaa', N'123', N'Nhân viên', CAST(12.00 AS Decimal(10, 2)), N'Manager', 10)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'nghia', N'aa', N'123', N'Nhân viên', CAST(10000000.00 AS Decimal(10, 2)), N'Admin', 11)
SET IDENTITY_INSERT [dbo].[nhanvien] OFF
GO
SET IDENTITY_INSERT [dbo].[NhapKho] ON 

INSERT [dbo].[NhapKho] ([MaNhapKho], [NgayNhap], [TongTien], [MaNhanVien]) VALUES (30, CAST(N'2024-11-24T12:41:14.767' AS DateTime), CAST(18147500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[NhapKho] ([MaNhapKho], [NgayNhap], [TongTien], [MaNhanVien]) VALUES (31, CAST(N'2024-11-24T12:56:57.207' AS DateTime), CAST(71000.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[NhapKho] OFF
GO
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (93, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (94, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (95, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (96, 9, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (97, 0, CAST(N'2024-10-24T12:31:26.887' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (98, 9, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (99, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (100, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (101, 9, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (102, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (103, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (104, 9, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (105, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (106, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (107, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (108, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (109, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (110, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (111, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (112, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (113, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (114, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (115, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (116, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (117, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (118, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (119, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (120, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (121, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (122, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (123, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (124, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (125, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (126, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (127, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (128, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (129, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (130, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (131, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (132, 1, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (133, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (134, 9, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (135, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (136, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (137, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (138, 1, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (139, 10, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (140, 1, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (141, 1, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (142, 0, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (143, 2, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (144, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (145, 22, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (146, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (147, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (148, 23, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (149, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (150, 6, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (151, 0, CAST(N'2024-10-24T12:31:26.887' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (152, 65, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (153, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (154, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (155, 0, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (156, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (157, 6, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (158, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (159, 45, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (160, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (161, 0, CAST(N'2024-10-24T12:31:26.887' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (162, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (163, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (164, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (165, 35, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (166, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (167, 2, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (168, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (169, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (170, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (171, 23, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (172, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (173, 0, CAST(N'2024-10-24T12:31:26.887' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (174, 23, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (175, 4, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (176, 5, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (177, 3, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (178, 0, CAST(N'2024-10-24T12:31:26.887' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (179, 2, CAST(N'2024-11-24T12:41:14.767' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (180, 1, CAST(N'2024-11-24T12:56:57.207' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (181, 5, CAST(N'2024-11-24T12:56:57.207' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (182, 36, CAST(N'2024-11-24T12:56:57.207' AS DateTime))
INSERT [dbo].[TonKho] ([MaNguyenLieu], [SoLuong], [NgayNhap]) VALUES (183, 1, CAST(N'2024-11-24T12:56:57.207' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[XuatKho] ON 

INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (44, CAST(N'2024-11-24' AS Date), 1, CAST(93200.00 AS Decimal(18, 2)))
INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (45, CAST(N'2024-11-24' AS Date), 1, CAST(66550.00 AS Decimal(18, 2)))
INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (46, CAST(N'2024-11-24' AS Date), 1, CAST(38800.00 AS Decimal(18, 2)))
INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (47, CAST(N'2024-11-24' AS Date), 1, CAST(44300.00 AS Decimal(18, 2)))
INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (48, CAST(N'2024-11-24' AS Date), 1, CAST(3042000.00 AS Decimal(18, 2)))
INSERT [dbo].[XuatKho] ([MaXuatKho], [NgayXuat], [MaNhanVien], [TongTien]) VALUES (49, CAST(N'2024-11-24' AS Date), 1, CAST(10500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[XuatKho] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__55F68FC0023D5A04]    Script Date: 24/11/2024 1:43:20 CH ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhanvien__TenDangNhap]    Script Date: 24/11/2024 1:43:20 CH ******/
ALTER TABLE [dbo].[nhanvien] ADD  CONSTRAINT [UQ__nhanvien__TenDangNhap] UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CongThucMonAn]  WITH CHECK ADD FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[CongThucMonAn]  WITH CHECK ADD FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_MonAn] FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_MonAn]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_NguyenLieu] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_NguyenLieu]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuNhap_NhapKho] FOREIGN KEY([MaNhapKho])
REFERENCES [dbo].[NhapKho] ([MaNhapKho])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK_ChiTietPhieuNhap_NhapKho]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_NguyenLieu] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_NguyenLieu]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuXuat_XuatKho] FOREIGN KEY([MaXuatKho])
REFERENCES [dbo].[XuatKho] ([MaXuatKho])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK_ChiTietPhieuXuat_XuatKho]
GO
ALTER TABLE [dbo].[DoanhThu]  WITH CHECK ADD  CONSTRAINT [FK_DoanhThu_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[DoanhThu] CHECK CONSTRAINT [FK_DoanhThu_HoaDon]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[nhanvien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_DanhMucMonAn] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMucMonAn] ([MaDanhMuc])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_DanhMucMonAn]
GO
ALTER TABLE [dbo].[NhapKho]  WITH CHECK ADD  CONSTRAINT [FK_NhapKho_MaNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[nhanvien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NhapKho] CHECK CONSTRAINT [FK_NhapKho_MaNhanVien]
GO
ALTER TABLE [dbo].[TonKho]  WITH CHECK ADD  CONSTRAINT [FK_TonKho_MaNguyenLieu] FOREIGN KEY([MaNguyenLieu])
REFERENCES [dbo].[NguyenLieu] ([MaNguyenLieu])
GO
ALTER TABLE [dbo].[TonKho] CHECK CONSTRAINT [FK_TonKho_MaNguyenLieu]
GO
ALTER TABLE [dbo].[XuatKho]  WITH CHECK ADD FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[nhanvien] ([MaNhanVien])
GO
