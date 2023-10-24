
INSERT INTO [dbo].[UserRecord] ([UserID],[UserName],[UserEmail],[DataValue],[NotificationFlag],[CreatedDateTime],[LastUpdatedDateTime])
     VALUES
	  (NEWID(),'Vijay','vijay@test.com','test data',1,GETDATE(),GETDATE()),
	  (NEWID(),'Joe','Joe@test.com','Joes test data',1,GETDATE(),GETDATE())
GO


