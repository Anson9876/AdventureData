USE [AnsonsPersonalDB]
GO

/****** Object:  StoredProcedure [dbo].[DBA_GetAllPhones]    Script Date: 10/25/2023 10:00:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[DBA_GetAllPhones] 
	-- Add the parameters for the stored procedure here
	@budget			INT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Phones WHERE PRICE <= @budget
END
GO


