USE [master]
GO
/****** Object:  Database [QL_MUABAN_TBDT]    Script Date: 18/07/2020 09:48:11 ******/
CREATE DATABASE [QL_MUABAN_TBDT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_MUABAN_TBDT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_MUABAN_TBDT.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_MUABAN_TBDT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QL_MUABAN_TBDT_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_MUABAN_TBDT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET  MULTI_USER 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QL_MUABAN_TBDT]
GO
/****** Object:  StoredProcedure [dbo].[CapNhatDanhMuc]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatDanhMuc]
(
	@MaDM int,
	@TenDM nvarchar(250)
)
as
begin
	update DanhMuc
	set TenDM=@TenDM where MaDM=@MaDM
end




GO
/****** Object:  StoredProcedure [dbo].[CapNhatLoaiSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatLoaiSanPham]
(
	@MaLoai int,
	@MaDM int,
	@TenLoaiSP nvarchar(250)
)
as
begin
	update LoaiSP
	set MaDM = @MaDM,TenLoaiSP=@TenLoaiSP where MaLoai=@MaLoai
end




GO
/****** Object:  StoredProcedure [dbo].[CapNhatSP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CapNhatSP]
(
	@MaSP nchar(20),
	@MaThuongHieu int,
	@MaLoai int,
	@TenSP nvarchar(300),
	@Hinh nvarchar(700),
	@GiaBan int,
	@NhaSanXuat nvarchar(250),
	@XuatXu nvarchar(250),
	@DungTich nvarchar(250),
	@ChatLieu nvarchar(250),
	@DoiTuong nvarchar(250),
	@Description nvarchar(Max)

)
as
begin
update SanPham
set MaThuongHieu = @MaThuongHieu,MaLoai=@MaLoai,Hinh=@Hinh,GiaBan=@GiaBan,NhaSanXuat=@NhaSanXuat,XuatXu=@XuatXu,DungTich=@DungTich,ChatLieu=@ChatLieu,DoiTuong=@DoiTuong,TenSP=@TenSP,Description=@Description where MaSP=@MaSP
end




GO
/****** Object:  StoredProcedure [dbo].[CapNhatThuongHieu]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatThuongHieu]
(
	@MaThuongHieu int,
	@TenThuongHieu nvarchar(250)
)
as
begin
	update ThuongHieu
	set TenThuongHieu=@TenThuongHieu where MaThuongHieu=@MaThuongHieu
end




GO
/****** Object:  StoredProcedure [dbo].[CategoryDM]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CategoryDM]
as
begin
select DanhMuc.MaDM,DanhMuc.TenDM,LoaiSP.MaLoai,LoaiSP.TenLoaiSP  from DanhMuc,LoaiSP where DanhMuc.MaDM = LoaiSP.MaDM
end




GO
/****** Object:  StoredProcedure [dbo].[CategoryLoaiSP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CategoryLoaiSP]
as
begin
select LoaiSP.MaLoai,LoaiSP.TenLoaiSP,SanPham.MaSP,SanPham.TenSP,ThuongHieu.MaThuongHieu,ThuongHieu.TenThuongHieu  from LoaiSP,SanPham,ThuongHieu where LoaiSP.MaLoai = SanPham.MaLoai and SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu
end




GO
/****** Object:  StoredProcedure [dbo].[ChangeStatus_KhachHang]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangeStatus_KhachHang]
(
	@MaKH int,
	@Status bit
)
as
begin
update KhachHang
set Status = @Status where MaKH = @MaKH
end




GO
/****** Object:  StoredProcedure [dbo].[ChangeTinhTrangGiao]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangeTinhTrangGiao]
(
	@MaDH int,
	@TinhTrangGiaoHang bit,
		@DaThanhToan bit
)
as
begin
update DonHang
set TinhTrangGiaoHang = @TinhTrangGiaoHang,DaThanhToan = @DaThanhToan where MaDH = @MaDH
end




GO
/****** Object:  StoredProcedure [dbo].[ChiTietSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChiTietSanPham]
(
	@MaSP nchar(20)
)
as
begin
	select * from SanPham where MaSP=@MaSP
end




GO
/****** Object:  StoredProcedure [dbo].[LayChiTietHoaDon]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LayChiTietHoaDon]
(
	@MaDH int
)
as
begin
	select   CTDonHang.MaDH,TenSP,SoLuong,DonGia  from CTDonHang,SanPham where SanPham.MaSP = CTDonHang.MaSP and CTDonHang.MaDH = @MaDH
end




GO
/****** Object:  StoredProcedure [dbo].[LayHoaDon]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LayHoaDon]
as
begin
	select DISTINCT DonHang.MaDH,KhachHang.HoTen,NgayGiao,NgayDat,DaThanhToan,TinhTrangGiaoHang    from KhachHang,CTDonHang,DonHang where KhachHang.MaKH = DonHang.MaKH and CTDonHang.MaDH = CTDonHang.MaDH
end




GO
/****** Object:  StoredProcedure [dbo].[LayLoaiSanPhamTheoDM]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------- Loai San Pham------------------------------------------------------------------------------------------------------------
create proc [dbo].[LayLoaiSanPhamTheoDM]
(
	@MaDM int
)
as
begin
	select * from LoaiSP where MaDM = @MaDM
end




GO
/****** Object:  StoredProcedure [dbo].[LaySanPhamTheoLoaiSP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LaySanPhamTheoLoaiSP]
(
	@MaLoai int,
	@MaThuongHieu int
) 
as
begin
select * from SanPham where MaLoai = @MaLoai or MaThuongHieu = @MaThuongHieu
end




GO
/****** Object:  StoredProcedure [dbo].[ThemDanhMuc]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------- Danh Muc --------------------------------------------------------------------
create proc [dbo].[ThemDanhMuc]
(
	@TenDM nvarchar(250)
)
as
begin
	Insert into DanhMuc(TenDM) values(@TenDM)
end




GO
/****** Object:  StoredProcedure [dbo].[ThemLoaiSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemLoaiSanPham]
(
	@MaDM int,
	@TenLoaiSP nvarchar(250)
)
as
begin
	insert into LoaiSP(MaDM,TenLoaiSP) values(@MaDM,@TenLoaiSP)
end




GO
/****** Object:  StoredProcedure [dbo].[ThemSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ThemSanPham]
(
	@MaSP nchar(20),
	@MaThuongHieu int,
	@MaLoai int,
	@Hinh nvarchar(700),
	@GiaBan int,
	@NhaSanXuat nvarchar(250),
	@XuatXu nvarchar(250),
	@DungTich nvarchar(250),
	@ChatLieu nvarchar(250),
	@DoiTuong nvarchar(250),
	@TenSP nvarchar(300),
	@CreatedDate date,
	@Description nvarchar(max)
)
as
begin
	insert into SanPham(MaSP,MaThuongHieu,MaLoai,TenSP,Hinh,GiaBan,NhaSanXuat,XuatXu,DungTich,ChatLieu,DoiTuong,CreatedDate,Description) values(@MaSP,@MaThuongHieu,@MaLoai,@TenSP,@Hinh,@GiaBan,@NhaSanXuat,@XuatXu,@DungTich,@ChatLieu,@DoiTuong,@CreatedDate,@Description)	
end




GO
/****** Object:  StoredProcedure [dbo].[ThemThuongHieu]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------- Thuong Hieu ---------------------------------------------------
create proc [dbo].[ThemThuongHieu]
(
	@TenThuongHieu nvarchar(250)
)
as
begin
	Insert into ThuongHieu(TenThuongHieu) values(@TenThuongHieu)
end




GO
/****** Object:  StoredProcedure [dbo].[TimKiemSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemSanPham]
(
	@MaSP char(20),
	@TenSP nvarchar(300)
)
as
begin
	select * from SanPham where MaSP = @MaSP or TenSP like @TenSP + '%'
end




GO
/****** Object:  StoredProcedure [dbo].[XoaDanhMuc]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaDanhMuc]
(
	@MaDM int
)
as
begin
	delete from DanhMuc where MaDM=@MaDM
end




GO
/****** Object:  StoredProcedure [dbo].[XoaHoaDon]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaHoaDon]
(
	@MaDH int
)
as
begin
delete from DonHang where MaDH=@MaDH
end




GO
/****** Object:  StoredProcedure [dbo].[XoaLoaiSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaLoaiSanPham]
(
	@MaLoai int
)
as
begin
	delete from LoaiSP where MaLoai=@MaLoai
end




GO
/****** Object:  StoredProcedure [dbo].[XoaSanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaSanPham]
(
	@MaSP nchar(20)
)
as
begin
delete from SanPham where MaSP = @MaSP
end




GO
/****** Object:  StoredProcedure [dbo].[XoaThuongHieu]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaThuongHieu]
(
	@MaThuongHieu int
)
as
begin
	delete from ThuongHieu where MaThuongHieu=@MaThuongHieu
end




GO
/****** Object:  Table [dbo].[CT_PHIEU_NHAP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_PHIEU_NHAP](
	[MAPN] [varchar](100) NOT NULL,
	[MASP] [nchar](20) NOT NULL,
	[SL_NHAP] [int] NULL,
	[GIANHAP] [money] NULL,
 CONSTRAINT [PK_CT_PHIEU_NHAP] PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC,
	[MASP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CTDonHang]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDonHang](
	[MaDH] [int] NOT NULL,
	[MaSP] [nchar](20) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](24, 0) NULL,
 CONSTRAINT [PK_CTDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDM] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayGiao] [date] NULL,
	[NgayDat] [date] NOT NULL,
	[DaThanhToan] [bit] NOT NULL,
	[TinhTrangGiaoHang] [bit] NOT NULL,
	[TONGTIEN] [money] NULL,
 CONSTRAINT [PK__DonHang__27258661FE3F4F63] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](250) NULL,
	[MatKhau] [varchar](250) NULL,
	[HoTen] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nchar](30) NULL,
	[DienThoai] [nchar](15) NULL,
	[Email] [varchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[NGAYTAO] [datetime] NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E976E20B9] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[MaDM] [int] NULL,
	[TenLoaiSP] [nvarchar](250) NULL,
 CONSTRAINT [PK__LoaiSP__730A5759B9991D12] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MANCC] [varchar](100) NOT NULL,
	[TENNCC] [nvarchar](500) NULL,
	[DIACHI] [nvarchar](500) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MANCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHANVIENS]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHANVIENS](
	[USERNAME] [varchar](100) NOT NULL,
	[PASS] [varchar](100) NULL,
	[TENNHANVIEN] [nvarchar](200) NULL,
	[EMAIL] [varchar](200) NULL,
	[HOATDONG] [bit] NULL,
 CONSTRAINT [PK_NHANVIENS] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHOMQUYENS]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NHOMQUYENS](
	[MANHOM] [varchar](100) NOT NULL,
	[TENNHOM] [nvarchar](500) NULL,
	[GHICHU] [nvarchar](500) NULL,
 CONSTRAINT [PK_NHOMQUYENS] PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANNHANVIEN_VAONHOMQUYEN]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANNHANVIEN_VAONHOMQUYEN](
	[USERNAME] [varchar](100) NOT NULL,
	[MANHOM] [varchar](100) NOT NULL,
	[GHICHU] [nvarchar](500) NULL,
 CONSTRAINT [PK_PHANNHANVIEN_VAONHOMQUYEN] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC,
	[MANHOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[MANHOM] [varchar](100) NOT NULL,
	[MAQUYEN] [varchar](100) NOT NULL,
	[COQUYEN] [bit] NULL,
 CONSTRAINT [PK_PHANQUYEN] PRIMARY KEY CLUSTERED 
(
	[MANHOM] ASC,
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PHIEU_NHAP]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PHIEU_NHAP](
	[MAPN] [varchar](100) NOT NULL,
	[NGAYNHAP] [date] NULL,
	[TONGTIEN] [money] NULL,
	[NHACC] [varchar](100) NULL,
 CONSTRAINT [PK_PHIEU_NHAP] PRIMARY KEY CLUSTERED 
(
	[MAPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QUYENS]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUYENS](
	[MAQUYEN] [varchar](100) NOT NULL,
	[TENQUYEN] [nvarchar](500) NULL,
	[GHICHU] [nvarchar](max) NULL,
 CONSTRAINT [PK_QUYENS] PRIMARY KEY CLUSTERED 
(
	[MAQUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 18/07/2020 09:48:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nchar](20) NOT NULL,
	[MaLoai] [int] NULL,
	[TenSP] [nvarchar](300) NULL,
	[Hinh] [nvarchar](700) NULL,
	[GiaBan] [int] NULL,
	[NhaSanXuat] [nvarchar](250) NULL,
	[XuatXu] [nvarchar](250) NULL,
	[DungTich] [nvarchar](250) NULL,
	[ChatLieu] [nvarchar](250) NULL,
	[DoiTuong] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
	[SL_TON] [int] NULL,
	[ISDELETE] [bit] NULL,
 CONSTRAINT [PK__SanPham__2725081CCF802F76] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP18                ', 2, 2.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP26                ', 2, 20000.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP3                 ', 1000, 4.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP33                ', 2, 10.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP34                ', 2, 2500.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP5                 ', 2, 10000.0000)
INSERT [dbo].[CT_PHIEU_NHAP] ([MAPN], [MASP], [SL_NHAP], [GIANHAP]) VALUES (N'PN01', N'SP6                 ', 1, 5000.0000)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1065, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1065, N'SP10                ', 1, CAST(250000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1066, N'SP1                 ', 1, CAST(359000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1067, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1067, N'SP10                ', 1, CAST(250000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1067, N'SP11                ', 1, CAST(58000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1067, N'SP15                ', 1, CAST(24000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1067, N'SP16                ', 1, CAST(24000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1068, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1068, N'SP1                 ', 1, CAST(359000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1068, N'SP10                ', 1, CAST(250000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1068, N'SP11                ', 1, CAST(58000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1069, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1070, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1070, N'SP10                ', 1, CAST(250000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1071, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1071, N'sp100               ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1072, N'sp09890909          ', 1, NULL)
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1072, N'SP1                 ', 1, CAST(359000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1072, N'SP14                ', 1, CAST(68000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1073, N'SP1                 ', 1, CAST(359000 AS Decimal(24, 0)))
INSERT [dbo].[CTDonHang] ([MaDH], [MaSP], [SoLuong], [DonGia]) VALUES (1074, N'SP10                ', 1, CAST(250000 AS Decimal(24, 0)))
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (2, N'Bỉm tã & vệ sinh')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (7, N'Đồ chơi TOYCITY')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (4, N'Mẹ bầu & Sau sinh')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (14, N'Nestle NAN Optipro 2')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (8, N'Phiếu & Quà tặng')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (3, N'Sơ sinh & Trẻ nhỏ')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (1, N'Sữa & Thực phẩm')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (5, N'Thời trang bé gái')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (6, N'Thời trang bé trai')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (24, N'Viet DD')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDM]) VALUES (26, N'Viet DD123')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1065, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 250000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1066, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 359000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1067, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 356000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1068, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 667000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1069, 58, NULL, CAST(0x00000000 AS Date), 0, 0, NULL)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1070, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 250000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1071, 58, NULL, CAST(0x00000000 AS Date), 0, 0, NULL)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1072, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 427000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1073, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 359000.0000)
INSERT [dbo].[DonHang] ([MaDH], [MaKH], [NgayGiao], [NgayDat], [DaThanhToan], [TinhTrangGiaoHang], [TONGTIEN]) VALUES (1074, 58, NULL, CAST(0x00000000 AS Date), 0, 0, 250000.0000)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([MaKH], [TaiKhoan], [MatKhau], [HoTen], [NgaySinh], [GioiTinh], [DienThoai], [Email], [DiaChi], [Status], [NGAYTAO]) VALUES (57, N'user01', N'123', N'Nguyen Quoc Viet', NULL, N'nam                           ', N'0398768860     ', NULL, NULL, 1, CAST(0x0000AA8C00EDEA5A AS DateTime))
INSERT [dbo].[KhachHang] ([MaKH], [TaiKhoan], [MatKhau], [HoTen], [NgaySinh], [GioiTinh], [DienThoai], [Email], [DiaChi], [Status], [NGAYTAO]) VALUES (58, N'user02', N'123', N'Nguoi Vo Danh', NULL, N'nữ                            ', N'0398768870     ', NULL, NULL, 1, CAST(0x0000AA8C00EDECA5 AS DateTime))
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
SET IDENTITY_INSERT [dbo].[LoaiSP] ON 

INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (1, 1, N'Sữa bột cho bé')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (2, 1, N'Sữa nước các loại')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (3, 1, N'Bột ăn dặm')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (4, 1, N'Bánh & Kẹo cho bé')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (5, 1, N'Cháo & mì cho bé')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (6, 1, N'Dinh dưỡng đóng lọ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (7, 1, N'Thực phẩm chế biến')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (8, 1, N'Dinh dưỡng cho mẹ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (9, 2, N'Thế giới Bỉm Tã')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (10, 2, N'Tắm & Gội toàn thân')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (11, 2, N'Nước rửa bình sữa')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (12, 2, N'Dưỡng da & Phấn thơm')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (13, 2, N'Giặt xả quần áo')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (14, 2, N'Thế giới khăn ướt')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (15, 2, N'Khăn khô & Khăn giấy')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (16, 2, N'Nước hoa & quà tặng')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (17, 3, N'Thời trang sơ sinh')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (18, 3, N'Đồ chơi sơ sinh')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (19, 3, N'Đồ dùng bé bú')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (20, 3, N'Đồ dùng bé ngủ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (21, 3, N'Các loại xe & Đai, Địu')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (22, 3, N'Dụng cụ vệ sinh')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (23, 3, N'Sức khỏe & An toàn')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (24, 3, N'Dụng cụ bé ăn')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (25, 4, N'Sữa cho mẹ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (26, 4, N'Thực phẩm cho mẹ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (27, 4, N'Mỹ phẩm cho mẹ')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (28, 4, N'Mẹ chăm bé')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (29, 4, N'Tắm & Gọi các loại')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (30, 4, N'Máy hút sữa')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (31, 4, N'Đầm bầu & Đồ lót')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (32, 4, N'Vệ sinh & Condom')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (33, 5, N'Đầm & Chân váy')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (34, 5, N'Bộ, Quần & Áo')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (35, 5, N'Đồ chơi cho bé')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (36, 5, N'Đồ ngủ & Đồ lót')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (37, 5, N'Quần Jean & Kaki')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (38, 5, N'Phụ kiện thời trang')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (39, 5, N'Ba lô & Túi xách')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (40, 5, N'Giày dép & Sandal')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (41, 6, N'Sơ mi bé trai')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (42, 6, N'Bộ, Quần & Áo 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (43, 6, N'Đồ chơi cho bé 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (44, 6, N'Đồ ngủ & Đồ lót 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (45, 6, N'Quần Jean & Kaki 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (46, 6, N'Phụ kiện thời trang 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (47, 6, N'Giày dép & Sandal 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (48, 6, N'Ba lô & Túi xách 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (49, 7, N'Đồ chơi sơ sinh 1')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (50, 7, N'Đồ chơi bé gái')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (51, 7, N'Đồ chơi bé trai')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (52, 7, N'Đồ chơi cát & Nước')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (53, 7, N'Bóng, Banh & Nhá banh')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (54, 7, N'Xe lắc & Chòi chân')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (55, 7, N'Scooter & Vận Động')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (56, 7, N'Xe đạp & Xe 3 bánh')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (57, 8, N'Tổ chức tiệc')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (58, 8, N'Gói quà')
INSERT [dbo].[LoaiSP] ([MaLoai], [MaDM], [TenLoaiSP]) VALUES (59, 8, N'Phiếu quà tặng')
SET IDENTITY_INSERT [dbo].[LoaiSP] OFF
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI]) VALUES (N'NCC01', N'nhà cung cấp thái bình', N'hcm')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI]) VALUES (N'NCC02', N'nhà cung cấp lapmaster', N'hcm')
INSERT [dbo].[NHACUNGCAP] ([MANCC], [TENNCC], [DIACHI]) VALUES (N'NCC03', N'nhà cung cấp tri tue viet', N'hcm')
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'USER01', N'123', N'NGUYEN QUOC VIET', NULL, 1)
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'USER02', N'123', N'LY XUAN THANH', NULL, 1)
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'USER03', N'123', N'HUYNH NGOC KHANH', NULL, 1)
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'USER04', N'123', N'BUI VU TRUONG', NULL, 0)
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'USER05', N'1235', N'LE DANG TRUONG', NULL, 1)
INSERT [dbo].[NHANVIENS] ([USERNAME], [PASS], [TENNHANVIEN], [EMAIL], [HOATDONG]) VALUES (N'User06', N'1234', N'Test user06', N'vietsaclo@gmail.com', 1)
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'N01', N'PHONG BAN KIEM HANG', N'QUAN LY VE THEM SAN PHAM')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'N02', N'PHONG BAN NHAN SU', N'QUAN LY VE THEM NHAN VIEN MOI')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'N03', N'PHONG BAN NGHIEP VU', N'QUAN LY VE THEM CAC QUYEN MOI VAO BAN QUYEN')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'N04', N'PHONG BAN KHO HANG', N'QUAN LY VE THEM SAN PHAM MOI VAO KHO')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'N05', N'PHONG BAN KE TOAN', N'QUAN LY VE THONG KE SAN PHAM BAN RA')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'NH01', N'Admin', N'Test Phan Admin')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'NH02', N'User', N'Test Phan User')
INSERT [dbo].[NHOMQUYENS] ([MANHOM], [TENNHOM], [GHICHU]) VALUES (N'NH03', N'Test', N'Test Quyen Thoi')
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER01', N'N01', NULL)
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER01', N'NH01', NULL)
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER02', N'N01', N'khach khach!')
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER02', N'N05', N'')
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER02', N'NH01', NULL)
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER02', N'NH02', NULL)
INSERT [dbo].[PHANNHANVIEN_VAONHOMQUYEN] ([USERNAME], [MANHOM], [GHICHU]) VALUES (N'USER05', N'NH03', NULL)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'Q03', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'Q04', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'SP02', 1)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N01', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N02', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N03', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N04', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'N05', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH01', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH02', N'SP05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'Q01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'Q02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'Q03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'Q04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'Q05', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'SP01', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'SP02', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'SP03', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'SP04', 0)
INSERT [dbo].[PHANQUYEN] ([MANHOM], [MAQUYEN], [COQUYEN]) VALUES (N'NH03', N'SP05', 0)
INSERT [dbo].[PHIEU_NHAP] ([MAPN], [NGAYNHAP], [TONGTIEN], [NHACC]) VALUES (N'PN01', CAST(0xE43F0B00 AS Date), 74024.0000, N'NCC01')
INSERT [dbo].[PHIEU_NHAP] ([MAPN], [NGAYNHAP], [TONGTIEN], [NHACC]) VALUES (N'PN02', CAST(0xE43F0B00 AS Date), NULL, N'NCC02')
INSERT [dbo].[PHIEU_NHAP] ([MAPN], [NGAYNHAP], [TONGTIEN], [NHACC]) VALUES (N'PN03', CAST(0xE43F0B00 AS Date), 0.0000, N'NCC01')
INSERT [dbo].[PHIEU_NHAP] ([MAPN], [NGAYNHAP], [TONGTIEN], [NHACC]) VALUES (N'PN05', CAST(0xE43F0B00 AS Date), 0.0000, N'NCC01')
INSERT [dbo].[PHIEU_NHAP] ([MAPN], [NGAYNHAP], [TONGTIEN], [NHACC]) VALUES (N'PN06', CAST(0xE43F0B00 AS Date), 0.0000, N'NCC01')
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'Q01', N'QUAN LY SAN PHAM', N'Ghi Chú 1')
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'Q02', N'QUAN LY NHAN VIEN', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'Q03', N'QUAN LY THEM QUYEN', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'Q04', N'QUAN LY NHAP HANG', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'Q05', N'QUAN LY THONG KE', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'SP01', N'Quan Ly Nhan Vien', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'SP02', N'Qann Ly Quyen', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'SP03', N'Quan Ly Nhom Quyen', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'SP04', N'Phan Nhan Vien Vao Nhom', NULL)
INSERT [dbo].[QUYENS] ([MAQUYEN], [TENQUYEN], [GHICHU]) VALUES (N'SP05', N'Phan Quyen Cho Nhom', NULL)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'sp09890909          ', 1, N'OKC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP1                 ', 1, N'Nestle NAN Optipro 2', N'h1.png', 359000, N'Nestlé Thụy Sỹ', N'Thụy Sỹ', N'0.8kg', N'Sữa bột', N'Cho trẻ từ 6-12 tháng tuổi', CAST(0x66400B00 AS Date), NULL, 0, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP10                ', 2, N'Thức uống lúa mạch uống liền Nestle Milo', N'h10.png', 250000, N'Việt Nam', N'Việt Nam', N'180ml', N'Sữa lỏng', N'Dành cho bé từ 6 tuổi trở lên', CAST(0x66400B00 AS Date), NULL, 0, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'sp100               ', NULL, N'Viet Dep Trai', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP11                ', 3, N'Bột ăn dặm Ridielac Gold 4 Vị Mặn', N'h11.png', 58000, N'Việt Nam', N'Việt Nam', N'200g', N'Bột Ngũ Cốc', N'Dành cho bé từ 7- 24 tháng tuổi', CAST(0x66400B00 AS Date), NULL, 0, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP12                ', 3, N'Bột sữa DD HiPP bổ sung Praebiotik', N'h12.png', 127000, N'Hipp Austria GmbH', N'Áo', N'250g', N'Bột Ngũ Cốc', N'Dành cho bé từ 4 tháng trở lên', CAST(0x66400B00 AS Date), NULL, 7, 1)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP13                ', 4, N'Bánh Ăn Dặm Gerber vị Chuối', N'h13.png', 68000, N'Mỹ', N'Mỹ', N'42g', N'Bánh', N' cho bé từ 8 tháng trở lên', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP14                ', 4, N' Bánh Ăn Dặm Gerber vị Táo Dâu', N'h14.png', 68000, N'Mỹ', N'Mỹ', N'42g', N'Bánh', N' cho bé từ 8 tháng trở lên', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP15                ', 5, N'Cháo tươi Baby bò đậu hà lan cà rốt', N'h15.png', 24000, N'Việt Nam', N'Việt Nam', N'240g', N'Cháo', N'Dành cho bé từ 10 tháng trở lên', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP16                ', 5, N'Cháo tươi Baby Tôm Rau Ngót Nhật', N'h16.png', 24000, N'Việt Nam', N'Việt Nam', N'240g', N'Cháo', N'Dành cho bé từ 10 tháng trở lên', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP17                ', 6, N'Yến Thiên Việt', N'h17.png', 295000, N'Việt Nam', N'Việt Nam', N'420ml', N'Yến sào', N'cho trẻ trên 06 tháng tuổi', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP18                ', 6, N'Yến Babi Bird ', N'h18.png', 65000, N'Việt Nam', N'Việt Nam', N'42g', N'Yến', N'cho trẻ trên 06 tháng tuổi', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP19                ', 7, N'Bột cá hồi US Food', N'h19.png', 130000, N'Việt Nam ', N'Việt Nam ', N'80g', N'Cá Hồi', N'cho bé từ 10 tháng tuổi trở lên', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP20                ', 8, N'Ensure Gold HMB Hương Vani', N'h20.png', 729000, N'Singapore', N'Singapore', N'850g', N'Sữa bột', N'Người lớn', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP21                ', 8, N'Friso Mum Gold hương Cam', N'h21.png', 449000, N'Việt Nam', N'Việt Nam', N'900g', N'Sữa bột', N'Dành cho mẹ mang thại và cho con bú', CAST(0x66400B00 AS Date), NULL, 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP22                ', 9, N'Tã dán Nhật cao cấp Genki', N'h22.png', 375000, N'Nhật Bản', N'Nhật Bản', N'44 miếng', N' Vải không dệt', N'Dành cho bé từ 12-17kg', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP23                ', 9, N'Tã quần Nhật cao cấp Genki', N'h23.png', 255000, N'Nhật Bản', N'Nhật Bản', N'26 miếng', N'Vải không dệt', N'Dành cho bé từ 12-17kg', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP24                ', 10, N'Tắm gội hạnh nhân cho sơ sinh và trẻ nhỏ Cadum', N'h24.png', 245000, N'Pháp', N'Pháp', N'750ml', N'Xà phòng', N'Tắm gội êm dịu cho sơ sinh và trẻ nhỏ', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP25                ', 11, N'Nước rửa bình sữa & rau quả D-nee', N'h25.png', 75000, N'Thái Lan', N'Thái Lan', N'500ml', N'chất tẩy', N'Dung dịch tẩy rửa bình sữa, núm ty cho bé', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP26                ', 12, N'Phấn rôm sơ sinh ngừa hăm Cadum', N'h26.png', 148000, N'Pháp', N'Pháp', N'300g', N'Phấn', N'Dùng để thoa toàn thân cho bé mỗi ngày', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP27                ', 12, N'Dầu Massage và dưỡng ẩm Johnson Baby', N'h27.png', 85000, N'Thái Lan', N'Thái Lan', N'200ml', N'Dầu', N'Cho bé từ 10 tháng tuổi', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP28                ', 13, N'Nước giặt Enfant xanh dương', N'h28.png', 179000, N'Thái Lan', N'Thái Lan', N'3000ml ', N'Xà phòng', N'Phù hợp giặt đồ cho bé từ sơ sinh trở lên', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP29                ', 14, N'Khăn ướt chiết xuất tự nhiên Aga-ae', N'h29.png', 43000, N'Hàn Quốc', N'Hàn Quốc', N'100 tờ', N'Giấy ướt', N'cho mọi người', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP3                 ', 1, N'Meiji Infant Formula', N'h3.png|h33.png|h4.png', 529000, N'Nhật Bản', N'Nhật Bản', N'0.8kg', N'Sữa bột', N'Cho trẻ từ 0-12 tháng', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP30                ', 17, N'Mũ Bảo Vệ Đầu Cho Bé Mumguard Hình Bọ Cánh Cam', N'h30.png', 249000, N'Việt Nam', N'Việt Nam', N'1 Cái', N'Nhựa', N'Dành cho bé từ 7 - 60 tháng tuổi', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP31                ', 17, N'Bộ thun bé trai ngắn CF', N'h31.png', 159000, N'Việt Nam', N'Việt Nam', N'1 bộ', N'cotton mềm mại', N'Dành cho bé từ 9-24 tháng', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP32                ', 18, N' Xe bus âm nhạc', N'h32.png', 185000, N'Trung Quốc', N'Trung Quốc', N'0.6kg', N'nhựa ABS', N'Dành cho bé từ 18 tháng trở lên', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP33                ', 18, N' Lật đật con gà vàng', N'h33.png', 85000, N'Trung Quốc', N'Trung Quốc', N'0.38kg', N'Nhựa ABS', N'Từ sơ sinh trở lên', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP34                ', 19, N'Bình sữa cổ rộng nhựa PPSU Pigeon', N'h34.png', 335000, N'Thái Lan', N'Thái Lan', N'160ml', N'nhựa PPSU', N'dành cho bé từ 0 tháng tuổi', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP35                ', 20, N'Nôi Mềm 2 Tầng 3 Sao', N'h35.png', 2090000, N'Việt Nam', N'Việt Nam', N'18kg', N'Kim loại', N'Dành cho bé sơ sinh đến 3 tuổi', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP36                ', 21, N'Xe tập đi Tobby bập bênh, có nhạc', N'h36.png', 845000, N'Trung Quốc', N'Trung Quốc', N'5.2kg', N'Nhựa', N'cho bé từ 6-15 tháng tuổi', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP37                ', 22, N'Khăn vải khô đa năng Mama', N'h37.png', 52000, N'Việt Nam', N'Việt Nam', N'240 tờ', N'Khăn vải', N'Trẻ sơ sinh', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP38                ', 23, N'Nhiệt kế hồng ngoại đo trán', N'h38.png', 850000, N'Thụy Sỹ', N'Trung Quốc', N'1 cái', N'kim loại', N'trẻ em', CAST(0x38400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP39                ', 24, N'Ghế gỗ cao cấp cho bé ', N'h39.png', 1150000, N'Việt Nam', N'Việt Nam', N'1 cái', N'Gỗ', N'trẻ em', CAST(0x3A400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP4                 ', 1, N'Meiji Growing up Formula', N'h4.png|h3.png|h33.png', 459000, N'Nhật Bản', N'Nhật Bản', N'0.8kg', N'Sữa bột', N'Cho trẻ từ 12-36 tháng', CAST(0x42400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP40                ', 33, N'Đầm vải bé gái CF', N'h40.png', 149000, N'Việt Nam', N'Việt Nam', N'1 cái', N'Vải', N'Dành cho bé từ 9-24 tháng tuổi', CAST(0x4C400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP41                ', 41, N'Áo vải bé trai tay dài CF', N'h41.png', 189000, N'Việt Nam', N'Việt Nam', N'1 cái', N'Vải cotton', N'Dành cho bé từ 7-12 tuổi', CAST(0x50400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP42                ', 34, N'Bộ thun bé gái ngắn CF', N'h42.png', 139000, N'Việt Nam', N'Việt Nam', N'1 bộ', N'Vải cotton', N'Dành cho bé từ 2-6 tuổi', CAST(0x53400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP43                ', 42, N'Bộ thun bé trai ngắn CF', N'h43.png', 149000, N'Việt Nam', N'Việt Nam', N'1 bộ', N'Vải cotton', N'Dành cho bé từ 2-6 tuổi', CAST(0x51400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP5                 ', 1, N'Frisolac Gold số 2 Sunrise', N'h5.png|h7.png|h4.png', 469000, N'Công ty TNHH FrieslandCampina Hà Nam', N'Việt Nam', N'0.9kg', N'Sữa bột', N'Cho trẻ từ 6-12 tháng tuổi', CAST(0x52400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP6                 ', 2, N'Pediasure dạng lỏng hương vani ', N'h6.png|h33.png|h37.png', 215000, N'Hoa Kỳ', N'Hoa Kỳ', N'237ml', N'Sữa lỏng', N'Cho trẻ từ 1-10 tuổi', CAST(0x54400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP7                 ', 2, N'Ensure Gold Vigor', N'h7.png|h4.png|h3.png', 259000, N'Hoa Kỳ', N'Hoa Kỳ', N'237ml', N'Sữa lỏng', N'Người lớn hoặc người bệnh', CAST(0x55400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP8                 ', 2, N'Abbott Grow Gold hương vani', N'h8.png', 58000, N'Malaysia', N'Malaysia', N'180ml', N'Sữa lỏng', N'Cho trẻ từ 2 tuổi trở lên', CAST(0x56400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
INSERT [dbo].[SanPham] ([MaSP], [MaLoai], [TenSP], [Hinh], [GiaBan], [NhaSanXuat], [XuatXu], [DungTich], [ChatLieu], [DoiTuong], [CreatedDate], [Description], [SL_TON], [ISDELETE]) VALUES (N'SP9                 ', 2, N'Sữa uống dinh dưỡng Optimum Gold', N'h9.png', 49000, N'Việt Nam', N'Việt Nam', N'180ml', N'Sữa lỏng', N'1 tuổi trở lên', CAST(0x57400B00 AS Date), N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea commodo consequat. Duis autem vel eum iriure dolor in hendrerit in vulputate velit esse molestie consequat, vel illum dolore eu feugiat nulla facilisis at vero eros et accumsan et iusto odio dignissim qui blandit praesent luptatum zzril delenit augue duis dolore te feugait nulla facilisi. Nam liber tempor cum soluta nobis eleifend option congue nihil imperdiet doming id quod mazim placerat facer possim assum.', 0, 0)
SET ANSI_PADDING ON

GO
/****** Object:  Index [Uni_TenDM]    Script Date: 18/07/2020 09:48:12 ******/
ALTER TABLE [dbo].[DanhMuc] ADD  CONSTRAINT [Uni_TenDM] UNIQUE NONCLUSTERED 
(
	[TenDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Uni_DienThoai]    Script Date: 18/07/2020 09:48:12 ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [Uni_DienThoai] UNIQUE NONCLUSTERED 
(
	[DienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Uni_TaiKhoan]    Script Date: 18/07/2020 09:48:12 ******/
ALTER TABLE [dbo].[KhachHang] ADD  CONSTRAINT [Uni_TaiKhoan] UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Uni_TenLoaiSP]    Script Date: 18/07/2020 09:48:12 ******/
ALTER TABLE [dbo].[LoaiSP] ADD  CONSTRAINT [Uni_TenLoaiSP] UNIQUE NONCLUSTERED 
(
	[TenLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_NgayDat]  DEFAULT (getdate()) FOR [NgayDat]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_DaThanhToan]  DEFAULT ((0)) FOR [DaThanhToan]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_TinhTrangGiaoHang]  DEFAULT ((0)) FOR [TinhTrangGiaoHang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SLTON]  DEFAULT ((0)) FOR [SL_TON]
