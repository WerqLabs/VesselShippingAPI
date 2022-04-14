

-- =============================================
-- Author:      Werq Labs
-- Create Date: 30.03.2022
-- Description: Get All Port List
-- =============================================
CREATE PROCEDURE [dbo].[usp_Port_All_List]
AS
BEGIN
	SELECT PortName,Latitude,Longitude FROM tblPortMasters
END

/****** Object:  StoredProcedure dbo.usp_Get_Nearest_Port    Script Date: 04/12/2022 3:02:47 PM ******/
SET ANSI_NULLS ON
