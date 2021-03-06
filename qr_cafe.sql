USE [master]
GO
/****** Object:  Database [KafeOtomasyonu]    Script Date: 17.04.2021 13:55:25 ******/
CREATE DATABASE [KafeOtomasyonu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KafeOtomasyonu', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KafeOtomasyonu.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KafeOtomasyonu_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KafeOtomasyonu_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KafeOtomasyonu] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KafeOtomasyonu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KafeOtomasyonu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET ARITHABORT OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KafeOtomasyonu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KafeOtomasyonu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET  ENABLE_BROKER 
GO
ALTER DATABASE [KafeOtomasyonu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [KafeOtomasyonu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KafeOtomasyonu] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [KafeOtomasyonu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET RECOVERY FULL 
GO
ALTER DATABASE [KafeOtomasyonu] SET  MULTI_USER 
GO
ALTER DATABASE [KafeOtomasyonu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KafeOtomasyonu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KafeOtomasyonu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KafeOtomasyonu] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KafeOtomasyonu] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KafeOtomasyonu] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KafeOtomasyonu', N'ON'
GO
ALTER DATABASE [KafeOtomasyonu] SET QUERY_STORE = ON
GO
ALTER DATABASE [KafeOtomasyonu] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [KafeOtomasyonu]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[GecmisDetaylar]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GecmisDetaylar](
	[GecmisDetayId] [int] IDENTITY(1,1) NOT NULL,
	[GecmisSiparisId] [int] NOT NULL,
	[GecmisUrunId] [int] NOT NULL,
	[GecmisFiyat] [float] NOT NULL,
 CONSTRAINT [PK_GecmisDetaylar] PRIMARY KEY CLUSTERED 
(
	[GecmisDetayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GecmisSiparisler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GecmisSiparisler](
	[GecmisSiparisId] [int] NOT NULL,
	[GecmisMusteriId] [int] NOT NULL,
	[VerilmeTarihi] [nvarchar](50) NOT NULL,
	[VerilmeZamani] [nvarchar](50) NOT NULL,
	[TeslimTarihi] [nvarchar](50) NOT NULL,
	[TeslimZamani] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GecmisSiparisler] PRIMARY KEY CLUSTERED 
(
	[GecmisSiparisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategoriler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategoriler](
	[KategoriId] [int] IDENTITY(1,1) NOT NULL,
	[KategoriAdi] [nvarchar](50) NOT NULL,
	[UstKategoriId] [int] NOT NULL,
	[AktifMi] [nchar](5) NOT NULL,
 CONSTRAINT [PK_Kategoriler] PRIMARY KEY CLUSTERED 
(
	[KategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MasaBilgileri]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MasaBilgileri](
	[BilgiId] [int] IDENTITY(1,1) NOT NULL,
	[MasaId] [nvarchar](10) NOT NULL,
	[MusteriId] [int] NOT NULL,
	[AcilmaTarihi] [nvarchar](50) NOT NULL,
	[AcilmaZamani] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MasaBilgileri] PRIMARY KEY CLUSTERED 
(
	[BilgiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_MusteriId] UNIQUE NONCLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Masalar]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Masalar](
	[MasaId] [nvarchar](10) NOT NULL,
	[MusaitlikDurumu] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Masalar] PRIMARY KEY CLUSTERED 
(
	[MasaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteriler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteriler](
	[MusteriId] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[KullaniciAdi] [nvarchar](50) NOT NULL,
	[Parola] [nvarchar](12) NOT NULL,
	[KazanilanPuan] [float] NOT NULL,
	[Eposta] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiparisDetaylari]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiparisDetaylari](
	[DetayId] [int] IDENTITY(1,1) NOT NULL,
	[SiparisId] [int] NOT NULL,
	[UrunId] [int] NOT NULL,
 CONSTRAINT [PK_SiparisDetaylari] PRIMARY KEY CLUSTERED 
(
	[DetayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparisler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparisler](
	[SiparisId] [int] IDENTITY(1,1) NOT NULL,
	[MusteriId] [int] NOT NULL,
	[VerilmeTarihi] [nvarchar](50) NOT NULL,
	[VerilmeZamani] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Siparisler] PRIMARY KEY CLUSTERED 
(
	[SiparisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urunler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urunler](
	[UrunId] [int] IDENTITY(1,1) NOT NULL,
	[UrunAdi] [nvarchar](50) NOT NULL,
	[StokDuzeyi] [int] NOT NULL,
	[Fiyat] [float] NOT NULL,
	[UrunPuani] [float] NOT NULL,
	[KategoriId] [int] NOT NULL,
	[AktifMi] [nchar](5) NOT NULL,
	[AlisPuani] [float] NULL,
 CONSTRAINT [PK_Urunler] PRIMARY KEY CLUSTERED 
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UrunResimleri]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UrunResimleri](
	[ResimId] [int] IDENTITY(1,1) NOT NULL,
	[ResimAdi] [nvarchar](max) NOT NULL,
	[ResimYolu] [nvarchar](max) NOT NULL,
	[Resim] [image] NOT NULL,
	[UrunId] [int] NOT NULL,
 CONSTRAINT [PK_UrunResimleri] PRIMARY KEY CLUSTERED 
(
	[ResimId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UKUrunId] UNIQUE NONCLUSTERED 
(
	[UrunId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UstKategoriler]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UstKategoriler](
	[UstKategoriId] [int] IDENTITY(1,1) NOT NULL,
	[UstKategoriAdi] [nvarchar](50) NOT NULL,
	[AktifMi] [nchar](5) NOT NULL,
 CONSTRAINT [PK_UstKategoriler] PRIMARY KEY CLUSTERED 
(
	[UstKategoriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GecmisDetaylar]  WITH CHECK ADD  CONSTRAINT [fkGecmisSiparisId] FOREIGN KEY([GecmisSiparisId])
REFERENCES [dbo].[GecmisSiparisler] ([GecmisSiparisId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GecmisDetaylar] CHECK CONSTRAINT [fkGecmisSiparisId]
GO
ALTER TABLE [dbo].[GecmisDetaylar]  WITH CHECK ADD  CONSTRAINT [fkGecmisUrunId] FOREIGN KEY([GecmisUrunId])
REFERENCES [dbo].[Urunler] ([UrunId])
GO
ALTER TABLE [dbo].[GecmisDetaylar] CHECK CONSTRAINT [fkGecmisUrunId]
GO
ALTER TABLE [dbo].[GecmisSiparisler]  WITH CHECK ADD  CONSTRAINT [fkGecmisMusteriId] FOREIGN KEY([GecmisMusteriId])
REFERENCES [dbo].[Musteriler] ([MusteriId])
GO
ALTER TABLE [dbo].[GecmisSiparisler] CHECK CONSTRAINT [fkGecmisMusteriId]
GO
ALTER TABLE [dbo].[Kategoriler]  WITH CHECK ADD  CONSTRAINT [UstKategori] FOREIGN KEY([UstKategoriId])
REFERENCES [dbo].[UstKategoriler] ([UstKategoriId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Kategoriler] CHECK CONSTRAINT [UstKategori]
GO
ALTER TABLE [dbo].[MasaBilgileri]  WITH CHECK ADD  CONSTRAINT [fk_MasaId] FOREIGN KEY([MasaId])
REFERENCES [dbo].[Masalar] ([MasaId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MasaBilgileri] CHECK CONSTRAINT [fk_MasaId]
GO
ALTER TABLE [dbo].[MasaBilgileri]  WITH CHECK ADD  CONSTRAINT [fk_MusteriId] FOREIGN KEY([MusteriId])
REFERENCES [dbo].[Musteriler] ([MusteriId])
GO
ALTER TABLE [dbo].[MasaBilgileri] CHECK CONSTRAINT [fk_MusteriId]
GO
ALTER TABLE [dbo].[SiparisDetaylari]  WITH CHECK ADD  CONSTRAINT [Detay_Siparis] FOREIGN KEY([SiparisId])
REFERENCES [dbo].[Siparisler] ([SiparisId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SiparisDetaylari] CHECK CONSTRAINT [Detay_Siparis]
GO
ALTER TABLE [dbo].[SiparisDetaylari]  WITH CHECK ADD  CONSTRAINT [Detay_Urun] FOREIGN KEY([UrunId])
REFERENCES [dbo].[Urunler] ([UrunId])
GO
ALTER TABLE [dbo].[SiparisDetaylari] CHECK CONSTRAINT [Detay_Urun]
GO
ALTER TABLE [dbo].[Siparisler]  WITH CHECK ADD  CONSTRAINT [fkMusteriId] FOREIGN KEY([MusteriId])
REFERENCES [dbo].[Musteriler] ([MusteriId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Siparisler] CHECK CONSTRAINT [fkMusteriId]
GO
ALTER TABLE [dbo].[Urunler]  WITH CHECK ADD  CONSTRAINT [UrunKategori] FOREIGN KEY([KategoriId])
REFERENCES [dbo].[Kategoriler] ([KategoriId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Urunler] CHECK CONSTRAINT [UrunKategori]
GO
ALTER TABLE [dbo].[UrunResimleri]  WITH CHECK ADD  CONSTRAINT [UrunResmiUrun] FOREIGN KEY([UrunId])
REFERENCES [dbo].[Urunler] ([UrunId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UrunResimleri] CHECK CONSTRAINT [UrunResmiUrun]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisDetayiEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGecmisSiparisDetayiEkle]
(
	@SiparisId int,
	@UrunId int,
	@GecmisFiyat float
)
as
insert GecmisDetaylar values(@SiparisId, @UrunId, @GecmisFiyat)


GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisDetayiGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spGecmisSiparisDetayiGetir]
as
select * from GecmisDetaylar



GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisDetaySiparisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGecmisSiparisDetaySiparisi]
(
	@id int
)
as
select gs.GecmisMusteriId,gs.GecmisSiparisId,gs.TeslimTarihi,gs.TeslimZamani,gs.VerilmeZamani,gs.VerilmeTarihi from GecmisSiparisler gs inner join GecmisDetaylar gd on gd.GecmisSiparisId = gs.GecmisSiparisId where gd.GecmisDetayId = @id
GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisDetayUrunu]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGecmisSiparisDetayUrunu]
(
	@id int
)
as
select u.AktifMi,u.Fiyat,u.KategoriId,u.StokDuzeyi,u.UrunAdi,u.UrunId,u.UrunPuani,u.AlisPuani from Urunler u inner join GecmisDetaylar gd on gd.GecmisUrunId = u.UrunId where gd.GecmisDetayId = @id
GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGecmisSiparisEkle]
(
	@SiparisId int,
	@MusteriId int,
	@VerilmeTarihi nvarchar(50), 
	@VerilmeZamani nvarchar(50), 
	@TeslimTarihi nvarchar(50), 
	@TeslimZamani nvarchar(max)
)
as
insert GecmisSiparisler values(@SiparisId, @MusteriId, @VerilmeTarihi, @VerilmeZamani,@TeslimTarihi,@TeslimZamani)


GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[spGecmisSiparisGetir]
as
select * from GecmisSiparisler


GO
/****** Object:  StoredProcedure [dbo].[spGecmisSiparisMusterisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spGecmisSiparisMusterisi]
(
	@id int
)
as
select m.Ad,m.Eposta,m.KazanilanPuan,m.KullaniciAdi,m.MusteriId,m.Parola,m.Soyad from Musteriler m inner join GecmisSiparisler gs on gs.GecmisMusteriId = m.MusteriId where gs.GecmisSiparisId = @id
GO
/****** Object:  StoredProcedure [dbo].[spGunSonuGrid]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spGunSonuGrid]
@tarih nvarchar(50)
as
select u.UrunAdi, COUNT(u.UrunId) Adet, gd.GecmisFiyat from GecmisDetaylar gd 
inner join GecmisSiparisler gs on gd.GecmisSiparisId= gs.GecmisSiparisId 
inner join  Urunler u on u.UrunId = gd.GecmisUrunId where gs.TeslimTarihi = @tarih
group by u.UrunAdi, gd.GecmisFiyat order by COUNT(u.UrunId) desc 

GO
/****** Object:  StoredProcedure [dbo].[spKategoriEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spKategoriEkle]
@KategoriAdi nvarchar(50),
@UstKategoriId int,
@AktifMi nchar(5)
as
insert Kategoriler values(@KategoriAdi,@UstKategoriId,@AktifMi)

GO
/****** Object:  StoredProcedure [dbo].[spKategoriGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spKategoriGuncelle]
(
@KategoriId int,
@KategoriAdi nvarchar(50),
@AktifMi nchar(5),
@UstKategoriId int
)
as
update Kategoriler set KategoriAdi = @KategoriAdi, UstKategoriId = @UstKategoriId, AktifMi = @AktifMi where KategoriId = @KategoriId

GO
/****** Object:  StoredProcedure [dbo].[spKategoriHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spKategoriHepsiniGetir]
as
select * from Kategoriler

GO
/****** Object:  StoredProcedure [dbo].[spKategorininUstKategorisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spKategorininUstKategorisi]
(
@KategoriId int
)
as
select uk.UstKategoriId, uk.UstKategoriAdi, uk.AktifMi from UstKategoriler uk inner join Kategoriler k on k.UstKategoriId = uk.UstKategoriId where k.KategoriId = @KategoriId

GO
/****** Object:  StoredProcedure [dbo].[spKategoriSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spKategoriSil]
@KategoriId int
as
delete from Kategoriler where KategoriId = @KategoriId

GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMasaBilgileriEkle]
(
@MasaId nvarchar(10),
@MusteriId int,
@AcilmaTarihi nvarchar(50),
@AcilmaZamani nvarchar(50)
)
as
insert MasaBilgileri values(@MasaId, @MusteriId,@AcilmaTarihi,@AcilmaZamani)

GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spMasaBilgileriGuncelle]
(
@BilgiId int,
@MasaId nvarchar(10),
@MusteriId int,
@AcilmaTarihi nvarchar(50),
@AcilmaZamani nvarchar(50)
)
as
update MasaBilgileri set MasaId = @MasaId, MusteriId = @MusteriId, AcilmaTarihi = @AcilmaTarihi, AcilmaZamani=@AcilmaZamani where BilgiId = @BilgiId
GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaBilgileriHepsiniGetir]
as
select * from MasaBilgileri
GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriMasasi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaBilgileriMasasi]
(
	@BilgiId int
)
as
select m.MasaId, m.MusaitlikDurumu from Masalar m inner join MasaBilgileri n on n.MasaId = m.MasaId where BilgiId = @BilgiId
GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriMusterisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaBilgileriMusterisi]
(
	@BilgiId int
)
as
Select m.MusteriId,m.Ad,m.Soyad,m.KullaniciAdi,m.Parola,m.KazanilanPuan,m.Eposta from Musteriler m inner join MasaBilgileri n on n.MusteriId = m.MusteriId where n.BilgiId=@BilgiId

GO
/****** Object:  StoredProcedure [dbo].[spMasaBilgileriSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaBilgileriSil]
(
@BilgiId int
)
as
delete from MasaBilgileri where BilgiId = @BilgiId
GO
/****** Object:  StoredProcedure [dbo].[spMasaEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaEkle]
(
	@MasaId nvarchar(10),
	@MusaitlikDurumu nchar(5)
)
as
insert Masalar(MasaId,MusaitlikDurumu) values(@MasaId, @MusaitlikDurumu)

GO
/****** Object:  StoredProcedure [dbo].[spMasaGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaGuncelle]
(
	@MasaId nvarchar(10),
	@MusaitlikDurumu nchar(5)

)
as
update Masalar set MusaitlikDurumu= @MusaitlikDurumu where MasaId = @MasaId

GO
/****** Object:  StoredProcedure [dbo].[spMasaHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaHepsiniGetir]

as
select * from Masalar

GO
/****** Object:  StoredProcedure [dbo].[spMasaSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMasaSil]
(
	@MasaId nvarchar(10)

)
as
delete from Masalar where MasaId = @MasaId

GO
/****** Object:  StoredProcedure [dbo].[spMusteriEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMusteriEkle]
(
@Ad nvarchar(50),
@Soyad nvarchar(50),
@KullaniciAdi nvarchar(50),
@Parola nvarchar(12),
@KazanilanPuan float,
@Eposta nvarchar(MAX)
)
as
insert Musteriler values(@Ad,@Soyad,@KullaniciAdi,@Parola,@KazanilanPuan,@Eposta)

GO
/****** Object:  StoredProcedure [dbo].[spMusteriGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMusteriGuncelle]
(
@MusteriId int,
@Ad nvarchar(50),
@Soyad nvarchar(50),
@KullaniciAdi nvarchar(50),
@Parola nvarchar(12),
@KazanilanPuan float,
@Eposta nvarchar(MAX)
)
as
update Musteriler set Ad = @Ad, Soyad = @Soyad, KullaniciAdi = @KullaniciAdi, Parola = @Parola, KazanilanPuan = @KazanilanPuan,Eposta = @Eposta where MusteriId = @MusteriId

GO
/****** Object:  StoredProcedure [dbo].[spMusteriHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMusteriHepsiniGetir]
as
select * from Musteriler

GO
/****** Object:  StoredProcedure [dbo].[spMusteriSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spMusteriSil]
(
@MusteriId int
)
as
delete from Musteriler where MusteriId = @MusteriId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisDetayiEkle]
(
	@SiparisId int,
	@UrunId int
)
as
insert SiparisDetaylari values(@SiparisId, @UrunId)

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisDetayiGuncelle]
(
	@SiparisId int,
	@UrunId int,
	@DetayId int
)
as
update SiparisDetaylari set  SiparisId = @SiparisId, UrunId = @UrunId where DetayId = @DetayId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisDetayiHepsiniGetir]
as
select * from SiparisDetaylari

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisDetayiSil]
(
		@DetayId int
)
as
delete from SiparisDetaylari where SiparisId = @DetayId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiSiparisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spSiparisDetayiSiparisi]
(
	@DetayId int
)
as
select s.SiparisId, s.VerilmeZamani from Siparisler s inner join SiparisDetaylari sd on sd.SiparisId = s.SiparisId where sd.DetayId = @DetayId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisDetayiUrunu]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spSiparisDetayiUrunu]
(
	@DetayId int
)
as
select u.UrunId,u.UrunAdi,u.Fiyat, u.StokDuzeyi,u.UrunPuani, u.AktifMi, u.AlisPuani from Urunler u inner join SiparisDetaylari s on s.UrunId = u.UrunId where s.DetayId = @DetayId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spSiparisEkle]
(
	@MusteriId int,
	@VerilmeTarihi nvarchar(50),
	@VerilmeZamani nvarchar(50)

)
as
insert Siparisler values(@MusteriId, @VerilmeTarihi, @VerilmeZamani)

GO
/****** Object:  StoredProcedure [dbo].[spSiparisGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spSiparisGuncelle]
(
	@SiparisId int,
	@MusteriId int, 
	@VerilmeTarihi nvarchar(50),
	@VerilmeZamani nvarchar(50)
	
)
as
update Siparisler set  MusteriId = @MusteriId, VerilmeZamani = @VerilmeZamani, VerilmeTarihi = @VerilmeTarihi where SiparisId = @SiparisId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisHepsiniGetir]
as
select * from Siparisler

GO
/****** Object:  StoredProcedure [dbo].[spSiparisinMusterisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisinMusterisi]
(
	@SiparisId int
)
as
Select m.MusteriId,m.Ad,m.Soyad,m.KullaniciAdi,m.Parola,m.KazanilanPuan,m.Eposta  from Musteriler m inner join Siparisler s on s.MusteriId = m.MusteriId where s.SiparisId=@SiparisId

GO
/****** Object:  StoredProcedure [dbo].[spSiparisSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spSiparisSil]
(
	@SiparisId int
)
as
delete from Siparisler where SiparisId = @SiparisId

GO
/****** Object:  StoredProcedure [dbo].[spUrunEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spUrunEkle]
(
@UrunAdi nvarchar(50),
@StokDuzeyi int ,
@Fiyat float,
@UrunPuani float,
@KategoriId int,
@AktifMi nchar(5),
@AlisPuani float
)
as
insert Urunler values(@UrunAdi, @StokDuzeyi, @Fiyat, @UrunPuani, @KategoriId, @AktifMi,@AlisPuani)

GO
/****** Object:  StoredProcedure [dbo].[spUrunGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spUrunGuncelle]
(
@UrunId int,
@UrunAdi nvarchar(50),
@StokDuzeyi int ,
@Fiyat float,
@UrunPuani float,
@KategoriId int,
@AktifMi nchar(5),
@AlisPuani float
)
as
update Urunler set UrunAdi =@UrunAdi, KategoriId=@KategoriId, Fiyat=@Fiyat, StokDuzeyi=@StokDuzeyi, UrunPuani = @UrunPuani, AktifMi = @AktifMi, AlisPuani = @AlisPuani where UrunId = @UrunId

GO
/****** Object:  StoredProcedure [dbo].[spUrunHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunHepsiniGetir]
as
select * from Urunler

GO
/****** Object:  StoredProcedure [dbo].[spUrunKategorisi]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunKategorisi]
(
	@UrunId int
)
as
select k.KategoriId, k.KategoriAdi, k.AktifMi from Kategoriler k inner join Urunler u on u.KategoriId = k.KategoriId where u.UrunId= @UrunId

GO
/****** Object:  StoredProcedure [dbo].[spUrunResmiEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunResmiEkle]
(
	@ResimAdi nvarchar(MAX),
	@ResimYolu nvarchar(MAX),
	@Resim image,
	@UrunId int
)
as
insert UrunResimleri values(@ResimAdi, @ResimYolu, @Resim, @UrunId)

GO
/****** Object:  StoredProcedure [dbo].[spUrunResmiGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunResmiGuncelle]
(
	@ResimId int,
	@ResimAdi nvarchar(MAX),
	@ResimYolu nvarchar(MAX),
	@Resim image,
	@UrunId int
)
as
update UrunResimleri set ResimAdi = @ResimAdi, ResimYolu = @ResimYolu, Resim = @Resim, UrunId = @UrunId where ResimId = @ResimId

GO
/****** Object:  StoredProcedure [dbo].[spUrunResmiHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunResmiHepsiniGetir]
as
select * from UrunResimleri

GO
/****** Object:  StoredProcedure [dbo].[spUrunResmiSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunResmiSil]
(
	@ResimId int
)
as
delete from UrunResimleri where ResimId = @ResimId

GO
/****** Object:  StoredProcedure [dbo].[spUrunResmiUrunu]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunResmiUrunu]
(
	@ResimId int
)
as
select u.AktifMi,u.Fiyat,u.KategoriId,u.StokDuzeyi,u.UrunAdi,u.UrunId,u.UrunPuani from Urunler u inner join UrunResimleri ur on ur.UrunId = u.UrunId where ur.ResimId = @ResimId

GO
/****** Object:  StoredProcedure [dbo].[spUrunSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUrunSil]
(
@UrunId int
)
as
delete from Urunler where UrunId = @UrunId

GO
/****** Object:  StoredProcedure [dbo].[spUstKategoriEkle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUstKategoriEkle]
(
@UstKategoriAdi nvarchar(50),
@AktifMi nvarchar(5)
)
as
insert UstKategoriler values(@UstKategoriAdi, @AktifMi)
GO
/****** Object:  StoredProcedure [dbo].[spUstKategoriGuncelle]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUstKategoriGuncelle]
(
@UstKategoriId int,
@UstKategoriAdi nvarchar(50),
@AktifMi nvarchar(5)
)
as
update UstKategoriler set UstKategoriAdi = @UstKategoriAdi, AktifMi = @AktifMi where UstKategoriId = @UstKategoriId
GO
/****** Object:  StoredProcedure [dbo].[spUstKategoriHepsiniGetir]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUstKategoriHepsiniGetir]
as
select * from UstKategoriler
GO
/****** Object:  StoredProcedure [dbo].[spUstKategoriSil]    Script Date: 17.04.2021 13:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUstKategoriSil]
(
@UstKategoriId int
)
as
delete from UstKategoriler where UstKategoriId = @UstKategoriId
GO
USE [master]
GO
ALTER DATABASE [KafeOtomasyonu] SET  READ_WRITE 
GO
