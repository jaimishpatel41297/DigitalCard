USE [Digitalcard]
GO
/****** Object:  User [studyfield]    Script Date: 06-11-2018 20:05:11 ******/
CREATE USER [studyfield] FOR LOGIN [studyfield] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [studyfield]
GO
/****** Object:  Table [dbo].[Company_Master]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company_Master](
	[Company_id] [int] IDENTITY(1,1) NOT NULL,
	[Company_Name] [varchar](50) NULL,
	[Logo] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL,
	[Mobile] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CompanyDetail]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompanyDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[companyid] [int] NULL,
	[Cid] [int] NULL,
	[Name] [varchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [bigint] NULL,
	[URL] [nvarchar](max) NULL,
	[Email] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContactDetail]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Companyid] [int] NULL,
	[Cid] [int] NULL,
	[Mobile] [bigint] NULL,
	[Email] [nvarchar](50) NULL,
	[Whatsapp] [bigint] NULL,
	[Facebook] [nvarchar](100) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profile]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[companyid] [int] NULL,
	[Cid] [int] NULL,
	[Name] [varchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[Company] [nvarchar](50) NOT NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Registration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Mobile] [bigint] NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SocialLink]    Script Date: 06-11-2018 20:05:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SocialLink](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[companyid] [int] NULL,
	[Cid] [int] NULL,
	[Title] [varchar](50) NULL,
	[Url] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
