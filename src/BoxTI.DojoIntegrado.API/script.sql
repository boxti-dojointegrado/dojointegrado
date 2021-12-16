USE `dojointegrado-db`;

CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Password` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Role` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Users` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211203142737_Inital_migration', '6.0.0');

COMMIT;

START TRANSACTION;

CREATE TABLE `Addresses` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `StreetName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `City` longtext CHARACTER SET utf8mb4 NOT NULL,
    `State` longtext CHARACTER SET utf8mb4 NOT NULL,
    `ZipCode` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Neighborhood` longtext CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK_Addresses` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

CREATE TABLE `Organizations` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Phone` longtext CHARACTER SET utf8mb4 NOT NULL,
    `CorporateName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `FantasyName` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Cnpj` longtext CHARACTER SET utf8mb4 NOT NULL,
    `Description` longtext CHARACTER SET utf8mb4 NOT NULL,
    `AddressId` int NOT NULL,
    CONSTRAINT `PK_Organizations` PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Organizations_Addresses_AddressId` FOREIGN KEY (`AddressId`) REFERENCES `Addresses` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Companies` (
    `OrganizationId` int NOT NULL,
    CONSTRAINT `PK_Companies` PRIMARY KEY (`OrganizationId`),
    CONSTRAINT `FK_Companies_Organizations_OrganizationId` FOREIGN KEY (`OrganizationId`) REFERENCES `Organizations` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE TABLE `Ngos` (
    `OrganizationId` int NOT NULL,
    CONSTRAINT `PK_Ngos` PRIMARY KEY (`OrganizationId`),
    CONSTRAINT `FK_Ngos_Organizations_OrganizationId` FOREIGN KEY (`OrganizationId`) REFERENCES `Organizations` (`Id`) ON DELETE CASCADE
) CHARACTER SET=utf8mb4;

CREATE INDEX `IX_Organizations_AddressId` ON `Organizations` (`AddressId`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20211203191741_Add_Entities', '6.0.0');

COMMIT;

