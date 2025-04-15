CREATE DATABASE IF NOT EXISTS Disaster_Relief CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE Disaster_Relief;

-- Role
CREATE TABLE Role (
    RoleId INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE CHECK (RoleName IN ('Admin', 'Staff'))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Area
CREATE TABLE Area (
    AreaId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    District VARCHAR(100),
    Province VARCHAR(100)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- DisasterType
CREATE TABLE DisasterType (
    DisasterTypeId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description VARCHAR(255)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ItemCategory
CREATE TABLE ItemCategory (
    CategoryId INT AUTO_INCREMENT PRIMARY KEY,
    CategoryName VARCHAR(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Donor
CREATE TABLE Donor (
    DonorId INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    CCCD VARCHAR(20) UNIQUE,
    Phone VARCHAR(20) UNIQUE,
    Email VARCHAR(100) UNIQUE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Warehouse
CREATE TABLE Warehouse (
    WarehouseId INT AUTO_INCREMENT PRIMARY KEY,
    Type VARCHAR(20) NOT NULL CHECK (Type IN ('Central', 'Local')),
    AreaId INT,
    Name VARCHAR(100) NOT NULL,
    FOREIGN KEY (AreaId) REFERENCES Area(AreaId) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- DisasterLevel
CREATE TABLE DisasterLevel (
    LevelId INT AUTO_INCREMENT PRIMARY KEY,
    DisasterTypeId INT NOT NULL,
    Level VARCHAR(50) NOT NULL,
    FOREIGN KEY (DisasterTypeId) REFERENCES DisasterType(DisasterTypeId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- WarehouseItem
CREATE TABLE WarehouseItem (
    ItemId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Unit VARCHAR(50),
    CategoryId INT,
    FOREIGN KEY (CategoryId) REFERENCES ItemCategory(CategoryId)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Donation
CREATE TABLE Donation (
    DonationId INT AUTO_INCREMENT PRIMARY KEY,
    DonorId INT NOT NULL,
    AreaId INT NOT NULL,
    Date DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (DonorId) REFERENCES Donor(DonorId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (AreaId) REFERENCES Area(AreaId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- User
CREATE TABLE `User` (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(256) NOT NULL,
    RoleId INT NOT NULL,
    AreaId INT,
    WarehouseId INT,
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (AreaId) REFERENCES Area(AreaId)
        ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(WarehouseId)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- SyncLog
CREATE TABLE SyncLog (
    SyncId INT AUTO_INCREMENT PRIMARY KEY,
    WarehouseId INT,
    SyncDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(50),
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(WarehouseId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Campaign
CREATE TABLE Campaign (
    CampaignId INT AUTO_INCREMENT PRIMARY KEY,
    AreaId INT NOT NULL,
    DisasterLevelId INT,
    Status VARCHAR(50) CHECK (Status IN ('Planned', 'Ongoing', 'Completed')),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Note VARCHAR(255),
    FOREIGN KEY (AreaId) REFERENCES Area(AreaId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (DisasterLevelId) REFERENCES DisasterLevel(LevelId)
        ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- WarehouseStock
CREATE TABLE WarehouseStock (
    StockId INT AUTO_INCREMENT PRIMARY KEY,
    WarehouseId INT,
    ItemId INT,
    Quantity INT DEFAULT 0,
    LastUpdated DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(WarehouseId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES WarehouseItem(ItemId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- DonationItem
CREATE TABLE DonationItem (
    DonationItemId INT AUTO_INCREMENT PRIMARY KEY,
    DonationId INT,
    ItemId INT,
    Quantity INT,
    Unit VARCHAR(50),
    FOREIGN KEY (DonationId) REFERENCES Donation(DonationId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES WarehouseItem(ItemId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- SyncLogItem
CREATE TABLE SyncLogItem (
    SyncLogItemId INT AUTO_INCREMENT PRIMARY KEY,
    SyncId INT,
    ItemId INT,
    Quantity INT,
    Unit VARCHAR(50),
    FOREIGN KEY (SyncId) REFERENCES SyncLog(SyncId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES WarehouseItem(ItemId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- CampaignItem
CREATE TABLE CampaignItem (
    CampaignId INT,
    ItemId INT,
    QuantityRequested INT,
    QuantityApproved INT,
    PRIMARY KEY (CampaignId, ItemId),
    FOREIGN KEY (CampaignId) REFERENCES Campaign(CampaignId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES WarehouseItem(ItemId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- DistributionLog
CREATE TABLE DistributionLog (
    DistributionId INT AUTO_INCREMENT PRIMARY KEY,
    CampaignId INT,
    ItemId INT,
    AreaId INT,
    Quantity INT,
    DistributionDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (CampaignId) REFERENCES Campaign(CampaignId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES WarehouseItem(ItemId)
        ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (AreaId) REFERENCES Area(AreaId)
        ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
