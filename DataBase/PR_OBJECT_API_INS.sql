SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Putz
-- Create date: 21/06/2022
-- Description:	Insert Object Data Table and return new Id inserted
-- =============================================
CREATE PROCEDURE PR_OBJECT_API_INS
	-- Add the parameters for the stored procedure here
	@NAME VARCHAR(50),
	@DESCRIPTION VARCHAR(200),
	@TYPE_ID [int],
	@ID BIGINT OUTPUT
AS
BEGIN
	INSERT INTO TAB_OBJECT ([NAME], [DESCRIPTION], [TYPE_ID]) VALUES (@NAME, @DESCRIPTION, @TYPE_ID);
	SELECT @ID = @@IDENTITY;
END
GO
