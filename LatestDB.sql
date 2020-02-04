-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: flc
-- ------------------------------------------------------
-- Server version	8.0.19

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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory` (
  `Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `Size` int DEFAULT NULL,
  `Unit` varchar(45) DEFAULT NULL,
  `Weight` int DEFAULT NULL,
  `Critical_Level` int DEFAULT NULL,
  `RFID` varchar(45) DEFAULT NULL,
  `Supplier_ID` int DEFAULT NULL,
  PRIMARY KEY (`Item_ID`),
  UNIQUE KEY `RFID_UNIQUE` (`RFID`)
) ENGINE=InnoDB AUTO_INCREMENT=322 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory`
--

LOCK TABLES `inventory` WRITE;
/*!40000 ALTER TABLE `inventory` DISABLE KEYS */;
INSERT INTO `inventory` VALUES (00001,'SM BONUS TOILET DEODORIZER STRAWBERRY','Finished Product',113,50,'g',50,31,'99924801472',3),(00002,'SM Bonus Toilet Deo Ref. Lemon ','Finished Product',81,50,'g',50,14,'71805081373',1),(00003,'SM Bonus Toilet Deo Ref. Sampa','Finished Product',134,50,'g',50,20,'71649929389',10),(00004,'SM Bonus Toilet Deo Ref. Straw ','Finished Product',117,100,'g',100,50,'89681536286',7),(00005,'SM Bonus Toilet Deo Ref. Lemon','Finished Product',145,100,'g',100,13,'69817296809',4),(00006,'SM Bonus Toilet Deo Ref. Sampa ','Finished Product',98,100,'g',100,12,'51877952415',6),(00007,'SM Bonus Toilet Deo W/holder Straw','Finished Product',119,50,'g',50,37,'80244804666',2),(00008,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',148,50,'g',50,33,'64418233215',2),(00009,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',86,100,'g',100,19,'17678452862',1),(00010,'SM Bonus Toilet Deo W/holder Straw','Finished Product',55,100,'g',100,21,'81028536438',8),(00011,'SM Bonus Toilet Deo W/holder Sampa','Finished Product',87,100,'g',100,11,'87959536568',3),(00012,'SM Bonus Toilet Deo W/holder Lemon','Finished Product',136,250,'ml',250,42,'67556211332',9),(00013,'SM Bonus TBC Lemon','Finished Product',93,250,'ml',250,12,'93931629133',9),(00014,'SM Bonus TBC Pine','Finished Product',122,250,'ml',250,13,'27933250068',8),(00015,'SM Bonus TBC Sampaguita','Finished Product',133,500,'ml',500,19,'72953874010',5),(00016,'SM Bonus TBC Lemon','Finished Product',95,500,'ml',500,39,'66106984314',7),(00017,'SM Bonus TBC Pine','Finished Product',172,500,'ml',500,34,'60677538254',6),(00018,'SM Bonus TBC Sampaguita','Finished Product',97,500,'ml',500,21,'69113433422',8),(00019,'SM Bonus TBC Blue w/deo','Finished Product',85,250,'ml',250,40,'18696043236',8),(00020,'SM Bonus TBC Blue w/de','Finished Product',106,500,'ml',500,39,'71296601208',8),(00021,'SM Bonus TBC Yellow w/deo','Finished Product',138,250,'ml',250,31,'36747874852',10),(00022,'SM Bonus TBC Yellow w/deo','Finished Product',70,500,'ml',500,24,'43236079030',5),(00023,'SM Bonus Laundry Bleach','Finished Product',62,250,'ml',250,10,'82669481422',8),(00024,'SM Bonus Laundry Bleach','Finished Product',144,1000,'ml',1000,37,'82357255521',4),(00026,'SM Bonus Glass Clearner Spray','Finished Product',95,600,'ml',600,22,'66409567496',6),(00027,'SM Bonus Glass Clearner Refill','Finished Product',113,600,'ml',600,28,'68082065471',9),(00028,'Fervar In-Tank TBC Blue','Finished Product',115,50,'g',50,38,'99018288896',6),(00029,'SM Bonus TBC 500mL + Toilet Bowl Intank','Finished Product',80,50,'g',50,45,'58770446589',7),(00030,'SM Bonus Deo Refill 50gx3 + SMB Bleach','Finished Product',116,250,'ml',250,12,'35561497566',5),(00032,'SM Bonus Alcohol 70%','Finished Product',59,250,'ml',250,18,'19256580838',2),(00033,'SM Bonus Alcohol 70% ','Finished Product',135,500,'ml',500,19,'58224050813',7),(00034,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',133,250,'ml',250,10,'89632488665',3),(00035,'SM Bonus Alcologne 40% Baby Fresh','Finished Product',116,500,'ml',500,47,'36792821577',9),(00036,'SM Bonus Alcologne 40% Shower FresH','Finished Product',76,250,'ml',250,13,'56389566915',2),(00037,'SM Bonus Alcologne 40% Shower Fresh ','Finished Product',141,500,'ml',500,22,'90117715909',4),(00038,'SM Bonus Pure Sugar ','Finished Product',127,7,'g',7,34,'16561716550',2),(00039,'SM Bonus Non-Dairy Creamer','Finished Product',88,3,'g',3,40,'39833588566',3),(00040,'SM Bonus Cheese Flavored Popcorn','Finished Product',149,250,'g',250,22,'57456591856',3),(00041,'SM Bonus Cheese Popcorn Canister','Finished Product',149,300,'g',300,20,'41336758271',7),(00042,'SM Bonus Multi-purpose Breading mix ','Finished Product',111,100,'g',100,40,'52903879172',5),(00043,'SM Bonus Gravy Sauce (Brown)','Finished Product',113,50,'g',50,39,'85785929387',1),(00108,'Bateau TM1887','Raw Material',136,750,'g',750,44,'4634645004',4),(00109,'PEG 40','Raw Material',109,500,'g',500,10,'5705829015',5),(00110,'Baby Fresh Scent','Raw Material',106,1000,'ml',1000,50,'7709858242',1),(00111,'Shower Fresh Scent','Raw Material',72,500,'ml',500,13,'4349898080',1),(00112,'Grapesunflower','Raw Material',103,1000,'g',1000,21,'3975408594',4),(00113,'SLES','Raw Material',67,250,'g',250,27,'9562181768',5),(00114,'Tergitol','Raw Material',133,100,'g',100,10,'2259575225',10),(00115,'Lactic Acid','Raw Material',133,750,'ml',750,25,'2176833545',10),(00116,'Pine Scent HQ','Raw Material',78,500,'g',500,48,'7269678653',3),(00117,'Blue 606 liquid','Raw Material',99,100,'g',100,27,'4981933734',7),(00118,'Lemon Scent','Raw Material',138,100,'g',100,14,'6923965814',2),(00119,'FDC Yellow # 5','Raw Material',115,250,'g',250,42,'9705315254',3),(00120,'Sampa 17630','Raw Material',106,1000,'ml',1000,31,'3347531120',9),(00121,'Butyl Cellosolve','Raw Material',142,500,'g',500,49,'1062868417',6),(00122,'Strong Ammonia water','Raw Material',122,750,'g',750,29,'9530667536',10),(00123,'STRAWBERRY SCENT','Raw Material',71,100,'ml',100,38,'6033383413',9),(00124,'NAOCL','Raw Material',64,1000,'g',1000,31,'1031336296',10),(00125,'Methyl salicylate','Raw Material',76,750,'g',750,14,'1346559959',5),(00126,'Menthol','Raw Material',70,250,'g',250,36,'1820056447',4),(00127,'IPA','Raw Material',112,1000,'ml',1000,12,'6415096368',6),(00128,'Camphor','Raw Material',122,1000,'ml',1000,49,'6043244403',4),(00129,'Eucalyptus oil','Raw Material',96,1000,'g',1000,24,'8345567126',7),(00130,'Oil soluble green','Raw Material',98,100,'g',100,26,'9900881877',3),(00131,'Mineral oil','Raw Material',115,100,'ml',100,42,'7753605715',2),(00132,'White Sugar','Raw Material',57,100,'ml',100,16,'2937411900',4),(00133,'Ferrous Sulphate Hep','Raw Material',68,250,'g',250,16,'1453111275',9),(00134,'Sodium Benzoate','Raw Material',80,250,'ml',250,13,'6245331901',8),(00135,'Citric Acid','Raw Material',96,250,'ml',250,22,'7898095312',9),(00136,'Cinchona','Raw Material',74,100,'g',100,12,'8286813586',4),(00137,'Tiki-Tiki','Raw Material',87,100,'ml',100,37,'2141818458',1),(00138,'Ethyl Alcohol FG','Raw Material',94,500,'ml',500,10,'4706058536',1),(00139,'Caramel Color NFH','Raw Material',77,500,'g',500,21,'1297953861',2),(00140,'Vanilla Flavor','Raw Material',132,250,'ml',250,35,'9001362863',9),(00141,'CAPB','Raw Material',90,500,'ml',500,24,'5994704950',5),(00142,'Glycerine','Raw Material',141,100,'ml',100,22,'7979481656',4),(00143,'Lactic Acid (PURAC)','Raw Material',138,1000,'ml',1000,24,'3925459730',5),(00144,'Sodium Lactate (Purasal)','Raw Material',59,100,'g',100,49,'6638053789',1),(00145,'Tea Tree oil','Raw Material',59,500,'g',500,40,'4213104501',10),(00146,'Little John Texan','Raw Material',150,500,'g',500,39,'7947104876',10),(00147,'Virginity Extract','Raw Material',81,750,'g',750,22,'4214824679',2),(00148,'Guava Extract','Raw Material',51,1000,'ml',1000,33,'5044758943',9),(00149,'D & C Blue #1(1% sol)','Raw Material',149,100,'g',100,31,'2757583487',8),(00150,'Sodium Chloride','Raw Material',73,250,'ml',250,36,'5875680483',2),(00151,'Deoplex','Raw Material',139,750,'ml',750,31,'8155160792',4),(00152,'Tongkat ali  extract','Raw Material',53,250,'g',250,37,'1130787242',8),(00153,'Avocado Oil','Raw Material',115,500,'g',500,39,'3446101558',1),(00154,'Mangosteen Extract','Raw Material',65,250,'ml',250,35,'2055122116',3),(00155,'Mango Extract','Raw Material',113,250,'ml',250,22,'8046225441',2),(00156,'Bisabolol','Raw Material',123,500,'g',500,19,'8841730687',4),(00157,'verstatil','Raw Material',57,750,'ml',750,50,'8019083602',6),(00158,'MAP','Raw Material',114,1000,'g',1000,37,'1837068030',10),(00159,'Cucumber extract','Raw Material',135,250,'g',250,42,'2976018583',4),(00160,'Witch Hazel extract','Raw Material',58,100,'ml',100,30,'7057524459',2),(00161,'Pentavitin','Raw Material',66,250,'ml',250,48,'2110183975',10),(00162,'Polysorbate 20','Raw Material',141,250,'g',250,37,'2871065387',3),(00163,'Vitamin E','Raw Material',84,250,'g',250,27,'7183603793',6),(00164,'Euniphen','Raw Material',104,500,'ml',500,12,'2522668652',7),(00165,'D & C Red # 33','Raw Material',91,500,'ml',500,45,'3483583549',5),(00166,'Chicha Morada','Raw Material',93,750,'ml',750,38,'5147823660',5),(00167,'Xanthan Gum','Raw Material',105,1000,'ml',1000,50,'6726067246',4),(00168,'GINGER EXTRACT','Raw Material',138,100,'ml',100,43,'9737572440',5),(00169,'Guava Extract','Raw Material',103,1000,'g',1000,36,'9631350897',5),(00170,'SUGAR','Raw Material',54,750,'ml',750,12,'9569886007',4),(00171,'CREAMER','Raw Material',83,500,'ml',500,49,'2518908478',9),(00237,'SM BONUS TOILET DEO. STRAWBERRY  (FRONTLABEL)','Packaging',66,1,'na',1,42,'8311744326',9),(00238,'SM BONUS TOILET DEO. LEMON  (FRONTLABEL)','Packaging',58,1,'na',1,43,'3964780530',6),(00239,'SM BONUS TOILET DEO.SAMPAGUITA  (FRONTLABEL)','Packaging',58,1,'na',1,10,'5315909982',4),(00240,'SM BonusToi. Deo REFILL Strawberry 50gms (Barcode)','Packaging',135,1,'na',1,47,'6835691285',4),(00241,'SM BonusToi. Deo REFILL Strawberry 100gms (Barcode)','Packaging',75,1,'na',1,31,'6971903636',3),(00242,'SM BONUS DEO HOLDER STRAW 50GMS (Barcode)','Packaging',50,1,'na',1,42,'3252436443',10),(00243,'SM BONUS DEO HOLDER STRAW 100GMS (Barcode)','Packaging',99,1,'na',1,18,'2058803772',8),(00244,'SM BonusToi. Deo REFILL Lemon 50gms (Barcode)','Packaging',133,1,'na',1,36,'3758102933',6),(00245,'SM BONUS DEO REF. LEMON 100GMS (Barcode)','Packaging',120,1,'na',1,28,'1462824827',7),(00246,'SM BONUS DEO HOLDER LEMON 50GMS (Barcode)','Packaging',122,1,'na',1,38,'8956110791',7),(00247,'SM BONUS DEO HOLDER LEMON100GMS (Barcode)','Packaging',127,1,'na',1,11,'9151993591',4),(00248,'BONUS DEO REFILL SAMPAGUITA 100GMS(Barcode)','Packaging',133,1,'na',1,32,'8454698365',10),(00249,'BONUS DEO REFILL SAMPAGUITA 50GMS (Barcode)','Packaging',143,1,'na',1,42,'3876876302',5),(00250,'BONUS DEOHolder SAMPAGUITA 50GMS (Barcode)','Packaging',118,1,'na',1,17,'2428006812',7),(00251,'BONUS DEO HOLDER SAMPAGUITA 100GMS (Barcode)','Packaging',118,1,'na',1,29,'5591254474',6),(00252,'SM Bonus TBC Pine 500ml set (back and Frontlabel)','Packaging',119,1,'na',1,34,'5916945377',6),(00253,'SM BONUS TBC SAMPAGUITA 500ML LABEL SET (F/B)','Packaging',66,1,'na',1,14,'1442114571',1),(00254,'SM BONUS TBCLEMON 500ML LABEL SET (F/B)','Packaging',129,1,'na',1,45,'9402589248',9),(00255,'SM BONUS TBC LEMON 250ML LABEL SET (F/B)','Packaging',122,1,'na',1,31,'4999189840',4),(00256,'SM Bonus TBC Pine 250ml set (back and Frontlabel)','Packaging',150,1,'na',1,33,'9201825280',3),(00257,'SM BONUS TBC SAMPAGUITA 250ML LABEL SET (F/B)','Packaging',132,1,'na',1,20,'3455687618',2),(00258,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',102,1,'na',1,37,'5460142770',3),(00259,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',50,1,'na',1,42,'8273322652',4),(00260,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',70,1,'na',1,10,'2099144002',6),(00261,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',84,1,'na',1,19,'1392444557',4),(00262,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',115,1,'na',1,26,'4831662538',8),(00263,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',71,1,'na',1,32,'8031413932',3),(00264,'SM BONUS GLASS CLEANER (FRONT /BACKLABEL)','Packaging',61,1,'na',1,49,'3513844735',8),(00265,'SM BONUS ALCOHOL 70% 250ML (FRONTLABEL)','Packaging',53,1,'na',1,35,'1938339950',2),(00266,'SM BONUS ALCOHOL 70% 500ML (FRONTLABEL)','Packaging',73,1,'na',1,17,'9557601485',1),(00267,'SM BONUS SHOWER FRESH 250ML( FRONT LABEL)','Packaging',101,1,'na',1,13,'8880811656',5),(00268,'SM BONUS SHOWER FRESH 500ML( FRONT LABEL)','Packaging',137,1,'na',1,29,'6473214011',7),(00269,'SM BONUS BABYFRESH ALCOLOGNE 250ml( front label)','Packaging',87,1,'na',1,11,'8122770344',2),(00270,'SM BONUS BABYFRESH ALCOLOGNE 500ml (front label)','Packaging',52,1,'na',1,25,'3404284848',1),(00271,'CELLOPHANE - WHITE','Packaging',66,1,'na',1,22,'8653092026',4),(00272,'CELLOPHANE - PINK','Packaging',133,1,'na',1,33,'6720598829',9),(00273,'CELLOPHANE - YELLOW','Packaging',63,1,'na',1,43,'4679940458',5),(00274,'CLEANING SOLUTION 201-0001-252','Packaging',93,1,'na',1,46,'5301917801',1),(00275,'MAKE-UP V708-D','Packaging',129,1,'na',1,36,'5168009944',6),(00276,'BLACK INK V435-D','Packaging',97,1,'na',1,27,'2046277019',7),(00277,'TRIGGER SPRAYER 28MM WHITE (YUYTR100-1)','Packaging',102,1,'na',1,16,'9962119569',7),(00278,'19.00mm ISPP (60ml Jimms Oil Liniment)','Packaging',89,1,'na',1,15,'8001753589',3),(00279,'17.4MM ISPP  (30mL Jimms Oil Liniment)','Packaging',80,1,'na',1,17,'3479981964',5),(00280,'34.00MM PS LINER (Trenz Purple Corn Powder Juice 350mL)','Packaging',107,1,'na',1,41,'8624981727',3),(00281,'23.2MM SAFETY SEAL \'PE\' (SM Bonus Bleach 250mL)','Packaging',112,1,'na',1,25,'9602461861',9),(00282,'26.5mm Safety Seal \'PE\' (SM Bonuis Bleach 1000mL)','Packaging',61,1,'na',1,40,'1958285246',8),(00283,'31.5MM Safety Seal \'PE\' (SM Bonus 1/2 Gal )','Packaging',61,1,'na',1,46,'2259937723',2),(00284,'22.00mm/ 18.5MM EPE Foam Washer (SM Bonus TBC)','Packaging',136,1,'na',1,13,'8696232358',10),(00285,'CORR. BOX (RSC BFLUTE 175 lbs GLUED JOINT W/ ONE COLOR PRINT)','Packaging',135,1,'na',1,47,'3078381271',1),(00286,'410 x 365  x 224mm x 175lbs. Test OD (500ml)','Packaging',81,1,'na',1,18,'7913952906',9),(00287,'445 x 345 181mm x 175lbs. Test OD (250ml)','Packaging',87,1,'na',1,10,'5479051741',6),(00288,'RSC,  C-125  LBS, Glued Joint, With Print  ','Packaging',132,1,'na',1,30,'7549748351',9),(00289,'(Toilet deo 50g, Holder Sm Bonus) 288 x 223 x 161mm','Packaging',77,1,'na',1,14,'5384696375',2),(00290,'50G REFILL(262 X 196 X 163mm) ','Packaging',57,1,'na',1,36,'4539714253',3),(00291,'100G REFILL (290 x 226 x  262mm)','Packaging',149,1,'na',1,19,'1687016627',8),(00292,'100G HOLDER (290 x 226 x 262mm)','Packaging',103,1,'na',1,37,'5292822722',2),(00293,'54 X 30 TRANSPARENT W/ PRINT','Packaging',67,1,'na',1,16,'9398667468',7),(00294,'46.00mm/38.mm SM BONUS TBC/ALCOHOL CAPSEAL','Packaging',129,1,'na',1,17,'8401852198',6),(00295,'119.00mm/40.mm SM BONUS DEO CAPSEAL 100G.','Packaging',62,1,'na',1,17,'1500280633',5),(00296,'105.00X40mm SM BONUS DEO CAPSEAL 50G.','Packaging',142,1,'na',1,29,'7092427916',6),(00297,'60ML BOTTLE','Packaging',140,1,'na',1,37,'2177496010',4),(00298,'DIRTY WHITE CAPS FOR 60ML','Packaging',110,1,'na',1,44,'3757401815',2),(00299,'30ML BOTTLE','Packaging',106,1,'na',1,48,'8960810207',2),(00300,'DIRTY WHITE CAPS FOR 30ML','Packaging',132,1,'na',1,34,'8743373844',6),(00301,'PET GLASS CLEANER 600ML','Packaging',138,1,'na',1,20,'9516528757',1),(00302,'7072-4076 Translucent Blue Screw on Smooth Wall with ','Packaging',140,1,'na',1,24,'1790132601',4),(00303,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',150,1,'na',1,35,'7270767603',9),(00304,'7072-3148 Translucent PINK Screw on Smooth Wall with ','Packaging',106,1,'na',1,34,'1210372448',5),(00305,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',69,1,'na',1,47,'4340555017',4),(00306,'7072-665 Translucent YELLOW Screw on Smooth Wall with ','Packaging',87,1,'na',1,14,'2964972969',4),(00307,'ZELSNAP, 4gms, Material: Polypropylene (PP)','Packaging',124,1,'na',1,40,'4679445901',2),(00308,'ALCOHOL BOT 250','Packaging',137,1,'na',1,36,'8692687936',5),(00309,'ALCOHOL BOT. 500','Packaging',55,1,'na',1,20,'1838910933',4),(00310,'24MM FLIPTOP CAP COLORED ( +VAT )','Packaging',108,1,'na',1,35,'7485659199',8),(00311,'PACKAGING TAPE 3\" X 90Rls.\"','Packaging',105,1,'na',1,45,'8564671097',6),(00312,'ALCOHOL 500 CARTON','Packaging',108,1,'na',1,31,'6444780162',3),(00313,'ALCOHOL 250 CARTON','Packaging',84,1,'na',1,43,'3224399151',7),(00314,'DEODORANT CARTON','Packaging',121,1,'na',1,34,'6566105989',5),(00315,'GLASS SPRAY CARTON','Packaging',67,1,'na',1,27,'1449791919',1),(00316,'GLASS REFILL CARTON','Packaging',61,1,'na',1,24,'8665797051',7),(00317,'HALFGALLON CARTON','Packaging',134,1,'na',1,11,'8020250440',9),(00318,'CREAMER POUCH','Packaging',72,1,'na',1,27,'5065247868',1),(00319,'SUGAR POUCH','Packaging',72,1,'na',1,20,'2476277023',8),(00320,'SUGAR PLASTIC','Packaging',57,1,'na',1,36,'9435536217',9),(00321,'CREAMER PLASTIC','Packaging',57,1,'na',1,46,'3706699110',4);
/*!40000 ALTER TABLE `inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory_production`
--

DROP TABLE IF EXISTS `inventory_production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `inventory_production` (
  `id` int NOT NULL AUTO_INCREMENT,
  `item_name` varchar(45) DEFAULT NULL,
  `category` varchar(45) DEFAULT NULL,
  `theoretical_yield` int DEFAULT NULL,
  `actual_yield` int DEFAULT NULL,
  `percent_yield` decimal(10,2) DEFAULT NULL,
  `quantity` decimal(10,2) DEFAULT NULL,
  `weight` decimal(10,2) DEFAULT NULL,
  `size` decimal(10,2) DEFAULT NULL,
  `unit` varchar(20) DEFAULT NULL,
  `status` varchar(25) DEFAULT NULL,
  `rfid` int DEFAULT NULL,
  `product_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_production`
--

LOCK TABLES `inventory_production` WRITE;
/*!40000 ALTER TABLE `inventory_production` DISABLE KEYS */;
INSERT INTO `inventory_production` VALUES (1,'Water','Raw Material',100,100,100.00,10.00,100.00,500.00,'ml','received',468081568,'Soap'),(2,'Bleach','Raw Material',100,100,100.00,10.00,100.00,500.00,'ml','received',468081568,'Soap'),(3,'Powder','Raw Material',100,100,100.00,10.00,100.00,500.00,'g','received',468081568,'Soap'),(4,'Ethanol','Raw Material',90,90,100.00,25.00,100.00,100.00,'ml','received',246757330,'Detergent Powder'),(5,'Sugar','Raw Material',90,90,100.00,10.00,25.00,25.00,'g','received',246757330,'Detergent Powder'),(6,'Salt','Raw Material',120,120,100.00,10.00,25.00,25.00,'g','received',246757330,'Detergent Powder'),(7,'Flour','Raw Material',87,87,100.00,10.00,25.00,25.00,'g','received',246757330,'Detergent Powder');
/*!40000 ALTER TABLE `inventory_production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `production`
--

DROP TABLE IF EXISTS `production`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `production` (
  `prod_id` int NOT NULL AUTO_INCREMENT,
  `prod_item_name` varchar(45) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prod_category` varchar(25) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `prod_theoretical_yield` decimal(10,2) DEFAULT NULL,
  `prod_actual_yield` decimal(10,2) DEFAULT NULL,
  `prod_percent_yield` decimal(10,2) DEFAULT NULL,
  `prod_qty` int DEFAULT NULL,
  `prod_received_weight` decimal(10,2) DEFAULT NULL,
  `prod_size` int DEFAULT NULL,
  `prod_unit` varchar(25) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prod_status` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `prod_rfid` varchar(15) CHARACTER SET utf8 COLLATE utf8_bin DEFAULT NULL,
  `prod_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  PRIMARY KEY (`prod_id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `production`
--

LOCK TABLES `production` WRITE;
/*!40000 ALTER TABLE `production` DISABLE KEYS */;
INSERT INTO `production` VALUES (1,NULL,'Liquid',100.00,100.00,100.00,NULL,500.00,NULL,NULL,'Pending',NULL,'Alcohol'),(2,NULL,'Liquid',100.00,100.00,100.00,NULL,500.00,NULL,NULL,'Processing',NULL,'Water'),(7,'Water','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(8,'Bleach','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(9,'Powder','Raw Material',100.00,100.00,100.00,10,100.00,500,'g','pending','468081568','Soap'),(10,'Ethanol','Raw Material',90.00,90.00,100.00,25,100.00,100,'ml','pending','246757330','Detergent Powder'),(11,'Sugar','Raw Material',90.00,90.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(12,'Salt','Raw Material',120.00,120.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(13,'Flour','Raw Material',87.00,87.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(14,'Ethanol','Raw Material',90.00,90.00,100.00,25,100.00,100,'ml','pending','246757330','Detergent Powder'),(15,'Sugar','Raw Material',90.00,90.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(16,'Salt','Raw Material',120.00,120.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(17,'Flour','Raw Material',87.00,87.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(18,'Water','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(19,'Bleach','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(20,'Powder','Raw Material',100.00,100.00,100.00,10,100.00,500,'g','pending','468081568','Soap'),(21,'Ethanol','Raw Material',90.00,90.00,100.00,25,100.00,100,'ml','pending','246757330','Detergent Powder'),(22,'Sugar','Raw Material',90.00,90.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(23,'Salt','Raw Material',120.00,120.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(24,'Flour','Raw Material',87.00,87.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(25,'Water','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(26,'Bleach','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(27,'Powder','Raw Material',100.00,100.00,100.00,10,100.00,500,'g','pending','468081568','Soap'),(28,'Water','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(29,'Bleach','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(30,'Powder','Raw Material',100.00,100.00,100.00,10,100.00,500,'g','pending','468081568','Soap'),(31,'Ethanol','Raw Material',90.00,90.00,100.00,25,100.00,100,'ml','pending','246757330','Detergent Powder'),(32,'Sugar','Raw Material',90.00,90.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(33,'Salt','Raw Material',120.00,120.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(34,'Flour','Raw Material',87.00,87.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(35,'Ethanol','Raw Material',90.00,90.00,100.00,25,100.00,100,'ml','pending','246757330','Detergent Powder'),(36,'Sugar','Raw Material',90.00,90.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(37,'Salt','Raw Material',120.00,120.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(38,'Flour','Raw Material',87.00,87.00,100.00,10,25.00,25,'g','pending','246757330','Detergent Powder'),(39,'Water','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(40,'Bleach','Raw Material',100.00,100.00,100.00,10,100.00,500,'ml','pending','468081568','Soap'),(41,'Powder','Raw Material',100.00,100.00,100.00,10,100.00,500,'g','pending','468081568','Soap');
/*!40000 ALTER TABLE `production` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe`
--

DROP TABLE IF EXISTS `recipe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recipe` (
  `recipe_id` int NOT NULL AUTO_INCREMENT,
  `id` int NOT NULL,
  `product_name` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `recipe` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `weight` decimal(10,2) NOT NULL,
  `unit` varchar(45) DEFAULT NULL,
  `size` int DEFAULT NULL,
  PRIMARY KEY (`recipe_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe`
--

LOCK TABLES `recipe` WRITE;
/*!40000 ALTER TABLE `recipe` DISABLE KEYS */;
INSERT INTO `recipe` VALUES (1,1,'Alcohol','water',210.00,'ml',700),(2,1,'Alcohol','ethanol',490.00,'ml',700),(3,2,'Refined Sugar','sugar',1000.00,'g',1000);
/*!40000 ALTER TABLE `recipe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shipment_items`
--

DROP TABLE IF EXISTS `shipment_items`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipment_items` (
  `Shipment_Item_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Shipment_ID` int DEFAULT NULL,
  `Item_ID` int DEFAULT NULL,
  `Quantity` int DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Shipment_Item_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=110 DEFAULT CHARSET=utf8;
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
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `shipments` (
  `Shipment_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Category` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `Origin` varchar(100) DEFAULT NULL,
  `Destination` varchar(100) DEFAULT NULL,
  `Distance` decimal(10,0) DEFAULT NULL,
  `Truck_ID` int DEFAULT NULL,
  `Delivery_Agent_ID` int DEFAULT NULL,
  `Date_Created` datetime DEFAULT CURRENT_TIMESTAMP,
  `Date_Due` datetime DEFAULT NULL,
  `Date_Accomplished` datetime DEFAULT NULL,
  `Estimated_Time` int DEFAULT NULL,
  `Actual_Time` int DEFAULT NULL,
  `Delay` int DEFAULT NULL,
  PRIMARY KEY (`Shipment_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=103 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shipments`
--

LOCK TABLES `shipments` WRITE;
/*!40000 ALTER TABLE `shipments` DISABLE KEYS */;
INSERT INTO `shipments` VALUES (00001,'Inbound','Complete','SANTA MESA HEIGHT','QUIAPO',12,3,2,'2019-01-24 11:36:43','2019-02-23 12:44:08','2019-03-19 22:26:25',222,248,26),(00002,'Outbound','Complete','UGONG NORTE','ERMITA',14,2,2,'2019-01-22 05:07:28','2019-03-01 00:38:56','2019-06-22 19:53:27',90,126,36),(00003,'Inbound','Complete','NOVALICHES','SANTA MESA',14,1,2,'2019-01-19 17:51:10','2019-02-23 10:57:39','2019-11-29 12:47:56',133,145,12),(00004,'Inbound','In-Transit','NEW MANILA','SAN MIGUEL',13,2,2,'2019-01-07 15:58:55','2019-02-24 11:39:00','2019-10-07 07:49:30',96,132,36),(00005,'Inbound','Complete','GALAS-SANTOL','SAMPALOC',15,1,2,'2019-01-07 23:14:49','2019-02-25 16:08:13','2019-07-04 11:59:17',136,155,19),(00006,'Inbound','Complete','CUBAO','QUIAPO',9,3,2,'2019-01-12 20:20:14','2019-02-08 12:06:27','2019-06-17 22:54:19',170,172,2),(00007,'Outbound','Complete','LOYOLA HEIGHTS','MALATE',8,2,2,'2019-01-08 20:50:28','2019-03-01 16:28:13','2019-08-12 18:06:12',158,189,31),(00008,'Outbound','Complete','NOVALICHES','MALATE',11,2,2,'2019-01-02 01:41:46','2019-02-01 16:51:34','2019-05-30 17:50:36',252,265,13),(00009,'Outbound','In-Transit','GALAS-SANTOL','SANTA ANA',15,2,2,'2019-01-16 19:40:13','2019-02-04 14:30:05','2019-12-19 13:16:14',154,186,32),(00010,'Outbound','Complete','DILIMAN','ERMITA',10,1,2,'2019-01-09 05:19:28','2019-02-11 06:14:35','2019-06-01 11:21:48',289,332,43),(00011,'Outbound','Complete','DILIMAN','PORT AREA',10,3,2,'2019-01-02 13:51:33','2019-02-26 04:46:09','2019-05-15 22:13:24',288,333,45),(00012,'Inbound','In-Transit','COMMONWEALTH AVENUE','SANTA CRUZ',14,2,2,'2019-01-06 00:18:32','2019-02-19 09:08:05','2019-04-13 19:20:33',264,294,30),(00013,'Outbound','In-Transit','TRIANGLE PARK','SANTA ANA',8,1,2,'2019-01-01 00:58:49','2019-02-15 21:43:21','2019-04-25 07:52:55',140,155,15),(00014,'Inbound','Pending','NOVALICHES','SAN MIGUEL',8,3,2,'2019-01-14 21:33:57','2019-02-24 21:11:58','2019-09-01 13:15:37',134,160,26),(00015,'Outbound','Pending','LA LOMA','PANDACAN',11,1,2,'2019-01-05 04:08:52','2019-02-25 03:53:08','2019-10-30 13:29:17',276,298,22),(00016,'Outbound','In-Transit','BAGUMBAYAN','ERMITA',10,1,2,'2019-01-14 05:44:17','2019-02-08 22:59:31','2019-08-03 06:43:51',200,248,48),(00017,'Inbound','In-Transit','THE PROJECT AREAS','PORT AREA',8,3,2,'2019-01-25 02:45:27','2019-03-01 05:40:06','2019-03-08 11:05:32',120,135,15),(00018,'Inbound','Complete','GALAS-SANTOL','INTRAMUROS',14,3,2,'2019-01-01 09:51:45','2019-02-03 19:56:04','2019-10-16 21:27:28',223,228,5),(00019,'Outbound','In-Transit','BAGUMBAYAN','BINONDO',8,3,2,'2019-01-07 12:15:09','2019-02-07 07:45:56','2019-12-28 17:21:05',184,205,21),(00020,'Outbound','Complete','TRIANGLE PARK','BINONDO',15,3,2,'2019-01-07 01:29:28','2019-02-10 14:46:12','2019-08-28 23:42:17',208,218,10),(00021,'Outbound','In-Transit','DILIMAN','SAN MIGUEL',8,2,2,'2019-01-24 07:31:56','2019-02-09 09:57:31','2019-05-19 06:55:07',208,239,31),(00022,'Outbound','Pending','DILIMAN','PANDACAN',12,1,2,'2019-01-05 18:40:34','2019-02-16 21:26:34','2019-06-23 12:54:23',105,112,7),(00023,'Outbound','In-Transit','BAGUMBAYAN','SAN NICOLAS',9,1,2,'2019-01-28 12:31:04','2019-02-12 03:17:58','2019-04-05 03:42:35',233,258,25),(00024,'Outbound','In-Transit','SAN FRANCISCO DEL MONTE','BINONDO',15,2,2,'2019-01-13 17:16:07','2019-02-26 11:49:39','2019-08-24 10:51:08',121,150,29),(00025,'Inbound','Pending','TANDANG SORA','BINONDO',15,3,2,'2019-01-02 09:02:31','2019-02-11 01:19:17','2019-08-01 08:10:46',98,122,24),(00026,'Outbound','Complete','COMMONWEALTH AVENUE','SANTA ANA',11,2,2,'2019-01-23 17:19:40','2019-02-10 12:53:14','2019-04-17 07:29:48',177,225,48),(00027,'Outbound','In-Transit','SANTA MESA HEIGHT','SANTA CRUZ',8,3,2,'2019-01-07 10:23:41','2019-02-02 14:59:39','2019-11-04 21:45:56',80,121,41),(00028,'Outbound','Complete','TANDANG SORA','SAMPALOC',9,3,2,'2019-01-07 17:09:40','2019-02-08 18:32:40','2019-04-24 16:43:38',299,328,29),(00029,'Outbound','In-Transit','TANDANG SORA','SANTA ANA',13,2,2,'2019-01-06 22:40:17','2019-02-26 15:02:18','2019-09-14 16:19:07',223,268,45),(00030,'Inbound','Pending','NEW MANILA','MALATE',15,3,2,'2019-01-14 03:15:42','2019-02-21 16:16:37','2019-06-10 15:59:08',93,98,5),(00031,'Outbound','In-Transit','DILIMAN','TONDO',15,2,2,'2019-01-28 06:07:41','2019-02-06 16:01:08','2019-12-02 17:37:19',297,325,28),(00032,'Outbound','Pending','SAN FRANCISCO DEL MONTE','INTRAMUROS',8,2,2,'2019-01-28 15:16:45','2019-02-09 23:15:02','2019-04-28 22:32:25',217,219,2),(00033,'Outbound','Complete','CUBAO','BINONDO',13,2,2,'2019-01-17 13:26:23','2019-02-08 05:08:07','2019-04-05 03:02:28',167,212,45),(00034,'Outbound','Pending','CUBAO','SAN NICOLAS',14,1,2,'2019-01-11 00:12:55','2019-02-27 04:24:00','2019-06-14 21:37:55',291,314,23),(00035,'Outbound','Pending','LOYOLA HEIGHTS','SAMPALOC',13,2,2,'2019-01-05 07:08:32','2019-02-06 09:49:13','2019-06-19 18:54:41',217,255,38),(00036,'Inbound','Pending','TANDANG SORA','SANTA MESA',11,1,2,'2019-01-07 12:37:27','2019-02-17 20:30:58','2019-03-11 07:45:44',261,286,25),(00037,'Outbound','In-Transit','CUBAO','MALATE',11,3,2,'2019-01-02 20:10:38','2019-02-04 08:30:38','2019-08-23 09:33:51',262,276,14),(00038,'Inbound','Complete','NEW MANILA','PACO',9,2,2,'2019-01-08 14:32:40','2019-02-23 05:37:22','2019-11-17 03:22:30',272,285,13),(00039,'Outbound','Pending','LA LOMA','QUIAPO',11,2,2,'2019-01-23 10:18:01','2019-03-02 12:15:00','2019-05-28 22:00:10',196,223,27),(00040,'Outbound','In-Transit','SANTA MESA HEIGHT','SANTA MESA',13,1,2,'2019-01-28 09:33:50','2019-02-18 00:50:20','2019-07-25 21:07:30',281,328,47),(00041,'Inbound','Pending','BAGUMBAYAN','SANTA MESA',11,3,2,'2019-01-05 21:02:53','2019-02-01 00:33:16','2019-09-26 11:42:05',236,248,12),(00042,'Outbound','Complete','UGONG NORTE','PORT AREA',14,3,2,'2019-01-21 05:09:08','2019-02-10 10:46:23','2019-11-22 07:24:43',116,116,0),(00043,'Inbound','In-Transit','CUBAO','PANDACAN',11,2,2,'2019-01-07 03:15:18','2019-02-07 10:28:46','2019-12-05 13:37:12',206,240,34),(00044,'Outbound','In-Transit','THE PROJECT AREAS','BINONDO',12,3,2,'2019-01-14 02:07:30','2019-02-04 23:36:46','2019-07-13 05:41:33',174,174,0),(00045,'Inbound','Complete','LA LOMA','SAN MIGUEL',12,2,2,'2019-01-22 01:23:29','2019-02-05 09:30:34','2019-11-27 23:50:31',223,242,19),(00046,'Outbound','Complete','LA LOMA','QUIAPO',10,1,2,'2019-01-27 11:01:37','2019-02-08 21:17:12','2019-04-13 17:22:21',236,246,10),(00047,'Inbound','Complete','CUBAO','TONDO',15,1,2,'2019-01-01 22:28:57','2019-02-18 18:01:42','2019-12-26 14:10:08',249,267,18),(00048,'Inbound','Complete','COMMONWEALTH AVENUE','QUIAPO',9,2,2,'2019-01-30 11:05:36','2019-02-23 05:52:29','2019-11-25 17:40:39',197,245,48),(00049,'Inbound','In-Transit','LOYOLA HEIGHTS','SANTA CRUZ',9,2,2,'2019-01-18 23:02:33','2019-02-27 16:19:38','2019-05-14 18:08:35',164,165,1),(00050,'Inbound','Pending','THE PROJECT AREAS','PACO',15,2,2,'2019-01-04 18:16:26','2019-02-16 03:05:55','2019-09-30 04:58:36',144,158,14),(00051,'Inbound','Complete','NOVALICHES','SAN ANDRES',13,3,2,'2019-01-24 20:05:57','2019-02-11 14:00:59','2019-06-11 22:16:05',200,225,25),(00052,'Inbound','In-Transit','SANTA MESA HEIGHT','TONDO',14,2,2,'2019-01-01 08:17:52','2019-02-13 10:24:41','2019-11-30 10:30:05',262,273,11),(00053,'Inbound','Pending','SAN FRANCISCO DEL MONTE','PACO',13,1,2,'2019-01-28 00:35:58','2019-02-18 01:11:55','2019-10-03 21:53:27',166,192,26),(00054,'Outbound','Complete','COMMONWEALTH AVENUE','SANTA CRUZ',11,3,2,'2019-01-08 11:55:22','2019-02-27 23:58:25','2019-07-03 00:48:47',205,239,34),(00055,'Outbound','In-Transit','UGONG NORTE','PACO',13,2,2,'2019-01-12 04:11:00','2019-02-26 03:09:13','2019-04-27 09:03:34',254,294,40),(00056,'Outbound','Complete','GALAS-SANTOL','INTRAMUROS',13,1,2,'2019-01-27 12:58:31','2019-03-01 01:43:22','2019-04-06 17:43:41',279,291,12),(00057,'Inbound','In-Transit','SANTA MESA HEIGHT','ERMITA',8,3,2,'2019-01-27 11:25:50','2019-02-26 15:13:53','2019-09-11 14:03:50',90,100,10),(00058,'Inbound','Complete','LOYOLA HEIGHTS','PANDACAN',15,3,2,'2019-01-30 07:31:08','2019-02-22 08:13:57','2019-08-07 06:10:30',183,194,11),(00059,'Inbound','In-Transit','COMMONWEALTH AVENUE','QUIAPO',14,1,2,'2019-01-21 22:26:56','2019-02-17 20:08:48','2019-10-02 11:03:34',171,218,47),(00060,'Inbound','In-Transit','UGONG NORTE','PORT AREA',12,3,2,'2019-01-16 17:53:27','2019-02-26 10:22:19','2019-03-26 18:58:22',104,104,0),(00061,'Inbound','In-Transit','NEW MANILA','SAMPALOC',8,1,2,'2019-01-12 08:29:22','2019-02-21 15:50:48','2019-03-08 20:44:42',297,306,9),(00062,'Outbound','Pending','THE PROJECT AREAS','SAN NICOLAS',10,1,2,'2019-01-07 11:01:38','2019-02-19 02:59:00','2019-06-21 08:14:25',212,255,43),(00063,'Outbound','Pending','UGONG NORTE','PORT AREA',15,3,2,'2019-01-24 21:16:35','2019-03-01 07:06:25','2019-03-18 06:41:29',296,296,0),(00064,'Inbound','Complete','COMMONWEALTH AVENUE','TONDO',13,2,2,'2019-01-24 02:10:24','2019-02-15 07:06:21','2019-07-23 20:18:12',157,186,29),(00065,'Inbound','In-Transit','DILIMAN','SANTA MESA',15,1,2,'2019-01-19 22:32:00','2019-02-17 14:33:21','2019-07-30 11:21:40',277,321,44),(00066,'Inbound','Complete','TRIANGLE PARK','SANTA MESA',8,1,2,'2019-01-05 08:55:08','2019-02-09 00:58:38','2019-05-31 08:52:28',115,136,21),(00067,'Inbound','In-Transit','LOYOLA HEIGHTS','SAN ANDRES',8,2,2,'2019-01-28 09:44:25','2019-03-02 23:21:58','2019-09-21 21:03:15',152,201,49),(00068,'Inbound','Pending','TRIANGLE PARK','TONDO',13,1,2,'2019-01-19 13:50:22','2019-02-21 23:12:49','2019-11-02 04:17:54',139,146,7),(00069,'Inbound','Pending','THE PROJECT AREAS','PACO',10,2,2,'2019-01-12 07:46:59','2019-02-23 05:16:35','2019-12-28 02:15:32',147,195,48),(00070,'Outbound','Complete','NEW MANILA','ERMITA',8,3,2,'2019-01-13 01:53:20','2019-02-02 14:32:35','2019-11-30 00:21:30',258,290,32),(00071,'Inbound','In-Transit','SAN FRANCISCO DEL MONTE','SAN MIGUEL',10,1,2,'2019-01-24 12:11:27','2019-03-01 14:53:31','2019-08-24 18:41:13',172,210,38),(00072,'Inbound','Complete','SANTA MESA HEIGHT','SAN ANDRES',12,1,2,'2019-01-27 20:14:31','2019-03-02 04:59:26','2019-07-02 09:59:45',268,314,46),(00073,'Outbound','Complete','BAGUMBAYAN','TONDO',9,2,2,'2019-01-07 21:10:01','2019-02-21 09:43:57','2019-07-18 03:11:18',237,250,13),(00074,'Outbound','Pending','GALAS-SANTOL','BINONDO',13,2,2,'2019-01-25 02:16:56','2019-02-20 03:44:07','2019-12-27 08:05:08',86,101,15),(00075,'Inbound','Complete','LOYOLA HEIGHTS','MALATE',10,2,2,'2019-01-05 02:52:13','2019-02-10 06:43:10','2019-04-23 13:26:36',214,233,19),(00076,'Outbound','In-Transit','SAN FRANCISCO DEL MONTE','INTRAMUROS',13,2,2,'2019-01-18 17:58:32','2019-02-03 11:20:10','2019-03-20 07:15:48',177,191,14),(00077,'Inbound','In-Transit','CUBAO','SAN NICOLAS',10,2,2,'2019-01-07 02:17:02','2019-02-25 11:36:10','2019-12-22 12:59:49',132,169,37),(00078,'Inbound','Pending','TANDANG SORA','INTRAMUROS',9,1,2,'2019-01-12 07:12:14','2019-02-13 23:26:48','2019-05-14 06:20:01',89,99,10),(00079,'Inbound','Pending','LA LOMA','MALATE',9,2,2,'2019-01-23 10:49:47','2019-02-17 13:17:50','2019-04-28 17:39:07',244,268,24),(00080,'Outbound','Complete','NOVALICHES','SANTA ANA',11,2,2,'2019-01-08 18:57:08','2019-02-07 03:42:15','2019-03-06 10:42:46',197,228,31),(00081,'Inbound','Complete','TRIANGLE PARK','PANDACAN',11,2,2,'2019-01-17 08:34:19','2019-02-20 07:48:19','2019-06-01 07:42:53',265,314,49),(00082,'Outbound','Pending','THE PROJECT AREAS','ERMITA',11,1,2,'2019-01-27 23:25:16','2019-02-18 22:52:45','2019-10-26 13:54:55',177,202,25),(00083,'Inbound','In-Transit','NEW MANILA','SAMPALOC',10,2,2,'2019-01-27 19:23:44','2019-02-24 20:58:46','2019-08-25 15:48:25',95,135,40),(00084,'Outbound','Complete','GALAS-SANTOL','SANTA CRUZ',13,2,2,'2019-01-09 06:50:40','2019-02-12 09:55:16','2019-03-26 04:54:35',253,297,44),(00085,'Outbound','Complete','SAN FRANCISCO DEL MONTE','SAN ANDRES',13,3,2,'2019-01-17 02:25:59','2019-02-25 09:04:20','2019-12-28 12:28:24',225,268,43),(00086,'Inbound','Pending','LOYOLA HEIGHTS','SAN NICOLAS',8,3,2,'2019-01-21 09:28:24','2019-02-04 15:02:25','2019-05-23 23:12:30',264,283,19),(00087,'Outbound','In-Transit','BAGUMBAYAN','PANDACAN',11,1,2,'2019-01-06 15:54:04','2019-02-19 01:44:14','2019-04-06 07:35:19',141,179,38),(00088,'Outbound','Pending','DILIMAN','SAN MIGUEL',8,2,2,'2019-01-20 08:14:24','2019-02-05 19:36:57','2019-10-27 04:05:01',112,153,41),(00089,'Inbound','In-Transit','BAGUMBAYAN','SAN NICOLAS',11,3,2,'2019-01-14 22:09:15','2019-02-14 13:46:22','2019-05-21 15:07:49',255,293,38),(00090,'Inbound','In-Transit','UGONG NORTE','ERMITA',15,3,2,'2019-01-16 16:55:47','2019-02-26 11:50:30','2019-03-06 21:55:54',231,232,1),(00091,'Inbound','Complete','GALAS-SANTOL','PORT AREA',12,3,2,'2019-01-05 19:28:03','2019-02-16 07:39:53','2019-09-05 00:37:22',83,91,8),(00092,'Inbound','In-Transit','SAN FRANCISCO DEL MONTE','SANTA ANA',12,1,2,'2019-01-26 04:34:52','2019-02-19 14:29:56','2019-09-25 03:50:57',256,292,36),(00093,'Inbound','Pending','TRIANGLE PARK','SAMPALOC',11,2,2,'2019-01-18 13:47:39','2019-02-04 00:48:58','2019-09-07 19:21:53',237,277,40),(00094,'Outbound','Complete','NOVALICHES','INTRAMUROS',15,2,2,'2019-01-18 21:57:21','2019-02-08 01:21:14','2019-10-06 23:44:39',166,190,24),(00095,'Inbound','Pending','LA LOMA','SANTA CRUZ',13,3,2,'2019-01-10 00:56:19','2019-02-05 09:26:32','2019-09-10 15:06:29',255,260,5),(00096,'Outbound','Complete','NEW MANILA','MALATE',15,3,2,'2019-01-16 10:48:48','2019-02-17 01:17:13','2019-03-22 19:33:43',148,186,38),(00097,'Outbound','Pending','LA LOMA','SAN ANDRES',13,3,2,'2019-01-10 10:53:52','2019-02-20 10:17:40','2019-11-08 18:11:31',136,178,42),(00098,'Inbound','Pending','NOVALICHES','SAN ANDRES',9,2,2,'2019-01-28 06:36:09','2019-02-08 02:35:16','2019-05-14 10:46:56',155,160,5),(00099,'Outbound','Complete','COMMONWEALTH AVENUE','PACO',14,1,2,'2019-01-09 16:54:29','2019-03-02 09:29:20','2019-05-09 00:25:15',292,304,12);
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
-- Table structure for table `system_log`
--

DROP TABLE IF EXISTS `system_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `system_log` (
  `Log_ID` int(5) unsigned zerofill NOT NULL AUTO_INCREMENT,
  `Message` varchar(420) DEFAULT NULL,
  `Category` varchar(45) DEFAULT NULL,
  `User_ID` int DEFAULT NULL,
  `Timestamp` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Log_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `system_log`
--

LOCK TABLES `system_log` WRITE;
/*!40000 ALTER TABLE `system_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `system_log` ENABLE KEYS */;
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
  `Capacity` int DEFAULT NULL,
  `Kilometers_Per_Liter` int DEFAULT NULL,
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

--
-- Dumping events for database 'flc'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-04 22:13:37