GO
ALTER TABLE [dbo].[SanPham] ADD  DEFAULT ((0)) FOR [ISDELETE]
GO
ALTER TABLE [dbo].[CT_PHIEU_NHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_PHIEUNHAP] FOREIGN KEY([MAPN])
REFERENCES [dbo].[PHIEU_NHAP] ([MAPN])
GO
ALTER TABLE [dbo].[CT_PHIEU_NHAP] CHECK CONSTRAINT [FK_CTPN_PHIEUNHAP]
GO
ALTER TABLE [dbo].[CT_PHIEU_NHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPN_SANPHAM] FOREIGN KEY([MASP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[CT_PHIEU_NHAP] CHECK CONSTRAINT [FK_CTPN_SANPHAM]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_DH] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_DH]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_SP] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_SP]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DH_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DH_KH]
GO
ALTER TABLE [dbo].[LoaiSP]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSP_DM] FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMuc] ([MaDM])
GO
ALTER TABLE [dbo].[LoaiSP] CHECK CONSTRAINT [FK_LoaiSP_DM]
GO
ALTER TABLE [dbo].[PHANNHANVIEN_VAONHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANNV_NHANVIEN] FOREIGN KEY([USERNAME])
REFERENCES [dbo].[NHANVIENS] ([USERNAME])
GO
ALTER TABLE [dbo].[PHANNHANVIEN_VAONHOMQUYEN] CHECK CONSTRAINT [FK_PHANNV_NHANVIEN]
GO
ALTER TABLE [dbo].[PHANNHANVIEN_VAONHOMQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANNV_NHOMQUYENS] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYENS] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANNHANVIEN_VAONHOMQUYEN] CHECK CONSTRAINT [FK_PHANNV_NHOMQUYENS]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_NHOMQUYEN] FOREIGN KEY([MANHOM])
REFERENCES [dbo].[NHOMQUYENS] ([MANHOM])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_NHOMQUYEN]
GO
ALTER TABLE [dbo].[PHANQUYEN]  WITH CHECK ADD  CONSTRAINT [FK_PHANQUYEN_QUYENS] FOREIGN KEY([MAQUYEN])
REFERENCES [dbo].[QUYENS] ([MAQUYEN])
GO
ALTER TABLE [dbo].[PHANQUYEN] CHECK CONSTRAINT [FK_PHANQUYEN_QUYENS]
GO
ALTER TABLE [dbo].[PHIEU_NHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU_NHAP_NHACC] FOREIGN KEY([NHACC])
REFERENCES [dbo].[NHACUNGCAP] ([MANCC])
GO
ALTER TABLE [dbo].[PHIEU_NHAP] CHECK CONSTRAINT [FK_PHIEU_NHAP_NHACC]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SP_LoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SP_LoaiSP]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [CHK_DonGia] CHECK  ((len([DonGia])>(3)))
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [CHK_DonGia]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [CHK_SoLuong] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [CHK_SoLuong]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [CHK_NgayDat_NgayGiao] CHECK  ((datediff(day,[NgayDat],[NgayGiao])>=(0)))
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [CHK_NgayDat_NgayGiao]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_DienThoai] CHECK  ((len([DienThoai])>=(8) AND len([DienThoai])<=(12)))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_DienThoai]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_GioiTinh] CHECK  (([GioiTinh]='Nam' OR [GioiTinh]=N'Nữ'))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_GioiTinh]
GO
USE [master]
GO
ALTER DATABASE [QL_MUABAN_TBDT] SET  READ_WRITE 
GO
