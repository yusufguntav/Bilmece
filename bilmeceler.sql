-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 05 May 2022, 18:11:18
-- Sunucu sürümü: 10.4.24-MariaDB
-- PHP Sürümü: 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `bilmeceler`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `bilmece_ve_cevap`
--

CREATE TABLE `bilmece_ve_cevap` (
  `BilmeceNumara` int(11) NOT NULL,
  `Bilmece` varchar(200) DEFAULT NULL,
  `Cevap` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `bilmece_ve_cevap`
--

INSERT INTO `bilmece_ve_cevap` (`BilmeceNumara`, `Bilmece`, `Cevap`) VALUES
(1, 'Herkesin önünde şapka çıkarttığı kişi kimdir?', 'Berber'),
(2, 'İncecik beli, elimin eli.', 'Çatal'),
(3, 'Duvara çarpan araba ne yapar?', 'Durur'),
(4, 'İçinde bir akrep var, zarar vermeden dolanır.', 'Saat'),
(5, 'Elsiz ayaksız kapı açarım.', 'Anahtar'),
(6, 'Ne yersen orucun bozulmaz?', 'Dayak'),
(7, 'Kolu var bacağı yok, dikdörtgeni vardır, karesi yok.', 'Kapı'),
(8, 'Altı canlı üstü cansız', 'Kaplumbağa'),
(9, 'İz eder dizi dizi, alır gezdirir bizi.', 'Ayaklarımız'),
(10, 'Hangi macunun tadı güzeldir?', 'Lahmacun'),
(11, 'Zilim var ama kapım yok.', 'Telefon'),
(12, 'Yazları giyinir, kışları soyunur.', 'Ağaç'),
(13, 'Bir sihirli fenerim, kibritsiz de yanarım.', 'Ampul'),
(14, 'Ağzı vardır konuşmaz, yatağı vardır ama hiç uyumaz.', 'Akarsu'),
(15, 'Yer altında turuncu minare.', 'Havuç'),
(16, 'Bakınca görünürsün, kaçarsan silinirsin.', 'Ayna'),
(17, 'Servis edilse de yenemeyen şey nedir?', 'Tenis topu'),
(18, 'Ben iki özleyenin arasında dururum. Onları istedikleri yerde konuştururum.', 'Cep telefonu'),
(19, 'Şehirler, köyler gezerim ama bir adım bile hareket etmem. Ben neyim?', 'Yol'),
(20, 'Yol kenarında bekler herkesi kontrol eder.', 'Trafik polisi'),
(21, 'Sıcağa koyma kururum, suya koyma köpürürüm.', 'Sabun'),
(22, 'Kökleri yukarı, dalları aşağı.', 'Saç'),
(23, 'Hem açanım hem de kapayan.', 'Anahtar'),
(24, 'Kirpiler nasıl uyur?', 'Diken üstünde'),
(25, 'Kıvrım kıvrım kıvrılır çizgisi, ayırır kara ile denizi.', 'Harita'),
(26, 'Ay varken uçar, güneş varken kaçar.', 'Yarasa'),
(27, 'Her gün yeniden doğar, dünyaya haber yayar.', 'Gazete'),
(28, 'Herkesin gitmekten korktuğu köy hangisidir?', 'Tahtalıköy'),
(29, 'En temiz böcek hangi böcektir?', 'Hamamböceği'),
(30, 'İçini çıkartınca büyüyen şey nedir?', 'çukur'),
(31, 'Ormanda ininde yaşar, kışın uzun bir uykuya dalar.', 'Ayı'),
(32, 'Boş bir çantaya kaç kitap koyulabilir?', '1'),
(33, 'Aynı anne babanın, aynı anda doğan çocukları nasıl ikiz olamaz?', 'Üçüzdürler'),
(34, 'İnsanları yükselten şey nedir?', 'Asansör'),
(35, 'Kaynatılabilen ama yenilemeyen şey nedir?', 'Ders'),
(36, '10 tane ağır sandığı en kolay nasıl çekersiniz?', 'Fotoğraf makinesiyle'),
(37, 'Neyi kırdığında çok mutlu olursun?', 'Rekor'),
(38, 'Burnu kuyruğundan uzun olan hayvan hangisidir?', 'Fil'),
(39, 'Başkasına verdiğimiz halde bizim tutuğumuz şey nedir?', 'Söz'),
(40, 'Küçük ve sevimli ördek yavrusu ilk kez suya girerse ne olur?', 'Sırılsıklam'),
(41, 'Her şey onun içindedir.', 'Sözlük'),
(42, 'Yazın bahçede, kışın küpte.', 'Turşu'),
(43, 'Her gün beni doldururlar, sen de gelip boşaltırsın. Ben neyim?', 'Posta kutusu'),
(44, 'Neyin kanatları yoktur ama başına konabilir?', 'Talih kuşunun'),
(45, 'Kurudukça daha çok ıslatılan şey nedir?', 'Havlu'),
(46, '29 harf içeren ama sadece 3 hecede söylenen kelime nedir?', 'Alfabe'),
(47, 'Hangi bebek hiçbir zaman ağlamaz?', 'Oyuncak bebek'),
(48, 'Ne versem yer, su verirsem ölür.', 'Ateş'),
(49, 'Başta sert olan ama sonra yumuşayan ve sürekli sürekli içine hava verdiğin şey nedir?', 'Sakız'),
(50, 'Çiğnenen ama yutulmayan şey nedir?', 'Kurallar'),
(51, 'Kullandıkça gelişen şey nedir?', 'Beyin'),
(52, 'Başta uzun olan, ama zaman geçtikçe kısalan şey nedir?', 'Mum'),
(53, 'Delik dolu olan ama su tutabilen şey nedir?', 'Sünger'),
(54, 'Bir trenim var gittiği yolu dümdüz eder.', 'Ütü'),
(55, 'Bilmece bildirmece dudak üstünde kaydırmaca.', 'Ruj'),
(56, 'Daldan dala tırmanır, tüm muzlara saldırır', 'Maymun'),
(57, 'Ayağınla basınca kırt kırt eder. Güneşi görünce eriyip gider.', 'Kar'),
(58, 'İp bağladım sopaya uçtu gitti havaya.', 'Uçurtma'),
(59, 'Bilmece bildirmece ayak altında kaydırmaca.', 'Paten'),
(60, 'Sabah akşam çalışır, hırsızlar ondan kaçışır.', 'Bekçi'),
(61, 'Hey gidi gidiver, şu gidiyi tutuver, ne tatlıca eti var, püsküllüce kuyruğu var.', 'Balık'),
(62, 'Yiyeceklerden sütü sever, diliyle yalayarak içer, miyav miyav diyerek oyun oynamak ister?', 'Kedi'),
(63, 'Ayağı var yürüyemez, dili var konuşamaz', 'Bebek'),
(64, 'Sever dağı ormanı, şişmana çıkmış adı, kışın uyuşur kanı, yazın meyve düşmanı.', 'Ayı'),
(65, 'Yağmur yağınca ne yükselir?', 'Su seviyesi');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `skor`
--

CREATE TABLE `skor` (
  `ID` int(11) NOT NULL,
  `Isim` varchar(100) DEFAULT NULL,
  `Skor` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Tablo döküm verisi `skor`
--

INSERT INTO `skor` (`ID`, `Isim`, `Skor`) VALUES
(1, 'Yusuf', 50),
(2, 'Yusuf', 100),
(3, 'Yusuf', 300),
(4, 'Sadık', 0),
(5, 'Yusuf', 100);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `bilmece_ve_cevap`
--
ALTER TABLE `bilmece_ve_cevap`
  ADD PRIMARY KEY (`BilmeceNumara`);

--
-- Tablo için indeksler `skor`
--
ALTER TABLE `skor`
  ADD PRIMARY KEY (`ID`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `bilmece_ve_cevap`
--
ALTER TABLE `bilmece_ve_cevap`
  MODIFY `BilmeceNumara` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- Tablo için AUTO_INCREMENT değeri `skor`
--
ALTER TABLE `skor`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
