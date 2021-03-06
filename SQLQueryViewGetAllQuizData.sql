-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Petra Mille
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddAnswer] 
	-- Add the parameters for the stored procedure here
	
	@Description varchar(MAX),
	@IsCorrectAnswer int,
	@QuestionID int,
	@AnswerID int output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Answer (Description, IsCorrectAnswer) VALUES (@Description, @IsCorrectAnswer)
	
	SET @AnswerID=SCOPE_IDENTITY()
	INSERT INTO QuestionAnswer (QuestionID, AnswerID) VALUES (@QuestionID, @AnswerID)
	SET NOCOUNT OFF;
END
