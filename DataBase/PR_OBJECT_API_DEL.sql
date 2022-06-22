USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 22/06/2022
-- Description:	Delete all Object Data Table and theirs relations if has
-- =============================================
CREATE PROCEDURE [dbo].[PR_OBJECT_API_DEL]	
	@ID BIGINT
AS
BEGIN
	
	DELETE TAB_RELATIONS WHERE ID_OBJECT_A = @ID;

	DELETE TAB_RELATIONS WHERE ID_OBJECT_B = @ID;

	DELETE TAB_OBJECT WHERE ID = @ID;
	
END
GO


