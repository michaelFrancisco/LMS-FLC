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
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Address` varchar(45) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
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
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Supplier_ID` int(5) unsigned NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `Unit` varchar(45) DEFAULT NULL,
  `Weight` int(11) DEFAULT NULL,
  `Critical_Level` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=322 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (1,3,'SM BONUS TOILET DEODORIZER STRAWBERRY','Finished Product',5,50,'g',50,31),(2,1,'SM Bonus Toilet Deo Ref. Lemon ','Finished Product',1281,50,'g',50,14),(3,10,'SM Bonus Toilet Deo Ref. Sampa','Finished Product',134,50,'g',50,20),(4,7,'SM Bonus Toilet Deo Ref. Straw ','Finished Product',117,100,'g',100,50),(5,4,'SM Bonus Toilet Deo Ref. Lemon','Finished Product',145,100,'g',100,13),(6,6,'SM Bonus Toilet Deo Ref. Sampa ','Finished Product',146,100,'g',100,12),(7,2,'SM Bonus Toilet Deo W/holder Straw','Finished Product',218,50,'g',50,37),(8,2,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',142,50,'g',50,33),(9,1,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',92,100,'g',100,19),(10,8,'SM Bonus Toilet Deo W/holder Straw','Finished Product',55,100,'g',100,21),(11,3,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',87,100,'g',100,11),(12,9,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',136,250,'ml',250,42),(13,9,'SM Bonus TBC Lemon','Finished Product',93,250,'ml',250,12),(14,8,'SM Bonus TBC Pine','Finished Product',122,250,'ml',250,13),(15,5,'SM Bonus TBC Sampaguita','Finished Product',133,500,'ml',500,19),(16,7,'SM Bonus TBC Lemon','Finished Product',95,500,'ml',500,39),(17,6,'SM Bonus TBC Pine','Finished Product',139,500,'ml',500,34),(18,8,'SM Bonus TBC Sampaguita','Finished Product',97,500,'ml',500,21),(19,8,'SM Bonus TBC Blue w/deo','Finished Product',85,250,'ml',250,40),(20,8,'SM Bonus TBC Blue w/de','Finished Product',106,500,'ml',500,39),(21,10,'SM Bonus TBC Yellow w/deo','Finished Product',138,250,'ml',250,31),(22,5,'SM Bonus TBC Yellow w/deo','Finished Product',70,500,'ml',500,24),(23,8,'SM Bonus Laundry Bleach','Finished Product',62,250,'ml',250,10),(24,4,'SM Bonus Laundry Bleach','Finished Product',144,1000,'ml',1000,37),(26,6,'SM Bonus Glass Clearner Spray','Finished Product',95,600,'ml',600,22),(27,9,'SM Bonus Glass Clearner Refill','Finished Product',84,600,'ml',600,28),(28,6,'Fervar In-Tank TBC Blue','Finished Product',84,50,'g',50,38),(29,7,'SM Bonus TBC 500mL + Toilet Bowl Intank','Finished Product',80,50,'g',50,45),(30,5,'SM Bonus Deo Refill 50gx3 + SMB Bleach','Finished Product',116,250,'ml',250,12),(32,2,'SM Bonus Alcohol 70%','Finished Product',59,250,'ml',250,18),(33,7,'SM Bonus Alcohol 70% ','Finished Product',135,500,'ml',500,19),(34,3,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',57,250,'ml',250,10),(35,9,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',93,500,'ml',500,47),(36,2,'SM Bonus Alcologne 40% Shower FresH','Finished Product',76,250,'ml',250,13),(37,4,'SM Bonus Alcologne 40% Shower Fresh ','Finished Product',141,500,'ml',500,22),(38,2,'SM Bonus Pure Sugar ','Finished Product',127,7,'g',7,34),(39,3,'SM Bonus Non-Dairy Creamer','Finished Product',52,3,'g',3,40),(40,3,'SM Bonus Cheese Flavored Popcorn','Finished Product',149,250,'g',250,22),(41,7,'SM Bonus Cheese Popcorn Canister','Finished Product',142,300,'g',300,20),(42,5,'SM Bonus Multi-purpose Breading mix ','Finished Product',85,100,'g',100,40),(43,1,'SM Bonus Gravy Sauce (Brown)','Finished Product',113,50,'g',50,39),(108,4,'Bateau TM1887','Raw Material',137,750,'g',750,44),(109,5,'PEG 40','Raw Material',1450,500,'g',500,10),(110,1,'Baby Fresh Scent','Raw Material',1518,1000,'ml',1000,50),(111,1,'Shower Fresh Scent','Raw Material',72,500,'ml',500,13),(112,4,'Grapesunflower','Raw Material',50,1000,'g',1000,21),(113,5,'SLES','Raw Material',67,250,'g',250,27),(114,10,'Tergitol','Raw Material',133,100,'g',100,10),(115,10,'Lactic Acid','Raw Material',133,750,'ml',750,25),(116,3,'Pine Scent HQ','Raw Material',78,500,'g',500,48),(117,7,'Blue 606 liquid','Raw Material',99,100,'g',100,27),(118,2,'Lemon Scent','Raw Material',138,100,'g',100,14),(119,3,'FDC Yellow # 5','Raw Material',115,250,'g',250,42),(120,9,'Sampa 17630','Raw Material',106,1000,'ml',1000,31),(121,6,'Butyl Cellosolve','Raw Material',142,500,'g',500,49),(122,10,'Strong Ammonia water','Raw Material',122,750,'g',750,29),(123,9,'STRAWBERRY SCENT','Raw Material',71,100,'ml',100,38),(124,10,'NAOCL','Raw Material',64,1000,'g',1000,31),(125,5,'Methyl salicylate','Raw Material',76,750,'g',750,14),(126,4,'Menthol','Raw Material',70,250,'g',250,36),(127,6,'IPA','Raw Material',112,1000,'ml',1000,12),(128,4,'Camphor','Raw Material',122,1000,'ml',1000,49),(129,7,'Eucalyptus oil','Raw Material',96,1000,'g',1000,24),(130,3,'Oil soluble green','Raw Material',98,100,'g',100,26),(131,2,'Mineral oil','Raw Material',115,100,'ml',100,42),(132,4,'White Sugar','Raw Material',57,100,'ml',100,16),(133,9,'Ferrous Sulphate Hep','Raw Material',68,250,'g',250,16),(134,8,'Sodium Benzoate','Raw Material',80,250,'ml',250,13),(135,9,'Citric Acid','Raw Material',96,250,'ml',250,22),(136,4,'Cinchona','Raw Material',74,100,'g',100,12),(137,1,'Tiki-Tiki','Raw Material',87,100,'ml',100,37),(138,1,'Ethyl Alcohol FG','Raw Material',94,500,'ml',500,10),(139,2,'Caramel Color NFH','Raw Material',77,500,'g',500,21),(140,9,'Vanilla Flavor','Raw Material',132,250,'ml',250,35),(141,5,'CAPB','Raw Material',90,500,'ml',500,24),(142,4,'Glycerine','Raw Material',141,100,'ml',100,22),(143,5,'Lactic Acid (PURAC)','Raw Material',138,1000,'ml',1000,24),(144,1,'Sodium Lactate (Purasal)','Raw Material',59,100,'g',100,49),(145,10,'Tea Tree oil','Raw Material',59,500,'g',500,40),(146,10,'Little John Texan','Raw Material',150,500,'g',500,39),(147,2,'Virginity Extract','Raw Material',81,750,'g',750,22),(148,9,'Guava Extract','Raw Material',51,1000,'ml',1000,33),(149,8,'D & C Blue #1(1% sol)','Raw Material',149,100,'g',100,31),(150,2,'Sodium Chloride','Raw Material',73,250,'ml',250,36),(151,4,'Deoplex','Raw Material',139,750,'ml',750,31),(152,8,'Tongkat ali  extract','Raw Material',53,250,'g',250,37),(153,1,'Avocado Oil','Raw Material',115,500,'g',500,39),(154,3,'Mangosteen Extract','Raw Material',65,250,'ml',250,35),(155,2,'Mango Extract','Raw Material',113,250,'ml',250,22),(156,4,'Bisabolol','Raw Material',123,500,'g',500,19),(157,6,'verstatil','Raw Material',57,750,'ml',750,50),(158,10,'MAP','Raw Material',114,1000,'g',1000,37),(159,4,'Cucumber extract','Raw Material',135,250,'g',250,42),(160,2,'Witch Hazel extract','Raw Material',58,100,'ml',100,30),(161,10,'Pentavitin','Raw Material',66,250,'ml',250,48),(162,3,'Polysorbate 20','Raw Material',141,250,'g',250,37),(163,6,'Vitamin E','Raw Material',84,250,'g',250,27),(164,7,'Euniphen','Raw Material',104,500,'ml',500,12),(165,5,'D & C Red # 33','Raw Material',91,500,'ml',500,45),(166,5,'Chicha Morada','Raw Material',93,750,'ml',750,38),(167,4,'Xanthan Gum','Raw Material',105,1000,'ml',1000,50),(168,5,'GINGER EXTRACT','Raw Material',138,100,'ml',100,43),(169,5,'Guava Extract','Raw Material',103,1000,'g',1000,36),(170,4,'SUGAR','Raw Material',54,750,'ml',750,12),(171,9,'CREAMER','Raw Material',83,500,'ml',500,49),(237,9,'SM BONUS TOILET DEO. STRAWBERRY  (FRONTLABEL)','Packaging',66,1,'na',1,42),(238,6,'SM BONUS TOILET DEO. LEMON  (FRONTLABEL)','Packaging',58,1,'na',1,43),(239,4,'SM BONUS TOILET DEO.SAMPAGUITA  (FRONTLABEL)','Packaging',58,1,'na',1,10),(240,4,'SM BonusToi. Deo REFILL Strawberry 50gms (Barcode)','Packaging',135,1,'na',1,47),(241,3,'SM BonusToi. Deo REFILL Strawberry 100gms (Barcode)','Packaging',75,1,'na',1,31),(242,10,'SM BONUS DEO HOLDER STRAW 50GMS (Barcode)','Packaging',50,1,'na',1,42),(243,8,'SM BONUS DEO HOLDER STRAW 100GMS (Barcode)','Packaging',99,1,'na',1,18),(244,6,'SM BonusToi. Deo REFILL Lemon 50gms (Barcode)','Packaging',133,1,'na',1,36),(245,7,'SM BONUS DEO REF. LEMON 100GMS (Barcode)','Packaging',120,1,'na',1,28),(246,7,'SM BONUS DEO HOLDER LEMON 50GMS (Barcode)','Packaging',122,1,'na',1,38),(247,4,'SM BONUS DEO HOLDER LEMON100GMS (Barcode)','Packaging',127,1,'na',1,11),(248,10,'BONUS DEO REFILL SAMPAGUITA 100GMS(Barcode)','Packaging',133,1,'na',1,32),(249,5,'BONUS DEO REFILL SAMPAGUITA 50GMS (Barcode)','Packaging',143,1,'na',1,42),(250,7,'BONUS DEOHolder SAMPAGUITA 50GMS (Barcode)','Packaging',118,1,'na',1,17),(251,6,'BONUS DEO HOLDER SAMPAGUITA 100GMS (Barcode)','Packaging',118,1,'na',1,29),(252,6,'SM Bonus TBC Pine 500ml set (back and Frontlabel)','Packaging',119,1,'na',1,34),(253,1,'SM BONUS TBC SAMPAGUITA 500ML LABEL SET (F/B)','Packaging',66,1,'na',1,14),(254,9,'SM BONUS TBCLEMON 500ML LABEL SET (F/B)','Packaging',129,1,'na',1,45),(255,4,'SM BONUS TBC LEMON 250ML LABEL SET (F/B)','Packaging',122,1,'na',1,31),(256,3,'SM Bonus TBC Pine 250ml set (back and Frontlabel)','Packaging',150,1,'na',1,33),(257,2,'SM BONUS TBC SAMPAGUITA 250ML LABEL SET (F/B)','Packaging',132,1,'na',1,20),(258,3,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',102,1,'na',1,37),(259,4,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',50,1,'na',1,42),(260,6,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',70,1,'na',1,10),(261,4,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',84,1,'na',1,19),(262,8,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',115,1,'na',1,26),(263,3,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',71,1,'na',1,32),(264,8,'SM BONUS GLASS CLEANER (FRONT /BACKLABEL)','Packaging',61,1,'na',1,49),(265,2,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',53,1,'na',1,35),(266,1,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',73,1,'na',1,17),(267,5,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',101,1,'na',1,13),(268,7,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',137,1,'na',1,29),(269,2,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',87,1,'na',1,11),(270,1,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',52,1,'na',1,25),(271,4,'CELLOPHANE - WHITE','Packaging',66,1,'na',1,22),(272,9,'CELLOPHANE - PINK','Packaging',133,1,'na',1,33),(273,5,'CELLOPHANE - YELLOW','Packaging',63,1,'na',1,43),(274,1,'CLEANING SOLUTION 201-0001-252','Packaging',93,1,'na',1,46),(275,6,'MAKE-UP V708-D','Packaging',129,1,'na',1,36),(276,7,'BLACK INK V435-D','Packaging',97,1,'na',1,27),(277,7,'TRIGGER SPRAYER 28MM WHITE (YUYTR100-1)','Packaging',102,1,'na',1,16),(278,3,'19.00mm ISPP (60ml Jimms Oil Liniment)','Packaging',89,1,'na',1,15),(279,5,'17.4MM ISPP  (30mL Jimms Oil Liniment)','Packaging',80,1,'na',1,17),(280,3,'34.00MM PS LINER (Trenz Purple Corn Powder Juice 350mL)','Packaging',107,1,'na',1,41),(281,9,'23.2MM SAFETY SEAL \'PE\' (SM Bonus Bleach 250mL)','Packaging',112,1,'na',1,25),(282,8,'26.5mm Safety Seal \'PE\' (SM Bonuis Bleach 1000mL)','Packaging',61,1,'na',1,40),(283,2,'31.5MM Safety Seal \'PE\' (SM Bonus 1/2 Gal )','Packaging',61,1,'na',1,46),(284,10,'22.00mm/ 18.5MM EPE Foam Washer (SM Bonus TBC)','Packaging',136,1,'na',1,13),(285,1,'CORR. BOX (RSC BFLUTE 175 lbs GLUED JOINT W/ ONE COLOR PRINT)','Packaging',135,1,'na',1,47),(286,9,'410 x 365  x 224mm x 175lbs. Test OD (500ml)','Packaging',81,1,'na',1,18),(287,6,'445 x 345 181mm x 175lbs. Test OD (250ml)','Packaging',87,1,'na',1,10),(288,9,'RSC,  C-125  LBS, Glued Joint, With Print  ','Packaging',132,1,'na',1,30),(289,2,'(Toilet deo 50g, Holder Sm Bonus) 288 x 223 x 161mm','Packaging',77,1,'na',1,14),(290,3,'50G REFILL(262 X 196 X 163mm) ','Packaging',57,1,'na',1,36),(291,8,'100G REFILL (290 x 226 x  262mm)','Packaging',149,1,'na',1,19),(292,2,'100G HOLDER (290 x 226 x 262mm)','Packaging',103,1,'na',1,37),(293,7,'54 X 30 TRANSPARENT W/ PRINT','Packaging',67,1,'na',1,16),(294,6,'46.00mm/38.mm SM BONUS TBC/ALCOHOL CAPSEAL','Packaging',129,1,'na',1,17),(295,5,'119.00mm/40.mm SM BONUS DEO CAPSEAL 100G.','Packaging',62,1,'na',1,17),(296,6,'105.00X40mm SM BONUS DEO CAPSEAL 50G.','Packaging',142,1,'na',1,29),(297,4,'60ML BOTTLE','Packaging',140,1,'na',1,37),(298,2,'DIRTY WHITE CAPS FOR 60ML','Packaging',110,1,'na',1,44),(299,2,'30ML BOTTLE','Packaging',106,1,'na',1,48),(300,6,'DIRTY WHITE CAPS FOR 30ML','Packaging',132,1,'na',1,34),(301,1,'PET GLASS CLEANER 600ML','Packaging',138,1,'na',1,20),(302,4,'7072-4076 Translucent Blue Screw on Smooth Wall with ','Packaging',140,1,'na',1,24),(303,9,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',150,1,'na',1,35),(304,5,'7072-3148 Translucent PINK Screw on Smooth Wall with ','Packaging',106,1,'na',1,34),(305,4,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',69,1,'na',1,47),(306,4,'7072-665 Translucent YELLOW Screw on Smooth Wall with ','Packaging',87,1,'na',1,14),(307,2,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',124,1,'na',1,40),(308,5,'ALCOHOL BOT 250','Packaging',137,1,'na',1,36),(309,4,'ALCOHOL BOT. 500','Packaging',55,1,'na',1,20),(310,8,'24MM FLIPTOP CAP COLORED ( +VAT )','Packaging',108,1,'na',1,35),(311,6,'PACKAGING TAPE 3\" X 90Rls.\"','Packaging',105,1,'na',1,45),(312,3,'ALCOHOL 500 CARTON','Packaging',108,1,'na',1,31),(313,7,'ALCOHOL 250 CARTON','Packaging',84,1,'na',1,43),(314,5,'DEODORANT CARTON','Packaging',121,1,'na',1,34),(315,1,'GLASS SPRAY CARTON','Packaging',67,1,'na',1,27),(316,7,'GLASS REFILL CARTON','Packaging',61,1,'na',1,24),(317,9,'HALFGALLON CARTON','Packaging',134,1,'na',1,11),(318,1,'CREAMER POUCH','Packaging',72,1,'na',1,27),(319,8,'SUGAR POUCH','Packaging',72,1,'na',1,20),(320,9,'SUGAR PLASTIC','Packaging',57,1,'na',1,36),(321,4,'CREAMER PLASTIC','Packaging',57,1,'na',1,46);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production_requests`
--

DROP TABLE IF EXISTS `production_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `production_requests` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Recipe_ID` int(5) unsigned NOT NULL,
  `Requested_By` int(10) unsigned NOT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Theoretical_Yield` int(11) DEFAULT NULL,
  `Actual_Yield` int(11) DEFAULT NULL,
  `Percent_Yield` decimal(10,2) DEFAULT NULL,
  `Date_Requested` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Due_Date` datetime DEFAULT NULL,
  `Date_Accomplished` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_requests`
--

LOCK TABLES `production_requests` WRITE;
/*!40000 ALTER TABLE `production_requests` DISABLE KEYS */;
INSERT INTO `production_requests` VALUES (72,64,7,'processing',97,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(73,65,8,'pending',65,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(74,66,9,'moved to inventory',69,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(75,67,10,'moved to inventory',80,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(76,68,11,'processing',43,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(77,69,12,'processing',20,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(78,70,13,'pending',23,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(79,71,14,'moved to inventory',41,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(80,72,15,'pending',23,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(81,73,16,'pending',26,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(82,74,17,'processing',25,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(83,75,18,'processing',42,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(84,76,19,'pending',46,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(85,77,20,'pending',25,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(86,78,21,'moved to inventory',88,NULL,NULL,'2020-02-08 02:48:44',NULL,NULL),(87,79,22,'processing',52,NULL,NULL,'2020-02-11 21:12:52',NULL,NULL),(88,80,23,'pending',45,NULL,NULL,'2020-02-12 00:40:29',NULL,NULL);
/*!40000 ALTER TABLE `production_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production_requests_items`
--

DROP TABLE IF EXISTS `production_requests_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `production_requests_items` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Request_ID` int(10) unsigned NOT NULL,
  `Item_ID` int(10) unsigned NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_requests_items`
--

LOCK TABLES `production_requests_items` WRITE;
/*!40000 ALTER TABLE `production_requests_items` DISABLE KEYS */;
/*!40000 ALTER TABLE `production_requests_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `recipe` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Item_ID` int(10) unsigned NOT NULL,
  `Ingredient_ID` int(10) unsigned NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=136 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (127,1,108,10),(128,1,109,15),(129,1,110,20),(130,2,111,3),(131,2,112,6),(132,2,113,9),(133,3,114,2),(134,3,115,4),(135,3,116,6);
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipment_items`
--

DROP TABLE IF EXISTS `shipment_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipment_items` (
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Shipment_ID` int(5) unsigned NOT NULL,
  `Item_ID` int(5) unsigned NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipment_items`
--

LOCK TABLES `shipment_items` WRITE;
/*!40000 ALTER TABLE `shipment_items` DISABLE KEYS */;
INSERT INTO `shipment_items` VALUES (6,9,3,10,NULL),(7,8,5,1,NULL),(8,2,1,6,NULL),(9,1,2,5,'Complete'),(10,8,3,7,NULL),(11,7,4,27,NULL),(12,4,5,8,NULL),(13,2,6,23,NULL),(14,2,7,13,NULL),(15,9,8,26,NULL),(16,8,9,15,NULL),(17,10,10,33,NULL),(18,9,11,23,NULL),(19,2,12,29,NULL),(20,2,13,14,NULL),(21,9,14,34,NULL),(22,2,15,35,NULL),(23,8,16,5,NULL),(24,8,17,29,NULL),(25,6,18,29,NULL),(26,2,19,9,NULL),(27,1,20,7,'Complete'),(28,10,21,31,NULL),(29,6,22,29,NULL),(30,2,23,35,NULL),(31,3,24,30,NULL),(33,7,26,29,NULL),(34,1,27,20,'Complete'),(35,10,28,23,NULL),(36,9,29,18,NULL),(37,3,30,35,NULL),(39,1,32,29,'Complete'),(40,9,33,27,NULL),(41,1,34,16,'Complete'),(42,10,35,26,NULL),(43,6,36,19,NULL),(44,1,37,17,'Complete'),(45,1,38,28,'Complete'),(46,8,39,22,NULL),(47,8,40,9,NULL),(48,4,41,21,NULL),(49,6,42,6,NULL),(50,5,43,25,NULL),(51,5,108,32,NULL),(52,10,109,24,NULL),(53,6,110,11,NULL),(54,9,111,5,NULL),(55,9,112,19,NULL),(56,2,113,26,NULL),(57,3,114,7,NULL),(58,2,115,25,NULL),(59,3,116,24,NULL),(60,4,117,17,NULL),(61,3,118,19,NULL),(62,8,119,19,NULL),(63,9,120,26,NULL),(64,1,121,17,'Complete'),(65,7,122,13,NULL),(66,3,123,20,NULL),(67,5,124,16,NULL),(68,8,125,10,NULL),(69,10,126,28,NULL),(70,4,127,34,NULL),(71,7,128,22,NULL),(72,9,129,28,NULL),(73,6,130,25,NULL),(74,5,131,6,NULL),(75,6,132,11,NULL),(76,3,133,34,NULL),(77,1,134,33,'Complete'),(78,3,135,19,NULL),(79,4,136,16,NULL),(80,10,137,13,NULL),(81,6,138,17,NULL),(82,8,139,9,NULL),(83,9,140,24,NULL),(84,1,141,30,'Complete'),(85,7,142,19,NULL),(86,3,143,34,NULL),(87,6,144,16,NULL),(88,3,145,30,NULL),(89,6,146,14,NULL),(90,9,147,11,NULL),(91,8,148,24,NULL),(92,3,149,25,NULL),(93,5,150,31,NULL),(94,10,151,19,NULL),(95,10,152,22,NULL),(96,6,153,30,NULL),(97,7,154,25,NULL),(98,1,155,12,'Complete'),(99,2,156,26,NULL),(100,7,157,26,NULL),(101,10,158,9,NULL),(102,10,159,33,NULL),(103,1,160,13,'Complete'),(104,10,161,30,NULL),(105,1,162,22,'Complete'),(106,2,163,20,NULL),(107,100,109,70,'Complete'),(108,101,108,11,'Complete'),(109,101,109,1341,'Complete'),(110,101,110,1412,'Complete'),(111,102,1,5,NULL),(112,103,4,67,'Complete');
/*!40000 ALTER TABLE `shipment_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipments`
--

DROP TABLE IF EXISTS `shipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipments` (
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Created_By` int(10) unsigned NOT NULL,
  `Truck_ID` int(5) unsigned NOT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Origin` varchar(100) DEFAULT NULL,
  `Destination` varchar(100) DEFAULT NULL,
  `Distance` decimal(10,0) DEFAULT NULL,
  `Delivery_Agent_ID` int(11) DEFAULT NULL,
  `Date_Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Date_Due` datetime DEFAULT NULL,
  `Date_Accomplished` datetime DEFAULT NULL,
  `Estimated_Time` int(11) DEFAULT NULL,
  `Actual_Time` int(11) DEFAULT NULL,
  `Delay` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=109 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (104,1,3,'Inbound','Complete','SANTA MESA HEIGHT','QUIAPO',12,2,'2019-01-24 11:36:43','2019-02-23 12:44:08','2019-03-19 22:26:25',222,248,26),(106,2,2,'Outbound','Pending','UGONG NORTE','ERMITA',14,2,'2019-01-22 05:07:28','2019-03-01 00:38:56','2019-06-22 19:53:27',90,126,36),(107,3,1,'Inbound','Pending','NOVALICHES','SANTA MESA',14,2,'2019-01-19 17:51:10','2019-02-23 10:57:39','2019-11-29 12:47:56',133,145,12),(108,4,2,'Inbound','In-Transit','NEW MANILA','SAN MIGUEL',13,2,'2019-01-07 15:58:55','2019-02-24 11:39:00','2019-10-07 07:49:30',96,132,36);
/*!40000 ALTER TABLE `shipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `supplier` (
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'5M CHEMICALS','Tyisha Ferrell','63-929-555-2433','beverly39@gmail.com','00 Hettinger Junction, Piddig 8698 Misamis Occidental'),(2,'ALYSONS CHEM','Erlene Barrick','63-928-555-8570','keith10@yahoo.com','00A McDermott Ridge, San Sebastian 3297 Leyte'),(3,'Fervar','Wilber Simmonds','63-909-555-8785','tuckermiguel@hotmail.com','02/85 Stamm Isle, Poblacion, Dapitan 8473 Lanao del Sur'),(4,'CCT CHEMICALS, INC.','Janiece Braggs','63-932-555-2705','fphillips@collins-walker.com','07/11 Zemlak Crescent, Matanao 3520 Cagayan'),(5,'CHEMISOL','Xenia Driggs','63-280-555-5286','jonesrussell@norton-gutierrez.com','11 Kunze Radial Apt. 254, Poblacion, Puerto Princesa 6133 Quezon'),(6,'CTC CHEMICALS','Gwyn Garris','63-919-555-3616','katherine31@robles.com','12A Collier Key, Poblacion, La Carlota 7245 Metro Manila'),(7,'ESSENTIAL ING. SPECIALIST INC.','Hyman Woll','63-919-555-7003','nielsenwilliam@simpson.com','14A Dare Square Suite 538, Bugasong 1776 Zamboanga Sibugay'),(8,'EUNICE INC.','Antoine Bolster','63-932-555-7515','wendymurphy@yahoo.com','15 Skiles Street, Naujan 5797 Maguindanao'),(9,'EURO CHEM','Ricky Marcoux','63-933-555-9329','wkelley@hotmail.com','19A Russel Turnpike Suite 153, Cabatuan 0921 Quirino'),(10,'HEXICHEM','Stephine Meisel','63-921-555-659','thomaslucas@yahoo.com','2205-A West Tower Philippine Stock Exchange Building Exchange StreetOrtigas Center 1605'),(11,'HIMMEL/RACHEM','Ardelle Goya','63-921-555-6193','allensherri@hotmail.com','27A Heathcote Glen Suite 961, Mahaplag 4723 Dinagat Islands'),(12,'HYCO','Julian Schaefer','63-922-555-5914','vbanks@johnson-schmidt.com','38/99 Maggio Extension, Poblacion, Baguio 8179 Cavite'),(13,'ISLANDWIDE','Julienne Schwanke','63-280-555-2350','solisjonathan@brown.com','39/83 Wiza Meadow Apt. 323, Rosario 7601 Sarangani'),(14,'J-LAI CHEMICAL CORP','Joslyn Stille','63-280-555-2671','escott@hotmail.com','45A Goyette Roads, Madamba 7299 Agusan del Sur'),(15,'KAMAGONG ENT.','Vernon Jowett','63-909-555-690','kaufmanheather@gmail.com','151 san gabriel street, Balagtas, Bulacan'),(16,'MANG NOLI','Haydee Bonenfant','63-922-555-690','nicolebowen@sutton.com','45A Windler Locks Suite 394, Poblacion, Malabon 6410 Sarangani'),(17,'NEW FLAVOR HOUSE','Lacy Martin','63-919-555-4093','csummers@shelton.com','49 Herzog Plaza, Hinigaran 0877 Negros Oriental'),(18,'NEWCHEM CO. INC.','Naomi Applin','63-910-555-5847','paulfranco@hotmail.com','49A Corwin Isle, Poblacion, Lucena 0920 Maguindanao'),(19,'OMNICIENT','Sebastian Schlottmann','63-283-555-9177','gary95@morris.org','61A Schmitt Crest Apt. 633, Poblacion, Himamaylan 6736 Guimaras'),(20,'RA. KELMAN','Peter Schweitzer','63-909-555-4643','qmullen@oliver.com','62 Rath Estates, Poblacion, Oroquieta 8794 Bohol'),(21,'RACHEM ENT.','Timika Fillmore','63-921-555-3338','ykautzer@parisian.com','63A/20 Cronin Lock Apt. 980, Santo Domingo 6305 Zamboanga del Sur'),(22,'SHAKESVILLE ENT.','Yuri Rundell','63-280-555-199','renner.anya@nolan.com','66A/63 Hartmann Trace, Sorsogon City 7304 Southern Leyte'),(23,'V.A. & SONS','Evelyne Michael','63-908-555-7622','littel.stephon@grimes.org','68 Collins Parkway, Roxas 1832 Abra'),(24,'ZEFINA MEGA SALES','Carroll Harren','63-928-555-1576','grimes.karson@gmail.com','74 Towne Manors Apt. 388, Poblacion, Meycauayan 4081 Batangas');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_log`
--

DROP TABLE IF EXISTS `system_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `system_log` (
  `ID` int(5) unsigned NOT NULL,
  `User_ID` int(5) unsigned NOT NULL,
  `Subject` varchar(100) DEFAULT NULL,
  `Body` varchar(420) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Timestamp` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_log`
--

LOCK TABLES `system_log` WRITE;
/*!40000 ALTER TABLE `system_log` DISABLE KEYS */;
INSERT INTO `system_log` VALUES (43,1,'PEG 40(70) was added to inventory','PEG 40(70) was added to inventory from Shipment no.100 and approved by Michael C. Francisco on 06/02/2020 9:31:23 PM','Inventory Update','2020-02-06 21:31:23'),(44,1,'Bateau TM1887(11) was added to inventory','Bateau TM1887(11) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(45,1,'PEG 40(1341) was added to inventory','PEG 40(1341) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(46,1,'Baby Fresh Scent(1412) was added to inventory','Baby Fresh Scent(1412) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(48,1,'SM Bonus Toilet Deo Ref. Straw (x67) was reduced from inventory','SM Bonus Toilet Deo Ref. Straw (x67) was reduced from inventory from Shipment no.103 and approved by Michael C. Francisco on 12/02/2020 8:46:52 AM','Inventory Update','2020-02-12 08:46:52'),(49,1,'SM Bonus Toilet Deo W/holder Straw(x10) was requested','SM Bonus Toilet Deo W/holder Straw(10) was requested by Michael C. Francisco on 12/02/2020 8:47:14 AM','Production Request','2020-02-12 08:47:14');
/*!40000 ALTER TABLE `system_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_log_read`
--

DROP TABLE IF EXISTS `system_log_read`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `system_log_read` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `System_Log_ID` int(10) unsigned NOT NULL,
  `User_ID` int(10) unsigned NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_log_read`
--

LOCK TABLES `system_log_read` WRITE;
/*!40000 ALTER TABLE `system_log_read` DISABLE KEYS */;
INSERT INTO `system_log_read` VALUES (1,43,7),(2,45,7),(3,46,7),(4,44,7),(5,48,7),(6,49,7);
/*!40000 ALTER TABLE `system_log_read` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trucks`
--

DROP TABLE IF EXISTS `trucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `trucks` (
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Plate_Number` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Capacity` int(11) DEFAULT NULL,
  `Kilometers_Per_Liter` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trucks`
--

LOCK TABLES `trucks` WRITE;
/*!40000 ALTER TABLE `trucks` DISABLE KEYS */;
INSERT INTO `trucks` VALUES (1,'A','A','A',1000,1000),(2,'B','B','B',1000,1000),(3,'C','C','C',1000,1000);
/*!40000 ALTER TABLE `trucks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `users` (
  `ID` int(5) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `User_Level` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (7,'Michael C. Francisco','admin','admin','IT Admin'),(8,'Driver','driver','driver','Delivery Agent'),(10,'Paul','dispensing','dispensing','Dispensing Officer'),(11,'Ringo','dispatching','dispatching','Dispatching Officer'),(12,'George','production','production','Production Officer');
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

-- Dump completed on 2020-02-20  9:58:59
