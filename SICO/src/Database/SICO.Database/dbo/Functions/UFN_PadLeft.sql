CREATE FUNCTION [dbo].[UFN_PadLeft]
(
	@TextToPad 	 	VARCHAR(8000),
	@CharacterToPad	VARCHAR(1),
	@NumberToPad	 	INT
)
RETURNS		VARCHAR(8000)
AS
BEGIN
	DECLARE	@OutputText VARCHAR(8000)
	
	SET		@OutputText = REPLICATE(@CharacterToPad, @NumberToPad) + @TextToPad	
	
	RETURN	RIGHT(@OutputText, @NumberToPad)
END