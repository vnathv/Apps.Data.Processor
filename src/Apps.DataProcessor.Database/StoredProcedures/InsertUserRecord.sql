CREATE PROCEDURE InsertUserRecord
    @UserName NVARCHAR(255),
    @UserEmail NVARCHAR(255),
    @DataValue NVARCHAR(MAX),
    @NotificationFlag BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Generate a new GUID for UserID
    DECLARE @UserID UNIQUEIDENTIFIER
    SET @UserID = NEWID()

    -- Set CreatedDateTime to current date and time
    DECLARE @CreatedDateTime DATETIME
    SET @CreatedDateTime = GETDATE()

    -- Insert data into the table
    INSERT INTO UserRecord
    (UserID, 
    UserName, 
    UserEmail, 
    DataValue, 
    NotificationFlag, 
    CreatedDateTime, 
    LastUpdatedDateTime)
    VALUES
    (@UserID, 
    @UserName, 
    @UserEmail, 
    @DataValue, 
    @NotificationFlag, 
    @CreatedDateTime, 
    @CreatedDateTime);
END