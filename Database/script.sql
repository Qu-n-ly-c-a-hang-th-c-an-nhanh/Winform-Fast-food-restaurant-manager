USE [FastFood]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 13/11/2024 11:30:43 CH ******/
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
/****** Object:  Table [dbo].[DanhMucMonAn]    Script Date: 13/11/2024 11:30:43 CH ******/
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
/****** Object:  Table [dbo].[DoanhThu]    Script Date: 13/11/2024 11:30:43 CH ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 13/11/2024 11:30:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaDonDatHang] [int] NULL,
	[MaNhanVien] [int] NULL,
	[NgayHoaDon] [datetime] NULL,
	[TongTien] [decimal](10, 0) NULL,
	[MaKhachHang] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 13/11/2024 11:30:43 CH ******/
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
/****** Object:  Table [dbo].[Kho]    Script Date: 13/11/2024 11:30:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[MaKho] [int] IDENTITY(1,1) NOT NULL,
	[MaMonAn] [int] NULL,
	[MaNhaCungCap] [int] NULL,
	[SoLuongTon] [int] NULL,
	[MucCanhBao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonAn]    Script Date: 13/11/2024 11:30:43 CH ******/
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
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 13/11/2024 11:30:43 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNhaCungCap] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaCungCap] [nvarchar](100) NULL,
	[NguoiLienHe] [nvarchar](100) NULL,
	[DienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhanvien]    Script Date: 13/11/2024 11:30:43 CH ******/
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

INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (1, CAST(N'2024-09-20T13:58:58.197' AS DateTime), CAST(60000.00 AS Decimal(10, 2)), N'Ti?n m?t', NULL)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (2, CAST(N'2024-09-20T13:58:58.197' AS DateTime), CAST(35000.00 AS Decimal(10, 2)), N'Th? tín d?ng', NULL)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (3, CAST(N'2024-09-20T14:00:05.267' AS DateTime), CAST(60000.00 AS Decimal(10, 2)), N'Ti?n m?t', NULL)
INSERT [dbo].[DoanhThu] ([MaDoanhThu], [NgayGhiNhan], [TongTien], [PhuongThucThanhToan], [MaHoaDon]) VALUES (4, CAST(N'2024-09-20T14:00:05.267' AS DateTime), CAST(35000.00 AS Decimal(10, 2)), N'Th? tín d?ng', NULL)
SET IDENTITY_INSERT [dbo].[DoanhThu] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [Email], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (1, N' Nguyễn Văn A', N'vana@example.com', N'0123456789', N'123 Đường ABC', N'vana', N'password1')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [Email], [DienThoai], [DiaChi], [TenDangNhap], [MatKhau]) VALUES (2, N'Trần Thị B', N'btran@example.com', N'0987654321', N'456 Đường DEF', N'btran', N'password2')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[Kho] ON 

INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (1, 1, 1, 50, 10)
INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (2, 2, 2, 30, 5)
INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (3, 3, 1, 20, 5)
INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (4, 1, 1, 50, 10)
INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (5, 2, 2, 30, 5)
INSERT [dbo].[Kho] ([MaKho], [MaMonAn], [MaNhaCungCap], [SoLuongTon], [MucCanhBao]) VALUES (6, 3, 1, 20, 5)
SET IDENTITY_INSERT [dbo].[Kho] OFF
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
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (131, N'sandwich cá hồi xông khói', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-4.jpg', 5)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (132, N'sandwich quả mâm xôi', N'', CAST(40000 AS Decimal(10, 0)), N'Image/20-mon-sandwich-hap-dan-ban-khong-nen-bo-lo-5.jpg', 5)
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
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (162, N'Bánh kem phô mai sầu riêng', N'', CAST(20000 AS Decimal(10, 0)), N'Image/mjMNZS0w-mon_banh_voi_huong_thom_sau_rieng_hap_dan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (163, N'Bánh vừng', N'', CAST(20000 AS Decimal(10, 0)), N'Image/banh_vung_la_mon_banh_ngot_de_lam_de_an.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (164, N'Bánh cupcake', N'', CAST(15000 AS Decimal(10, 0)), N'Image/cupcake_la_mon_banh_ngot_ngon_xinh_xan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (165, N'Bánh dừa', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_dua_thich_hop_dung_trong_tiec_tra_chieu.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (167, N'Bánh dorayaki', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_ran_doremon_khong_dau_mo_it_ngot_de_an.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (168, N'Bánh sữa chua', N'', CAST(15000 AS Decimal(10, 0)), N'Image/banh_sua_chua_vi_chua_ngot_an_khong_bi_ngan.jpg', 6)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (187, N'TRÀ MATCHA ĐẬU ĐỎ KEM CHEESE ', N'', CAST(15000 AS Decimal(10, 0)), N'Image/tra-matcha-dau-do-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (188, N'HỒNG TRÀ YAKULT', N'', CAST(15000 AS Decimal(10, 0)), N'Image/7_hongtra.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (189, N'TRÀ XANH DÂU TÂY', N'', CAST(25000 AS Decimal(10, 0)), N'Image/7_dau.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (190, N'TRÀ XANH CAM VÀNG ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/7_camvang.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (191, N'TRÀ XANH BƯỞI HỒNG RUBY ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-buoi-hong-ruby-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (192, N'TRÀ XANH CAM ĐÀO DÂU TÂY 
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-cam-dau-tay.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (193, N'TRÀ XANH CHANH VÀNG ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-chanh-vang-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (201, N'TRÀ XANH CHANH DÂY THANH LONG ĐỎ 
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-chanh-day-thanh-long-do-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (202, N'TRÀ XANH CHANH VIỆT QUẤT ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-chanh-viet-quat-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (203, N'HỒNG TRÀ QUẤT ĐỎ 
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/hong-tra-quat-do-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (204, N'TRÀ XANH XOÀI KEM CHEESE ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-xoai-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (205, N'TRÀ XANH DƯA HẤU KEM CHEESE 
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-xanh-dua-hau-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (206, N'TRÀ XANH NHO ĐEN KEM CHEESE ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-nho-den-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (207, N'OOLONG PHÚ QUÝ KEM CHEESE ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/olong-phu-quy-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (208, N'TRÀ XANH HOA NHÀI KEM CHEESE ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-xanh-hoa-nhai-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (209, N'OOLONG MỸ NHÂN KEM CHEESE ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/oolong-my-nhan-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (210, N'OOLONG XUÂN XANH KEM CHEESE 
', N'', CAST(25000 AS Decimal(10, 0)), N'Image/olong-xuan-xanh-kem-cheese-01(1).jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (211, N'TRÀ OOLONG HOA HỒNG KEM CHEESE ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/oolong-hoa-hong-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (212, N'TRÀ GẠO LỨT KEM CHEESE 
', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-gao-lut-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (213, N'TRÀ OOLONG QUẾ HOA KEM CHEESE ', N'', CAST(30000 AS Decimal(10, 0)), N'Image/olong-que-hoa-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (214, N'TRÀ BÍCH LOA XUÂN KEM CHEESE ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-bich-loa-xuan-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (215, N'TRÀ TIỂU LONG CHÂU KEM CHEESE 
', N'', CAST(30000 AS Decimal(10, 0)), N'Image/tra-tieu-long-chau-kem-cheese-01.jpg', 7)
INSERT [dbo].[MonAn] ([MaMonAn], [TenMonAn], [MoTa], [Gia], [HinhAnh], [MaDanhMuc]) VALUES (216, N'TRÀ SỮA NƯỚNG ', N'', CAST(25000 AS Decimal(10, 0)), N'Image/tra-sua-nuong-01.jpg', 7)
SET IDENTITY_INSERT [dbo].[MonAn] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [DienThoai], [Email], [DiaChi]) VALUES (1, N'Công ty A', N'Nguy?n Văn E', N'0123456789', N'contactA@example.com', N'789 Đư?ng GHI')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [DienThoai], [Email], [DiaChi]) VALUES (2, N'Công ty B', N'Tr?n Th? F', N'0987654321', N'contactB@example.com', N'321 Đư?ng JKL')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [DienThoai], [Email], [DiaChi]) VALUES (3, N'Công ty A', N'Nguy?n Văn E', N'0123456789', N'contactA@example.com', N'789 Đư?ng GHI')
INSERT [dbo].[NhaCungCap] ([MaNhaCungCap], [TenNhaCungCap], [NguoiLienHe], [DienThoai], [Email], [DiaChi]) VALUES (4, N'Công ty B', N'Tr?n Th? F', N'0987654321', N'contactB@example.com', N'321 Đư?ng JKL')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
GO
SET IDENTITY_INSERT [dbo].[nhanvien] ON 

INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Hieu nghia', N'admin', N'123', N'Admin', CAST(1000.00 AS Decimal(10, 2)), N'Admin', 1)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Nguyễn Văn A', N'userA', N'123', N'Quản lý', CAST(5000.00 AS Decimal(10, 2)), N'User', 2)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'Le Van b', N'userC', N'123', N'Nhân viên', CAST(6000.00 AS Decimal(10, 2)), N'User', 4)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'nguyen hieu nghia', N'123', N'123', N'Nhân viên', CAST(10000.00 AS Decimal(10, 2)), N'Manager', 5)
INSERT [dbo].[nhanvien] ([TenNhanVien], [TenDangNhap], [MatKhau], [ChucVu], [Luong], [Quyen], [MaNhanVien]) VALUES (N'nghia', N'aaa', N'123', N'Nhân viên', CAST(12.00 AS Decimal(10, 2)), N'Manager', 10)
SET IDENTITY_INSERT [dbo].[nhanvien] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__KhachHan__55F68FC0023D5A04]    Script Date: 13/11/2024 11:30:43 CH ******/
ALTER TABLE [dbo].[KhachHang] ADD UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__nhanvien__TenDangNhap]    Script Date: 13/11/2024 11:30:43 CH ******/
ALTER TABLE [dbo].[nhanvien] ADD  CONSTRAINT [UQ__nhanvien__TenDangNhap] UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
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
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD FOREIGN KEY([MaMonAn])
REFERENCES [dbo].[MonAn] ([MaMonAn])
GO
ALTER TABLE [dbo].[Kho]  WITH CHECK ADD FOREIGN KEY([MaNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([MaNhaCungCap])
GO
ALTER TABLE [dbo].[MonAn]  WITH CHECK ADD  CONSTRAINT [FK_MonAn_DanhMucMonAn] FOREIGN KEY([MaDanhMuc])
REFERENCES [dbo].[DanhMucMonAn] ([MaDanhMuc])
GO
ALTER TABLE [dbo].[MonAn] CHECK CONSTRAINT [FK_MonAn_DanhMucMonAn]
GO
