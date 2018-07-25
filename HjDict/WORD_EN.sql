--USE ENTSVR;
USE CTest;
GO
--DROP TABLE [dbo].[WORD_EN]
--GO
CREATE TABLE [dbo].[WORD_EN](
	Value [nvarchar](40) NOT NULL,
	PronouncesUs [nvarchar](100) NULL,
	Sample [nvarchar](1000) NULL,
	Phrase [nvarchar](2000) NULL,
	Detail [nvarchar](max) NULL,
	PronouncesEn [nvarchar](40) NULL,
	DetailEnEn [nvarchar](4000) NULL,
	Synant [nvarchar](1000) NULL,
	Inflections [nvarchar](500) NULL,
	AudioUrl [nvarchar](100) NULL,
	Audio [varbinary](max) NULL,
 CONSTRAINT [PK_WORD_EN] PRIMARY KEY CLUSTERED 
(
	Value
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]