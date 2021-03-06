USE [master]
GO
/****** Object:  Database [invwarehouse]    Script Date: 1/1/2022 11:14:16 PM ******/
CREATE DATABASE [invwarehouse] ON  PRIMARY 
( NAME = N'invwarehouse', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\invwarehouse.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'invwarehouse_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\invwarehouse_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [invwarehouse] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [invwarehouse].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [invwarehouse] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [invwarehouse] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [invwarehouse] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [invwarehouse] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [invwarehouse] SET ARITHABORT OFF 
GO
ALTER DATABASE [invwarehouse] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [invwarehouse] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [invwarehouse] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [invwarehouse] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [invwarehouse] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [invwarehouse] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [invwarehouse] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [invwarehouse] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [invwarehouse] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [invwarehouse] SET  ENABLE_BROKER 
GO
ALTER DATABASE [invwarehouse] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [invwarehouse] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [invwarehouse] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [invwarehouse] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [invwarehouse] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [invwarehouse] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [invwarehouse] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [invwarehouse] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [invwarehouse] SET  MULTI_USER 
GO
ALTER DATABASE [invwarehouse] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [invwarehouse] SET DB_CHAINING OFF 
GO
USE [invwarehouse]
GO
/****** Object:  Table [dbo].[ChiTietSanPham]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSanPham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CongSuat] [int] NOT NULL,
	[opt] [varchar](25) NULL,
	[MaQR] [varchar](10) NOT NULL,
	[TenSeries] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[TenSeries] [varchar](25) NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoanDangNhap]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoanDangNhap](
	[TenDangNhap] [nvarchar](25) NULL,
	[MatKhau] [nvarchar](50) NULL,
	[IDTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[AccessLevel] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinHoaDon]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinHoaDon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenKH] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [nvarchar](50) NULL,
	[ngay] [datetime] NULL,
	[TenSeries] [nvarchar](50) NULL,
	[cs] [int] NULL,
	[opt] [nvarchar](50) NULL,
	[qr] [nvarchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinTaiKhoan]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinTaiKhoan](
	[IDTaiKhoan] [int] NOT NULL,
	[Ten] [nvarchar](25) NULL,
	[Tuoi] [int] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ThongTinTaiKhoan]  WITH CHECK ADD FOREIGN KEY([IDTaiKhoan])
REFERENCES [dbo].[TaiKhoanDangNhap] ([IDTaiKhoan])
GO
/****** Object:  StoredProcedure [dbo].[Usp_AddAccount]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Usp_AddAccount] @usr varchar(25), @pwd varchar(50), @acc varchar(20)
as
begin
declare @i int
insert into TaiKhoanDangNhap (TenDangNhap,MatKhau,AccessLevel) values (@usr, @pwd, @acc)
set @i = (select IDTaiKhoan from TaiKhoanDangNhap where TenDangNhap = @usr)
insert into ThongTinTaiKhoan (IDTaiKhoan) values (@i)
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_ChangePassword]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Usp_ChangePassword]
@usr varchar(25), @pwd nvarchar(200)
as
begin
update TaiKhoanDangNhap set MatKhau = @pwd where TenDangNhap =@usr
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_CheckAccountExist]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Usp_CheckAccountExist] @usr varchar(25)
as
begin
select IDTaiKhoan, TenDangNhap, MatKhau, AccessLevel from TaiKhoanDangNhap where TenDangNhap = @usr
end

GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteAccount]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Usp_DeleteAccount] @usr varchar(25)
as
begin
delete from TaiKhoanDangNhap where TenDangNhap = @usr
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_LoadDanhSachTaiKhoan]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Usp_LoadDanhSachTaiKhoan] @acc varchar(20)
as
begin
if @acc = 'All'
begin
select TenDangNhap, MatKhau, AccessLevel, IDTaiKhoan from TaiKhoanDangNhap
end
else 
begin
select TenDangNhap, MatKhau, AccessLevel, IDTaiKhoan from TaiKhoanDangNhap where AccessLevel = @acc
end
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_Login]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Usp_Login] @usr varchar(20), @pwd varchar(100)
as
begin
select IDTaiKhoan, TenDangNhap, MatKhau, AccessLevel from TaiKhoanDangNhap where TenDangNhap = @usr and MatKhau = @pwd
end
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateThongTin]    Script Date: 1/1/2022 11:14:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Usp_UpdateThongTin]
@ten varchar(50) , @tuoi int  , @dc varchar(50), @SDT varchar(12), @id int
as
begin
if @ten != '' update ThongTinTaiKhoan set Ten = @ten where IDTaiKhoan = @id
if @dc != '' update ThongTinTaiKhoan set DiaChi = @dc where IDTaiKhoan = @id
if @SDT != '' update ThongTinTaiKhoan set SDT = @SDT where IDTaiKhoan = @id
if @tuoi is not null update ThongTinTaiKhoan set Tuoi = @tuoi where IDTaiKhoan = @id

end
GO
USE [master]
GO
ALTER DATABASE [invwarehouse] SET  READ_WRITE 
GO
