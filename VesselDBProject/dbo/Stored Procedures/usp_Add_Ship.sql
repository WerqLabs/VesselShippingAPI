
-- =============================================
-- Author:      Werq Labs
-- Create Date: 30.03.2022
-- Description: Add Ships
-- =============================================
CREATE PROCEDURE [dbo].[usp_Add_Ship](
	@ShipName_In VARCHAR(100),
	@ShipVelocity_In DECIMAL(5,2),
	@Latitude_In DECIMAL(9,6),
	@Longitude_In DECIMAL(9,6),
	@ErrorMsg_Out VARCHAR(100) OUTPUT,
	@Identity_Out INT OUTPUT
)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM tblShipMasters WHERE ShipName = @ShipName_In)
	BEGIN
		INSERT INTO tblShipMasters (ShipName,ShipVelocity,CurrentLatitude,CurrentLongitude)
		VALUES (@ShipName_In,@ShipVelocity_In,@Latitude_In,@Longitude_In)
		select @Identity_Out=@@IDENTITY
	END
	ELSE
	BEGIN
		SET @ErrorMsg_Out = 'Ship Name Already Exists.';
	END
END

/****** Object:  StoredProcedure [dbo].[usp_Get_Nearest_Port]    Script Date: 04/12/2022 3:02:47 PM ******/
SET ANSI_NULLS ON
