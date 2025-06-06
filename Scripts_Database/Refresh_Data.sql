-- Xóa Notification
DELETE FROM Notification WHERE NotificationId > 0;

-- Xóa SyncLog
DELETE FROM SyncLog WHERE SyncId > 0;

-- Xóa DonationItem
DELETE FROM DonationItem WHERE DonationItemId > 0;

-- Xóa DistributionLog
DELETE FROM DistributionLog WHERE DistributionId > 0;

-- Xóa CampaignItem
DELETE FROM CampaignItem WHERE CampaignId > 0;

-- Xóa Campaign
DELETE FROM Campaign WHERE CampaignId > 0;

-- Xóa WarehouseStock
DELETE FROM WarehouseStock WHERE StockId > 0;

-- Xóa WarehouseItem
-- DELETE FROM WarehouseItem WHERE ItemId > 0;

-- Xóa Donor (Mạnh Thường Quân)
-- DELETE FROM Donor WHERE DonorId > 0;

-- Reset AUTO_INCREMENT về 1 (tùy chọn)
ALTER TABLE Notification AUTO_INCREMENT = 1;
ALTER TABLE SyncLog AUTO_INCREMENT = 1;
ALTER TABLE DonationItem AUTO_INCREMENT = 1;
ALTER TABLE DistributionLog AUTO_INCREMENT = 1;
ALTER TABLE CampaignItem AUTO_INCREMENT = 1;
ALTER TABLE Campaign AUTO_INCREMENT = 1;
ALTER TABLE WarehouseStock AUTO_INCREMENT = 1;

-- ALTER TABLE WarehouseItem AUTO_INCREMENT = 1;
-- ALTER TABLE Donor AUTO_INCREMENT = 1;
