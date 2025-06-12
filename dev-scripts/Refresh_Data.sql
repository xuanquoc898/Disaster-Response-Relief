-- ================================================
-- 🧹 DEV RESET SCRIPT (DELETE ALL & REFRESH)
-- Phiên bản kết hợp 2 chế độ:
--  XÓA TOÀN BỘ DỮ LIỆU HỆ THỐNG
--  CHỈ XÓA DỮ LIỆU PHÁT SINH
-- ================================================

-- Cấu hình: Đổi thành 1 để xóa toàn bộ, hoặc 0 để chỉ refresh
SET @DELETE_ALL = 0;

-- Tắt kiểm tra ràng buộc khóa ngoại
SET FOREIGN_KEY_CHECKS = 0;

-- =============================
-- 🔁 DỮ LIỆU PHÁT SINH 
-- =============================
DELETE FROM SyncLogItem WHERE SyncLogItemId > 0;
DELETE FROM SyncLog WHERE SyncId > 0;

DELETE FROM DistributionLog WHERE DistributionId > 0;
DELETE FROM DonationItem WHERE DonationItemId > 0;
DELETE FROM Donation WHERE DonationId > 0;

DELETE FROM Notification WHERE NotificationId > 0;

DELETE FROM CampaignItem WHERE CampaignId > 0;
DELETE FROM Campaign WHERE CampaignId > 0;

DELETE FROM WarehouseStock WHERE StockId > 0;

-- =============================
-- 🧾 XÓA DỮ LIỆU HỆ THỐNG (nếu @DELETE_ALL = 1)
-- =============================

-- Donor
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM Donor WHERE DonorId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- WarehouseItem
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM WarehouseItem WHERE ItemId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- Warehouse
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM Warehouse WHERE WarehouseId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- ItemCategory
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM ItemCategory WHERE CategoryId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- DisasterLevel
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM DisasterLevel WHERE LevelId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- DisasterType
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM DisasterType WHERE DisasterTypeId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- Area
SET @sql = IF(@DELETE_ALL = 1, 'DELETE FROM Area WHERE AreaId > 0;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- User (giữ lại admin chưa gán Area)
SET @sql = IF(@DELETE_ALL = 1,
  'DELETE FROM `User` WHERE (RoleId != 1 OR AreaId IS NOT NULL) AND UserId > 0;',
  '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- =============================
-- 🔄 RESET AUTO_INCREMENT
-- =============================
ALTER TABLE SyncLogItem        AUTO_INCREMENT = 1;
ALTER TABLE SyncLog            AUTO_INCREMENT = 1;
ALTER TABLE DistributionLog    AUTO_INCREMENT = 1;
ALTER TABLE DonationItem       AUTO_INCREMENT = 1;
ALTER TABLE Donation           AUTO_INCREMENT = 1;
ALTER TABLE Notification       AUTO_INCREMENT = 1;
ALTER TABLE Campaign           AUTO_INCREMENT = 1;
ALTER TABLE WarehouseStock     AUTO_INCREMENT = 1;

-- Reset các bảng cấu hình

-- Donor
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE Donor AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- WarehouseItem
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE WarehouseItem AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- Warehouse
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE Warehouse AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- ItemCategory
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE ItemCategory AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- DisasterLevel
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE DisasterLevel AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- DisasterType
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE DisasterType AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- Area
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE Area AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- User
SET @sql = IF(@DELETE_ALL = 1, 'ALTER TABLE `User` AUTO_INCREMENT = 1;', '');
PREPARE stmt FROM @sql; EXECUTE stmt; DEALLOCATE PREPARE stmt;

-- ❌ KHÔNG reset bảng Role

-- Bật lại kiểm tra khóa ngoại
SET FOREIGN_KEY_CHECKS = 1;

-- ================================================
-- ✅ HOÀN TẤT. Log:
--  - @DELETE_ALL = 1: Hệ thống đã được reset toàn bộ
--  - @DELETE_ALL = 0: Chỉ xóa dữ liệu phát sinh
-- ================================================
