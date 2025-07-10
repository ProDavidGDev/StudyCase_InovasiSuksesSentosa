USE [CaseStudyDB]
GO

/****** Object: Table [dbo].[ListNama] Script Date: 10/07/2025 20:02:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ListNama](
	[NIK] [varchar](10) NOT NULL,
	[Nama] [varchar](50) NOT NULL,
    CONSTRAINT [PK_ListNama] PRIMARY KEY ([NIK])
)
GO

/****** Object: Table [dbo].[Absensi] Script Date: 10/07/2025 20:06:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Membuat tabel absensi dengan Primary Key gabungan dan Foreign Key
CREATE TABLE [dbo].[Absensi](
	[NIK] [varchar](10) NOT NULL,
	[TanggalAbsen] [date] NOT NULL,
    CONSTRAINT [PK_Absensi] PRIMARY KEY ([NIK], [TanggalAbsen]),
    CONSTRAINT [FK_Absensi_To_ListNama] FOREIGN KEY ([NIK]) REFERENCES [dbo].[ListNama]([NIK])
)
GO

