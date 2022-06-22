USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 22/06/2022
-- Description:	Delete a relations between two objects
-- =============================================
CREATE PROCEDURE [dbo].[PR_RELATIONS_API_DEL]	
	@ID BIGINT
AS
BEGIN
	
	DELETE TAB_RELATIONS WHERE ID = @ID;
	
END
GO


