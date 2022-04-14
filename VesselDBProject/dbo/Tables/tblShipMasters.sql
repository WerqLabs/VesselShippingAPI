CREATE TABLE [dbo].[tblShipMasters] (
    [PK_ShipId]        INT            IDENTITY (1, 1) NOT NULL,
    [ShipName]         VARCHAR (100)  NOT NULL,
    [ShipVelocity]     DECIMAL (5, 2) NOT NULL,
    [CurrentLatitude]  DECIMAL (8, 6) NOT NULL,
    [CurrentLongitude] DECIMAL (9, 6) NOT NULL,
    CONSTRAINT [PK_ShipMaster] PRIMARY KEY CLUSTERED ([PK_ShipId] ASC)
);

