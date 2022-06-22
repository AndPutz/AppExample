SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		André Putz
-- Create date: 22/06/2022
-- Description:	Insert Relations data and return new Id inserted
-- =============================================
CREATE PROCEDURE PR_RELATIONS_API_INS
	-- Add the parameters for the stored procedure here
	@ID_OBJECT_A BIGINT,
	@ID_OBJECT_B BIGINT,	
	@ID BIGINT OUTPUT
AS
BEGIN
	INSERT INTO TAB_RELATIONS (ID_OBJECT_A, ID_OBJECT_B) VALUES (@ID_OBJECT_A, @ID_OBJECT_B);
	SELECT @ID = @@IDENTITY;
END
GO
