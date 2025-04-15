USE Disaster_Relief;

-- Role
INSERT INTO Role (RoleName) VALUES ('Admin'), ('Staff');

-- Area
INSERT INTO Area (Name, District, Province) VALUES
('Phường Hòa Khánh Bắc', 'Quận Liên Chiểu', 'TP.Đà Nẵng'),
('Phường Hòa Khánh Nam', 'Quận Liên Chiểu', 'TP.Đà Nẵng'),
('Phường Hòa Cường Nam', 'Quận Hải Châu', 'TP.Đà Nẵng');

-- DisasterType
INSERT INTO DisasterType (Name, Description) VALUES
('Lũ lụt', 'Mưa lớn gây ngập lụt trên diện rộng'),
('Động đất', 'Rung chấn gây thiệt hại nhà cửa'),
('Hạn hán', 'Thời gian dài không có mưa');

-- ItemCategory
INSERT INTO ItemCategory (CategoryName) VALUES
('Lương thực'), ('Thuốc men'), ('Vật dụng cá nhân');

-- Donor
INSERT INTO Donor (FullName, CCCD, Phone, Email) VALUES
('Nguyễn Văn A', '123456789012', '0912345678', 'a@gmail.com'),
('Trần Thị B', '234567890123', '0987654321', 'b@gmail..com');

-- Warehouse
INSERT INTO Warehouse (Type, AreaId, Name) VALUES
('Central', NULL, 'Kho TP.Đà Nẵng'),
('Local', 1, 'Kho HKB Q.Liên Chiểu'),
('Local', 2, 'Kho HKN Q.Liên Chiểu'),
('Local', 3, 'Kho HCB Q.Hải Châu');

-- DisasterLevel
INSERT INTO DisasterLevel (DisasterTypeId, Level) VALUES
(1, 'Nghiêm trọng'),
(2, 'Trung bình'),
(3, 'Cảnh báo'),
(3, 'Nhẹ');

-- WarehouseItem
INSERT INTO WarehouseItem (Name, Unit, CategoryId) VALUES
('Gạo', 'kg', 1),
('Nước suối', 'chai', 1),
('Khẩu trang', 'hộp', 3),
('Thuốc cảm', 'vỉ', 2);

-- User
INSERT INTO `User` (Username, Password, RoleId, AreaId, WarehouseId) VALUES
('admin01', 'hashedpassword1', 1, NULL, 1),
('staff01', 'hashedpassword2', 2, 1, 2),
('staff02', 'hashedpassword3', 2, 2, 3);



-- Donation
INSERT INTO Donation (DonorId, AreaId) VALUES
(1, 1),
(2, 2);

-- DonationItem
INSERT INTO DonationItem (DonationId, ItemId, Quantity, Unit) VALUES
(1, 1, 100, 'kg'),
(1, 2, 50, 'chai'),
(2, 3, 200, 'hộp');

-- SyncLog
INSERT INTO SyncLog (WarehouseId, Status) VALUES
(2, 'Đã đồng bộ'),
(3, 'Chưa đồng bộ');

-- SyncLogItem
INSERT INTO SyncLogItem (SyncId, ItemId, Quantity, Unit) VALUES
(1, 1, 50, 'kg'),
(1, 2, 20, 'chai'),
(2, 3, 150, 'hộp');

-- Campaign
INSERT INTO Campaign (AreaId, DisasterLevelId, Status, Note) VALUES
(1, 1, 'Planned', 'Cứu trợ đợt 1 tại Quận Liên Chiểu'),
(2, 2, 'Ongoing', 'Hỗ trợ dân cư vùng ngập lụt');

-- CampaignItem
INSERT INTO CampaignItem (CampaignId, ItemId, QuantityRequested, QuantityApproved) VALUES
(1, 1, 200, 100),
(1, 2, 100, 50),
(2, 3, 300, 200);

-- DistributionLog
INSERT INTO DistributionLog (CampaignId, ItemId, AreaId, Quantity) VALUES
(1, 1, 1, 100),
(1, 2, 1, 50),
(2, 3, 2, 200);

-- WarehouseStock
INSERT INTO WarehouseStock (WarehouseId, ItemId, Quantity) VALUES
(2, 1, 500),
(2, 2, 300),
(3, 3, 400),
(3, 4, 150);
