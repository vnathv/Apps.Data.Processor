CREATE TABLE [dbo].[UserRecord](
	[RecordID] [int] NOT NULL,
	[UserID] [int] IDENTITY(100,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NULL,
	[DataValue] [nvarchar](max) NULL,
	[NotificationFlag] [bit] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastUpdatedDateTime] [datetime] NULL,
 CONSTRAINT [PK_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

ALTER TABLE [dbo].[UserRecord] ADD  CONSTRAINT [DF_UserRecord_LastUpdatedDateTime]  DEFAULT (getdate()) FOR [LastUpdatedDateTime]
GO