USE [consultare.gov.start]
GO
/****** Object:  Table [dbo].[Proposals]    Script Date: 11/29/2016 1:25:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proposals](
	[Id] [nvarchar](128) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[InstitutionId] [nvarchar](128) NOT NULL,
	[InitiatingInstitutionId] [nvarchar](128) NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[LimitDate] [datetime] NULL,
	[Link] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Observations] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Proposals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Proposals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proposals_dbo.Institutions_InitiatingInstitutionId] FOREIGN KEY([InitiatingInstitutionId])
REFERENCES [dbo].[Institutions] ([Id])
GO
ALTER TABLE [dbo].[Proposals] CHECK CONSTRAINT [FK_dbo.Proposals_dbo.Institutions_InitiatingInstitutionId]
GO
ALTER TABLE [dbo].[Proposals]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Proposals_dbo.Institutions_InstitutionId] FOREIGN KEY([InstitutionId])
REFERENCES [dbo].[Institutions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Proposals] CHECK CONSTRAINT [FK_dbo.Proposals_dbo.Institutions_InstitutionId]
GO
