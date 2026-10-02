-- MySQL dump 10.13  Distrib 8.0.43, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: pr34_smirnov
-- ------------------------------------------------------
-- Server version	9.4.0

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
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order` (
  `OrderID` int NOT NULL AUTO_INCREMENT,
  `OrderDate` date NOT NULL,
  `OrderDeliveryDate` date NOT NULL,
  `OrderPickupPoint` int NOT NULL,
  `FIO` varchar(300) NOT NULL,
  `OrderCode` int NOT NULL,
  `OrderStatus` text NOT NULL,
  PRIMARY KEY (`OrderID`),
  KEY `OrderPickupPoint` (`OrderPickupPoint`),
  CONSTRAINT `order_ibfk_1` FOREIGN KEY (`OrderPickupPoint`) REFERENCES `orderpickuppoint` (`OrderPickupPointID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'2016-05-20','2022-05-20',1,'Ситникова Эмилия Степановна',801,'Завершен'),(2,'2016-05-20','2022-05-20',14,'Иванов Иван Иванович',802,'Новый '),(3,'2017-05-20','2023-05-20',2,'Воронцова Виктория Саввична',803,'Новый '),(4,'2017-05-20','2023-05-20',22,'Сидоров Алексей Дмитриевич',804,'Новый '),(5,'2019-05-20','2025-05-20',2,'Егоров Артём Евгеньевич',805,'Новый '),(6,'2020-05-20','2026-05-20',28,'Попова Ольга Александровна',806,'Новый '),(7,'2022-05-20','2028-05-20',3,'Соколова Анна Павловна',807,'Новый '),(8,'2022-05-20','2028-05-20',32,'Новикова Ирина Константиновна',808,'Новый '),(9,'2024-05-20','2030-05-20',5,'Михайлов Павел Владимирович',809,'Новый '),(10,'2024-05-20','2030-05-20',36,'Софронов Ярослав Игоревич',810,'Новый ');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-19  0:24:46
