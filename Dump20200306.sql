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
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
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
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Supplier_ID` int(10) unsigned NOT NULL,
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
INSERT INTO `inventory` VALUES (1,3,'SM BONUS TOILET DEODORIZER STRAWBERRY','Finished Product',1000,50,'g',50,31),(2,1,'SM Bonus Toilet Deo Ref. Lemon ','Finished Product',1000,50,'g',50,14),(3,10,'SM Bonus Toilet Deo Ref. Sampa','Finished Product',1006,50,'g',50,20),(4,7,'SM Bonus Toilet Deo Ref. Straw ','Finished Product',1000,100,'g',100,50),(5,4,'SM Bonus Toilet Deo Ref. Lemon','Finished Product',1000,100,'g',100,13),(6,6,'SM Bonus Toilet Deo Ref. Sampa ','Finished Product',1000,100,'g',100,12),(7,2,'SM Bonus Toilet Deo W/holder Straw','Finished Product',1000,50,'g',50,37),(8,2,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',1000,50,'g',50,33),(9,1,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',1000,100,'g',100,19),(10,8,'SM Bonus Toilet Deo W/holder Straw','Finished Product',1000,100,'g',100,21),(11,3,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',1000,100,'g',100,11),(12,9,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',1000,250,'ml',250,42),(13,9,'SM Bonus TBC Lemon','Finished Product',1000,250,'ml',250,12),(14,8,'SM Bonus TBC Pine','Finished Product',1000,250,'ml',250,13),(15,5,'SM Bonus TBC Sampaguita','Finished Product',1000,500,'ml',500,19),(16,7,'SM Bonus TBC Lemon','Finished Product',1000,500,'ml',500,39),(17,6,'SM Bonus TBC Pine','Finished Product',1000,500,'ml',500,34),(18,8,'SM Bonus TBC Sampaguita','Finished Product',1000,500,'ml',500,21),(19,8,'SM Bonus TBC Blue w/deo','Finished Product',1000,250,'ml',250,40),(20,8,'SM Bonus TBC Blue w/de','Finished Product',1000,500,'ml',500,39),(21,10,'SM Bonus TBC Yellow w/deo','Finished Product',1000,250,'ml',250,31),(22,5,'SM Bonus TBC Yellow w/deo','Finished Product',1000,500,'ml',500,24),(23,8,'SM Bonus Laundry Bleach','Finished Product',1000,250,'ml',250,10),(24,4,'SM Bonus Laundry Bleach','Finished Product',1000,1000,'ml',1000,37),(26,6,'SM Bonus Glass Clearner Spray','Finished Product',1000,600,'ml',600,22),(27,9,'SM Bonus Glass Clearner Refill','Finished Product',1000,600,'ml',600,28),(28,6,'Fervar In-Tank TBC Blue','Finished Product',1000,50,'g',50,38),(29,7,'SM Bonus TBC 500mL + Toilet Bowl Intank','Finished Product',1000,50,'g',50,45),(30,5,'SM Bonus Deo Refill 50gx3 + SMB Bleach','Finished Product',1000,250,'ml',250,12),(32,2,'SM Bonus Alcohol 70%','Finished Product',1000,250,'ml',250,18),(33,7,'SM Bonus Alcohol 70% ','Finished Product',1000,500,'ml',500,19),(34,3,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',1000,250,'ml',250,10),(35,9,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',1000,500,'ml',500,47),(36,2,'SM Bonus Alcologne 40% Shower FresH','Finished Product',1000,250,'ml',250,13),(37,4,'SM Bonus Alcologne 40% Shower Fresh ','Finished Product',1000,500,'ml',500,22),(38,2,'SM Bonus Pure Sugar ','Finished Product',1000,7,'g',7,34),(39,3,'SM Bonus Non-Dairy Creamer','Finished Product',1000,3,'g',3,40),(40,3,'SM Bonus Cheese Flavored Popcorn','Finished Product',1000,250,'g',250,22),(41,7,'SM Bonus Cheese Popcorn Canister','Finished Product',1000,300,'g',300,20),(42,5,'SM Bonus Multi-purpose Breading mix ','Finished Product',1000,100,'g',100,40),(43,1,'SM Bonus Gravy Sauce (Brown)','Finished Product',1000,50,'g',50,39),(108,4,'Bateau TM1887','Raw Material',1000,750,'g',750,44),(109,5,'PEG 40','Raw Material',1000,500,'g',500,10),(110,1,'Baby Fresh Scent','Raw Material',1000,1000,'ml',1000,50),(111,1,'Shower Fresh Scent','Raw Material',1000,500,'ml',500,13),(112,4,'Grapesunflower','Raw Material',1000,1000,'g',1000,21),(113,5,'SLES','Raw Material',1000,250,'g',250,27),(114,10,'Tergitol','Raw Material',990,100,'g',100,10),(115,10,'Lactic Acid','Raw Material',980,750,'ml',750,25),(116,3,'Pine Scent HQ','Raw Material',970,500,'g',500,48),(117,7,'Blue 606 liquid','Raw Material',1000,100,'g',100,27),(118,7,'Lemon Scent','Raw Material',1000,100,'g',100,14),(119,7,'FDC Yellow # 5','Raw Material',1000,250,'g',250,42),(120,9,'Sampa 17630','Raw Material',1000,1000,'ml',1000,31),(121,6,'Butyl Cellosolve','Raw Material',1000,500,'g',500,49),(122,10,'Strong Ammonia water','Raw Material',1000,750,'g',750,29),(123,9,'STRAWBERRY SCENT','Raw Material',1000,100,'ml',100,38),(124,10,'NAOCL','Raw Material',1000,1000,'g',1000,31),(125,5,'Methyl salicylate','Raw Material',1000,750,'g',750,14),(126,4,'Menthol','Raw Material',1000,250,'g',250,36),(127,6,'IPA','Raw Material',1000,1000,'ml',1000,12),(128,4,'Camphor','Raw Material',1000,1000,'ml',1000,49),(129,7,'Eucalyptus oil','Raw Material',1000,1000,'g',1000,24),(130,3,'Oil soluble green','Raw Material',1000,100,'g',100,26),(131,2,'Mineral oil','Raw Material',1000,100,'ml',100,42),(132,4,'White Sugar','Raw Material',1000,100,'ml',100,16),(133,9,'Ferrous Sulphate Hep','Raw Material',1000,250,'g',250,16),(134,8,'Sodium Benzoate','Raw Material',1000,250,'ml',250,13),(135,9,'Citric Acid','Raw Material',1000,250,'ml',250,22),(136,4,'Cinchona','Raw Material',1000,100,'g',100,12),(137,1,'Tiki-Tiki','Raw Material',1000,100,'ml',100,37),(138,1,'Ethyl Alcohol FG','Raw Material',1000,500,'ml',500,10),(139,2,'Caramel Color NFH','Raw Material',1000,500,'g',500,21),(140,9,'Vanilla Flavor','Raw Material',1000,250,'ml',250,35),(141,5,'CAPB','Raw Material',1000,500,'ml',500,24),(142,4,'Glycerine','Raw Material',1000,100,'ml',100,22),(143,5,'Lactic Acid (PURAC)','Raw Material',1000,1000,'ml',1000,24),(144,1,'Sodium Lactate (Purasal)','Raw Material',1000,100,'g',100,49),(145,10,'Tea Tree oil','Raw Material',1000,500,'g',500,40),(146,10,'Little John Texan','Raw Material',1000,500,'g',500,39),(147,2,'Virginity Extract','Raw Material',1000,750,'g',750,22),(148,9,'Guava Extract','Raw Material',1000,1000,'ml',1000,33),(149,8,'D & C Blue #1(1% sol)','Raw Material',1000,100,'g',100,31),(150,2,'Sodium Chloride','Raw Material',1000,250,'ml',250,36),(151,4,'Deoplex','Raw Material',1000,750,'ml',750,31),(152,8,'Tongkat ali  extract','Raw Material',1000,250,'g',250,37),(153,1,'Avocado Oil','Raw Material',1000,500,'g',500,39),(154,3,'Mangosteen Extract','Raw Material',1000,250,'ml',250,35),(155,2,'Mango Extract','Raw Material',1000,250,'ml',250,22),(156,4,'Bisabolol','Raw Material',1000,500,'g',500,19),(157,6,'verstatil','Raw Material',1000,750,'ml',750,50),(158,10,'MAP','Raw Material',1000,1000,'g',1000,37),(159,4,'Cucumber extract','Raw Material',1000,250,'g',250,42),(160,2,'Witch Hazel extract','Raw Material',1000,100,'ml',100,30),(161,10,'Pentavitin','Raw Material',1000,250,'ml',250,48),(162,3,'Polysorbate 20','Raw Material',1000,250,'g',250,37),(163,6,'Vitamin E','Raw Material',1000,250,'g',250,27),(164,7,'Euniphen','Raw Material',1000,500,'ml',500,12),(165,5,'D & C Red # 33','Raw Material',1000,500,'ml',500,45),(166,5,'Chicha Morada','Raw Material',1000,750,'ml',750,38),(167,4,'Xanthan Gum','Raw Material',1000,1000,'ml',1000,50),(168,5,'GINGER EXTRACT','Raw Material',1000,100,'ml',100,43),(169,5,'Guava Extract','Raw Material',1000,1000,'g',1000,36),(170,4,'SUGAR','Raw Material',1000,750,'ml',750,12),(171,9,'CREAMER','Raw Material',1000,500,'ml',500,49),(237,9,'SM BONUS TOILET DEO. STRAWBERRY  (FRONTLABEL)','Packaging',1000,1,'na',1,42),(238,6,'SM BONUS TOILET DEO. LEMON  (FRONTLABEL)','Packaging',1000,1,'na',1,43),(239,4,'SM BONUS TOILET DEO.SAMPAGUITA  (FRONTLABEL)','Packaging',1000,1,'na',1,10),(240,4,'SM BonusToi. Deo REFILL Strawberry 50gms (Barcode)','Packaging',1000,1,'na',1,47),(241,3,'SM BonusToi. Deo REFILL Strawberry 100gms (Barcode)','Packaging',1000,1,'na',1,31),(242,10,'SM BONUS DEO HOLDER STRAW 50GMS (Barcode)','Packaging',1000,1,'na',1,42),(243,8,'SM BONUS DEO HOLDER STRAW 100GMS (Barcode)','Packaging',1000,1,'na',1,18),(244,6,'SM BonusToi. Deo REFILL Lemon 50gms (Barcode)','Packaging',1000,1,'na',1,36),(245,7,'SM BONUS DEO REF. LEMON 100GMS (Barcode)','Packaging',1000,1,'na',1,28),(246,7,'SM BONUS DEO HOLDER LEMON 50GMS (Barcode)','Packaging',1000,1,'na',1,38),(247,4,'SM BONUS DEO HOLDER LEMON100GMS (Barcode)','Packaging',1000,1,'na',1,11),(248,10,'BONUS DEO REFILL SAMPAGUITA 100GMS(Barcode)','Packaging',1000,1,'na',1,32),(249,5,'BONUS DEO REFILL SAMPAGUITA 50GMS (Barcode)','Packaging',1000,1,'na',1,42),(250,7,'BONUS DEOHolder SAMPAGUITA 50GMS (Barcode)','Packaging',1000,1,'na',1,17),(251,6,'BONUS DEO HOLDER SAMPAGUITA 100GMS (Barcode)','Packaging',1000,1,'na',1,29),(252,6,'SM Bonus TBC Pine 500ml set (back and Frontlabel)','Packaging',1000,1,'na',1,34),(253,1,'SM BONUS TBC SAMPAGUITA 500ML LABEL SET (F/B)','Packaging',1000,1,'na',1,14),(254,9,'SM BONUS TBCLEMON 500ML LABEL SET (F/B)','Packaging',1000,1,'na',1,45),(255,4,'SM BONUS TBC LEMON 250ML LABEL SET (F/B)','Packaging',1000,1,'na',1,31),(256,3,'SM Bonus TBC Pine 250ml set (back and Frontlabel)','Packaging',1000,1,'na',1,33),(257,2,'SM BONUS TBC SAMPAGUITA 250ML LABEL SET (F/B)','Packaging',1000,1,'na',1,20),(258,3,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',1000,1,'na',1,37),(259,4,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',1000,1,'na',1,42),(260,6,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',1000,1,'na',1,10),(261,4,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',1000,1,'na',1,19),(262,8,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',1000,1,'na',1,26),(263,3,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',1000,1,'na',1,32),(264,8,'SM BONUS GLASS CLEANER (FRONT /BACKLABEL)','Packaging',1000,1,'na',1,49),(265,2,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',1000,1,'na',1,35),(266,1,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',1000,1,'na',1,17),(267,5,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',1000,1,'na',1,13),(268,7,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',1000,1,'na',1,29),(269,2,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',1000,1,'na',1,11),(270,1,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',1000,1,'na',1,25),(271,4,'CELLOPHANE - WHITE','Packaging',1000,1,'na',1,22),(272,9,'CELLOPHANE - PINK','Packaging',1000,1,'na',1,33),(273,5,'CELLOPHANE - YELLOW','Packaging',1000,1,'na',1,43),(274,1,'CLEANING SOLUTION 201-0001-252','Packaging',1000,1,'na',1,46),(275,6,'MAKE-UP V708-D','Packaging',1000,1,'na',1,36),(276,7,'BLACK INK V435-D','Packaging',1000,1,'na',1,27),(277,7,'TRIGGER SPRAYER 28MM WHITE (YUYTR100-1)','Packaging',1000,1,'na',1,16),(278,3,'19.00mm ISPP (60ml Jimms Oil Liniment)','Packaging',1000,1,'na',1,15),(279,5,'17.4MM ISPP  (30mL Jimms Oil Liniment)','Packaging',1000,1,'na',1,17),(280,3,'34.00MM PS LINER (Trenz Purple Corn Powder Juice 350mL)','Packaging',1000,1,'na',1,41),(281,9,'23.2MM SAFETY SEAL \'PE\' (SM Bonus Bleach 250mL)','Packaging',1000,1,'na',1,25),(282,8,'26.5mm Safety Seal \'PE\' (SM Bonuis Bleach 1000mL)','Packaging',1000,1,'na',1,40),(283,2,'31.5MM Safety Seal \'PE\' (SM Bonus 1/2 Gal )','Packaging',1000,1,'na',1,46),(284,10,'22.00mm/ 18.5MM EPE Foam Washer (SM Bonus TBC)','Packaging',1000,1,'na',1,13),(285,1,'CORR. BOX (RSC BFLUTE 175 lbs GLUED JOINT W/ ONE COLOR PRINT)','Packaging',1000,1,'na',1,47),(286,9,'410 x 365  x 224mm x 175lbs. Test OD (500ml)','Packaging',1000,1,'na',1,18),(287,6,'445 x 345 181mm x 175lbs. Test OD (250ml)','Packaging',1000,1,'na',1,10),(288,9,'RSC,  C-125  LBS, Glued Joint, With Print  ','Packaging',1000,1,'na',1,30),(289,2,'(Toilet deo 50g, Holder Sm Bonus) 288 x 223 x 161mm','Packaging',1000,1,'na',1,14),(290,3,'50G REFILL(262 X 196 X 163mm) ','Packaging',1000,1,'na',1,36),(291,8,'100G REFILL (290 x 226 x  262mm)','Packaging',1000,1,'na',1,19),(292,2,'100G HOLDER (290 x 226 x 262mm)','Packaging',1000,1,'na',1,37),(293,7,'54 X 30 TRANSPARENT W/ PRINT','Packaging',1000,1,'na',1,16),(294,6,'46.00mm/38.mm SM BONUS TBC/ALCOHOL CAPSEAL','Packaging',1000,1,'na',1,17),(295,5,'119.00mm/40.mm SM BONUS DEO CAPSEAL 100G.','Packaging',1000,1,'na',1,17),(296,6,'105.00X40mm SM BONUS DEO CAPSEAL 50G.','Packaging',1000,1,'na',1,29),(297,4,'60ML BOTTLE','Packaging',1000,1,'na',1,37),(298,2,'DIRTY WHITE CAPS FOR 60ML','Packaging',1000,1,'na',1,44),(299,2,'30ML BOTTLE','Packaging',1000,1,'na',1,48),(300,6,'DIRTY WHITE CAPS FOR 30ML','Packaging',1000,1,'na',1,34),(301,1,'PET GLASS CLEANER 600ML','Packaging',1000,1,'na',1,20),(302,4,'7072-4076 Translucent Blue Screw on Smooth Wall with ','Packaging',1000,1,'na',1,24),(303,9,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',1000,1,'na',1,35),(304,5,'7072-3148 Translucent PINK Screw on Smooth Wall with ','Packaging',1000,1,'na',1,34),(305,4,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',1000,1,'na',1,47),(306,4,'7072-665 Translucent YELLOW Screw on Smooth Wall with ','Packaging',1000,1,'na',1,14),(307,2,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',1000,1,'na',1,40),(308,5,'ALCOHOL BOT 250','Packaging',1000,1,'na',1,36),(309,4,'ALCOHOL BOT. 500','Packaging',1000,1,'na',1,20),(310,8,'24MM FLIPTOP CAP COLORED ( +VAT )','Packaging',1000,1,'na',1,35),(311,6,'PACKAGING TAPE 3\" X 90Rls.\"','Packaging',1000,1,'na',1,45),(312,3,'ALCOHOL 500 CARTON','Packaging',1000,1,'na',1,31),(313,7,'ALCOHOL 250 CARTON','Packaging',1000,1,'na',1,43),(314,5,'DEODORANT CARTON','Packaging',1000,1,'na',1,34),(315,1,'GLASS SPRAY CARTON','Packaging',1000,1,'na',1,27),(316,7,'GLASS REFILL CARTON','Packaging',1000,1,'na',1,24),(317,9,'HALFGALLON CARTON','Packaging',1000,1,'na',1,11),(318,1,'CREAMER POUCH','Packaging',1000,1,'na',1,27),(319,8,'SUGAR POUCH','Packaging',1000,1,'na',1,20),(320,9,'SUGAR PLASTIC','Packaging',1000,1,'na',1,36),(321,4,'CREAMER PLASTIC','Packaging',1000,1,'na',1,46);
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
  `Recipe_ID` int(10) unsigned NOT NULL,
  `Requested_By` int(10) unsigned NOT NULL,
  `Status` varchar(100) DEFAULT NULL,
  `Theoretical_Yield` int(11) DEFAULT NULL,
  `Actual_Yield` int(11) DEFAULT NULL,
  `Percent_Yield` decimal(10,2) DEFAULT NULL,
  `Date_Requested` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Due_Date` datetime DEFAULT NULL,
  `Date_Accomplished` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production_requests`
--

LOCK TABLES `production_requests` WRITE;
/*!40000 ALTER TABLE `production_requests` DISABLE KEYS */;
INSERT INTO `production_requests` VALUES (145,2,7,'Finished',1,NULL,NULL,'2020-02-27 03:29:37','2020-02-27 00:00:00',NULL),(146,2,7,'Finished',1,NULL,NULL,'2020-02-27 03:36:22','2020-02-27 00:00:00',NULL),(147,3,7,'Finished',1,NULL,NULL,'2020-02-27 15:54:36','2020-02-27 00:00:00',NULL),(148,3,7,'Waiting for Raw Materials',1,NULL,NULL,'2020-02-28 20:05:05','2020-02-29 00:00:00',NULL),(149,3,7,'Finished',5,NULL,NULL,'2020-03-05 10:37:47','2020-03-05 00:00:00',NULL),(150,3,7,'Waiting for Raw Materials',1,NULL,NULL,'2020-03-05 10:42:02','2020-03-05 00:00:00',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=144 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (127,1,108,10),(128,1,109,15),(129,1,110,20),(130,2,111,3),(131,2,112,6),(132,2,113,9),(133,3,114,2),(134,3,115,4),(135,3,116,6),(136,1,117,5),(137,1,118,5),(138,1,119,10),(139,1,120,15),(140,1,121,25),(141,1,122,10),(142,1,123,10),(143,1,124,15);
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipment_items`
--

