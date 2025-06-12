-- =========================================
-- 🚀 INITIAL DATA - Seed dữ liệu hệ thống
-- Sử dụng cho môi trường DEV / TEST
-- =========================================

-- -----------------------------
-- 1. Khu vực (Area)
-- -----------------------------
INSERT INTO Area (AreaId, Name, District, Province) VALUES
(1, 'P. Hòa Cường Bắc', 'Q. Hải Châu', 'TP. Đà Nẵng'),
(2, 'P. Thạch Thang', 'Q. Hải Châu', 'TP. Đà Nẵng'),
(3, 'P. Hòa Khánh Nam', 'Q. Liên Chiểu', 'TP. Đà Nẵng'),
(4, 'P. Hòa Minh', 'Q. Liên Chiểu', 'TP. Đà Nẵng'),
(5, 'X. Thủy Phù', 'TX. Hương Thủy', 'TP. Huế'),
(6, 'X. Hương Toàn', 'TX. Hương Trà', 'TP. Huế'),
(7, 'P. Đông Lễ', 'TP. Đông Hà', 'T. Quảng Trị'),
(8, 'X. Triệu Long', 'H. Triệu Phong', 'T. Quảng Trị'),
(9, 'X. Cam Tuyền', 'H. Cam Lộ', 'T. Quảng Trị');

-- -----------------------------
-- 2. Kho hàng (Warehouse)
-- -----------------------------
INSERT INTO Warehouse (WarehouseId, Name, Type, AreaId) VALUES
(1, 'Kho Trung Tâm TP. Đà Nẵng', 'Central', NULL),
(2, 'Kho Hòa Cường Bắc', 'Local', 1),
(3, 'Kho Thạch Thang', 'Local', 2),
(4, 'Kho Hòa Khánh Nam', 'Local', 3),
(5, 'Kho Hòa Minh', 'Local', 4),
(6, 'Kho Thủy Phù', 'Local', 5),
(7, 'Kho Hương Toàn', 'Local', 6),
(8, 'Kho Đông Lễ', 'Local', 7),
(9, 'Kho Triệu Long', 'Local', 8),
(10, 'Kho Cam Tuyền', 'Local', 9);

-- -----------------------------
-- 3. Loại thiên tai (DisasterType)
-- -----------------------------
INSERT INTO DisasterType (DisasterTypeId, Name) VALUES
(1, 'Lũ lụt'),
(2, 'Bão'),
(3, 'Hạn hán'),
(4, 'Lũ quét'),
(5, 'Xâm nhập mặn'),
(6, 'Sạt lở đất');

-- -----------------------------
-- 4. Cấp độ thiên tai (DisasterLevel)
-- -----------------------------
INSERT INTO DisasterLevel (LevelId, DisasterTypeId, Level) VALUES
-- Lũ lụt
(1, 1, 'Ngập cục bộ (nhẹ)'),
(2, 1, 'Ngập trên diện rộng'),
(3, 1, 'Lũ lịch sử (nghiêm trọng)'),

-- Bão
(4, 2, 'Cấp 8–9 (vừa)'),
(5, 2, 'Cấp 10–12 (mạnh)'),
(6, 2, 'Cấp 13 trở lên (rất mạnh)'),

-- Hạn hán
(7, 3, 'Nắng nóng kéo dài'),
(8, 3, 'Thiếu nước sinh hoạt/nông nghiệp'),
(9, 3, 'Đất nứt nẻ diện rộng'),

-- Lũ quét
(10, 4, 'Nguy cơ xảy ra'),
(11, 4, 'Gây thiệt hại nhỏ'),
(12, 4, 'Cuốn trôi tài sản/người'),

-- Xâm nhập mặn
(13, 5, 'Mặn dưới 1‰ (ảnh hưởng nhẹ)'),
(14, 5, 'Mặn 1–4‰ (ảnh hưởng trung bình)'),
(15, 5, 'Mặn trên 4‰ (ảnh hưởng nghiêm trọng)'),

-- Sạt lở đất
(16, 6, 'Có dấu hiệu nứt/sụt'),
(17, 6, 'Đã sạt lở, thiệt hại nhỏ'),
(18, 6, 'Sạt lở nghiêm trọng, đe dọa dân cư');

-- -----------------------------
-- 5. Danh mục hàng hóa (ItemCategory)
-- -----------------------------
INSERT INTO ItemCategory (CategoryId, CategoryName) VALUES
(1, 'Lương thực'),
(2, 'Nước uống'),
(3, 'Thuốc men'),
(4, 'Vật dụng cá nhân'),
(5, 'Đồ dùng gia đình'),
(6, 'Thiết bị cứu hộ'),
(7, 'Khác');

-- -----------------------------
-- 6. Hàng hóa kho (WarehouseItem)
-- -----------------------------
INSERT INTO WarehouseItem (ItemId, Name, Unit, CategoryId) VALUES
-- Lương thực
(1, 'Gạo', 'kg', 1),
(2, 'Mì tôm', 'thùng', 1),
(3, 'Thực phẩm đóng hộp', 'hộp', 1),
(4, 'Cháo ăn liền', 'gói', 1),

-- Nước uống
(5, 'Nước tinh khiết', 'lít', 2),
(6, 'Bình nước 20L', 'bình', 2),
(7, 'Viên lọc nước', 'viên', 2),
(8, 'Bộ lọc nước cá nhân', 'bộ', 2),

-- Thuốc men
(9, 'Thuốc cảm', 'vỉ', 3),
(10, 'Dung dịch sát khuẩn', 'chai', 3),
(11, 'Bông băng gạc', 'bộ', 3),

-- Vật dụng cá nhân
(12, 'Khẩu trang y tế', 'hộp', 4),
(13, 'Áo mưa', 'cái', 4),
(14, 'Bàn chải đánh răng', 'cái', 4),
(15, 'Khăn mặt', 'cái', 4),

-- Đồ dùng gia đình
(16, 'Mền (chăn)', 'cái', 5),
(17, 'Đèn pin', 'cái', 5),
(18, 'Nồi nhôm', 'cái', 5),

-- Thiết bị cứu hộ
(19, 'Dây thừng', 'cuộn', 6),
(20, 'Đèn năng lượng mặt trời', 'cái', 6),
(21, 'Loa pin thông báo', 'cái', 6),
(22, 'Canô hơi', 'chiếc', 6),
(23, 'Áo phao', 'cái', 6),
(24, 'Áo mưa', 'cái', 6),
(25, 'Bạt che', 'tấm', 6),

-- Khác
(26, 'Tiền mặt', 'VND', 7);
