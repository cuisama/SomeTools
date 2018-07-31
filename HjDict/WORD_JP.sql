USE ENTSVR;
--USE CTest;
GO
--DROP TABLE [dbo].[WORD_JP]
--GO
CREATE TABLE [dbo].[WORD_JP](
	Value [nvarchar](40) NOT NULL,
	Pronounces [nvarchar](100) NOT NULL,
	Sample [nvarchar](1000) NULL,
	Detail [nvarchar](max) NULL,
	Synant [nvarchar](1000) NULL,
	AudioUrl [nvarchar](100) NULL,
	Audio [varbinary](max) NULL,
	Mark [numeric](4,0) NULL,
	UpdateCount [numeric](4, 0) NOT NULL,
	UpdateTime [datetime] NOT NULL,
 CONSTRAINT [PK_WORD_JP] PRIMARY KEY CLUSTERED 
(
	Value,
	Pronounces
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]