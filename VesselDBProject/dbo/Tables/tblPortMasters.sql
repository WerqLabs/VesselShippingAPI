CREATE TABLE [dbo].[tblPortMasters] (
    [PK_PortId] INT            IDENTITY (1, 1) NOT NULL,
    [PortName]  VARCHAR (75)   NOT NULL,
    [Latitude]  DECIMAL (8, 6) NOT NULL,
    [Longitude] DECIMAL (9, 6) NOT NULL,
    CONSTRAINT [PK_PortMaster1] PRIMARY KEY CLUSTERED ([PK_PortId] ASC)
);

