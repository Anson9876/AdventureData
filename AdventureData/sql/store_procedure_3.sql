USE [AnsonsPersonalDB]
GO

/****** Object:  StoredProcedure [dbo].[DBA_GetAllSports]    Script Date: 10/25/2023 10:00:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DBA_GetAllSports] 
	-- Add the parameters for the stored procedure here
	@time			INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Sports WHERE DURATION <= @time
END
GO


