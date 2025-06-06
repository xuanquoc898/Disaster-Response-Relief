-- Xóa dữ liệu trong Area
DELETE FROM Area WHERE AreaId > 0;

-- Xóa dữ liệu trong Warehouse
DELETE FROM Warehouse WHERE WarehouseId > 0;

-- Xóa dữ liệu trong DisasterType
DELETE FROM DisasterType WHERE DisasterTypeId > 0;

-- Xóa dữ liệu trong DisasterLevel
DELETE FROM DisasterLevel WHERE LevelId > 0;

-- Xóa dữ liệu trong ItemCategory
-- DELETE FROM ItemCategory WHERE CategoryId > 0;

-- Xóa dữ liệu trong WarehouseItem
-- DELETE FROM WarehouseItem WHERE ItemId > 0;

-- Xóa dữ liệu trong WarehouseStock
DELETE FROM WarehouseStock WHERE StockId > 0;

-- Xóa dữ liệu trong Campaign
DELETE FROM Campaign WHERE CampaignId > 0;

-- Xóa dữ liệu trong CampaignItem
DELETE FROM CampaignItem WHERE CampaignId > 0;

-- Xóa dữ liệu trong DistributionLog
DELETE FROM DistributionLog WHERE DistributionId > 0;

-- Xóa dữ liệu trong SyncLog
DELETE FROM SyncLog WHERE SyncId > 0;

-- Xóa dữ liệu trong SyncLogItem
DELETE FROM SyncLogItem WHERE SyncLogItemId > 0;

-- Xóa dữ liệu trong Notification
DELETE FROM Notification WHERE NotificationId > 0;

-- Xóa dữ liệu trong Donation
DELETE FROM Donation WHERE DonationId > 0;

-- Xóa dữ liệu trong DonationItem
DELETE FROM DonationItem WHERE DonationItemId > 0;

-- Reset Auto Increment
ALTER TABLE Area AUTO_INCREMENT = 1;
ALTER TABLE Warehouse AUTO_INCREMENT = 1;
ALTER TABLE DisasterType AUTO_INCREMENT = 1;
ALTER TABLE DisasterLevel AUTO_INCREMENT = 1;
ALTER TABLE ItemCategory AUTO_INCREMENT = 1;
ALTER TABLE WarehouseStock AUTO_INCREMENT = 1;
ALTER TABLE Campaign AUTO_INCREMENT = 1;
ALTER TABLE CampaignItem AUTO_INCREMENT = 1;
ALTER TABLE DistributionLog AUTO_INCREMENT = 1;
ALTER TABLE SyncLog AUTO_INCREMENT = 1;
ALTER TABLE SyncLogItem AUTO_INCREMENT = 1;
ALTER TABLE Notification AUTO_INCREMENT = 1;
ALTER TABLE Donation AUTO_INCREMENT = 1;
ALTER TABLE DonationItem AUTO_INCREMENT = 1;
