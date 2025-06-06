-- Thêm nhiều Area thực tế ở TP Đà Nẵng
INSERT INTO Area (Name, District, Province) VALUES 
('Phường Thạch Thang', 'Quận Hải Châu', 'Thành phố Đà Nẵng'),
('Phường Hải Châu 1', 'Quận Hải Châu', 'Thành phố Đà Nẵng'),
('Phường Hải Châu 2', 'Quận Hải Châu', 'Thành phố Đà Nẵng'),
('Phường Thanh Bình', 'Quận Hải Châu', 'Thành phố Đà Nẵng'),
('Phường Hòa Thuận Đông', 'Quận Hải Châu', 'Thành phố Đà Nẵng'),
('Phường Tân Chính', 'Quận Thanh Khê', 'Thành phố Đà Nẵng'),
('Phường Thạc Gián', 'Quận Thanh Khê', 'Thành phố Đà Nẵng'),
('Phường Chính Gián', 'Quận Thanh Khê', 'Thành phố Đà Nẵng'),
('Phường An Hải Bắc', 'Quận Sơn Trà', 'Thành phố Đà Nẵng'),
('Phường An Hải Đông', 'Quận Sơn Trà', 'Thành phố Đà Nẵng'),
('Phường Mỹ An', 'Quận Ngũ Hành Sơn', 'Thành phố Đà Nẵng'),
('Phường Khuê Mỹ', 'Quận Ngũ Hành Sơn', 'Thành phố Đà Nẵng');

-- Thêm Warehouse thực tế
-- WarehouseId=1: kho trung tâm admin (không cần gắn Area)

INSERT INTO Warehouse (Name, AreaId, Type) VALUES
('Kho Trung Tâm', NULL, 'Central'), -- Admin kho tổng

('Kho Hải Châu 1', 1, 'Local'),  -- Phường Thạch Thang
('Kho Hải Châu 2', 2, 'Local'),  -- Phường Hải Châu 1
('Kho Hải Châu 3', 3, 'Local'),  -- Phường Hải Châu 2
('Kho Thanh Khê 1', 6, 'Local'), -- Phường Tân Chính
('Kho Thanh Khê 2', 7, 'Local'), -- Phường Thạc Gián
('Kho Sơn Trà 1', 9, 'Local'),   -- Phường An Hải Bắc
('Kho Sơn Trà 2', 10, 'Local'),  -- Phường An Hải Đông
('Kho Ngũ Hành Sơn 1', 11, 'Local'), -- Phường Mỹ An
('Kho Ngũ Hành Sơn 2', 12, 'Local'); -- Phường Khuê Mỹ

-- Thêm dữ liệu vào DisasterType
INSERT INTO DisasterType (Name, Description) VALUES 
('Lũ lụt', 'Thiên tai ngập lụt do mưa lớn'),
('Động đất', 'Thiên tai rung chuyển mặt đất'),
('Hạn hán', 'Thiếu nước kéo dài');

-- Thêm dữ liệu vào DisasterLevel
INSERT INTO DisasterLevel (Level, DisasterTypeId) VALUES 
('Nhẹ', 1),
('Trung bình', 1),
('Nặng', 1),
('Nhẹ', 2),
('Trung bình', 2),
('Nặng', 2),
('Nhẹ', 3),
('Trung bình', 3),
('Nặng', 3);

-- Thêm dữ liệu vào ItemCategory
INSERT INTO ItemCategory (CategoryName) VALUES 
('Thực phẩm'),
('Quần áo'),
('Thiết bị y tế'),
('Đồ dùng vệ sinh');
SELECT * FROM ItemCategory WHERE CategoryId = 5;
UPDATE ItemCategory
SET CategoryName = 'Khác'
WHERE CategoryId = 5;

SELECT * FROM WarehouseItem WHERE CategoryId = 5;

INSERT INTO ItemCategory (CategoryName) VALUES 
('Tiền mặt');

INSERT INTO WarehouseItem (Name, Unit, CategoryId) VALUES
('Tiền mặt', 'VNĐ', 5);         


-- Thêm dữ liệu vào WarehouseItem
INSERT INTO WarehouseItem (Name, Unit, CategoryId) VALUES
('Gạo', 'Kg', 1),         -- Thuộc Thực phẩm
('Mì gói', 'Thùng', 1),   -- Thuộc Thực phẩm
('Nước sạch', 'Bình 20L', 1), -- Thực phẩm

('Áo mưa', 'Cái', 2),     -- Thuộc Quần áo
('Áo phao', 'Cái', 2),    -- Thuộc Quần áo

('Băng gạc', 'Hộp', 3),   -- Thuộc Thiết bị y tế
('Thuốc sát trùng', 'Chai', 3), -- Thiết bị y tế

('Xà phòng', 'Bánh', 4),  -- Thuộc Đồ dùng vệ sinh
('Khẩu trang', 'Hộp', 4); -- Đồ dùng vệ sinh

