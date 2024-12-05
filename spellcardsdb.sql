-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               10.4.28-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             12.8.0.6908
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for spellcardsdb
DROP DATABASE IF EXISTS `spellcardsdb`;
CREATE DATABASE IF NOT EXISTS `spellcardsdb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `spellcardsdb`;

-- Dumping structure for table spellcardsdb.admin_tbl
DROP TABLE IF EXISTS `admin_tbl`;
CREATE TABLE IF NOT EXISTS `admin_tbl` (
  `adminID` int(11) NOT NULL AUTO_INCREMENT,
  `userID` int(11) NOT NULL,
  `deckID` int(11) NOT NULL,
  `flashcardID` int(11) NOT NULL,
  `adminEmail` int(50) DEFAULT 0,
  `adminPassword` int(20) DEFAULT 0,
  PRIMARY KEY (`adminID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table spellcardsdb.admin_tbl: ~0 rows (approximately)
DELETE FROM `admin_tbl`;

-- Dumping structure for table spellcardsdb.deck_tbl
DROP TABLE IF EXISTS `deck_tbl`;
CREATE TABLE IF NOT EXISTS `deck_tbl` (
  `deckID` int(11) NOT NULL AUTO_INCREMENT,
  `flashcardID` int(11) NOT NULL,
  `deckName` varchar(50) DEFAULT '',
  `deckCreated` datetime DEFAULT NULL,
  PRIMARY KEY (`deckID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table spellcardsdb.deck_tbl: ~0 rows (approximately)
DELETE FROM `deck_tbl`;

-- Dumping structure for table spellcardsdb.flashcard_tbl
DROP TABLE IF EXISTS `flashcard_tbl`;
CREATE TABLE IF NOT EXISTS `flashcard_tbl` (
  `flashcardID` int(11) NOT NULL AUTO_INCREMENT,
  `frontCard` varchar(350) DEFAULT NULL,
  `backCard` varchar(350) DEFAULT NULL,
  `flashcardCreated` datetime DEFAULT NULL,
  PRIMARY KEY (`flashcardID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table spellcardsdb.flashcard_tbl: ~0 rows (approximately)
DELETE FROM `flashcard_tbl`;

-- Dumping structure for table spellcardsdb.user_tbl
DROP TABLE IF EXISTS `user_tbl`;
CREATE TABLE IF NOT EXISTS `user_tbl` (
  `userID` int(11) NOT NULL AUTO_INCREMENT,
  `deckID` int(11) NOT NULL,
  `firstName` varchar(50) DEFAULT NULL,
  `lastName` varchar(50) DEFAULT NULL,
  `username` varchar(50) DEFAULT NULL,
  `userPhone` int(11) DEFAULT NULL,
  `userEmail` varchar(50) DEFAULT NULL,
  `userPassword` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- Dumping data for table spellcardsdb.user_tbl: ~0 rows (approximately)
DELETE FROM `user_tbl`;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
