-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : lun. 03 juin 2024 à 12:55
-- Version du serveur : 8.3.0
-- Version de PHP : 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestionperso`
--

-- --------------------------------------------------------

--
-- Structure de la table `absences`
--

DROP TABLE IF EXISTS `absences`;
CREATE TABLE IF NOT EXISTS `absences` (
  `IDABSENCE` int NOT NULL AUTO_INCREMENT,
  `IDPERSONNEL` int NOT NULL,
  `IDMOTIF` int NOT NULL,
  `DATEDEBUT` date NOT NULL,
  `DATEFIN` date NOT NULL,
  PRIMARY KEY (`IDABSENCE`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `absences`
--

INSERT INTO `absences` (`IDABSENCE`, `IDPERSONNEL`, `IDMOTIF`, `DATEDEBUT`, `DATEFIN`) VALUES
(1, 4, 4, '2024-05-01', '2024-09-10'),
(2, 1, 1, '2020-05-01', '2024-08-10'),
(3, 10, 2, '2024-05-08', '2024-05-11'),
(4, 10, 1, '2024-05-18', '2024-05-31'),
(5, 10, 1, '2024-10-01', '2024-12-31'),
(6, 10, 1, '2025-10-01', '2027-12-31');

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `IDMOTIF` int NOT NULL,
  `NOM` varchar(255) NOT NULL,
  PRIMARY KEY (`IDMOTIF`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`IDMOTIF`, `NOM`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `IDSERVICE` int DEFAULT NULL,
  `NOM` varchar(256) NOT NULL,
  `PRENOM` varchar(256) NOT NULL,
  `TEL` varchar(256) NOT NULL,
  `EMAIL` varchar(256) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`ID`, `IDSERVICE`, `NOM`, `PRENOM`, `TEL`, `EMAIL`) VALUES
(1, 1, 'Nashamura', 'Takumi', '06 07 08 09 10', 'taku@initial-d.email'),
(2, 1, 'Ramb', 'John', '07 01 02 03 04', 'Johnny@1984.email'),
(3, 2, 'Piotrsky', 'Lise', '01 00 02 03 04', 'lise@euro.email'),
(4, 3, 'Piotrsky', 'Pierre', '01 00 02 03 08', 'pierrepiotr@euro.email'),
(5, 3, 'Tavernian', 'Jean', '01 01 02 02 04', 'jeanjean@1984.email'),
(6, 2, 'Sanchez', 'Marco', '09 00 00 01 88', 'MarcoSan@email.com'),
(7, 1, 'Poliak', 'Clara', '07 00 02 03 08', 'MissClara@email.com.fr'),
(8, 1, 'manier', 'Jacques', '07 06 05 03 04', 'manier@synths.email'),
(9, 3, 'Nurry', 'Franck', '09 00 00 01 88', 'NurrFranck@email.com.fr'),
(10, 3, 'Scatt', 'Ridley', '01 88 00 00 08', '1984@society.mail.fr'),
(11, 1, 'Dima', 'John', '01 33 00 00 00', 'dima01@email.mail'),
(12, 3, 'Mado', 'Anna', '08 21 00 00 21', 'Mado@society.com.fr'),
(13, 3, 'Johnson', 'Lea', '04 00 00 00 08', '1984@ad.join.fr'),
(14, 1, 'Dima', 'Amadou', '02 55 00 44 00', 'ama33@society.mail'),
(15, 3, 'Marau', 'Myriam', '09 00 00 00 20', 'MYmara@monemail.com.fr'),
(16, 2, 'Steinbrick', 'William', '04 00 00 00 33', 'willstein@php.mail'),
(17, 2, 'Van', 'Jules', '01 33 33 00 00', 'julesvan@1984.mail'),
(18, 2, 'Madys', 'Ygor', '07 04 08 04 00', 'gorma@society.fr'),
(19, 1, 'Yang', 'Hanna', '08 00 04 00 04', 'yang@ad.leave.fr');

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `pwd` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  UNIQUE KEY `INDEX` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', '2eaeca08a1333bdfbb30da65efc0a3b63ea39e33aba820f8e4592558615ec9e8');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `IDSERVICE` int NOT NULL,
  `NOM` varchar(256) NOT NULL,
  PRIMARY KEY (`IDSERVICE`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`IDSERVICE`, `NOM`) VALUES
(1, 'administratif'),
(2, 'médiation'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
