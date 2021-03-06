USE [dbAppExample]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Andr? Putz
-- Create date: 23/06/2022
-- Description:	Select the Object Data Table by ID
-- =============================================
CREATE PROCEDURE [dbo].[PR_OBJECT_API_SEL_BYID]	
	@ID BIGINT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT T1.ID, [NAME], T1.[DESCRIPTION], T1.[TYPE_ID], T2.[DESCRIPTION] AS TYPE_DESCRIPTION
	FROM TAB_OBJECT T1 WITH(NOLOCK)
	INNER JOIN TAB_TYPE T2 WITH(NOLOCK) ON
		T1.TYPE_ID = T2.ID
	WHERE
		T1.ID = @ID;
	
END
GO


