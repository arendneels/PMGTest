-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Gegenereerd op: 19 jul 2018 om 14:54
-- Serverversie: 5.7.19
-- PHP-versie: 7.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pmg_db`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `colors`
--

DROP TABLE IF EXISTS `colors`;
CREATE TABLE IF NOT EXISTS `colors` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hex` varchar(7) NOT NULL,
  `name` varchar(25) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `colors`
--

INSERT INTO `colors` (`id`, `hex`, `name`) VALUES
(1, '#d71a21', 'red'),
(2, '#94bb2e', 'green'),
(3, '#ea6808', 'orange'),
(4, '#0072bb', 'blue'),
(5, '#ffc20f', 'yellow');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `tiles`
--

DROP TABLE IF EXISTS `tiles`;
CREATE TABLE IF NOT EXISTS `tiles` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `color_id` int(11) NOT NULL,
  `new_order` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `tiles`
--

INSERT INTO `tiles` (`id`, `color_id`, `new_order`) VALUES
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 1, 6),
(7, 2, 7),
(8, 3, 8),
(9, 4, 9),
(10, 3, 10),
(11, 5, 11),
(12, 1, 12);

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `tilestranslations`
--

DROP TABLE IF EXISTS `tilestranslations`;
CREATE TABLE IF NOT EXISTS `tilestranslations` (
  `tile_id` int(11) NOT NULL,
  `lang` varchar(6) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Gegevens worden geëxporteerd voor tabel `tilestranslations`
--

INSERT INTO `tilestranslations` (`tile_id`, `lang`, `name`) VALUES
(1, 'nl', 'GRATIS BOUWPLAN'),
(1, 'en', 'FREE BUILDING PLAN'),
(1, 'fr', 'PLAN DE BATIMENT GRATUIT'),
(2, 'nl', 'GRATIS ONLINE MAGAZINE'),
(2, 'en', 'FREE ONLINE MAGAZINE'),
(2, 'fr', 'MAGAZINE EN LIGNE GRATUIT'),
(3, 'nl', 'DOBBIT WEBSHOP'),
(3, 'en', 'DOBBIT WEBSHOP'),
(3, 'fr', 'DOBBIT WEBSHOP'),
(4, 'nl', 'VOOR ABONNEES'),
(4, 'en', 'FOR SUBSCRIBERS'),
(4, 'fr', 'POUR LES ABONNÉS'),
(5, 'nl', 'BEKIJK VIDEO\'S'),
(5, 'en', 'WATCH VIDEOS'),
(5, 'fr', 'REGARDER DES VIDÉOS'),
(6, 'nl', 'JOUW KLUS OP DOBBIT TV?'),
(6, 'en', 'YOUR JOB ON DOBBIT TV?'),
(6, 'fr', 'VOTRE JOB SUR DOBBIT TV?'),
(7, 'nl', 'GEZIEN OP DOBBIT TV'),
(7, 'en', 'SEEN ON DOBBIT TV'),
(7, 'fr', 'VU SUR DOBBIT TV'),
(8, 'nl', 'Dobbit BESTE DEALS'),
(8, 'en', 'Dobbit BEST DEALS'),
(8, 'fr', 'Dobbit MEILLEURES OFFRES'),
(10, 'nl', 'HERBEKIJK Diy on wheels'),
(9, 'fr', 'RE-REGARDER la maison d\'auto-construction'),
(9, 'en', 'RE-WATCH the self-build house'),
(9, 'nl', 'HERBEKIJK het zelfbouwhuis'),
(10, 'en', 'RE-WATCH Diy on wheels'),
(10, 'fr', 'RE-REGARDER Diy on wheels'),
(11, 'nl', 'WINNAARS WEDSTRIJDEN'),
(11, 'en', 'COMPETITION WINNERS'),
(11, 'fr', 'GAGNANTS DU CONCOURS'),
(12, 'nl', '8 MEEST INNOVATIEVE DHZ-PRODUCTEN'),
(12, 'en', '8 MOST INNOVATIVE DIY PRODUCTS'),
(12, 'fr', '8 PRODUITS DE BRICOLAGE LES PLUS INNOVANTS');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