DROP TABLE IF EXISTS `shipment_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipment_items` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Shipment_ID` int(10) unsigned NOT NULL,
  `Item_ID` int(10) unsigned NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=115 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipment_items`
--

LOCK TABLES `shipment_items` WRITE;
/*!40000 ALTER TABLE `shipment_items` DISABLE KEYS */;
INSERT INTO `shipment_items` VALUES (6,9,3,10,NULL),(7,8,5,1,NULL),(8,2,1,6,NULL),(9,1,2,5,'Complete'),(10,8,3,7,NULL),(11,7,4,27,NULL),(12,4,5,8,NULL),(13,2,6,23,NULL),(14,2,7,13,NULL),(15,9,8,26,NULL),(16,8,9,15,NULL),(17,10,10,33,NULL),(18,9,11,23,NULL),(19,2,12,29,NULL),(20,2,13,14,NULL),(21,9,14,34,NULL),(22,2,15,35,NULL),(23,8,16,5,NULL),(24,8,17,29,NULL),(25,6,18,29,NULL),(26,2,19,9,NULL),(27,1,20,7,'Complete'),(28,10,21,31,NULL),(29,6,22,29,NULL),(30,2,23,35,NULL),(31,3,24,30,NULL),(33,7,26,29,NULL),(34,1,27,20,'Complete'),(35,10,28,23,NULL),(36,9,29,18,NULL),(37,3,30,35,NULL),(39,1,32,29,'Complete'),(40,9,33,27,NULL),(41,1,34,16,'Complete'),(42,10,35,26,NULL),(43,6,36,19,NULL),(44,1,37,17,'Complete'),(45,1,38,28,'Complete'),(46,8,39,22,NULL),(47,8,40,9,NULL),(48,4,41,21,NULL),(49,6,42,6,NULL),(50,5,43,25,NULL),(51,5,108,32,NULL),(52,10,109,24,NULL),(53,6,110,11,NULL),(54,9,111,5,NULL),(55,9,112,19,NULL),(56,2,113,26,NULL),(57,3,114,7,NULL),(58,2,115,25,NULL),(59,3,116,24,NULL),(60,4,117,17,NULL),(61,3,118,19,NULL),(62,8,119,19,NULL),(63,9,120,26,NULL),(64,1,121,17,'Complete'),(65,7,122,13,NULL),(66,3,123,20,NULL),(67,5,124,16,NULL),(68,8,125,10,NULL),(69,10,126,28,NULL),(70,4,127,34,NULL),(71,7,128,22,NULL),(72,9,129,28,NULL),(73,6,130,25,NULL),(74,5,131,6,NULL),(75,6,132,11,NULL),(76,3,133,34,NULL),(77,1,134,33,'Complete'),(78,3,135,19,NULL),(79,4,136,16,NULL),(80,10,137,13,NULL),(81,6,138,17,NULL),(82,8,139,9,NULL),(83,9,140,24,NULL),(84,1,141,30,'Complete'),(85,7,142,19,NULL),(86,3,143,34,NULL),(87,6,144,16,NULL),(88,3,145,30,NULL),(89,6,146,14,NULL),(90,9,147,11,NULL),(91,8,148,24,NULL),(92,3,149,25,NULL),(93,5,150,31,NULL),(94,10,151,19,NULL),(95,10,152,22,NULL),(96,6,153,30,NULL),(97,7,154,25,NULL),(98,1,155,12,'Complete'),(99,2,156,26,NULL),(100,7,157,26,NULL),(101,10,158,9,NULL),(102,10,159,33,NULL),(103,1,160,13,'Complete'),(104,10,161,30,NULL),(105,1,162,22,'Complete'),(106,2,163,20,NULL),(107,100,109,70,'Complete'),(108,101,108,11,'Complete'),(109,101,109,1341,'Complete'),(110,101,110,1412,'Complete'),(111,102,1,5,NULL),(112,103,4,67,'Complete'),(113,109,110,99,NULL),(114,110,3,6,NULL);
/*!40000 ALTER TABLE `shipment_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipments`
--

DROP TABLE IF EXISTS `shipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `shipments` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Created_By` int(10) unsigned NOT NULL,
  `Truck_ID` int(10) unsigned NOT NULL,
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
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (104,1,3,'Inbound','Complete','SANTA MESA HEIGHT','QUIAPO',12,2,'2019-01-24 11:36:43','2019-02-23 12:44:08','2019-03-19 22:26:25',222,248,26),(106,2,2,'Outbound','Pending','UGONG NORTE','ERMITA',14,2,'2019-01-22 05:07:28','2019-03-01 00:38:56','2019-06-22 19:53:27',90,126,36),(107,3,1,'Inbound','Pending','NOVALICHES','SANTA MESA',14,2,'2019-01-19 17:51:10','2019-02-23 10:57:39','2019-11-29 12:47:56',133,145,12),(108,4,2,'Inbound','In-Transit','NEW MANILA','SAN MIGUEL',13,2,'2019-01-07 15:58:55','2019-02-24 11:39:00','2019-10-07 07:49:30',96,132,36),(109,7,1,'Inbound','Pending','SANTA MESA HEIGHT','QUIAPO',NULL,8,'2020-02-23 19:37:24','2020-02-23 00:00:00',NULL,NULL,NULL,NULL),(110,7,1,'Outbound','Pending','SANTA MESA HEIGHT','QUIAPO',NULL,8,'2020-03-05 20:22:21','2020-03-05 00:00:00',NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `shipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `supplier` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `supplier`
--

LOCK TABLES `supplier` WRITE;
/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier` VALUES (1,'5M CHEMICALS','Tyisha Ferrell','63-929-555-2433','capstone420xx@gmail.com','00 Hettinger Junction, Piddig 8698 Misamis Occidental'),(2,'ALYSONS CHEM','Erlene Barrick','63-928-555-8570','capstone421xx@gmail.com','00A McDermott Ridge, San Sebastian 3297 Leyte'),(3,'Fervar','Wilber Simmonds','63-909-555-8785','fishboneashikawa001@gmail.com','02/85 Stamm Isle, Poblacion, Dapitan 8473 Lanao del Sur'),(4,'CCT CHEMICALS, INC.','Janiece Braggs','63-932-555-2705','Gafupaul001@gmail.com','07/11 Zemlak Crescent, Matanao 3520 Cagayan'),(5,'CHEMISOL','Xenia Driggs','63-280-555-5286','akosijerry001@gmail.com','11 Kunze Radial Apt. 254, Poblacion, Puerto Princesa 6133 Quezon'),(6,'CTC CHEMICALS','Gwyn Garris','63-919-555-3616','akosijunel001@gmail.com','12A Collier Key, Poblacion, La Carlota 7245 Metro Manila'),(7,'ESSENTIAL ING. SPECIALIST INC.','Hyman Woll','63-919-555-7003','lovekosijena001@gmail.com','14A Dare Square Suite 538, Bugasong 1776 Zamboanga Sibugay'),(8,'EUNICE INC.','Antoine Bolster','63-932-555-7515','ilovejazz001gmail.com','15 Skiles Street, Naujan 5797 Maguindanao'),(9,'EURO CHEM','Ricky Marcoux','63-933-555-9329','bardagul001@gmail.com','19A Russel Turnpike Suite 153, Cabatuan 0921 Quirino'),(10,'HEXICHEM','Stephine Meisel','63-921-555-659','jericgaufo08@gmail.com','2205-A West Tower Philippine Stock Exchange Building Exchange StreetOrtigas Center 1605'),(11,'HIMMEL/RACHEM','Ardelle Goya','63-921-555-6193','juneldescallar001@gmail.com','27A Heathcote Glen Suite 961, Mahaplag 4723 Dinagat Islands'),(12,'HYCO','Julian Schaefer','63-922-555-5914','caturanjayar666@gmail.com','38/99 Maggio Extension, Poblacion, Baguio 8179 Cavite'),(13,'ISLANDWIDE','Julienne Schwanke','63-280-555-2350','jericgaufo001@gmail.com','39/83 Wiza Meadow Apt. 323, Rosario 7601 Sarangani'),(14,'J-LAI CHEMICAL CORP','Joslyn Stille','63-280-555-2671','fitzpalacio@gmail.com','45A Goyette Roads, Madamba 7299 Agusan del Sur'),(15,'KAMAGONG ENT.','Vernon Jowett','63-909-555-690','samasuncion666@gmail.com','151 san gabriel street, Balagtas, Bulacan'),(16,'MANG NOLI','Haydee Bonenfant','63-922-555-690','joenavarro130130@gmail.com','45A Windler Locks Suite 394, Poblacion, Malabon 6410 Sarangani'),(17,'NEW FLAVOR HOUSE','Lacy Martin','63-919-555-4093','csummers@shelton.com','49 Herzog Plaza, Hinigaran 0877 Negros Oriental'),(18,'NEWCHEM CO. INC.','Naomi Applin','63-910-555-5847','paulfranco@hotmail.com','49A Corwin Isle, Poblacion, Lucena 0920 Maguindanao'),(19,'OMNICIENT','Sebastian Schlottmann','63-283-555-9177','gary95@morris.org','61A Schmitt Crest Apt. 633, Poblacion, Himamaylan 6736 Guimaras'),(20,'RA. KELMAN','Peter Schweitzer','63-909-555-4643','qmullen@oliver.com','62 Rath Estates, Poblacion, Oroquieta 8794 Bohol'),(21,'RACHEM ENT.','Timika Fillmore','63-921-555-3338','ykautzer@parisian.com','63A/20 Cronin Lock Apt. 980, Santo Domingo 6305 Zamboanga del Sur'),(22,'SHAKESVILLE ENT.','Yuri Rundell','63-280-555-199','renner.anya@nolan.com','66A/63 Hartmann Trace, Sorsogon City 7304 Southern Leyte'),(23,'V.A. & SONS','Evelyne Michael','63-908-555-7622','littel.stephon@grimes.org','68 Collins Parkway, Roxas 1832 Abra'),(24,'ZEFINA MEGA SALES','Carroll Harren','63-928-555-1576','rgreg1593@gmail.com','74 Towne Manors Apt. 388, Poblacion, Meycauayan 4081 Batangas');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `system_log`
--

DROP TABLE IF EXISTS `system_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `system_log` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `User_ID` int(10) unsigned NOT NULL,
  `Subject` varchar(100) DEFAULT NULL,
  `Body` varchar(420) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Timestamp` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=130 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_log`
--

LOCK TABLES `system_log` WRITE;
/*!40000 ALTER TABLE `system_log` DISABLE KEYS */;
INSERT INTO `system_log` VALUES (43,1,'PEG 40(70) was added to inventory','PEG 40(70) was added to inventory from Shipment no.100 and approved by Michael C. Francisco on 06/02/2020 9:31:23 PM','Inventory Update','2020-02-06 21:31:23'),(44,1,'Bateau TM1887(11) was added to inventory','Bateau TM1887(11) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(45,1,'PEG 40(1341) was added to inventory','PEG 40(1341) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(46,1,'Baby Fresh Scent(1412) was added to inventory','Baby Fresh Scent(1412) was added to inventory from Shipment no.101 and approved by Michael C. Francisco on 06/02/2020 9:33:12 PM','Inventory Update','2020-02-06 21:33:12'),(48,1,'SM Bonus Toilet Deo Ref. Straw (x67) was reduced from inventory','SM Bonus Toilet Deo Ref. Straw (x67) was reduced from inventory from Shipment no.103 and approved by Michael C. Francisco on 12/02/2020 8:46:52 AM','Inventory Update','2020-02-12 08:46:52'),(49,1,'SM Bonus Toilet Deo W/holder Straw(x10) was requested','SM Bonus Toilet Deo W/holder Straw(10) was requested by Michael C. Francisco on 12/02/2020 8:47:14 AM','Production Request','2020-02-12 08:47:14'),(50,7,'SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested','SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested by Michael C. Francisco on 21/02/2020 4:47:44 PM','Production Request','2020-02-21 16:47:44'),(51,7,'SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested','SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested by Michael C. Francisco on 23/02/2020 7:31:20 PM','Production Request','2020-02-23 19:31:20'),(52,7,'SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested','SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested by Michael C. Francisco on 2/27/2020 8:53:29 AM','Production Request','2020-02-27 08:53:29'),(53,7,'Bateau TM1887(x10) was reduced from inventory','Bateau TM1887(x10) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:45 AM','Inventory Update','2020-02-27 08:53:45'),(54,7,'PEG 40(x15) was reduced from inventory','PEG 40(x15) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:45 AM','Inventory Update','2020-02-27 08:53:45'),(55,7,'Baby Fresh Scent(x20) was reduced from inventory','Baby Fresh Scent(x20) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:45 AM','Inventory Update','2020-02-27 08:53:45'),(56,7,'Blue 606 liquid(x5) was reduced from inventory','Blue 606 liquid(x5) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:45 AM','Inventory Update','2020-02-27 08:53:45'),(57,7,'Lemon Scent(x5) was reduced from inventory','Lemon Scent(x5) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(58,7,'FDC Yellow # 5(x10) was reduced from inventory','FDC Yellow # 5(x10) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(59,7,'Sampa 17630(x15) was reduced from inventory','Sampa 17630(x15) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(60,7,'Butyl Cellosolve(x25) was reduced from inventory','Butyl Cellosolve(x25) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(61,7,'Strong Ammonia water(x10) was reduced from inventory','Strong Ammonia water(x10) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(62,7,'STRAWBERRY SCENT(x10) was reduced from inventory','STRAWBERRY SCENT(x10) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:46 AM','Inventory Update','2020-02-27 08:53:46'),(63,7,'NAOCL(x15) was reduced from inventory','NAOCL(x15) was reduced from inventory from Request no.139 and approved by Michael C. Francisco on 2/27/2020 8:53:47 AM','Inventory Update','2020-02-27 08:53:47'),(64,7,'SM BONUS TOILET DEODORIZER STRAWBERRY(x2) was requested','SM BONUS TOILET DEODORIZER STRAWBERRY(x2) was requested by Michael C. Francisco on 2/27/2020 10:05:49 AM','Production Request','2020-02-27 10:05:49'),(65,7,'Bateau TM1887(x20) was reduced from inventory','Bateau TM1887(x20) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:18 AM','Inventory Update','2020-02-27 10:07:18'),(66,7,'PEG 40(x30) was reduced from inventory','PEG 40(x30) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:18 AM','Inventory Update','2020-02-27 10:07:18'),(67,7,'Baby Fresh Scent(x40) was reduced from inventory','Baby Fresh Scent(x40) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:18 AM','Inventory Update','2020-02-27 10:07:18'),(68,7,'Blue 606 liquid(x10) was reduced from inventory','Blue 606 liquid(x10) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:18 AM','Inventory Update','2020-02-27 10:07:18'),(69,7,'Lemon Scent(x10) was reduced from inventory','Lemon Scent(x10) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:18 AM','Inventory Update','2020-02-27 10:07:18'),(70,7,'FDC Yellow # 5(x20) was reduced from inventory','FDC Yellow # 5(x20) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(71,7,'Sampa 17630(x30) was reduced from inventory','Sampa 17630(x30) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(72,7,'Butyl Cellosolve(x50) was reduced from inventory','Butyl Cellosolve(x50) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(73,7,'Strong Ammonia water(x20) was reduced from inventory','Strong Ammonia water(x20) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(74,7,'STRAWBERRY SCENT(x20) was reduced from inventory','STRAWBERRY SCENT(x20) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(75,7,'NAOCL(x30) was reduced from inventory','NAOCL(x30) was reduced from inventory from Request no.140 and approved by Michael C. Francisco on 2/27/2020 10:07:19 AM','Inventory Update','2020-02-27 10:07:19'),(76,7,'SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested','SM BONUS TOILET DEODORIZER STRAWBERRY(x1) was requested by Michael C. Francisco on 2/27/2020 10:19:23 AM','Production Request','2020-02-27 10:19:23'),(77,7,'Bateau TM1887(x10) was reduced from inventory','Bateau TM1887(x10) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:17 AM','Inventory Update','2020-02-27 10:28:17'),(78,7,'PEG 40(x15) was reduced from inventory','PEG 40(x15) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:17 AM','Inventory Update','2020-02-27 10:28:17'),(79,7,'Baby Fresh Scent(x20) was reduced from inventory','Baby Fresh Scent(x20) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:17 AM','Inventory Update','2020-02-27 10:28:17'),(80,7,'Blue 606 liquid(x5) was reduced from inventory','Blue 606 liquid(x5) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:18 AM','Inventory Update','2020-02-27 10:28:18'),(81,7,'Lemon Scent(x5) was reduced from inventory','Lemon Scent(x5) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:18 AM','Inventory Update','2020-02-27 10:28:18'),(82,7,'FDC Yellow # 5(x10) was reduced from inventory','FDC Yellow # 5(x10) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:18 AM','Inventory Update','2020-02-27 10:28:18'),(83,7,'Sampa 17630(x15) was reduced from inventory','Sampa 17630(x15) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:18 AM','Inventory Update','2020-02-27 10:28:18'),(84,7,'Butyl Cellosolve(x25) was reduced from inventory','Butyl Cellosolve(x25) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:18 AM','Inventory Update','2020-02-27 10:28:18'),(85,7,'Strong Ammonia water(x10) was reduced from inventory','Strong Ammonia water(x10) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:19 AM','Inventory Update','2020-02-27 10:28:19'),(86,7,'STRAWBERRY SCENT(x10) was reduced from inventory','STRAWBERRY SCENT(x10) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:19 AM','Inventory Update','2020-02-27 10:28:19'),(87,7,'NAOCL(x15) was reduced from inventory','NAOCL(x15) was reduced from inventory from Request no.141 and approved by Michael C. Francisco on 2/27/2020 10:28:19 AM','Inventory Update','2020-02-27 10:28:19'),(88,7,'SM Bonus Toilet Deo Ref. Lemon (x1) was requested','SM Bonus Toilet Deo Ref. Lemon (x1) was requested by Michael C. Francisco on 2/27/2020 10:57:45 AM','Production Request','2020-02-27 10:57:45'),(89,7,'SM Bonus Toilet Deo Ref. Lemon (x2) was requested','SM Bonus Toilet Deo Ref. Lemon (x2) was requested by Michael C. Francisco on 2/27/2020 10:59:06 AM','Production Request','2020-02-27 10:59:06'),(90,7,'SM Bonus Toilet Deo Ref. Lemon (x2) was requested','SM Bonus Toilet Deo Ref. Lemon (x2) was requested by Michael C. Francisco on 2/27/2020 11:00:34 AM','Production Request','2020-02-27 11:00:34'),(91,7,'Shower Fresh Scent(x6) was reduced from inventory','Shower Fresh Scent(x6) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:27:38 AM','Inventory Update','2020-02-27 11:27:38'),(92,7,'Grapesunflower(x12) was reduced from inventory','Grapesunflower(x12) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:27:39 AM','Inventory Update','2020-02-27 11:27:39'),(93,7,'SLES(x18) was reduced from inventory','SLES(x18) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:27:39 AM','Inventory Update','2020-02-27 11:27:39'),(94,7,'Shower Fresh Scent(x6) was reduced from inventory','Shower Fresh Scent(x6) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:28:07 AM','Inventory Update','2020-02-27 11:28:07'),(95,7,'Grapesunflower(x12) was reduced from inventory','Grapesunflower(x12) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:28:07 AM','Inventory Update','2020-02-27 11:28:07'),(96,7,'SLES(x18) was reduced from inventory','SLES(x18) was reduced from inventory from Request no.144 and approved by Michael C. Francisco on 2/27/2020 11:28:07 AM','Inventory Update','2020-02-27 11:28:07'),(97,7,'SM Bonus Toilet Deo Ref. Lemon (x1) was requested','SM Bonus Toilet Deo Ref. Lemon (x1) was requested by Michael C. Francisco on 2/27/2020 11:29:37 AM','Production Request','2020-02-27 11:29:37'),(98,7,'Shower Fresh Scent(x3) was reduced from inventory','Shower Fresh Scent(x3) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:29:54 AM','Inventory Update','2020-02-27 11:29:54'),(99,7,'Grapesunflower(x6) was reduced from inventory','Grapesunflower(x6) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:29:54 AM','Inventory Update','2020-02-27 11:29:54'),(100,7,'SLES(x9) was reduced from inventory','SLES(x9) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:29:54 AM','Inventory Update','2020-02-27 11:29:54'),(101,7,'Shower Fresh Scent(x3) was reduced from inventory','Shower Fresh Scent(x3) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:30:02 AM','Inventory Update','2020-02-27 11:30:02'),(102,7,'Grapesunflower(x6) was reduced from inventory','Grapesunflower(x6) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:30:02 AM','Inventory Update','2020-02-27 11:30:02'),(103,7,'SLES(x9) was reduced from inventory','SLES(x9) was reduced from inventory from Request no.145 and approved by Michael C. Francisco on 2/27/2020 11:30:03 AM','Inventory Update','2020-02-27 11:30:03'),(104,7,'SM Bonus Toilet Deo Ref. Lemon (x1) was requested','SM Bonus Toilet Deo Ref. Lemon (x1) was requested by Michael C. Francisco on 2/27/2020 11:36:22 AM','Production Request','2020-02-27 11:36:23'),(105,7,'Shower Fresh Scent(x3) was reduced from inventory','Shower Fresh Scent(x3) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:34 AM','Inventory Update','2020-02-27 11:36:34'),(106,7,'Grapesunflower(x6) was reduced from inventory','Grapesunflower(x6) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:34 AM','Inventory Update','2020-02-27 11:36:34'),(107,7,'SLES(x9) was reduced from inventory','SLES(x9) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:34 AM','Inventory Update','2020-02-27 11:36:34'),(108,7,'Shower Fresh Scent(x3) was reduced from inventory','Shower Fresh Scent(x3) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:41 AM','Inventory Update','2020-02-27 11:36:41'),(109,7,'Grapesunflower(x6) was reduced from inventory','Grapesunflower(x6) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:41 AM','Inventory Update','2020-02-27 11:36:41'),(110,7,'SLES(x9) was reduced from inventory','SLES(x9) was reduced from inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 11:36:42 AM','Inventory Update','2020-02-27 11:36:42'),(111,7,'SM Bonus Toilet Deo Ref. Lemon (x1) was added to inventory','SM Bonus Toilet Deo Ref. Lemon (x1) was added to inventory from Request no.146 and approved by Michael C. Francisco on 2/27/2020 12:29:53 PM','Inventory Update','2020-02-27 12:29:53'),(112,7,'SM Bonus Toilet Deo Ref. Sampa(x1) was requested','SM Bonus Toilet Deo Ref. Sampa(x1) was requested by Michael C. Francisco on 2/27/2020 11:54:36 PM','Production Request','2020-02-27 23:54:36'),(113,7,'Tergitol(x2) was reduced from inventory','Tergitol(x2) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:54:52 PM','Inventory Update','2020-02-27 23:54:52'),(114,7,'Lactic Acid(x4) was reduced from inventory','Lactic Acid(x4) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:54:53 PM','Inventory Update','2020-02-27 23:54:53'),(115,7,'Pine Scent HQ(x6) was reduced from inventory','Pine Scent HQ(x6) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:54:53 PM','Inventory Update','2020-02-27 23:54:53'),(116,7,'Tergitol(x2) was reduced from inventory','Tergitol(x2) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:55:03 PM','Inventory Update','2020-02-27 23:55:03'),(117,7,'Lactic Acid(x4) was reduced from inventory','Lactic Acid(x4) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:55:03 PM','Inventory Update','2020-02-27 23:55:03'),(118,7,'Pine Scent HQ(x6) was reduced from inventory','Pine Scent HQ(x6) was reduced from inventory from Request no.147 and approved by Michael C. Francisco on 2/27/2020 11:55:03 PM','Inventory Update','2020-02-27 23:55:03'),(119,7,'SM Bonus Toilet Deo Ref. Sampa(x1) was requested','SM Bonus Toilet Deo Ref. Sampa(x1) was requested by Michael C. Francisco on 2/29/2020 4:05:06 AM','Production Request','2020-02-29 04:05:06'),(120,7,'SM Bonus Toilet Deo Ref. Sampa(x5) was requested','SM Bonus Toilet Deo Ref. Sampa(x5) was requested by Michael C. Francisco on 3/5/2020 6:37:48 PM','Production Request','2020-03-05 18:37:48'),(121,7,'SM Bonus Toilet Deo Ref. Sampa(x1) was requested','SM Bonus Toilet Deo Ref. Sampa(x1) was requested by Michael C. Francisco on 3/5/2020 6:42:02 PM','Production Request','2020-03-05 18:42:02'),(122,7,'Tergitol(x10) was reduced from inventory','Tergitol(x10) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 6:47:36 PM','Inventory Update','2020-03-05 18:47:36'),(123,7,'Lactic Acid(x20) was reduced from inventory','Lactic Acid(x20) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 6:47:36 PM','Inventory Update','2020-03-05 18:47:36'),(124,7,'Pine Scent HQ(x30) was reduced from inventory','Pine Scent HQ(x30) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 6:47:36 PM','Inventory Update','2020-03-05 18:47:36'),(125,7,'Tergitol(x10) was reduced from inventory','Tergitol(x10) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 7:17:37 PM','Inventory Update','2020-03-05 19:17:37'),(126,7,'Lactic Acid(x20) was reduced from inventory','Lactic Acid(x20) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 7:17:38 PM','Inventory Update','2020-03-05 19:17:38'),(127,7,'Pine Scent HQ(x30) was reduced from inventory','Pine Scent HQ(x30) was reduced from inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 7:17:38 PM','Inventory Update','2020-03-05 19:17:38'),(128,7,'SM Bonus Toilet Deo Ref. Sampa(x1) was added to inventory','SM Bonus Toilet Deo Ref. Sampa(x1) was added to inventory from Request no.147 and approved by Michael C. Francisco on 3/5/2020 7:27:41 PM','Inventory Update','2020-03-05 19:27:41'),(129,7,'SM Bonus Toilet Deo Ref. Sampa(x5) was added to inventory','SM Bonus Toilet Deo Ref. Sampa(x5) was added to inventory from Request no.149 and approved by Michael C. Francisco on 3/5/2020 7:27:51 PM','Inventory Update','2020-03-05 19:27:51');
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
) ENGINE=InnoDB AUTO_INCREMENT=87 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_log_read`
--

LOCK TABLES `system_log_read` WRITE;
/*!40000 ALTER TABLE `system_log_read` DISABLE KEYS */;
INSERT INTO `system_log_read` VALUES (1,43,7),(2,45,7),(3,46,7),(4,44,7),(5,48,7),(6,49,7),(7,50,7),(8,51,7),(9,52,7),(10,53,7),(11,54,7),(12,55,7),(13,56,7),(14,57,7),(15,58,7),(16,59,7),(17,60,7),(18,61,7),(19,62,7),(20,63,7),(21,64,7),(22,65,7),(23,66,7),(24,67,7),(25,68,7),(26,69,7),(27,70,7),(28,71,7),(29,72,7),(30,73,7),(31,74,7),(32,75,7),(33,76,7),(34,77,7),(35,78,7),(36,79,7),(37,80,7),(38,81,7),(39,82,7),(40,83,7),(41,84,7),(42,85,7),(43,86,7),(44,87,7),(45,88,7),(46,89,7),(47,111,7),(48,90,7),(49,91,7),(50,92,7),(51,93,7),(52,94,7),(53,95,7),(54,96,7),(55,97,7),(56,98,7),(57,99,7),(58,100,7),(59,101,7),(60,102,7),(61,103,7),(62,104,7),(63,105,7),(64,106,7),(65,107,7),(66,108,7),(67,109,7),(68,110,7),(69,112,7),(70,113,7),(71,114,7),(72,115,7),(73,116,7),(74,117,7),(75,118,7),(76,119,7),(77,120,7),(78,121,7),(79,122,7),(80,123,7),(81,124,7),(82,125,7),(83,126,7),(84,127,7),(85,128,7),(86,129,7);
/*!40000 ALTER TABLE `system_log_read` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trucks`
--

DROP TABLE IF EXISTS `trucks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `trucks` (
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
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
  `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,
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

-- Dump completed on 2020-03-06  8:03:59
