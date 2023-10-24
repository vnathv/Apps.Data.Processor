CREATE TABLE [dbo].[UserRecord](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](100) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[UserEmail] [varchar](50) NOT NULL,
	[DataValue] [varchar](max) NULL,
	[NotificationFlag] [bit] NOT NULL,
	[CreatedDateTime] [datetime] NOT NULL,
	[LastUpdatedDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)
GO

ALTER TABLE [dbo].[UserRecord] ADD  CONSTRAINT [DF_UserRecord_LastUpdatedDateTime]  DEFAULT (getdate()) FOR [LastUpdatedDateTime]
GO
ALTER TABLE [dbo].[UserRecord] ADD  CONSTRAINT [DF_UserRecord_NotificationFlag]  DEFAULT (0) FOR [NotificationFlag]
GO