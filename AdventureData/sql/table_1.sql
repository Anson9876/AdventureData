USE [AnsonsPersonalDB]
GO

/****** Object:  Table [dbo].[CARS]    Script Date: 10/25/2023 10:01:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CARS](
	[MAKE] [varchar](40) NULL,
	[MODEL] [varchar](40) NULL,
	[YEAR_OF_RELEASE] [int] NULL,
	[PRICE] [int] NULL
) ON [PRIMARY]

GO


