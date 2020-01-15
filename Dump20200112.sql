-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: flc
-- ------------------------------------------------------
-- Server version	8.0.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `client` (
  `Client_Id` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Address` varchar(45) DEFAULT NULL,
  `Client_Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Client_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=100004 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (10005,'Shaw Boulevard, Mandaluyong City','SM Megamall','Shawn Mendes','09415581956'),(100001,'Damong Maliit, Malinta, Quezon City','SM Novaliches','Jennifer Bayani','09451875991'),(100002,'Legarda Avenue, Manila','SM San Lazaro','Tannie De Guzman','09294157414'),(100003,'San Antonio, Edsa, Quezon City','SM North Edsa','Vilma Santos','09581234565');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `inventory` (
  `Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Quantity` int(10) DEFAULT NULL,
  `Size` int(10) DEFAULT NULL,
  `Unit` varchar(45) DEFAULT NULL,
  `Critical_Level` int(10) DEFAULT NULL,
  `RFID` varchar(45) DEFAULT NULL,
  `Supplier_ID` int(5) DEFAULT NULL,
  PRIMARY KEY (`Item_ID`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (00001,'Water','Raw Material ',100,500,'ML',100,'11234',1),(00002,'Bottle','Packaging',100,500,'ML',100,'12432',2),(00003,'Bottle of Water','Finished Product',100,5001,'ML',1001,'124331',3),(00005,'Bleach','Raw Material',100,500,'ml',10,NULL,4);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipment_items`
--

DROP TABLE IF EXISTS `shipment_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipment_items` (
  `Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Shipment_ID` int(5) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`Item_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipment_items`
--

LOCK TABLES `shipment_items` WRITE;
/*!40000 ALTER TABLE `shipment_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `shipment_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipments`
--

DROP TABLE IF EXISTS `shipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipments` (
  `Shipment_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Category` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Origin` varchar(100) DEFAULT NULL,
  `Destination` varchar(100) DEFAULT NULL,
  `Truck_ID` int(5) DEFAULT NULL,
  `Delivery_Agent_ID` int(5) DEFAULT NULL,
  `Date_Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Date_Due` datetime DEFAULT NULL,
  `Date_Accomplished` datetime DEFAULT NULL,
  PRIMARY KEY (`Shipment_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (00001,'Inbound','In-Transit','Sauyo','Trinoma',1,2,'2020-01-01 23:00:19',NULL,NULL),(00002,'Outbound','Accomplished','Bayan','Sm North',1,2,'2020-01-01 23:00:19',NULL,NULL),(00003,'Inbound','Accomplished','RP','Bayan',1,2,'2020-01-01 23:00:19',NULL,NULL),(00004,'Outbound','In-Transit','Holy Cross','Sm Fairview',1,2,'2020-01-01 23:00:19',NULL,NULL);
/*!40000 ALTER TABLE `shipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `supplier` (
  `Supplier_Id` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Supplier_Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Supplier_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (00001,'5M CHEMICALS','Tyisha Ferrell','63-929-555-2433','beverly39@gmail.com','00 Hettinger Junction, Piddig 8698 Misamis Occidental'),(00002,'ALYSONS CHEM','Erlene Barrick','63-928-555-8570','keith10@yahoo.com','00A McDermott Ridge, San Sebastian 3297 Leyte'),(00003,'Fervar','Wilber Simmonds','63-909-555-8785','tuckermiguel@hotmail.com','02/85 Stamm Isle, Poblacion, Dapitan 8473 Lanao del Sur'),(00004,'CCT CHEMICALS, INC.','Janiece Braggs','63-932-555-2705','fphillips@collins-walker.com','07/11 Zemlak Crescent, Matanao 3520 Cagayan'),(00005,'CHEMISOL','Xenia Driggs','63-280-555-5286','jonesrussell@norton-gutierrez.com','11 Kunze Radial Apt. 254, Poblacion, Puerto Princesa 6133 Quezon'),(00006,'CTC CHEMICALS','Gwyn Garris','63-919-555-3616','katherine31@robles.com','12A Collier Key, Poblacion, La Carlota 7245 Metro Manila'),(00007,'ESSENTIAL ING. SPECIALIST INC.','Hyman Woll','63-919-555-7003','nielsenwilliam@simpson.com','14A Dare Square Suite 538, Bugasong 1776 Zamboanga Sibugay'),(00008,'EUNICE INC.','Antoine Bolster','63-932-555-7515','wendymurphy@yahoo.com','15 Skiles Street, Naujan 5797 Maguindanao'),(00009,'EURO CHEM','Ricky Marcoux','63-933-555-9329','wkelley@hotmail.com','19A Russel Turnpike Suite 153, Cabatuan 0921 Quirino'),(00010,'HEXICHEM','Stephine Meisel','63-921-555-659','thomaslucas@yahoo.com','2205-A West Tower Philippine Stock Exchange Building Exchange StreetOrtigas Center 1605'),(00011,'HIMMEL/RACHEM','Ardelle Goya','63-921-555-6193','allensherri@hotmail.com','27A Heathcote Glen Suite 961, Mahaplag 4723 Dinagat Islands'),(00012,'HYCO','Julian Schaefer','63-922-555-5914','vbanks@johnson-schmidt.com','38/99 Maggio Extension, Poblacion, Baguio 8179 Cavite'),(00013,'ISLANDWIDE','Julienne Schwanke','63-280-555-2350','solisjonathan@brown.com','39/83 Wiza Meadow Apt. 323, Rosario 7601 Sarangani'),(00014,'J-LAI CHEMICAL CORP','Joslyn Stille','63-280-555-2671','escott@hotmail.com','45A Goyette Roads, Madamba 7299 Agusan del Sur'),(00015,'KAMAGONG ENT.','Vernon Jowett','63-909-555-690','kaufmanheather@gmail.com','151 san gabriel street, Balagtas, Bulacan'),(00016,'MANG NOLI','Haydee Bonenfant','63-922-555-690','nicolebowen@sutton.com','45A Windler Locks Suite 394, Poblacion, Malabon 6410 Sarangani'),(00017,'NEW FLAVOR HOUSE','Lacy Martin','63-919-555-4093','csummers@shelton.com','49 Herzog Plaza, Hinigaran 0877 Negros Oriental'),(00018,'NEWCHEM CO. INC.','Naomi Applin','63-910-555-5847','paulfranco@hotmail.com','49A Corwin Isle, Poblacion, Lucena 0920 Maguindanao'),(00019,'OMNICIENT','Sebastian Schlottmann','63-283-555-9177','gary95@morris.org','61A Schmitt Crest Apt. 633, Poblacion, Himamaylan 6736 Guimaras'),(00020,'RA. KELMAN','Peter Schweitzer','63-909-555-4643','qmullen@oliver.com','62 Rath Estates, Poblacion, Oroquieta 8794 Bohol'),(00021,'RACHEM ENT.','Timika Fillmore','63-921-555-3338','ykautzer@parisian.com','63A/20 Cronin Lock Apt. 980, Santo Domingo 6305 Zamboanga del Sur'),(00022,'SHAKESVILLE ENT.','Yuri Rundell','63-280-555-199','renner.anya@nolan.com','66A/63 Hartmann Trace, Sorsogon City 7304 Southern Leyte'),(00023,'V.A. & SONS','Evelyne Michael','63-908-555-7622','littel.stephon@grimes.org','68 Collins Parkway, Roxas 1832 Abra'),(00024,'ZEFINA MEGA SALES','Carroll Harren','63-928-555-1576','grimes.karson@gmail.com','74 Towne Manors Apt. 388, Poblacion, Meycauayan 4081 Batangas');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trucks`
--

DROP TABLE IF EXISTS `trucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `trucks` (
  `Truck_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Plate_Number` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Capacity` int(11) DEFAULT NULL,
  PRIMARY KEY (`Truck_ID`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trucks`
--

LOCK TABLES `trucks` WRITE;
/*!40000 ALTER TABLE `trucks` DISABLE KEYS */;
INSERT INTO `trucks` VALUES (00001,'Isuzu','URD-427','Box Truck',6200);
/*!40000 ALTER TABLE `trucks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `User_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `User_Level` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`User_ID`),
  UNIQUE KEY `Username_UNIQUE` (`Username`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (00001,'Michael C. Francisco','admin','admin','IT'),(00002,'Antonio Roberto','driver','driver','Delivery Agent');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-15 14:33:28
