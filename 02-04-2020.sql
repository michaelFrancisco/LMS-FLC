-- MySQL dump 10.13  Distrib 8.0.18, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: flc
-- ------------------------------------------------------
-- Server version	8.0.18

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
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `client` (
  `Client_Id` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `trucks_Truck_ID` int(5) unsigned zerofill NOT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `Client_Name` varchar(45) DEFAULT NULL,
  `Contact_Person` varchar(45) DEFAULT NULL,
  `Contact_Number` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Client_Id`),
  KEY `fk_client_trucks1_idx` (`trucks_Truck_ID`),
  CONSTRAINT `fk_client_trucks1` FOREIGN KEY (`trucks_Truck_ID`) REFERENCES `trucks` (`Truck_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=100004 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (10005,00000,'Shaw Boulevard, Mandaluyong City','SM Megamall','Shawn Mendes','09415581956'),(100001,00000,'Damong Maliit, Malinta, Quezon City','SM Novaliches','Jennifer Bayani','09451875991'),(100002,00000,'Legarda Avenue, Manila','SM San Lazaro','Tannie De Guzman','09294157414'),(100003,00000,'San Antonio, Edsa, Quezon City','SM North Edsa','Vilma Santos','09581234565');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory`
--

DROP TABLE IF EXISTS `inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Supplier_ID` int(5) unsigned zerofill NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `Unit` varchar(45) DEFAULT NULL,
  `Weight` int(11) DEFAULT NULL,
  `Critical_Level` int(11) DEFAULT NULL,
  PRIMARY KEY (`Item_ID`),
  KEY `fk_inventory_supplier1_idx` (`Supplier_ID`),
  CONSTRAINT `fk_inventory_supplier1` FOREIGN KEY (`Supplier_ID`) REFERENCES `supplier` (`Supplier_Id`)
) ENGINE=InnoDB AUTO_INCREMENT=577 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (00001,00003,'SM BONUS TOILET DEODORIZER STRAWBERRY','Finished Product',113,50,'g',50,31),(00002,00001,'SM Bonus Toilet Deo Ref. Lemon ','Finished Product',81,50,'g',50,14),(00003,00010,'SM Bonus Toilet Deo Ref. Sampa','Finished Product',134,50,'g',50,20),(00004,00007,'SM Bonus Toilet Deo Ref. Straw ','Finished Product',117,100,'g',100,50),(00005,00004,'SM Bonus Toilet Deo Ref. Lemon','Finished Product',145,100,'g',100,13),(00006,00006,'SM Bonus Toilet Deo Ref. Sampa ','Finished Product',98,100,'g',100,12),(00007,00002,'SM Bonus Toilet Deo W/holder Straw','Finished Product',118,50,'g',50,37),(00008,00002,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',142,50,'g',50,33),(00009,00001,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',92,100,'g',100,19),(00010,00008,'SM Bonus Toilet Deo W/holder Straw','Finished Product',55,100,'g',100,21),(00011,00003,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',87,100,'g',100,11),(00012,00009,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',136,250,'ml',250,42),(00013,00009,'SM Bonus TBC Lemon','Finished Product',93,250,'ml',250,12),(00014,00008,'SM Bonus TBC Pine','Finished Product',122,250,'ml',250,13),(00015,00005,'SM Bonus TBC Sampaguita','Finished Product',133,500,'ml',500,19),(00016,00007,'SM Bonus TBC Lemon','Finished Product',95,500,'ml',500,39),(00017,00006,'SM Bonus TBC Pine','Finished Product',139,500,'ml',500,34),(00018,00008,'SM Bonus TBC Sampaguita','Finished Product',97,500,'ml',500,21),(00019,00008,'SM Bonus TBC Blue w/deo','Finished Product',85,250,'ml',250,40),(00020,00008,'SM Bonus TBC Blue w/de','Finished Product',106,500,'ml',500,39),(00021,00010,'SM Bonus TBC Yellow w/deo','Finished Product',138,250,'ml',250,31),(00022,00005,'SM Bonus TBC Yellow w/deo','Finished Product',70,500,'ml',500,24),(00023,00008,'SM Bonus Laundry Bleach','Finished Product',62,250,'ml',250,10),(00024,00004,'SM Bonus Laundry Bleach','Finished Product',144,1000,'ml',1000,37),(00026,00006,'SM Bonus Glass Clearner Spray','Finished Product',95,600,'ml',600,22),(00027,00009,'SM Bonus Glass Clearner Refill','Finished Product',84,600,'ml',600,28),(00028,00006,'Fervar In-Tank TBC Blue','Finished Product',84,50,'g',50,38),(00029,00007,'SM Bonus TBC 500mL + Toilet Bowl Intank','Finished Product',80,50,'g',50,45),(00030,00005,'SM Bonus Deo Refill 50gx3 + SMB Bleach','Finished Product',116,250,'ml',250,12),(00032,00002,'SM Bonus Alcohol 70%','Finished Product',59,250,'ml',250,18),(00033,00007,'SM Bonus Alcohol 70% ','Finished Product',135,500,'ml',500,19),(00034,00003,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',57,250,'ml',250,10),(00035,00009,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',93,500,'ml',500,47),(00036,00002,'SM Bonus Alcologne 40% Shower FresH','Finished Product',76,250,'ml',250,13),(00037,00004,'SM Bonus Alcologne 40% Shower Fresh ','Finished Product',141,500,'ml',500,22),(00038,00002,'SM Bonus Pure Sugar ','Finished Product',127,7,'g',7,34),(00039,00003,'SM Bonus Non-Dairy Creamer','Finished Product',52,3,'g',3,40),(00040,00003,'SM Bonus Cheese Flavored Popcorn','Finished Product',149,250,'g',250,22),(00041,00007,'SM Bonus Cheese Popcorn Canister','Finished Product',142,300,'g',300,20),(00042,00005,'SM Bonus Multi-purpose Breading mix ','Finished Product',85,100,'g',100,40),(00043,00001,'SM Bonus Gravy Sauce (Brown)','Finished Product',113,50,'g',50,39),(00108,00004,'Bateau TM1887','Raw Material',126,750,'g',750,44),(00109,00005,'PEG 40','Raw Material',109,500,'g',500,10),(00110,00001,'Baby Fresh Scent','Raw Material',106,1000,'ml',1000,50),(00111,00001,'Shower Fresh Scent','Raw Material',72,500,'ml',500,13),(00112,00004,'Grapesunflower','Raw Material',103,1000,'g',1000,21),(00113,00005,'SLES','Raw Material',67,250,'g',250,27),(00114,00010,'Tergitol','Raw Material',133,100,'g',100,10),(00115,00010,'Lactic Acid','Raw Material',133,750,'ml',750,25),(00116,00003,'Pine Scent HQ','Raw Material',78,500,'g',500,48),(00117,00007,'Blue 606 liquid','Raw Material',99,100,'g',100,27),(00118,00002,'Lemon Scent','Raw Material',138,100,'g',100,14),(00119,00003,'FDC Yellow # 5','Raw Material',115,250,'g',250,42),(00120,00009,'Sampa 17630','Raw Material',106,1000,'ml',1000,31),(00121,00006,'Butyl Cellosolve','Raw Material',142,500,'g',500,49),(00122,00010,'Strong Ammonia water','Raw Material',122,750,'g',750,29),(00123,00009,'STRAWBERRY SCENT','Raw Material',71,100,'ml',100,38),(00124,00010,'NAOCL','Raw Material',64,1000,'g',1000,31),(00125,00005,'Methyl salicylate','Raw Material',76,750,'g',750,14),(00126,00004,'Menthol','Raw Material',70,250,'g',250,36),(00127,00006,'IPA','Raw Material',112,1000,'ml',1000,12),(00128,00004,'Camphor','Raw Material',122,1000,'ml',1000,49),(00129,00007,'Eucalyptus oil','Raw Material',96,1000,'g',1000,24),(00130,00003,'Oil soluble green','Raw Material',98,100,'g',100,26),(00131,00002,'Mineral oil','Raw Material',115,100,'ml',100,42),(00132,00004,'White Sugar','Raw Material',57,100,'ml',100,16),(00133,00009,'Ferrous Sulphate Hep','Raw Material',68,250,'g',250,16),(00134,00008,'Sodium Benzoate','Raw Material',80,250,'ml',250,13),(00135,00009,'Citric Acid','Raw Material',96,250,'ml',250,22),(00136,00004,'Cinchona','Raw Material',74,100,'g',100,12),(00137,00001,'Tiki-Tiki','Raw Material',87,100,'ml',100,37),(00138,00001,'Ethyl Alcohol FG','Raw Material',94,500,'ml',500,10),(00139,00002,'Caramel Color NFH','Raw Material',77,500,'g',500,21),(00140,00009,'Vanilla Flavor','Raw Material',132,250,'ml',250,35),(00141,00005,'CAPB','Raw Material',90,500,'ml',500,24),(00142,00004,'Glycerine','Raw Material',141,100,'ml',100,22),(00143,00005,'Lactic Acid (PURAC)','Raw Material',138,1000,'ml',1000,24),(00144,00001,'Sodium Lactate (Purasal)','Raw Material',59,100,'g',100,49),(00145,00010,'Tea Tree oil','Raw Material',59,500,'g',500,40),(00146,00010,'Little John Texan','Raw Material',150,500,'g',500,39),(00147,00002,'Virginity Extract','Raw Material',81,750,'g',750,22),(00148,00009,'Guava Extract','Raw Material',51,1000,'ml',1000,33),(00149,00008,'D & C Blue #1(1% sol)','Raw Material',149,100,'g',100,31),(00150,00002,'Sodium Chloride','Raw Material',73,250,'ml',250,36),(00151,00004,'Deoplex','Raw Material',139,750,'ml',750,31),(00152,00008,'Tongkat ali  extract','Raw Material',53,250,'g',250,37),(00153,00001,'Avocado Oil','Raw Material',115,500,'g',500,39),(00154,00003,'Mangosteen Extract','Raw Material',65,250,'ml',250,35),(00155,00002,'Mango Extract','Raw Material',113,250,'ml',250,22),(00156,00004,'Bisabolol','Raw Material',123,500,'g',500,19),(00157,00006,'verstatil','Raw Material',57,750,'ml',750,50),(00158,00010,'MAP','Raw Material',114,1000,'g',1000,37),(00159,00004,'Cucumber extract','Raw Material',135,250,'g',250,42),(00160,00002,'Witch Hazel extract','Raw Material',58,100,'ml',100,30),(00161,00010,'Pentavitin','Raw Material',66,250,'ml',250,48),(00162,00003,'Polysorbate 20','Raw Material',141,250,'g',250,37),(00163,00006,'Vitamin E','Raw Material',84,250,'g',250,27),(00164,00007,'Euniphen','Raw Material',104,500,'ml',500,12),(00165,00005,'D & C Red # 33','Raw Material',91,500,'ml',500,45),(00166,00005,'Chicha Morada','Raw Material',93,750,'ml',750,38),(00167,00004,'Xanthan Gum','Raw Material',105,1000,'ml',1000,50),(00168,00005,'GINGER EXTRACT','Raw Material',138,100,'ml',100,43),(00169,00005,'Guava Extract','Raw Material',103,1000,'g',1000,36),(00170,00004,'SUGAR','Raw Material',54,750,'ml',750,12),(00171,00009,'CREAMER','Raw Material',83,500,'ml',500,49),(00237,00009,'SM BONUS TOILET DEO. STRAWBERRY  (FRONTLABEL)','Packaging',66,1,'na',1,42),(00238,00006,'SM BONUS TOILET DEO. LEMON  (FRONTLABEL)','Packaging',58,1,'na',1,43),(00239,00004,'SM BONUS TOILET DEO.SAMPAGUITA  (FRONTLABEL)','Packaging',58,1,'na',1,10),(00240,00004,'SM BonusToi. Deo REFILL Strawberry 50gms (Barcode)','Packaging',135,1,'na',1,47),(00241,00003,'SM BonusToi. Deo REFILL Strawberry 100gms (Barcode)','Packaging',75,1,'na',1,31),(00242,00010,'SM BONUS DEO HOLDER STRAW 50GMS (Barcode)','Packaging',50,1,'na',1,42),(00243,00008,'SM BONUS DEO HOLDER STRAW 100GMS (Barcode)','Packaging',99,1,'na',1,18),(00244,00006,'SM BonusToi. Deo REFILL Lemon 50gms (Barcode)','Packaging',133,1,'na',1,36),(00245,00007,'SM BONUS DEO REF. LEMON 100GMS (Barcode)','Packaging',120,1,'na',1,28),(00246,00007,'SM BONUS DEO HOLDER LEMON 50GMS (Barcode)','Packaging',122,1,'na',1,38),(00247,00004,'SM BONUS DEO HOLDER LEMON100GMS (Barcode)','Packaging',127,1,'na',1,11),(00248,00010,'BONUS DEO REFILL SAMPAGUITA 100GMS(Barcode)','Packaging',133,1,'na',1,32),(00249,00005,'BONUS DEO REFILL SAMPAGUITA 50GMS (Barcode)','Packaging',143,1,'na',1,42),(00250,00007,'BONUS DEOHolder SAMPAGUITA 50GMS (Barcode)','Packaging',118,1,'na',1,17),(00251,00006,'BONUS DEO HOLDER SAMPAGUITA 100GMS (Barcode)','Packaging',118,1,'na',1,29),(00252,00006,'SM Bonus TBC Pine 500ml set (back and Frontlabel)','Packaging',119,1,'na',1,34),(00253,00001,'SM BONUS TBC SAMPAGUITA 500ML LABEL SET (F/B)','Packaging',66,1,'na',1,14),(00254,00009,'SM BONUS TBCLEMON 500ML LABEL SET (F/B)','Packaging',129,1,'na',1,45),(00255,00004,'SM BONUS TBC LEMON 250ML LABEL SET (F/B)','Packaging',122,1,'na',1,31),(00256,00003,'SM Bonus TBC Pine 250ml set (back and Frontlabel)','Packaging',150,1,'na',1,33),(00257,00002,'SM BONUS TBC SAMPAGUITA 250ML LABEL SET (F/B)','Packaging',132,1,'na',1,20),(00258,00003,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',102,1,'na',1,37),(00259,00004,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',50,1,'na',1,42),(00260,00006,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',70,1,'na',1,10),(00261,00004,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',84,1,'na',1,19),(00262,00008,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',115,1,'na',1,26),(00263,00003,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',71,1,'na',1,32),(00264,00008,'SM BONUS GLASS CLEANER (FRONT /BACKLABEL)','Packaging',61,1,'na',1,49),(00265,00002,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',53,1,'na',1,35),(00266,00001,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',73,1,'na',1,17),(00267,00005,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',101,1,'na',1,13),(00268,00007,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',137,1,'na',1,29),(00269,00002,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',87,1,'na',1,11),(00270,00001,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',52,1,'na',1,25),(00271,00004,'CELLOPHANE - WHITE','Packaging',66,1,'na',1,22),(00272,00009,'CELLOPHANE - PINK','Packaging',133,1,'na',1,33),(00273,00005,'CELLOPHANE - YELLOW','Packaging',63,1,'na',1,43),(00274,00001,'CLEANING SOLUTION 201-0001-252','Packaging',93,1,'na',1,46),(00275,00006,'MAKE-UP V708-D','Packaging',129,1,'na',1,36),(00276,00007,'BLACK INK V435-D','Packaging',97,1,'na',1,27),(00277,00007,'TRIGGER SPRAYER 28MM WHITE (YUYTR100-1)','Packaging',102,1,'na',1,16),(00278,00003,'19.00mm ISPP (60ml Jimms Oil Liniment)','Packaging',89,1,'na',1,15),(00279,00005,'17.4MM ISPP  (30mL Jimms Oil Liniment)','Packaging',80,1,'na',1,17),(00280,00003,'34.00MM PS LINER (Trenz Purple Corn Powder Juice 350mL)','Packaging',107,1,'na',1,41),(00281,00009,'23.2MM SAFETY SEAL \'PE\' (SM Bonus Bleach 250mL)','Packaging',112,1,'na',1,25),(00282,00008,'26.5mm Safety Seal \'PE\' (SM Bonuis Bleach 1000mL)','Packaging',61,1,'na',1,40),(00283,00002,'31.5MM Safety Seal \'PE\' (SM Bonus 1/2 Gal )','Packaging',61,1,'na',1,46),(00284,00010,'22.00mm/ 18.5MM EPE Foam Washer (SM Bonus TBC)','Packaging',136,1,'na',1,13),(00285,00001,'CORR. BOX (RSC BFLUTE 175 lbs GLUED JOINT W/ ONE COLOR PRINT)','Packaging',135,1,'na',1,47),(00286,00009,'410 x 365  x 224mm x 175lbs. Test OD (500ml)','Packaging',81,1,'na',1,18),(00287,00006,'445 x 345 181mm x 175lbs. Test OD (250ml)','Packaging',87,1,'na',1,10),(00288,00009,'RSC,  C-125  LBS, Glued Joint, With Print  ','Packaging',132,1,'na',1,30),(00289,00002,'(Toilet deo 50g, Holder Sm Bonus) 288 x 223 x 161mm','Packaging',77,1,'na',1,14),(00290,00003,'50G REFILL(262 X 196 X 163mm) ','Packaging',57,1,'na',1,36),(00291,00008,'100G REFILL (290 x 226 x  262mm)','Packaging',149,1,'na',1,19),(00292,00002,'100G HOLDER (290 x 226 x 262mm)','Packaging',103,1,'na',1,37),(00293,00007,'54 X 30 TRANSPARENT W/ PRINT','Packaging',67,1,'na',1,16),(00294,00006,'46.00mm/38.mm SM BONUS TBC/ALCOHOL CAPSEAL','Packaging',129,1,'na',1,17),(00295,00005,'119.00mm/40.mm SM BONUS DEO CAPSEAL 100G.','Packaging',62,1,'na',1,17),(00296,00006,'105.00X40mm SM BONUS DEO CAPSEAL 50G.','Packaging',142,1,'na',1,29),(00297,00004,'60ML BOTTLE','Packaging',140,1,'na',1,37),(00298,00002,'DIRTY WHITE CAPS FOR 60ML','Packaging',110,1,'na',1,44),(00299,00002,'30ML BOTTLE','Packaging',106,1,'na',1,48),(00300,00006,'DIRTY WHITE CAPS FOR 30ML','Packaging',132,1,'na',1,34),(00301,00001,'PET GLASS CLEANER 600ML','Packaging',138,1,'na',1,20),(00302,00004,'7072-4076 Translucent Blue Screw on Smooth Wall with ','Packaging',140,1,'na',1,24),(00303,00009,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',150,1,'na',1,35),(00304,00005,'7072-3148 Translucent PINK Screw on Smooth Wall with ','Packaging',106,1,'na',1,34),(00305,00004,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',69,1,'na',1,47),(00306,00004,'7072-665 Translucent YELLOW Screw on Smooth Wall with ','Packaging',87,1,'na',1,14),(00307,00002,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',124,1,'na',1,40),(00308,00005,'ALCOHOL BOT 250','Packaging',137,1,'na',1,36),(00309,00004,'ALCOHOL BOT. 500','Packaging',55,1,'na',1,20),(00310,00008,'24MM FLIPTOP CAP COLORED ( +VAT )','Packaging',108,1,'na',1,35),(00311,00006,'PACKAGING TAPE 3\" X 90Rls.\"','Packaging',105,1,'na',1,45),(00312,00003,'ALCOHOL 500 CARTON','Packaging',108,1,'na',1,31),(00313,00007,'ALCOHOL 250 CARTON','Packaging',84,1,'na',1,43),(00314,00005,'DEODORANT CARTON','Packaging',121,1,'na',1,34),(00315,00001,'GLASS SPRAY CARTON','Packaging',67,1,'na',1,27),(00316,00007,'GLASS REFILL CARTON','Packaging',61,1,'na',1,24),(00317,00009,'HALFGALLON CARTON','Packaging',134,1,'na',1,11),(00318,00001,'CREAMER POUCH','Packaging',72,1,'na',1,27),(00319,00008,'SUGAR POUCH','Packaging',72,1,'na',1,20),(00320,00009,'SUGAR PLASTIC','Packaging',57,1,'na',1,36),(00321,00004,'CREAMER PLASTIC','Packaging',57,1,'na',1,46);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production`
--

DROP TABLE IF EXISTS `production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `theoretical_yield` int(20) DEFAULT NULL,
  `actual_yield` int(20) DEFAULT NULL,
  `percent_yield` int(20) DEFAULT NULL,
  `qty` int(11) DEFAULT NULL,
  `received_weight` decimal(10,2) DEFAULT NULL,
  `unit` varchar(25) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `status` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `created_date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `modified_date` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production`
--

LOCK TABLES `production` WRITE;
/*!40000 ALTER TABLE `production` DISABLE KEYS */;
INSERT INTO `production` VALUES (1,'SM Bonus Alcohol 70% ',100,0,0,60,100.00,'kg','pending','2020-02-03 06:26:30',NULL),(2,'SM Bonus Cheese Flavored Popcorn 250g/100',100,0,0,100,100.00,'kg','processing','2020-02-03 06:26:30',NULL),(3,'SM Bonus Multi-purpose Breading mix 100g/100',100,0,0,100,150.00,'kg','pending','2020-02-03 06:26:30',NULL),(4,'SM Bonus Toilet Deo Ref. Lemon 50g/144',100,99,99,144,222.00,'kg','finished','2020-02-03 06:26:30',NULL),(5,'SM Bonus Toilet Deo Ref. Straw 50g/144',100,0,0,144,100.00,'kg','processing','2020-02-03 06:26:30',NULL),(6,'SM Bonus Laundry Bleach 250mL/48',100,0,0,48,100.00,'kg','pending','2020-02-03 06:26:30',NULL),(7,'SM Bonus Multi-purpose Breading mix 100g/100',100,0,0,100,250.00,'kg','processing','2020-02-03 06:26:30',NULL),(8,'SM Bonus Gravy Sauce (Brown) 50g/150',100,0,0,150,100.00,'kg','processing','2020-02-03 06:26:30',NULL),(9,'SM Bonus Non-Dairy Creamer 3g/50\'s/36',100,100,100,36,200.00,'kg','finished','2020-02-03 06:26:30',NULL),(10,'SM Bonus Pure Sugar 7g/50\'s/36',100,100,100,36,454.00,'kg','finished','2020-02-03 06:26:30',NULL),(11,'SM Bonus Laundry Bleach 250mL/48',100,0,0,48,350.00,'kg','pending','2020-02-03 06:26:30',NULL),(12,'SM Bonus TBC Lemon 500mL/36',100,0,0,36,540.00,'kg','processing','2020-02-03 06:26:30',NULL),(14,'SM Bonus TBC Blue w/deo 250mL/48',100,0,0,48,600.00,'kg','pending','2020-02-03 06:26:30',NULL),(16,'SM Bonus Toilet Deo Ref. Straw 50g/144',100,0,0,144,210.00,'kg','pending','2020-02-03 06:26:30',NULL),(17,'SM Bonus Gravy Sauce (Brown) 50g/150',100,98,0,150,340.00,'kg','finished','2020-02-03 06:26:30',NULL),(18,'SM Bonus Pure Sugar 7g/50\'s/36',100,99,0,36,87.00,'kg','finished','2020-02-03 06:26:30',NULL),(19,'SM Bonus Non-Dairy Creamer 3g/50\'s/36',100,97,0,36,800.00,'kg','finished','2020-02-03 06:26:30',NULL),(21,'Ferrous Sulphate',100,0,0,33,500.00,'kg','processing','2020-02-03 06:26:30',NULL),(23,'Gum',100,0,0,50,210.00,'kg','pending','2020-02-03 06:26:30',NULL),(24,'Lactic Acid',100,0,0,30,100.00,'kg','pending','2020-02-03 06:26:30',NULL);
/*!40000 ALTER TABLE `production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_production`
--

DROP TABLE IF EXISTS `request_production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `request_production` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `production_id` int(11) NOT NULL,
  `item_name` varchar(45) DEFAULT NULL,
  `category` varchar(45) DEFAULT NULL,
  `quantity` decimal(10,2) DEFAULT NULL,
  `weight_in_kg` decimal(10,2) DEFAULT NULL,
  `size` int(11) DEFAULT NULL,
  `unit` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_inventory_production_production_idx` (`production_id`),
  CONSTRAINT `fk_inventory_production_production` FOREIGN KEY (`production_id`) REFERENCES `production` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=135 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_production`
--

LOCK TABLES `request_production` WRITE;
/*!40000 ALTER TABLE `request_production` DISABLE KEYS */;
INSERT INTO `request_production` VALUES (72,1,'Ethyl Alcohol FG','Raw Material',97.00,10.00,5,'Liters'),(73,1,'IPA','Raw Material',65.00,25.00,10,'Liters'),(74,1,'NAOCL','Raw Material',69.00,50.00,15,'Liters'),(75,2,'FDC Yellow # 5','Raw Material',80.00,25.00,20,'Liters'),(76,2,'Glycerine','Raw Material',43.00,45.00,25,'Liters'),(77,2,'Lactic Acid (PURAC)','Raw Material',23.00,10.00,30,'Liters'),(78,2,'Little John Texan','Raw Material',20.00,50.00,35,'Liters'),(79,2,'Pine Scent HQ','Raw Material',66.00,45.00,40,'Liters'),(80,2,'Sodium Lactate (Purasal)','Raw Material',22.00,45.00,45,'Liters'),(81,2,'Strong Ammonia water','Raw Material',50.00,25.00,50,'Liters'),(82,2,'Tea Tree oil','Raw Material',100.00,50.00,5,'Liters'),(83,3,'PEG 40','Raw Material',53.00,45.00,10,'Liters'),(84,4,'Bateau TM1887','Raw Material',67.00,45.00,15,'Liters'),(85,4,'Grapesunflower','Raw Material',44.00,25.00,20,'Liters'),(86,4,'Shower Fresh Scent','Raw Material',50.00,50.00,25,'Liters'),(87,5,'Butyl Cellosolve','Raw Material',30.00,45.00,30,'Liters'),(88,6,'Chicha Morada','Raw Material',20.00,10.00,35,'Liters'),(89,6,'D & C Red # 33','Raw Material',20.00,10.00,40,'Liters'),(90,6,'Euniphen','Raw Material',2.00,50.00,45,'Liters'),(91,6,'verstatil','Raw Material',60.00,45.00,50,'Liters'),(92,7,'D & C Blue #1(1% sol)','Raw Material',80.00,25.00,5,'Liters'),(93,7,'Deoplex','Raw Material',40.00,50.00,10,'Liters'),(94,7,'Guava Extract','Raw Material',30.00,45.00,15,'Liters'),(95,7,'Sodium Chloride','Raw Material',30.00,10.00,20,'Liters'),(96,7,'Tongkat ali  extract','Raw Material',30.00,50.00,25,'Liters'),(97,7,'Virginity Extract','Raw Material',30.00,45.00,30,'Liters'),(98,8,'Baby Fresh Scent','Raw Material',40.00,45.00,35,'Liters'),(99,8,'CAPB','Raw Material',45.00,25.00,40,'Liters'),(100,8,'Cucumber extract','Raw Material',25.00,10.00,45,'Liters'),(101,8,'Guava Extract','Raw Material',25.00,10.00,50,'Liters'),(102,8,'MAP','Raw Material',15.00,25.00,5,'Liters'),(103,8,'Polysorbate 20','Raw Material',65.00,50.00,10,'Liters'),(104,8,'Vitamin E','Raw Material',55.00,45.00,15,'Liters'),(105,8,'Witch Hazel extract','Raw Material',5.00,50.00,20,'Liters'),(106,9,'Avocado Oil','Raw Material',5.00,25.00,25,'Liters'),(107,9,'Bisabolol','Raw Material',15.00,10.00,30,'Liters'),(108,9,'GINGER EXTRACT','Raw Material',11.00,10.00,35,'Liters'),(109,9,'Mango Extract','Raw Material',26.00,10.00,40,'Liters'),(110,9,'Mangosteen Extract','Raw Material',22.00,50.00,45,'Liters'),(111,9,'Pentavitin','Raw Material',21.00,45.00,50,'Liters'),(112,10,'Camphor','Raw Material',65.00,45.00,5,'Liters'),(113,10,'Eucalyptus oil','Raw Material',44.00,10.00,10,'Liters'),(114,10,'Menthol','Raw Material',22.00,10.00,15,'Liters'),(115,10,'Methyl salicylate','Raw Material',32.00,45.00,20,'Liters'),(116,10,'Mineral oil','Raw Material',22.00,50.00,25,'Liters'),(117,10,'SLES','Raw Material',11.00,45.00,30,'Liters'),(118,10,'Tergitol','Raw Material',54.00,10.00,35,'Liters'),(119,12,'Lemon Scent','Raw Material',32.00,10.00,40,'Liters'),(120,12,'Oil soluble green','Raw Material',34.00,10.00,45,'Liters'),(121,12,'Sampa 17630','Raw Material',65.00,45.00,50,'Liters'),(122,12,'Sodium Benzoate','Raw Material',23.00,45.00,5,'Liters'),(123,12,'STRAWBERRY SCENT','Raw Material',22.00,10.00,10,'Liters'),(124,14,'Blue 606 liquid','Raw Material',11.00,45.00,15,'Liters'),(125,16,'Cinchona','Raw Material',23.00,25.00,20,'Liters'),(126,16,'Tiki-Tiki','Raw Material',42.00,45.00,25,'Liters'),(127,17,'Caramel Color NFH','Raw Material',55.00,10.00,30,'Liters'),(128,18,'Citric Acid','Raw Material',65.00,10.00,35,'Liters'),(129,18,'Vanilla Flavor','Raw Material',50.00,10.00,40,'Liters'),(130,19,'CREAMER','Raw Material',8.00,50.00,45,'Liters'),(131,19,'SUGAR','Raw Material',90.00,25.00,50,'Liters'),(132,21,'Ferrous Sulphate Hep','Raw Material',77.00,10.00,5,'Liters'),(133,23,'Xanthan Gum','Raw Material',2.00,50.00,10,'Liters'),(134,24,'Lactic Acid','Raw Material',35.00,10.00,15,'Liters');
/*!40000 ALTER TABLE `request_production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipment_items`
--

DROP TABLE IF EXISTS `shipment_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipment_items` (
  `Shipment_Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Shipment_ID` int(5) unsigned zerofill NOT NULL,
  `Item_ID` int(5) unsigned zerofill NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Shipment_Item_ID`),
  KEY `fk_shipment_items_shipments1_idx` (`Shipment_ID`),
  KEY `fk_shipment_items_inventory1_idx` (`Item_ID`),
  CONSTRAINT `fk_shipment_items_inventory1` FOREIGN KEY (`Item_ID`) REFERENCES `inventory` (`Item_ID`),
  CONSTRAINT `fk_shipment_items_shipments1` FOREIGN KEY (`Shipment_ID`) REFERENCES `shipments` (`Shipment_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=107 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipment_items`
--

LOCK TABLES `shipment_items` WRITE;
/*!40000 ALTER TABLE `shipment_items` DISABLE KEYS */;
INSERT INTO `shipment_items` VALUES (00006,00009,00003,10,NULL),(00007,00008,00005,1,NULL),(00008,00002,00001,6,NULL),(00009,00001,00002,5,'Complete'),(00010,00008,00003,7,NULL),(00011,00007,00004,27,NULL),(00012,00004,00005,8,NULL),(00013,00002,00006,23,NULL),(00014,00002,00007,13,NULL),(00015,00009,00008,26,NULL),(00016,00008,00009,15,NULL),(00017,00010,00010,33,NULL),(00018,00009,00011,23,NULL),(00019,00002,00012,29,NULL),(00020,00002,00013,14,NULL),(00021,00009,00014,34,NULL),(00022,00002,00015,35,NULL),(00023,00008,00016,5,NULL),(00024,00008,00017,29,NULL),(00025,00006,00018,29,NULL),(00026,00002,00019,9,NULL),(00027,00001,00020,7,'Complete'),(00028,00010,00021,31,NULL),(00029,00006,00022,29,NULL),(00030,00002,00023,35,NULL),(00031,00003,00024,30,NULL),(00033,00007,00026,29,NULL),(00034,00001,00027,20,'Complete'),(00035,00010,00028,23,NULL),(00036,00009,00029,18,NULL),(00037,00003,00030,35,NULL),(00039,00001,00032,29,'Complete'),(00040,00009,00033,27,NULL),(00041,00001,00034,16,'Complete'),(00042,00010,00035,26,NULL),(00043,00006,00036,19,NULL),(00044,00001,00037,17,'Complete'),(00045,00001,00038,28,'Complete'),(00046,00008,00039,22,NULL),(00047,00008,00040,9,NULL),(00048,00004,00041,21,NULL),(00049,00006,00042,6,NULL),(00050,00005,00043,25,NULL),(00051,00005,00108,32,NULL),(00052,00010,00109,24,NULL),(00053,00006,00110,11,NULL),(00054,00009,00111,5,NULL),(00055,00009,00112,19,NULL),(00056,00002,00113,26,NULL),(00057,00003,00114,7,NULL),(00058,00002,00115,25,NULL),(00059,00003,00116,24,NULL),(00060,00004,00117,17,NULL),(00061,00003,00118,19,NULL),(00062,00008,00119,19,NULL),(00063,00009,00120,26,NULL),(00064,00001,00121,17,'Complete'),(00065,00007,00122,13,NULL),(00066,00003,00123,20,NULL),(00067,00005,00124,16,NULL),(00068,00008,00125,10,NULL),(00069,00010,00126,28,NULL),(00070,00004,00127,34,NULL),(00071,00007,00128,22,NULL),(00072,00009,00129,28,NULL),(00073,00006,00130,25,NULL),(00074,00005,00131,6,NULL),(00075,00006,00132,11,NULL),(00076,00003,00133,34,NULL),(00077,00001,00134,33,'Complete'),(00078,00003,00135,19,NULL),(00079,00004,00136,16,NULL),(00080,00010,00137,13,NULL),(00081,00006,00138,17,NULL),(00082,00008,00139,9,NULL),(00083,00009,00140,24,NULL),(00084,00001,00141,30,'Complete'),(00085,00007,00142,19,NULL),(00086,00003,00143,34,NULL),(00087,00006,00144,16,NULL),(00088,00003,00145,30,NULL),(00089,00006,00146,14,NULL),(00090,00009,00147,11,NULL),(00091,00008,00148,24,NULL),(00092,00003,00149,25,NULL),(00093,00005,00150,31,NULL),(00094,00010,00151,19,NULL),(00095,00010,00152,22,NULL),(00096,00006,00153,30,NULL),(00097,00007,00154,25,NULL),(00098,00001,00155,12,'Complete'),(00099,00002,00156,26,NULL),(00100,00007,00157,26,NULL),(00101,00010,00158,9,NULL),(00102,00010,00159,33,NULL),(00103,00001,00160,13,'Complete'),(00104,00010,00161,30,NULL),(00105,00001,00162,22,'Complete'),(00106,00002,00163,20,NULL);
/*!40000 ALTER TABLE `shipment_items` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipments`
--

DROP TABLE IF EXISTS `shipments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipments` (
  `Shipment_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Truck_ID` int(5) unsigned zerofill NOT NULL,
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
  PRIMARY KEY (`Shipment_ID`),
  KEY `fk_shipments_trucks1_idx` (`Truck_ID`),
  CONSTRAINT `fk_shipments_trucks1` FOREIGN KEY (`Truck_ID`) REFERENCES `trucks` (`Truck_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=100 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (00001,00003,'Inbound','Complete','SANTA MESA HEIGHT','QUIAPO',12,2,'2019-01-24 11:36:43','2019-02-23 12:44:08','2019-03-19 22:26:25',222,248,26),(00002,00002,'Outbound','Pending','UGONG NORTE','ERMITA',14,2,'2019-01-22 05:07:28','2019-03-01 00:38:56','2019-06-22 19:53:27',90,126,36),(00003,00001,'Inbound','Pending','NOVALICHES','SANTA MESA',14,2,'2019-01-19 17:51:10','2019-02-23 10:57:39','2019-11-29 12:47:56',133,145,12),(00004,00002,'Inbound','In-Transit','NEW MANILA','SAN MIGUEL',13,2,'2019-01-07 15:58:55','2019-02-24 11:39:00','2019-10-07 07:49:30',96,132,36),(00005,00001,'Inbound','Accomplished','GALAS-SANTOL','SAMPALOC',15,2,'2019-01-07 23:14:49','2019-02-25 16:08:13','2019-07-04 11:59:17',136,155,19),(00006,00003,'Inbound','Accomplished','CUBAO','QUIAPO',9,2,'2019-01-12 20:20:14','2019-02-08 12:06:27','2019-06-17 22:54:19',170,172,2),(00007,00002,'Outbound','Accomplished','LOYOLA HEIGHTS','MALATE',8,2,'2019-01-08 20:50:28','2019-03-01 16:28:13','2019-08-12 18:06:12',158,189,31),(00008,00002,'Outbound','Pending','NOVALICHES','MALATE',11,2,'2019-01-02 01:41:46','2019-02-01 16:51:34','2019-05-30 17:50:36',252,265,13),(00009,00002,'Outbound','In-Transit','GALAS-SANTOL','SANTA ANA',15,2,'2019-01-16 19:40:13','2019-02-04 14:30:05','2019-12-19 13:16:14',154,186,32),(00010,00001,'Outbound','Pending','DILIMAN','ERMITA',10,2,'2019-01-09 05:19:28','2019-02-11 06:14:35','2019-06-01 11:21:48',289,332,43),(00011,00003,'Outbound','Accomplished','DILIMAN','PORT AREA',10,2,'2019-01-02 13:51:33','2019-02-26 04:46:09','2019-05-15 22:13:24',288,333,45),(00012,00002,'Inbound','In-Transit','COMMONWEALTH AVENUE','SANTA CRUZ',14,2,'2019-01-06 00:18:32','2019-02-19 09:08:05','2019-04-13 19:20:33',264,294,30),(00013,00001,'Outbound','In-Transit','TRIANGLE PARK','SANTA ANA',8,2,'2019-01-01 00:58:49','2019-02-15 21:43:21','2019-04-25 07:52:55',140,155,15),(00014,00003,'Inbound','Pending','NOVALICHES','SAN MIGUEL',8,2,'2019-01-14 21:33:57','2019-02-24 21:11:58','2019-09-01 13:15:37',134,160,26),(00015,00001,'Outbound','Pending','LA LOMA','PANDACAN',11,2,'2019-01-05 04:08:52','2019-02-25 03:53:08','2019-10-30 13:29:17',276,298,22),(00016,00001,'Outbound','In-Transit','BAGUMBAYAN','ERMITA',10,2,'2019-01-14 05:44:17','2019-02-08 22:59:31','2019-08-03 06:43:51',200,248,48),(00017,00003,'Inbound','In-Transit','THE PROJECT AREAS','PORT AREA',8,2,'2019-01-25 02:45:27','2019-03-01 05:40:06','2019-03-08 11:05:32',120,135,15),(00018,00003,'Inbound','Accomplished','GALAS-SANTOL','INTRAMUROS',14,2,'2019-01-01 09:51:45','2019-02-03 19:56:04','2019-10-16 21:27:28',223,228,5),(00019,00003,'Outbound','In-Transit','BAGUMBAYAN','BINONDO',8,2,'2019-01-07 12:15:09','2019-02-07 07:45:56','2019-12-28 17:21:05',184,205,21),(00020,00003,'Outbound','Accomplished','TRIANGLE PARK','BINONDO',15,2,'2019-01-07 01:29:28','2019-02-10 14:46:12','2019-08-28 23:42:17',208,218,10),(00021,00002,'Outbound','In-Transit','DILIMAN','SAN MIGUEL',8,2,'2019-01-24 07:31:56','2019-02-09 09:57:31','2019-05-19 06:55:07',208,239,31),(00022,00001,'Outbound','Pending','DILIMAN','PANDACAN',12,2,'2019-01-05 18:40:34','2019-02-16 21:26:34','2019-06-23 12:54:23',105,112,7),(00023,00001,'Outbound','In-Transit','BAGUMBAYAN','SAN NICOLAS',9,2,'2019-01-28 12:31:04','2019-02-12 03:17:58','2019-04-05 03:42:35',233,258,25),(00024,00002,'Outbound','In-Transit','SAN FRANCISCO DEL MONTE','BINONDO',15,2,'2019-01-13 17:16:07','2019-02-26 11:49:39','2019-08-24 10:51:08',121,150,29),(00025,00003,'Inbound','Pending','TANDANG SORA','BINONDO',15,2,'2019-01-02 09:02:31','2019-02-11 01:19:17','2019-08-01 08:10:46',98,122,24),(00026,00002,'Outbound','Accomplished','COMMONWEALTH AVENUE','SANTA ANA',11,2,'2019-01-23 17:19:40','2019-02-10 12:53:14','2019-04-17 07:29:48',177,225,48),(00027,00003,'Outbound','In-Transit','SANTA MESA HEIGHT','SANTA CRUZ',8,2,'2019-01-07 10:23:41','2019-02-02 14:59:39','2019-11-04 21:45:56',80,121,41),(00028,00003,'Outbound','Accomplished','TANDANG SORA','SAMPALOC',9,2,'2019-01-07 17:09:40','2019-02-08 18:32:40','2019-04-24 16:43:38',299,328,29),(00029,00002,'Outbound','In-Transit','TANDANG SORA','SANTA ANA',13,2,'2019-01-06 22:40:17','2019-02-26 15:02:18','2019-09-14 16:19:07',223,268,45),(00030,00003,'Inbound','Pending','NEW MANILA','MALATE',15,2,'2019-01-14 03:15:42','2019-02-21 16:16:37','2019-06-10 15:59:08',93,98,5),(00031,00002,'Outbound','In-Transit','DILIMAN','TONDO',15,2,'2019-01-28 06:07:41','2019-02-06 16:01:08','2019-12-02 17:37:19',297,325,28),(00032,00002,'Outbound','Pending','SAN FRANCISCO DEL MONTE','INTRAMUROS',8,2,'2019-01-28 15:16:45','2019-02-09 23:15:02','2019-04-28 22:32:25',217,219,2),(00033,00002,'Outbound','Accomplished','CUBAO','BINONDO',13,2,'2019-01-17 13:26:23','2019-02-08 05:08:07','2019-04-05 03:02:28',167,212,45),(00034,00001,'Outbound','Pending','CUBAO','SAN NICOLAS',14,2,'2019-01-11 00:12:55','2019-02-27 04:24:00','2019-06-14 21:37:55',291,314,23),(00035,00002,'Outbound','Pending','LOYOLA HEIGHTS','SAMPALOC',13,2,'2019-01-05 07:08:32','2019-02-06 09:49:13','2019-06-19 18:54:41',217,255,38),(00036,00001,'Inbound','Pending','TANDANG SORA','SANTA MESA',11,2,'2019-01-07 12:37:27','2019-02-17 20:30:58','2019-03-11 07:45:44',261,286,25),(00037,00003,'Outbound','In-Transit','CUBAO','MALATE',11,2,'2019-01-02 20:10:38','2019-02-04 08:30:38','2019-08-23 09:33:51',262,276,14),(00038,00002,'Inbound','Accomplished','NEW MANILA','PACO',9,2,'2019-01-08 14:32:40','2019-02-23 05:37:22','2019-11-17 03:22:30',272,285,13),(00039,00002,'Outbound','Pending','LA LOMA','QUIAPO',11,2,'2019-01-23 10:18:01','2019-03-02 12:15:00','2019-05-28 22:00:10',196,223,27),(00040,00001,'Outbound','In-Transit','SANTA MESA HEIGHT','SANTA MESA',13,2,'2019-01-28 09:33:50','2019-02-18 00:50:20','2019-07-25 21:07:30',281,328,47),(00041,00003,'Inbound','Pending','BAGUMBAYAN','SANTA MESA',11,2,'2019-01-05 21:02:53','2019-02-01 00:33:16','2019-09-26 11:42:05',236,248,12),(00042,00003,'Outbound','Accomplished','UGONG NORTE','PORT AREA',14,2,'2019-01-21 05:09:08','2019-02-10 10:46:23','2019-11-22 07:24:43',116,116,0),(00043,00002,'Inbound','In-Transit','CUBAO','PANDACAN',11,2,'2019-01-07 03:15:18','2019-02-07 10:28:46','2019-12-05 13:37:12',206,240,34),(00044,00003,'Outbound','In-Transit','THE PROJECT AREAS','BINONDO',12,2,'2019-01-14 02:07:30','2019-02-04 23:36:46','2019-07-13 05:41:33',174,174,0),(00045,00002,'Inbound','Accomplished','LA LOMA','SAN MIGUEL',12,2,'2019-01-22 01:23:29','2019-02-05 09:30:34','2019-11-27 23:50:31',223,242,19),(00046,00001,'Outbound','Accomplished','LA LOMA','QUIAPO',10,2,'2019-01-27 11:01:37','2019-02-08 21:17:12','2019-04-13 17:22:21',236,246,10),(00047,00001,'Inbound','Accomplished','CUBAO','TONDO',15,2,'2019-01-01 22:28:57','2019-02-18 18:01:42','2019-12-26 14:10:08',249,267,18),(00048,00002,'Inbound','Accomplished','COMMONWEALTH AVENUE','QUIAPO',9,2,'2019-01-30 11:05:36','2019-02-23 05:52:29','2019-11-25 17:40:39',197,245,48),(00049,00002,'Inbound','In-Transit','LOYOLA HEIGHTS','SANTA CRUZ',9,2,'2019-01-18 23:02:33','2019-02-27 16:19:38','2019-05-14 18:08:35',164,165,1),(00050,00002,'Inbound','Pending','THE PROJECT AREAS','PACO',15,2,'2019-01-04 18:16:26','2019-02-16 03:05:55','2019-09-30 04:58:36',144,158,14),(00051,00003,'Inbound','Accomplished','NOVALICHES','SAN ANDRES',13,2,'2019-01-24 20:05:57','2019-02-11 14:00:59','2019-06-11 22:16:05',200,225,25),(00052,00002,'Inbound','In-Transit','SANTA MESA HEIGHT','TONDO',14,2,'2019-01-01 08:17:52','2019-02-13 10:24:41','2019-11-30 10:30:05',262,273,11),(00053,00001,'Inbound','Pending','SAN FRANCISCO DEL MONTE','PACO',13,2,'2019-01-28 00:35:58','2019-02-18 01:11:55','2019-10-03 21:53:27',166,192,26),(00054,00003,'Outbound','Accomplished','COMMONWEALTH AVENUE','SANTA CRUZ',11,2,'2019-01-08 11:55:22','2019-02-27 23:58:25','2019-07-03 00:48:47',205,239,34),(00055,00002,'Outbound','In-Transit','UGONG NORTE','PACO',13,2,'2019-01-12 04:11:00','2019-02-26 03:09:13','2019-04-27 09:03:34',254,294,40),(00056,00001,'Outbound','Accomplished','GALAS-SANTOL','INTRAMUROS',13,2,'2019-01-27 12:58:31','2019-03-01 01:43:22','2019-04-06 17:43:41',279,291,12),(00057,00003,'Inbound','In-Transit','SANTA MESA HEIGHT','ERMITA',8,2,'2019-01-27 11:25:50','2019-02-26 15:13:53','2019-09-11 14:03:50',90,100,10),(00058,00003,'Inbound','Accomplished','LOYOLA HEIGHTS','PANDACAN',15,2,'2019-01-30 07:31:08','2019-02-22 08:13:57','2019-08-07 06:10:30',183,194,11),(00059,00001,'Inbound','In-Transit','COMMONWEALTH AVENUE','QUIAPO',14,2,'2019-01-21 22:26:56','2019-02-17 20:08:48','2019-10-02 11:03:34',171,218,47),(00060,00003,'Inbound','In-Transit','UGONG NORTE','PORT AREA',12,2,'2019-01-16 17:53:27','2019-02-26 10:22:19','2019-03-26 18:58:22',104,104,0),(00061,00001,'Inbound','In-Transit','NEW MANILA','SAMPALOC',8,2,'2019-01-12 08:29:22','2019-02-21 15:50:48','2019-03-08 20:44:42',297,306,9),(00062,00001,'Outbound','Pending','THE PROJECT AREAS','SAN NICOLAS',10,2,'2019-01-07 11:01:38','2019-02-19 02:59:00','2019-06-21 08:14:25',212,255,43),(00063,00003,'Outbound','Pending','UGONG NORTE','PORT AREA',15,2,'2019-01-24 21:16:35','2019-03-01 07:06:25','2019-03-18 06:41:29',296,296,0),(00064,00002,'Inbound','Accomplished','COMMONWEALTH AVENUE','TONDO',13,2,'2019-01-24 02:10:24','2019-02-15 07:06:21','2019-07-23 20:18:12',157,186,29),(00065,00001,'Inbound','In-Transit','DILIMAN','SANTA MESA',15,2,'2019-01-19 22:32:00','2019-02-17 14:33:21','2019-07-30 11:21:40',277,321,44),(00066,00001,'Inbound','Accomplished','TRIANGLE PARK','SANTA MESA',8,2,'2019-01-05 08:55:08','2019-02-09 00:58:38','2019-05-31 08:52:28',115,136,21),(00067,00002,'Inbound','In-Transit','LOYOLA HEIGHTS','SAN ANDRES',8,2,'2019-01-28 09:44:25','2019-03-02 23:21:58','2019-09-21 21:03:15',152,201,49),(00068,00001,'Inbound','Pending','TRIANGLE PARK','TONDO',13,2,'2019-01-19 13:50:22','2019-02-21 23:12:49','2019-11-02 04:17:54',139,146,7),(00069,00002,'Inbound','Pending','THE PROJECT AREAS','PACO',10,2,'2019-01-12 07:46:59','2019-02-23 05:16:35','2019-12-28 02:15:32',147,195,48),(00070,00003,'Outbound','Accomplished','NEW MANILA','ERMITA',8,2,'2019-01-13 01:53:20','2019-02-02 14:32:35','2019-11-30 00:21:30',258,290,32),(00071,00001,'Inbound','In-Transit','SAN FRANCISCO DEL MONTE','SAN MIGUEL',10,2,'2019-01-24 12:11:27','2019-03-01 14:53:31','2019-08-24 18:41:13',172,210,38),(00072,00001,'Inbound','Accomplished','SANTA MESA HEIGHT','SAN ANDRES',12,2,'2019-01-27 20:14:31','2019-03-02 04:59:26','2019-07-02 09:59:45',268,314,46),(00073,00002,'Outbound','Accomplished','BAGUMBAYAN','TONDO',9,2,'2019-01-07 21:10:01','2019-02-21 09:43:57','2019-07-18 03:11:18',237,250,13),(00074,00002,'Outbound','Pending','GALAS-SANTOL','BINONDO',13,2,'2019-01-25 02:16:56','2019-02-20 03:44:07','2019-12-27 08:05:08',86,101,15),(00075,00002,'Inbound','Accomplished','LOYOLA HEIGHTS','MALATE',10,2,'2019-01-05 02:52:13','2019-02-10 06:43:10','2019-04-23 13:26:36',214,233,19),(00076,00002,'Outbound','In-Transit','SAN FRANCISCO DEL MONTE','INTRAMUROS',13,2,'2019-01-18 17:58:32','2019-02-03 11:20:10','2019-03-20 07:15:48',177,191,14),(00077,00002,'Inbound','In-Transit','CUBAO','SAN NICOLAS',10,2,'2019-01-07 02:17:02','2019-02-25 11:36:10','2019-12-22 12:59:49',132,169,37),(00078,00001,'Inbound','Pending','TANDANG SORA','INTRAMUROS',9,2,'2019-01-12 07:12:14','2019-02-13 23:26:48','2019-05-14 06:20:01',89,99,10),(00079,00002,'Inbound','Pending','LA LOMA','MALATE',9,2,'2019-01-23 10:49:47','2019-02-17 13:17:50','2019-04-28 17:39:07',244,268,24),(00080,00002,'Outbound','Accomplished','NOVALICHES','SANTA ANA',11,2,'2019-01-08 18:57:08','2019-02-07 03:42:15','2019-03-06 10:42:46',197,228,31),(00081,00002,'Inbound','Accomplished','TRIANGLE PARK','PANDACAN',11,2,'2019-01-17 08:34:19','2019-02-20 07:48:19','2019-06-01 07:42:53',265,314,49),(00082,00001,'Outbound','Pending','THE PROJECT AREAS','ERMITA',11,2,'2019-01-27 23:25:16','2019-02-18 22:52:45','2019-10-26 13:54:55',177,202,25),(00083,00002,'Inbound','In-Transit','NEW MANILA','SAMPALOC',10,2,'2019-01-27 19:23:44','2019-02-24 20:58:46','2019-08-25 15:48:25',95,135,40),(00084,00002,'Outbound','Accomplished','GALAS-SANTOL','SANTA CRUZ',13,2,'2019-01-09 06:50:40','2019-02-12 09:55:16','2019-03-26 04:54:35',253,297,44),(00085,00003,'Outbound','Accomplished','SAN FRANCISCO DEL MONTE','SAN ANDRES',13,2,'2019-01-17 02:25:59','2019-02-25 09:04:20','2019-12-28 12:28:24',225,268,43),(00086,00003,'Inbound','Pending','LOYOLA HEIGHTS','SAN NICOLAS',8,2,'2019-01-21 09:28:24','2019-02-04 15:02:25','2019-05-23 23:12:30',264,283,19),(00087,00001,'Outbound','In-Transit','BAGUMBAYAN','PANDACAN',11,2,'2019-01-06 15:54:04','2019-02-19 01:44:14','2019-04-06 07:35:19',141,179,38),(00088,00002,'Outbound','Pending','DILIMAN','SAN MIGUEL',8,2,'2019-01-20 08:14:24','2019-02-05 19:36:57','2019-10-27 04:05:01',112,153,41),(00089,00003,'Inbound','In-Transit','BAGUMBAYAN','SAN NICOLAS',11,2,'2019-01-14 22:09:15','2019-02-14 13:46:22','2019-05-21 15:07:49',255,293,38),(00090,00003,'Inbound','In-Transit','UGONG NORTE','ERMITA',15,2,'2019-01-16 16:55:47','2019-02-26 11:50:30','2019-03-06 21:55:54',231,232,1),(00091,00003,'Inbound','Accomplished','GALAS-SANTOL','PORT AREA',12,2,'2019-01-05 19:28:03','2019-02-16 07:39:53','2019-09-05 00:37:22',83,91,8),(00092,00001,'Inbound','In-Transit','SAN FRANCISCO DEL MONTE','SANTA ANA',12,2,'2019-01-26 04:34:52','2019-02-19 14:29:56','2019-09-25 03:50:57',256,292,36),(00093,00002,'Inbound','Pending','TRIANGLE PARK','SAMPALOC',11,2,'2019-01-18 13:47:39','2019-02-04 00:48:58','2019-09-07 19:21:53',237,277,40),(00094,00002,'Outbound','Accomplished','NOVALICHES','INTRAMUROS',15,2,'2019-01-18 21:57:21','2019-02-08 01:21:14','2019-10-06 23:44:39',166,190,24),(00095,00003,'Inbound','Pending','LA LOMA','SANTA CRUZ',13,2,'2019-01-10 00:56:19','2019-02-05 09:26:32','2019-09-10 15:06:29',255,260,5),(00096,00003,'Outbound','Accomplished','NEW MANILA','MALATE',15,2,'2019-01-16 10:48:48','2019-02-17 01:17:13','2019-03-22 19:33:43',148,186,38),(00097,00003,'Outbound','Pending','LA LOMA','SAN ANDRES',13,2,'2019-01-10 10:53:52','2019-02-20 10:17:40','2019-11-08 18:11:31',136,178,42),(00098,00002,'Inbound','Pending','NOVALICHES','SAN ANDRES',9,2,'2019-01-28 06:36:09','2019-02-08 02:35:16','2019-05-14 10:46:56',155,160,5),(00099,00001,'Outbound','Accomplished','COMMONWEALTH AVENUE','PACO',14,2,'2019-01-09 16:54:29','2019-03-02 09:29:20','2019-05-09 00:25:15',292,304,12);
/*!40000 ALTER TABLE `shipments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `supplier`
--

DROP TABLE IF EXISTS `supplier`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trucks` (
  `Truck_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Plate_Number` varchar(45) DEFAULT NULL,
  `Model` varchar(45) DEFAULT NULL,
  `Capacity` int(11) DEFAULT NULL,
  `Kilometers_Per_Liter` int(11) DEFAULT NULL,
  PRIMARY KEY (`Truck_ID`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trucks`
--

LOCK TABLES `trucks` WRITE;
/*!40000 ALTER TABLE `trucks` DISABLE KEYS */;
INSERT INTO `trucks` VALUES (00001,'Small','URD-427','FTR',6200,10),(00002,'Medium','UBO-420','NPR',7400,12),(00003,'Large','CSG-069','NPR XD',8200,14);
/*!40000 ALTER TABLE `trucks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
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

-- Dump completed on 2020-02-04  0:10:04
