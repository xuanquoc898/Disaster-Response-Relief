-- ========================================
-- 📋 XEM DỮ LIỆU TOÀN BỘ BẢNG HỆ THỐNG
-- Sử dụng cho mục đích kiểm tra nhanh
-- ========================================

-- 🗺️ Vùng / Khu vực
SELECT * FROM Area;

-- 📢 Chiến dịch & Chi tiết chiến dịch
SELECT * FROM Campaign;
SELECT * FROM CampaignItem;

-- 🌪️ Thiên tai & cấp độ
SELECT * FROM DisasterType;
SELECT * FROM DisasterLevel;

-- 🚚 Phân phối cứu trợ
SELECT * FROM DistributionLog;

-- 🎁 Quyên góp & vật phẩm
SELECT * FROM Donation;
SELECT * FROM DonationItem;
SELECT * FROM Donor;

-- 📦 Danh mục, kho hàng & tồn kho
SELECT * FROM ItemCategory;
SELECT * FROM Warehouse;
SELECT * FROM WarehouseItem;
SELECT * FROM WarehouseStock;

-- 🔔 Thông báo
SELECT * FROM Notification;

-- 🔁 Đồng bộ dữ liệu
SELECT * FROM SyncLog;
SELECT * FROM SyncLogItem;

-- 👤 Tài khoản & phân quyền
SELECT * FROM User;
SELECT * FROM Role;
