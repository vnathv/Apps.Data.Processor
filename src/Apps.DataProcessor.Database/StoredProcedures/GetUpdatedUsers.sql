CREATE PROCEDURE GetUpdatedUsers
    @TimeIntervalInMinutes int
AS
BEGIN
    SET NOCOUNT ON;

    -- Calculate the datetime 15 minutes ago
    DECLARE @FifteenMinutesAgo DATETIME
    SET @FifteenMinutesAgo = DATEADD(MINUTE, @TimeIntervalInMinutes, GETUTCDATE())

    -- Select records based on LastUpdatedDateTime or CreatedDateTime
    SELECT 
        RecordID, 
        UserID, 
        UserName, 
        UserEmail, 
        DataValue, 
        NotificationFlag, 
        CreatedDateTime, 
        LastUpdatedDateTime
    FROM 
        dbo.[UserRecord]
    WHERE 
        (LastUpdatedDateTime >= @FifteenMinutesAgo)
END
