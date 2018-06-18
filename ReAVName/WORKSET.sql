CREATE TABLE [dbo].[WORKSET](
	Number [varchar](10) NOT NULL,
	Actor [varchar](20) NULL,
	Name [varchar](200) NULL,
	Url [varchar](100) NULL,
	Duration [varchar](5) NULL,
	IssueDate [varchar](10) NULL,
	Category [varchar](100) NULL,
	Director [varchar](20) NULL,
	Maker [varchar](20) NULL,
	Publisher [varchar](20) NULL,
	Image [varchar](100) NULL,
 CONSTRAINT [PK_WORKSET] PRIMARY KEY CLUSTERED 
(
	Number ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]