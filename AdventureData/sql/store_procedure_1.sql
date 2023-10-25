USE [AnsonsPersonalDB]
GO

/****** Object:  StoredProcedure [dbo].[DBA_GetAllCars]    Script Date: 10/25/2023 9:59:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DBA_GetAllCars] 
	-- Add the parameters for the stored procedure here
	@budget			INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM CARS WHERE PRICE <= @budget
END
GO


