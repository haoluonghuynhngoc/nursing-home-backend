-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: NursingHome
-- ------------------------------------------------------
-- Server version	8.0.39-0ubuntu0.24.04.1

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
-- Table structure for table `AppointmentElder`
--

DROP TABLE IF EXISTS `AppointmentElder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AppointmentElder` (
  `AppointmentsId` int NOT NULL,
  `EldersId` int NOT NULL,
  PRIMARY KEY (`AppointmentsId`,`EldersId`),
  KEY `IX_AppointmentElder_EldersId` (`EldersId`),
  CONSTRAINT `FK_AppointmentElder_Appointments_AppointmentsId` FOREIGN KEY (`AppointmentsId`) REFERENCES `Appointments` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AppointmentElder_Elders_EldersId` FOREIGN KEY (`EldersId`) REFERENCES `Elders` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AppointmentElder`
--

LOCK TABLES `AppointmentElder` WRITE;
/*!40000 ALTER TABLE `AppointmentElder` DISABLE KEYS */;
INSERT INTO `AppointmentElder` VALUES (19,1),(17,2),(18,2),(21,2),(33,2),(36,2),(8,3),(21,3),(10,5),(11,5),(20,11),(31,13),(34,16);
/*!40000 ALTER TABLE `AppointmentElder` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Appointments`
--

DROP TABLE IF EXISTS `Appointments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Appointments` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `NursingPackageId` int DEFAULT NULL,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `Date` date NOT NULL DEFAULT '0001-01-01',
  `ContractId` int DEFAULT NULL,
  `Reason` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Time` time(6) NOT NULL DEFAULT '00:00:00.000000',
  PRIMARY KEY (`Id`),
  KEY `IX_Appointments_UserId` (`UserId`),
  KEY `IX_Appointments_NursingPackageId` (`NursingPackageId`),
  KEY `IX_Appointments_ContractId` (`ContractId`),
  CONSTRAINT `FK_Appointments_Contracts_ContractId` FOREIGN KEY (`ContractId`) REFERENCES `Contracts` (`Id`),
  CONSTRAINT `FK_Appointments_NursingPackages_NursingPackageId` FOREIGN KEY (`NursingPackageId`) REFERENCES `NursingPackages` (`Id`),
  CONSTRAINT `FK_Appointments_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Appointments`
--

LOCK TABLES `Appointments` WRITE;
/*!40000 ALTER TABLE `Appointments` DISABLE KEYS */;
INSERT INTO `Appointments` VALUES (1,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 14:47:06.778002','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:27:21.389063',NULL,NULL,5,'Completed','2024-08-08',NULL,NULL,'00:00:00.000000'),(2,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 15:42:13.249628','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:52:49.766365',NULL,NULL,6,'Cancelled','2024-08-07',NULL,NULL,'00:00:00.000000'),(7,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 17:10:27.496676','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 10:23:21.368702',NULL,NULL,6,'Completed','2024-08-09',NULL,NULL,'00:00:00.000000'),(8,'Đăng ký lịch thăm nuôi',NULL,'FollowUpVisit','Đăng ký lịch thăm nuôi','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 17:17:41.505852','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 16:15:24.654506',NULL,NULL,NULL,'Cancelled','2024-08-18',NULL,NULL,'00:00:00.000000'),(9,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 05:13:04.040826','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:31.148805',NULL,NULL,6,'Completed','2024-08-08',NULL,NULL,'00:00:00.000000'),(10,'Lịch hẹn kết thúc hợp đồng','Lịch hẹn kết thúc hợp đồng','Cancel','Lịch hẹn kết thúc hợp đồng','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 05:26:40.012307','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:26:52.929103',NULL,NULL,NULL,'Cancelled','2024-08-09',5,'Không phù hợp với môi trường','00:00:00.000000'),(11,'Đăng ký lịch thăm nuôi',NULL,'FollowUpVisit','Đăng ký lịch thăm nuôi','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 05:31:07.899423','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:31:24.247801',NULL,NULL,NULL,'Completed','2024-08-09',NULL,NULL,'00:00:00.000000'),(12,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','2024-08-07 15:51:44.740148','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 16:02:24.572165',NULL,NULL,1,'Completed','2024-08-08',NULL,NULL,'00:00:00.000000'),(13,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb74b-366b-4a70-88f9-5631236a3f1b','2024-08-08 01:45:34.579526','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-08 01:51:44.478999',NULL,NULL,6,'Completed','2024-08-09',NULL,NULL,'00:00:00.000000'),(14,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:07:37.456590','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 16:09:43.677300',NULL,NULL,4,'Cancelled','2024-08-12',NULL,NULL,'00:00:00.000000'),(15,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:10:09.569227','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 16:22:37.903783',NULL,NULL,1,'Cancelled','2024-08-13',NULL,NULL,'00:00:00.000000'),(16,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:10:29.910871','Anonymous','2024-08-16 23:10:13.278810',NULL,NULL,2,'Cancelled','2024-08-15',NULL,NULL,'00:00:00.000000'),(17,'Lịch hẹn gia hạn hợp đồng','Lịch hẹn gia hạn hợp đồng','ProcedureCompletion','Lịch hẹn gia hạn hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:18:24.217580','Anonymous','2024-08-15 23:10:03.848228',NULL,NULL,NULL,'Cancelled','2024-08-14',2,'','00:00:00.000000'),(18,'Lịch hẹn gia hạn hợp đồng','Lịch hẹn gia hạn hợp đồng','ProcedureCompletion','Lịch hẹn gia hạn hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:18:33.022482','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-16 00:27:43.410217',NULL,NULL,NULL,'Completed','2024-08-17',2,'','00:00:00.000000'),(19,'Lịch hẹn kết thúc hợp đồng','Lịch hẹn kết thúc hợp đồng','Cancel','Lịch hẹn kết thúc hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:19:38.607836','Anonymous','2024-08-16 23:10:13.357084',NULL,NULL,NULL,'Cancelled','2024-08-15',6,'toi muon ve nha','00:00:00.000000'),(20,'Lịch hẹn kết thúc hợp đồng','Lịch hẹn kết thúc hợp đồng','Cancel','Lịch hẹn kết thúc hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:20:05.979590','Anonymous','2024-08-22 21:00:12.297341',NULL,NULL,NULL,'Cancelled','2024-08-21',14,'huy ','00:00:00.000000'),(21,'Đăng ký lịch thăm nuôi',NULL,'FollowUpVisit','Đăng ký lịch thăm nuôi','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:45:22.759696','Anonymous','2024-08-19 23:10:02.690596',NULL,NULL,NULL,'Cancelled','2024-08-18',NULL,NULL,'00:00:00.000000'),(22,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-12 07:51:44.554244','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 07:55:19.655125',NULL,NULL,6,'Completed','2024-08-13',NULL,NULL,'00:00:00.000000'),(23,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-12 19:17:14.549148','Anonymous','2024-08-15 23:10:03.909988',NULL,NULL,6,'Cancelled','2024-08-14',NULL,NULL,'00:00:00.000000'),(24,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbb79-7a66-40c4-89c9-9c123b56123c','08dcbb79-7a66-40c4-89c9-9c123b56123c','2024-08-13 09:37:54.102714','Anonymous','2024-08-15 23:10:03.919099',NULL,NULL,8,'Cancelled','2024-08-14',NULL,NULL,'00:00:00.000000'),(25,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbb82-44a6-4718-8bda-d392c5a12e22','08dcbb82-44a6-4718-8bda-d392c5a12e22','2024-08-13 10:37:57.451144','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 10:39:20.985594',NULL,NULL,6,'Completed','2024-08-14',NULL,NULL,'00:00:00.000000'),(26,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 11:23:25.997955','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 11:26:13.483368',NULL,NULL,6,'Completed','2024-08-14',NULL,NULL,'00:00:00.000000'),(27,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 13:31:28.798621','Anonymous','2024-08-15 23:10:03.927174',NULL,NULL,6,'Cancelled','2024-08-14',NULL,NULL,'00:00:00.000000'),(28,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 15:39:54.403126','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 15:43:27.311003',NULL,NULL,8,'Completed','2024-08-17',NULL,NULL,'00:00:00.000000'),(29,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbc07-6864-4aca-8b85-d654af70c13a','08dcbc07-6864-4aca-8b85-d654af70c13a','2024-08-14 02:19:45.122919','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 02:22:57.544875',NULL,NULL,8,'Completed','2024-08-15',NULL,NULL,'00:00:00.000000'),(30,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 06:42:01.508264','Anonymous','2024-08-22 21:00:12.341166',NULL,NULL,6,'Cancelled','2024-08-21',NULL,NULL,'00:00:00.000000'),(31,'Đăng ký lịch thăm nuôi',NULL,'FollowUpVisit','Đăng ký lịch thăm nuôi','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 06:47:08.896029','Anonymous','2024-08-22 21:00:12.351697',NULL,NULL,NULL,'Cancelled','2024-08-22',NULL,NULL,'00:00:00.000000'),(33,'Lịch hẹn gia hạn hợp đồng','Lịch hẹn gia hạn hợp đồng','ProcedureCompletion','Lịch hẹn gia hạn hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-20 06:50:57.677075','Anonymous','2024-08-22 21:00:12.358037',NULL,NULL,NULL,'Cancelled','2024-08-22',2,'','00:00:00.000000'),(34,'Lịch hẹn kết thúc hợp đồng','Lịch hẹn kết thúc hợp đồng','Cancel','Lịch hẹn kết thúc hợp đồng','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-20 07:26:08.526171','Anonymous','2024-08-25 21:00:05.069241',NULL,NULL,NULL,'Pending','2024-08-28',21,'','00:00:00.000000'),(35,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-20 07:26:36.295330','Anonymous','2024-08-22 21:00:12.371307',NULL,NULL,6,'Cancelled','2024-08-22',NULL,NULL,'00:00:00.000000'),(36,'Đăng ký lịch thăm nuôi',NULL,'FollowUpVisit','Đăng ký lịch thăm nuôi','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-20 07:27:59.576812','Anonymous','2024-08-22 21:00:12.378507',NULL,NULL,NULL,'Cancelled','2024-08-21',NULL,NULL,'00:00:00.000000'),(37,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 14:04:16.565753','Anonymous','2024-08-24 21:00:03.753165',NULL,NULL,6,'Cancelled','2024-08-24',NULL,NULL,'00:00:00.000000'),(40,'Lịch hẹn hoàn thành thủ tục đăng ký','Lịch hẹn hoàn thành thủ tục đăng ký','Consultation','Lịch hẹn hoàn thành thủ tục đăng ký','08dcc33d-cb4c-4c30-80f7-97cbdf1a800e','08dcc33d-cb4c-4c30-80f7-97cbdf1a800e','2024-08-23 06:36:45.519173','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-23 06:39:09.145482',NULL,NULL,6,'Completed','2024-08-24',NULL,NULL,'00:00:00.000000');
/*!40000 ALTER TABLE `Appointments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Blocks`
--

DROP TABLE IF EXISTS `Blocks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Blocks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Blocks`
--

LOCK TABLES `Blocks` WRITE;
/*!40000 ALTER TABLE `Blocks` DISABLE KEYS */;
INSERT INTO `Blocks` VALUES (1,'A'),(2,'B'),(3,'C');
/*!40000 ALTER TABLE `Blocks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CareScheduleRoom`
--

DROP TABLE IF EXISTS `CareScheduleRoom`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CareScheduleRoom` (
  `CareSchedulesId` int NOT NULL,
  `RoomsId` int NOT NULL,
  PRIMARY KEY (`CareSchedulesId`,`RoomsId`),
  KEY `IX_CareScheduleRoom_RoomsId` (`RoomsId`),
  CONSTRAINT `FK_CareScheduleRoom_CareSchedules_CareSchedulesId` FOREIGN KEY (`CareSchedulesId`) REFERENCES `CareSchedules` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_CareScheduleRoom_Rooms_RoomsId` FOREIGN KEY (`RoomsId`) REFERENCES `Rooms` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CareScheduleRoom`
--

LOCK TABLES `CareScheduleRoom` WRITE;
/*!40000 ALTER TABLE `CareScheduleRoom` DISABLE KEYS */;
INSERT INTO `CareScheduleRoom` VALUES (2,34),(3,34),(4,34),(5,35),(1,36);
/*!40000 ALTER TABLE `CareScheduleRoom` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CareSchedules`
--

DROP TABLE IF EXISTS `CareSchedules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CareSchedules` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CareMonth` int NOT NULL DEFAULT '0',
  `CareYear` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CareSchedules`
--

LOCK TABLES `CareSchedules` WRITE;
/*!40000 ALTER TABLE `CareSchedules` DISABLE KEYS */;
INSERT INTO `CareSchedules` VALUES (1,'string',8,2024),(2,'string',9,2024),(3,'string',10,2024),(4,'string',8,2024),(5,'string',8,2024);
/*!40000 ALTER TABLE `CareSchedules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Contracts`
--

DROP TABLE IF EXISTS `Contracts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Contracts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `SigningDate` date NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReasonForCanceling` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ElderId` int NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `NursingPackageId` int DEFAULT NULL,
  `Duration` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Contracts_ElderId` (`ElderId`),
  KEY `IX_Contracts_UserId` (`UserId`),
  KEY `IX_Contracts_NursingPackageId` (`NursingPackageId`),
  CONSTRAINT `FK_Contracts_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Contracts_NursingPackages_NursingPackageId` FOREIGN KEY (`NursingPackageId`) REFERENCES `NursingPackages` (`Id`),
  CONSTRAINT `FK_Contracts_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Contracts`
--

LOCK TABLES `Contracts` WRITE;
/*!40000 ALTER TABLE `Contracts` DISABLE KEYS */;
INSERT INTO `Contracts` VALUES (1,'HDDL1009','2023-08-06','2023-08-07','2024-08-06',10800000.000000000000000000000000000000,NULL,NULL,NULL,'Expired',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 14:54:21.335603','Anonymous','2024-08-07 00:00:08.874623',NULL,NULL,5,0),(2,'HDDL1010','2024-08-06','2024-08-06','2025-02-06',9000000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,2,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:27:21.011384','Anonymous','2024-08-26 00:00:05.325929',NULL,NULL,2,0),(3,'HDDL12','2024-08-06','2024-08-07','2025-02-07',30000000.000000000000000000000000000000,NULL,NULL,'Người cao tuổi về nhà','Cancelled',NULL,3,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:52:22.427952','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-22 11:10:34.990198',NULL,NULL,6,0),(4,'HDDL1012','2024-08-07','2024-08-08','2026-08-08',21600000.000000000000000000000000000000,'Hợp Đồng cho người Già 2 Năm',NULL,NULL,'Valid',NULL,4,'08dcb64b-96b1-4e12-8a71-84f13e47d292','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 19:44:08.810809','Anonymous','2024-08-26 00:00:05.367228',NULL,NULL,5,0),(5,'HDDL121','2024-08-07','2024-08-08','2025-08-08',10800000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,5,'08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:30.940628','Anonymous','2024-08-26 00:00:05.402071',NULL,NULL,5,0),(6,'HDDL09','2024-08-07','2024-08-07','2025-08-07',60000000.000000000000000000000000000000,NULL,NULL,'','Cancelled',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 09:16:53.438698','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 08:08:59.425456',NULL,NULL,6,0),(7,'HDDL122','2023-08-07','2023-08-08','2023-08-08',10800000.000000000000000000000000000000,NULL,NULL,NULL,'Expired',NULL,5,'08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2023-08-07 15:09:17.000137','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2023-08-07 15:09:17.000231',NULL,NULL,5,0),(8,'HDDL122','2024-08-07','2024-08-08','2025-08-08',10800000.000000000000000000000000000000,NULL,NULL,'','Cancelled',NULL,5,'08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:19:17.153230','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 19:16:58.165991',NULL,NULL,5,0),(9,'HDDL08','2024-08-07','2024-08-08','2025-02-08',9000000.000000000000000000000000000000,NULL,NULL,'','Cancelled',NULL,6,'08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 16:02:24.288163','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 19:14:49.304013',NULL,NULL,2,0),(10,'HDDL88','2024-08-08','2024-08-08','2025-08-08',60000000.000000000000000000000000000000,NULL,NULL,'','Cancelled',NULL,7,'08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-08 01:51:44.212395','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 16:03:57.013731',NULL,NULL,6,0),(11,'HDDL99','2024-08-09','2024-08-09','2025-08-09',60000000.000000000000000000000000000000,NULL,NULL,'đã mất ','Cancelled',NULL,8,'08dcb6ca-7842-40fe-8086-f724e6188753','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 13:53:29.790481','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 19:13:23.362043',NULL,NULL,6,0),(12,'HDDL98','2024-08-10','2024-08-10','2025-08-10',10800000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,9,'08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 08:12:11.080207','Anonymous','2024-08-26 00:00:05.473169',NULL,NULL,5,0),(13,'HDDL97','2024-08-10','2024-08-10','2026-08-10',48000000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,10,'08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 10:20:46.981420','Anonymous','2024-08-26 00:00:05.531675',NULL,NULL,3,0),(14,'HDDL95','2024-08-10','2024-08-10','2025-08-10',60000000.000000000000000000000000000000,'',NULL,NULL,'Valid',NULL,11,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 10:23:21.046562','Anonymous','2024-08-26 00:00:05.561143',NULL,NULL,6,0),(15,'HDDL93','2024-08-12','2024-08-12','2025-08-12',60000000.000000000000000000000000000000,NULL,NULL,'Tôi Muốn Về Nhà','Cancelled',NULL,12,'08dcb61e-8a1a-4750-81fa-9811238463cd','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:43:29.392549','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-15 15:38:30.356393',NULL,NULL,6,0),(16,'HDDL88','2024-08-12','2024-08-12','2027-08-12',32400000.000000000000000000000000000000,NULL,'','Muốn Xuất Viện','Cancelled','',7,'08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:44:32.341797','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 15:09:17.680319',NULL,NULL,5,0),(17,'HDDL89','2024-08-12','2024-08-12','2025-08-12',60000000.000000000000000000000000000000,NULL,NULL,'','Cancelled',NULL,6,'08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 05:05:34.046373','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 08:18:34.521917',NULL,NULL,6,0),(18,'HDDL1030','2024-08-12','2024-08-12','2025-08-12',60000000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,13,'08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 07:55:18.975815','Anonymous','2024-08-26 00:00:05.620605',NULL,NULL,6,0),(19,'HDDL90','2024-08-13','2024-08-13','2025-08-13',60000000.000000000000000000000000000000,NULL,NULL,NULL,'Valid',NULL,14,'08dcbb82-44a6-4718-8bda-d392c5a12e22','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 10:39:20.630193','Anonymous','2024-08-26 00:00:05.688664',NULL,NULL,6,0),(20,'HDDL91','2024-08-13','2024-08-13','2025-08-13',60000000.000000000000000000000000000000,'Nội dung hợp đồng',NULL,'','Cancelled',NULL,15,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 11:26:13.192508','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 08:03:39.954364',NULL,NULL,6,0),(21,'HDDL92','2024-08-13','2024-08-13','2026-08-13',120000000.000000000000000000000000000000,'',NULL,NULL,'Valid',NULL,16,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 15:43:27.028989','Anonymous','2024-08-26 00:00:05.730429',NULL,NULL,6,0),(22,'HDDL1079','2024-08-14','2024-08-14','2026-08-14',120000000.000000000000000000000000000000,'Hợp đồng lưu trú dành cho người cao tuổi\n',NULL,NULL,'Valid',NULL,17,'08dcbc07-6864-4aca-8b85-d654af70c13a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 02:22:57.275614','Anonymous','2024-08-26 00:00:05.782539',NULL,NULL,6,0);
/*!40000 ALTER TABLE `Contracts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Devices`
--

DROP TABLE IF EXISTS `Devices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Devices` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Token` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Devices_UserId` (`UserId`),
  CONSTRAINT `FK_Devices_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=177 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Devices`
--

LOCK TABLES `Devices` WRITE;
/*!40000 ALTER TABLE `Devices` DISABLE KEYS */;
INSERT INTO `Devices` VALUES (2,'ExponentPushToken[AjHCdgO6kLQ5gN6UHodxxB]','08dcb621-57f4-4acb-877d-4650a09350ab'),(10,'ExponentPushToken[5407AtGJQKMFoeYRQoIPI4]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(33,'ExponentPushToken[uA7Qp6Jg4iFxU4orb7ZsVt]','08dcb628-3f07-45f8-8280-6ccb6e6fefff'),(38,'ExponentPushToken[KOGmVeO8-I-ng4KRKeL2nA]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(43,'ExponentPushToken[u_mFsLH_ECaVA9WbxeW8FZ]','08dcb61f-ffa3-4445-8ad4-d8f8e839f425'),(45,'ExponentPushToken[ix0LNhE5WBY-TBxFbLio8U]','08dcb61f-ecc0-4838-8063-3077fa843444'),(61,'ExponentPushToken[DywyZbOb3Itob_Ij2PMoZP]','08dcb74b-366b-4a70-88f9-5631236a3f1b'),(65,'ExponentPushToken[2vPU28Cacdh5FJKL3KkUoR]','08dcb69f-67c7-43be-81fe-9c26b6a92b08'),(68,'ExponentPushToken[kwlimIJJur4eDUwpzPkXzk]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(73,'ExponentPushToken[KyU8LkCe-1D9cbpNfQ2YML]','08dcb61f-ecc0-4838-8063-3077fa843444'),(83,'ExponentPushToken[LQe2FKB0uBf94fev_W1X4W]','08dcb69f-67c7-43be-81fe-9c26b6a92b08'),(108,'ExponentPushToken[TJcKAHBeHTsFU7qMoLvvqQ]','08dcb61f-ecc0-4838-8063-3077fa843444'),(116,'ExponentPushToken[yDj9rZIA2YQj1pUbd1ikzJ]','08dcb61f-ecc0-4838-8063-3077fa843444'),(119,'ExponentPushToken[VYwFW0J3o2m82C0qvIR_aG]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(133,'ExponentPushToken[lPczlqBQpwm72b1mXHDuc5]','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a'),(139,'ExponentPushToken[B9aV4uOuX5YvC22dwavIdf]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(140,'ExponentPushToken[B9aV4uOuX5YvC22dwavIdf]','08dcb61f-ecc0-4838-8063-3077fa843444'),(141,'ExponentPushToken[lPczlqBQpwm72b1mXHDuc5]','08dcb61f-ecc0-4838-8063-3077fa843444'),(151,'ExponentPushToken[Fk91ZvFERkf4EMl98krCZ6]','08dcb61f-ecc0-4838-8063-3077fa843444'),(175,'ExponentPushToken[b3pswiFHi_Sdd5obChTQQS]','08dcb621-e0c8-4ad9-8956-1b20ea506e0b'),(176,'ExponentPushToken[b3pswiFHi_Sdd5obChTQQS]','08dcb61f-ecc0-4838-8063-3077fa843444');
/*!40000 ALTER TABLE `Devices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DiseaseCategory`
--

DROP TABLE IF EXISTS `DiseaseCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DiseaseCategory` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DiseaseCategory`
--

LOCK TABLES `DiseaseCategory` WRITE;
/*!40000 ALTER TABLE `DiseaseCategory` DISABLE KEYS */;
INSERT INTO `DiseaseCategory` VALUES (1,'Cao huyết áp','Active'),(2,'Ung thư','Active'),(3,'Bệnh Alzheimer','Active'),(4,'Bệnh tim','Active'),(5,'Đột quỵ','Deleted'),(6,'Bệnh phổi tắc nghẽn mãn tính','Deleted'),(7,'Tiểu đường','Deleted'),(8,'Viêm khớp','Active'),(9,'Viêm khớp 1','Deleted'),(10,'Viên soan','Deleted'),(11,'Viên xoang','Active');
/*!40000 ALTER TABLE `DiseaseCategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DiseaseCategoryMedicalRecord`
--

DROP TABLE IF EXISTS `DiseaseCategoryMedicalRecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DiseaseCategoryMedicalRecord` (
  `DiseaseCategoriesId` int NOT NULL,
  `MedicalRecordsId` int NOT NULL,
  PRIMARY KEY (`DiseaseCategoriesId`,`MedicalRecordsId`),
  KEY `IX_DiseaseCategoryMedicalRecord_MedicalRecordsId` (`MedicalRecordsId`),
  CONSTRAINT `FK_DiseaseCategoryMedicalRecord_DiseaseCategory_DiseaseCategori~` FOREIGN KEY (`DiseaseCategoriesId`) REFERENCES `DiseaseCategory` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_DiseaseCategoryMedicalRecord_MedicalRecords_MedicalRecordsId` FOREIGN KEY (`MedicalRecordsId`) REFERENCES `MedicalRecords` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DiseaseCategoryMedicalRecord`
--

LOCK TABLES `DiseaseCategoryMedicalRecord` WRITE;
/*!40000 ALTER TABLE `DiseaseCategoryMedicalRecord` DISABLE KEYS */;
INSERT INTO `DiseaseCategoryMedicalRecord` VALUES (3,3),(4,3),(5,3),(6,3),(7,3),(9,3),(5,9),(7,9),(3,11),(4,11),(5,11),(6,11),(2,13),(3,13),(4,13),(5,13),(9,13),(4,14),(6,14),(8,14),(2,15),(3,15),(4,15),(5,15),(6,15),(8,15),(2,16),(4,16),(5,16),(6,16),(7,16),(8,16),(9,16),(5,17),(6,17),(8,17);
/*!40000 ALTER TABLE `DiseaseCategoryMedicalRecord` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Elders`
--

DROP TABLE IF EXISTS `Elders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Elders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CCCD` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `DateOfBirth` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Gender` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Nationality` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RoomId` int DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `InDate` date NOT NULL DEFAULT '0001-01-01',
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  `OutDate` date NOT NULL DEFAULT '0001-01-01',
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `Habits` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Relationship` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Elders_RoomId` (`RoomId`),
  KEY `IX_Elders_UserId` (`UserId`),
  CONSTRAINT `FK_Elders_Rooms_RoomId` FOREIGN KEY (`RoomId`) REFERENCES `Rooms` (`Id`),
  CONSTRAINT `FK_Elders_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Elders`
--

LOCK TABLES `Elders` WRITE;
/*!40000 ALTER TABLE `Elders` DISABLE KEYS */;
INSERT INTO `Elders` VALUES (1,'Nguyễn Văn Toàn','087428917632','1960-03-11','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0fe19280-6c51-4324-81e5-cd3a0dc1ba26.jpg?alt=media&token=9d69b024-749a-4f04-80be-0b3d585703f6','109 TP.Thủ Đức',NULL,'Khó di chuyển ',12,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 14:54:21.335572','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:54:57.056000',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted','','Cháu'),(2,'Nguyễn Thị Hoa','087428917633','1960-05-05','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fb7184b6c-810e-4220-bc23-9011368f56ed.jpg?alt=media&token=351d17fa-6b86-493b-a38e-679328923eaa','124/2 hẻm nhỏ, quận 10, TP.Hồ Chí Minh',NULL,NULL,35,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-06 15:27:21.011380','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:59:55.849141',NULL,NULL,'0001-01-01',0,'0001-01-01','Active',NULL,NULL),(3,'Lê Thị Diễm Trang','074202004479','1976-08-20','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fea112a7c-757f-4592-b32c-58b7be5c3c15.jpg?alt=media&token=8bffc61c-964b-45b2-82ca-2288e3f16eb9','158 Đinh Tiên Hòa, Thành Phố Thủ Đức',NULL,NULL,NULL,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-06 15:52:22.426865','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-22 11:13:11.183344',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted',NULL,NULL),(4,'Nguyễn Thị Định','134512323','1960-02-03','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F25ce2acc-7443-40ea-9275-67732ba6e1e8.jpg?alt=media&token=2650fd01-d30c-435f-bdc3-f0f481c08ee9','Cao Lỗ Phường 4 Quận 8 Thành Phố Hồ Chí Minh',NULL,'Người Già Có sức khỏe bình thường',36,'08dcb64b-96b1-4e12-8a71-84f13e47d292','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-06 19:44:08.810807','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 19:44:08.810808',NULL,NULL,'0001-01-01',0,'0001-01-01','Active',NULL,NULL),(5,'Houang Triệu Huy','074202004477','1976-02-03','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F1c0d6b51-7be1-48ba-83f7-60ca07b60144.jpg?alt=media&token=f03f081a-5e3b-482f-84de-62259eb60c70','43 Trần Văn Ơn',NULL,NULL,36,'08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-07 05:25:30.940621','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:30.940621',NULL,NULL,'0001-01-01',0,'0001-01-01','Active',NULL,NULL),(6,'Lê Minh Tâm','074202005478','1968-05-08','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8451ed2f-5f4c-404f-a7d6-c46b86869f1f.jpg?alt=media&token=ea148f23-0735-4278-9b68-9f23efe10a06','158 Đinh Tiên Hòa, Thành Phố Thủ Đức',NULL,NULL,NULL,'08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-07 16:02:24.288120','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 08:18:43.027911',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted',NULL,NULL),(7,'Mai Tài Phến','074202004488','1968-05-08','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffad70282-1773-48af-9172-38b03955625e.jpg?alt=media&token=eb4b6f1c-bd7e-4174-b050-33f2f3db7fd5','Biên hòa, Bình Dương',NULL,'Người già lãng trí \n',NULL,'08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-03-08 01:51:44.212368','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 15:09:53.209511',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted',NULL,NULL),(8,'Nguyễn Phú Yên','111111111111','1966-08-09','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F84d88f2b-6a19-419c-b875-c8c31e76b26c.jpg?alt=media&token=c8d53358-5001-4edb-ae9a-9cdec10f2534','Long An',NULL,NULL,NULL,'08dcb6ca-7842-40fe-8086-f724e6188753','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-09 13:53:29.790322','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-16 09:02:49.552928',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted','ăn uống kém ','Ba/mẹ'),(9,'Trần Thanh Hòa','115282911112','1963-05-09','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F1de4cf06-81df-4d90-8dde-3d329cdba548.jpg?alt=media&token=1c3958ba-897f-4443-b22a-06b4c505515a','Cà Mau',NULL,'không có',36,'08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-03-10 08:12:11.080164','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:52:07.855534',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','không có','Con'),(10,'Trần Hoài Nam','111113335112','1970-11-11','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F496ea3ed-f430-4b9d-bb24-3a7095d8b772.jpg?alt=media&token=69eb251e-3795-41d7-a4f0-21f0e98c20c2','Cà Mau',NULL,'Không Có',24,'08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-10 10:20:46.981416','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:00:45.864434',NULL,NULL,'0001-01-01',0,'0001-01-01','Active',NULL,'Con'),(11,'Nguyễn Thị Đẹt','111111111188','1966-05-05','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F27b5ab99-9b31-4b33-ab2a-f31787deaa75.jpg?alt=media&token=6069e234-d226-46de-b631-5972742ebd5c','Cà Mau',NULL,'Không Có',32,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-10 10:23:21.046559','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:59:32.640303',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','ss','Ba/mẹ'),(12,'Nguyễn Thị Hoa','011111111177','1936-08-20','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F119fb98b-a1bc-45e2-ab2b-34b9a32ff7c9.jpg?alt=media&token=6cb8eec5-5df2-48cb-935c-3447915300ca','Hà Nội',NULL,NULL,NULL,'08dcb61e-8a1a-4750-81fa-9811238463cd','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:43:29.392340','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-16 09:02:05.587002',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted',NULL,'Con'),(13,'Nguyễn Thị Bảy','087428917147','1949-05-05','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F25b15c3c-a4a8-4ef1-9c35-022a4486914a.jpg?alt=media&token=146a4992-384d-4fa8-b4e7-d070b5a0288d','huyện Đức Hòa ,tỉnh Long An',NULL,NULL,34,'08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 07:55:18.975787','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 08:34:27.933459',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','- Giờ thức dậy: 5:00 sáng\n- Giờ đi ngủ: 9:00 tối\n- Thói quen buổi sáng:\n- Thể dục: Đi bộ nhẹ nhàng trong khuôn viên\n- Uống trà/cà phê: Trà xanh mỗi sáng\n- Bữa ăn:\n  + Thời gian ăn: 7:00 sáng, 12:00 trưa, 6:00 tối  \n  + Loại thức ăn ưa thích: Cháo, cơm mềm, rau luộc\n  + Kiêng cữ món ăn nào (nếu có): Thức ăn nhiều dầu mỡ, mặn\n- Hoạt động buổi chiều:\n- Thích đọc sách/nghe nhạc: Đọc sách, nghe đài phát thanh\n - Thói quen chăm sóc cây cảnh: Tưới cây cảnh trước phòng\n- Đi dạo: Đi dạo nhẹ quanh khu vườn\n- Hoạt động buổi tối:\n   + Giờ nghỉ ngơi: 8:00 tối\n   + Thói quen giải trí trước khi ngủ: Nghe nhạc nhẹ hoặc đọc sách\n- Hoạt động xã hội:\n   + Tham gia các buổi gặp gỡ, giao lưu với người cùng viện: Thỉnh thoảng tham gia\n   + Thích trò chuyện với ai: Trò chuyện với các bạn cùng phòng','Cháu'),(14,'Nguyễn Văn Bảo','111111111134','1963-08-14','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F7fe7d6eb-243d-474b-ac56-d8411ff7309e.png?alt=media&token=d6246e16-75c3-4a7e-9f8f-d3113f275fc3','Cà Mau',NULL,'Không có',32,'08dcbb82-44a6-4718-8bda-d392c5a12e22','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-13 10:39:20.630152','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:01:34.070627',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','Không có','Anh/Em'),(15,'Nguyễn Trung Nguyên','111111111444','1970-12-17','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fa9a163ee-7889-4fe9-bcc0-2f9da68ab156.jpg?alt=media&token=3c2102f7-2798-4a6c-8d62-64eef2072ae3','Hà Nội',NULL,'Ghi chú người cao tuổi',NULL,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 11:26:13.192497','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 08:03:52.470057',NULL,NULL,'0001-01-01',0,'0001-01-01','Deleted','Thói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\nThói quen sinh hoạt\n','Anh/Em'),(16,'Nguyễn Thị Mai ','112233445566','1970-11-11','Female','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fa6a0ff9b-da47-4e6d-955d-163478972781.jpg?alt=media&token=acbb1248-0f33-493b-b6ee-bcdc1ab0155d',' Biên hòa, Bình Dương',NULL,'Không Có',33,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 15:43:27.028986','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:02:49.743381',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','Buổi sáng:\nThức dậy: Thực hiện vệ sinh cá nhân và tập thể dục nhẹ nhàng.\nĂn sáng: Bữa sáng với thực đơn nhẹ nhàng, lành mạnh.\nBuổi trưa:\nĂn trưa: Tiêu thụ các món ăn giàu dinh dưỡng.\nNghỉ ngơi: Ngủ trưa ngắn để hồi phục năng lượng.\nBuổi chiều:\nHoạt động giải trí: Tham gia các hoạt động như đọc sách, chơi cờ, hoặc xem TV.\nTắm rửa: Chuẩn bị cho bữa tối.\nBuổi tối:\nĂn tối: Bữa tối nhẹ nhàng, dễ tiêu hóa.\nThư giãn và nghỉ ngơi: Thư giãn bằng cách nghe nhạc, đọc sách, và chuẩn bị đi ngủ.','Anh/Em'),(17,'Lê Văn Hoàng','074202004731','1968-05-08','Male','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F5de0bc8c-deca-4531-8642-a3577e717859.jpg?alt=media&token=1a5b1dc3-9fa4-428b-bee9-10e4e300af39',' Biên hòa, Bình Dương',NULL,'Người già đãng trí ',33,'08dcbc07-6864-4aca-8b85-d654af70c13a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 02:22:57.275612','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:45:20.230262',NULL,NULL,'0001-01-01',0,'0001-01-01','Active','1. Buổi Sáng:\nThức Dậy và Vệ Sinh Cá Nhân: Bác An thường thức dậy vào lúc 6:00 sáng. Sau khi rửa mặt và đánh răng, bác được nhân viên giúp đỡ trong việc thay quần áo và chuẩn bị cho ngày mới.\nBữa Sáng: Khoảng 7:00 sáng, bác An dùng bữa sáng với cháo và một ly sữa ấm. Bữa sáng được thiết kế đặc biệt để đảm bảo dinh dưỡng và dễ tiêu hóa cho người cao tuổi.\n2. Hoạt Động Buổi Sáng:\nTập Thể Dục Nhẹ: Sau bữa sáng, bác An thường tham gia vào một buổi tập thể dục nhẹ, bao gồm các động tác dưỡng sinh và đi bộ trong khu vườn của viện dưỡng lão. Đây là hoạt động giúp bác duy trì sự linh hoạt và tăng cường sức khỏe.\nTham Gia Câu Lạc Bộ: Khoảng 9:00 sáng, bác An tham gia câu lạc bộ đọc sách cùng với các bạn đồng niên. Đây là khoảng thời gian thư giãn và giúp bác duy trì trí nhớ tốt.\n3. Buổi Trưa:\nBữa Trưa: Vào lúc 11:30, bác An dùng bữa trưa với thực đơn được cân nhắc kỹ lưỡng về dinh dưỡng, bao gồm cơm, cá, rau củ, và một món tráng miệng nhẹ.\nGiờ Nghỉ Trưa: Sau bữa trưa, bác An có thời gian nghỉ ngơi khoảng 1-2 tiếng. Bác thường nằm nghỉ trong phòng riêng, tận hưởng không gian yên tĩnh.\n4. Buổi Chiều:\nHoạt Động Ngoài Trời: Khoảng 3:00 chiều, bác An thích ra ngoài ngồi dưới bóng cây hoặc tham gia các hoạt động ngoài trời như trồng cây, chăm sóc vườn hoa.\nChơi Cờ Tướng: Buổi chiều còn là thời gian bác An thường chơi cờ tướng với bạn bè, một hoạt động yêu thích giúp bác rèn luyện trí não.\n5. Buổi Tối:\nBữa Tối: Vào lúc 6:00 chiều, bác An dùng bữa tối với thực đơn nhẹ nhàng, dễ tiêu hóa. Sau bữa tối, bác thường đi dạo một vòng trong khuôn viên viện dưỡng lão để thư giãn.\nSinh Hoạt Nhẹ: Trước khi đi ngủ, bác An thích xem một chương trình truyền hình yêu thích hoặc đọc sách.\nGiờ Đi Ngủ: Khoảng 9:00 tối, bác An chuẩn bị đi ngủ để có một giấc ngủ sâu, chuẩn bị cho ngày mới tràn đầy năng lượng.\n','Con');
/*!40000 ALTER TABLE `Elders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmployeeSchedules`
--

DROP TABLE IF EXISTS `EmployeeSchedules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EmployeeSchedules` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `EmployeeTypeId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `CareScheduleId` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_EmployeeSchedules_EmployeeTypeId` (`EmployeeTypeId`),
  KEY `IX_EmployeeSchedules_UserId` (`UserId`),
  KEY `IX_EmployeeSchedules_CareScheduleId` (`CareScheduleId`),
  CONSTRAINT `FK_EmployeeSchedules_CareSchedules_CareScheduleId` FOREIGN KEY (`CareScheduleId`) REFERENCES `CareSchedules` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_EmployeeSchedules_EmployeeTypes_EmployeeTypeId` FOREIGN KEY (`EmployeeTypeId`) REFERENCES `EmployeeTypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_EmployeeSchedules_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeSchedules`
--

LOCK TABLES `EmployeeSchedules` WRITE;
/*!40000 ALTER TABLE `EmployeeSchedules` DISABLE KEYS */;
INSERT INTO `EmployeeSchedules` VALUES (1,'08dcb628-3f07-45f8-8280-6ccb6e6fefff',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301960','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301971',NULL,NULL,1),(2,'08dcb61e-8aa1-46c5-82d8-b13b6e32980d',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301975','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301975',NULL,NULL,1),(3,'08dcb61f-e6f2-4330-8f63-a472bd0aca55',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301976','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:58:46.301976',NULL,NULL,1),(4,'08dcb628-3f07-45f8-8280-6ccb6e6fefff',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841439','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841440',NULL,NULL,2),(5,'08dcb61f-e80e-4fa8-8dae-08ddc014eb55',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841440','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841440',NULL,NULL,2),(6,'08dcb61f-e8fe-4752-8d11-e48aca28f2b5',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841440','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:34:54.841440',NULL,NULL,2),(7,'08dcb628-3f07-45f8-8280-6ccb6e6fefff',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426516','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426517',NULL,NULL,3),(8,'08dcb61f-eadd-46b8-8045-1837805db77f',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426517','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426517',NULL,NULL,3),(9,'08dcb61f-ebcb-44cc-82bc-f4ec0a9aee78',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426517','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 16:44:40.426517',NULL,NULL,3),(10,'08dcb61f-ecc0-4838-8063-3077fa843444',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381930','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381950',NULL,NULL,4),(11,'08dcb61f-e8fe-4752-8d11-e48aca28f2b5',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381962','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381962',NULL,NULL,4),(12,'08dcb61f-eadd-46b8-8045-1837805db77f',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381968','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 07:11:21.381970',NULL,NULL,4),(13,'08dcb61f-f53c-4d8e-82e9-b7f7e8e88c0b',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975586','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975604',NULL,NULL,5),(14,'08dcb61f-edad-464a-8e97-5e005200d40d',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975611',NULL,NULL,5),(15,'08dcb61f-eea1-4ffb-8631-86a38de90b48',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975613','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975613',NULL,NULL,5),(16,'08dcb61f-e80e-4fa8-8dae-08ddc014eb55',1,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975614','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975614',NULL,NULL,5),(17,'08dcb61f-ef90-4625-8766-c360f2394e45',2,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975615','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975615',NULL,NULL,5),(18,'08dcb61f-e9eb-41e8-82ad-1e7a0c29486f',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975616','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:59:27.975616',NULL,NULL,5);
/*!40000 ALTER TABLE `EmployeeSchedules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `EmployeeTypes`
--

DROP TABLE IF EXISTS `EmployeeTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `EmployeeTypes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `EmployeeTypes`
--

LOCK TABLES `EmployeeTypes` WRITE;
/*!40000 ALTER TABLE `EmployeeTypes` DISABLE KEYS */;
INSERT INTO `EmployeeTypes` VALUES (1,'NV1','Anonymous','2024-08-06 13:49:05.021669','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474521',NULL,NULL),(2,'NV2','Anonymous','2024-08-06 13:49:05.021667','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939462',NULL,NULL),(3,'NV3','Anonymous','2024-08-06 13:49:05.021598','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276822',NULL,NULL);
/*!40000 ALTER TABLE `EmployeeTypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `FamilyMembers`
--

DROP TABLE IF EXISTS `FamilyMembers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `FamilyMembers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DateOfBirth` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Relationship` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ElderId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `Gender` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_FamilyMembers_ElderId` (`ElderId`),
  CONSTRAINT `FK_FamilyMembers_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `FamilyMembers`
--

LOCK TABLES `FamilyMembers` WRITE;
/*!40000 ALTER TABLE `FamilyMembers` DISABLE KEYS */;
INSERT INTO `FamilyMembers` VALUES (1,'Nguyễn Tuấn Khoa','1997-06-03','0978517548','tuankhoanguyen@gmail.com','đường 3/2, quận 11, TP.HCM','Cháu',NULL,2,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 08:23:32.264817','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 08:32:04.993475',NULL,NULL,'Active','Male'),(3,'Trần Gia Tín','2003-09-12','0379971705','giatintran@gmail.com','Duc Hue, Long An','Cháu',NULL,2,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 10:44:57.217827','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 17:50:37.771038',NULL,NULL,'Deleted','Male'),(4,'Trần Thanh Mai','1987-08-16','0315789477','thanhmai2021@gmail.com','Thanh Mai, Ha Noi','Cháu',NULL,3,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 10:54:02.547046','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 17:51:25.652855',NULL,NULL,'Deleted','Female'),(6,'Nguyễn Thanh Tâm','1984-05-16','0325974123','thanhtam@gmail.com','abc','Anh/Em',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 11:12:05.766838','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 11:12:05.766846',NULL,NULL,'Active','Female'),(7,'Nguyễn Thị Bé','1974-06-20','0978548762','benguyen@gmail.com','Long An','Anh/Em',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 11:38:28.450456','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 13:20:26.274254',NULL,NULL,'Deleted','Female'),(8,'Võ Quế Anh','1924-08-09','0978517666','Queanhvo@gmail.com','abc','Ba/mẹ',NULL,3,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 13:24:11.321964','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 13:24:33.207675',NULL,NULL,'Deleted','Female'),(25,'Edogawa Conan','1994-08-10','0245871994','edogawaconan@gmail.com','???','Cháu',NULL,11,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 10:32:01.283021','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 10:32:27.311095',NULL,NULL,'Active','Male'),(27,'Nguyễn Trung Trực','2006-08-10','0325974123','anguyen@gmail.com','abc dce','Ba/mẹ',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 15:32:55.904411','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 15:37:11.776191',NULL,NULL,'Active','Male'),(28,'Lê Thị Kiều Diễm','2006-08-10','0325974114','asvsh@gmail.com','dcee','Ba/mẹ',NULL,1,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:42:39.065728','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 16:42:39.065842',NULL,NULL,'Active','Female'),(29,'Lê Thị Thơ','1997-08-13','0373625784','Letho@gmail.com','Long An','Cháu',NULL,3,'08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 16:16:02.710480','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 16:16:41.589192',NULL,NULL,'Active','Female'),(30,'Nguyễn Thị Thùy','1992-08-13','0373615779','thuynguyen@yopmail.com','Long An','Cháu',NULL,13,'08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-13 16:54:03.274932','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-13 16:54:03.274933',NULL,NULL,'Active','Female');
/*!40000 ALTER TABLE `FamilyMembers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Feedbacks`
--

DROP TABLE IF EXISTS `Feedbacks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Feedbacks` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `OrderDetailId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Ratings` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Feedbacks_OrderDetailId` (`OrderDetailId`),
  KEY `IX_Feedbacks_UserId` (`UserId`),
  CONSTRAINT `FK_Feedbacks_OrderDetails_OrderDetailId` FOREIGN KEY (`OrderDetailId`) REFERENCES `OrderDetails` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Feedbacks_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Feedbacks`
--

LOCK TABLES `Feedbacks` WRITE;
/*!40000 ALTER TABLE `Feedbacks` DISABLE KEYS */;
/*!40000 ALTER TABLE `Feedbacks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HealthCategories`
--

DROP TABLE IF EXISTS `HealthCategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HealthCategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HealthCategories`
--

LOCK TABLES `HealthCategories` WRITE;
/*!40000 ALTER TABLE `HealthCategories` DISABLE KEYS */;
INSERT INTO `HealthCategories` VALUES (1,'Huyết áp','https://thanhnien.mediacdn.vn/Uploaded/ngocquy/2021_10_30/1-huyet-ap-shutterstock-6379.jpeg','Đo các chỉ số liên quan đến huyết áp','Active'),(3,'Cholesterol','https://media.gettyimages.com/id/1413404652/vector/cholesterol-education-month-september-vector.jpg?s=612x612&w=gi&k=20&c=Q4dSiTTOlce99S6BqIdc0O8KPMiuJmb2_1wvoD8uGxU=','Theo dõi các chỉ số liên quan đến cholesterol trong máu','Active'),(4,'Phổi','https://img.lovepik.com/free-png/20210926/lovepik-lung-png-image_401431526_wh1200.png','Theo dõi các chỉ số liên quan đến phổi','Active'),(5,'Thận','https://media.istockphoto.com/id/1317973249/vi/vec-to/%E1%BA%A3nh-minh-h%E1%BB%8Da-s%E1%BB%8Fi-th%E1%BA%ADn-%C4%91%C6%B0%E1%BB%A3c-ph%C3%A2n-l%E1%BA%ADp-tr%C3%AAn-n%E1%BB%81n-tr%E1%BA%AFng-kh%C3%A1i-ni%E1%BB%87m-v%E1%BB%81-b%E1%BB%87nh-th%E1%BA%ADn.jpg?s=1024x1024&w=is&k=20&c=dS0VdCfCyKg4OsaBslB2zS9WrCD2x41WMKE6ZTdXXAA=','Theo dõi các chỉ số liên quan đến thận','Active'),(7,'Dissociative Identity Disorder',NULL,'','Deleted'),(8,'Nhịp tim','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff5bd2ac5-7ad4-4032-8587-8e233218e291.jpg?alt=media&token=b8826ffd-75c6-460c-a03b-e29a0f923034','Theo dõi chỉ số liên quan đến nhịp tim','Active'),(9,'Độ oxy trong máu','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fd8b6ba3b-0cbc-4453-bcea-28ff60f9ea4a.jpg?alt=media&token=dc1de807-c690-4dbc-bb48-b6f076ef1a96','Theo dõi chỉ số liên quan đến độ oxy trong máu','Active'),(10,'Điện giải','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fa6930403-5512-4145-bf8a-45cf1e988b06.jpg?alt=media&token=2a078155-6222-4e10-a8bd-976aa36b0b49','Theo dõi chỉ số điện dãi','Active'),(11,'Hemoglobin','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F813f09c1-8c95-4a1a-ac91-e209d9b06974.jpg?alt=media&token=cadc5add-077e-40c8-a252-d5f18670808c','Theo dõi chỉ số sức khỏe hemoglobin','Active');
/*!40000 ALTER TABLE `HealthCategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HealthReportDetailMeasures`
--

DROP TABLE IF EXISTS `HealthReportDetailMeasures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HealthReportDetailMeasures` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Value` float NOT NULL,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `MeasureUnitId` int NOT NULL,
  `HealthReportDetailId` int NOT NULL,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_HealthReportDetailMeasures_HealthReportDetailId` (`HealthReportDetailId`),
  KEY `IX_HealthReportDetailMeasures_MeasureUnitId` (`MeasureUnitId`),
  CONSTRAINT `FK_HealthReportDetailMeasures_HealthReportDetails_HealthReportD~` FOREIGN KEY (`HealthReportDetailId`) REFERENCES `HealthReportDetails` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_HealthReportDetailMeasures_MeasureUnits_MeasureUnitId` FOREIGN KEY (`MeasureUnitId`) REFERENCES `MeasureUnits` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HealthReportDetailMeasures`
--

LOCK TABLES `HealthReportDetailMeasures` WRITE;
/*!40000 ALTER TABLE `HealthReportDetailMeasures` DISABLE KEYS */;
INSERT INTO `HealthReportDetailMeasures` VALUES (2,5,'',4,2,'Normal'),(3,100,'',1,3,'Normal'),(4,80,'',2,3,'Normal'),(5,100,'',1,4,'Normal'),(6,100,'',2,4,'Warning'),(7,90,'',1,5,'Normal'),(8,80,'',2,5,'Normal'),(10,4,'',4,7,'Normal'),(11,20,'',1,8,'Warning'),(12,100,'Cao hơn bình thường',2,8,'Warning'),(13,90,'Bình thường',1,9,'Normal'),(14,100,'Cao hơn bình thường',2,9,'Warning'),(17,6,'Cao bất thường',4,12,'Warning'),(18,5,'',4,13,'Normal'),(20,90,'',1,15,'Normal'),(21,80,'',2,15,'Normal'),(23,97,'',1,17,'Normal'),(24,80,'Bình thường',2,17,'Normal'),(25,4.2,'',4,18,'Normal'),(27,26,'Bình thường',4,20,'Warning'),(28,90,'',1,21,'Normal'),(29,80,'',2,21,'Normal'),(32,5,'',4,24,'Normal'),(34,56,'Bình thường',1,26,'Warning'),(35,65,'Bình thường',2,26,'Normal'),(37,90,'',1,28,'Normal'),(38,80,'',2,28,'Normal'),(39,4.2,'',4,29,'Normal'),(40,90,'',1,30,'Normal'),(41,100,'Cao bất thường',2,30,'Warning'),(42,56,'',4,31,'Warning'),(43,123,'',9,32,'Warning'),(44,119,'Chỉ số bình thường',1,33,'Normal'),(45,113,'Bất thường',2,33,'Warning'),(46,235,'Khôbg có',4,34,'Warning'),(47,123,'Chỉ số bất thường',5,35,'Warning'),(48,123,'Chỉ số bất thường',9,36,'Warning');
/*!40000 ALTER TABLE `HealthReportDetailMeasures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HealthReportDetails`
--

DROP TABLE IF EXISTS `HealthReportDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HealthReportDetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `HealthCategoryId` int NOT NULL,
  `HealthReportId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_HealthReportDetails_HealthCategoryId` (`HealthCategoryId`),
  KEY `IX_HealthReportDetails_HealthReportId` (`HealthReportId`),
  CONSTRAINT `FK_HealthReportDetails_HealthCategories_HealthCategoryId` FOREIGN KEY (`HealthCategoryId`) REFERENCES `HealthCategories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_HealthReportDetails_HealthReports_HealthReportId` FOREIGN KEY (`HealthReportId`) REFERENCES `HealthReports` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HealthReportDetails`
--

LOCK TABLES `HealthReportDetails` WRITE;
/*!40000 ALTER TABLE `HealthReportDetails` DISABLE KEYS */;
INSERT INTO `HealthReportDetails` VALUES (2,3,2),(3,1,3),(4,1,4),(5,1,5),(7,3,7),(8,1,8),(9,1,9),(12,3,10),(13,3,11),(15,1,12),(17,1,14),(18,3,14),(20,3,15),(21,1,16),(24,3,17),(26,1,19),(28,1,20),(29,3,20),(30,1,21),(31,3,22),(32,8,22),(33,1,23),(34,3,23),(35,4,24),(36,8,24);
/*!40000 ALTER TABLE `HealthReportDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HealthReports`
--

DROP TABLE IF EXISTS `HealthReports`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HealthReports` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ElderId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Date` date NOT NULL DEFAULT '0001-01-01',
  PRIMARY KEY (`Id`),
  KEY `IX_HealthReports_ElderId` (`ElderId`),
  CONSTRAINT `FK_HealthReports_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HealthReports`
--

LOCK TABLES `HealthReports` WRITE;
/*!40000 ALTER TABLE `HealthReports` DISABLE KEYS */;
INSERT INTO `HealthReports` VALUES (1,'Bình thường',1,'08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-06 16:02:05.609945','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-06 16:02:05.609955',NULL,NULL,'2024-08-06'),(2,'Bình thường',1,'08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-06 16:02:59.661274','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-06 16:02:59.661274',NULL,NULL,'2024-08-06'),(3,'Bình thường',5,'08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 06:50:21.960927','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 06:50:21.960955',NULL,NULL,'2024-08-07'),(4,'Bất bình thường',5,'08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 08:35:50.754605','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 08:35:50.754608',NULL,NULL,'2024-08-07'),(5,'Bình thường',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 17:13:59.899073','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 17:13:59.899151',NULL,NULL,'2024-08-08'),(6,'Bình thường',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 23:45:11.595500','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 23:45:11.595567',NULL,NULL,'2024-08-08'),(7,'Bình thường',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 23:46:03.899423','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-07 23:46:03.899438',NULL,NULL,'2024-08-08'),(8,'Phát hiện chỉ số bất thường',1,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-12 09:55:13.407993','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-12 09:55:13.408011',NULL,NULL,'2024-08-12'),(9,'Huyết áp cao mức độ nhẹ',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 08:21:04.514778','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 08:21:04.514801',NULL,NULL,'2024-08-13'),(10,'Choles cao',1,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 10:53:51.900660','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 10:53:51.900680',NULL,NULL,'2024-08-13'),(11,'Đường Huyết Thấp',1,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:43:23.197896','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:43:23.197897',NULL,NULL,'2024-08-13'),(12,'Bình thường',1,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:56:17.812884','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:56:17.812886',NULL,NULL,'2024-08-13'),(13,'Bình thường',1,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:57:46.666440','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 11:57:46.666442',NULL,NULL,'2024-08-13'),(14,'Bình thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 14:30:15.031543','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 14:30:15.031545',NULL,NULL,'2024-08-13'),(15,'Cụ Không Được Khỏe',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 15:58:56.096185','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 15:58:56.096186',NULL,NULL,'2024-08-13'),(16,'Bình thường',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 16:12:18.497351','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 16:12:18.497352',NULL,NULL,'2024-08-13'),(17,'Bình thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 16:27:51.377250','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-13 16:27:51.377251',NULL,NULL,'2024-08-13'),(18,'Bình thường',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-14 01:42:49.042983','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-14 01:42:49.042984',NULL,NULL,'2024-08-14'),(19,'Chỉ Số Bất Thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-14 02:39:05.118551','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-14 02:39:05.118552',NULL,NULL,'2024-08-14'),(20,'Bình Thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-20 09:40:13.516086','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-20 09:40:13.516113',NULL,NULL,'2024-08-20'),(21,'Huyết áp cao',3,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-20 14:10:55.505613','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-20 14:10:55.505615',NULL,NULL,'2024-08-20'),(22,'Trạng thái bất thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-21 05:03:57.427018','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-21 05:03:57.427084',NULL,NULL,'2024-08-21'),(23,'Có một chỉ số bất thường',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-23 05:18:18.664765','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-23 05:18:18.664796',NULL,NULL,'2024-08-23'),(24,'Ngày hôm nay chỉ số không được tốt',13,'08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-23 06:56:37.092586','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-23 06:56:37.092587',NULL,NULL,'2024-08-23');
/*!40000 ALTER TABLE `HealthReports` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Image`
--

DROP TABLE IF EXISTS `Image`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Image` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ContractId` int NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Image_ContractId` (`ContractId`),
  CONSTRAINT `FK_Image_Contracts_ContractId` FOREIGN KEY (`ContractId`) REFERENCES `Contracts` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Image`
--

LOCK TABLES `Image` WRITE;
/*!40000 ALTER TABLE `Image` DISABLE KEYS */;
INSERT INTO `Image` VALUES (1,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fd87c69a4-afa4-4675-924d-0feb4f0ff7e3.jpg?alt=media&token=84cbaf36-35f9-4c96-a92e-088a68ee4691',1),(2,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F2458d46b-eb39-48d5-bcbe-dc7c4eb7ec9b.jpg?alt=media&token=d50600d4-3b64-4abd-8154-7af987e0e2e9',2),(3,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F2dc6b507-353a-4b3e-8261-32cc02a45f1c.jpg?alt=media&token=35adbeb6-79ea-4b09-9652-d2060b8f93e5',3),(4,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fa4f2061f-5666-4e92-ba59-eb5dc608a958.png?alt=media&token=466bc8cb-128f-422e-8749-38a3d7a527c2',4),(5,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F2dc6b507-353a-4b3e-8261-32cc02a45f1c.jpg?alt=media&token=35adbeb6-79ea-4b09-9652-d2060b8f93e5',5),(6,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffb146d3a-a42f-4b00-bff8-5d2043d20de0.png?alt=media&token=85687713-21a1-448a-840e-121bfd6124be',6),(7,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fb1b21986-e809-4389-93be-e18cda3374b7.jpg?alt=media&token=f95e4d9e-b931-455a-918a-3b51072a715f',7),(8,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F2dc6b507-353a-4b3e-8261-32cc02a45f1c.jpg?alt=media&token=35adbeb6-79ea-4b09-9652-d2060b8f93e5',8),(9,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fb2e70edc-7097-402a-ab1f-a20efeed0340.jpg?alt=media&token=fc008287-4e40-4c21-8c04-5bf7b6cbd39d',9),(10,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8ddcbc30-8e4f-445d-81be-a82fa69ac825.jpg?alt=media&token=5874809f-dbba-459c-8321-4c6fbf5bb49a',10),(11,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F60381415-df4e-437c-ba24-54875ebeadbd.jpg?alt=media&token=c7849dcc-6c75-432d-a763-76eb9b05e85c',10),(12,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fad9990f8-e1bd-4692-b589-198051748dbc.jpg?alt=media&token=e552db08-3a8b-407f-8d36-3bade706f2d6',11),(13,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8243bb88-7e79-47ac-8953-c3e591485d19.jpg?alt=media&token=f1258d7f-790d-40de-90c1-77d9dd715f4c',11),(14,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0e77cbbb-f7fe-4370-824d-64185cfb86a1.jpg?alt=media&token=409549a1-2c9d-4afd-ad46-2136e16924c3',12),(15,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0ea208f9-ed1c-4a9b-b32a-90291f2f60f2.jpg?alt=media&token=18644e06-197f-4134-b713-2dc4162edecc',12),(16,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffc0bda68-3fc9-441d-98ab-69235ae44ece.jpg?alt=media&token=11ef0fc0-623c-4db0-a806-0e6e66f7287d',13),(17,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F45d7f0fe-db00-44f9-8e90-8bf79c474c2f.jpg?alt=media&token=9af059ec-211b-49ca-a173-54c7968d7b4a',13),(18,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F4a80348a-8923-49d8-8bd4-f5e1c77b8ff3.jpg?alt=media&token=0ee96651-ee65-4f69-9804-5142b201a5cf',14),(19,'https://taca.edu.vn/wp-content/uploads/2018/12/48361807_1296461240496271_7957931812250976256_n.jpg',14),(20,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffff4de13-4531-4736-bf43-66c4caa09d43.jpg?alt=media&token=67e137a1-680d-4f68-a1cc-4fca5b03c7a8',14),(21,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff65d96f5-ade6-466d-a8ef-af40e859178b.jpg?alt=media&token=206ab779-cc79-4c42-85a1-ae04f5820ec7',14),(22,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F457e68bc-16fd-4c3a-a870-6ddeb3010d4a.jpg?alt=media&token=21a74110-f0ea-4bb2-bf8a-a8c20180a3a1',14),(23,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff8528d15-cd99-4901-b981-ddf18afd429f.jpg?alt=media&token=5ad938ae-e7a2-4578-87e8-082cd49f1c87',14),(24,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0b20caa6-fbda-4a80-b5f5-87514013f714.jpg?alt=media&token=80a7b93d-6483-4b2f-b54f-93022895e637',14),(25,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8976cddb-cf47-4459-8d89-9ba533654eeb.jpg?alt=media&token=039fffe7-716e-4cc7-a53e-e60500736b03',15),(26,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffff4de13-4531-4736-bf43-66c4caa09d43.jpg?alt=media&token=67e137a1-680d-4f68-a1cc-4fca5b03c7a8',15),(27,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F3b290ce6-bea1-4df7-8374-1a784ea9a9f8.jpg?alt=media&token=07f2acd2-61b4-45e0-9545-1703edabf8f9',16),(28,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F3b290ce6-bea1-4df7-8374-1a784ea9a9f8.jpg?alt=media&token=07f2acd2-61b4-45e0-9545-1703edabf8f9',17),(29,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F2a3cd8b8-9e0d-4fb0-9f6e-58d60eb0bdd1.jpg?alt=media&token=e81ae2bb-41b1-4b97-a022-e50994121308',18),(30,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F227988fd-12ca-46db-b6b2-0981f3b3ae31.jpg?alt=media&token=ba0f8284-be4d-44f3-8c3a-541816e19725',19),(31,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fddd1200a-a8ee-4ec9-ae39-b6eaa4038959.jpg?alt=media&token=26e0649a-fc49-4e7c-8e43-3f89f25949ef',19),(32,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff65d96f5-ade6-466d-a8ef-af40e859178b.jpg?alt=media&token=206ab779-cc79-4c42-85a1-ae04f5820ec7',20),(33,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fdb265a69-d6a3-474c-b200-74f60dc0ec2f.jpg?alt=media&token=df195d37-eb8b-4e8a-8ca9-46fa1a2ae1a1',20),(34,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F92e1a9e4-93e1-40c3-807a-88788b1d6363.jpg?alt=media&token=c3e894f0-24de-4503-bfda-8ca5879847c2',21),(35,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F3181d517-31a6-4f94-98ca-9cff40f54109.jpg?alt=media&token=86a76df0-984c-4988-841c-c5fb36178ba2',21),(36,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fcc0a93b2-8156-4d7f-9cd2-461089a3791f.jpg?alt=media&token=1f24b8a8-7c13-4445-a4c3-2ecd2adf88fb',22),(37,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffa4ba5b5-fccb-42e0-92d0-67ef9b3841f8.jpg?alt=media&token=4daf9386-2772-4623-a3cf-5752bf608c7f',22);
/*!40000 ALTER TABLE `Image` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MeasureUnits`
--

DROP TABLE IF EXISTS `MeasureUnits`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MeasureUnits` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UnitType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `HealthCategoryId` int NOT NULL,
  `MaxValue` float NOT NULL DEFAULT '0',
  `MinValue` float NOT NULL DEFAULT '0',
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_MeasureUnits_HealthCategoryId` (`HealthCategoryId`),
  CONSTRAINT `FK_MeasureUnits_HealthCategories_HealthCategoryId` FOREIGN KEY (`HealthCategoryId`) REFERENCES `HealthCategories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MeasureUnits`
--

LOCK TABLES `MeasureUnits` WRITE;
/*!40000 ALTER TABLE `MeasureUnits` DISABLE KEYS */;
INSERT INTO `MeasureUnits` VALUES (1,'Huyết áp tâm thu','mmHg','Áp lực trong động mạch khi tim co bóp',1,120,90,'Active'),(2,'Huyết áp tâm trương','mmHg','Áp lực trong động mạch khi tim nghỉ',1,80,60,'Active'),(4,'Cholesterol toàn phần','mmol/L','Đo lượng cholesterol tổng trong máu',3,5.7,3.9,'Active'),(5,'Dung tích phổi','mL','Dung tích phổi khi hít vào và thở ra',4,6000,3000,'Active'),(6,'Creatinine','mg/dL','Đo mức creatinine trong máu để đánh giá chức năng thận',5,0.6,1.2,'Active'),(8,'não','hzz','',7,12,11.1111,'Active'),(9,'Nhịp','bpm','',8,99,70,'Active'),(10,'SpO2','%','',9,100,95,'Active'),(11,'Natri','mEq/L','',10,145,135,'Active'),(12,'Kali','mEq/L','',10,5,3.5,'Active'),(13,'Calcium','mg/dL','',10,10.2,8.5,'Active'),(14,'Hb','g/dL','',11,18,12.2,'Active');
/*!40000 ALTER TABLE `MeasureUnits` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MedicalRecords`
--

DROP TABLE IF EXISTS `MedicalRecords`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MedicalRecords` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `BloodType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Weight` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Height` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UnderlyingDisease` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Note` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ElderId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Move` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_MedicalRecords_ElderId` (`ElderId`),
  CONSTRAINT `FK_MedicalRecords_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MedicalRecords`
--

LOCK TABLES `MedicalRecords` WRITE;
/*!40000 ALTER TABLE `MedicalRecords` DISABLE KEYS */;
INSERT INTO `MedicalRecords` VALUES (1,'AB-','40','160','Tim, huyết áp','Di chuyển yếu',1,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:54:57.056001',NULL,NULL,NULL),(2,'Chưa có','0','0',NULL,NULL,2,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:59:55.849143',NULL,NULL,NULL),(3,'AB-','70','175','string','string',3,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:52:22.427954','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 09:34:49.415815',NULL,NULL,NULL),(4,'O','57','13','Không ',NULL,4,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 19:44:08.810812','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 19:44:08.810813',NULL,NULL,NULL),(5,'AB-','70','175',NULL,NULL,5,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:30.940630','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:30.940631',NULL,NULL,NULL),(6,'Chưa có','70','200','d','d',6,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:59:47.843148',NULL,NULL,NULL),(7,'B','55','160','Bình Thường',NULL,7,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:57:42.770193',NULL,NULL,NULL),(8,'B','50','170','không có ','không có ',8,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 16:38:16.190004',NULL,NULL,NULL),(9,'A-','30','160','hay ốm vặt ','',9,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:52:07.855537',NULL,NULL,NULL),(10,NULL,NULL,NULL,NULL,NULL,10,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:00:45.864435',NULL,NULL,NULL),(11,'Chưa có','0','0','','',11,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:59:32.640305',NULL,NULL,NULL),(12,NULL,NULL,NULL,NULL,NULL,12,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:49:48.681109',NULL,NULL,NULL),(13,'A','22','175',NULL,NULL,13,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 03:39:35.816066',NULL,NULL,NULL),(14,'AB','22','175',NULL,NULL,14,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:01:34.070651',NULL,NULL,NULL),(15,'AB','23','150','Bệnh lý trước đó','sức khỏe',15,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 16:28:24.749736',NULL,NULL,NULL),(16,'B','55','150','khoong cos ','thoong tin ',16,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:02:49.743384',NULL,NULL,NULL),(17,'B','60','160',NULL,NULL,17,NULL,NULL,'08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:45:20.230264',NULL,NULL,NULL);
/*!40000 ALTER TABLE `MedicalRecords` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MonthlyCalendarDetailShift`
--

DROP TABLE IF EXISTS `MonthlyCalendarDetailShift`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MonthlyCalendarDetailShift` (
  `NurseSchedulersId` int NOT NULL,
  `ShiftsId` int NOT NULL,
  PRIMARY KEY (`NurseSchedulersId`,`ShiftsId`),
  KEY `IX_MonthlyCalendarDetailShift_ShiftsId` (`ShiftsId`),
  CONSTRAINT `FK_MonthlyCalendarDetailShift_MonthlyCalendarDetails_NurseSched~` FOREIGN KEY (`NurseSchedulersId`) REFERENCES `MonthlyCalendarDetails` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_MonthlyCalendarDetailShift_Shifts_ShiftsId` FOREIGN KEY (`ShiftsId`) REFERENCES `Shifts` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MonthlyCalendarDetailShift`
--

LOCK TABLES `MonthlyCalendarDetailShift` WRITE;
/*!40000 ALTER TABLE `MonthlyCalendarDetailShift` DISABLE KEYS */;
INSERT INTO `MonthlyCalendarDetailShift` VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,1),(10,1),(11,1),(22,1),(23,1),(24,1),(25,1),(26,1),(27,1),(28,1),(29,1),(30,1),(31,1),(43,1),(44,1),(45,1),(46,1),(47,1),(48,1),(49,1),(50,1),(51,1),(52,1),(12,2),(13,2),(14,2),(15,2),(16,2),(17,2),(18,2),(19,2),(20,2),(21,2),(32,2),(33,2),(34,2),(35,2),(36,2),(37,2),(38,2),(39,2),(40,2),(41,2),(42,2),(53,2),(54,2),(55,2),(56,2),(57,2),(58,2),(59,2),(60,2),(61,2),(62,2),(1,3),(2,3),(3,3),(4,3),(5,3),(6,3),(7,3),(8,3),(9,3),(10,3),(11,3),(22,3),(23,3),(24,3),(25,3),(26,3),(27,3),(28,3),(29,3),(30,3),(31,3),(43,3),(44,3),(45,3),(46,3),(47,3),(48,3),(49,3),(50,3),(51,3),(52,3),(12,4),(13,4),(14,4),(15,4),(16,4),(17,4),(18,4),(19,4),(20,4),(21,4),(32,4),(33,4),(34,4),(35,4),(36,4),(37,4),(38,4),(39,4),(40,4),(41,4),(42,4),(53,4),(54,4),(55,4),(56,4),(57,4),(58,4),(59,4),(60,4),(61,4),(62,4);
/*!40000 ALTER TABLE `MonthlyCalendarDetailShift` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MonthlyCalendarDetails`
--

DROP TABLE IF EXISTS `MonthlyCalendarDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MonthlyCalendarDetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `MonthlyCalendarId` int NOT NULL,
  `EmployeeTypeId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_MonthlyCalendarDetails_EmployeeTypeId` (`EmployeeTypeId`),
  KEY `IX_MonthlyCalendarDetails_MonthlyCalendarId` (`MonthlyCalendarId`),
  CONSTRAINT `FK_MonthlyCalendarDetails_EmployeeTypes_EmployeeTypeId` FOREIGN KEY (`EmployeeTypeId`) REFERENCES `EmployeeTypes` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_MonthlyCalendarDetails_MonthlyCalendars_MonthlyCalendarId` FOREIGN KEY (`MonthlyCalendarId`) REFERENCES `MonthlyCalendars` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=63 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MonthlyCalendarDetails`
--

LOCK TABLES `MonthlyCalendarDetails` WRITE;
/*!40000 ALTER TABLE `MonthlyCalendarDetails` DISABLE KEYS */;
INSERT INTO `MonthlyCalendarDetails` VALUES (1,1,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474475','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474487',NULL,NULL),(2,4,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474492','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474493',NULL,NULL),(3,7,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474495','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474495',NULL,NULL),(4,10,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474496','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474496',NULL,NULL),(5,13,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474497','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474497',NULL,NULL),(6,16,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474498','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474499',NULL,NULL),(7,19,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474500','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474501',NULL,NULL),(8,22,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474501','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474502',NULL,NULL),(9,25,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474502','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474502',NULL,NULL),(10,28,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474503','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474503',NULL,NULL),(11,31,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474504','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474504',NULL,NULL),(12,2,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474505','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474505',NULL,NULL),(13,5,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474508','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474509',NULL,NULL),(14,8,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474509','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474510',NULL,NULL),(15,11,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474510','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474511',NULL,NULL),(16,14,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474512','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474512',NULL,NULL),(17,17,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474513','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474514',NULL,NULL),(18,20,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474514','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474515',NULL,NULL),(19,23,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474515','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474515',NULL,NULL),(20,26,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474516','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474516',NULL,NULL),(21,29,1,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474517','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:03.474517',NULL,NULL),(22,3,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939434','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939434',NULL,NULL),(23,6,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939435','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939436',NULL,NULL),(24,9,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939438','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939438',NULL,NULL),(25,12,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939439','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939439',NULL,NULL),(26,15,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939440','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939440',NULL,NULL),(27,18,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939441','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939441',NULL,NULL),(28,21,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939442','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939442',NULL,NULL),(29,24,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939447','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939449',NULL,NULL),(30,27,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939451','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939452',NULL,NULL),(31,30,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939453','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939453',NULL,NULL),(32,1,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939454','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939454',NULL,NULL),(33,4,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939454','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939455',NULL,NULL),(34,7,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939455','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939455',NULL,NULL),(35,10,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939456','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939456',NULL,NULL),(36,13,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939456','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939457',NULL,NULL),(37,16,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939458','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939458',NULL,NULL),(38,19,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939458','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939458',NULL,NULL),(39,22,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939459','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939459',NULL,NULL),(40,25,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939460','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939460',NULL,NULL),(41,28,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939460','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939460',NULL,NULL),(42,31,2,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939461','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:16.939461',NULL,NULL),(43,2,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276780','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276781',NULL,NULL),(44,5,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276782','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276782',NULL,NULL),(45,8,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276783','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276783',NULL,NULL),(46,11,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276784','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276784',NULL,NULL),(47,14,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276784','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276785',NULL,NULL),(48,17,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276785','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276786',NULL,NULL),(49,20,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276786','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276787',NULL,NULL),(50,23,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276787','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276787',NULL,NULL),(51,26,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276787','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276788',NULL,NULL),(52,29,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276788','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276788',NULL,NULL),(53,3,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276788','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276792',NULL,NULL),(54,6,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276794','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276794',NULL,NULL),(55,9,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276795','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276795',NULL,NULL),(56,12,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276795','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276795',NULL,NULL),(57,15,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276796','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276796',NULL,NULL),(58,18,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276796','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276796',NULL,NULL),(59,21,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276796','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276797',NULL,NULL),(60,24,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276797','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276797',NULL,NULL),(61,27,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276812','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276820',NULL,NULL),(62,30,3,'08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276820','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:04:26.276821',NULL,NULL);
/*!40000 ALTER TABLE `MonthlyCalendarDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `MonthlyCalendars`
--

DROP TABLE IF EXISTS `MonthlyCalendars`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `MonthlyCalendars` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DateInMonth` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `MonthlyCalendars`
--

LOCK TABLES `MonthlyCalendars` WRITE;
/*!40000 ALTER TABLE `MonthlyCalendars` DISABLE KEYS */;
INSERT INTO `MonthlyCalendars` VALUES (1,1,'Anonymous','2024-08-06 13:49:04.905335','Anonymous','2024-08-06 13:49:04.905335',NULL,NULL),(2,2,'Anonymous','2024-08-06 13:49:04.905334','Anonymous','2024-08-06 13:49:04.905334',NULL,NULL),(3,3,'Anonymous','2024-08-06 13:49:04.905333','Anonymous','2024-08-06 13:49:04.905333',NULL,NULL),(4,4,'Anonymous','2024-08-06 13:49:04.905332','Anonymous','2024-08-06 13:49:04.905332',NULL,NULL),(5,5,'Anonymous','2024-08-06 13:49:04.905331','Anonymous','2024-08-06 13:49:04.905331',NULL,NULL),(6,6,'Anonymous','2024-08-06 13:49:04.905330','Anonymous','2024-08-06 13:49:04.905330',NULL,NULL),(7,7,'Anonymous','2024-08-06 13:49:04.905329','Anonymous','2024-08-06 13:49:04.905329',NULL,NULL),(8,8,'Anonymous','2024-08-06 13:49:04.905328','Anonymous','2024-08-06 13:49:04.905329',NULL,NULL),(9,9,'Anonymous','2024-08-06 13:49:04.905328','Anonymous','2024-08-06 13:49:04.905328',NULL,NULL),(10,10,'Anonymous','2024-08-06 13:49:04.905327','Anonymous','2024-08-06 13:49:04.905327',NULL,NULL),(11,11,'Anonymous','2024-08-06 13:49:04.905326','Anonymous','2024-08-06 13:49:04.905326',NULL,NULL),(12,12,'Anonymous','2024-08-06 13:49:04.905325','Anonymous','2024-08-06 13:49:04.905325',NULL,NULL),(13,13,'Anonymous','2024-08-06 13:49:04.905324','Anonymous','2024-08-06 13:49:04.905325',NULL,NULL),(14,14,'Anonymous','2024-08-06 13:49:04.905323','Anonymous','2024-08-06 13:49:04.905324',NULL,NULL),(15,15,'Anonymous','2024-08-06 13:49:04.905323','Anonymous','2024-08-06 13:49:04.905323',NULL,NULL),(16,16,'Anonymous','2024-08-06 13:49:04.905321','Anonymous','2024-08-06 13:49:04.905322',NULL,NULL),(17,17,'Anonymous','2024-08-06 13:49:04.905320','Anonymous','2024-08-06 13:49:04.905320',NULL,NULL),(18,18,'Anonymous','2024-08-06 13:49:04.905319','Anonymous','2024-08-06 13:49:04.905319',NULL,NULL),(19,19,'Anonymous','2024-08-06 13:49:04.905318','Anonymous','2024-08-06 13:49:04.905318',NULL,NULL),(20,20,'Anonymous','2024-08-06 13:49:04.905316','Anonymous','2024-08-06 13:49:04.905317',NULL,NULL),(21,21,'Anonymous','2024-08-06 13:49:04.905316','Anonymous','2024-08-06 13:49:04.905316',NULL,NULL),(22,22,'Anonymous','2024-08-06 13:49:04.905315','Anonymous','2024-08-06 13:49:04.905315',NULL,NULL),(23,23,'Anonymous','2024-08-06 13:49:04.905314','Anonymous','2024-08-06 13:49:04.905314',NULL,NULL),(24,24,'Anonymous','2024-08-06 13:49:04.905312','Anonymous','2024-08-06 13:49:04.905313',NULL,NULL),(25,25,'Anonymous','2024-08-06 13:49:04.905312','Anonymous','2024-08-06 13:49:04.905312',NULL,NULL),(26,26,'Anonymous','2024-08-06 13:49:04.905311','Anonymous','2024-08-06 13:49:04.905311',NULL,NULL),(27,27,'Anonymous','2024-08-06 13:49:04.905309','Anonymous','2024-08-06 13:49:04.905310',NULL,NULL),(28,28,'Anonymous','2024-08-06 13:49:04.905308','Anonymous','2024-08-06 13:49:04.905308',NULL,NULL),(29,29,'Anonymous','2024-08-06 13:49:04.905307','Anonymous','2024-08-06 13:49:04.905307',NULL,NULL),(30,30,'Anonymous','2024-08-06 13:49:04.905305','Anonymous','2024-08-06 13:49:04.905305',NULL,NULL),(31,31,'Anonymous','2024-08-06 13:49:04.905270','Anonymous','2024-08-06 13:49:04.905298',NULL,NULL);
/*!40000 ALTER TABLE `MonthlyCalendars` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Notifications`
--

DROP TABLE IF EXISTS `Notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Notifications` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ReadAt` datetime(6) DEFAULT NULL,
  `Data` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Level` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_Notifications_UserId` (`UserId`),
  CONSTRAINT `FK_Notifications_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Notifications`
--

LOCK TABLES `Notifications` WRITE;
/*!40000 ALTER TABLE `Notifications` DISABLE KEYS */;
INSERT INTO `Notifications` VALUES (1,'Test Notification','This is a test notification',NULL,'{\"Id\":\"0abcde43-43fc-4190-bba0-5e721247ebbf\",\"Entity\":\"User\"}','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','Anonymous','2024-08-06 15:26:51.463541','Anonymous','2024-08-06 15:26:51.463558',NULL,NULL,'Information'),(2,'Test Notification','This is a test notification',NULL,'{\"Id\":\"20c189df-17b1-4592-b674-5f93f42f7b51\",\"Entity\":\"User\"}','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','Anonymous','2024-08-06 15:27:12.725662','Anonymous','2024-08-06 15:27:12.725664',NULL,NULL,'Information'),(3,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":1,\"Entity\":\"CareSchedule\"}','08dcb61e-8aa1-46c5-82d8-b13b6e32980d','Anonymous','2024-08-06 15:58:46.353961','Anonymous','2024-08-06 15:58:46.353962',NULL,NULL,'Information'),(4,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.','2024-08-07 06:47:58.523028','{\"Id\":1,\"Entity\":\"CareSchedule\"}','08dcb628-3f07-45f8-8280-6ccb6e6fefff','Anonymous','2024-08-06 15:58:46.357280','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 06:47:58.536529',NULL,NULL,'Information'),(5,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":1,\"Entity\":\"CareSchedule\"}','08dcb61f-e6f2-4330-8f63-a472bd0aca55','Anonymous','2024-08-06 15:58:46.355473','Anonymous','2024-08-06 15:58:46.355474',NULL,NULL,'Information'),(6,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn đã được đo chỉ số sức khỏe ngày 06/08/2024','2024-08-06 16:18:27.332043','{\"Id\":1,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-06 16:02:05.652282','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 16:18:27.332196',NULL,NULL,'Information'),(7,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn đã được đo chỉ số sức khỏe ngày 06/08/2024','2024-08-06 16:17:58.847020','{\"Id\":2,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-06 16:02:59.683598','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-06 16:17:58.847135',NULL,NULL,'Information'),(8,'Thông báo lịch trực','Bạn có lịch trực vào tháng 9.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":2,\"Entity\":\"CareSchedule\"}','08dcb61f-e80e-4fa8-8dae-08ddc014eb55','Anonymous','2024-08-06 16:34:54.900368','Anonymous','2024-08-06 16:34:54.900369',NULL,NULL,'Information'),(9,'Thông báo lịch trực','Bạn có lịch trực vào tháng 9.  Vui lòng kiểm tra lịch trình của bạn.','2024-08-07 08:40:20.319692','{\"Id\":2,\"Entity\":\"CareSchedule\"}','08dcb628-3f07-45f8-8280-6ccb6e6fefff','Anonymous','2024-08-06 16:34:54.894220','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 08:40:20.319769',NULL,NULL,'Information'),(10,'Thông báo lịch trực','Bạn có lịch trực vào tháng 9.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":2,\"Entity\":\"CareSchedule\"}','08dcb61f-e8fe-4752-8d11-e48aca28f2b5','Anonymous','2024-08-06 16:34:54.910556','Anonymous','2024-08-06 16:34:54.910557',NULL,NULL,'Information'),(11,'Thông báo lịch trực','Bạn có lịch trực vào tháng 10.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":3,\"Entity\":\"CareSchedule\"}','08dcb61f-eadd-46b8-8045-1837805db77f','Anonymous','2024-08-06 16:44:40.475458','Anonymous','2024-08-06 16:44:40.475459',NULL,NULL,'Information'),(12,'Thông báo lịch trực','Bạn có lịch trực vào tháng 10.  Vui lòng kiểm tra lịch trình của bạn.','2024-08-07 08:40:24.426669','{\"Id\":3,\"Entity\":\"CareSchedule\"}','08dcb628-3f07-45f8-8280-6ccb6e6fefff','Anonymous','2024-08-06 16:44:40.485254','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-07 08:40:24.426822',NULL,NULL,'Information'),(13,'Thông báo lịch trực','Bạn có lịch trực vào tháng 10.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":3,\"Entity\":\"CareSchedule\"}','08dcb61f-ebcb-44cc-82bc-f4ec0a9aee78','Anonymous','2024-08-06 16:44:40.480762','Anonymous','2024-08-06 16:44:40.480763',NULL,NULL,'Information'),(15,'Thông Báo Hợp Đồng Ngày 07/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL12 có hiệu lực vào ngày 07/08/2024.','2024-08-07 15:29:00.828340','{\"Id\":3,\"Entity\":\"Contract\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-07 00:00:08.947693','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-07 15:29:00.848997',NULL,NULL,'Information'),(16,'Báo Cáo Sức Khỏe','Người cao tuổi Houang Triệu Huy đã được đo chỉ số sức khỏe ngày 07/08/2024','2024-08-07 08:41:03.327812','{\"Id\":3,\"Entity\":\"HealthReport\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 06:50:22.161616','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 08:41:03.327965',NULL,NULL,'Information'),(17,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.','2024-08-20 14:12:23.452961','{\"Id\":4,\"Entity\":\"CareSchedule\"}','08dcb61f-ecc0-4838-8063-3077fa843444','Anonymous','2024-08-07 07:11:21.455406','08dcb61f-ecc0-4838-8063-3077fa843444','2024-08-20 14:12:23.453042',NULL,NULL,'Information'),(18,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":4,\"Entity\":\"CareSchedule\"}','08dcb61f-eadd-46b8-8045-1837805db77f','Anonymous','2024-08-07 07:11:21.497558','Anonymous','2024-08-07 07:11:21.497560',NULL,NULL,'Information'),(19,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":4,\"Entity\":\"CareSchedule\"}','08dcb61f-e8fe-4752-8d11-e48aca28f2b5','Anonymous','2024-08-07 07:11:21.501329','Anonymous','2024-08-07 07:11:21.501332',NULL,NULL,'Information'),(20,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024','2024-08-07 08:20:27.843119','{\"Id\":1,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 08:20:16.527190','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 08:20:27.843198',NULL,NULL,'Information'),(21,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Houang Triệu Huy có chỉ số sức khỏe “bất thường” ngày 07/08/2024.','2024-08-07 08:40:57.816285','{\"Id\":4,\"Entity\":\"HealthReport\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 08:35:50.777143','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 08:40:57.817980',NULL,NULL,'Warning'),(22,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024','2024-08-07 08:44:50.030870','{\"Id\":2,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 08:44:44.035706','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 08:44:50.032013',NULL,NULL,'Information'),(23,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-e9eb-41e8-82ad-1e7a0c29486f','Anonymous','2024-08-07 15:59:28.204224','Anonymous','2024-08-07 15:59:28.204226',NULL,NULL,'Information'),(24,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-ef90-4625-8766-c360f2394e45','Anonymous','2024-08-07 15:59:28.199227','Anonymous','2024-08-07 15:59:28.199246',NULL,NULL,'Information'),(25,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-eea1-4ffb-8631-86a38de90b48','Anonymous','2024-08-07 15:59:28.209469','Anonymous','2024-08-07 15:59:28.209471',NULL,NULL,'Information'),(26,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-f53c-4d8e-82e9-b7f7e8e88c0b','Anonymous','2024-08-07 15:59:28.207487','Anonymous','2024-08-07 15:59:28.207489',NULL,NULL,'Information'),(27,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-edad-464a-8e97-5e005200d40d','Anonymous','2024-08-07 15:59:28.211112','Anonymous','2024-08-07 15:59:28.211113',NULL,NULL,'Information'),(28,'Thông báo lịch trực','Bạn có lịch trực vào tháng 8.  Vui lòng kiểm tra lịch trình của bạn.',NULL,'{\"Id\":5,\"Entity\":\"CareSchedule\"}','08dcb61f-e80e-4fa8-8dae-08ddc014eb55','Anonymous','2024-08-07 15:59:28.334367','Anonymous','2024-08-07 15:59:28.334368',NULL,NULL,'Information'),(29,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":3,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 16:31:48.313660','Anonymous','2024-08-07 16:31:48.313661',NULL,NULL,'Information'),(31,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":5,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-07 16:31:48.320160','Anonymous','2024-08-07 16:31:48.320161',NULL,NULL,'Information'),(32,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":6,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-07 16:50:46.272650','Anonymous','2024-08-07 16:50:46.272651',NULL,NULL,'Information'),(34,'Thông Báo Đơn Hàng Ngày 07/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":8,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-07 16:50:46.278270','Anonymous','2024-08-07 16:50:46.278271',NULL,NULL,'Information'),(35,'Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang đã được đo chỉ số sức khỏe ngày 08/08/2024','2024-08-07 17:16:40.920277','{\"Id\":5,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-07 17:14:00.231953','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-07 17:16:40.920750',NULL,NULL,'Information'),(36,'Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang đã được đo chỉ số sức khỏe ngày 08/08/2024','2024-08-10 06:07:53.315902','{\"Id\":6,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-07 23:45:11.752708','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 06:07:53.316361',NULL,NULL,'Information'),(37,'Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang đã được đo chỉ số sức khỏe ngày 08/08/2024','2024-08-09 19:34:53.149542','{\"Id\":7,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-07 23:46:03.930484','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-09 19:34:53.166297',NULL,NULL,'Information'),(38,'Thông Báo Hợp Đồng Ngày 08/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL1012 có hiệu lực vào ngày 08/08/2024.',NULL,'{\"Id\":4,\"Entity\":\"Contract\"}','08dcb64b-96b1-4e12-8a71-84f13e47d292','Anonymous','2024-08-08 00:00:08.211817','Anonymous','2024-08-08 00:00:08.211819',NULL,NULL,'Information'),(39,'Thông Báo Hợp Đồng Ngày 08/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL121 có hiệu lực vào ngày 08/08/2024.',NULL,'{\"Id\":5,\"Entity\":\"Contract\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-08 00:00:08.232398','Anonymous','2024-08-08 00:00:08.232401',NULL,NULL,'Information'),(40,'Thông Báo Hợp Đồng Ngày 08/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL121 có hiệu lực vào ngày 08/08/2024.',NULL,'{\"Id\":8,\"Entity\":\"Contract\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-08 00:00:08.354755','Anonymous','2024-08-08 00:00:08.354757',NULL,NULL,'Information'),(41,'Thông Báo Hợp Đồng Ngày 08/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL1211 có hiệu lực vào ngày 08/08/2024.',NULL,'{\"Id\":9,\"Entity\":\"Contract\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-08 00:00:08.377233','Anonymous','2024-08-08 00:00:08.377235',NULL,NULL,'Information'),(42,'Thông Báo Hợp Đồng Ngày 12/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã HDDL88 có hiệu lực vào ngày 12/08/2024.',NULL,'{\"Id\":16,\"Entity\":\"Contract\"}','08dcb74b-366b-4a70-88f9-5631236a3f1b','Anonymous','2024-08-12 00:00:10.585124','Anonymous','2024-08-12 00:00:10.585159',NULL,NULL,'Information'),(43,'Thông Báo Hợp Đồng Ngày 12/08/2024','Hợp đồng có hiệu lực: Hợp đồng có mã hop đong tu123 có hiệu lực vào ngày 12/08/2024.',NULL,'{\"Id\":15,\"Entity\":\"Contract\"}','08dcb61e-8a1a-4750-81fa-9811238463cd','Anonymous','2024-08-12 00:00:10.593767','Anonymous','2024-08-12 00:00:10.593770',NULL,NULL,'Information'),(44,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn có chỉ số sức khỏe “bất thường” ngày 12/08/2024.','2024-08-13 11:37:39.786953','{\"Id\":8,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-12 09:55:13.682510','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 11:37:39.787113',NULL,NULL,'Warning'),(45,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy có chỉ số sức khỏe “bất thường” ngày 13/08/2024.','2024-08-23 04:18:31.922994','{\"Id\":9,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-13 08:21:04.854087','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-23 04:18:31.945314',NULL,NULL,'Warning'),(47,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":9,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-13 10:50:13.760259','Anonymous','2024-08-13 10:50:13.760263',NULL,NULL,'Information'),(48,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":11,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-13 10:50:13.765517','Anonymous','2024-08-13 10:50:13.765521',NULL,NULL,'Information'),(49,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn có chỉ số sức khỏe “bất thường” ngày 13/08/2024.','2024-08-13 10:54:21.683756','{\"Id\":10,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 10:53:51.957726','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 10:54:21.683846',NULL,NULL,'Warning'),(51,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":14,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-13 11:38:09.252077','Anonymous','2024-08-13 11:38:09.252079',NULL,NULL,'Information'),(52,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":12,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-13 11:38:09.254365','Anonymous','2024-08-13 11:38:09.254366',NULL,NULL,'Information'),(53,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn có chỉ số sức khỏe “bất thường” ngày 13/08/2024.','2024-08-13 11:44:03.762178','{\"Id\":11,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 11:43:23.227429','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 11:44:03.762255',NULL,NULL,'Warning'),(54,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn đã được đo chỉ số sức khỏe ngày 13/08/2024','2024-08-13 15:55:56.273318','{\"Id\":12,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 11:56:17.867959','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 15:55:56.273392',NULL,NULL,'Information'),(55,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Văn Toàn đã được đo chỉ số sức khỏe ngày 13/08/2024','2024-08-13 15:56:03.327041','{\"Id\":13,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 11:57:46.701389','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 15:56:03.327134',NULL,NULL,'Information'),(56,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy đã được đo chỉ số sức khỏe ngày 13/08/2024','2024-08-13 16:26:43.844886','{\"Id\":14,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-13 14:30:15.109260','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-13 16:26:43.844969',NULL,NULL,'Information'),(57,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":17,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-13 15:54:02.011445','Anonymous','2024-08-13 15:54:02.011446',NULL,NULL,'Information'),(58,'Thông Báo Đơn Hàng Ngày 13/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":15,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-13 15:54:02.017301','Anonymous','2024-08-13 15:54:02.017321',NULL,NULL,'Information'),(60,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang có chỉ số sức khỏe “bất thường” ngày 13/08/2024.','2024-08-13 16:10:03.904953','{\"Id\":15,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 15:58:56.140704','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-13 16:10:03.905052',NULL,NULL,'Warning'),(61,'Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang đã được đo chỉ số sức khỏe ngày 13/08/2024',NULL,'{\"Id\":16,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-13 16:12:18.537315','Anonymous','2024-08-13 16:12:18.537316',NULL,NULL,'Information'),(62,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy đã được đo chỉ số sức khỏe ngày 13/08/2024','2024-08-20 06:36:44.426023','{\"Id\":17,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-13 16:27:51.434891','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 06:36:44.442060',NULL,NULL,'Information'),(63,'Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang đã được đo chỉ số sức khỏe ngày 14/08/2024',NULL,'{\"Id\":18,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-14 01:42:49.077221','Anonymous','2024-08-14 01:42:49.077222',NULL,NULL,'Information'),(66,'Thông Báo Đơn Hàng Ngày 14/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":20,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-14 02:33:53.060329','Anonymous','2024-08-14 02:33:53.060331',NULL,NULL,'Information'),(67,'Thông Báo Đơn Hàng Ngày 14/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":18,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-14 02:33:53.064499','Anonymous','2024-08-14 02:33:53.064501',NULL,NULL,'Information'),(68,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy có chỉ số sức khỏe “bất thường” ngày 14/08/2024.','2024-08-14 02:39:43.347471','{\"Id\":19,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-14 02:39:05.167582','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-14 02:39:43.347543',NULL,NULL,'Warning'),(69,'Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy đã được đo chỉ số sức khỏe ngày 20/08/2024','2024-08-20 13:39:17.204327','{\"Id\":20,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-20 09:40:13.701212','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-20 13:39:17.204409',NULL,NULL,'Information'),(70,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Lê Thị Diễm Trang có chỉ số sức khỏe “bất thường” ngày 20/08/2024.',NULL,'{\"Id\":21,\"Entity\":\"HealthReport\"}','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Anonymous','2024-08-20 14:10:55.559401','Anonymous','2024-08-20 14:10:55.559402',NULL,NULL,'Warning'),(71,'Thông Báo Đơn Hàng Ngày 21/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":22,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-21 04:56:58.535516','Anonymous','2024-08-21 04:56:58.535552',NULL,NULL,'Information'),(72,'Thông Báo Đơn Hàng Ngày 21/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":24,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-21 04:56:58.536022','Anonymous','2024-08-21 04:56:58.536024',NULL,NULL,'Information'),(76,'Thông Báo Đơn Hàng Ngày 21/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":26,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-21 04:57:01.259150','Anonymous','2024-08-21 04:57:01.259152',NULL,NULL,'Information'),(77,'Thông Báo Đơn Hàng Ngày 21/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":28,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-21 04:57:01.264894','Anonymous','2024-08-21 04:57:01.264895',NULL,NULL,'Information'),(79,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy có chỉ số sức khỏe “bất thường” ngày 21/08/2024.','2024-08-21 05:04:09.388402','{\"Id\":22,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-21 05:03:57.484473','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-21 05:04:09.388491',NULL,NULL,'Warning'),(80,'Thông Báo Đơn Hàng Ngày 23/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":32,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-23 05:12:05.434603','Anonymous','2024-08-23 05:12:05.434616',NULL,NULL,'Information'),(83,'Thông Báo Đơn Hàng Ngày 23/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":30,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-23 05:12:05.446551','Anonymous','2024-08-23 05:12:05.446556',NULL,NULL,'Information'),(84,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy có chỉ số sức khỏe “bất thường” ngày 23/08/2024.','2024-08-23 05:18:33.478729','{\"Id\":23,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-23 05:18:18.758267','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-23 05:18:33.478841',NULL,NULL,'Warning'),(86,'Thông Báo Đơn Hàng Ngày 23/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":34,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-23 06:50:59.162857','Anonymous','2024-08-23 06:50:59.162865',NULL,NULL,'Information'),(87,'Thông Báo Đơn Hàng Ngày 23/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":36,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-23 06:50:59.191885','Anonymous','2024-08-23 06:50:59.191887',NULL,NULL,'Information'),(89,'Cảnh Báo Báo Cáo Sức Khỏe','Người cao tuổi Nguyễn Thị Bảy có chỉ số sức khỏe “bất thường” ngày 23/08/2024.','2024-08-23 06:58:06.811158','{\"Id\":24,\"Entity\":\"HealthReport\"}','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Anonymous','2024-08-23 06:56:37.138423','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-23 06:58:06.811255',NULL,NULL,'Warning'),(90,'Thông Báo Đơn Hàng Ngày 25/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":39,\"Entity\":\"ScheduledService\"}','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Anonymous','2024-08-25 23:20:05.438466','Anonymous','2024-08-25 23:20:05.438496',NULL,NULL,'Information'),(91,'Thông Báo Đơn Hàng Ngày 25/08/2024','Thông báo xác nhận đăng ký dịch vụ Gói dịch vụ gia hạn Tháng 9 cho tháng 9 Năm 2024',NULL,'{\"Id\":38,\"Entity\":\"ScheduledService\"}','08dcb69f-67c7-43be-81fe-9c26b6a92b08','Anonymous','2024-08-25 23:20:05.451118','Anonymous','2024-08-25 23:20:05.451120',NULL,NULL,'Information');
/*!40000 ALTER TABLE `Notifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `NursingPackages`
--

DROP TABLE IF EXISTS `NursingPackages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `NursingPackages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `RegistrationLimit` int NOT NULL,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Capacity` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `NumberOfNurses` int NOT NULL DEFAULT '0',
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `NursingPackages`
--

LOCK TABLES `NursingPackages` WRITE;
/*!40000 ALTER TABLE `NursingPackages` DISABLE KEYS */;
INSERT INTO `NursingPackages` VALUES (1,'Gói Chăm Sóc Cao Cấp','Gói Chăm Sóc Cao Cấp là gói dịch vụ dưỡng lão cao cấp nhất, mang đến trải nghiệm sống đẳng cấp và chăm sóc toàn diện cho người cao tuổi tại viện dưỡng lão. Gói dịch vụ này được thiết kế để đáp ứng nhu cầu của những người cần sự chăm sóc đặc biệt và mong muốn một môi trường sống sang trọng, tiện nghi.\n\n• Chăm sóc y tế chuyên sâu và cá nhân hóa: \nKhám sức khỏe hàng ngày, quản lý và theo dõi sát sao các bệnh lý mãn tính, dịch vụ y tế tại chỗ với bác sĩ chuyên khoa, và hỗ trợ điều trị bệnh nặng.\n\n• Dịch vụ ăn uống cao cấp: \nThực đơn dinh dưỡng được thiết kế riêng biệt bởi chuyên gia dinh dưỡng, với các món ăn cao cấp và đa dạng, phục vụ tận phòng theo yêu cầu.\n\n• Hỗ trợ vệ sinh cá nhân đặc biệt: \nDịch vụ vệ sinh cá nhân toàn diện, bao gồm các liệu trình chăm sóc da, spa, tắm thảo dược, và cắt tóc tại phòng.\n\n• Dịch vụ giặt là riêng: \nGiặt và chăm sóc quần áo, đồ dùng cá nhân với chất lượng cao nhất, được thực hiện riêng cho từng người.\n\n• Hoạt động giải trí và thư giãn cao cấp: \nCác hoạt động giải trí bao gồm nghệ thuật, âm nhạc, thiền định, yoga, và các liệu trình thư giãn như xoa bóp, vật lý trị liệu cao cấp.\n\n• Dịch vụ vệ sinh phòng riêng biệt: \nPhòng được vệ sinh hàng ngày theo tiêu chuẩn cao cấp, bao gồm dịch vụ dọn dẹp riêng và trang trí không gian sống theo yêu cầu cá nhân.','Normal',12000000.000000000000000000000000000000,100,'https://image.sggp.org.vn/w1000/Uploaded/2024/evofjasfzyr/2022_11_21/23_ODZC.jpg.webp',4,'Anonymous','2024-08-06 13:49:04.693937','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:19:59.852037',NULL,NULL,1,'Active'),(2,'Gói Chăm Sóc Toàn Diện','Gói Chăm Sóc Toàn Diện là một gói dịch vụ dưỡng lão cao cấp, cung cấp sự chăm sóc toàn diện cho người cao tuổi tại viện dưỡng lão. Đây là một lựa chọn lý tưởng cho những người cần được chăm sóc đặc biệt, với các dịch vụ hỗ trợ toàn diện cả về y tế lẫn sinh hoạt hàng ngày.\n\n• Chăm sóc y tế chuyên sâu: \nKiểm tra sức khỏe hàng ngày, quản lý thuốc men chuyên nghiệp, hỗ trợ điều trị các bệnh mãn tính, và dịch vụ cấp cứu 24/7.\n\n• Dịch vụ ăn uống đặc biệt: \nCung cấp các bữa ăn thiết kế riêng biệt dựa trên chế độ dinh dưỡng và tình trạng sức khỏe, với thực đơn thay đổi hàng ngày, bao gồm cả các món ăn kiêng và dinh dưỡng đặc biệt.\n\n• Hỗ trợ vệ sinh cá nhân: \nDịch vụ vệ sinh cá nhân toàn diện bao gồm tắm rửa, thay đồ, cắt tóc, làm móng, và chăm sóc da.\n\n• Dịch vụ giặt là cao cấp: \nGiặt và ủi quần áo cá nhân, chăn ga thường xuyên với chất lượng cao.\n\n• Hoạt động giải trí và phục hồi chức năng: \nTham gia các hoạt động thể dục, vật lý trị liệu, phục hồi chức năng, cũng như các hoạt động giải trí như nghệ thuật, âm nhạc trị liệu, và các buổi sinh hoạt xã hội.\n\n• Dịch vụ vệ sinh phòng cao cấp: \nPhòng được vệ sinh hàng ngày với tiêu chuẩn cao, bao gồm việc thay ga giường, làm sạch khu vực sinh hoạt cá nhân và không gian chung.','Special',9000000.000000000000000000000000000000,150,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F1a152285-8a72-40ed-b6d9-7c30a5d8ab5e.png?alt=media&token=ca9d8667-20d7-4557-9625-3720a85ba82b',5,'Anonymous','2024-08-06 13:49:04.693936','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 17:34:07.539381',NULL,NULL,2,'Active'),(3,'Gói Chăm Sóc Đặc Biệt','Gói Chăm Sóc Đặc Biệt là gói dịch vụ dưỡng lão cao cấp, được thiết kế để cung cấp sự chăm sóc đặc biệt và toàn diện cho người cao tuổi có nhu cầu đặc biệt về sức khỏe hoặc cần sự hỗ trợ đặc biệt trong cuộc sống hàng ngày. Đây là gói dịch vụ dành cho những người cần sự quan tâm chăm sóc ở mức độ cao hơn, với các dịch vụ và tiện nghi đặc biệt.\n\n• Chăm sóc y tế chuyên biệt: \nKhám sức khỏe hàng ngày, theo dõi sát sao tình trạng sức khỏe, quản lý thuốc men chuyên biệt, hỗ trợ điều trị các bệnh lý nghiêm trọng hoặc phức tạp.\n\n• Dịch vụ ăn uống chuyên biệt: \nThực đơn được thiết kế riêng biệt dựa trên nhu cầu dinh dưỡng và chế độ ăn uống đặc biệt của từng cá nhân, với nguyên liệu cao cấp và an toàn tuyệt đối.\n\n• Hỗ trợ vệ sinh cá nhân và chăm sóc đặc biệt: \nDịch vụ chăm sóc cá nhân toàn diện, bao gồm các liệu trình chăm sóc da, chăm sóc tóc, dịch vụ spa và các dịch vụ chăm sóc đặc biệt theo nhu cầu cá nhân.\n\n• Dịch vụ giặt là và chăm sóc đồ dùng riêng: \nQuần áo và đồ dùng cá nhân được chăm sóc và giặt là riêng biệt, đảm bảo chất lượng và sự sạch sẽ tối đa.\n\n• Hoạt động giải trí và trị liệu đặc biệt: \nCác chương trình trị liệu bằng âm nhạc, nghệ thuật, yoga và các hoạt động giải trí đặc biệt được thiết kế riêng biệt để hỗ trợ tinh thần và sức khỏe.\n\n• Dịch vụ vệ sinh phòng cao cấp: \nPhòng được dọn dẹp và bảo dưỡng hàng ngày với tiêu chuẩn cao cấp, có thể tùy chỉnh theo yêu cầu cá nhân.','Vip',7000000.000000000000000000000000000000,200,'https://vienduonglaonhanai.vn/wp-content/uploads/2024/02/425499524_1129059848367861_4681676633479513605_n.jpg',6,'Anonymous','2024-08-06 13:49:04.693935','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:19:34.167257',NULL,NULL,3,'Active'),(4,'Gói Cuối Tuần Thư Giãn','Gói Chăm Sóc Toàn Diện là một gói dịch vụ dưỡng lão cao cấp, cung cấp sự chăm sóc toàn diện cho người cao tuổi tại viện dưỡng lão. Đây là một lựa chọn lý tưởng cho những người cần được chăm sóc đặc biệt, với các dịch vụ hỗ trợ toàn diện cả về y tế lẫn sinh hoạt hàng ngày.\n\n• Chăm sóc y tế chuyên sâu: Kiểm tra sức khỏe hàng ngày, quản lý thuốc men chuyên nghiệp, hỗ trợ điều trị các bệnh mãn tính, và dịch vụ cấp cứu 24/7.\n\n• Dịch vụ ăn uống đặc biệt: Cung cấp các bữa ăn thiết kế riêng biệt dựa trên chế độ dinh dưỡng và tình trạng sức khỏe, với thực đơn thay đổi hàng ngày, bao gồm cả các món ăn kiêng và dinh dưỡng đặc biệt.\n\n• Hỗ trợ vệ sinh cá nhân: Dịch vụ vệ sinh cá nhân toàn diện bao gồm tắm rửa, thay đồ, cắt tóc, làm móng, và chăm sóc da.\n\n• Dịch vụ giặt là cao cấp: Giặt và ủi quần áo cá nhân, chăn ga thường xuyên với chất lượng cao.\n\n• Hoạt động giải trí và phục hồi chức năng: Tham gia các hoạt động thể dục, vật lý trị liệu, phục hồi chức năng, cũng như các hoạt động giải trí như nghệ thuật, âm nhạc trị liệu, và các buổi sinh hoạt xã hội.\n\n• Dịch vụ vệ sinh phòng cao cấp: Phòng được vệ sinh hàng ngày với tiêu chuẩn cao, bao gồm việc thay ga giường, làm sạch khu vực sinh hoạt cá nhân và không gian chung.','Special',1200000.000000000000000000000000000000,120,'https://duonglaothienduc.com/wp-content/uploads/2023/02/thuvien3-1900x900resize_and_crop.jpg',3,'Anonymous','2024-08-06 13:49:04.693862','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:12:19.546454',NULL,NULL,2,'Deleted'),(5,'Gói Thể Thao Năng Động','Gói dịch vụ thể dục thể thao','Vip',900000.000000000000000000000000000000,90,'https://random.com.vn/blog/wp-content/uploads/2020/09/tap-duong-sinh-5-1.jpg',5,'Anonymous','2024-08-06 13:49:04.693504','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-12 06:47:03.797563',NULL,NULL,1,'Deleted'),(6,'Gói Chăm Sóc Cơ Bản','Gói chăm sóc cơ bản bao gồm kiểm tra sức khỏe định kỳ và chăm sóc hàng ngày \n\n• Chăm sóc y tế cơ bản: \nKiểm tra sức khỏe định kỳ, quản lý thuốc men và hỗ trợ khẩn cấp.\n\n• Dịch vụ ăn uống:\nCung cấp 3 bữa ăn chính và 2 bữa phụ mỗi ngày, thực đơn được thiết kế dựa trên nhu cầu dinh dưỡng và sức khỏe của người cao tuổi.\n\n• Vệ sinh cá nhân: \nHỗ trợ vệ sinh hàng ngày, bao gồm tắm rửa, thay đồ, và chăm sóc răng miệng.\n\n• Dịch vụ giặt là: \nGiặt và ủi quần áo, chăn ga định kỳ.\nGiải trí và hoạt động xã hội: Tham gia các hoạt động giải trí như xem phim, nghe nhạc, và các trò chơi nhẹ nhàng. Có các chương trình sinh hoạt chung như yoga, tập thể dục nhẹ nhàng, hoặc thiền định.\n\n• Dịch vụ vệ sinh phòng: \nPhòng được dọn dẹp hàng ngày, bao gồm việc thay ga giường và dọn dẹp khu vực sinh hoạt chung.','Normal',5000000.000000000000000000000000000000,120,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ffd8e949e-2654-4d01-ad22-738a7ee65d6d.jpg?alt=media&token=53398f63-7e5f-45c2-9240-8375a0dcb34a',4,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-06 15:40:06.882975','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 17:36:06.931205',NULL,NULL,1,'Active'),(7,'Annual ssss','123','Normal',100000.000000000000000000000000000000,120,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fc9ba9ced-af0b-4064-ae89-0b4c7ce4a568.jpg?alt=media&token=40cb4f11-e9ce-4464-813b-985b4ad1e092',2,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 17:31:45.542747','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 17:32:20.626193',NULL,NULL,2,'Deleted'),(8,'Gói Chăm Sóc Đa Dạng','Gói Chăm Sóc Đa Dạng là gói dịch vụ linh hoạt và toàn diện, được thiết kế để đáp ứng các nhu cầu khác nhau của người cao tuổi tại viện dưỡng lão. Gói dịch vụ này mang đến nhiều lựa chọn chăm sóc và hỗ trợ, cho phép người cao tuổi và gia đình lựa chọn các dịch vụ phù hợp với tình trạng sức khỏe và mong muốn cá nhân.\n\n• Chăm sóc y tế linh hoạt: \nCác gói khám sức khỏe định kỳ, quản lý thuốc men, hỗ trợ điều trị các bệnh lý mãn tính hoặc cấp tính, tùy chọn theo nhu cầu sức khỏe của từng cá nhân.\n\n• Dịch vụ ăn uống đa dạng: \nThực đơn phong phú và linh hoạt, có thể tùy chọn theo chế độ dinh dưỡng, khẩu vị cá nhân, với các bữa ăn được chuẩn bị kỹ lưỡng và cân bằng dinh dưỡng.\n\n• Hỗ trợ vệ sinh cá nhân: \nDịch vụ vệ sinh cá nhân tùy chọn, bao gồm tắm rửa, thay đồ, cắt tóc, làm móng, với sự hỗ trợ từ nhân viên chuyên nghiệp.\n\n• Dịch vụ giặt là tùy chọn: \nGiặt và ủi quần áo cá nhân với tùy chọn dịch vụ từ cơ bản đến cao cấp, đảm bảo sự sạch sẽ và ngăn nắp.\n\n• Hoạt động giải trí và sinh hoạt phong phú: \nCác hoạt động thể dục, nghệ thuật, văn hóa, và giải trí được tổ chức thường xuyên, với nhiều lựa chọn phù hợp với sở thích và nhu cầu cá nhân.\n\n• Dịch vụ vệ sinh phòng: \nPhòng được vệ sinh định kỳ với tiêu chuẩn cao, có thể tùy chọn dịch vụ dọn dẹp hàng ngày hoặc theo yêu cầu.','Normal',10000000.000000000000000000000000000000,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F1cbbdbd9-e681-4e2e-92da-9aa531a7372c.jpg?alt=media&token=345d46e3-6d4b-4a49-9788-1190d252fccb',2,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:18:03.929538','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:20:17.247675',NULL,NULL,2,'Active');
/*!40000 ALTER TABLE `NursingPackages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OrderDates`
--

DROP TABLE IF EXISTS `OrderDates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OrderDates` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `OrderDetailId` int NOT NULL DEFAULT '0',
  `CompletedAt` datetime(6) DEFAULT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_OrderDates_OrderDetailId` (`OrderDetailId`),
  KEY `IX_OrderDates_UserId` (`UserId`),
  CONSTRAINT `FK_OrderDates_OrderDetails_OrderDetailId` FOREIGN KEY (`OrderDetailId`) REFERENCES `OrderDetails` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_OrderDates_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=156 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OrderDates`
--

LOCK TABLES `OrderDates` WRITE;
/*!40000 ALTER TABLE `OrderDates` DISABLE KEYS */;
INSERT INTO `OrderDates` VALUES (5,'2024-08-07','NotPerformed',7,NULL,NULL),(6,'2024-08-14','Missed',7,NULL,NULL),(7,'2024-08-21','Missed',7,NULL,NULL),(8,'2024-08-28','InComplete',7,NULL,NULL),(9,'2024-08-07','NotPerformed',8,NULL,NULL),(10,'2024-08-08','Complete',8,'2024-08-07 08:57:55.770625','08dcb628-3f07-45f8-8280-6ccb6e6fefff'),(11,'2024-08-09','Missed',8,NULL,NULL),(12,'2024-08-10','Missed',8,NULL,NULL),(17,'2024-09-04','InComplete',10,NULL,NULL),(18,'2024-09-11','InComplete',10,NULL,NULL),(19,'2024-09-18','InComplete',10,NULL,NULL),(20,'2024-09-25','InComplete',10,NULL,NULL),(28,'2024-08-01','NotPerformed',13,NULL,NULL),(29,'2024-08-15','NotPerformed',13,NULL,NULL),(30,'2024-08-22','NotPerformed',13,NULL,NULL),(31,'2024-08-29','NotPerformed',13,NULL,NULL),(32,'2024-08-01','NotPerformed',17,NULL,NULL),(33,'2024-08-08','Missed',17,NULL,NULL),(34,'2024-08-15','Missed',17,NULL,NULL),(35,'2024-08-22','Missed',17,NULL,NULL),(36,'2024-08-29','InComplete',17,NULL,NULL),(45,'2024-08-19','Missed',20,NULL,NULL),(46,'2024-08-23','Missed',20,NULL,NULL),(47,'2024-08-09','NotPerformed',22,NULL,NULL),(48,'2024-08-10','NotPerformed',22,NULL,NULL),(49,'2024-08-11','NotPerformed',22,NULL,NULL),(50,'2024-08-12','NotPerformed',22,NULL,NULL),(51,'2024-08-13','NotPerformed',22,NULL,NULL),(146,'2024-08-26','Complete',72,'2024-08-26 04:35:38.657911','08dcb61f-ecc0-4838-8063-3077fa843444'),(147,'2024-08-27','InComplete',72,NULL,NULL),(148,'2024-08-26','InComplete',73,NULL,NULL),(149,'2024-08-28','InComplete',73,NULL,NULL),(151,'2024-08-26','InComplete',75,NULL,NULL),(152,'2024-08-27','InComplete',75,NULL,NULL),(153,'2024-08-28','InComplete',75,NULL,NULL),(154,'2024-08-24','Complete',76,'2024-08-26 04:34:55.275907','08dcb61f-ecc0-4838-8063-3077fa843444'),(155,'2024-08-25','Complete',76,'2024-08-26 04:34:59.971519','08dcb61f-ecc0-4838-8063-3077fa843444');
/*!40000 ALTER TABLE `OrderDates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OrderDetails`
--

DROP TABLE IF EXISTS `OrderDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OrderDetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Price` decimal(65,30) NOT NULL,
  `Quantity` int NOT NULL,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ServicePackageId` int DEFAULT NULL,
  `ContractId` int DEFAULT NULL,
  `ElderId` int DEFAULT NULL,
  `OrderId` int NOT NULL DEFAULT '0',
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `IsRepeatable` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_OrderDetails_ContractId` (`ContractId`),
  KEY `IX_OrderDetails_ElderId` (`ElderId`),
  KEY `IX_OrderDetails_ServicePackageId` (`ServicePackageId`),
  KEY `IX_OrderDetails_OrderId` (`OrderId`),
  CONSTRAINT `FK_OrderDetails_Contracts_ContractId` FOREIGN KEY (`ContractId`) REFERENCES `Contracts` (`Id`),
  CONSTRAINT `FK_OrderDetails_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`),
  CONSTRAINT `FK_OrderDetails_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_OrderDetails_ServicePackages_ServicePackageId` FOREIGN KEY (`ServicePackageId`) REFERENCES `ServicePackages` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=77 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OrderDetails`
--

LOCK TABLES `OrderDetails` WRITE;
/*!40000 ALTER TABLE `OrderDetails` DISABLE KEYS */;
INSERT INTO `OrderDetails` VALUES (2,9000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Nguyễn Thị Hoa',NULL,2,2,2,'Finalized',0),(3,30000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Lê Thị Diễm Trang',NULL,3,3,3,'Finalized',0),(4,21600000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Nguyễn Thị Định',NULL,4,4,4,'Finalized',0),(5,10800000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Houang Triệu Huy',NULL,5,5,5,'Finalized',0),(7,150000.000000000000000000000000000000,1,'RecurringWeeks','Thanh toán dịch vụ Dịch vụ thể thao người cao tuổi cho người cao tuổi Houang Triệu Huy',4,NULL,5,7,'Repeatable',0),(8,300000.000000000000000000000000000000,1,'One_Time','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe cho người cao tuổi Houang Triệu Huy',5,NULL,5,8,'Finalized',0),(10,200000.000000000000000000000000000000,1,'RecurringWeeks','Dịch vụ thể thao người cao tuổi',4,NULL,5,10,'Repeatable',0),(11,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Nguyễn Văn Toàn',NULL,6,1,11,'Finalized',0),(13,300000.000000000000000000000000000000,1,'RecurringWeeks','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe cho người cao tuổi Houang Triệu Huy',5,NULL,5,13,'Finalized',0),(14,10800000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Houang Triệu Huy',NULL,7,5,14,'Finalized',0),(15,10800000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Houang Triệu Huy',NULL,8,5,15,'Finalized',0),(16,9000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Lê Minh Tâm',NULL,9,6,16,'Finalized',0),(17,400000.000000000000000000000000000000,1,'RecurringWeeks','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe cho người cao tuổi Lê Minh Tâm',5,NULL,6,17,'Repeatable',0),(20,400000.000000000000000000000000000000,1,'RecurringDay','Thanh toán dịch vụ Gói Yoga  cho người cao tuổi Houang Triệu Huy',8,NULL,5,20,'Repeatable',0),(21,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Mai Tài Phến',NULL,10,7,21,'Finalized',0),(22,500000.000000000000000000000000000000,1,'One_Time','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe cho người cao tuổi Mai Tài Phến',5,NULL,7,22,'Finalized',0),(23,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Nguyễn Văn Toàn',NULL,11,8,23,'Finalized',0),(24,10800000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Trần Văn Trung',NULL,12,9,24,'Finalized',0),(25,48000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Trần Thúy Vy',NULL,13,10,25,'Finalized',0),(26,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Lên Đức Minh',NULL,14,11,26,'Finalized',0),(27,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Lê Cap Ngyên',NULL,15,12,27,'Finalized',0),(28,32400000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Mai Tài Phến',NULL,16,7,28,'Finalized',0),(29,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Lê Minh Tâm',NULL,17,6,29,'Finalized',0),(30,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Nguyễn Thị Bảy',NULL,18,13,30,'Finalized',0),(34,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Nguyễn Chí Bảo',NULL,19,14,34,'Finalized',0),(37,60000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi Trần Quốc Sư',NULL,20,15,37,'Finalized',0),(44,120000000.000000000000000000000000000000,1,'One_Time','Thanh toán gói chăm sóc người cao tuổi cho người cao tuổi  Lê Văn Hoàng',NULL,22,17,43,'Finalized',0),(72,140000.000000000000000000000000000000,1,'One_Time','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi cho người cao tuổi Nguyễn Thị Bảy',13,NULL,13,71,'NonRepeatable',0),(73,400000.000000000000000000000000000000,1,'RecurringDay','Thanh toán dịch vụ Dịch vụ Yoga Cho Người Cao Tuổi cho người cao tuổi Nguyễn Thị Bảy',8,NULL,13,72,'Repeatable',0),(75,300000.000000000000000000000000000000,1,'One_Time','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe cho người cao tuổi Nguyễn Thị Hoa',5,NULL,2,74,'NonRepeatable',0),(76,140000.000000000000000000000000000000,1,'One_Time','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi cho người cao tuổi Nguyễn Thị Hoa',13,NULL,2,75,'NonRepeatable',0);
/*!40000 ALTER TABLE `OrderDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Orders`
--

DROP TABLE IF EXISTS `Orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Orders` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Amount` double NOT NULL,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Content` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Method` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `PaymentReferenceId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci DEFAULT NULL,
  `DueDate` date NOT NULL DEFAULT '0001-01-01',
  `PaymentDate` datetime(6) DEFAULT NULL,
  `PaymentUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Orders_UserId` (`UserId`),
  CONSTRAINT `FK_Orders_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=76 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Orders`
--

LOCK TABLES `Orders` WRITE;
/*!40000 ALTER TABLE `Orders` DISABLE KEYS */;
INSERT INTO `Orders` VALUES (2,9000000,'Paid','Người Lớn Tuổi Nguyễn Thị Hoa Đã Thanh Toán Chi Phí Gói Dưỡng Lão Vào Ngày 08/06/2024.','Payment For Nursing Care Service Package','None','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-06 15:27:21.043294','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:27:21.043296',NULL,NULL,'Cash',NULL,'2024-08-06','2024-08-06 15:27:21.040274',NULL),(3,30000000,'Paid','Người Lớn Tuổi Lê Thị Diễm Trang Đã Thanh Toán Chi Phí Gói Dưỡng Lão Vào Ngày 08/06/2024.','Payment For Nursing Care Service Package','None','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-05-06 15:52:22.446878','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 15:52:22.446879',NULL,NULL,'Cash',NULL,'2024-08-06','2024-08-06 15:52:22.446271',NULL),(4,21600000,'Paid','Người Lớn Tuổi Nguyễn Thị Định Đã Thanh Toán Chi Phí Gói Dưỡng Lão Vào Ngày 08/06/2024.','Payment For Nursing Care Service Package','None','08dcb64b-96b1-4e12-8a71-84f13e47d292','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-06 19:44:08.834543','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-06 19:44:08.834544',NULL,NULL,'Cash',NULL,'2024-08-06','2024-08-06 19:44:08.832368',NULL),(5,10800000,'Paid','Người Lớn Tuổi Houang Triệu Huy Đã Thanh Toán Chi Phí Gói Dưỡng Lão Vào Ngày 08/07/2024.','Payment For Nursing Care Service Package','None','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-07 05:25:30.953181','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 05:25:30.953182',NULL,NULL,'Cash',NULL,'2024-08-07','2024-08-07 05:25:30.952603',NULL),(7,150000.00000000003,'Paid','Thanh toán dịch vụ Dịch vụ thể thao người cao tuổi','Thanh toán dịch vụ Dịch vụ thể thao người cao tuổi','Thanh toán dịch vụ Dịch vụ thể thao người cao tuổi','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-06-07 07:14:09.524571','Anonymous','2024-08-07 07:16:20.854762',NULL,NULL,'Momo','2442dacc-71a1-4468-8f71-7c6a92d97419','2024-08-07','2024-08-07 07:16:20.854597','https://test-payment.momo.vn/v2/gateway/pay?t=TU9NT3wyNDQyZGFjYy03MWExLTQ0NjgtOGY3MS03YzZhOTJkOTc0MTk&s=15b252936e2c43106ddde4b4f087d0a450ead0d335bb7b8ef9ca476759bfbeb8'),(8,300000.00000000006,'Paid','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-04-07 08:00:36.521092','Anonymous','2024-08-07 08:01:13.815168',NULL,NULL,'VnPay','72af769a-8189-4792-96fb-b09a736494ee','2024-08-07','2024-08-07 08:01:13.815040','https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=30000000&vnp_Command=pay&vnp_CreateDate=20240807080036&vnp_CurrCode=VND&vnp_IpAddr=127.0.1.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+to%C3%A1n+d%E1%BB%8Bch+v%E1%BB%A5+Ch%C3%A2m+C%E1%BB%A9u+Ph%E1%BB%A5c+H%E1%BB%93i+S%E1%BB%A9c+Kh%E1%BB%8Fe&vnp_OrderType=deposit&vnp_ReturnUrl=http%3A%2F%2Fhomenursingcatone.xyz%3A5000%2Fapi%2Fpayments%2Fvnpay-callback%3FreturnUrl%3Dhttps%3A%2F%2Fcareconnectadmin.vercel.app%2FpaymentStatus&vnp_TmnCode=O0F551ER&vnp_TxnRef=72af769a-8189-4792-96fb-b09a736494ee&vnp_Version=2.1.0&vnp_SecureHash=1adb1285d9fda0999909a758e3631b43a5fd51479401d74a70bc9d6942a0b459f90554d22d6e88016fa443e745c4b01d3a50f944582c888378e6d30acda8b8b0'),(10,200000,'Paid','Gói dịch vụ gia hạn Tháng 9','Gói dịch vụ gia hạn Tháng 9','Gói dịch vụ gia hạn Tháng 9','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-08-07 08:44:54.466809','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 10:05:06.692189',NULL,NULL,'Cash','8e32ac60-4a8c-4612-b941-450421b2618a','2024-08-30','2024-08-13 10:05:06.649916',NULL),(11,60000000,'Paid','Người Lớn Tuổi Nguyễn Văn Toàn Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-07 09:16:53.438719','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 09:16:53.438719',NULL,NULL,'Cash',NULL,'2024-08-07','2024-08-07 09:16:53.412088',NULL),(13,300000.00000000006,'OverDue','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-04-07 14:20:35.466355','Anonymous','2024-08-07 23:10:08.568414',NULL,NULL,'Momo','afca611d-b9c5-4606-b6bf-ea4c2ba48ce3','2024-08-07',NULL,'https://test-payment.momo.vn/v2/gateway/pay?t=TU9NT3xhZmNhNjExZC1iOWM1LTQ2MDYtYjZiZi1lYTRjMmJhNDhjZTM&s=1c93d0e4a55075f9848edce0840e123bc80f67c138422df12738abebc02b4ebc'),(14,10800000,'Paid','Người Lớn Tuổi Houang Triệu Huy Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:09:17.000301','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:09:17.000322',NULL,NULL,'Cash',NULL,'2024-08-07','2024-08-07 15:09:16.815693',NULL),(15,10800000,'Paid','Người Lớn Tuổi Houang Triệu Huy Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-05-07 15:19:17.153262','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 15:19:17.153262',NULL,NULL,'Cash',NULL,'2024-08-07','2024-08-07 15:19:17.152343',NULL),(16,9000000,'Paid','Người Lớn Tuổi Lê Minh Tâm Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-07 16:02:24.318142','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 16:02:24.318153',NULL,NULL,'Cash',NULL,'2024-08-07','2024-08-07 16:02:24.317412',NULL),(17,400000,'Paid','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','2024-04-07 16:06:52.390992','Anonymous','2024-08-07 16:08:12.872621',NULL,NULL,'VnPay','ffc977bd-cae6-4ce8-b0cc-8df841486b41','2024-08-07','2024-08-07 16:08:12.872454','https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=40000000&vnp_Command=pay&vnp_CreateDate=20240807160652&vnp_CurrCode=VND&vnp_IpAddr=127.0.1.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+to%C3%A1n+d%E1%BB%8Bch+v%E1%BB%A5+Ch%C3%A2m+C%E1%BB%A9u+Ph%E1%BB%A5c+H%E1%BB%93i+S%E1%BB%A9c+Kh%E1%BB%8Fe&vnp_OrderType=deposit&vnp_ReturnUrl=http%3A%2F%2Fhomenursingcatone.xyz%3A5000%2Fapi%2Fpayments%2Fvnpay-callback%3FreturnUrl%3Dhttps%3A%2F%2Fcareconnectadmin.vercel.app%2FpaymentStatus&vnp_TmnCode=O0F551ER&vnp_TxnRef=ffc977bd-cae6-4ce8-b0cc-8df841486b41&vnp_Version=2.1.0&vnp_SecureHash=7d0db63e23317eef8b7408ac788569d2f07f332d18c716958b1cbb6fc6790270cce28290fac33fbfb55347148e1fe6aabde61f86c0d6b2cfbd1ea8887d96d150'),(20,400000,'Paid','Thanh toán dịch vụ Gói Yoga ','Thanh toán dịch vụ Gói Yoga ','Thanh toán dịch vụ Gói Yoga ','08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb69f-67c7-43be-81fe-9c26b6a92b08','2024-05-07 23:49:48.684062','Anonymous','2024-08-07 23:50:12.782255',NULL,NULL,'Momo','3aa28f76-64cc-46da-93bf-1636f16f789f','2024-08-08','2024-08-07 23:50:12.781585','https://test-payment.momo.vn/v2/gateway/pay?t=TU9NT3wzYWEyOGY3Ni02NGNjLTQ2ZGEtOTNiZi0xNjM2ZjE2Zjc4OWY&s=40e6f1560d3dcdc66eb69d93d4f73ee225d4379eab6bdb70445ac2185092a522'),(21,60000000,'Paid','Người Lớn Tuổi Mai Tài Phến Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-08 01:51:44.252570','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-08 01:51:44.252572',NULL,NULL,'Cash',NULL,'2024-08-08','2024-08-08 01:51:44.244763',NULL),(22,500000,'OverDue','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb74b-366b-4a70-88f9-5631236a3f1b','2024-04-08 01:58:34.759460','Anonymous','2024-08-08 23:10:09.544598',NULL,NULL,'Momo','84b08875-e744-4d91-b58b-e3badb9df08a','2024-08-08',NULL,'https://test-payment.momo.vn/v2/gateway/pay?t=TU9NT3w4NGIwODg3NS1lNzQ0LTRkOTEtYjU4Yi1lM2JhZGI5ZGYwOGE&s=ff96e1ba8755acc5e3db64b79f30d1a94531a86f23979001044c2cd24268c8d1'),(23,60000000,'Paid','Người Lớn Tuổi toannv Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb6ca-7842-40fe-8086-f724e6188753','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-09 13:53:30.212265','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-09 13:53:30.212288',NULL,NULL,'Cash',NULL,'2024-08-09','2024-08-09 13:53:29.996335',NULL),(24,10800000,'Paid','Người Lớn Tuổi Annual ssss Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-03-10 08:12:11.370352','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 08:12:11.370377',NULL,NULL,'Cash',NULL,'2024-08-10','2024-08-10 08:12:11.189401',NULL),(25,48000000,'Paid','Người Lớn Tuổi toannv Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-03-10 10:20:47.002532','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 10:20:47.002536',NULL,NULL,'Cash',NULL,'2024-08-10','2024-08-10 10:20:47.000545',NULL),(26,60000000,'Paid','Người Lớn Tuổi Annual ssss Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-06-10 10:23:21.074202','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-10 10:23:21.074204',NULL,NULL,'Cash',NULL,'2024-08-10','2024-08-10 10:23:21.073172',NULL),(27,60000000,'Paid','Người Lớn Tuổi Annual ssss Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb61e-8a1a-4750-81fa-9811238463cd','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:43:29.622074','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:43:29.622087',NULL,NULL,'Cash',NULL,'2024-08-11','2024-08-11 22:43:29.476372',NULL),(28,32400000,'Paid','Người Lớn Tuổi Mai Tài Phến Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-11 22:44:32.341801','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-11 22:44:32.341804',NULL,NULL,'Cash',NULL,'2024-08-11','2024-08-11 22:44:32.340022',NULL),(29,60000000,'Paid','Người Lớn Tuổi Lê Minh Tâm Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-05-12 05:05:34.046397','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 05:05:34.046398',NULL,NULL,'Cash',NULL,'2024-08-12','2024-08-12 05:05:34.045979',NULL),(30,60000000,'Paid','Người Lớn Tuổi Nguyễn Thị Bảy Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 07:55:19.192000','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-12 07:55:19.192012',NULL,NULL,'Cash',NULL,'2024-08-12','2024-08-12 07:55:19.032859',NULL),(34,60000000,'Paid','Người Lớn Tuổi toàn  Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcbb82-44a6-4718-8bda-d392c5a12e22','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-13 10:39:20.747945','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 10:39:20.747964',NULL,NULL,'Cash',NULL,'2024-08-13','2024-08-13 10:39:20.685169',NULL),(37,60000000,'Paid','Người Lớn Tuổi nguyeen vanw toan Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-03-13 11:26:13.229591','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 11:26:13.229595',NULL,NULL,'Cash',NULL,'2024-08-13','2024-08-13 11:26:13.225491',NULL),(43,120000000,'Paid','Người Lớn Tuổi Lê Văn Hoàng Đã Thanh Toán Chi Phí Gói Dưỡng Lão.','Payment For Nursing Care Service Package','None','08dcbc07-6864-4aca-8b85-d654af70c13a','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-04-14 02:22:57.289375','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 02:22:57.289376',NULL,NULL,'Cash',NULL,'2024-08-14','2024-08-14 02:22:57.288610',NULL),(71,140000.00000000003,'Paid','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-25 15:23:00.803413','Anonymous','2024-08-25 15:24:02.455031',NULL,NULL,'VnPay','719af487-8f5a-4f05-9515-0e2efc1eaf44','2024-08-25','2024-08-25 15:24:02.453353','https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=14000000&vnp_Command=pay&vnp_CreateDate=20240825152300&vnp_CurrCode=VND&vnp_IpAddr=127.0.1.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+to%C3%A1n+d%E1%BB%8Bch+v%E1%BB%A5+D%E1%BB%8Bch+v%E1%BB%A5+t%E1%BA%AFm+g%E1%BB%99i+cho+ng%C6%B0%E1%BB%9Di+cao+tu%E1%BB%95i&vnp_OrderType=deposit&vnp_ReturnUrl=http%3A%2F%2Fhomenursingcatone.xyz%3A5000%2Fapi%2Fpayments%2Fvnpay-callback%3FreturnUrl%3Dhttps%3A%2F%2Fcareconnectadmin.vercel.app%2FpaymentStatus&vnp_TmnCode=O0F551ER&vnp_TxnRef=719af487-8f5a-4f05-9515-0e2efc1eaf44&vnp_Version=2.1.0&vnp_SecureHash=e5df02de15f4df3f3ddf356a222d20c7735077ebb03c0429f21bd6d0bf862c5fd2810a655191469b065891cd262319b13613254741c486d3159f86546c33422e'),(72,400000,'Paid','Thanh toán dịch vụ Dịch vụ Yoga Cho Người Cao Tuổi','Thanh toán dịch vụ Dịch vụ Yoga Cho Người Cao Tuổi','Thanh toán dịch vụ Dịch vụ Yoga Cho Người Cao Tuổi','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','2024-08-25 15:27:38.818873','Anonymous','2024-08-25 15:28:09.092465',NULL,NULL,'VnPay','046dd475-fa79-49f3-9b87-e72ba7b112c6','2024-08-25','2024-08-25 15:28:09.091788','https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=40000000&vnp_Command=pay&vnp_CreateDate=20240825152738&vnp_CurrCode=VND&vnp_IpAddr=127.0.1.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+to%C3%A1n+d%E1%BB%8Bch+v%E1%BB%A5+D%E1%BB%8Bch+v%E1%BB%A5+Yoga+Cho+Ng%C6%B0%E1%BB%9Di+Cao+Tu%E1%BB%95i&vnp_OrderType=deposit&vnp_ReturnUrl=http%3A%2F%2Fhomenursingcatone.xyz%3A5000%2Fapi%2Fpayments%2Fvnpay-callback%3FreturnUrl%3Dhttps%3A%2F%2Fcareconnectadmin.vercel.app%2FpaymentStatus&vnp_TmnCode=O0F551ER&vnp_TxnRef=046dd475-fa79-49f3-9b87-e72ba7b112c6&vnp_Version=2.1.0&vnp_SecureHash=369538b515d491b922f2334e042bd31dd8598fcb8700d1e3c48b40257a5fc39244906cf77d9627874ca17225d48341067565be05d4bda81ea04dec49aa3e4f0e'),(74,300000.00000000006,'Paid','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','Thanh toán dịch vụ Châm Cứu Phục Hồi Sức Khỏe','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-25 15:37:39.446927','Anonymous','2024-08-25 15:38:19.458175',NULL,NULL,'VnPay','3c09d5e4-253c-480f-8b1d-13827a6994a9','2024-08-25','2024-08-25 15:38:19.458051','https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?vnp_Amount=30000000&vnp_Command=pay&vnp_CreateDate=20240825153739&vnp_CurrCode=VND&vnp_IpAddr=127.0.1.1&vnp_Locale=vn&vnp_OrderInfo=Thanh+to%C3%A1n+d%E1%BB%8Bch+v%E1%BB%A5+Ch%C3%A2m+C%E1%BB%A9u+Ph%E1%BB%A5c+H%E1%BB%93i+S%E1%BB%A9c+Kh%E1%BB%8Fe&vnp_OrderType=deposit&vnp_ReturnUrl=http%3A%2F%2Fhomenursingcatone.xyz%3A5000%2Fapi%2Fpayments%2Fvnpay-callback%3FreturnUrl%3Dhttps%3A%2F%2Fcareconnectadmin.vercel.app%2FpaymentStatus&vnp_TmnCode=O0F551ER&vnp_TxnRef=3c09d5e4-253c-480f-8b1d-13827a6994a9&vnp_Version=2.1.0&vnp_SecureHash=10a5031bd1ac9747706ec442f9425afd1e4a730aeee4de7b9fd97b94ff63b4cf0c929c7f6efb5d07b15102e805e2c677b0acfc1020dfb963a31b40dff9aef009'),(75,140000.00000000003,'Paid','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','Thanh toán dịch vụ Dịch vụ tắm gội cho người cao tuổi','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-23 15:38:59.801515','Anonymous','2024-08-25 15:39:35.646723',NULL,NULL,'VnPay','a0b7e207-c161-4712-98b9-2e5786719c76','2024-08-25','2024-08-25 15:39:35.646585','https://test-payment.momo.vn/v2/gateway/pay?t=TU9NT3xmMGVhNDBhNy0wZmFlLTQxMGQtYTI1MC01NjM0N2RhOTFkNTU&s=c2d7a7255e6000d4de8e71eba230f62453f49bab12d5e287bc34262a6a57bf37');
/*!40000 ALTER TABLE `Orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PotentialCustomerUser`
--

DROP TABLE IF EXISTS `PotentialCustomerUser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PotentialCustomerUser` (
  `PotentialCustomersId` int NOT NULL,
  `UsersId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`PotentialCustomersId`,`UsersId`),
  KEY `IX_PotentialCustomerUser_UsersId` (`UsersId`),
  CONSTRAINT `FK_PotentialCustomerUser_PotentialCustomers_PotentialCustomersId` FOREIGN KEY (`PotentialCustomersId`) REFERENCES `PotentialCustomers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_PotentialCustomerUser_Users_UsersId` FOREIGN KEY (`UsersId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PotentialCustomerUser`
--

LOCK TABLES `PotentialCustomerUser` WRITE;
/*!40000 ALTER TABLE `PotentialCustomerUser` DISABLE KEYS */;
/*!40000 ALTER TABLE `PotentialCustomerUser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PotentialCustomers`
--

DROP TABLE IF EXISTS `PotentialCustomers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PotentialCustomers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `FullName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Status` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Title` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PotentialCustomers`
--

LOCK TABLES `PotentialCustomers` WRITE;
/*!40000 ALTER TABLE `PotentialCustomers` DISABLE KEYS */;
INSERT INTO `PotentialCustomers` VALUES (1,'Nguyễn Văn Tèo','0923324422','Teo@gmail.com','New','Đăng Ký Xem App','Làm thế nào để đăng ký tài khoản mới?','Cao Lỗ Quận 8 Thành Phố Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:23:03.683610','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:23:03.683627',NULL,NULL,'Active'),(2,'Lê Minh Hoàng','0831856550','hoangle@gmail.com','New','Đăng Ký Xem App','Giao diện thân thiện và dễ sử dụng cho người mới bắt đầu.','789 Đường Nguyễn Trãi, Quận 5, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:39:50.644387','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:39:50.644389',NULL,NULL,'Active'),(3,'Phạm Thị Liên','0768034790','lienpham@gmail.com','New','Đăng Ký Xem App','Cập nhật thường xuyên với các tính năng mới và cải tiến.','101 Đường Điện Biên Phủ, Quận Bình Thạnh, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:40:18.368236','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:40:18.368238',NULL,NULL,'Active'),(4,'Hoàng Văn An','0981685286','anhoang@gmail.com','New','Đăng Ký Xem App','Làm thế nào để đăng ký tài khoản mới?','202 Đường Lý Tự Trọng, Quận 1, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:40:47.167368','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:40:47.167370',NULL,NULL,'Active'),(5,'Đặng Văn Hậu','0752121228','haudang@gmail.com','New','Đăng Ký Xem App','Tôi quên mật khẩu, làm thế nào để lấy lại?','404 Đường Trần Hưng Đạo, Quận 1, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:41:48.657460','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:41:48.657462',NULL,NULL,'Active'),(6,'Bùi Thị Phương','0848512691','phuongbui@gmail.com','New','Đăng Ký Xem App','Ứng dụng này có an toàn với thông tin cá nhân của tôi không?','505 Đường Nguyễn Văn Cừ, Quận 5, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:42:32.001937','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:42:32.001939',NULL,NULL,'Active'),(7,'Đỗ Văn Tú','0909922369','tudo@gmail.com','New','Đăng Ký Xem App','Làm sao để tắt thông báo từ ứng dụng?','606 Đường Hoàng Diệu, Quận 4, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:42:58.325262','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:42:58.325264',NULL,NULL,'Active'),(8,'Hồ Thị Kim','0798374418','kimho@gmail.com','New','Đăng Ký Xem App','Tại sao tôi không thể đăng nhập vào tài khoản của mình?','707 Đường Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:43:27.586395','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:43:27.586397',NULL,NULL,'Active'),(9,'Nguyễn Thị Mai','0946603546','mainguyen@gmail.com','New','Đăng Ký Xem App','Ứng dụng có hỗ trợ ngôn ngữ của tôi không?','808 Đường Nguyễn Đình Chiểu, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:44:11.008406','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:44:11.008408',NULL,NULL,'Active'),(10,'Trần Văn Lực','0819035575','luctran@gmail.com','New','Đăng Ký Xem App','Làm thế nào để cập nhật ứng dụng lên phiên bản mới nhất?','909 Đường Trần Quang Khải, Quận 1, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:44:38.507072','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:44:38.507074',NULL,NULL,'Active'),(11,'Lê Thị Thu','0724337164','thule@gmail.com','New','Đăng Ký Xem App','Tôi có thể sử dụng ứng dụng này trên nhiều thiết bị không?','1010 Đường Hai Bà Trưng, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:45:05.221006','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:45:05.221035',NULL,NULL,'Active'),(12,'Phạm Văn Minh','0831478399','minhpham@gmail.com','New','Đăng Ký Xem App','Tại sao ứng dụng chạy chậm hoặc bị đơ?','1111 Đường Lê Lợi, Quận 1, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:46:37.190800','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:46:37.190816',NULL,NULL,'Active'),(13,'Hoàng Thị Lan','0784071234','lanhoang@gmail.com','New','Đăng Ký Xem App','Làm thế nào để xóa tài khoản của tôi?','1212 Đường Nguyễn Thị Minh Khai, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:02.104590','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:02.104592',NULL,NULL,'Active'),(14,'Võ Văn Bình','0871825918','binhvo@gmail.com','New','Đăng Ký Xem App','Ứng dụng có tích hợp với các ứng dụng khác không?','1313 Đường Nam Kỳ Khởi Nghĩa, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:24.368768','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:24.368770',NULL,NULL,'Active'),(15,'Đặng Thị Hương','0908067174','huongdang@gmail.com','New','Đăng Ký Xem App','Làm thế nào để tùy chỉnh giao diện ứng dụng?','1414 Đường Lê Văn Sỹ, Quận Phú Nhuận, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:48.399601','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:47:48.399602',NULL,NULL,'Active'),(16,'Bùi Văn Sơn','0978589388','sonbui@gmail.com','New','Đăng Ký Xem App','Tôi có thể chia sẻ dữ liệu từ ứng dụng với người khác không?','1515 Đường Huỳnh Tấn Phát, Quận 7, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:13.040748','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:13.040750',NULL,NULL,'Active'),(17,'Đỗ Thị Ngọc','0761094882','ngocdo@gmail.com','New','Đăng Ký Xem App','Tại sao tôi không nhận được thông báo từ ứng dụng?','1616 Đường Trần Não, Quận 2, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:36.273499','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:36.273501',NULL,NULL,'Active'),(18,'Hồ Văn Tiến','0949535842','tienho@gmail.com','New','Đăng Ký Xem App','Làm sao để sao lưu và khôi phục dữ liệu trên ứng dụng?','1717 Đường Tô Hiến Thành, Quận 10, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:59.361703','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:48:59.361705',NULL,NULL,'Active'),(19,'Nguyễn Văn Long','0858462723','longnguyen@gmail.com','New','Đăng Ký Xem App','Làm sao để sao lưu và khôi phục dữ liệu trên ứng dụng?','1818 Đường Phan Đăng Lưu, Quận Phú Nhuận, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:49:21.862980','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:49:21.862982',NULL,NULL,'Active'),(20,'Trần Thị Vân','0862459556','vantran@gmail.com','New','Đăng Ký Xem App','Tại sao tôi không thể tải ứng dụng về thiết bị của mình?','1919 Đường Nguyễn Oanh, Quận Gò Vấp, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:49:46.243626','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:49:46.243629',NULL,NULL,'Active'),(21,'Phạm Thị Yến','0852931072','yenpham@gmail.com','Contacted','Đăng Ký Xem App','Có phiên bản ứng dụng nào cho máy tính không?','2121 Đường Hoàng Văn Thụ, Quận Tân Bình, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:50:32.582638','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-08 00:52:37.644186',NULL,NULL,'Active'),(22,'Hoàng Văn Khoa','0937628618','khoahoang@gmail.com','New','Đăng Ký Xem App','Làm thế nào để liên hệ với bộ phận hỗ trợ khách hàng?','2222 Đường Lê Văn Khương, Quận 12, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:50:54.744477','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:50:54.744479',NULL,NULL,'Active'),(23,'Võ Thị Thủy','0774337345','thuyvo@gmail.com','New','Đăng Ký Xem App','Ứng dụng có tiêu tốn nhiều dung lượng dữ liệu không?','2323 Đường Trường Chinh, Quận Tân Bình, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:51:20.120266','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:51:20.120268',NULL,NULL,'Active'),(24,'Đặng Văn Hiếu','0787383057','hieudang@gmail.com','New','Đăng Ký Xem App','Làm thế nào để báo cáo lỗi hoặc góp ý về ứng dụng?','2424 Đường Phan Văn Trị, Quận Bình Thạnh, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:51:44.413486','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:51:44.413488',NULL,NULL,'Active'),(25,'Bùi Thị Thanh','0981957668','thanhbui@gmail.com','Contacted','Đăng Ký Xem App','Ứng dụng có chế độ tối (dark mode) không?','2525 Đường Nguyễn Xí, Quận Bình Thạnh, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:52:05.793135','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 02:44:12.766018',NULL,NULL,'Active'),(26,'Đỗ Văn Phong','0725642363','phongdo@gmail.com','Contacted','Đăng Ký Xem App','Tại sao tôi không thể cập nhật thông tin cá nhân của mình?','2626 Đường Trần Quốc Toản, Quận 3, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:52:27.797519','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:00:55.807874',NULL,NULL,'Active'),(27,'Hồ Thị Xuân','0951465586','xuanho@gmail.com','Contacted','Đăng Ký Xem App','Làm thế nào để khôi phục các thiết lập mặc định của ứng dụng?','2727 Đường Lạc Long Quân, Quận 11, TP. Hồ Chí Minh','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 07:52:50.971953','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-13 14:00:45.905786',NULL,NULL,'Active');
/*!40000 ALTER TABLE `PotentialCustomers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `RoleClaims`
--

DROP TABLE IF EXISTS `RoleClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `RoleClaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_RoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_RoleClaims_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `RoleClaims`
--

LOCK TABLES `RoleClaims` WRITE;
/*!40000 ALTER TABLE `RoleClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `RoleClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Roles` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
INSERT INTO `Roles` VALUES ('08dcb61e-8985-45eb-8977-8923efda62f6','Admin','ADMIN',NULL),('08dcb61e-8992-49d6-804d-b7bdc3e8065b','Director','DIRECTOR',NULL),('08dcb61e-8995-4b2a-8b2b-c4e6fd10366c','Manager','MANAGER',NULL),('08dcb61e-8998-4361-857b-22934a0368e3','Staff','STAFF',NULL),('08dcb61e-899a-4c95-8542-553777363020','Nurse','NURSE',NULL),('08dcb61e-899d-4775-8d76-203b2693f855','Customer','CUSTOMER',NULL);
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Rooms`
--

DROP TABLE IF EXISTS `Rooms`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Rooms` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `BlockId` int NOT NULL,
  `NursingPackageId` int DEFAULT NULL,
  `Index` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Rooms_BlockId` (`BlockId`),
  KEY `IX_Rooms_NursingPackageId` (`NursingPackageId`),
  CONSTRAINT `FK_Rooms_Blocks_BlockId` FOREIGN KEY (`BlockId`) REFERENCES `Blocks` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Rooms_NursingPackages_NursingPackageId` FOREIGN KEY (`NursingPackageId`) REFERENCES `NursingPackages` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Rooms`
--

LOCK TABLES `Rooms` WRITE;
/*!40000 ALTER TABLE `Rooms` DISABLE KEYS */;
INSERT INTO `Rooms` VALUES (1,'P.001','UsableRoom',1,1,0),(2,'P.002','UsableRoom',1,4,0),(3,'P.003','UsableRoom',1,1,0),(4,'P.004','UsableRoom',1,4,0),(5,'P.005','UsableRoom',1,1,0),(6,'P.006','UsableRoom',1,4,0),(7,'P.007','UsableRoom',1,1,0),(8,'P.008','UsableRoom',1,4,0),(9,'P.009','UsableRoom',1,1,0),(10,'P.010','UsableRoom',1,4,0),(11,'P.011','UsableRoom',1,5,0),(12,'P.012','UsableRoom',1,5,0),(13,'P.013','UsableRoom',2,5,0),(14,'P.014','UsableRoom',2,5,0),(15,'P.015','UsableRoom',2,1,0),(16,'P.016','UsableRoom',2,3,0),(17,'P.017','UsableRoom',2,3,0),(18,'P.018','UsableRoom',2,3,0),(19,'P.019','UsableRoom',2,3,0),(20,'P.020','UsableRoom',2,1,0),(21,'P.021','UsableRoom',2,1,0),(22,'P.022','UsableRoom',2,1,0),(23,'P.023','UsableRoom',2,1,0),(24,'P.024','VacantRoom',2,3,0),(25,'P.025','UsableRoom',3,2,0),(26,'P.026','UsableRoom',3,2,0),(27,'P.027','UsableRoom',3,2,0),(28,'P.028','VacantRoom',3,2,0),(29,'P.029','VacantRoom',3,5,0),(30,'P.030','VacantRoom',3,2,0),(31,'P.031','VacantRoom',3,5,0),(32,'P.032','VacantRoom',3,6,0),(33,'P.033','VacantRoom',3,6,0),(34,'P.034','VacantRoom',3,6,0),(35,'P.035','VacantRoom',3,2,0),(36,'P.036','VacantRoom',3,5,0);
/*!40000 ALTER TABLE `Rooms` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ScheduledServiceDetails`
--

DROP TABLE IF EXISTS `ScheduledServiceDetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ScheduledServiceDetails` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ScheduledServiceId` int NOT NULL,
  `ServicePackageId` int DEFAULT NULL,
  `ElderId` int DEFAULT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_ScheduledServiceDetails_ElderId` (`ElderId`),
  KEY `IX_ScheduledServiceDetails_ScheduledServiceId` (`ScheduledServiceId`),
  KEY `IX_ScheduledServiceDetails_ServicePackageId` (`ServicePackageId`),
  CONSTRAINT `FK_ScheduledServiceDetails_Elders_ElderId` FOREIGN KEY (`ElderId`) REFERENCES `Elders` (`Id`),
  CONSTRAINT `FK_ScheduledServiceDetails_ScheduledServices_ScheduledServiceId` FOREIGN KEY (`ScheduledServiceId`) REFERENCES `ScheduledServices` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_ScheduledServiceDetails_ServicePackages_ServicePackageId` FOREIGN KEY (`ServicePackageId`) REFERENCES `ServicePackages` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ScheduledServiceDetails`
--

LOCK TABLES `ScheduledServiceDetails` WRITE;
/*!40000 ALTER TABLE `ScheduledServiceDetails` DISABLE KEYS */;
/*!40000 ALTER TABLE `ScheduledServiceDetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ScheduledServices`
--

DROP TABLE IF EXISTS `ScheduledServices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ScheduledServices` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Status` int NOT NULL,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ScheduledServices_UserId` (`UserId`),
  CONSTRAINT `FK_ScheduledServices_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ScheduledServices`
--

LOCK TABLES `ScheduledServices` WRITE;
/*!40000 ALTER TABLE `ScheduledServices` DISABLE KEYS */;
/*!40000 ALTER TABLE `ScheduledServices` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ScheduledTimes`
--

DROP TABLE IF EXISTS `ScheduledTimes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ScheduledTimes` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Date` date NOT NULL,
  `ScheduledServiceDetailId` int NOT NULL DEFAULT '0',
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ScheduledTimes_ScheduledServiceDetailId` (`ScheduledServiceDetailId`),
  CONSTRAINT `FK_ScheduledTimes_ScheduledServiceDetails_ScheduledServiceDetai~` FOREIGN KEY (`ScheduledServiceDetailId`) REFERENCES `ScheduledServiceDetails` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=246 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ScheduledTimes`
--

LOCK TABLES `ScheduledTimes` WRITE;
/*!40000 ALTER TABLE `ScheduledTimes` DISABLE KEYS */;
/*!40000 ALTER TABLE `ScheduledTimes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ServicePackageCategories`
--

DROP TABLE IF EXISTS `ServicePackageCategories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ServicePackageCategories` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ServicePackageCategories`
--

LOCK TABLES `ServicePackageCategories` WRITE;
/*!40000 ALTER TABLE `ServicePackageCategories` DISABLE KEYS */;
INSERT INTO `ServicePackageCategories` VALUES (1,'Gói Sức Khỏe và Thể Chất','Deleted'),(2,'Ưu Đãi Dịp Lễ','Deleted'),(3,'Thân Thiện Với Môi Trường','Active'),(4,'Ưu Đãi Cuối Tuần','Deleted'),(5,'Gói Thể Dục Thể Thao','Deleted'),(6,'Gói du lịch ngắn ngày','Deleted'),(11,'Chăm Sóc Sức Khỏe','Deleted'),(12,'Thể Dục Thể Thao','Active'),(13,'Sức khỏe','Active'),(14,'Dịch vụ thẩm mỹ','Active'),(15,'Du Lịch','Active'),(16,'Thân Thiện Với Môi Trường','Deleted'),(17,'Du Lịch 1','Deleted'),(18,'Du Lịch ','Deleted'),(19,'Du Lịch 12','Deleted'),(20,'Thân Thiện Với Môi Trường','Deleted');
/*!40000 ALTER TABLE `ServicePackageCategories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ServicePackageDates`
--

DROP TABLE IF EXISTS `ServicePackageDates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ServicePackageDates` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `DayOfWeek` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci DEFAULT NULL,
  `ServicePackageId` int NOT NULL,
  `RepetitionDay` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ServicePackageDates_ServicePackageId` (`ServicePackageId`),
  CONSTRAINT `FK_ServicePackageDates_ServicePackages_ServicePackageId` FOREIGN KEY (`ServicePackageId`) REFERENCES `ServicePackages` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ServicePackageDates`
--

LOCK TABLES `ServicePackageDates` WRITE;
/*!40000 ALTER TABLE `ServicePackageDates` DISABLE KEYS */;
INSERT INTO `ServicePackageDates` VALUES (1,NULL,3,1),(2,NULL,3,2),(3,NULL,3,3),(4,NULL,3,4),(5,NULL,3,5),(6,NULL,3,10),(7,NULL,3,11),(8,NULL,3,12),(9,NULL,3,13),(10,NULL,3,14),(11,NULL,3,19),(12,NULL,3,20),(13,NULL,3,21),(14,NULL,3,22),(15,NULL,3,23),(16,NULL,3,25),(17,'Monday',4,NULL),(18,'Wednesday',4,NULL),(19,'Friday',4,NULL),(20,'Sunday',4,NULL),(21,NULL,6,1),(22,NULL,6,2),(23,NULL,6,3),(24,NULL,6,4),(25,NULL,6,7),(26,NULL,6,9),(27,NULL,6,10),(28,NULL,6,16),(29,NULL,6,17),(30,NULL,6,18),(31,NULL,6,19),(32,NULL,6,23),(33,NULL,6,24),(34,NULL,6,25),(35,NULL,6,26),(36,NULL,7,1),(37,NULL,7,2),(38,NULL,7,3),(39,NULL,7,7),(40,NULL,7,8),(41,NULL,7,9),(42,NULL,7,10),(43,NULL,7,11),(44,NULL,7,15),(45,NULL,7,17),(46,NULL,7,19),(47,NULL,7,18),(48,NULL,7,16),(49,NULL,7,20),(50,NULL,7,27),(51,NULL,7,28),(52,NULL,7,26),(53,NULL,8,1),(54,NULL,8,2),(55,NULL,8,3),(56,NULL,8,19),(57,NULL,8,21),(58,NULL,8,23),(59,NULL,8,28),(60,NULL,8,26),(92,'Monday',10,NULL),(93,'Friday',10,NULL);
/*!40000 ALTER TABLE `ServicePackageDates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ServicePackages`
--

DROP TABLE IF EXISTS `ServicePackages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ServicePackages` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` decimal(65,30) NOT NULL,
  `Duration` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `RegistrationLimit` int NOT NULL,
  `TimeBetweenServices` int NOT NULL,
  `ImageUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ServicePackageCategoryId` int NOT NULL,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `Type` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  `EndRegistrationDate` date DEFAULT NULL,
  `StartRegistrationDate` date DEFAULT NULL,
  `EventDate` date DEFAULT NULL,
  `State` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`),
  KEY `IX_ServicePackages_ServicePackageCategoryId` (`ServicePackageCategoryId`),
  CONSTRAINT `FK_ServicePackages_ServicePackageCategories_ServicePackageCateg~` FOREIGN KEY (`ServicePackageCategoryId`) REFERENCES `ServicePackageCategories` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ServicePackages`
--

LOCK TABLES `ServicePackages` WRITE;
/*!40000 ALTER TABLE `ServicePackages` DISABLE KEYS */;
INSERT INTO `ServicePackages` VALUES (2,'Chương Trình Viếng Thăm Nghĩa Trang Liệt Sĩ','1. Mô Tả Chương Trình:\nChương trình viếng thăm nghĩa trang liệt sĩ dành cho người cao tuổi nhằm mục đích tạo điều kiện cho các cụ ông, cụ bà có thể tưởng nhớ, tri ân những anh hùng đã hy sinh vì đất nước. Chương trình được tổ chức với sự chú trọng đến an toàn, tiện nghi và sự thoải mái cho người cao tuổi.\n\n2. Các Hoạt Động Chính:\n\nTham Quan Nghĩa Trang Liệt Sĩ: Hướng dẫn viên sẽ dẫn đoàn tham quan khu vực nghĩa trang, giới thiệu về lịch sử và các nhân vật anh hùng được tưởng niệm tại đây.\nLễ Dâng Hoa và Thắp Nến: Tổ chức lễ dâng hoa và thắp nến để bày tỏ lòng thành kính và tri ân đối với các liệt sĩ. Cung cấp các bó hoa tươi và nến để người tham dự có thể tham gia.\nTìm Hiểu Lịch Sử: Cung cấp thông tin và tư liệu về các sự kiện lịch sử liên quan đến các liệt sĩ và cuộc chiến đấu của họ.\nGặp Gỡ và Giao Lưu: Tạo cơ hội để người cao tuổi gặp gỡ và giao lưu với những người cùng tham gia chương trình, chia sẻ cảm xúc và ký ức.\n\n3. Thông Tin Cụ Thể:\n\nThời Lượng: 1 ngày.\nDịch Vụ Bao Gồm:\nVé vào cửa nghĩa trang và các khu vực liên quan.\nHướng dẫn viên chuyên nghiệp và hiểu biết về lịch sử.\nXe đưa đón từ nơi ở đến nghĩa trang và ngược lại.\nHoa, nến và các vật phẩm cần thiết cho lễ dâng hoa và thắp nến.\nCác bữa ăn nhẹ hoặc bữa trưa.\nCông Dụng:\nTạo cơ hội cho người cao tuổi thể hiện lòng thành kính và tri ân các anh hùng liệt sĩ.\nCung cấp môi trường để học hỏi về lịch sử và các sự kiện liên quan.\nCải thiện tinh thần và cảm giác kết nối với lịch sử và di sản văn hóa.\n\n4. Đối Tượng Nên Sử Dụng:\n\nNhững người có lòng yêu nước và muốn tưởng nhớ các anh hùng đã hy sinh vì độc lập và tự do của đất nước.\n\n5. Lưu Ý:\n\nSức Khỏe và An Toàn: Đảm bảo các hoạt động được điều chỉnh phù hợp với sức khỏe của người cao tuổi. Có sự chuẩn bị để hỗ trợ những người cần thiết.\nChuẩn Bị Kỹ Lưỡng: Mang theo các vật dụng cần thiết như thuốc, nước uống, và thiết bị hỗ trợ nếu cần.\nTôn Trọng: Đảm bảo tất cả các hoạt động đều diễn ra trong không khí trang nghiêm và tôn trọng.',150000.000000000000000000000000000000,NULL,50,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F5ae66184-6809-4ede-9547-41b6aab1cd0b.jpg?alt=media&token=47d1fc98-e542-4e8a-a857-85420621739a',3,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-06 17:24:39.694279','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-22 12:12:41.753851',NULL,NULL,'OneDay','2024-08-28',NULL,'2024-08-31','Active'),(3,'Dịch vụ vật lý trị liệu','1. Thời lượng:\n\nLần trị liệu: Mỗi buổi trị liệu thường kéo dài từ 30 phút đến 1 giờ, tùy thuộc vào kế hoạch điều trị cụ thể và tình trạng sức khỏe của từng người.\n\nTần suất: Khuyến nghị từ 2 đến 3 lần mỗi tuần, tuy nhiên, tần suất có thể điều chỉnh theo nhu cầu và sự tiến bộ của người cao tuổi.\n\n2. Công dụng:\n\nCải thiện khả năng vận động: Giúp nâng cao sự linh hoạt, sức mạnh cơ bắp và khả năng di chuyển của người cao tuổi, đặc biệt là sau chấn thương hoặc phẫu thuật.\n\nGiảm đau và căng thẳng cơ bắp: Các liệu pháp như nhiệt trị liệu, siêu âm trị liệu và điện trị liệu giúp giảm đau, căng thẳng và viêm nhiễm cơ bắp.\n\nHỗ trợ phục hồi chức năng: Giúp người cao tuổi phục hồi khả năng vận động, cân bằng và sự tự lập trong sinh hoạt hàng ngày.\n\nPhòng ngừa và điều trị các bệnh lý cơ xương khớp: Cải thiện tình trạng viêm khớp, loãng xương và thoái hóa cột sống, từ đó giảm thiểu nguy cơ té ngã và các vấn đề khác liên quan đến tuổi tác.\n\n3. Đối tượng nên dùng:\n\nNgười cao tuổi: Những người gặp khó khăn trong vận động, có các vấn đề về cơ xương khớp hoặc đang phục hồi sau chấn thương hoặc phẫu thuật.\n\nNgười mắc các bệnh lý mãn tính: Những người bị viêm khớp, loãng xương, thoái hóa cột sống hoặc các bệnh lý liên quan đến cơ xương khớp.\n\nNgười cần cải thiện khả năng vận động: Những người muốn duy trì sự linh hoạt và sức khỏe cơ bắp, giảm đau và cải thiện chất lượng cuộc sống.',300000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F5a66c1e5-1285-46e3-960d-c6e496431fb6.jpg?alt=media&token=72a1c353-35c9-443c-a536-d9990fae2dbd',13,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-06 17:25:57.857693','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-22 12:05:42.632008',NULL,NULL,'MultipleDays',NULL,NULL,NULL,'Active'),(4,'Dịch vụ thể thao người cao tuổi','Yoga dành cho người cao tuổi tập trung vào các bài tập nhẹ nhàng và các kỹ thuật thở, giúp cải thiện sự linh hoạt, cân bằng và sức khỏe tinh thần. Các lớp học yoga này được thiết kế đặc biệt để phù hợp với nhu cầu và khả năng của người cao tuổi, giúp họ duy trì sự linh hoạt và giảm căng thẳng.\n\nChi Tiết:\n\nThời Lượng: 1 đến 1.5 giờ mỗi buổi.\n\nDịch Vụ Bao Gồm:\nLớp học yoga do huấn luyện viên chuyên nghiệp hướng dẫn.\nThảm yoga và các dụng cụ hỗ trợ (như khối yoga, dây đai).\nHướng dẫn về các động tác và kỹ thuật thở phù hợp với người cao tuổi.\n\nCông Dụng:\n\nCải Thiện Sự Linh Hoạt: Các bài tập yoga giúp duy trì và cải thiện sự linh hoạt của cơ thể, giúp người cao tuổi dễ dàng thực hiện các hoạt động hàng ngày.\n\nTăng Cường Cân Bằng: Yoga giúp cải thiện sự cân bằng, giảm nguy cơ té ngã và chấn thương.\n\nGiảm Căng Thẳng: Các kỹ thuật thở và thư giãn trong yoga giúp giảm căng thẳng, lo âu và cải thiện tinh thần.\n\nTăng Cường Sức Khỏe Tinh Thần: Yoga giúp người cao tuổi cảm thấy thư giãn và nâng cao tinh thần, góp phần vào sự khỏe mạnh toàn diện.\n\nĐối Tượng Nên Sử Dụng:\n\nNgười Cao Tuổi: Những người có nhu cầu cải thiện sự linh hoạt và cân bằng, cũng như tìm kiếm một phương pháp giảm căng thẳng nhẹ nhàng.\n\nNgười Có Vấn Đề Về Khớp: Những người gặp khó khăn trong các hoạt động thể chất do các vấn đề về khớp hoặc sức khỏe.\n\nNgười Tìm Kiếm Sự Thư Giãn: Những người muốn tìm một phương pháp thư giãn và cải thiện sức khỏe tinh thần.',50000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F70289702-ea7d-4f5d-95ee-3a73436c7cd4.jpg?alt=media&token=a547c397-c1ef-4900-9ec3-c7a10cf2e9e3',12,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-06 17:26:52.702811','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 02:12:40.315493',NULL,NULL,'WeeklyDays',NULL,NULL,NULL,'Active'),(5,'Châm Cứu Phục Hồi Sức Khỏe','1. Thời lượng:\n\nLần châm cứu: Mỗi buổi châm cứu thường kéo dài từ 30 đến 60 phút, tùy thuộc vào tình trạng sức khỏe và mục tiêu điều trị.\n\nTần suất: Thường khuyến nghị thực hiện từ 1 đến 2 lần mỗi tuần, nhưng tần suất có thể điều chỉnh theo nhu cầu và tiến trình điều trị của từng người.\n\n2. Công dụng:\n\nCải thiện lưu thông máu: Châm cứu giúp kích thích các điểm huyệt trên cơ thể, từ đó cải thiện lưu thông máu và năng lượng, giảm tình trạng tắc nghẽn và đau nhức.\n\nGiảm đau: Hiệu quả trong việc giảm đau cơ, đau lưng, đau khớp, và các triệu chứng đau mạn tính khác. Châm cứu có thể giúp làm giảm cơn đau nhanh chóng và hiệu quả.\n\nHỗ trợ phục hồi chức năng: Giúp phục hồi sức khỏe và chức năng của các bộ phận cơ thể sau chấn thương, phẫu thuật hoặc bệnh lý, đồng thời cải thiện sức khỏe tổng thể.\n\nĐiều trị các vấn đề sức khỏe: Có thể hỗ trợ điều trị các bệnh lý mãn tính như viêm khớp, rối loạn tiêu hóa, mất ngủ, lo âu, và các vấn đề về thần kinh.\n\n3. Đối tượng nên dùng:\n\nNgười cao tuổi: Những người gặp các vấn đề về sức khỏe như đau nhức cơ khớp, rối loạn lưu thông máu, hoặc các vấn đề sức khỏe mãn tính khác.\n\nNgười phục hồi sau chấn thương hoặc phẫu thuật: Những người cần hỗ trợ phục hồi chức năng và giảm đau sau chấn thương hoặc phẫu thuật.\n\nNgười gặp vấn đề về stress hoặc lo âu: Châm cứu có thể giúp giảm căng thẳng, lo âu, và cải thiện chất lượng giấc ngủ.',100000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff3aaed57-5f68-4d1a-b09c-c3d80825186e.jpg?alt=media&token=34eda752-62fe-4af5-9a65-d25dcf3d6bec',1,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-06 18:05:07.447780','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:43:58.791546',NULL,NULL,'AnyDay',NULL,NULL,NULL,'Active'),(6,'Gói Dịch Vụ Chăm Sóc Sau m Viện','Gói dịch vụ chăm sóc cao cấp này được thiết kế đặc biệt để cung cấp sự chăm sóc toàn diện và hỗ trợ hàng ngày cho người cao tuổi.\nDịch vụ bao gồm theo dõi sức khỏe định kỳ, hỗ trợ sinh hoạt cơ bản như ăn uống, vệ sinh cá nhân, và tư vấn dinh dưỡng để đảm bảo sức khỏe và sự thoải mái tối đa.\nCung cấp hỗ trợ về tâm lý và xã hội, bao gồm các hoạt động giải trí và giao tiếp xã hội để nâng cao chất lượng cuộc sống.',350000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F9a561267-1c4d-475f-b7ac-3570a470adb0.png?alt=media&token=192bb70f-5c09-47d3-bc10-1da4b223aef6',1,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 09:26:44.836792','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 09:27:09.152489',NULL,NULL,'MultipleDays',NULL,NULL,NULL,'Deleted'),(7,'Gói Dịch Vụ Chăm Sóc Sau Nằm Viện','Gói dịch vụ chăm sóc cao cấp này được thiết kế đặc biệt để cung cấp sự chăm sóc toàn diện và hỗ trợ hàng ngày cho người cao tuổi.\nDịch vụ bao gồm theo dõi sức khỏe định kỳ, hỗ trợ sinh hoạt cơ bản như ăn uống, vệ sinh cá nhân, và tư vấn dinh dưỡng để đảm bảo sức khỏe và sự thoải mái tối đa.\nCung cấp hỗ trợ về tâm lý và xã hội, bao gồm các hoạt động giải trí và giao tiếp xã hội để nâng cao chất lượng cuộc sống',350000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fc06f2dd2-d54b-4484-a2f0-89d409a5f6a5.png?alt=media&token=8be2a057-e7f4-448e-854b-bc2bde8289b5',1,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 09:28:35.283423','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 14:50:01.809198',NULL,NULL,'MultipleDays',NULL,NULL,NULL,'Deleted'),(8,'Dịch vụ Yoga Cho Người Cao Tuổi','1. Thời lượng:\n\nLớp Yoga: Mỗi buổi lớp yoga thường kéo dài từ 45 đến 60 phút, tùy thuộc vào loại hình yoga và nhu cầu của người tham gia.\n\nTần suất: Khuyến nghị thực hiện từ 1 đến 2 lần mỗi tuần để đạt được lợi ích tối ưu và duy trì sức khỏe lâu dài.\n\n2.  Công dụng:\n\nCải thiện sự linh hoạt: Yoga giúp tăng cường sự linh hoạt của cơ bắp và khớp, giúp người cao tuổi dễ dàng thực hiện các hoạt động hàng ngày và giảm nguy cơ bị chấn thương.\n\nTăng cường sức mạnh cơ bắp: Các tư thế yoga hỗ trợ tăng cường sức mạnh cơ bắp, đặc biệt là các nhóm cơ quan trọng như cơ lưng, cơ bụng và cơ chân.\n\nCải thiện sự cân bằng: Yoga giúp cải thiện sự cân bằng và phối hợp cơ thể, từ đó giảm nguy cơ té ngã và cải thiện khả năng vận động.\n\nGiảm căng thẳng và lo âu: Các bài tập thở và thiền trong yoga giúp giảm căng thẳng, lo âu và cải thiện tâm trạng, tạo cảm giác thư giãn và an lành.\n\nCải thiện giấc ngủ: Yoga giúp cải thiện chất lượng giấc ngủ bằng cách giảm căng thẳng và thư giãn cơ thể, hỗ trợ việc ngủ sâu hơn và ngon hơn.\n\n3. Đối tượng nên dùng:\n\nNgười cao tuổi: Những người muốn duy trì sự linh hoạt, sức mạnh cơ bắp và cải thiện cân bằng, đặc biệt là những người gặp khó khăn trong vận động hoặc có nguy cơ cao về các vấn đề cơ xương khớp.\n\nNgười phục hồi chức năng: Những người đang phục hồi sau chấn thương, phẫu thuật, hoặc mắc các bệnh lý mãn tính cần cải thiện khả năng vận động và sự linh hoạt.\n\nNgười tìm kiếm phương pháp thư giãn: Những người muốn giảm căng thẳng, lo âu và cải thiện chất lượng giấc ngủ.\n\nCác kiểu yoga phù hợp cho người cao tuổi:\n\nHatha Yoga: Tập trung vào các tư thế cơ bản và kỹ thuật thở, phù hợp cho người mới bắt đầu và người cao tuổi để cải thiện sự linh hoạt và sức mạnh cơ bản.\n\nYin Yoga: Tập trung vào các tư thế kéo dài lâu và thư giãn, giúp cải thiện sự linh hoạt và giảm căng thẳng.\n\nGentle Yoga: Các bài tập yoga nhẹ nhàng và điều chỉnh, đặc biệt thiết kế cho người cao tuổi để dễ dàng thực hiện và tránh chấn thương.\n\nChair Yoga: Yoga với sự hỗ trợ của ghế, giúp những người gặp khó khăn trong việc đứng hoặc ngồi trên sàn thực hiện các tư thế yoga an toàn và hiệu quả.',200000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F72c50083-ce87-4b09-b464-401ea95c8cb9.jpg?alt=media&token=f4bd60e1-8d4e-4f32-8b3d-f227bf3ae3fd',12,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-07 16:41:38.950854','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:47:03.535298',NULL,NULL,'MultipleDays',NULL,NULL,NULL,'Active'),(10,'Dịch Vụ Chăm Sóc Da và Làm Đẹp','1. Mô tả Dịch Vụ:\nDịch vụ chăm sóc da bao gồm một loạt các liệu pháp và kỹ thuật được thiết kế để cải thiện và duy trì sức khỏe, sự tươi trẻ của làn da. Các dịch vụ này có thể bao gồm làm sạch, tẩy tế bào chết, massage, đắp mặt nạ, và sử dụng các sản phẩm dưỡng da đặc biệt để giải quyết các vấn đề da cụ thể.\n\n2. Các Loại Dịch Vụ Chăm Sóc Da:\n\na. Làm Sạch Da:\n\nThời lượng: 30 phút.\nDịch vụ bao gồm: Làm sạch sâu để loại bỏ bụi bẩn, dầu thừa và lớp trang điểm.\nCông dụng: Giúp da sạch sẽ, tạo điều kiện cho các bước chăm sóc da tiếp theo hiệu quả hơn.\n\nb. Tẩy Tế Bào Chết:\n\nThời lượng: 30 phút.\nDịch vụ bao gồm: Sử dụng các sản phẩm tẩy tế bào chết như scrubs hoặc hóa chất để loại bỏ lớp tế bào chết trên da.\nCông dụng: Làm sáng da, cải thiện kết cấu da và giúp da hấp thụ tốt hơn các sản phẩm dưỡng da\n\nc. Massage Mặt:\n\nThời lượng: 30 đến 60 phút.\nDịch vụ bao gồm: Massage mặt với các kỹ thuật thư giãn và sản phẩm dưỡng da.\nCông dụng: Giảm căng thẳng, kích thích tuần hoàn máu, làm mềm và làm đều màu da.\n\nd. Đắp Mặt Nạ:\n\nThời lượng: 20 đến 30 phút.\nDịch vụ bao gồm: Đắp mặt nạ chứa các thành phần dưỡng chất như vitamin, khoáng chất, và tinh dầu.\nCông dụng: Cung cấp độ ẩm, làm sáng da, làm giảm nếp nhăn và cải thiện tình trạng da cụ thể.\n\ne. Dưỡng Ẩm Da:\n\nThời lượng: 30 phút.\nDịch vụ bao gồm: Sử dụng các sản phẩm dưỡng ẩm như serum và kem dưỡng để cấp ẩm và giữ cho da mềm mại.\nCông dụng: Cung cấp độ ẩm cần thiết cho da, ngăn ngừa khô da và giữ cho da luôn mịn màng.\n\nf. Điều Trị Da Chuyên Sâu:\n\nThời lượng: 60 đến 90 phút.\nDịch vụ bao gồm: Điều trị các vấn đề da như mụn, đốm nâu, lão hóa, và nhạy cảm.\nCông dụng: Giải quyết các vấn đề da cụ thể bằng các sản phẩm và kỹ thuật điều trị chuyên sâu.\n\n3. Công Dụng:\n\nCải thiện sức khỏe da: Loại bỏ bụi bẩn, tế bào chết và cung cấp độ ẩm giúp da khỏe mạnh hơn.\nLàm sáng da: Tẩy tế bào chết và đắp mặt nạ giúp làm sáng da và cải thiện kết cấu da.\nGiảm nếp nhăn: Massage và dưỡng ẩm giúp giảm nếp nhăn và giữ cho da mịn màng.\nTăng cường tuần hoàn: Massage mặt và các liệu pháp chuyên sâu giúp kích thích tuần hoàn máu, làm cho da trông rạng rỡ hơn.\n\n4. Đối Tượng Nên Sử Dụng:\n\nNgười cao tuổi: Những người muốn duy trì sự tươi trẻ và sức khỏe của làn da, cải thiện tình trạng da lão hóa.\nNgười có vấn đề về da: Những người gặp vấn đề như mụn, da nhạy cảm, hoặc da khô.\nNgười cần thư giãn: Những người muốn giảm căng thẳng và chăm sóc bản thân.\n',200000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F27eac905-afd6-429d-a7da-01a0611665e4.jpg?alt=media&token=2ae51704-f34d-459d-8548-5266dba79c53',14,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 01:57:53.559371','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 06:53:37.927778',NULL,NULL,'WeeklyDays',NULL,NULL,NULL,'Deleted'),(11,'Dịch Vụ Tham Quan Công Viên','1. Mô tả Dịch Vụ:\nDịch vụ du lịch sinh thái cho người cao tuổi được thiết kế đặc biệt để phù hợp với nhu cầu và khả năng của người cao tuổi, cung cấp trải nghiệm du lịch gắn liền với thiên nhiên trong một môi trường an toàn và thoải mái. Các dịch vụ này chú trọng đến việc giữ gìn sức khỏe, dễ dàng di chuyển, và tận hưởng vẻ đẹp của thiên nhiên mà không gặp phải khó khăn.\n\n2. Các Hoạt Động Chính:\n\nTham Quan Khu Vườn: Khách tham quan sẽ có cơ hội chiêm ngưỡng các loại cây cỏ, hoa lá và thiết kế cảnh quan đẹp mắt trong khu vườn. Hướng dẫn viên sẽ cung cấp thông tin về các loài thực vật và lịch sử của khu vườn.\nĐi Dạo Trong Công Viên: Cung cấp không gian thoải mái để đi dạo và tận hưởng không khí trong lành. Các công viên thường có các khu vực nghỉ ngơi như ghế đá và bóng mát để khách có thể thư giãn.\nThưởng Thức Ẩm Thực: Một số chương trình có thể bao gồm bữa trưa hoặc bữa ăn nhẹ tại các quán cà phê hoặc nhà hàng gần khu vực tham quan, nơi cung cấp các món ăn ngon và dinh dưỡng.\n\n3. Thông Tin Cụ Thể:\n\nThời Lượng: 1 ngày.\nDịch Vụ Bao Gồm:\nVé vào cửa các khu vườn và công viên.\nHướng dẫn viên giàu kinh nghiệm.\nXe đưa đón từ nơi ở đến khu vực tham quan.\nCác bữa ăn nhẹ hoặc bữa trưa tùy theo chương trình.\nCông Dụng:\nCung cấp một môi trường thư giãn và thoải mái để người cao tuổi có thể tận hưởng cảnh đẹp và không khí trong lành.\nCải thiện tâm trạng và sức khỏe tinh thần thông qua sự kết nối với thiên nhiên.\nTăng cường sự vận động nhẹ nhàng qua các hoạt động đi dạo và khám phá.\n\n3. Đối Tượng Nên Sử Dụng:\n\nNgười cao tuổi có sở thích yêu thích thiên nhiên và cảnh quan xanh mát.\nNhững người tìm kiếm hoạt động thư giãn, không cần vận động quá sức.\nNgười có nhu cầu nghỉ ngơi và giảm căng thẳng trong một môi trường yên tĩnh.',300000.000000000000000000000000000000,NULL,3,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8fc80112-699a-4d7f-8e13-ef9564db9540.jpeg?alt=media&token=84150111-6f85-4fd8-a6b9-18cfc754c17f',15,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 02:05:38.892271','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-17 17:25:49.260983',NULL,NULL,'OneDay','2024-09-15',NULL,'2024-09-20','Deleted'),(12,'Dịch Vụ Chăm Sóc Da và Làm Đẹp','1. Mô tả Dịch Vụ: Dịch vụ chăm sóc da bao gồm một loạt các liệu pháp và kỹ thuật được thiết kế để cải thiện và duy trì sức khỏe, sự tươi trẻ của làn da. Các dịch vụ này có thể bao gồm làm sạch, tẩy tế bào chết, massage, đắp mặt nạ, và sử dụng các sản phẩm dưỡng da đặc biệt để giải quyết các vấn đề da cụ thể. \n\n2. Các Loại Dịch Vụ Chăm Sóc Da: \n\na. Làm Sạch Da: \nThời lượng: 30 phút. \nDịch vụ bao gồm: Làm sạch sâu để loại bỏ bụi bẩn, dầu thừa và lớp trang điểm. \nCông dụng: Giúp da sạch sẽ, tạo điều kiện cho các bước chăm sóc da tiếp theo hiệu quả hơn. \n\nb. Tẩy Tế Bào Chết: \nThời lượng: 30 phút. \nDịch vụ bao gồm: Sử dụng các sản phẩm tẩy tế bào chết như scrubs hoặc hóa chất để loại bỏ lớp tế bào chết trên da. \nCông dụng: Làm sáng da, cải thiện kết cấu da và giúp da hấp thụ tốt hơn các sản phẩm dưỡng da \n\nc. Massage Mặt: \nThời lượng: 30 đến 60 phút. \nDịch vụ bao gồm: Massage mặt với các kỹ thuật thư giãn và sản phẩm dưỡng da. \nCông dụng: Giảm căng thẳng, kích thích tuần hoàn máu, làm mềm và làm đều màu da. \n\nd. Đắp Mặt Nạ: \nThời lượng: 20 đến 30 phút. \nDịch vụ bao gồm: Đắp mặt nạ chứa các thành phần dưỡng chất như vitamin, khoáng chất, và tinh dầu. \nCông dụng: Cung cấp độ ẩm, làm sáng da, làm giảm nếp nhăn và cải thiện tình trạng da cụ thể. \n\ne. Dưỡng Ẩm Da: \nThời lượng: 30 phút. \nDịch vụ bao gồm: Sử dụng các sản phẩm dưỡng ẩm như serum và kem dưỡng để cấp ẩm và giữ cho da mềm mại. \nCông dụng: Cung cấp độ ẩm cần thiết cho da, ngăn ngừa khô da và giữ cho da luôn mịn màng. \n\n 3. Công Dụng: \nCải thiện sức khỏe da: Loại bỏ bụi bẩn, tế bào chết và cung cấp độ ẩm giúp da khỏe mạnh hơn. \n\nLàm sáng da: Tẩy tế bào chết và đắp mặt nạ giúp làm sáng da và cải thiện kết cấu da. \n\nGiảm nếp nhăn: Massage và dưỡng ẩm giúp giảm nếp nhăn và giữ cho da mịn màng. \n\nTăng cường tuần hoàn: Massage mặt và các liệu pháp chuyên sâu giúp kích thích tuần hoàn máu, làm cho da trông rạng rỡ hơn. \n\n4. Đối Tượng Nên Sử Dụng: \nNhững người cao tuổi muốn duy trì sự tươi trẻ và sức khỏe của làn da, cải thiện tình trạng da lão hóa. ',200000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F451c224b-06a3-46be-af0d-b609feb6809d.jpg?alt=media&token=5382381d-5cc7-48b1-9a3d-04760179b2d7',14,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 06:53:32.182677','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-13 06:53:32.182761',NULL,NULL,'AnyDay',NULL,NULL,NULL,'Active'),(13,'Dịch vụ tắm gội cho người cao tuổi','1. Thời lượng:\nThời gian mỗi buổi: Mỗi buổi tắm gội cho người cao tuổi thường kéo dài từ 30 đến 45 phút, tùy thuộc vào tình trạng sức khỏe và nhu cầu chăm sóc cá nhân.\n\nTần suất: Thường khuyến nghị từ 2 đến 3 lần mỗi tuần, nhưng có thể điều chỉnh theo yêu cầu của người cao tuổi và điều kiện sức khỏe cụ thể.\n\n2. Công dụng:\n\nGiữ gìn vệ sinh cá nhân: Dịch vụ giúp duy trì sự sạch sẽ, vệ sinh, ngăn ngừa các bệnh về da và nhiễm trùng, đặc biệt là ở những vùng da khó chăm sóc.\n\nThư giãn và giảm căng thẳng: Các động tác massage nhẹ nhàng trong khi tắm và gội đầu giúp người cao tuổi cảm thấy thư giãn, giảm bớt căng thẳng và mệt mỏi.\n\nCải thiện lưu thông máu: Tắm gội với nước ấm kết hợp với massage có thể kích thích tuần hoàn máu, từ đó cải thiện sức khỏe tổng thể và giúp giảm đau nhức cơ bắp.\n\nHỗ trợ chăm sóc da: Sau khi tắm, da được dưỡng ẩm với các sản phẩm chuyên dụng, giúp duy trì độ ẩm và bảo vệ làn da mỏng manh của người cao tuổi khỏi khô và nứt nẻ.\n\n3. Đối tượng nên dùng:\n\nNgười cao tuổi gặp khó khăn trong việc tự chăm sóc cá nhân: Dịch vụ tắm gội đặc biệt hữu ích cho những người già có khả năng vận động hạn chế, khó khăn trong việc tự tắm rửa và chăm sóc bản thân.\n\nNgười cao tuổi cần hỗ trợ vệ sinh cá nhân do tình trạng sức khỏe: Những người có các vấn đề về sức khỏe như đau nhức khớp, bệnh da liễu hoặc người nằm liệt giường có thể cần sự hỗ trợ chuyên nghiệp để đảm bảo vệ sinh cá nhân.\n\nNgười cao tuổi muốn cải thiện chất lượng cuộc sống: Dịch vụ này không chỉ giúp người cao tuổi cảm thấy sạch sẽ mà còn mang lại cảm giác thoải mái, tăng cường sự tự tin và cải thiện chất lượng cuộc sống hàng ngày.',70000.000000000000000000000000000000,NULL,0,0,'https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff5ab964c-9478-4761-9395-131d254a0a23.png?alt=media&token=726e6d31-f86a-4abd-86cb-5eb62ac29641',13,'08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-20 16:01:08.021935','08dcb61e-8a5d-424e-8f3e-6c525aad3768','2024-08-20 16:01:08.022039',NULL,NULL,'AnyDay',NULL,NULL,NULL,'Active');
/*!40000 ALTER TABLE `ServicePackages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Shifts`
--

DROP TABLE IF EXISTS `Shifts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Shifts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `StartTime` time(6) NOT NULL,
  `EndTime` time(6) NOT NULL,
  `Name` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Shifts`
--

LOCK TABLES `Shifts` WRITE;
/*!40000 ALTER TABLE `Shifts` DISABLE KEYS */;
INSERT INTO `Shifts` VALUES (1,'07:30:00.000000','11:30:00.000000','Morning'),(2,'12:00:00.000000','16:00:00.000000','Noon'),(3,'17:00:00.000000','00:00:00.000000','Afternoon'),(4,'00:00:00.000000','07:00:00.000000','Evening');
/*!40000 ALTER TABLE `Shifts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserClaims`
--

DROP TABLE IF EXISTS `UserClaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserClaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_UserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_UserClaims_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserClaims`
--

LOCK TABLES `UserClaims` WRITE;
/*!40000 ALTER TABLE `UserClaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserClaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserLogins`
--

DROP TABLE IF EXISTS `UserLogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserLogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_UserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_UserLogins_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserLogins`
--

LOCK TABLES `UserLogins` WRITE;
/*!40000 ALTER TABLE `UserLogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserLogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserRoles`
--

DROP TABLE IF EXISTS `UserRoles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserRoles` (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_UserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_UserRoles_Roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_UserRoles_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserRoles`
--

LOCK TABLES `UserRoles` WRITE;
/*!40000 ALTER TABLE `UserRoles` DISABLE KEYS */;
INSERT INTO `UserRoles` VALUES ('08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','08dcb61e-8985-45eb-8977-8923efda62f6'),('08dcb61e-8a37-47f8-8268-d08050d8e929','08dcb61e-8992-49d6-804d-b7bdc3e8065b'),('08dcb61e-8a5d-424e-8f3e-6c525aad3768','08dcb61e-8995-4b2a-8b2b-c4e6fd10366c'),('08dcb94b-2350-4076-8e61-0944738bad57','08dcb61e-8995-4b2a-8b2b-c4e6fd10366c'),('08dcb61e-8a7c-40ea-8a7a-9b681377e499','08dcb61e-8998-4361-857b-22934a0368e3'),('08dcb628-d6f8-4eef-89a6-f1de2c9e0574','08dcb61e-8998-4361-857b-22934a0368e3'),('08dcb629-2f2d-4524-87df-f03d905b5fd5','08dcb61e-8998-4361-857b-22934a0368e3'),('08dcb629-72f3-40f0-8c12-e8f102def407','08dcb61e-8998-4361-857b-22934a0368e3'),('08dcb62b-07c5-4541-8654-c48ab638957b','08dcb61e-8998-4361-857b-22934a0368e3'),('08dcb61e-8aa1-46c5-82d8-b13b6e32980d','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-e6f2-4330-8f63-a472bd0aca55','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-e80e-4fa8-8dae-08ddc014eb55','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-e8fe-4752-8d11-e48aca28f2b5','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-e9eb-41e8-82ad-1e7a0c29486f','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-eadd-46b8-8045-1837805db77f','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-ebcb-44cc-82bc-f4ec0a9aee78','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-ecc0-4838-8063-3077fa843444','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-edad-464a-8e97-5e005200d40d','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-eea1-4ffb-8631-86a38de90b48','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-ef90-4625-8766-c360f2394e45','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f082-4d19-8bf6-b1700eb2d8fc','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f170-41f9-80a0-0f51a32cfcf5','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f267-4bcc-8e88-43562d15a317','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f356-40dc-82d1-187bf6da0492','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f449-48d4-8b65-da65da4ebe83','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f53c-4d8e-82e9-b7f7e8e88c0b','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f62d-4136-85ba-1248fd1835ed','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f725-435e-8940-05919d34c962','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f81b-42e1-8d50-6004e3a637dd','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-f90b-4cdc-8e6f-0e1001f58ec7','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-fa03-405d-8ba6-50ca37f469d5','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-faf4-4eb0-8d85-e82c23a8b309','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-fbe5-4144-8143-9b0827d51150','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-fcd1-4b71-82b6-c68a1cb9d843','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-fdbe-44bf-82cc-8587f90402fb','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-feb3-44c0-8afa-2ab51366705d','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61f-ffa3-4445-8ad4-d8f8e839f425','08dcb61e-899a-4c95-8542-553777363020'),('08dcb620-0093-47a4-88dd-7479d89c0828','08dcb61e-899a-4c95-8542-553777363020'),('08dcb620-0189-4f27-8117-fc6b7085fc5d','08dcb61e-899a-4c95-8542-553777363020'),('08dcb620-0278-4909-84d5-e9c9519629c6','08dcb61e-899a-4c95-8542-553777363020'),('08dcb628-3f07-45f8-8280-6ccb6e6fefff','08dcb61e-899a-4c95-8542-553777363020'),('08dcb61e-8a1a-4750-81fa-9811238463cd','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb621-57f4-4acb-877d-4650a09350ab','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb621-e0c8-4ad9-8956-1b20ea506e0b','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb64b-96b1-4e12-8a71-84f13e47d292','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb69f-67c7-43be-81fe-9c26b6a92b08','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb6ca-7842-40fe-8086-f724e6188753','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb74b-366b-4a70-88f9-5631236a3f1b','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcb92b-98e9-444b-8ea9-0226d0ff657c','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcba01-8bd2-4eea-807c-c267c857c203','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcbb79-7a66-40c4-89c9-9c123b56123c','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcbb82-44a6-4718-8bda-d392c5a12e22','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcbc07-6864-4aca-8b85-d654af70c13a','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcbc2a-8a61-47a0-879f-63aa5f6b82d2','08dcb61e-899d-4775-8d76-203b2693f855'),('08dcc33d-cb4c-4c30-80f7-97cbdf1a800e','08dcb61e-899d-4775-8d76-203b2693f855');
/*!40000 ALTER TABLE `UserRoles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `UserTokens`
--

DROP TABLE IF EXISTS `UserTokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `UserTokens` (
  `UserId` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_UserTokens_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `Users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `UserTokens`
--

LOCK TABLES `UserTokens` WRITE;
/*!40000 ALTER TABLE `UserTokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `UserTokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `FullName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `AvatarUrl` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CCCD` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `IsActive` tinyint(1) NOT NULL,
  `Gender` varchar(24) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `DateOfBirth` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `CreatedAt` datetime(6) DEFAULT NULL,
  `ModifiedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ModifiedAt` datetime(6) DEFAULT NULL,
  `DeletedBy` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DeletedAt` datetime(6) DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `Index` int NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','Admin','https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg','Cao Lỗ Phường 4 Quận 8','123456789',1,'Male','01/01/1990','Anonymous','2024-03-06 13:49:05.810617','Anonymous','2024-08-06 13:49:06.010567',NULL,NULL,'admin','ADMIN','Haoluong@gmail.com',NULL,0,'AQAAAAIAAYagAAAAECC/7pthg9zdwDCWgPe/ko2r/9MNK0mi5Cs/X8KgnXAMUKHmg2UJjw1W+gYRcbGjiQ==','S2SVS6IMBSQBS6VAFRLW5HJ7WRRIZUJV','fe9c27b9-92b4-49a8-8905-6f76a59e4897','0901234567',0,0,NULL,1,0,0),('08dcb61e-8a1a-4750-81fa-9811238463cd','Lương Thị Dung','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0a1ec590-4196-4017-bf32-2bdda573de92.jpg?alt=media&token=615d7839-df83-4118-95d2-073c86b1762f','Ho Chi Minh','123456789111',1,'Male','1990-12-17','Anonymous','2024-03-06 13:49:06.207462','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 17:51:47.761677',NULL,NULL,'user','USER','toan17@gmail.com',NULL,0,'AQAAAAIAAYagAAAAEDgzNDjqXSyC1ZFeyoj7FPDdZzGtW4hFacNRytFen5tTDOJaBcAfhn0aqnwVekTi3w==','DTJUMNXK45OJRI53SDQRTHC46NB75NOB','3340c43d-896b-4d7f-aa5e-630a1866d2cb','0902345678',0,0,NULL,1,0,0),('08dcb61e-8a37-47f8-8268-d08050d8e929','Trần Văn Trung','https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg','Da Nang','123456789',1,'Male','01/01/1999','Anonymous','2024-03-06 13:49:06.397119','Anonymous','2024-08-20 12:50:59.420901',NULL,NULL,'director','DIRECTOR','Ngoc@gmail.com','NGOC@GMAIL.COM',0,'AQAAAAIAAYagAAAAEMQ7/YAPBA3IdoaN/ZZ0LRVzFZRv1yhhIIEMSkjxtZfyW+XE4wkKhzeKYAsKVqe+Dg==','IKEQMEUJJ5ATXXAVTKOWG4EXVYQ2SFKT','05443752-2559-4e1a-bed3-278c6de78b0a','0903456789',0,0,NULL,1,0,0),('08dcb61e-8a5d-424e-8f3e-6c525aad3768','Ngô Thị Mai','https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg','Long An','222323456789',1,'Male','1990-05-17','Anonymous','2024-03-06 13:49:06.642708','Anonymous','2024-08-18 17:09:25.271220',NULL,NULL,'manager','MANAGER','evanan@example.com','EVANAN@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEO7ZuoEORuPk6a4NfmB2BqFKANi7Mq90iw2sbingi3x3MSOi58jyaYxf2p4SfZ+2RQ==','P6E4PWRYFE4TIUL65XXUMUMM3OTHA7JQ','577baa61-b3c5-4ebe-8401-2ea7d3a2d26d','0904567890',0,0,'2024-08-10 14:44:14.392534',1,0,0),('08dcb61e-8a7c-40ea-8a7a-9b681377e499','Nguyễn Trung Sơn','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fd70e9782-e79c-471d-bba0-06c5b175b00d.jpg?alt=media&token=ab2670d0-52d9-4fc0-a858-16d8663c0425','Đà Lạt','556677889',1,'Male','1988-08-23','Anonymous','2024-03-06 13:49:06.846428','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-25 14:40:53.771748',NULL,NULL,'staff','STAFF','phamthid1@example.com','PHAMTHID1@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEMKw1jmBP3+9/ehalyXdNM+WX4EBuymXyQFcDj9KvWOB0eWIPrj3N5DfQ8bEHPhhuw==','QESRXZM7MS3WAFGR34S4RVLNOFQZZ7AJ','a0fe485f-7c03-497f-af34-d4227035ef2f','0905678901',0,0,NULL,1,0,0),('08dcb61e-8aa1-46c5-82d8-b13b6e32980d','Nguyễn Trung Định','https://gcs.tripi.vn/public-tripi/tripi-feed/img/474110FMI/anh-buon-phong-canh_060206013.jpg','Ca Mau','998877665',1,'Male','1987-02-05','Anonymous','2024-03-06 13:49:07.089508','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:57:18.669935',NULL,NULL,'nurses','NURSES','hoangvane@example.com',NULL,0,'AQAAAAIAAYagAAAAEL2OYK/8bRI1OtfxcZyxrTyVl0myxNl4jTF78wBX8E7U5tyMCeiUYCitbXHJ79Bhvw==','SG4VCQE4WDCYQMEXXOABKVUBIJY3A2NU','a0be946d-3e39-44fb-9860-a3a3b249c0b8','0906789012',0,0,NULL,1,0,0),('08dcb61f-e6f2-4330-8f63-a472bd0aca55','Nguyễn Thị An','https://png.pngtree.com/thumb_back/fw800/background/20210910/pngtree-nurse-sees-a-doctor-image_838954.jpg','109 TP.Thủ Đức','087428917631',1,'Female','1991-05-17','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-04-06 13:58:51.579039','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:53:17.593264',NULL,NULL,'0987654321','0987654321','nguyenthian@example.com',NULL,0,'AQAAAAIAAYagAAAAELhfQFqX7AiVcO+TcmPSYEnlUSlQXRiSZQ6nEz1lSptY+7mKK9tddpGzRTarKZWaEA==','3N3XVAUQDDP7QLHHTZXCPYLRNZPOXW7E','4088bb0c-d92a-453c-b8e8-c7b8d2dc835b','0987654321',0,0,NULL,1,0,1),('08dcb61f-e80e-4fa8-8dae-08ddc014eb55','Trần Thị Bích','https://watermark.lovepik.com/photo/20211126/large/lovepik-nurse-image-picture_501088974.jpg','124/2 hẻm nhỏ, quận 10, TP.Hồ Chí Minh','087428917636',1,'Female','1993-03-11','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:58:53.332359','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:53:45.416493',NULL,NULL,'0912345678','0912345678','tranthibich@example.com',NULL,0,'AQAAAAIAAYagAAAAEOrP4k3oA9d+eFJ6omvce97SmfAj05F1b5E496wBhiUcdskAf2gUHuCTLnE1ZVZu8Q==','6246OFNHCBWKJL7TUGCY26BRGIGQBF6Q','2ba11c37-40de-4606-8378-353394a52c54','0912345678',0,0,NULL,1,0,2),('08dcb61f-e8fe-4752-8d11-e48aca28f2b5','Lê Thị Cẩm','https://suckhoedoisong.qltns.mediacdn.vn/324455921873985536/2022/2/15/pho-trong-lang-3-16448826581081420176736.jpg','Ca Mau','667788990',1,'Female','1995-09-09','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-07-06 13:58:54.900431','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:58:00.349291',NULL,NULL,'0923456789','0923456789','lethicam@example.com',NULL,0,'AQAAAAIAAYagAAAAEKJWmp6ylJY+XykFRstRAr6pqhn0M/B9aaiwBP3gM81cm6sLdmGf8LexFBF/GaKk2w==','JKZZJNQYF6DJ62OP3PSFORQ6LAOZLVGN','e3b1f4ac-023b-40cc-bf41-74de2e018aad','0923456789',0,0,NULL,1,0,3),('08dcb61f-e9eb-41e8-82ad-1e7a0c29486f','Phạm Thị Dung','https://cdn.tuoitre.vn/2020/4/15/photo-1-15869183436611032528408.jpg','long an','334455667',1,'Female','1995-10-10','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-05-06 13:58:56.451244','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:58:21.481842',NULL,NULL,'0934567890','0934567890','phamthidung@example.com',NULL,0,'AQAAAAIAAYagAAAAECrd6TtI5a6Ka2KN30RiqymC30IUCtgJEPaXrujmvMP6OmX7IHhyiPvgih/nGkcDTA==','CBC4NG7TGQVWRZPWRAFMUSXQ2PHMVZGB','8a55c589-d33b-4ef9-885f-98ea251876de','0934567890',0,0,NULL,1,0,4),('08dcb61f-eadd-46b8-8045-1837805db77f','Hoàng Thị Đào','https://watermark.lovepik.com/photo/20211210/large/lovepik-youth-female-nurse-professional-image-picture_501779592.jpg','hà nam','889900112',1,'Female','1995-11-11','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:58:58.039068','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:58:43.889241',NULL,NULL,'0945678901','0945678901','hoangthidao@example.com',NULL,0,'AQAAAAIAAYagAAAAEMX5OYhkfVaNbZFFYph8q2fOf5pnNR8e0qhb7thb2U27bBFPYVRBgTSwzq24WLGq0Q==','POSWX2SMMHVWLUD63ZG7WFGMBLVD2PZJ','d5c187fc-4521-451e-b34c-3ee7809d35e8','0945678901',0,0,NULL,1,0,5),('08dcb61f-ebcb-44cc-82bc-f4ec0a9aee78','Vũ Thị Em','https://png.pngtree.com/thumb_back/fw800/background/20210910/pngtree-nursing-doctor-female-hospital-injection-photography-chart-with-picture-image_838956.jpg','123 Nguyễn Trãi, Quận 1, Thành phố Hồ Chí Minh','110022334',1,'Female','1992-01-17','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-04-06 13:58:59.598165','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:59:20.565363',NULL,NULL,'0956789012','0956789012','vuthiem@example.com',NULL,0,'AQAAAAIAAYagAAAAECpAjhdZ+noD0IcijXt9G4IMf4d5L00lERIehQGgxbvBB9ggKP5thHdAQg/zyEbx+w==','DGQLMR5U37RYYCRY3CDMZD3FSGMHW6PC','de1e6083-2785-47f6-bb85-f1f367a803c4','0956789012',0,0,NULL,1,0,6),('08dcb61f-ecc0-4838-8063-3077fa843444','Đặng Thị Hà','https://thomasnguyen.vn/wp-content/uploads/2020/04/15-12.jpg','456 Lý Thường Kiệt, Quận 10, Thành phố Hồ Chí Minh','443322110',1,'Female','1995-01-13','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-05-06 13:59:01.205152','Anonymous','2024-08-13 16:11:35.860394',NULL,NULL,'0967890123','0967890123','dangthiha@example.com','DANGTHIHA@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAELwgShi/y7kgwksViBp5w+2HHSIy+gKML4qJ5RB1F+Vc2dTvZR6+9H86wi67D5AtLA==','EEHWOUX5UHBVZBRSP3FBMDMYYXXUHY2K','f4b82f83-1b0a-4dd8-8279-c8a1ce63ef65','0967890123',0,0,NULL,1,0,7),('08dcb61f-edad-464a-8e97-5e005200d40d','Nguyễn Thị Hạnh','https://thomasnguyen.vn/wp-content/uploads/2020/04/16-11.jpg','789 Phan Đình Phùng, Quận Phú Nhuận, Thành phố Hồ Chí Minh','556600778',1,'Female','1995-02-14','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:02.757493','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:59:42.528154',NULL,NULL,'0978901234','0978901234','nguyenthihanh@example.com','NGUYENTHIHANH@EXAMPLE.COM',0,'AQAAAAIAAYagAAAAEHotXHy+E30vD0WyEWxdGAPp58T7KigyToBd/V6aoGJ/k3hWLbLxIkTgj6KDDKKt9w==','FX74VZDDZKDFUSZ6OXJIOBVRHHIURFLT','f9f8118e-9262-4913-94c0-9c37179898f0','0978901234',0,0,NULL,1,0,8),('08dcb61f-eea1-4ffb-8631-86a38de90b48','Trần Thị Hương','https://thomasnguyen.vn/wp-content/uploads/2020/04/5-1.jpg','1011 Điện Biên Phủ, Quận Bình Thạnh, Thành phố Hồ Chí Minh','992211334',1,'Female','1995-03-15','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-07-06 13:59:04.360575','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:59:58.451637',NULL,NULL,'0990123456','0990123456','tranthihuong@example.com',NULL,0,'AQAAAAIAAYagAAAAELUCobWeSnL57pjT1bsjmkhrgNWx9CT7Zo8/PS/uY7hpdWrDirEQqEsGX1CtMixEqQ==','PPQU62ER6B27B5Z7CNXDK2O3NWO62VUE','d0a25bb3-a9a0-42b3-b70b-3583b712c3c4','0990123456',0,0,NULL,1,0,9),('08dcb61f-ef90-4625-8766-c360f2394e45','Lê Thị Lan','https://maydongphucyte.com/upload/product/15/85/83/mau-dam-y-ta-dieu-duong-from-dai-image-20200402214052-770872.jpg','1213 Trần Hưng Đạo, Quận 5, Thành phố Hồ Chí Minh','667799001',1,'Female','1995-04-16','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-03-06 13:59:05.922839','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:00:25.349431',NULL,NULL,'0901234567','0901234567','lethilan@example.com',NULL,0,'AQAAAAIAAYagAAAAEErJX0ues4Kxtx2lOee22wI1ExDUddVm7vCvbCOoPuAP1+TRkFY6I2dU8fcFTJx1ZQ==','ALXNTHUNPJEQRGRRZCCBTMXQRGL5OQWF','705cf97c-9e9b-4dd1-9f2b-77d63a945ab2','0901234567',0,0,NULL,1,0,10),('08dcb61f-f082-4d19-8bf6-b1700eb2d8fc','Phạm Thị Liên','https://dongphuckhanhlinh.com/pic/product/45-dong-phuc-y-ta_637145481284377757.jpg?w=800','Ca Mau','334455779',1,'Female','1995-05-17','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-04-06 13:59:07.511698','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:00:48.257190',NULL,NULL,'0912345690','0912345690','phamthilien@example.com',NULL,0,'AQAAAAIAAYagAAAAECI/gjaS5Ib2bELAappAacUGcik08kSJ0t88n720GWBhXWQmNq+w29C7hajQ/gA0NA==','JE36S72VFY52NR5B76ZST4FW2NBSH3LR','f6753ea8-116c-4d27-9f74-33a3040ce8d3','0912345690',0,0,NULL,1,0,11),('08dcb61f-f170-41f9-80a0-0f51a32cfcf5','Hoàng Thị Mai','https://cache.maysoichivang.com/wp-content/uploads/2022/04/dam-dong-phuc-y-ta-1.jpg','1617 Nguyễn Văn Linh, Quận 7, Thành phố Hồ Chí Minh','112200334',1,'Female','1995-06-18','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:09.066967','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:00:58.213720',NULL,NULL,'0923456791','0923456791','hoangthimai@example.com',NULL,0,'AQAAAAIAAYagAAAAEGQghYCZF6+slH77I00aMOOo2GoPWoDlX1yXRmu+HwDAlypKPP6/bw5aeJHKlupElw==','TSQWMFQ2DBGREGH7X6HMOAFPS247GD5M','8e961ebb-3d47-495b-8d57-244d940c11e0','0923456791',0,0,NULL,1,0,12),('08dcb61f-f267-4bcc-8e88-43562d15a317','Vũ Thị Minh','https://thomasnguyen.vn/wp-content/uploads/2020/02/ao-blouse-dieu-duong.jpg','1819 Phạm Văn Đồng, Quận Thủ Đức, Thành phố Hồ Chí Minh','087428919999',1,'Female','1995-07-19','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-07-06 13:59:10.689632','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:00:05.970911',NULL,NULL,'0934567892','0934567892','vuthiminh@example.com',NULL,0,'AQAAAAIAAYagAAAAEM9BpDpuoOed4z7ttDrRCvET1/Q0VULWj2dVSgv5+QiOncAuy0WVibHdi3kryFqBOA==','EMEIMB45ESTU4FB2YLLUJGCUN2PD753B','f8cc5842-a69c-4b3a-bd38-685c77d8f84c','0934567892',0,0,NULL,1,0,13),('08dcb61f-f356-40dc-82d1-187bf6da0492','Đặng Thị Ngọc','https://dongphucvinhphat.com/wp-content/uploads/2019/01/1222.png','021 Lê Văn Sỹ, Quận 3, Thành phố Hồ Chí Minh','087428917193',1,'Female','1988-10-19','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:12.251472','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:59:44.767972',NULL,NULL,'0945678903','0945678903','dangthingoc@example.com',NULL,0,'AQAAAAIAAYagAAAAEHakh2L5d4qbC/98DCMSvIs+xg6mo5nhLgATAeIc7kfz4isfvFeSXQiuPrgKbHcgnA==','MM5AELDTVR6QO72UCEZCMKBTSZ6QW7H5','0b405134-ae5d-4d9f-bf2c-6ee44fd76a0c','0945678903',0,0,NULL,1,0,14),('08dcb61f-f449-48d4-8b65-da65da4ebe83','Nguyễn Thị Phương','https://thomasnguyen.vn/wp-content/uploads/2020/04/9-1.jpg','huyện cần đước ,tỉnh Bến Tre','123587415198',1,'Female','1995-09-21','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:13.847454','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:59:03.975631',NULL,NULL,'0956789014','0956789014','nguyenthiphuong@example.com',NULL,0,'AQAAAAIAAYagAAAAEIxhQWVtilO68FA/vhoK97c97QO/MyxyroPFB8OGKMMO9d/KOlPpVINgGljL/N9tNg==','LCARLOSPE7SAR5WTW4VAAIJYPAKM7CEO','07ead3f4-d507-4ad8-9145-d97be896b063','0956789014',0,0,NULL,1,0,15),('08dcb61f-f53c-4d8e-82e9-b7f7e8e88c0b','Trần Thị Quỳnh','https://danviet.mediacdn.vn/upload/3-2016/images/2016-07-24/1469334687479-5.jpg','193 quận 11, TP.Hồ Chí Minh','087428917753',1,'Female','1995-06-06','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-05-06 13:59:15.441774','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:54:52.678922',NULL,NULL,'0967890125','0967890125','tranthiquynh@example.com',NULL,0,'AQAAAAIAAYagAAAAEE4Tj7/et0QWDET1BBYgyfXc/lIRcN6oCseSFDRt3GyTO8XVR7+tOtqNbaUGE8N3vA==','JNNLRMR6VC3BWKBYM4SPWITPNW2OKDUB','2d54bdad-807a-4a98-8f8a-e80787535e34','0967890125',0,0,NULL,1,0,16),('08dcb61f-f62d-4136-85ba-1248fd1835ed','Lê Thị Thu','https://danviet.mediacdn.vn/upload/3-2016/images/2016-07-24/146933468728931-4.jpg','huyện Đức Hòa ,tỉnh Long An','852137415157',1,'Female','1983-10-19','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:17.016273','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:55:18.284670',NULL,NULL,'0978901236','0978901236','lethithu@example.com',NULL,0,'AQAAAAIAAYagAAAAEDOr+YtJl+naC+wVQIMPNYhzaVY6dONrmEX8T6StmwBygjty5RsWCOAbOc7YS3a7Pg==','RAXFO52GKQC6GAP4MME2VAXU7ECLLH37','e6dd91f6-cb4a-40fc-95e2-64842a3b7af1','0978901236',0,0,NULL,1,0,17),('08dcb61f-f725-435e-8940-05919d34c962','Phạm Thị Thảo','https://dongphuckimvang.vn/uploads/shops/dp-y-ta/15-y-ta-38.jpg','Đõ Xuân Hợp TP.Thủ Đức','123587415486',1,'Female','1995-10-22','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-05-06 13:59:18.642264','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:58:57.219069',NULL,NULL,'0990123457','0990123457','phamthithao@example.com',NULL,0,'AQAAAAIAAYagAAAAEAVVdkFWdcjUdVTWshq9i0W1Iwbz6GWOPR5yFKC/WlrCWvzaYfmFNrP6ucO04XZ43A==','JTFALHXNZZRQ7PZJ42G3EJOCR6GMD4H4','cb060d24-a326-4364-ad35-75c51217a603','0990123457',0,0,NULL,1,0,18),('08dcb61f-f81b-42e1-8d50-6004e3a637dd','Hoàng Thị Thanh','https://bizweb.dktcdn.net/thumb/large/100/367/355/products/dongphucdieuduongdpdd00451.jpg?v=1591782372727','109 TP.Thủ Đức','087428917146',1,'Female','1984-07-25','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:20.254366','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:55:39.683645',NULL,NULL,'0901234568','0901234568','hoangthithanh@example.com',NULL,0,'AQAAAAIAAYagAAAAELpDSXaL0lpftbLStCwq+XjLKkbOLrlzcIgFQZSoC09eWgy0PGrOy6jjju8aWc+uBw==','WQG4SAGTOQ23FJ4BJHTPJLZT4QPFJIMH','77d576d1-c142-46ea-9055-096620f137c9','0901234568',0,0,NULL,1,0,19),('08dcb61f-f90b-4cdc-8e6f-0e1001f58ec7','Vũ Thị Trang','https://maydongphucyte.com/upload/product/15/85/83/mau-dam-y-ta-dieu-duong-from-dai-image-20200402214052-770872.jpg','Đõ Xuân Hợp TP.Thủ Đức','159852468185',1,'Female','1982-01-05','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:21.831413','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:56:49.942331',NULL,NULL,'0912345691','0912345691','vuthitrang@example.com',NULL,0,'AQAAAAIAAYagAAAAEPhxgfMAwzvMf2moI39kvVWsNMe7/AL4Xa64G/m6wRW2ibzyWSDOl8ZPB8bBZK352Q==','MURJMEN33XL2Q6DUML6SVDR3E6MI7MUZ','dc379a54-1f3b-4a45-9561-1c9a81c00552','0912345691',0,0,NULL,1,0,20),('08dcb61f-fa03-405d-8ba6-50ca37f469d5','Đặng Thị Tuyết','https://thomasnguyen.vn/wp-content/uploads/2020/04/4-1.jpg','109 TP.Thủ Đức','087428914513',1,'Female','1995-07-07','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-07-06 13:59:23.451407','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:57:56.280705',NULL,NULL,'0923456792','0923456792','dangthituyet@example.com',NULL,0,'AQAAAAIAAYagAAAAEC2kOMa388+31Ke6YV6GWWGqKxXrIFrS7IIfNZ2kGqKx0bfw5jv7S4IIsg+WjM5JJQ==','UHRNQ5TRSHHY2FQURIZDECAMCWKCXVIS','12019c8a-5879-4ee7-8bc2-ebb4687cb46f','0923456792',0,0,NULL,1,0,21),('08dcb61f-faf4-4eb0-8d85-e82c23a8b309','Nguyễn Thị Trâm','https://cdn.eva.vn/upload/4-2018/images/2018-10-26/nu-y-ta-xinh-dep-nhat-thai-lan-da-bi-benh-vien-sa-thai-2-1540525288-590-width640height681.jpg','124/2 hẻm nhỏ, quận 11, TP.Hồ Chí Minh','159852464578',1,'Female','1995-08-08','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:25.037105','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:57:35.240653',NULL,NULL,'0934567893','0934567893','nguyenthitram@example.com',NULL,0,'AQAAAAIAAYagAAAAENLm/Ami7sokiSQdwYHV7dR4Ovm6j6HStf2pSUwYl54Mi6ipoUuSQFgwSB+Vr989vw==','4JQIZSNENHLIKQPEX4QZAWUW7AOMY6GV','9c64abec-8e23-40a0-bb4a-59974cef6f5f','0934567893',0,0,NULL,1,0,22),('08dcb61f-fbe5-4144-8143-9b0827d51150','Trần Thị Tú','https://watermark.lovepik.com/photo/20211126/large/lovepik-nurse-image-picture_501088995.jpg','huyện Đức Hòa ,tỉnh Long An','123587415487',1,'Female','1995-06-06','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-07-06 13:59:26.610609','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:57:11.394702',NULL,NULL,'0945678904','0945678904','tranthitu@example.com',NULL,0,'AQAAAAIAAYagAAAAEC7Iar6ojW9L1YNwcZePY0FEHI1/z3TbK3M4CM7rYugQixP0p7fG2uQxcn+pCDrWBA==','QHK2XZDHM7CQAX62J57NBVYBBUXB6AQ7','cda13e25-1935-4a19-8dd7-a15b1832fd00','0945678904',0,0,NULL,1,0,23),('08dcb61f-fcd1-4b71-82b6-c68a1cb9d843','Lê Thị Uyên','https://watermark.lovepik.com/photo/20211210/large/lovepik-youth-female-nurse-professional-image-picture_501779592.jpg','124/2 hẻm nhỏ, quận 11, TP.Hồ Chí Minh','087428917674',1,'Female','1989-03-04','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:28.161451','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:56:04.916158',NULL,NULL,'0956789015','0956789015','lethiuyen@example.com',NULL,0,'AQAAAAIAAYagAAAAEGfsN3v4/QLa9bpFl7/awT8Vmrm/8QOaAm7BDQxF3etS2ByjKrkODydomunYRuYJog==','MFXOIRQB3Q7F26SO576N2AG2DRKLAMOR','143866ff-c605-4dc5-8610-31cef922eeee','0956789015',0,0,NULL,1,0,24),('08dcb61f-fdbe-44bf-82cc-8587f90402fb','Phạm Thị Vân','https://dongphucsaigon3.com/wp-content/uploads/2019/11/HTB1qez2nYSYBuNjSspfq6AZCpXaD-400x600.jpg','1007 TP.Thủ Đức','087428917677',1,'Female','1988-04-23','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:29.711924','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 17:54:21.073433',NULL,NULL,'0967890126','0967890126','phamthivan@example.com',NULL,0,'AQAAAAIAAYagAAAAELPkI7mzsCy5RmTiHESlCRdN5Tgiy3Ee1WIWCZnJG8QIgqUp0Opdi6ELkXFU4N4e5Q==','4SJ3ULEHVAAD3VR7ZG55NTOM2E3GBKAK','c639ebb6-4ee4-4639-92fb-60bceb06b700','0967890126',0,0,NULL,1,0,25),('08dcb61f-feb3-44c0-8afa-2ab51366705d','Hoàng Thị Yến','https://salt.tikicdn.com/cache/w1200/ts/product/a8/01/1e/91787ab3e6f0321c6e3c8c71c41d3cd3.jpg','2223 Cách Mạng Tháng 8, Quận Tân Phú, Thành phố Hồ Chí Minh','852137415998',1,'Female','1995-05-05','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:31.317596','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:01:25.638911',NULL,NULL,'0978901237','0978901237','hoangthiyen@example.com',NULL,0,'AQAAAAIAAYagAAAAEDah8EQztagrnXj3kKRY3vXWAAJF66Ase5GRpyRHgH49yzZn6EMJv3qtI7PvqRoisQ==','CXXOFAS7ASOMAMBW5Z5SNP3TAJJJMQZO','4124c793-f4dc-45fe-80c5-96230f7a6d9e','0978901237',0,0,NULL,1,0,26),('08dcb61f-ffa3-4445-8ad4-d8f8e839f425','Vũ Thị Hải','https://cdn.eva.vn/upload/4-2020/images/2020-10-22/9-1603368514-374-width800height700.jpg','2425 Hùng Vương, Quận 6, Thành phố Hồ Chí Minh','087428917758',1,'Female','1995-04-04','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:32.890307','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:01:08.548477',NULL,NULL,'0990123458','0990123458','vuthihai@example.com',NULL,0,'AQAAAAIAAYagAAAAEEACrAlz6Xy8U3gQyrpOikuWT/fcwx9wpX+NHUz6V9VxMEoYCv7hswYZ++947XqnEA==','YXURP7OWMWMDJQ6SOH3HMINQJG54TSW5','e50dbc35-7ab6-4382-a89f-55f9a5e4e594','0990123458',0,0,NULL,1,0,27),('08dcb620-0093-47a4-88dd-7479d89c0828','Đặng Thị Hường','https://cdn.24h.com.vn/upload/2-2021/images/2021-05-19/Nu-y-ta-chong-Covid-19-dang-duoc-chu-y-la-nguoi-mau-tung-bi-duoi-vi-dep-184845757_919212145587527_3888235000814823459_n-1621397224-688-width1080height1349.jpg','2627 Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh','087428917998',1,'Female','1995-03-03','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:34.464485','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:01:17.622874',NULL,NULL,'0901234569','0901234569','dangthihuong@example.com',NULL,0,'AQAAAAIAAYagAAAAEO3oZN7JPAG+GlLR6Qs5BJGpKs45cPcWbaP5uggmIR9sHv33h+h+N9AvhLoGkj14Lw==','JG3YQUBHQQ6W4SJA46JER5ATGOBQKQKL','e94cfec6-7500-40fd-8451-51f5676d5e4f','0901234569',0,0,NULL,1,0,28),('08dcb620-0189-4f27-8117-fc6b7085fc5d','Nguyễn Thị Liên','https://bizweb.dktcdn.net/100/415/076/products/1-67f3a48c-44e1-4547-80e5-93d6e7aeba70.jpg?v=1688575528790','2829 Nguyễn Huệ, Quận 1, Thành phố Hồ Chí Minh','074202020222',1,'Female','1995-02-02','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-08-06 13:59:36.079753','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:01:34.959844',NULL,NULL,'0912345692','0912345692','nguyenthilien@example.com',NULL,0,'AQAAAAIAAYagAAAAEAWoiayay5MaWj2AMjRtLSwDHb9N3/JBRYhvxKLTpUaOPESwPCSVV+TAWw8hwpDWzg==','OCX66JKC3LHXA3NW7IMZTV65Y4FK7PGW','a1ef6fb6-fb2a-4077-b899-9711d547fd45','0912345692',0,0,NULL,1,0,29),('08dcb620-0278-4909-84d5-e9c9519629c6','Trần Thị Phúc','https://img.docnhanh.vn/images/uploads/2024/01/24/loat-anh-khoe-dang-nuot-cua-nu-y-ta-dai-loan-nguc-khung.jpg','3031 Lê Quang Định, Quận Bình Thạnh, Thành phố Hồ Chí Minh','074202001234',1,'Female','1995-01-01','08dca44f-6a7e-456a-8c54-3195fdfa3444','2024-06-06 13:59:37.643704','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 18:01:14.809559',NULL,NULL,'0923456793','0923456793','tranthiphuc@example.com',NULL,0,'AQAAAAIAAYagAAAAEFc4wQc8qa7T6d8lDio+MbaiIZ40EW9PjFaXqmTJMWFi5Rbhf8gcNA5rEs861Xh81Q==','5INF2QR7PAZOBW63OZJJA5ZUIGQFUUN6','382cb5a8-3c62-4e1c-b050-bd4bc7f3e75e','0923456793',0,0,NULL,1,0,30),('08dcb621-57f4-4acb-877d-4650a09350ab','Nguyễn Kiều Cẩm Thơ','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F7e255618-a389-4e73-831a-800217e3b2f7.jpg?alt=media&token=4dfe1fbf-8d80-4c14-92b7-d5cb357ba58f','109 TP.Thủ Đức','080302756896',1,'Female','2000-12-17','Anonymous','2024-08-06 14:09:10.560223','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:02:51.662340',NULL,NULL,'0386218039','0386218039','toan@fpt.edu.vn','TOAN@FPT.EDU.VN',0,'AQAAAAIAAYagAAAAEND1PkGOCVKb/9yk616K/qaGfC8jRYjWSyR6IlC87Y45SzZZUfzKzHdOPyKK80VGRw==','XNLM3PYBPWLQUY27F4JZLU7HE5ZRR5P7','db4a1be3-6a51-4722-9c8f-4212a589d152','0386218039',1,0,NULL,1,0,0),('08dcb621-e0c8-4ad9-8956-1b20ea506e0b','Trần Thị Bích My','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0efcfa42-3f44-460c-87f3-12ca01626cb0.jpg?alt=media&token=39db1195-ec2a-43d6-9376-cea9033bea80','Đõ Xuân Hợp TP.Thủ Đức','087428917637',1,'Female','2006-08-06','Anonymous','2024-07-06 14:13:00.119568','Anonymous','2024-08-25 15:28:51.369088',NULL,NULL,'0909799799','0909799799','toannvse1504633@fpt.edu.vn','TOANNVSE1504633@FPT.EDU.VN',0,'AQAAAAIAAYagAAAAEOS8cVGYdJPaE/JJ7rGwt4tzkRUM9mh7n3e+B3x/XU+6cT+mLXTuA+jWmE5aPb0uMA==','6DINE7N4FYGAZUCYZXOSIHAE2ZOEBVXR','592ae480-a4e3-4594-a5c4-391ff89bb91d','0909799799',1,0,'2024-08-13 09:45:15.868402',1,0,0),('08dcb628-3f07-45f8-8280-6ccb6e6fefff','Lê Thị Thùy','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fe278ba92-8b6a-41b7-95ce-5c62a993ee39.jpg?alt=media&token=c9dbce21-39dd-415b-8df1-b2b23d044615','124/2 hẻm nhỏ, quận 11, TP.Hồ Chí Minh','087428917632',1,'Female','1995-08-10','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 14:58:35.216546','08dcb628-3f07-45f8-8280-6ccb6e6fefff','2024-08-13 12:54:31.899255',NULL,NULL,'0909799999','0909799999','thuy@gmail.com','THUY@GMAIL.COM',0,'AQAAAAIAAYagAAAAEFTH8R1AnMO1YunzIChFv+rRm5/OxJ1sKLx3nVurqO/LMuDR6mhVoM+RIzCD7cEesA==','VDHM2V6LPPD77LEKXNWU2ZATMPYLRBB2','39c6dc3a-b3bf-4d0b-94c1-2e1b5381760b','0909799999',0,0,NULL,1,0,0),('08dcb628-d6f8-4eef-89a6-f1de2c9e0574','Houang Tam Nhu','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fe30179dd-a7c5-4ac2-b36c-32ba5517cbcf.png?alt=media&token=901a9c1c-b0b4-4f39-a285-1ee9b66d35eb','43 Trần Văn Ơn','281336255',1,'Female','1996-05-15','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-07-06 15:02:50.135651','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 15:02:50.156143',NULL,NULL,'0792012719','0792012719','nhu@gmail.com','NHU@GMAIL.COM',0,'AQAAAAIAAYagAAAAEJrKndwNaVaPSUSFFMnmQcfwG9yUGnihS8gTDTDT8FCgQiSHbr53qpQMA6d/XuSZuA==','SZ4BPG4X6VRDBI46J5CTRW6WICPFK77Q','a3543c6e-03fa-49ca-a6f6-074e45792799','0792012719',0,0,NULL,1,0,0),('08dcb629-2f2d-4524-87df-f03d905b5fd5','Nguyễn Văn Toàn','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F50cb467a-ea90-4d80-84ba-f781dd4e5de8.jpg?alt=media&token=1a8e82b0-7432-4b00-a4b3-b5d162a1d3d3','Ca Mau','111155551112',1,'Male','1990-11-11','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 15:05:18.118677','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 14:56:56.557957',NULL,NULL,'toansola','TOANSOLA','toansola17122000@gmail.com','TOANSOLA17122000@GMAIL.COM',0,'AQAAAAIAAYagAAAAEPL0CVeO35J7wGovxB0SuuRUZk0bf7J6QqDNJ0Y/Hn/cy5XlwuOL3E40R9U6+6wBLA==','EI2RHHT3TBLQ5XBKVJT5HHRBVOE53QAI','a85313ed-84ca-4886-9121-5a0a8fb04284','0345821712',0,0,NULL,1,0,0),('08dcb629-72f3-40f0-8c12-e8f102def407','Nguyễn Ngọc Hải','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F981b6e28-bf31-4db9-8ce1-24df793903e1.png?alt=media&token=66c46ef8-749f-4b49-9cb0-2d77b7da2732','Ca Mau','159852468732',1,'Male','1997-09-13','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-06-06 15:07:11.821693','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 14:58:18.977929',NULL,NULL,'0345821717','0345821717','toansol22000@gmail.com','TOANSOL22000@GMAIL.COM',0,'AQAAAAIAAYagAAAAEJt/ysgbmzsBW2Cfg92KWJmWqsK+bhfS0rm+I3Pk9+H3JV3hn8Rym3/gyD9nuX5/oA==','YISOON3SHPIMEM3I34ZEFFK5ST3AMCIK','14b9bc4a-f764-47e2-95e3-acd7e5680452','0345821717',0,0,NULL,1,0,0),('08dcb62b-07c5-4541-8654-c48ab638957b','Trần Đại Phúc','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Ff7f76aa6-78f9-4044-a8db-11d0d0f76471.jpg?alt=media&token=f2f029db-2fb5-475a-920e-70a77dd57713','huyện Đức Hòa ,tỉnh Long An','087428917639',1,'Male','1992-05-15','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-06 15:18:30.999246','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-07 15:02:12.892562',NULL,NULL,'toannnn','TOANNNN','phuctran0704@gmail.com','TOANSOLA17122660@GMAIL.COM',0,'AQAAAAIAAYagAAAAEBNPA0YNWeIrvIF8Eu7Z152jdXtLQZatR/Jy+hamZXWp0DsHiuD9yYy20PgpooM/ZA==','YM4P5KQBZWP5YMZQ4OMUARCGXAZATIAA','b55e36c8-9b40-44cd-b86f-e16952349d1c','0345821711',0,0,NULL,1,0,0),('08dcb64b-96b1-4e12-8a71-84f13e47d292','Lương Huỳnh Ngọc Hảo','https://hoanghamobile.com/tin-tuc/wp-content/uploads/2024/04/anh-thanh-pho-ve-dem.jpg','Cao Lỗ Phường 4 Quận 8','09232222441',1,'Male','09/09/2001','Anonymous','2024-07-06 19:11:34.681311','Anonymous','2024-08-06 19:11:34.696931',NULL,NULL,'0912209999','0912209999','Haoluong9999@gmail.com','HAOLUONGHUYNHNGOC@GMAIL.COM',0,'AQAAAAIAAYagAAAAEPbuHs/JIiJ/FctVSmC0//BtfPrBMqhDN+ZyQ2NMkd4CFvLncYGu+0ZmjPhJlI1AZg==','V2BD6Q5EXCM3XFF3FBMCRL67QMDFOQJS','73133941-04ce-41bf-bb9a-32d29613c2f1','0912209999',1,0,NULL,1,0,0),('08dcb69f-67c7-43be-81fe-9c26b6a92b08','Houang Gia Thành','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fd90620c6-3bfd-4280-af26-7b0fbb671796.jpg?alt=media&token=9f0061f6-99f7-453c-9ffb-c08b2de38c61','Hà Nam','171220001123',1,'Male','2002-08-07','Anonymous','2024-08-07 05:11:33.693606','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 17:01:09.636350',NULL,NULL,'0797302368','0797302368','giathanh.houang12344@gmail.com','GIATHANH.HOUANG12344@GMAIL.COM',0,'AQAAAAIAAYagAAAAEOVOMmH9JJLXWHT3/zCet6m9MVKD75XJtJwOrlbn2Jc6rNIkQjYgza2YkdavwVeAGQ==','7HGY6GAZAZHK6GOAEPM6LBLKXTZF33GE','45543765-7460-46e3-adc9-ff914df5bfb6','0797302368',1,0,NULL,1,0,0),('08dcb6ca-7842-40fe-8086-f724e6188753','Phạm Đình Thái','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F36c088b5-bdae-4c42-adfd-938d4e169e8a.jpg?alt=media&token=484235e4-e803-46e4-9df5-5fff49ca79de','huyện Đức Hòa ,tỉnh Long An','852137415371',1,'Male','1990-06-16','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-07-07 10:19:49.713012','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 10:19:49.857651',NULL,NULL,'0978517523','0978517523','phamdinhthai@gmail.com','PHAMDINHTHAI@GMAIL.COM',0,'AQAAAAIAAYagAAAAEKGdU2Qx8GOdtG/Cn9hJOhSeCwBfGnkiT+ddiMoWtIBUXrvGddFKRxR0SrNrYGL8dg==','JM4DPGQPTYXWRNUIBLJCOQJ7Y4SG32RE','f8c0ebb6-28ad-40af-a6f3-4cd61a112fbd','0978517523',1,0,NULL,1,0,0),('08dcb6ca-d4e6-45f1-8203-5c5ec6be2610','Trần Nhi Ngọc','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fec98e7ad-f722-43bf-9fc9-0dd5c60aee23.jpg?alt=media&token=38813338-6905-4376-adb4-3fa7c8ed61e6','huyện Đức Hòa ,tỉnh Long An','087428917679',1,'Female','1994-08-15','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-07 10:22:25.129279','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-14 05:28:28.826077',NULL,NULL,'0373625702','0373625702','nhingoc1508@gmail.com','NHINGOC1508@GMAIL.COM',0,'AQAAAAIAAYagAAAAEElBfyjlhUU7pdHzhcwAZrDU6DVBBwVYapiTb2Wj069u5guSOh3dMB63cdSfYmmPqw==','TV4ZYCQDFTHFZTZXKFH2VBR4MNVJCX7F','348e00b8-e21d-4364-94d2-1f8f7884a803','0373625702',1,0,NULL,1,1,0),('08dcb74b-366b-4a70-88f9-5631236a3f1b','Lê Vinh Phúc','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fb41d165c-308c-479d-98a8-eccab0df2b08.jpg?alt=media&token=7725a122-c88f-46a0-ab19-1797cba11e09','Cao Bằng, Lạng Sơn','074202157893',1,'Male','1998-08-15','Anonymous','2024-06-08 01:41:24.352390','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:59:12.585954',NULL,NULL,'0373615710','0373615710','vinhohucle@gmail.com','VINHOHUCLE@GMAIL.COM',0,'AQAAAAIAAYagAAAAEBz2RTFO/jvQHPeEGtJYG+0noRotGIiBoRGJ4qSF0MxN33GPve5y2Cn13dmhZ2VgXQ==','TSR2CKXRYLTY4JQIAQYQPW2GBVQSXPXQ','139adcde-a97b-468b-b799-4afae6a861d7','0373615710',1,0,NULL,1,0,0),('08dcb92b-98e9-444b-8ea9-0226d0ff657c','Thao Tuyen','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fd6993ba7-1db2-403f-95d3-33ad964d6d43.jpg?alt=media&token=deaa1ffc-fd1f-46b6-a702-1d88ee107a30','Nam Từ Liêm','074202124479',1,'Female','1993-06-18','Anonymous','2024-06-10 11:00:08.039763','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:58:31.756617',NULL,NULL,'0379971803','0379971803','Thaotuyen1993@mail.com','THAOTUYEN1993@MAIL.COM',0,'AQAAAAIAAYagAAAAEE0nfzTd7eYwamPzp7xuN70RGFaSlYducmR/NeFkE+v/q4Z8jfZPOJJ0TWJMVVo/Bw==','KMVBMJHLKGDZ326LKSHWZQNKNETHFKLG','5d8d17e8-9365-4c65-a64c-4cc6204215d5','0379971803',1,0,NULL,1,0,0),('08dcb94b-2350-4076-8e61-0944738bad57','Trần Vũ Thúy Vy','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F6ff02bc4-18bb-4963-b0ef-199be35fa99d.jpg?alt=media&token=e7db41d1-794b-4d35-8203-87de4826fe8e','Lê Thái Tổ, Hà Nội','214587963258',1,'Male','2002-08-08','08dcb621-e0c8-4ad9-8956-1b20ea506e0b','2024-08-10 14:45:54.590598','08dcb61e-89c3-47a0-8e9c-b6c2be2e71ca','2024-08-20 16:46:06.825974',NULL,NULL,'mymanager','MYMANAGER','mymanager@gmail.com','MYMANAGER@GMAIL.COM',0,'AQAAAAIAAYagAAAAECCM840V/la/0e0mHCzC+4gwGMhWEsk5pb6NW6i6ohlgiatgNm+LcshPzPC8UquUWA==','MGXKXSYXRJDXUGURP7LP7VB3BUZ3TGUH','a4f0c071-9612-4e1e-89bb-d646d01b483c','01235874963',0,0,NULL,1,0,0),('08dcba01-8bd2-4eea-807c-c267c857c203','Huỳnh Thúy Vy','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F0f87b738-7ed8-4bd9-8da6-c285b801678f.jpg?alt=media&token=a47c3282-def2-4aa6-a4de-d74c548c851e','Cao Lỗ Phường 43 Quận 8 Thành Phố Hồ Chí Minh','092232123311',1,'Female','2000-02-11','Anonymous','2024-08-11 12:31:38.508065','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 15:37:42.697886',NULL,NULL,'0833068017','0833068017','VyHuynh@gmail.com','VYHUYNH@GMAIL.COM',0,'AQAAAAIAAYagAAAAEFW7qJufODbByJgARxIaQ7KEktDMhx6BE6EcOjnm7lpAM7UPCbpkzWivUfjKJyPerA==','I72N6H7VUHT3OJCKISMLQIGDX2F42CMW','173720f8-a0f0-4576-86bb-ccfd520fa14d','0833068017',1,0,NULL,1,0,0),('08dcbaa3-37d3-4a43-87c7-7e7f918e9c8a','Lê Thảo My','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fb726a115-5a1e-477f-8537-d16180781227.jpg?alt=media&token=f1635874-9936-454d-9d31-45b6bc08df7f','huyện Đức Hòa ,tỉnh Long An','087428917779',1,'Female','1993-08-13','Anonymous','2024-07-12 07:48:55.945849','Anonymous','2024-08-21 03:55:55.009486',NULL,NULL,'0373615702','0373615702','toannvse150463@fpt.edu.vn','TOANNVSE150463@FPT.EDU.VN',0,'AQAAAAIAAYagAAAAEAmlTKuvwS8adwQK2EjQRzutkRnpXHCdqRZiCHH/LWZKWWLIJDW4+p1pzPKHDBXo8w==','RSTGTXIE5QTAC4TU4EEYOLJXLG52YGLE','7bfb3a5a-5020-4ed1-bbd8-54b7aad862a0','0373615702',1,0,NULL,1,0,0),('08dcbb79-7a66-40c4-89c9-9c123b56123c','Lương Huỳnh Ngọc Hảo','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F95c9ebfa-44b5-4f09-a236-8d93d45777f6.jpg?alt=media&token=5dafd40e-2466-4766-8d7c-5f1822e0fe33','Nguyễn Trãi , Quận 1 , TP Hồ Chí Minh','079202004579',1,'Male','2001-09-09','Anonymous','2024-07-13 09:22:39.875839','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-23 04:43:08.686579',NULL,NULL,'0912201924','0912201924','Haoluonghuynhngoc@gmai.com','HAOLUONGHUYNHNGOC@GMAI.COM',0,'AQAAAAIAAYagAAAAEGPeYuc+RaDD0HnQaPXhg5m4yOGnC6MgsIANanc1xM/xpyV4apq7vM3gan4ILfxbNA==','SEOXIYWARGHS4KM362FTIBEYAW5SDQ5H','8c8dcd50-d8d4-4d79-b6b7-9ec5b4855248','0912201924',1,0,NULL,1,0,0),('08dcbb82-44a6-4718-8bda-d392c5a12e22','Nguyễn Văn Toàn','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F8c5ee1c2-622d-40e7-837e-771305a643c0.jpg?alt=media&token=a2a4b136-bcbe-4647-8d7e-23e8659b44ca','huyện Đức Hòa ,tỉnh Long An','087428917634',1,'Male','2006-08-13','Anonymous','2024-07-13 10:25:35.176682','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-16 13:55:16.434589',NULL,NULL,'0345821799','0345821799','toannvse1504631@fpt.edu.vn','TOANNVSE150463@FPT.EDU.VN',0,'AQAAAAIAAYagAAAAEHt5B8ud/D+rJJ3OVvwgQ3XCXQDAICLzfErEAXLvhsEyvj6ocp/XGzEZuGbfrtnpoQ==','56JLWFZFUYZ2SMJ543GDYJQVAZGJAIYA','33b3b07e-f703-4acb-a538-c7dc8fe62815','0345821799',1,0,NULL,1,0,0),('08dcbc07-6864-4aca-8b85-d654af70c13a','Lê Hoàng Minh','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2Fa52e2952-796c-47e2-bb5e-92445252a08c.jpg?alt=media&token=5e70d54e-5a67-4806-b45f-81817a54545f','huyện Đức Hòa ,tỉnh Long An','087428917741',1,'Male','2002-08-14','Anonymous','2024-08-14 02:18:38.199258','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:56:28.460112',NULL,NULL,'0373615799','0373615799','hoangminh@gmail.com','HOANGMINH@GMAIL.COM',0,'AQAAAAIAAYagAAAAEIPee4xQhwo2T8vFC580gwaHRlwCL0RdVNfDW6uFc1P0Jqb+22FAE3hKVDbTiqXm/w==','CBIERJ77L3VFBEX6J4VAWHSRKD7HZRCE','d7b15c55-1037-4a8e-9cce-e684d14e0bf5','0373615799',1,0,NULL,1,0,0),('08dcbc2a-8a61-47a0-879f-63aa5f6b82d2','Hồ Hồng Minh','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F313db1de-c82c-40b5-a0fb-a2933a82a209.jpg?alt=media&token=13d18c69-1baf-4841-a021-c360bc84f656','Hồ Hoàn Kiếm','074302125479',1,'Female','2006-08-14','Anonymous','2024-08-14 06:30:07.606339','08dcb61e-8a7c-40ea-8a7a-9b681377e499','2024-08-20 16:54:04.454271',NULL,NULL,'0888181100','0888181100','sendy.tara@gmail.com','SENDY.TARA@GMAIL.COM',0,'AQAAAAIAAYagAAAAELsOhaDA0xc1fksxw4rQxWLEXSuk2JXq3HsExzOQD5KsU55jtgBkzjXPIv9uI4A7bA==','NZYO5HO2FQV64QDAMPVMGWRNVVO2VTSG','98c1a299-f2a8-4e9e-82a3-491fc9ac3bdd','0888181100',1,0,NULL,1,0,0),('08dcc33d-cb4c-4c30-80f7-97cbdf1a800e','Lê Hoàng Long','https://firebasestorage.googleapis.com/v0/b/careconnect-2d494.appspot.com/o/images%2F3be127ed-a90e-4364-8160-99338def0144.png?alt=media&token=3de8a6cb-0986-4347-9a22-eb369f7d02ff','',NULL,1,'Male','1996-08-23','Anonymous','2024-08-23 06:35:35.100861','Anonymous','2024-08-23 06:35:35.134578',NULL,NULL,'0978517779','0978517779','lehoanglong96@gmail.com','LEHOANGLONG96@GMAIL.COM',0,'AQAAAAIAAYagAAAAELbUB61ePN4RPIgUdBwGebLSivsaNCEIDVD8vIMWEiAmcprJv/Y6ABqhA3Une2j/sQ==','2WQUSOLLLTTJOSZRRBR6H6SV2GVY6HC2','f01dd7fd-ac6b-4721-a708-7e3e3329e832','0978517779',1,0,NULL,1,0,0);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `__EFMigrationsHistory`
--

DROP TABLE IF EXISTS `__EFMigrationsHistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__EFMigrationsHistory`
--

LOCK TABLES `__EFMigrationsHistory` WRITE;
/*!40000 ALTER TABLE `__EFMigrationsHistory` DISABLE KEYS */;
INSERT INTO `__EFMigrationsHistory` VALUES ('20240617093649_CreateInit','8.0.2'),('20240617145340_UpdateDatabaseV01','8.0.2'),('20240618140245_UpdateDatabaseV02','8.0.2'),('20240618153505_UpdateDatabaseV03','8.0.2'),('20240618163225_Add-Index-Rooms','8.0.2'),('20240620060439_Add-Method-Order','8.0.2'),('20240620061129_Update-OrderDate','8.0.2'),('20240620121633_Update-NullReference-ElderId','8.0.2'),('20240620125822_Add-PaymentReferenceId','8.0.2'),('20240620181020_CreateDiseaseCategory','8.0.2'),('20240621061025_Remove-Relationship-Appointment','8.0.2'),('20240621061139_Add-Relationship-Appointment','8.0.2'),('20240625172838_RemoveOrderAndNursingPackage','8.0.2'),('20240625173636_UpdateEntityContractNursingPackageAndOrder','8.0.2'),('20240625200602_UpdateFieldTmpIdNursingInContract','8.0.2'),('20240626044554_ChangeNameNurseSchedulerToNurseSchedule','8.0.2'),('20240626130957_UpdatePackageServiceAndNursingPackage','8.0.2'),('20240626133154_CreateOrderAndOrderDetail','8.0.2'),('20240626192512_AddFieldInServicePackageDate','8.0.2'),('20240626193529_ChangeFieldInServicePackage','8.0.2'),('20240628051743_UpdateEntityFeedback','8.0.2'),('20240628051857_UpdateEntityFeedbackV01','8.0.2'),('20240628075115_AddFieldToOrder','8.0.2'),('20240628141841_AddFieldOrderPaymentDate','8.0.2'),('20240628200053_UpdateNameShift','8.0.2'),('20240629160932_CreateImageInOrder','8.0.2'),('20240629163824_AddFieldInServicePackage','8.0.2'),('20240630120120_UpdateFieldServicePackage','8.0.2'),('20240630130515_UpdateFieldRoom','8.0.2'),('20240702114440_AddFieldInEntityOrderAndMeasureUnit','8.0.2'),('20240702115326_UpdateEnumStateInMeasureUnit','8.0.2'),('20240702120119_UpdateStatusEnum','8.0.2'),('20240702120827_RemoveShipNameStatus','8.0.2'),('20240702121129_AddShiftNameStatus','8.0.2'),('20240703194143_RemoveStatusHealthReportDetailMeasure','8.0.2'),('20240703202908_AddStatusHealthReportDetailMeasure','8.0.2'),('20240703211604_CreateDatteInHealthReport','8.0.2'),('20240704185745_CreateStatusInOrderDetail','8.0.2'),('20240707061411_CreateElderAndAppointment','8.0.2'),('20240708114010_CreateEntityScheduled','8.0.2'),('20240708170643_CreatePotentialCustomer','8.0.2'),('20240708172928_RemoveAppointmentDate','8.0.2'),('20240708173120_UpdateAppointmentDateTimeToDateOnly','8.0.2'),('20240708221322_UpdateFieldInScheduledTimeResponse','8.0.2'),('20240709072810_RemoveRelationShipUserAndPotentialCustomer','8.0.2'),('20240709072952_CreateRelationShipManyToManyUserAndPotentialCustomer','8.0.2'),('20240711081828_UpdateFieldTypeInScheduledServiceDetail','8.0.2'),('20240714154834_AddFieldInEntityOrderAndOrderDate','8.0.2'),('20240714211156_UpdateDateBase','8.0.2'),('20240714211336_UpdateEntityOrderDateAndUser','8.0.2'),('20240714213546_UpdateDatabaseOrderDate','8.0.2'),('20240716151715_CreateForeignKeyAboutAppointmentAndContract','8.0.2'),('20240718102831_RemoveShiftAndNurseSchedule','8.0.2'),('20240718102948_AddManyToManyShiftAndNurseSchedule','8.0.2'),('20240720180901_AddFieldInAppointment','8.0.2'),('20240720184839_UpdateFieldInServicePackage','8.0.2'),('20240722172415_RemoveUserAndNurseSchedule','8.0.2'),('20240722172943_AddNurseScheduleAndUser','8.0.2'),('20240722174115_UpdateNurseSchedule','8.0.2'),('20240722175130_UpdateShiftWorkerNameInNurseSchedule','8.0.2'),('20240723073857_UpdateHealthCategory','8.0.2'),('20240723120459_AddFieldStateInEntity','8.0.2'),('20240723171148_RemoveLevelNotification','8.0.2'),('20240723201616_CreatSchedule','8.0.2'),('20240723202142_UpdateSchedule','8.0.2'),('20240724194125_RemoveRoomAndCareSchedule','8.0.2'),('20240724194329_AddRoomAndCareSchedule','8.0.2'),('20240726080028_AddFieldInNotifiationAndContract','8.0.2'),('20240730121124_AddFieldIndexInUser','8.0.2'),('20240801173142_AddFieldIsActiveInOrderDetail','8.0.2'),('20240805113400_RemoveRequireDateServicePackage','8.0.2'),('20240809055001_AddTableFamilyMember','8.0.2'),('20240809062250_addStatusElderAndFamilyMember','8.0.2'),('20240809100310_UpdateEntityElder','8.0.2'),('20240809203322_RemoveGenderInFamilyMember','8.0.2'),('20240809203354_AddGenderInFamilyMember','8.0.2'),('20240815163656_ChangeConstraintsRoomInElder','8.0.2'),('20240816075241_AddFieldStateInDiseaseCategory','8.0.2');
/*!40000 ALTER TABLE `__EFMigrationsHistory` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-08-26 11:54:54
