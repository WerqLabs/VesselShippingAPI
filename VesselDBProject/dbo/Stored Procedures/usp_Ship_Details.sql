

-- =============================================
-- Author:      Werq Labs
-- Create Date: 30.03.2022
-- Description: Get Ship Details
-- =============================================
CREATE PROCEDURE dbo.usp_Ship_Details(
	@ShipId_In INT
)
AS
BEGIN
	SELECT ShipName,ShipVelocity,CurrentLatitude,CurrentLongitude FROM tblShipMasters WHERE PK_ShipId = @ShipId_In
END

/****** Object:  StoredProcedure dbo.usp_Get_Nearest_Port    Script Date: 04/12/2022 3:02:47 PM ******/
SET ANSI_NULLS ON
