-- phpMyAdmin SQL Dump
-- version 4.8.2
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2019. Már 13. 12:55
-- Kiszolgáló verziója: 10.1.34-MariaDB
-- PHP verzió: 7.2.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `nagykonyv`
--
CREATE DATABASE IF NOT EXISTS `nagykonyv` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `nagykonyv`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szoveg`
--

CREATE TABLE `szoveg` (
  `id` int(11) NOT NULL,
  `cim` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `szoveg` text COLLATE utf8_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `szoveg`
--

INSERT INTO `szoveg` (`id`, `cim`, `szoveg`) VALUES
(1, 'Ajánló', 'Megelégedés és öröm számomra, hogy Európában elsőként Magyarország Taekwon-dosainak dedikálhatok egy ilyen látványos formában készült, képekkel gazdagon illusztrált könyvet. Ebben a témakörben ez ma, tartalmát tekintve, különlegességnek számít!\r\nEgykori tanítványom: Harmat László főinstruktor, a Magyar Taekwon-do megalapítója és vezetője - dicséretet érdemlően - kimagaslóan látta el feladatát. Nemcsak mesterként, hanem íróként és szerkesztőként is nagy szakmai hozzáértésről tett tanúbizonyságot. Ugyancsak elismerés illeti a fotókon közreműködő sportolókat teljesítményükért.\r\nE könyv létrehozásával és megjelentetésével a  magyar fiatalok széles tömegei is megismerhetik, megkedvelhetik Korea különleges harcművészetét; idővel pedig maguk is bekapcsolódhatnak a közös edzésmunkába. A szakkönyv nyomán nemcsak a Taekwon-do tömegbázisa bővül majd, hanem a technikai színvonal folyamatos emelkedési is várható, mely a legfontosabb lépés a nemzetközi versenysikerek felé.\r\nTanításaimnak megfelelően az írásos rész gondosan, minden apróságra kiterjedően informálja az olvasót, a képek pedig hűen és igényesen tolmácsolják a gyakorlatokat az egyszerűbbektől a legnehezebbekig. Az anyag kuriózuma, hogy olyan komoly elméleti részeket tárgyal, továbbá olyan technikai specialitásokat mutat be, amelyek ez ideig még sehol, egyetlen szakanyagban sem láttak napvilágot. A szerkesztés munkáját dicséri, hogy mindenütt felismerhetők a feszes logikai sorrendek és összefüggések.\r\nA lektoráláskor úgy találtam, hogy a bemutatott technikákat az igényesség, a pontosság és közérthetőség jellemzi. Szakmai szempontból e munka fő értékeit éppen ezekben a tényezőkben látom.\r\nA könyv nagy segítséget fog nyújtani minden Taekwon-dosnak: kezdőknél az alapok elsajátításában, fejlesztésében és helyes értelmezésében; haladóknál pedig új technikák tanulásában, a mozdulatok folyamatos csiszolásában és küzdőtechnikájukba való beépülésében játszhat döntő szerepet. Instruktoroknak is hasznos útmutatással szolgál majd, mind elméleti, mind gyakorlati oktatáshoz. Mindenekelőtt azonban a helyes úton járva népszerűsíti és hozza sokak számára elérhető közelségbe ezt a nagyszerű művészetet.\r\nAjánlom tehát e könyvet minden mesternek és tanítványnak, érdeklődő kívülállónak és leendő Taekwon-dosnak egyaránt. Meggyőződésem, hogy ez a színvonalas szakanyag előbbre viszi tudásukat és szellemüket a már megtett úton.\r\n\r\nPhenjan, Korea 1984							Choi Hong Hi 9.Dan\r\n								alapító nagymester,\r\n								a világszövetség elnöke');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `szoveg`
--
ALTER TABLE `szoveg`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `szoveg`
--
ALTER TABLE `szoveg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
