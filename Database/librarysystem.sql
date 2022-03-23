CREATE DATABASE  IF NOT EXISTS `librarysystem` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `librarysystem`;
-- MySQL dump 10.13  Distrib 8.0.27, for Win64 (x86_64)
--
-- Host: localhost    Database: librarysystem
-- ------------------------------------------------------
-- Server version	8.0.27

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
-- Table structure for table `lib01`
--

DROP TABLE IF EXISTS `lib01`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib01` (
  `b01f01` int NOT NULL AUTO_INCREMENT COMMENT 'UserId',
  `b01f02` varchar(50) NOT NULL COMMENT 'Name',
  `b01f03` varchar(50) DEFAULT NULL COMMENT 'MobileNumber',
  `b01f04` varchar(50) DEFAULT NULL COMMENT 'City',
  `b01f05` varchar(50) DEFAULT NULL COMMENT 'Email',
  `b01f06` varchar(50) DEFAULT NULL COMMENT 'Password',
  `b01f07` tinyint DEFAULT '0' COMMENT 'IsLibrarian',
  `b01f08` datetime DEFAULT NULL COMMENT 'EntryDate',
  PRIMARY KEY (`b01f01`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Users';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib01`
--

LOCK TABLES `lib01` WRITE;
/*!40000 ALTER TABLE `lib01` DISABLE KEYS */;
INSERT INTO `lib01` VALUES (1,'Pinal','9845621324','Rajkot','pinal@gmail.com','MX8WeAT+SlALCHDyOLof5w==',0,'2022-02-17 00:00:00'),(2,'Admin','9545632145','Rajkot','Admin@gmail.com','tK5m8F1eJbNZmyN+bA2fWA==',1,'2022-02-17 00:00:00'),(4,'Sneha','9548763215','Mumbai','Sneha@gmail.com','VoTH01287Th+ZknfRCUwsw==',0,'2022-02-20 00:00:00');
/*!40000 ALTER TABLE `lib01` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib02`
--

DROP TABLE IF EXISTS `lib02`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib02` (
  `b02f01` int NOT NULL AUTO_INCREMENT COMMENT 'BookId',
  `b02f02` varchar(50) DEFAULT NULL COMMENT 'Book Name',
  `b02f03` varchar(50) DEFAULT NULL COMMENT 'Author',
  `b02f04` varchar(200) DEFAULT NULL COMMENT 'Details',
  `b02f05` varchar(50) DEFAULT NULL COMMENT 'Publication',
  `b02f06` varchar(50) DEFAULT NULL COMMENT 'Book Type',
  `b02f07` int DEFAULT NULL COMMENT 'Total Quantities',
  `b02f08` int DEFAULT NULL COMMENT 'Available Quantities',
  `b02f09` int DEFAULT ((`b02f07` - `b02f08`)) COMMENT 'RentQnt',
  `b02f10` decimal(5,2) DEFAULT NULL COMMENT 'Price',
  `b02f11` varchar(100) DEFAULT NULL COMMENT 'Image',
  `b02f12` datetime DEFAULT NULL COMMENT 'EntryDate',
  PRIMARY KEY (`b02f01`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Book';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib02`
--

LOCK TABLES `lib02` WRITE;
/*!40000 ALTER TABLE `lib02` DISABLE KEYS */;
INSERT INTO `lib02` VALUES (3,'The Jungle Book','Rose','Jungle','Ravi Prakasan','Story',10,7,3,230.00,'dsds','2022-02-23 00:00:00');
/*!40000 ALTER TABLE `lib02` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib03`
--

DROP TABLE IF EXISTS `lib03`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib03` (
  `b03f01` int NOT NULL AUTO_INCREMENT COMMENT 'BookTypeId',
  `b03f02` varchar(50) DEFAULT NULL COMMENT 'Type',
  PRIMARY KEY (`b03f01`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Book Type';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib03`
--

LOCK TABLES `lib03` WRITE;
/*!40000 ALTER TABLE `lib03` DISABLE KEYS */;
INSERT INTO `lib03` VALUES (1,'Advanture'),(2,'Story'),(4,'Horror'),(5,'Programming');
/*!40000 ALTER TABLE `lib03` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib04`
--

DROP TABLE IF EXISTS `lib04`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib04` (
  `b04f01` int NOT NULL AUTO_INCREMENT COMMENT 'PublicationId',
  `b04f02` varchar(50) DEFAULT NULL COMMENT 'Publication',
  PRIMARY KEY (`b04f01`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Publication';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib04`
--

LOCK TABLES `lib04` WRITE;
/*!40000 ALTER TABLE `lib04` DISABLE KEYS */;
INSERT INTO `lib04` VALUES (1,'Dorling Kindersley Publishing, Incorporated'),(2,'Ravi Prakasan'),(3,'Arihant Books');
/*!40000 ALTER TABLE `lib04` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib05`
--

DROP TABLE IF EXISTS `lib05`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib05` (
  `b05f01` int NOT NULL COMMENT 'BookId',
  `b05f02` int NOT NULL COMMENT 'UserId',
  `b05f03` int DEFAULT NULL COMMENT 'Days',
  `b05f04` datetime DEFAULT NULL COMMENT 'IssueDate',
  `b05f05` datetime DEFAULT NULL COMMENT 'ReturnDate',
  `b05f06` int DEFAULT '1' COMMENT 'Status',
  PRIMARY KEY (`b05f01`,`b05f02`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Rent';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib05`
--

LOCK TABLES `lib05` WRITE;
/*!40000 ALTER TABLE `lib05` DISABLE KEYS */;
INSERT INTO `lib05` VALUES (3,1,10,'2022-02-12 17:19:57','2022-02-22 17:19:57',0),(3,2,10,'2022-02-23 17:26:32','2022-02-05 17:26:32',1),(3,4,10,'2022-03-22 10:22:42','2022-04-01 10:22:42',1);
/*!40000 ALTER TABLE `lib05` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lib06`
--

DROP TABLE IF EXISTS `lib06`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lib06` (
  `b06f01` int NOT NULL COMMENT 'UserId',
  `b06f02` int NOT NULL COMMENT 'BookId',
  `b06f03` decimal(5,2) DEFAULT NULL COMMENT 'Price',
  `b06f04` decimal(5,2) DEFAULT NULL COMMENT 'Penalty',
  `b06f05` varchar(100) DEFAULT NULL COMMENT 'Details',
  `b06f06` datetime DEFAULT NULL COMMENT 'EntryDate',
  PRIMARY KEY (`b06f01`,`b06f02`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Penalty';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lib06`
--

LOCK TABLES `lib06` WRITE;
/*!40000 ALTER TABLE `lib06` DISABLE KEYS */;
INSERT INTO `lib06` VALUES (1,3,230.00,50.00,'Late Return','2022-02-23 00:00:00');
/*!40000 ALTER TABLE `lib06` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-23 16:27:46
