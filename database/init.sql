CREATE TABLE IF NOT EXISTS `Sessions` (
    `Id` CHAR(36) PRIMARY KEY,
    `Ip` VARCHAR(15) NOT NULL,
    `UserAgent` VARCHAR(255) NOT NULL,
    `Device` VARCHAR(255) NOT NULL,
    `Browser` VARCHAR(255) NOT NULL,
    `Os` VARCHAR(255) NOT NULL,
    `UserId` CHAR(36) NOT NULL,
    `IsActive` BOOLEAN NOT NULL,
    `Created` DATETIME NOT NULL,
    `Updated` DATETIME NULL,
    `Deleted` DATETIME NULL,
    `TenantId` CHAR(36) NOT NULL
);