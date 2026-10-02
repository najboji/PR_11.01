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
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product` (
  `ProductArticleNumber` varchar(6) NOT NULL,
  `ProductName` varchar(50) NOT NULL,
  `ProductUnits` varchar(5) NOT NULL,
  `ProductCost` decimal(7,2) NOT NULL,
  `ProductMaxDiscountAmount` int NOT NULL,
  `ProductManufacturer` int NOT NULL,
  `ProductSupplier` int NOT NULL,
  `ProductCategory` int NOT NULL,
  `ProductDiscountAmount` int NOT NULL,
  `ProductQuantityInStock` int NOT NULL,
  `ProductDescription` text NOT NULL,
  `ProductPhoto` blob NOT NULL,
  PRIMARY KEY (`ProductArticleNumber`),
  KEY `ProductManufacturer` (`ProductManufacturer`),
  KEY `ProductSupplier` (`ProductSupplier`),
  KEY `ProductCategory` (`ProductCategory`),
  CONSTRAINT `product_ibfk_1` FOREIGN KEY (`ProductManufacturer`) REFERENCES `productmanufacturer` (`ProductManufacturerID`),
  CONSTRAINT `product_ibfk_2` FOREIGN KEY (`ProductSupplier`) REFERENCES `productsupplier` (`ProductSupplierID`),
  CONSTRAINT `product_ibfk_3` FOREIGN KEY (`ProductCategory`) REFERENCES `productcategory` (`ProductCategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product`
--

LOCK TABLES `product` WRITE;
/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product` VALUES ('B736H6','Вилка столовая','шт.',220.00,5,4,2,1,3,4,'Вилка столовая 21,2 см «Аляска бэйсик» сталь KunstWerk',_binary 'B736H6.jpg'),('B963H5','Ложка','шт.',800.00,5,6,2,2,3,8,'Ложка 21 мм металлическая (медная) (Упаковка 10 шт)',_binary 'А112Т4.jpg'),('C430T4','Набор на одну персону','шт.',1600.00,30,2,2,3,3,6,'Набор на одну персону (4 предмета) серия \"Bistro\"\", нерж. сталь, Was, Германия.\"',_binary 'D735T5.jpg'),('C635Y6','Детский столовый набор','шт.',1000.00,15,5,1,3,4,25,'Детский столовый набор Fissman «Зебра» ',_binary 'K437E6.jpg'),('C730R7','Ложка детская','шт.',300.00,5,6,2,2,3,17,'Ложка детская столовая',_binary 'T793T4.jpg'),('C943G5','Набор чайных ложек','шт.',200.00,5,2,1,3,4,12,'Attribute Набор чайных ложек Baguette 3 предмета серебристый',_binary 'H384H3.jpg'),('C946Y6','Вилка столовая','шт.',300.00,15,5,2,1,2,16,'Вилка детская столовая',_binary 'B736H6.jpg'),('D735T5','Ложка чайная','шт.',220.00,5,4,2,2,2,13,'Ложка чайная ALASKA Eternum',_binary 'D735T5.jpg'),('E732R7','Набор столовых приборов','шт.',990.00,15,6,1,3,5,6,'Набор столовых приборов Smart Home20 Black в подарочной коробке, 4 шт',_binary 'E732R7.jpg'),('F392G6','Набор столовых приборов','шт.',490.00,10,5,2,3,4,9,'Apollo Набор столовых приборов Chicago 4 предмета серебристый',_binary 'А112Т4.jpg'),('F573T5','Вилки столовые','шт.',650.00,15,1,1,1,3,4,'Вилки столовые на блистере / 6 шт.',_binary 'F573T5.jpg'),('F745K4','Столовые приборы для салата','шт.',2000.00,10,7,2,3,3,2,'Столовые приборы для салата Orskov Lava, 2шт',_binary 'H384H3.jpg'),('F839R6','Ложка чайная','шт.',400.00,15,3,1,2,2,6,'Ложка чайная DORIA Eternum',_binary 'G387Y6.jpg'),('G304H6','Набор ложек','шт.',500.00,5,5,1,2,4,12,'Набор ложек столовых APOLLO \"Bohemica\"\" 3 пр.\"',_binary 'F573T5.jpg'),('G387Y6','Ложка столовая','шт.',441.00,5,3,1,2,4,23,'Ложка столовая DORIA L=195/60 мм Eternum',_binary 'G387Y6.jpg'),('H384H3','Набор столовых приборов','шт.',600.00,15,5,1,3,2,9,'Набор столовых приборов для торта Palette 7 предметов серебристый',_binary 'H384H3.jpg'),('H495H6','Набор стейковых ножей','шт.',7000.00,15,7,2,4,2,15,'Набор стейковых ножей 4 пр. в деревянной коробке',_binary 'B736H6.jpg'),('K437E6','Набор вилок','шт.',530.00,5,5,1,3,3,16,'Набор вилок столовых APOLLO \"Aurora\"\" 3шт.\"',_binary 'K437E6.jpg'),('L593H5','набор ножей','шт.',1300.00,25,7,1,3,5,14,'Набор ножей Mayer & Boch, 4 шт',_binary 'G387Y6.jpg'),('N493G6','Набор для серверовки','шт.',2550.00,15,6,2,3,4,6,'Набор для сервировки сыра Select',_binary 'T793T4.jpg'),('R836H6','Набор  столовых ножей','шт.',250.00,5,2,2,4,3,16,'Attribute Набор столовых ножей Baguette 2 предмета серебристый',_binary 'R836H6.jpg'),('S394J5','Набор чайных ложек','шт.',170.00,5,2,2,3,3,4,'Attribute Набор чайных ложек Chaplet 3 предмета серебристый',_binary 'K437E6.jpg'),('S395B5','Нож для стейка','шт.',600.00,10,5,2,4,4,15,'Нож для стейка 11,5 см серебристый/черный',_binary 'E732R7.jpg'),('T793T4','Набор ложек','шт.',250.00,10,2,2,2,3,16,'Набор столовых ложек Baguette 3 предмета серебристый',_binary 'T793T4.jpg'),('V026J4','набор ножей','шт.',700.00,15,5,1,3,3,9,'абор ножей для стейка и пиццы Swiss classic 2 шт. желтый',_binary 'F573T5.jpg'),('V403G6','Ложка чайная','шт.',600.00,15,3,1,2,5,24,'Ложка чайная DORIA Eternum',_binary 'R836H6.jpg'),('V727Y6','Набор десертных ложек','шт.',3000.00,10,7,2,2,4,8,'Набор десертных ложек на подставке Размер: 7*7*15 см',_binary 'D735T5.jpg'),('W295Y5','Сервировочный набор для торта','шт.',1100.00,15,2,1,3,2,16,'Набор сервировочный для торта \"Розанна\"\"\"',_binary 'R836H6.jpg'),('W405G6','Набор столовых приборов','шт.',1300.00,25,2,2,3,3,4,'Набор сервировочных столовых вилок Цветы',_binary 'E732R7.jpg'),('А112Т4','Набор вилок','шт.',1600.00,30,1,1,1,2,6,'Набор столовых вилок Davinci, 20 см 6 шт.',_binary 'А112Т4.jpg');
/*!40000 ALTER TABLE `product` ENABLE KEYS */;
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
