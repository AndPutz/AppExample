USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 21/06/2022
-- Description:	Update Object Data Table 
-- =============================================
CREATE PROCEDURE [dbo].[PR_OBJECT_API_UPD]
	-- Add the parameters for the stored procedure here
	@NAME VARCHAR(50),
	@DESCRIPTION VARCHAR(200),
	@TYPE_ID [int],
	@ID BIGINT
AS
BEGIN
	UPDATE TAB_OBJECT SET [NAME] = @NAME, [DESCRIPTION] = @DESCRIPTION, [TYPE_ID] = @TYPE_ID, DATE_MODIFIED = GETDATE() WHERE ID = @ID;	
END
GO


