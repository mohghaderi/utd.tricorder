using NodaTime;
using NodaTime.TimeZones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    /// <summary>
    /// Class for managing DateTime based on Unix Epoch
    /// </summary>
    public class DateTimeEpoch
    {
        public static DateTime UnixMinDate = new DateTime(1970, 1, 1);
        public static DateTime UnixMaxDate = new DateTime(2030, 1, 1); // TODO: Find out last unix possible date time
        public const int UnixMinDateSecondsEpoch = 0;
        public const short DefaultTimeZoneID = 381; // America/Chicago'

        /// <summary>
        /// number of seconds in one day This is only to remove this magic number from the source files
        /// </summary>
        public const int OneDaySeconds = 86400;

        /// <summary>
        /// Converts the date to seconds epoch.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static int ConvertDateToSecondsEpoch(DateTime startDateTime)
        {
            return Convert.ToInt32((startDateTime - UnixMinDate).TotalSeconds);
        }

        /// <summary>
        /// Converts the seconds epoch to date time.
        /// </summary>
        /// <param name="dateSeconds_Epoch">The date seconds_ epoch.</param>
        /// <returns></returns>
        public static DateTime ConvertSecondsEpochToDateTime(int dateSeconds_Epoch)
        {
            return UnixMinDate.AddSeconds(dateSeconds_Epoch);
        }

        /// <summary>
        /// Gets the UTC now epoch.
        /// </summary>
        /// <returns></returns>
        public static int GetUtcNowEpoch()
        {
            return ConvertDateToSecondsEpoch(DateTime.UtcNow);
        }


        /// <summary>
        /// Converts the UTC time to local time.
        /// </summary>
        /// <param name="utcTime">The UTC time.</param>
        /// <param name="tzID">The tz identifier. It is the same as IANA TZdb in database</param>
        /// <returns></returns>
        public static DateTime ConvertUnixEpochToLocalTime(int secondsSinceUnixEpoch, string tzID)
        {
            Instant time = Instant.FromSecondsSinceUnixEpoch(secondsSinceUnixEpoch);
            var dateTimeZone = GetTimeZoneProvider()[tzID];
            ZonedDateTime zonedDateTime = time.InZone(dateTimeZone);
            return zonedDateTime.ToDateTimeUnspecified();
        }

        /// <summary>
        /// Converts the UTC time to local time.
        /// </summary>
        /// <param name="utcTime">The UTC time.</param>
        /// <param name="tzID">The tz identifier. it is the same as dbo.WorldTimeZone table in database</param>
        /// <returns></returns>
        public static DateTime ConvertUtcTimeToLocalTime(DateTime utcTime, int worldTimeZoneID)
        {
            int secondsSinceUnixEpoch = ConvertDateToSecondsEpoch(utcTime);
            return ConvertUnixEpochToLocalTime(secondsSinceUnixEpoch, worldTimeZoneID);
        }


        /// <summary>
        /// Converts the UTC time to local time.
        /// </summary>
        /// <param name="secondsSinceUnixEpoch">The seconds since unix epoch.</param>
        /// <param name="worldTimeZoneID">The world time zone identifier.</param>
        /// <returns></returns>
        public static DateTime ConvertUnixEpochToLocalTime(int secondsSinceUnixEpoch, int worldTimeZoneID)
        {
            string tzID = GetTimeZoneDic()[worldTimeZoneID];
            return ConvertUnixEpochToLocalTime(secondsSinceUnixEpoch, tzID);
        }


        private static object lockObject = new object();
        private static IDateTimeZoneProvider provider;

        /// <summary>
        /// Gets the time zone provider.
        /// It reads the file form its configuration settings
        /// This is for making an updatable file outside the program source
        /// </summary>
        /// <returns></returns>
        public static IDateTimeZoneProvider GetTimeZoneProvider()
        {
            if (provider != null)
                return provider;

            lock (lockObject)
            {
                if (provider != null)
                    return provider;
                // Or use Assembly.GetManifestResourceStream for an embedded file
                string tzdbFileName = FWUtils.ConfigUtils.GetAppSettings().Localization.TzdbFile;
                string tzdbFileFullName = System.IO.Path.Combine(FWUtils.ConfigUtils.ApplicationPath, tzdbFileName);
                using (var stream = System.IO.File.OpenRead(tzdbFileFullName))
                {
                    var source = TzdbDateTimeZoneSource.FromStream(stream);
                    provider = new DateTimeZoneCache(source);
                }
            }
            return provider;
        }

        private static Dictionary<int, string> timeZoneDic = new Dictionary<int, string>();

        private static Dictionary<int, string> GetTimeZoneDic()
        {
            if (timeZoneDic.Count == 0)
            {
                timeZoneDic.Add(1, "Europe/Andorra");
                timeZoneDic.Add(2, "Asia/Dubai");
                timeZoneDic.Add(3, "Asia/Kabul");
                timeZoneDic.Add(4, "America/Antigua");
                timeZoneDic.Add(5, "America/Anguilla");
                timeZoneDic.Add(6, "Europe/Tirane");
                timeZoneDic.Add(7, "Asia/Yerevan");
                timeZoneDic.Add(8, "Africa/Luanda");
                timeZoneDic.Add(9, "Antarctica/McMurdo");
                timeZoneDic.Add(10, "Antarctica/Rothera");
                timeZoneDic.Add(11, "Antarctica/Palmer");
                timeZoneDic.Add(12, "Antarctica/Mawson");
                timeZoneDic.Add(13, "Antarctica/Davis");
                timeZoneDic.Add(14, "Antarctica/Casey");
                timeZoneDic.Add(15, "Antarctica/Vostok");
                timeZoneDic.Add(16, "Antarctica/DumontDUrville");
                timeZoneDic.Add(17, "Antarctica/Syowa");
                timeZoneDic.Add(18, "Antarctica/Troll");
                timeZoneDic.Add(19, "America/Argentina/Buenos_Aires");
                timeZoneDic.Add(20, "America/Argentina/Cordoba");
                timeZoneDic.Add(21, "America/Argentina/Salta");
                timeZoneDic.Add(22, "America/Argentina/Jujuy");
                timeZoneDic.Add(23, "America/Argentina/Tucuman");
                timeZoneDic.Add(24, "America/Argentina/Catamarca");
                timeZoneDic.Add(25, "America/Argentina/La_Rioja");
                timeZoneDic.Add(26, "America/Argentina/San_Juan");
                timeZoneDic.Add(27, "America/Argentina/Mendoza");
                timeZoneDic.Add(28, "America/Argentina/San_Luis");
                timeZoneDic.Add(29, "America/Argentina/Rio_Gallegos");
                timeZoneDic.Add(30, "America/Argentina/Ushuaia");
                timeZoneDic.Add(31, "Pacific/Pago_Pago");
                timeZoneDic.Add(32, "Europe/Vienna");
                timeZoneDic.Add(33, "Australia/Lord_Howe");
                timeZoneDic.Add(34, "Antarctica/Macquarie");
                timeZoneDic.Add(35, "Australia/Hobart");
                timeZoneDic.Add(36, "Australia/Currie");
                timeZoneDic.Add(37, "Australia/Melbourne");
                timeZoneDic.Add(38, "Australia/Sydney");
                timeZoneDic.Add(39, "Australia/Broken_Hill");
                timeZoneDic.Add(40, "Australia/Brisbane");
                timeZoneDic.Add(41, "Australia/Lindeman");
                timeZoneDic.Add(42, "Australia/Adelaide");
                timeZoneDic.Add(43, "Australia/Darwin");
                timeZoneDic.Add(44, "Australia/Perth");
                timeZoneDic.Add(45, "Australia/Eucla");
                timeZoneDic.Add(46, "America/Aruba");
                timeZoneDic.Add(47, "Europe/Mariehamn");
                timeZoneDic.Add(48, "Asia/Baku");
                timeZoneDic.Add(49, "Europe/Sarajevo");
                timeZoneDic.Add(50, "America/Barbados");
                timeZoneDic.Add(51, "Asia/Dhaka");
                timeZoneDic.Add(52, "Europe/Brussels");
                timeZoneDic.Add(53, "Africa/Ouagadougou");
                timeZoneDic.Add(54, "Europe/Sofia");
                timeZoneDic.Add(55, "Asia/Bahrain");
                timeZoneDic.Add(56, "Africa/Bujumbura");
                timeZoneDic.Add(57, "Africa/Porto-Novo");
                timeZoneDic.Add(58, "America/St_Barthelemy");
                timeZoneDic.Add(59, "Atlantic/Bermuda");
                timeZoneDic.Add(60, "Asia/Brunei");
                timeZoneDic.Add(61, "America/La_Paz");
                timeZoneDic.Add(62, "America/Kralendijk");
                timeZoneDic.Add(63, "America/Noronha");
                timeZoneDic.Add(64, "America/Belem");
                timeZoneDic.Add(65, "America/Fortaleza");
                timeZoneDic.Add(66, "America/Recife");
                timeZoneDic.Add(67, "America/Araguaina");
                timeZoneDic.Add(68, "America/Maceio");
                timeZoneDic.Add(69, "America/Bahia");
                timeZoneDic.Add(70, "America/Sao_Paulo");
                timeZoneDic.Add(71, "America/Campo_Grande");
                timeZoneDic.Add(72, "America/Cuiaba");
                timeZoneDic.Add(73, "America/Santarem");
                timeZoneDic.Add(74, "America/Porto_Velho");
                timeZoneDic.Add(75, "America/Boa_Vista");
                timeZoneDic.Add(76, "America/Manaus");
                timeZoneDic.Add(77, "America/Eirunepe");
                timeZoneDic.Add(78, "America/Rio_Branco");
                timeZoneDic.Add(79, "America/Nassau");
                timeZoneDic.Add(80, "Asia/Thimphu");
                timeZoneDic.Add(81, "Africa/Gaborone");
                timeZoneDic.Add(82, "Europe/Minsk");
                timeZoneDic.Add(83, "America/Belize");
                timeZoneDic.Add(84, "America/St_Johns");
                timeZoneDic.Add(85, "America/Halifax");
                timeZoneDic.Add(86, "America/Glace_Bay");
                timeZoneDic.Add(87, "America/Moncton");
                timeZoneDic.Add(88, "America/Goose_Bay");
                timeZoneDic.Add(89, "America/Blanc-Sablon");
                timeZoneDic.Add(90, "America/Toronto");
                timeZoneDic.Add(91, "America/Nipigon");
                timeZoneDic.Add(92, "America/Thunder_Bay");
                timeZoneDic.Add(93, "America/Iqaluit");
                timeZoneDic.Add(94, "America/Pangnirtung");
                timeZoneDic.Add(95, "America/Resolute");
                timeZoneDic.Add(96, "America/Atikokan");
                timeZoneDic.Add(97, "America/Rankin_Inlet");
                timeZoneDic.Add(98, "America/Winnipeg");
                timeZoneDic.Add(99, "America/Rainy_River");
                timeZoneDic.Add(100, "America/Regina");
                timeZoneDic.Add(101, "America/Swift_Current");
                timeZoneDic.Add(102, "America/Edmonton");
                timeZoneDic.Add(103, "America/Cambridge_Bay");
                timeZoneDic.Add(104, "America/Yellowknife");
                timeZoneDic.Add(105, "America/Inuvik");
                timeZoneDic.Add(106, "America/Creston");
                timeZoneDic.Add(107, "America/Dawson_Creek");
                timeZoneDic.Add(108, "America/Vancouver");
                timeZoneDic.Add(109, "America/Whitehorse");
                timeZoneDic.Add(110, "America/Dawson");
                timeZoneDic.Add(111, "Indian/Cocos");
                timeZoneDic.Add(112, "Africa/Kinshasa");
                timeZoneDic.Add(113, "Africa/Lubumbashi");
                timeZoneDic.Add(114, "Africa/Bangui");
                timeZoneDic.Add(115, "Africa/Brazzaville");
                timeZoneDic.Add(116, "Europe/Zurich");
                timeZoneDic.Add(117, "Africa/Abidjan");
                timeZoneDic.Add(118, "Pacific/Rarotonga");
                timeZoneDic.Add(119, "America/Santiago");
                timeZoneDic.Add(120, "Pacific/Easter");
                timeZoneDic.Add(121, "Africa/Douala");
                timeZoneDic.Add(122, "Asia/Shanghai");
                timeZoneDic.Add(123, "Asia/Harbin");
                timeZoneDic.Add(124, "Asia/Chongqing");
                timeZoneDic.Add(125, "Asia/Urumqi");
                timeZoneDic.Add(126, "Asia/Kashgar");
                timeZoneDic.Add(127, "America/Bogota");
                timeZoneDic.Add(128, "America/Costa_Rica");
                timeZoneDic.Add(129, "America/Havana");
                timeZoneDic.Add(130, "Atlantic/Cape_Verde");
                timeZoneDic.Add(131, "America/Curacao");
                timeZoneDic.Add(132, "Indian/Christmas");
                timeZoneDic.Add(133, "Asia/Nicosia");
                timeZoneDic.Add(134, "Europe/Prague");
                timeZoneDic.Add(135, "Europe/Berlin");
                timeZoneDic.Add(136, "Europe/Busingen");
                timeZoneDic.Add(137, "Africa/Djibouti");
                timeZoneDic.Add(138, "Europe/Copenhagen");
                timeZoneDic.Add(139, "America/Dominica");
                timeZoneDic.Add(140, "America/Santo_Domingo");
                timeZoneDic.Add(141, "Africa/Algiers");
                timeZoneDic.Add(142, "America/Guayaquil");
                timeZoneDic.Add(143, "Pacific/Galapagos");
                timeZoneDic.Add(144, "Europe/Tallinn");
                timeZoneDic.Add(145, "Africa/Cairo");
                timeZoneDic.Add(146, "Africa/El_Aaiun");
                timeZoneDic.Add(147, "Africa/Asmara");
                timeZoneDic.Add(148, "Europe/Madrid");
                timeZoneDic.Add(149, "Africa/Ceuta");
                timeZoneDic.Add(150, "Atlantic/Canary");
                timeZoneDic.Add(151, "Africa/Addis_Ababa");
                timeZoneDic.Add(152, "Europe/Helsinki");
                timeZoneDic.Add(153, "Pacific/Fiji");
                timeZoneDic.Add(154, "Atlantic/Stanley");
                timeZoneDic.Add(155, "Pacific/Chuuk");
                timeZoneDic.Add(156, "Pacific/Pohnpei");
                timeZoneDic.Add(157, "Pacific/Kosrae");
                timeZoneDic.Add(158, "Atlantic/Faroe");
                timeZoneDic.Add(159, "Europe/Paris");
                timeZoneDic.Add(160, "Africa/Libreville");
                timeZoneDic.Add(161, "Europe/London");
                timeZoneDic.Add(162, "America/Grenada");
                timeZoneDic.Add(163, "Asia/Tbilisi");
                timeZoneDic.Add(164, "America/Cayenne");
                timeZoneDic.Add(165, "Europe/Guernsey");
                timeZoneDic.Add(166, "Africa/Accra");
                timeZoneDic.Add(167, "Europe/Gibraltar");
                timeZoneDic.Add(168, "America/Godthab");
                timeZoneDic.Add(169, "America/Danmarkshavn");
                timeZoneDic.Add(170, "America/Scoresbysund");
                timeZoneDic.Add(171, "America/Thule");
                timeZoneDic.Add(172, "Africa/Banjul");
                timeZoneDic.Add(173, "Africa/Conakry");
                timeZoneDic.Add(174, "America/Guadeloupe");
                timeZoneDic.Add(175, "Africa/Malabo");
                timeZoneDic.Add(176, "Europe/Athens");
                timeZoneDic.Add(177, "Atlantic/South_Georgia");
                timeZoneDic.Add(178, "America/Guatemala");
                timeZoneDic.Add(179, "Pacific/Guam");
                timeZoneDic.Add(180, "Africa/Bissau");
                timeZoneDic.Add(181, "America/Guyana");
                timeZoneDic.Add(182, "Asia/Hong_Kong");
                timeZoneDic.Add(183, "America/Tegucigalpa");
                timeZoneDic.Add(184, "Europe/Zagreb");
                timeZoneDic.Add(185, "America/Port-au-Prince");
                timeZoneDic.Add(186, "Europe/Budapest");
                timeZoneDic.Add(187, "Asia/Jakarta");
                timeZoneDic.Add(188, "Asia/Pontianak");
                timeZoneDic.Add(189, "Asia/Makassar");
                timeZoneDic.Add(190, "Asia/Jayapura");
                timeZoneDic.Add(191, "Europe/Dublin");
                timeZoneDic.Add(192, "Asia/Jerusalem");
                timeZoneDic.Add(193, "Europe/Isle_of_Man");
                timeZoneDic.Add(194, "Asia/Kolkata");
                timeZoneDic.Add(195, "Indian/Chagos");
                timeZoneDic.Add(196, "Asia/Baghdad");
                timeZoneDic.Add(197, "Asia/Tehran");
                timeZoneDic.Add(198, "Atlantic/Reykjavik");
                timeZoneDic.Add(199, "Europe/Rome");
                timeZoneDic.Add(200, "Europe/Jersey");
                timeZoneDic.Add(201, "America/Jamaica");
                timeZoneDic.Add(202, "Asia/Amman");
                timeZoneDic.Add(203, "Asia/Tokyo");
                timeZoneDic.Add(204, "Africa/Nairobi");
                timeZoneDic.Add(205, "Asia/Bishkek");
                timeZoneDic.Add(206, "Asia/Phnom_Penh");
                timeZoneDic.Add(207, "Pacific/Tarawa");
                timeZoneDic.Add(208, "Pacific/Enderbury");
                timeZoneDic.Add(209, "Pacific/Kiritimati");
                timeZoneDic.Add(210, "Indian/Comoro");
                timeZoneDic.Add(211, "America/St_Kitts");
                timeZoneDic.Add(212, "Asia/Pyongyang");
                timeZoneDic.Add(213, "Asia/Seoul");
                timeZoneDic.Add(214, "Asia/Kuwait");
                timeZoneDic.Add(215, "America/Cayman");
                timeZoneDic.Add(216, "Asia/Almaty");
                timeZoneDic.Add(217, "Asia/Qyzylorda");
                timeZoneDic.Add(218, "Asia/Aqtobe");
                timeZoneDic.Add(219, "Asia/Aqtau");
                timeZoneDic.Add(220, "Asia/Oral");
                timeZoneDic.Add(221, "Asia/Vientiane");
                timeZoneDic.Add(222, "Asia/Beirut");
                timeZoneDic.Add(223, "America/St_Lucia");
                timeZoneDic.Add(224, "Europe/Vaduz");
                timeZoneDic.Add(225, "Asia/Colombo");
                timeZoneDic.Add(226, "Africa/Monrovia");
                timeZoneDic.Add(227, "Africa/Maseru");
                timeZoneDic.Add(228, "Europe/Vilnius");
                timeZoneDic.Add(229, "Europe/Luxembourg");
                timeZoneDic.Add(230, "Europe/Riga");
                timeZoneDic.Add(231, "Africa/Tripoli");
                timeZoneDic.Add(232, "Africa/Casablanca");
                timeZoneDic.Add(233, "Europe/Monaco");
                timeZoneDic.Add(234, "Europe/Chisinau");
                timeZoneDic.Add(235, "Europe/Podgorica");
                timeZoneDic.Add(236, "America/Marigot");
                timeZoneDic.Add(237, "Indian/Antananarivo");
                timeZoneDic.Add(238, "Pacific/Majuro");
                timeZoneDic.Add(239, "Pacific/Kwajalein");
                timeZoneDic.Add(240, "Europe/Skopje");
                timeZoneDic.Add(241, "Africa/Bamako");
                timeZoneDic.Add(242, "Asia/Rangoon");
                timeZoneDic.Add(243, "Asia/Ulaanbaatar");
                timeZoneDic.Add(244, "Asia/Hovd");
                timeZoneDic.Add(245, "Asia/Choibalsan");
                timeZoneDic.Add(246, "Asia/Macau");
                timeZoneDic.Add(247, "Pacific/Saipan");
                timeZoneDic.Add(248, "America/Martinique");
                timeZoneDic.Add(249, "Africa/Nouakchott");
                timeZoneDic.Add(250, "America/Montserrat");
                timeZoneDic.Add(251, "Europe/Malta");
                timeZoneDic.Add(252, "Indian/Mauritius");
                timeZoneDic.Add(253, "Indian/Maldives");
                timeZoneDic.Add(254, "Africa/Blantyre");
                timeZoneDic.Add(255, "America/Mexico_City");
                timeZoneDic.Add(256, "America/Cancun");
                timeZoneDic.Add(257, "America/Merida");
                timeZoneDic.Add(258, "America/Monterrey");
                timeZoneDic.Add(259, "America/Matamoros");
                timeZoneDic.Add(260, "America/Mazatlan");
                timeZoneDic.Add(261, "America/Chihuahua");
                timeZoneDic.Add(262, "America/Ojinaga");
                timeZoneDic.Add(263, "America/Hermosillo");
                timeZoneDic.Add(264, "America/Tijuana");
                timeZoneDic.Add(265, "America/Santa_Isabel");
                timeZoneDic.Add(266, "America/Bahia_Banderas");
                timeZoneDic.Add(267, "Asia/Kuala_Lumpur");
                timeZoneDic.Add(268, "Asia/Kuching");
                timeZoneDic.Add(269, "Africa/Maputo");
                timeZoneDic.Add(270, "Africa/Windhoek");
                timeZoneDic.Add(271, "Pacific/Noumea");
                timeZoneDic.Add(272, "Africa/Niamey");
                timeZoneDic.Add(273, "Pacific/Norfolk");
                timeZoneDic.Add(274, "Africa/Lagos");
                timeZoneDic.Add(275, "America/Managua");
                timeZoneDic.Add(276, "Europe/Amsterdam");
                timeZoneDic.Add(277, "Europe/Oslo");
                timeZoneDic.Add(278, "Asia/Kathmandu");
                timeZoneDic.Add(279, "Pacific/Nauru");
                timeZoneDic.Add(280, "Pacific/Niue");
                timeZoneDic.Add(281, "Pacific/Auckland");
                timeZoneDic.Add(282, "Pacific/Chatham");
                timeZoneDic.Add(283, "Asia/Muscat");
                timeZoneDic.Add(284, "America/Panama");
                timeZoneDic.Add(285, "America/Lima");
                timeZoneDic.Add(286, "Pacific/Tahiti");
                timeZoneDic.Add(287, "Pacific/Marquesas");
                timeZoneDic.Add(288, "Pacific/Gambier");
                timeZoneDic.Add(289, "Pacific/Port_Moresby");
                timeZoneDic.Add(290, "Asia/Manila");
                timeZoneDic.Add(291, "Asia/Karachi");
                timeZoneDic.Add(292, "Europe/Warsaw");
                timeZoneDic.Add(293, "America/Miquelon");
                timeZoneDic.Add(294, "Pacific/Pitcairn");
                timeZoneDic.Add(295, "America/Puerto_Rico");
                timeZoneDic.Add(296, "Asia/Gaza");
                timeZoneDic.Add(297, "Asia/Hebron");
                timeZoneDic.Add(298, "Europe/Lisbon");
                timeZoneDic.Add(299, "Atlantic/Madeira");
                timeZoneDic.Add(300, "Atlantic/Azores");
                timeZoneDic.Add(301, "Pacific/Palau");
                timeZoneDic.Add(302, "America/Asuncion");
                timeZoneDic.Add(303, "Asia/Qatar");
                timeZoneDic.Add(304, "Indian/Reunion");
                timeZoneDic.Add(305, "Europe/Bucharest");
                timeZoneDic.Add(306, "Europe/Belgrade");
                timeZoneDic.Add(307, "Europe/Kaliningrad");
                timeZoneDic.Add(308, "Europe/Moscow");
                timeZoneDic.Add(309, "Europe/Volgograd");
                timeZoneDic.Add(310, "Europe/Samara");
                timeZoneDic.Add(311, "Europe/Simferopol");
                timeZoneDic.Add(312, "Asia/Yekaterinburg");
                timeZoneDic.Add(313, "Asia/Omsk");
                timeZoneDic.Add(314, "Asia/Novosibirsk");
                timeZoneDic.Add(315, "Asia/Novokuznetsk");
                timeZoneDic.Add(316, "Asia/Krasnoyarsk");
                timeZoneDic.Add(317, "Asia/Irkutsk");
                timeZoneDic.Add(318, "Asia/Yakutsk");
                timeZoneDic.Add(319, "Asia/Khandyga");
                timeZoneDic.Add(320, "Asia/Vladivostok");
                timeZoneDic.Add(321, "Asia/Sakhalin");
                timeZoneDic.Add(322, "Asia/Ust-Nera");
                timeZoneDic.Add(323, "Asia/Magadan");
                timeZoneDic.Add(324, "Asia/Kamchatka");
                timeZoneDic.Add(325, "Asia/Anadyr");
                timeZoneDic.Add(326, "Africa/Kigali");
                timeZoneDic.Add(327, "Asia/Riyadh");
                timeZoneDic.Add(328, "Pacific/Guadalcanal");
                timeZoneDic.Add(329, "Indian/Mahe");
                timeZoneDic.Add(330, "Africa/Khartoum");
                timeZoneDic.Add(331, "Europe/Stockholm");
                timeZoneDic.Add(332, "Asia/Singapore");
                timeZoneDic.Add(333, "Atlantic/St_Helena");
                timeZoneDic.Add(334, "Europe/Ljubljana");
                timeZoneDic.Add(335, "Arctic/Longyearbyen");
                timeZoneDic.Add(336, "Europe/Bratislava");
                timeZoneDic.Add(337, "Africa/Freetown");
                timeZoneDic.Add(338, "Europe/San_Marino");
                timeZoneDic.Add(339, "Africa/Dakar");
                timeZoneDic.Add(340, "Africa/Mogadishu");
                timeZoneDic.Add(341, "America/Paramaribo");
                timeZoneDic.Add(342, "Africa/Juba");
                timeZoneDic.Add(343, "Africa/Sao_Tome");
                timeZoneDic.Add(344, "America/El_Salvador");
                timeZoneDic.Add(345, "America/Lower_Princes");
                timeZoneDic.Add(346, "Asia/Damascus");
                timeZoneDic.Add(347, "Africa/Mbabane");
                timeZoneDic.Add(348, "America/Grand_Turk");
                timeZoneDic.Add(349, "Africa/Ndjamena");
                timeZoneDic.Add(350, "Indian/Kerguelen");
                timeZoneDic.Add(351, "Africa/Lome");
                timeZoneDic.Add(352, "Asia/Bangkok");
                timeZoneDic.Add(353, "Asia/Dushanbe");
                timeZoneDic.Add(354, "Pacific/Fakaofo");
                timeZoneDic.Add(355, "Asia/Dili");
                timeZoneDic.Add(356, "Asia/Ashgabat");
                timeZoneDic.Add(357, "Africa/Tunis");
                timeZoneDic.Add(358, "Pacific/Tongatapu");
                timeZoneDic.Add(359, "Europe/Istanbul");
                timeZoneDic.Add(360, "America/Port_of_Spain");
                timeZoneDic.Add(361, "Pacific/Funafuti");
                timeZoneDic.Add(362, "Asia/Taipei");
                timeZoneDic.Add(363, "Africa/Dar_es_Salaam");
                timeZoneDic.Add(364, "Europe/Kiev");
                timeZoneDic.Add(365, "Europe/Uzhgorod");
                timeZoneDic.Add(366, "Europe/Zaporozhye");
                timeZoneDic.Add(367, "Africa/Kampala");
                timeZoneDic.Add(368, "Pacific/Johnston");
                timeZoneDic.Add(369, "Pacific/Midway");
                timeZoneDic.Add(370, "Pacific/Wake");
                timeZoneDic.Add(371, "America/New_York");
                timeZoneDic.Add(372, "America/Detroit");
                timeZoneDic.Add(373, "America/Kentucky/Louisville");
                timeZoneDic.Add(374, "America/Kentucky/Monticello");
                timeZoneDic.Add(375, "America/Indiana/Indianapolis");
                timeZoneDic.Add(376, "America/Indiana/Vincennes");
                timeZoneDic.Add(377, "America/Indiana/Winamac");
                timeZoneDic.Add(378, "America/Indiana/Marengo");
                timeZoneDic.Add(379, "America/Indiana/Petersburg");
                timeZoneDic.Add(380, "America/Indiana/Vevay");
                timeZoneDic.Add(381, "America/Chicago");
                timeZoneDic.Add(382, "America/Indiana/Tell_City");
                timeZoneDic.Add(383, "America/Indiana/Knox");
                timeZoneDic.Add(384, "America/Menominee");
                timeZoneDic.Add(385, "America/North_Dakota/Center");
                timeZoneDic.Add(386, "America/North_Dakota/New_Salem");
                timeZoneDic.Add(387, "America/North_Dakota/Beulah");
                timeZoneDic.Add(388, "America/Denver");
                timeZoneDic.Add(389, "America/Boise");
                timeZoneDic.Add(390, "America/Phoenix");
                timeZoneDic.Add(391, "America/Los_Angeles");
                timeZoneDic.Add(392, "America/Anchorage");
                timeZoneDic.Add(393, "America/Juneau");
                timeZoneDic.Add(394, "America/Sitka");
                timeZoneDic.Add(395, "America/Yakutat");
                timeZoneDic.Add(396, "America/Nome");
                timeZoneDic.Add(397, "America/Adak");
                timeZoneDic.Add(398, "America/Metlakatla");
                timeZoneDic.Add(399, "Pacific/Honolulu");
                timeZoneDic.Add(400, "America/Montevideo");
                timeZoneDic.Add(401, "Asia/Samarkand");
                timeZoneDic.Add(402, "Asia/Tashkent");
                timeZoneDic.Add(403, "Europe/Vatican");
                timeZoneDic.Add(404, "America/St_Vincent");
                timeZoneDic.Add(405, "America/Caracas");
                timeZoneDic.Add(406, "America/Tortola");
                timeZoneDic.Add(407, "America/St_Thomas");
                timeZoneDic.Add(408, "Asia/Ho_Chi_Minh");
                timeZoneDic.Add(409, "Pacific/Efate");
                timeZoneDic.Add(410, "Pacific/Wallis");
                timeZoneDic.Add(411, "Pacific/Apia");
                timeZoneDic.Add(412, "Asia/Aden");
                timeZoneDic.Add(413, "Indian/Mayotte");
                timeZoneDic.Add(414, "Africa/Johannesburg");
                timeZoneDic.Add(415, "Africa/Lusaka");
                timeZoneDic.Add(416, "Africa/Harare");
            }
            return timeZoneDic;
        }

    }
}
