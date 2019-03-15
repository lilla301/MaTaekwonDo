-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Jan 21. 11:28
-- Kiszolgáló verziója: 10.1.30-MariaDB
-- PHP verzió: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `usermanagment`
--
CREATE DATABASE IF NOT EXISTS `usermanagment` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `usermanagment`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(20) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `category`
--

INSERT INTO `category` (`id`, `name`) VALUES
(1, 'admin'),
(2, 'Nagymester'),
(3, 'Mester');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `klub`
--

CREATE TABLE `klub` (
  `ID` int(11) NOT NULL,
  `nev` varchar(200) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `klub`
--

INSERT INTO `klub` (`ID`, `nev`) VALUES
(2, 'Szövetségi Központi Edzőterem Budapest'),
(3, 'Buday SE'),
(4, 'Budapesti Sasok SE'),
(5, 'Budapesti Hurrikán TKD Club'),
(6, 'Budapesti Tigrisek SE'),
(7, 'Zen Power TKD Klub'),
(8, 'Budakeszi TKD Klub'),
(9, 'Barátság SE Battonya'),
(10, 'Békéscsabai Lakótelepi SE'),
(11, 'Csopaki Hullámtörők TKD Klub'),
(12, 'Székesfehérvári Taekwon-do Klub'),
(13, 'Balatonfüred TKD Klub'),
(14, 'Gödöllői Contact ITF Taekwon-do Sportegyesület'),
(15, 'Győri Sárkányok Hwa-Rang Taekwon-do Sportegyesület'),
(16, 'Hatvani Taekwon-do Klub'),
(17, 'Herendi Taekwon-do Egyesület'),
(18, 'Hódmezővásárhelyi TKD Klub'),
(19, 'Algyői Sportkör ITF Taekwon-do Szakosztály'),
(20, 'Taekwon-do Spirit SE Hatvan'),
(21, 'Kétegyháza TKD Klub'),
(22, 'Sasok SE Kiskunhalas'),
(23, 'Kápolnásnyék TSC Taekwon-do Szakosztály'),
(24, 'Luigi Team Érdi Taekwon-do Klub'),
(25, 'Magyarbánhegyesi Szabadidő Klub\r\nKorvin Taekwon-do Szakosztálya'),
(26, 'Spárta Taekwondo Medgyesegyháza SE'),
(27, 'Mezőhegyes Platán SE'),
(28, 'Mongúzok Taekwon-do SE, Balatonalmádi'),
(29, 'Monor SE TKD Szakosztály'),
(30, 'Pécsi Sasok Taekwon-do Klub'),
(31, 'Pétfürdői Diáksport Egyesület\r\nPéti Sólymok TKD Szakosztály'),
(32, 'Pile SC'),
(33, 'Szeged, Club Dynamic SC'),
(34, 'Szigeti Delfinek TKD SE'),
(35, 'Makó TKD Klub'),
(36, 'Tápiómenti TKD SE'),
(37, 'Telki Taekwon-do Sportegyesület'),
(38, 'TÉT SE'),
(39, 'Várpalotai TKD Klub'),
(40, 'Vasadi Kobrák TKD Klub'),
(41, 'Veszprémi Taekwon-Do SE Felnőtt Szakosztály'),
(42, 'Veszprémi Taekwon-Do SE / Rózsa / Gyermek szakosztály'),
(43, 'Padányi Taekwon-Do klub Veszprém'),
(44, 'Darazsak Taekwon-do Klub'),
(45, 'Viharsarok Budo SE');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ovfokozatok`
--

CREATE TABLE `ovfokozatok` (
  `id` int(11) NOT NULL,
  `fokozat` varchar(200) COLLATE utf8_hungarian_ci NOT NULL,
  `nev` varchar(200) COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `ovfokozatok`
--

INSERT INTO `ovfokozatok` (`id`, `fokozat`, `nev`) VALUES
(1, '10. gup', 'Fehér öv'),
(2, '9. gup', 'Fehér öv sárga csík'),
(3, '8. gup', 'Sárga öv'),
(4, '7. gup', 'Sárga öv zöld csík'),
(5, '6. gup', 'Zöld öv'),
(6, '5. gup', 'Zöld öv kék csík'),
(7, '4. gup', 'Kék öv'),
(8, '3. gup', 'Kék öv piros csík'),
(9, '2. gup', 'Piros öv'),
(10, '1. gup', 'Piros öv fekete csík'),
(11, '1. dan', 'Fekete öv'),
(12, '2. dan', 'Fekete öv'),
(13, '3. dan', 'Fekete öv'),
(14, '4. dan', 'Fekete öv'),
(15, '5. dan', 'Fekete öv'),
(16, '6. dan', 'Fekete öv'),
(17, '7. dan', 'Fekete öv'),
(18, '8. dan', 'Fekete öv'),
(19, '9. dan', 'Fekete öv');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `categoryID` int(11) NOT NULL,
  `szemelyID` int(11) NOT NULL,
  `felhasznalonev` varchar(20) COLLATE utf8_hungarian_ci NOT NULL,
  `jelszo` varchar(20) COLLATE utf8_hungarian_ci DEFAULT NULL,
  `vezeteknev` varchar(60) COLLATE utf8_hungarian_ci NOT NULL,
  `keresztnev` varchar(60) COLLATE utf8_hungarian_ci NOT NULL,
  `email` varchar(90) COLLATE utf8_hungarian_ci NOT NULL,
  `neme` tinyint(1) NOT NULL,
  `klub` int(11) NOT NULL,
  `ovfokozat` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`categoryID`, `szemelyID`, `felhasznalonev`, `jelszo`, `vezeteknev`, `keresztnev`, `email`, `neme`, `klub`, `ovfokozat`) VALUES
(1, 1, 'admin', 'admin', '', '', '', 0, 2, 1),
(3, 3, 'Lilla301', 'lilla', 'Tari', 'Lilla', 'tari.lilla2@gmail.com', 0, 3, 1),
(3, 4, 'as', 'sa', 'as', 'sa', 'as', 0, 2, 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `klub`
--
ALTER TABLE `klub`
  ADD PRIMARY KEY (`ID`);

--
-- A tábla indexei `ovfokozatok`
--
ALTER TABLE `ovfokozatok`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`szemelyID`),
  ADD KEY `klub` (`klub`),
  ADD KEY `ovfokozat` (`ovfokozat`),
  ADD KEY `categoryID` (`categoryID`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `klub`
--
ALTER TABLE `klub`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=46;

--
-- AUTO_INCREMENT a táblához `ovfokozatok`
--
ALTER TABLE `ovfokozatok`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `szemelyID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`ovfokozat`) REFERENCES `ovfokozatok` (`id`),
  ADD CONSTRAINT `user_ibfk_2` FOREIGN KEY (`categoryID`) REFERENCES `category` (`id`),
  ADD CONSTRAINT `user_ibfk_3` FOREIGN KEY (`klub`) REFERENCES `klub` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
