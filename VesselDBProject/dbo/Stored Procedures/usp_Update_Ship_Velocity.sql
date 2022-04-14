
-- =============================================
-- Author:      Werq Labs
-- Create Date: 30.03.2022
-- Description: Update Ships Velocity
-- =============================================
CREATE PROCEDURE [dbo].[usp_Update_Ship_Velocity](
@ShipId_In INT ,
@ShipVelocity_In DECIMAL(5, 3),
@Longitude_In DECIMAL(9,6),
@Latitude_In DECIMAL(9,6),
@ErrorMsg_Out VARCHAR(100) OUTPUT
)
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    SET NOCOUNT ON
	IF EXISTS (SELECT PK_ShipID FROM tblShipMasters WHERE PK_ShipID = @ShipId_In)
	BEGIN
		UPDATE tblShipMasters SET ShipVelocity = @ShipVelocity_In,CurrentLatitude = @Latitude_In,CurrentLongitude =  @Longitude_In
		WHERE PK_ShipID=@ShipId_In
	END
	ELSE
	BEGIN
		SET @ErrorMsg_Out = 'Invalid Ship Id.';
	END
END
