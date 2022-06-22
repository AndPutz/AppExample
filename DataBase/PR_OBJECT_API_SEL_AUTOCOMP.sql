USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 21/06/2022
-- Description:	Select just the name of Object Table for uses with autocomplete feature
-- =============================================
CREATE PROCEDURE [dbo].[PR_OBJECT_API_SEL_AUTOCOMP]	
	@NAME VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT [NAME] FROM TAB_OBJECT WITH(NOLOCK)
	WHERE NAME LIKE '%' + @NAME + '%';
	
END
GO


