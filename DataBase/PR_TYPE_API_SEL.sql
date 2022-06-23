USE [dbAppExample]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		André Putz
-- Create date: 23/06/2022
-- Description:	Select all types
-- =============================================
CREATE PROCEDURE [dbo].[PR_TYPE_API_SEL]	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT ID, [DESCRIPTION] 	
	FROM TAB_TYPE WITH(NOLOCK)
	ORDER BY [DESCRIPTION] ASC
	
END
GO


