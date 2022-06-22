USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		André Putz
-- Create date: 22/06/2022
-- Description:	Select just the name of both objects related each other distinctly for uses with autocomplete feature
-- =============================================
CREATE PROCEDURE [dbo].[PR_RELATIONS_API_SEL_AUTOCOMP]	
	@NAME VARCHAR(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT DISTINCT [NAME]
	FROM
	(
		SELECT [NAME]
		FROM
		(
			SELECT [NAME] FROM TAB_RELATIONS T1 WITH(NOLOCK)
			INNER JOIN TAB_OBJECT T2 WITH(NOLOCK) ON
				T1.ID_OBJECT_A = T2.ID
			WHERE 
				T2.[NAME] LIKE '%' + @NAME + '%'
		) AS A
		UNION ALL
		SELECT [NAME]
		FROM
		(
			SELECT [NAME] FROM TAB_RELATIONS T1 WITH(NOLOCK)
			INNER JOIN TAB_OBJECT T2 WITH(NOLOCK) ON
				T1.ID_OBJECT_B = T2.ID
			WHERE 
				T2.[NAME] LIKE '%' + @NAME + '%'
		) AS B
	) AS RESULT
	ORDER BY [NAME] ASC

END
GO


