USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 22/06/2022
-- Description:	Update a Relations between two objects.
-- =============================================
CREATE PROCEDURE [dbo].[PR_RELATIONS_API_UPD]
	-- Add the parameters for the stored procedure here
	@ID_OBJECT_A BIGINT,
	@ID_OBJECT_B BIGINT,
	@ID BIGINT
AS
BEGIN
	UPDATE TAB_RELATIONS 
	SET ID_OBJECT_A = @ID_OBJECT_A, ID_OBJECT_B = @ID_OBJECT_B, DATE_MODIFIED = GETDATE() 
	WHERE ID = @ID;	
END
GO


