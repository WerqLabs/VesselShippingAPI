
-- =============================================
-- Author:      Werq Labs
-- Create Date: 04.04.2022
-- Description: Get Nearest Port Of Ship
-- =============================================
CREATE Procedure [dbo].[usp_Get_Nearest_Port](
	@ShipId_In int,
	@ErrorMsg_Out varchar(100) OUTPUT
)
As
BEGIN
DECLARE @ShipName VARCHAR(100)
DECLARE @Latitude DECIMAL (9,6)
DECLARE @Longitude DECIMAL (9,6)
DECLARE @Velocity DECIMAL (9,6)
SELECT @Latitude=CurrentLatitude,@Longitude=CurrentLongitude,@Velocity=ShipVelocity,@ShipName=ShipName FROM tblShipMasters
WHERE PK_ShipID=@ShipId_In

IF @ShipName IS NOT NULL AND @Velocity >0 
	BEGIN
				SELECT TOP 1 PortName,distance,distance/@Velocity AS ETA,@Velocity AS Velocity,@ShipName AS ShipName FROM (
				SELECT *, 
					(
						(
							(
								acos(
									sin(( @Latitude * pi() / 180))
									*
									sin(( [latitude] * pi() / 180)) + cos(( @Latitude * pi() /180 ))
									*
									cos(( [latitude] * pi() / 180)) * cos((( @Longitude - [longitude]) * pi()/180)))
							) * 180/pi()
						) * 60 * 1.1515 * 0.86898
					)
				AS distance FROM tblPortMasters
			) myTable ORDER BY distance
	END
ELSE
	BEGIN
		IF @Velocity =0
		BEGIN
			SET @ErrorMsg_Out='Please Update Velocity of the Ship to get ETA, Velocity Cannot be 0'
		END
		ELSE
		BEGIN
			SET @ErrorMsg_Out='Please Provider valid Ship Id, Record Not Found'
		END
	END
END

/****** Object:  StoredProcedure [dbo].[usp_Get_Nearest_Port]    Script Date: 04/12/2022 3:02:47 PM ******/
SET ANSI_NULLS ON
