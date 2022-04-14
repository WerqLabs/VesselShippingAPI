
-- =============================================
-- Author:      Werq Labs
-- Create Date: 04.04.2022
-- Description: Show All Ships
-- =============================================
CREATE PROCEDURE [dbo].[usp_List_All_Ship]
AS
BEGIN
	SELECT PK_ShipId,ShipName,ShipVelocity,CurrentLatitude,CurrentLongitude FROM tblShipMasters
END
