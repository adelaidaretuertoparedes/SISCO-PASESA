CREATE FUNCTION [dbo].[UFN_GetNextCodeSequence]
(
    @SequencePrefix VARCHAR(5),
    @SequenceId INT,
	@SuffixLength INT=10
) RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @result varchar(20)
    SET @result = @SequencePrefix + dbo.UFN_PadLeft(@SequenceId,'0',@SuffixLength)
    RETURN @result    
END
