-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: disaster_relief
-- ------------------------------------------------------
-- Server version	8.0.42

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `area`
--

DROP TABLE IF EXISTS `area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `area` (
  `AreaId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `District` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Province` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`AreaId`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `area`
--

LOCK TABLES `area` WRITE;
/*!40000 ALTER TABLE `area` DISABLE KEYS */;
INSERT INTO `area` VALUES (1,'P. Hòa Cường Bắc','Q. Hải Châu','TP. Đà Nẵng'),(2,'P. Thạch Thang','Q. Hải Châu','TP. Đà Nẵng'),(3,'P. Hòa Khánh Nam','Q. Liên Chiểu','TP. Đà Nẵng'),(4,'P. Hòa Minh','Q. Liên Chiểu','TP. Đà Nẵng'),(5,'X. Thủy Phù','TX. Hương Thủy','TP. Huế'),(6,'X. Hương Toàn','TX. Hương Trà','TP. Huế'),(7,'P. Đông Lễ','TP. Đông Hà','T. Quảng Trị'),(8,'X. Triệu Long','H. Triệu Phong','T. Quảng Trị'),(9,'X. Cam Tuyền','H. Cam Lộ','T. Quảng Trị');
/*!40000 ALTER TABLE `area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaign`
--

DROP TABLE IF EXISTS `campaign`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaign` (
  `CampaignId` int NOT NULL AUTO_INCREMENT,
  `AreaId` int NOT NULL,
  `DisasterLevelId` int DEFAULT NULL,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CreatedDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `Title` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `ApprovedAt` datetime DEFAULT NULL,
  `RejectedAt` datetime DEFAULT NULL,
  `CompletedAt` datetime DEFAULT NULL,
  `Note` varchar(300) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`CampaignId`),
  KEY `AreaId` (`AreaId`),
  KEY `DisasterLevelId` (`DisasterLevelId`),
  CONSTRAINT `Campaign_ibfk_1` FOREIGN KEY (`AreaId`) REFERENCES `area` (`AreaId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Campaign_ibfk_2` FOREIGN KEY (`DisasterLevelId`) REFERENCES `disasterlevel` (`LevelId`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Campaign_chk_1` CHECK ((`Status` in (_utf8mb4'Planned',_utf8mb4'Approved',_utf8mb4'Rejected',_utf8mb4'Completed')))
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaign`
--

LOCK TABLES `campaign` WRITE;
/*!40000 ALTER TABLE `campaign` DISABLE KEYS */;
INSERT INTO `campaign` VALUES (1,5,1,'Completed','2025-04-08 22:40:08','Staff05','2025-04-13 22:42:10',NULL,'2025-04-21 22:52:38',NULL),(2,6,4,'Rejected','2025-04-08 22:41:29','Staff06',NULL,'2025-04-13 22:42:35',NULL,'Không đủ hàng hóa, vui lòng chờ đợi thêm'),(3,9,12,'Completed','2025-04-19 22:44:30','Staff09 khẩn cấp','2025-04-23 22:51:53',NULL,'2025-04-25 22:54:27',NULL),(4,8,14,'Completed','2025-04-22 22:45:59','Staff08 nguy cơ','2025-04-23 22:52:02',NULL,'2025-04-21 22:53:54',NULL),(5,7,17,'Completed','2025-04-21 22:53:38','Staff07','2025-04-29 23:04:01',NULL,'2025-04-29 23:04:47',NULL),(6,6,18,'Completed','2025-04-25 22:59:56','Staff06 nguy cấp','2025-04-28 23:03:22',NULL,'2025-04-29 23:04:25',NULL),(7,7,14,'Completed','2025-05-07 23:18:41','Staff07 SOS','2025-05-08 23:19:53',NULL,'2025-06-07 00:14:44',NULL),(8,8,2,'Rejected','2025-05-10 23:19:30','SOS Staff8',NULL,'2025-05-14 23:23:07',NULL,'Không đủ áo phao đâu nha'),(9,5,12,'Completed','2025-05-18 23:24:44','Nghiêm trọng Staff5','2025-05-18 23:25:04',NULL,'2025-05-19 23:25:24',NULL),(10,9,5,'Approved','2025-05-25 23:27:11','Bão mạnh','2025-05-25 23:27:28',NULL,NULL,NULL),(11,9,4,'Completed','2025-06-01 00:06:58','Staff9 Bão nhỏ','2025-06-02 00:07:37',NULL,'2025-06-02 00:08:28',NULL),(12,6,11,'Completed','2025-06-05 00:12:01','Lũ nhỏ','2025-06-06 00:13:26',NULL,'2025-06-07 00:15:10',NULL),(13,7,8,'Rejected','2025-06-05 00:12:52','Thiếu nước',NULL,'2025-06-06 00:14:02',NULL,'Không đủ lượng nước yêu cầu!'),(14,8,7,'Planned','2025-06-07 00:16:35','Cần thêm hỗ trợ',NULL,NULL,NULL,NULL),(15,9,14,'Completed','2025-06-08 21:41:07','MAI THI LO RƠI HẾT MỒ HÔI','2025-06-09 21:45:25',NULL,'2025-06-09 21:48:10',NULL),(16,1,12,'Planned','2025-06-10 09:17:07','LU QUET ',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `campaign` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `campaignitem`
--

DROP TABLE IF EXISTS `campaignitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `campaignitem` (
  `CampaignId` int NOT NULL,
  `ItemId` int NOT NULL,
  `QuantityRequested` int DEFAULT NULL,
  PRIMARY KEY (`CampaignId`,`ItemId`),
  KEY `ItemId` (`ItemId`),
  CONSTRAINT `CampaignItem_ibfk_1` FOREIGN KEY (`CampaignId`) REFERENCES `campaign` (`CampaignId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `CampaignItem_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `warehouseitem` (`ItemId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `campaignitem`
--

LOCK TABLES `campaignitem` WRITE;
/*!40000 ALTER TABLE `campaignitem` DISABLE KEYS */;
INSERT INTO `campaignitem` VALUES (1,1,30),(1,2,10),(1,16,10),(1,17,10),(1,19,10),(1,22,2),(2,6,20),(2,9,100),(2,11,50),(2,26,2000000),(3,1,500),(3,3,500),(3,4,220),(3,5,30),(3,22,10),(4,5,30),(4,7,300),(4,12,100),(4,26,2000000),(5,19,50),(5,21,40),(6,6,10),(6,11,10),(6,19,50),(6,25,10),(7,1,500),(7,2,300),(7,19,10),(8,22,4),(8,23,50),(9,5,20),(9,6,10),(9,23,100),(10,2,200),(10,3,200),(10,12,50),(10,19,100),(11,1,500),(11,2,100),(11,17,100),(11,21,50),(12,1,200),(12,19,10),(13,5,200),(13,6,30),(14,6,50),(14,19,10),(15,8,1),(16,19,10),(16,23,50);
/*!40000 ALTER TABLE `campaignitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disasterlevel`
--

DROP TABLE IF EXISTS `disasterlevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disasterlevel` (
  `LevelId` int NOT NULL AUTO_INCREMENT,
  `DisasterTypeId` int NOT NULL,
  `Level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`LevelId`),
  KEY `DisasterTypeId` (`DisasterTypeId`),
  CONSTRAINT `DisasterLevel_ibfk_1` FOREIGN KEY (`DisasterTypeId`) REFERENCES `disastertype` (`DisasterTypeId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disasterlevel`
--

LOCK TABLES `disasterlevel` WRITE;
/*!40000 ALTER TABLE `disasterlevel` DISABLE KEYS */;
INSERT INTO `disasterlevel` VALUES (1,1,'Ngập cục bộ (nhẹ)'),(2,1,'Ngập trên diện rộng'),(3,1,'Lũ lịch sử (nghiêm trọng)'),(4,2,'Cấp 8–9 (vừa)'),(5,2,'Cấp 10–12 (mạnh)'),(6,2,'Cấp 13 trở lên (rất mạnh)'),(7,3,'Nắng nóng kéo dài'),(8,3,'Thiếu nước sinh hoạt/nông nghiệp'),(9,3,'Đất nứt nẻ diện rộng'),(10,4,'Nguy cơ xảy ra'),(11,4,'Gây thiệt hại nhỏ'),(12,4,'Cuốn trôi tài sản/người'),(13,5,'Mặn dưới 1‰ (ảnh hưởng nhẹ)'),(14,5,'Mặn 1–4‰ (ảnh hưởng trung bình)'),(15,5,'Mặn trên 4‰ (ảnh hưởng nghiêm trọng)'),(16,6,'Có dấu hiệu nứt/sụt'),(17,6,'Đã sạt lở, thiệt hại nhỏ'),(18,6,'Sạt lở nghiêm trọng, đe dọa dân cư');
/*!40000 ALTER TABLE `disasterlevel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `disastertype`
--

DROP TABLE IF EXISTS `disastertype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `disastertype` (
  `DisasterTypeId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`DisasterTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `disastertype`
--

LOCK TABLES `disastertype` WRITE;
/*!40000 ALTER TABLE `disastertype` DISABLE KEYS */;
INSERT INTO `disastertype` VALUES (1,'Lũ lụt'),(2,'Bão'),(3,'Hạn hán'),(4,'Lũ quét'),(5,'Xâm nhập mặn'),(6,'Sạt lở đất');
/*!40000 ALTER TABLE `disastertype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `distributionlog`
--

DROP TABLE IF EXISTS `distributionlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `distributionlog` (
  `DistributionId` int NOT NULL AUTO_INCREMENT,
  `CampaignId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `DistributionDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `AreaId` int DEFAULT NULL,
  PRIMARY KEY (`DistributionId`),
  KEY `CampaignId` (`CampaignId`),
  KEY `ItemId` (`ItemId`),
  KEY `DistributionLog_ibfk_3` (`AreaId`),
  CONSTRAINT `DistributionLog_ibfk_1` FOREIGN KEY (`CampaignId`) REFERENCES `campaign` (`CampaignId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `DistributionLog_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `warehouseitem` (`ItemId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `distributionlog`
--

LOCK TABLES `distributionlog` WRITE;
/*!40000 ALTER TABLE `distributionlog` DISABLE KEYS */;
INSERT INTO `distributionlog` VALUES (1,1,1,30,'2025-04-13 22:42:10',5),(2,1,2,10,'2025-04-13 22:42:10',5),(3,1,16,10,'2025-04-13 22:42:10',5),(4,1,17,10,'2025-04-13 22:42:10',5),(5,1,19,10,'2025-04-13 22:42:10',5),(6,1,22,2,'2025-04-13 22:42:10',5),(7,3,1,500,'2025-04-23 22:51:52',9),(8,3,3,500,'2025-04-23 22:51:52',9),(9,3,4,220,'2025-04-23 22:51:52',9),(10,3,5,30,'2025-04-23 22:51:52',9),(11,3,22,10,'2025-04-23 22:51:52',9),(12,4,5,30,'2025-04-23 22:52:01',8),(13,4,7,300,'2025-04-23 22:52:01',8),(14,4,12,100,'2025-04-23 22:52:01',8),(15,4,26,2000000,'2025-04-23 22:52:01',8),(16,6,6,10,'2025-04-28 23:03:22',6),(17,6,11,10,'2025-04-28 23:03:22',6),(18,6,19,50,'2025-04-28 23:03:22',6),(19,6,25,10,'2025-04-28 23:03:22',6),(20,5,19,50,'2025-04-29 23:04:00',7),(21,5,21,40,'2025-04-29 23:04:00',7),(22,7,1,500,'2025-05-08 23:19:52',7),(23,7,2,300,'2025-05-08 23:19:52',7),(24,7,19,10,'2025-05-08 23:19:52',7),(25,9,5,20,'2025-05-18 23:25:03',5),(26,9,6,10,'2025-05-18 23:25:03',5),(27,9,23,100,'2025-05-18 23:25:03',5),(28,10,2,200,'2025-05-25 23:27:28',9),(29,10,3,200,'2025-05-25 23:27:28',9),(30,10,12,50,'2025-05-25 23:27:28',9),(31,10,19,100,'2025-05-25 23:27:28',9),(32,11,1,500,'2025-06-02 00:07:37',9),(33,11,2,100,'2025-06-02 00:07:37',9),(34,11,17,100,'2025-06-02 00:07:37',9),(35,11,21,50,'2025-06-02 00:07:37',9),(36,12,1,200,'2025-06-06 00:13:26',6),(37,12,19,10,'2025-06-06 00:13:26',6),(38,15,8,1,'2025-06-09 21:45:24',9);
/*!40000 ALTER TABLE `distributionlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donation`
--

DROP TABLE IF EXISTS `donation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donation` (
  `DonationId` int NOT NULL AUTO_INCREMENT,
  `DonorId` int NOT NULL,
  `AreaId` int NOT NULL,
  `Date` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`DonationId`),
  KEY `DonorId` (`DonorId`),
  KEY `AreaId` (`AreaId`),
  CONSTRAINT `Donation_ibfk_1` FOREIGN KEY (`DonorId`) REFERENCES `donor` (`DonorId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Donation_ibfk_2` FOREIGN KEY (`AreaId`) REFERENCES `area` (`AreaId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=54 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donation`
--

LOCK TABLES `donation` WRITE;
/*!40000 ALTER TABLE `donation` DISABLE KEYS */;
INSERT INTO `donation` VALUES (1,3,1,'2025-04-01 22:07:09'),(2,12,1,'2025-04-01 22:07:56'),(3,6,1,'2025-04-01 22:11:19'),(4,1,1,'2025-04-01 22:12:26'),(5,4,1,'2025-04-01 22:12:53'),(6,15,1,'2025-04-01 22:13:11'),(7,7,1,'2025-04-03 22:15:02'),(8,10,1,'2025-04-03 22:15:25'),(9,6,1,'2025-04-03 22:15:41'),(10,6,1,'2025-04-03 22:15:53'),(11,4,1,'2025-04-03 22:16:46'),(12,14,1,'2025-04-03 22:17:14'),(13,4,1,'2025-04-06 22:18:35'),(14,9,1,'2025-04-06 22:19:40'),(15,8,1,'2025-04-06 22:21:10'),(16,3,1,'2025-04-06 22:21:21'),(17,7,1,'2025-04-06 22:21:30'),(18,11,1,'2025-04-06 22:21:57'),(19,11,1,'2025-04-06 22:22:35'),(20,14,1,'2025-04-06 22:22:48'),(21,12,1,'2025-04-13 22:23:35'),(22,15,1,'2025-04-13 22:23:45'),(23,15,1,'2025-04-13 22:23:52'),(24,6,1,'2025-04-13 22:24:04'),(25,15,1,'2025-04-13 22:24:17'),(26,13,1,'2025-04-13 22:24:30'),(27,13,1,'2025-04-17 22:25:42'),(28,13,1,'2025-04-17 22:25:55'),(29,3,1,'2025-04-17 22:26:26'),(30,15,1,'2025-04-19 22:28:25'),(31,5,1,'2025-04-23 22:30:15'),(32,10,1,'2025-04-23 22:30:34'),(33,15,1,'2025-04-10 22:32:29'),(34,8,1,'2025-04-10 22:32:53'),(35,4,1,'2025-04-10 22:33:09'),(36,9,1,'2025-04-10 22:33:46'),(37,9,1,'2025-04-10 22:34:01'),(38,8,1,'2025-04-22 22:46:50'),(39,3,1,'2025-04-16 22:49:38'),(40,10,1,'2025-04-16 22:50:07'),(41,9,1,'2025-04-27 23:02:14'),(42,10,1,'2025-05-03 23:15:01'),(43,2,1,'2025-05-03 23:15:16'),(44,9,1,'2025-05-03 23:15:34'),(45,11,1,'2025-05-04 23:16:34'),(46,5,1,'2025-05-04 23:17:11'),(47,6,1,'2025-05-04 23:17:26'),(48,14,1,'2025-05-12 23:20:44'),(49,10,1,'2025-05-12 23:21:13'),(50,9,1,'2025-05-18 23:23:52'),(51,2,1,'2025-06-02 00:09:12'),(52,8,1,'2025-06-03 00:10:46'),(53,4,1,'2025-06-10 09:12:16');
/*!40000 ALTER TABLE `donation` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donationitem`
--

DROP TABLE IF EXISTS `donationitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donationitem` (
  `DonationItemId` int NOT NULL AUTO_INCREMENT,
  `DonationId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `Unit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`DonationItemId`),
  KEY `DonationId` (`DonationId`),
  KEY `ItemId` (`ItemId`),
  CONSTRAINT `DonationItem_ibfk_1` FOREIGN KEY (`DonationId`) REFERENCES `donation` (`DonationId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `DonationItem_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `warehouseitem` (`ItemId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=116 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donationitem`
--

LOCK TABLES `donationitem` WRITE;
/*!40000 ALTER TABLE `donationitem` DISABLE KEYS */;
INSERT INTO `donationitem` VALUES (1,1,1,100,'kg'),(2,1,2,50,'thùng'),(3,1,3,100,'hộp'),(4,1,4,50,'gói'),(5,1,5,50,'lít'),(6,1,6,5,'bình'),(7,1,7,100,'viên'),(8,1,8,2,'bộ'),(9,1,10,10,'chai'),(10,2,16,10,'cái'),(11,2,17,10,'cái'),(12,2,18,20,'cái'),(13,2,26,500000,'VND'),(14,2,11,50,'bộ'),(15,3,12,50,'hộp'),(16,3,13,100,'cái'),(17,3,15,10,'cái'),(18,3,14,7,'cái'),(19,4,1,50,'kg'),(20,4,2,12,'thùng'),(21,4,3,10,'hộp'),(22,4,4,50,'gói'),(23,4,1,40,'kg'),(24,5,20,100,'cái'),(25,5,21,100,'cái'),(26,5,12,33,'hộp'),(27,6,26,1000000,'VND'),(28,7,18,10,'cái'),(29,7,17,100,'cái'),(30,7,10,100,'chai'),(31,7,11,100,'bộ'),(32,7,9,100,'vỉ'),(33,7,4,50,'gói'),(34,8,1,300,'kg'),(35,8,3,10,'hộp'),(36,8,26,3000000,'VND'),(37,9,26,250000,'VND'),(38,10,22,2,'chiếc'),(39,10,25,2,'tấm'),(40,11,17,100,'cái'),(41,11,18,2,'cái'),(42,12,12,30,'hộp'),(43,12,26,750000,'VND'),(44,13,8,20,'bộ'),(45,13,6,5,'bình'),(46,13,26,1000000,'VND'),(47,13,15,50,'cái'),(48,13,12,100,'hộp'),(49,14,26,2000000,'VND'),(50,14,12,100,'hộp'),(51,15,26,5000000,'VND'),(52,16,3,50,'hộp'),(53,17,19,5,'cuộn'),(54,18,9,100,'vỉ'),(55,18,10,100,'chai'),(56,18,11,200,'bộ'),(57,19,26,100000,'VND'),(58,20,26,50000,'VND'),(59,21,4,22,'gói'),(60,21,26,700000,'VND'),(61,22,12,222,'hộp'),(62,23,16,22,'cái'),(63,24,13,44,'cái'),(64,25,17,100,'cái'),(65,26,22,7,'chiếc'),(66,27,17,100,'cái'),(67,27,16,20,'cái'),(68,27,17,22,'cái'),(69,28,26,1000000,'VND'),(70,29,22,10,'chiếc'),(71,30,13,100,'cái'),(72,30,14,100,'cái'),(73,30,26,3000000,'VND'),(74,31,26,100000,'VND'),(75,32,1,1000,'kg'),(76,33,8,50,'bộ'),(77,33,5,100,'lít'),(78,33,26,5000000,'VND'),(79,34,19,10,'cuộn'),(80,34,25,10,'tấm'),(81,35,26,1000000,'VND'),(82,36,26,400000,'VND'),(83,37,14,50,'cái'),(84,37,1,30,'kg'),(85,38,26,200000,'VND'),(86,38,1,500,'kg'),(87,38,2,100,'thùng'),(88,39,7,1000,'viên'),(89,39,5,50,'lít'),(90,40,3,500,'hộp'),(91,40,4,500,'gói'),(92,40,2,500,'thùng'),(93,41,19,100,'cuộn'),(94,41,21,100,'cái'),(95,41,6,100,'bình'),(96,42,26,4000000,'VND'),(97,42,12,500,'hộp'),(98,43,18,100,'cái'),(99,44,16,100,'cái'),(100,45,14,22,'cái'),(101,45,26,500000,'VND'),(102,46,19,500,'cuộn'),(103,46,21,40,'cái'),(104,47,25,50,'tấm'),(105,48,17,50,'cái'),(106,49,3,500,'hộp'),(107,49,6,200,'bình'),(108,50,23,500,'cái'),(109,51,1,700,'kg'),(110,51,21,40,'cái'),(111,52,3,100,'hộp'),(112,52,1,100,'kg'),(113,52,10,100,'chai'),(114,52,6,40,'bình'),(115,53,6,2,'bình');
/*!40000 ALTER TABLE `donationitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `donor`
--

DROP TABLE IF EXISTS `donor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `donor` (
  `DonorId` int NOT NULL AUTO_INCREMENT,
  `FullName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `CCCD` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Phone` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`DonorId`),
  UNIQUE KEY `CCCD` (`CCCD`),
  UNIQUE KEY `Phone` (`Phone`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `donor`
--

LOCK TABLES `donor` WRITE;
/*!40000 ALTER TABLE `donor` DISABLE KEYS */;
INSERT INTO `donor` VALUES (1,'Trần Tuấn Hưng','048208667352','0985436274','tuanhung@gmail.com'),(2,'Phạm Quang Mạnh','037188564276','0987543274','manhcute@gmail.com'),(3,'Phạm Thị Hà','048101654872','0986789456','ha12@gmail.com'),(4,'Trần Minh Anh','046205678432','0378654263','minhanh@gmail.com'),(5,'Chu Minh Quân','048205783451','0367054321','mquan232@gmail.com'),(6,'Phạm Thị Hồng Vân','048110675423','0378654371','usagi@gmail.com'),(7,'Trần Đình Phương Thảo','048198765232','0987652349','pthao111@gmail.com'),(8,'Mai Xuân Quốc','046205783541','0368975433','tometroi898@gmail.com'),(9,'Nguyễn Hoàng Hà','048205008237','0367042327','hhacute@gmail.com'),(10,'Lưu Lan Nhi','048105673421','0398819654','nhiluuw0911@gmail.com'),(11,'Hồ Công Tuấn Anh','048205661876','0367854871','hcta@gmail.com'),(12,'Nguyễn Tường Vy','046107151223','0356765123','Vynhat11@gmail.com'),(13,'Phạm Văn Khánh','048210472145','0398876546','KhanhNguyen111@gmail.com'),(14,'Nguyễn Phước Thiên','037099656432','0367049998','thiennhan2020@gmail.com'),(15,'Lê Nhật Khang','048207658762','0378789876','khang@gmail.com');
/*!40000 ALTER TABLE `donor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemcategory`
--

DROP TABLE IF EXISTS `itemcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemcategory` (
  `CategoryId` int NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`CategoryId`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemcategory`
--

LOCK TABLES `itemcategory` WRITE;
/*!40000 ALTER TABLE `itemcategory` DISABLE KEYS */;
INSERT INTO `itemcategory` VALUES (1,'Lương thực'),(2,'Nước uống'),(3,'Thuốc men'),(4,'Vật dụng cá nhân'),(5,'Đồ dùng gia đình'),(6,'Thiết bị cứu hộ'),(7,'Khác');
/*!40000 ALTER TABLE `itemcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notification` (
  `NotificationId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `CampaignId` int DEFAULT NULL,
  `Content` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `IsRead` tinyint(1) DEFAULT '0',
  `CreatedAt` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`NotificationId`),
  KEY `StaffId` (`UserId`),
  KEY `CampaignId` (`CampaignId`),
  CONSTRAINT `Notification_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `Notification_ibfk_2` FOREIGN KEY (`CampaignId`) REFERENCES `campaign` (`CampaignId`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notification`
--

LOCK TABLES `notification` WRITE;
/*!40000 ALTER TABLE `notification` DISABLE KEYS */;
INSERT INTO `notification` VALUES (1,1,1,'● Chiến dịch \"Staff05\" vừa gửi yêu cầu duyệt.',0,'2025-04-08 22:40:08'),(2,1,2,'● Chiến dịch \"Staff06\" vừa gửi yêu cầu duyệt.',0,'2025-04-08 22:41:29'),(3,10,1,'Chiến dịch \"Staff05\" đã được duyệt.',1,'2025-04-13 22:42:10'),(4,2,2,'Chiến dịch \"Staff06\" đã bị từ chối.',1,'2025-04-13 22:42:35'),(5,1,3,'● Chiến dịch \"Staff09 khẩn cấp\" vừa gửi yêu cầu duyệt.',0,'2025-04-19 22:44:30'),(6,1,4,'● Chiến dịch \"Staff08 nguy cơ\" vừa gửi yêu cầu duyệt.',0,'2025-04-22 22:45:59'),(7,5,3,'Chiến dịch \"Staff09 khẩn cấp\" đã được duyệt.',1,'2025-04-23 22:51:53'),(8,4,4,'Chiến dịch \"Staff08 nguy cơ\" đã được duyệt.',1,'2025-04-23 22:52:02'),(9,1,5,'● Chiến dịch \"Staff07\" vừa gửi yêu cầu duyệt.',0,'2025-04-21 22:53:38'),(10,1,6,'● Chiến dịch \"Staff06 nguy cấp\" vừa gửi yêu cầu duyệt.',0,'2025-04-25 22:59:56'),(11,2,6,'Chiến dịch \"Staff06 nguy cấp\" đã được duyệt.',1,'2025-04-28 23:03:23'),(12,3,5,'Chiến dịch \"Staff07\" đã được duyệt.',1,'2025-04-29 23:04:01'),(13,1,7,'● Chiến dịch \"Staff07 SOS\" vừa gửi yêu cầu duyệt.',0,'2025-05-07 23:18:42'),(14,1,8,'● Chiến dịch \"SOS Staff8\" vừa gửi yêu cầu duyệt.',1,'2025-05-10 23:19:30'),(15,3,7,'Chiến dịch \"Staff07 SOS\" đã được duyệt.',1,'2025-05-08 23:19:53'),(16,4,8,'Chiến dịch \"SOS Staff8\" đã bị từ chối.',0,'2025-05-14 23:23:07'),(17,1,9,'● Chiến dịch \"Nghiêm trọng Staff5\" vừa gửi yêu cầu duyệt.',1,'2025-05-18 23:24:45'),(18,10,9,'Chiến dịch \"Nghiêm trọng Staff5\" đã được duyệt.',1,'2025-05-18 23:25:04'),(19,1,10,'● Chiến dịch \"Bão mạnh\" vừa gửi yêu cầu duyệt.',0,'2025-05-25 23:27:11'),(20,5,10,'Chiến dịch \"Bão mạnh\" đã được duyệt.',0,'2025-05-25 23:27:28'),(21,1,11,'● Chiến dịch \"Staff9 Bão nhỏ\" vừa gửi yêu cầu duyệt.',0,'2025-06-01 00:06:58'),(22,5,11,'Chiến dịch \"Staff9 Bão nhỏ\" đã được duyệt.',1,'2025-06-02 00:07:37'),(23,1,12,'● Chiến dịch \"Lũ nhỏ\" vừa gửi yêu cầu duyệt.',0,'2025-06-05 00:12:01'),(24,1,13,'● Chiến dịch \"Thiếu nước\" vừa gửi yêu cầu duyệt.',1,'2025-06-05 00:12:52'),(25,2,12,'Chiến dịch \"Lũ nhỏ\" đã được duyệt.',1,'2025-06-06 00:13:26'),(26,3,13,'Chiến dịch \"Thiếu nước\" đã bị từ chối.',1,'2025-06-06 00:14:02'),(27,1,14,'● Chiến dịch \"Cần thêm hỗ trợ\" vừa gửi yêu cầu duyệt.',1,'2025-06-07 00:16:35'),(28,1,15,'● Chiến dịch \"MAI THI LO RƠI HẾT MỒ HÔI\" vừa gửi yêu cầu duyệt.',1,'2025-06-08 21:41:09'),(29,5,15,'Chiến dịch \"MAI THI LO RƠI HẾT MỒ HÔI\" đã được duyệt.',1,'2025-06-09 21:45:25'),(30,1,16,'● Chiến dịch \"LU QUET \" vừa gửi yêu cầu duyệt.',1,'2025-06-10 09:17:08');
/*!40000 ALTER TABLE `notification` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role` (
  `RoleId` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`RoleId`),
  UNIQUE KEY `RoleName` (`RoleName`),
  CONSTRAINT `Role_chk_1` CHECK ((`RoleName` in (_utf8mb4'Admin',_utf8mb4'Staff')))
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'Admin'),(2,'Staff');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `synclog`
--

DROP TABLE IF EXISTS `synclog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `synclog` (
  `SyncId` int NOT NULL AUTO_INCREMENT,
  `WarehouseId` int DEFAULT NULL,
  `SyncDate` datetime DEFAULT CURRENT_TIMESTAMP,
  `Status` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`SyncId`),
  KEY `WarehouseId` (`WarehouseId`),
  CONSTRAINT `SyncLog_ibfk_1` FOREIGN KEY (`WarehouseId`) REFERENCES `warehouse` (`WarehouseId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `synclog`
--

LOCK TABLES `synclog` WRITE;
/*!40000 ALTER TABLE `synclog` DISABLE KEYS */;
INSERT INTO `synclog` VALUES (1,2,'2025-04-01 22:11:31','Success'),(2,3,'2025-04-01 22:13:22','Success'),(3,4,'2025-04-03 22:16:05','Success'),(4,4,'2025-04-03 22:17:24','Success'),(5,5,'2025-04-06 22:19:45','Success'),(6,4,'2025-04-17 22:27:29','Success'),(7,4,'2025-04-21 22:29:10','Success'),(8,3,'2025-04-23 22:30:39','Success'),(9,5,'2025-04-10 22:33:12','Success'),(10,2,'2025-04-10 22:34:03','Success'),(11,9,'2025-04-22 22:46:56','Success'),(12,5,'2025-04-19 22:51:33','Success'),(13,3,'2025-04-27 23:03:03','Success'),(14,2,'2025-05-03 23:15:55','Success'),(15,4,'2025-05-04 23:17:31','Success'),(16,4,'2025-05-12 23:21:20','Success'),(17,5,'2025-05-18 23:23:56','Success'),(18,3,'2025-06-02 00:09:16','Success'),(19,5,'2025-06-03 00:10:52','Success'),(20,2,'2025-06-10 09:14:00','Success');
/*!40000 ALTER TABLE `synclog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `synclogitem`
--

DROP TABLE IF EXISTS `synclogitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `synclogitem` (
  `SyncLogItemId` int NOT NULL AUTO_INCREMENT,
  `SyncId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  PRIMARY KEY (`SyncLogItemId`),
  KEY `SyncId` (`SyncId`),
  KEY `ItemId` (`ItemId`),
  CONSTRAINT `SyncLogItem_ibfk_1` FOREIGN KEY (`SyncId`) REFERENCES `synclog` (`SyncId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `SyncLogItem_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `warehouseitem` (`ItemId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=106 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `synclogitem`
--

LOCK TABLES `synclogitem` WRITE;
/*!40000 ALTER TABLE `synclogitem` DISABLE KEYS */;
INSERT INTO `synclogitem` VALUES (1,1,1,100),(2,1,2,50),(3,1,3,100),(4,1,4,50),(5,1,5,50),(6,1,6,5),(7,1,7,100),(8,1,8,2),(9,1,10,10),(10,1,16,10),(11,1,17,10),(12,1,18,20),(13,1,26,500000),(14,1,11,50),(15,1,12,50),(16,1,13,100),(17,1,15,10),(18,1,14,7),(19,2,1,90),(20,2,2,12),(21,2,3,10),(22,2,4,50),(23,2,20,100),(24,2,21,100),(25,2,12,33),(26,2,26,1000000),(27,3,18,10),(28,3,17,100),(29,3,10,100),(30,3,11,100),(31,3,9,100),(32,3,4,50),(33,3,1,300),(34,3,3,10),(35,3,26,3250000),(36,3,22,2),(37,3,25,2),(38,4,17,100),(39,4,18,2),(40,4,12,30),(41,4,26,750000),(42,5,8,20),(43,5,6,5),(44,5,26,3000000),(45,5,15,50),(46,5,12,200),(47,6,4,22),(48,6,26,700000),(49,6,12,222),(50,6,16,22),(51,6,13,44),(52,6,17,100),(53,6,22,7),(54,7,13,100),(55,7,14,100),(56,7,26,3000000),(57,8,17,122),(58,8,16,20),(59,8,26,1100000),(60,8,22,10),(61,8,1,1000),(62,9,8,50),(63,9,5,100),(64,9,26,6000000),(65,9,19,10),(66,9,25,10),(67,10,26,5550000),(68,10,3,50),(69,10,19,5),(70,10,9,100),(71,10,10,100),(72,10,11,200),(73,10,14,50),(74,10,1,30),(75,11,26,200000),(76,11,1,500),(77,11,2,100),(78,12,7,1000),(79,12,5,50),(80,12,3,500),(81,12,4,500),(82,12,2,500),(83,13,19,100),(84,13,21,100),(85,13,6,100),(86,14,26,4000000),(87,14,12,500),(88,14,18,100),(89,14,16,100),(90,15,14,22),(91,15,26,500000),(92,15,19,500),(93,15,21,40),(94,15,25,50),(95,16,17,50),(96,16,3,500),(97,16,6,200),(98,17,23,500),(99,18,1,700),(100,18,21,40),(101,19,3,100),(102,19,1,100),(103,19,10,100),(104,19,6,40),(105,20,6,2);
/*!40000 ALTER TABLE `synclogitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Password` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Salt` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `RoleId` int NOT NULL,
  `AreaId` int DEFAULT NULL,
  `WarehouseId` int DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `Username` (`Username`),
  KEY `RoleId` (`RoleId`),
  KEY `AreaId` (`AreaId`),
  KEY `WarehouseId` (`WarehouseId`),
  CONSTRAINT `User_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `role` (`RoleId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `User_ibfk_2` FOREIGN KEY (`AreaId`) REFERENCES `area` (`AreaId`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `User_ibfk_3` FOREIGN KEY (`WarehouseId`) REFERENCES `warehouse` (`WarehouseId`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'admin','9cbfbe7bf3f6016f7e2949bf615470381d9a4baa3098a0d3e7530e21617440b3','AwQlPPqGOd1Tr5DQq0AkazwOt0oWKNq8zlkydpvWunE=',1,NULL,1),(2,'staff06','68d93616937db409d5a738e37fef114532b83ba95346608c970c1b933366bd01','2LZTMCvSYByARd529cbiBaPEC+Sw12eq9d7Fl8q0Fy4=',2,6,7),(3,'staff07','9c70f10cf3707389bbadb0bde179410af4493efe315582393515fc3499e3d5f0','wWHeAKrFKua3ochfMS16e5vSWznpgHF/Scf0wBP46xg=',2,7,8),(4,'staff08','97b0d9737661f323931125e667d609fb83828acec7d0d9fbf450f5aca2b787a0','y+uiTpC/Vj2fFeKKVkVJHZ6vdMfgUtGciq8kzuLiwvM=',2,8,9),(5,'staff09','303efacfd3249ee3a0f4d13b50a8e228fca04585732b4457902a95ac49cfd91c','HXftjzscdL1htwrIgoHpqxiaq/3Z4K73ToZCFZkzZgY=',2,9,10),(6,'staff01','6654c8960124493909a3971150a099918366099b73441b1c070f74bf98673654','2Wwlnlo7c09sZ3+uNfCC78Kv4hs7G8NFZygUsKi1lc4=',2,1,2),(7,'staff02','831846720c044a10652c8bf64c2bfdcc86ab9daf1a6dff79490304db352978f1','1gUBbV1b/O2ZKSXnkcix9+c6bwhnvxy9S15MqW65tzY=',2,2,3),(8,'staff03','c7071bd5ba95f4e436495a14cc0f8ce9a6a139c531869737c9781509278d0094','4uD2YK3vpQs9lqdQpX9PPlihh44tBvZM7OVUbPDvmCk=',2,3,4),(9,'staff04','6584e5c5d43bee43eb97d0e3b3237f88b4af926937834d0cafd848c0af4385df','r2uo1pRkRsGMBNFMUM5IFMHIj7PKb8D7u/8Aqt61x6w=',2,4,5),(10,'staff05','169ad59620e866810791b6130f57b18368533cd64d48b77e6624683e61d37ef7','pCU16JPJaqqBxfKCf+sogjEiZD/TcutDOzD9ViO7UFw=',2,5,6);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouse`
--

DROP TABLE IF EXISTS `warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `warehouse` (
  `WarehouseId` int NOT NULL AUTO_INCREMENT,
  `Type` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `AreaId` int DEFAULT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  PRIMARY KEY (`WarehouseId`),
  KEY `AreaId` (`AreaId`),
  CONSTRAINT `Warehouse_ibfk_1` FOREIGN KEY (`AreaId`) REFERENCES `area` (`AreaId`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `Warehouse_chk_1` CHECK ((`Type` in (_utf8mb4'Central',_utf8mb4'Local')))
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouse`
--

LOCK TABLES `warehouse` WRITE;
/*!40000 ALTER TABLE `warehouse` DISABLE KEYS */;
INSERT INTO `warehouse` VALUES (1,'Central',NULL,'Kho Trung Tâm TP. Đà Nẵng'),(2,'Local',1,'Kho Hòa Cường Bắc'),(3,'Local',2,'Kho Thạch Thang'),(4,'Local',3,'Kho Hòa Khánh Nam'),(5,'Local',4,'Kho Hòa Minh'),(6,'Local',5,'Kho Thủy Phù'),(7,'Local',6,'Kho Hương Toàn'),(8,'Local',7,'Kho Đông Lễ'),(9,'Local',8,'Kho Triệu Long'),(10,'Local',9,'Kho Cam Tuyền');
/*!40000 ALTER TABLE `warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehouseitem`
--

DROP TABLE IF EXISTS `warehouseitem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `warehouseitem` (
  `ItemId` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Unit` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CategoryId` int DEFAULT NULL,
  PRIMARY KEY (`ItemId`),
  KEY `CategoryId` (`CategoryId`),
  CONSTRAINT `WarehouseItem_ibfk_1` FOREIGN KEY (`CategoryId`) REFERENCES `itemcategory` (`CategoryId`) ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehouseitem`
--

LOCK TABLES `warehouseitem` WRITE;
/*!40000 ALTER TABLE `warehouseitem` DISABLE KEYS */;
INSERT INTO `warehouseitem` VALUES (1,'Gạo','kg',1),(2,'Mì tôm','thùng',1),(3,'Thực phẩm đóng hộp','hộp',1),(4,'Cháo ăn liền','gói',1),(5,'Nước tinh khiết','lít',2),(6,'Bình nước 20L','bình',2),(7,'Viên lọc nước','viên',2),(8,'Bộ lọc nước cá nhân','bộ',2),(9,'Thuốc cảm','vỉ',3),(10,'Dung dịch sát khuẩn','chai',3),(11,'Bông băng gạc','bộ',3),(12,'Khẩu trang y tế','hộp',4),(13,'Áo mưa','cái',4),(14,'Bàn chải đánh răng','cái',4),(15,'Khăn mặt','cái',4),(16,'Mền (chăn)','cái',5),(17,'Đèn pin','cái',5),(18,'Nồi nhôm','cái',5),(19,'Dây thừng','cuộn',6),(20,'Đèn năng lượng mặt trời','cái',6),(21,'Loa pin thông báo','cái',6),(22,'Canô hơi','chiếc',6),(23,'Áo phao','cái',6),(25,'Bạt che','tấm',6),(26,'Tiền mặt','VND',7);
/*!40000 ALTER TABLE `warehouseitem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `warehousestock`
--

DROP TABLE IF EXISTS `warehousestock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `warehousestock` (
  `StockId` int NOT NULL AUTO_INCREMENT,
  `WarehouseId` int DEFAULT NULL,
  `ItemId` int DEFAULT NULL,
  `Quantity` int DEFAULT '0',
  `LastUpdated` datetime DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`StockId`),
  KEY `WarehouseId` (`WarehouseId`),
  KEY `ItemId` (`ItemId`),
  CONSTRAINT `WarehouseStock_ibfk_1` FOREIGN KEY (`WarehouseId`) REFERENCES `warehouse` (`WarehouseId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `WarehouseStock_ibfk_2` FOREIGN KEY (`ItemId`) REFERENCES `warehouseitem` (`ItemId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=162 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `warehousestock`
--

LOCK TABLES `warehousestock` WRITE;
/*!40000 ALTER TABLE `warehousestock` DISABLE KEYS */;
INSERT INTO `warehousestock` VALUES (19,1,1,1090,'2025-06-06 00:13:26'),(20,1,2,52,'2025-06-02 00:07:37'),(21,1,3,570,'2025-06-03 00:10:52'),(22,1,4,452,'2025-04-23 22:51:52'),(23,1,5,120,'2025-05-18 23:25:03'),(24,1,6,332,'2025-06-10 09:14:02'),(25,1,7,800,'2025-04-23 22:52:01'),(26,1,8,71,'2025-06-09 21:45:24'),(27,1,10,310,'2025-06-03 00:10:52'),(28,1,16,142,'2025-05-03 23:15:55'),(29,1,17,372,'2025-06-02 00:07:37'),(30,1,18,132,'2025-05-03 23:15:55'),(31,1,26,27550000,'2025-05-04 23:17:31'),(32,1,11,340,'2025-04-28 23:03:22'),(33,1,12,885,'2025-05-25 23:27:28'),(34,1,13,244,'2025-04-21 22:29:09'),(35,1,15,60,'2025-04-06 22:19:44'),(36,1,14,179,'2025-05-04 23:17:31'),(45,1,20,100,'2025-04-01 22:13:21'),(46,1,21,190,'2025-06-02 00:09:15'),(58,1,9,200,'2025-04-10 22:34:03'),(59,1,22,7,'2025-04-23 22:51:52'),(60,1,25,52,'2025-05-04 23:17:31'),(96,1,19,385,'2025-06-06 00:13:26'),(107,6,1,30,'2025-04-21 22:52:38'),(108,6,2,10,'2025-04-21 22:52:38'),(109,6,16,10,'2025-04-21 22:52:38'),(110,6,17,10,'2025-04-21 22:52:38'),(111,6,19,10,'2025-04-21 22:52:38'),(112,6,22,2,'2025-04-21 22:52:38'),(113,9,5,30,'2025-04-21 22:53:54'),(114,9,7,300,'2025-04-21 22:53:54'),(115,9,12,100,'2025-04-21 22:53:54'),(116,9,26,2000000,'2025-04-21 22:53:54'),(117,10,1,1000,'2025-06-02 00:08:28'),(118,10,3,500,'2025-04-25 22:54:26'),(119,10,4,220,'2025-04-25 22:54:26'),(120,10,5,30,'2025-04-25 22:54:26'),(121,10,22,10,'2025-04-25 22:54:26'),(125,7,6,10,'2025-04-29 23:04:24'),(126,7,11,10,'2025-04-29 23:04:24'),(127,7,19,60,'2025-06-07 00:15:10'),(128,7,25,10,'2025-04-29 23:04:24'),(129,8,19,60,'2025-06-07 00:14:43'),(130,8,21,40,'2025-04-29 23:04:47'),(144,1,23,400,'2025-05-18 23:25:03'),(145,6,5,20,'2025-05-19 23:25:24'),(146,6,6,10,'2025-05-19 23:25:24'),(147,6,23,100,'2025-05-19 23:25:24'),(148,10,2,100,'2025-06-02 00:08:28'),(149,10,17,100,'2025-06-02 00:08:28'),(150,10,21,50,'2025-06-02 00:08:28'),(157,8,1,500,'2025-06-07 00:14:43'),(158,8,2,300,'2025-06-07 00:14:43'),(159,7,1,200,'2025-06-07 00:15:10'),(160,10,8,1,'2025-06-09 21:48:11');
/*!40000 ALTER TABLE `warehousestock` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-12 10:46:25
