using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTD.Tricorder.Common.EntityObjects
{
    public class EntityEnums
    {
        public enum UserApprovalStatusEnum
        {
            IncompleteRegistration = 0,
            WaitingForApproval = 1,
            Approved = 2,
            Rejected = 3,
            Locked = 4,
            FailedPasswordLocked = 5,
            Canceled = 6
        }

        public enum PermissionTypeEnum
        {
            Inheret = 0,
            Allow = 1,
            Deny = 2
        }

        public enum ResourceTypeEnum
        {
            Group = 1,
            Subsystem = 2,
            Menu = 3,
            Form = 4,
            Entity = 5,
            EntityAction = 6
        }

        public enum GenderTypeEnum
        {
            Male = 0,
            Female = 1
        }


        public enum RoleEnum
        {
            Patient = 1,
            Doctor = 2,
            HospitalManager = 3,
            SystemAdmin = 4
        }

        public static class RoleSEnum
        {
            public static string Patient = "Patient";
            public static string Doctor = "Doctor";
            public static string HospitalManager = "HospitalManager";
            public static string SystemAdmin = "SystemAdmin";
        }


        public enum AppLogType
        {
            User_Login = 1,
            User_Logout = 2,
            User_ResetPassword = 3,
            User_FailedLogin = 4,
            User_ResetPasswordRequest = 5,

            PayPal_ReturnURL = 100,
            PayPal_IPNURL = 101,
            PayPal_CancelURL = 102,
            PayPal_CompletePayment = 103,
            PayPal_UpdatePayKey = 104,
            PayPal_Refund = 105,

            Notify_Email = 201,
            Notify_SMS = 202,
            Notify_MobilePush = 203,

            Visit_CallPatient = 301,
            Visit_EndCall = 302
        }

        public enum VitalTypeEnum
        {
            Weight = 1,
            BodyTemperature = 2,
            Height = 3
        }

        public enum TimeSeriesTypeEnum
        {
            ECG = 1
        }

        public enum PaymentEntityEnum
        {
            Visit = 1
        }

        public enum PaymentStatusEnum
        {
            NotStarted = 0,
            PendingWithoutPayKey = 1,
            PendingWithPayKey = 2,
            Done = 3,
            Cancelled = 4,
            Refunded = 5
        }

        public enum VisitStatusEnum
        {
            Scheduled = 0,
            InWaitingRoom = 1,
            Cancelled = 2,
            EndSuccess = 3
        }

        public enum PaymentMethodEnum
        {
            Undefined = 0,
            PayPal = 1
        }

        public enum NotificationStatusEnum : byte
        {
            Pending = 0,
            Sent = 1,
            Cancelled = 2,
            Error = 3
        }


        public enum NotificationTemplateEnum
        {
            MasterTemplate = 0,
            TestNotification = 1,
            EmailVerification = 2,
            VisitRescheduled = 3,
            VisitCanceled = 4,
            DoctorQuickRegisterAPatient = 5,
            PhoneNumberVerification = 6,
            ResetPasswordRequest = 7,
            ResetPasswordChanged = 8
        }

        public enum AppEntityEnum : short
        {
            Visit = 1,
            User = 2
        }


        public enum AppEntityFileTypeEnum
        {
            // Developer Note: Change Security in AmazonUploadRequest function
            // if you add any new File type for "User" entity

            /// <summary>
            /// Test case for upload tests
            /// </summary>
            Test_Picture_Upload = 1,

            /// <summary>
            /// Profile picture of a user
            /// </summary>
            User_Profile_Picture = 1000,
            /// <summary>
            /// Medical docs for user
            /// </summary>
            User_MedicalDocuments = 1001,

            /// <summary>
            /// Attachments for each visit
            /// </summary>
            Visit_Attachments = 1002
        }

        //http://stackoverflow.com/questions/3191664/list-of-all-locales-and-their-short-codes

        public enum LanguageEnum
        {
            English = 0
        }

        //public enum USStateEnum
        //{
        //    Alabama = 1,
        //    Alaska = 2,
        //    Arizona = 3,
        //    Arkansas = 4,
        //    California = 5,
        //    Colorado = 6,
        //    Connecticut = 7,
        //    Delaware = 8,
        //    Dist_of_Columbia = 9,
        //    Florida = 10,
        //    Georgia = 11,
        //    Guam = 12,
        //    Hawaii = 13,
        //    Idaho = 14,
        //    Illinois = 15,
        //    Indiana = 16,
        //    Iowa = 17,
        //    Kansas = 18,
        //    Kentucky = 19,
        //    Louisiana = 20,
        //    Maine = 21,
        //    Maryland = 22,
        //    Massachusetts = 23,
        //    Michigan = 24,
        //    Minnesota = 25,
        //    Mississippi = 26,
        //    Missouri = 27,
        //    Montana = 28,
        //    Nebraska = 29,
        //    Nevada = 30,
        //    New_Hampshire = 31,
        //    New_Jersey = 32,
        //    New_Mexico = 33,
        //    New_York = 34,
        //    North_Carolina = 35,
        //    North_Dakota = 36,
        //    Ohio = 37,
        //    Oklahoma = 38,
        //    Oregon = 39,
        //    Pennsylvania = 40,
        //    Puerto_Rico = 41,
        //    Rhode_Island = 42,
        //    South_Carolina = 43,
        //    South_Dakota = 44,
        //    Tennessee = 45,
        //    Texas = 46,
        //    Utah = 47,
        //    Vermont = 48,
        //    Virginia = 49,
        //    Virgin_Islands = 50,
        //    Washington = 51,
        //    West_Virginia = 52,
        //    Wisconsin = 53,
        //    Wyoming = 54

        //}

        public enum MobilePushServerEnum
        {
            Unknown = 0,
            Google_GCM = 1,
            Apple_APNS = 2,
            WindowsPush = 3,
            BlackBerry_PAP = 4,
            Amazon_ADM = 5
        }


        public enum MembershipAreaEnum
        {
            Root = 0
        }

        public enum WorldTimeZoneEnum
        {
            Europe_Andorra = 1,
            Asia_Dubai = 2,
            Asia_Kabul = 3,
            America_Antigua = 4,
            America_Anguilla = 5,
            Europe_Tirane = 6,
            Asia_Yerevan = 7,
            Africa_Luanda = 8,
            Antarctica_McMurdo = 9,
            Antarctica_Rothera = 10,
            Antarctica_Palmer = 11,
            Antarctica_Mawson = 12,
            Antarctica_Davis = 13,
            Antarctica_Casey = 14,
            Antarctica_Vostok = 15,
            Antarctica_DumontDUrville = 16,
            Antarctica_Syowa = 17,
            Antarctica_Troll = 18,
            America_Argentina_Buenos_Aires = 19,
            America_Argentina_Cordoba = 20,
            America_Argentina_Salta = 21,
            America_Argentina_Jujuy = 22,
            America_Argentina_Tucuman = 23,
            America_Argentina_Catamarca = 24,
            America_Argentina_La_Rioja = 25,
            America_Argentina_San_Juan = 26,
            America_Argentina_Mendoza = 27,
            America_Argentina_San_Luis = 28,
            America_Argentina_Rio_Gallegos = 29,
            America_Argentina_Ushuaia = 30,
            Pacific_Pago_Pago = 31,
            Europe_Vienna = 32,
            Australia_Lord_Howe = 33,
            Antarctica_Macquarie = 34,
            Australia_Hobart = 35,
            Australia_Currie = 36,
            Australia_Melbourne = 37,
            Australia_Sydney = 38,
            Australia_Broken_Hill = 39,
            Australia_Brisbane = 40,
            Australia_Lindeman = 41,
            Australia_Adelaide = 42,
            Australia_Darwin = 43,
            Australia_Perth = 44,
            Australia_Eucla = 45,
            America_Aruba = 46,
            Europe_Mariehamn = 47,
            Asia_Baku = 48,
            Europe_Sarajevo = 49,
            America_Barbados = 50,
            Asia_Dhaka = 51,
            Europe_Brussels = 52,
            Africa_Ouagadougou = 53,
            Europe_Sofia = 54,
            Asia_Bahrain = 55,
            Africa_Bujumbura = 56,
            Africa_Porto_Novo = 57,
            America_St_Barthelemy = 58,
            Atlantic_Bermuda = 59,
            Asia_Brunei = 60,
            America_La_Paz = 61,
            America_Kralendijk = 62,
            America_Noronha = 63,
            America_Belem = 64,
            America_Fortaleza = 65,
            America_Recife = 66,
            America_Araguaina = 67,
            America_Maceio = 68,
            America_Bahia = 69,
            America_Sao_Paulo = 70,
            America_Campo_Grande = 71,
            America_Cuiaba = 72,
            America_Santarem = 73,
            America_Porto_Velho = 74,
            America_Boa_Vista = 75,
            America_Manaus = 76,
            America_Eirunepe = 77,
            America_Rio_Branco = 78,
            America_Nassau = 79,
            Asia_Thimphu = 80,
            Africa_Gaborone = 81,
            Europe_Minsk = 82,
            America_Belize = 83,
            America_St_Johns = 84,
            America_Halifax = 85,
            America_Glace_Bay = 86,
            America_Moncton = 87,
            America_Goose_Bay = 88,
            America_Blanc_Sablon = 89,
            America_Toronto = 90,
            America_Nipigon = 91,
            America_Thunder_Bay = 92,
            America_Iqaluit = 93,
            America_Pangnirtung = 94,
            America_Resolute = 95,
            America_Atikokan = 96,
            America_Rankin_Inlet = 97,
            America_Winnipeg = 98,
            America_Rainy_River = 99,
            America_Regina = 100,
            America_Swift_Current = 101,
            America_Edmonton = 102,
            America_Cambridge_Bay = 103,
            America_Yellowknife = 104,
            America_Inuvik = 105,
            America_Creston = 106,
            America_Dawson_Creek = 107,
            America_Vancouver = 108,
            America_Whitehorse = 109,
            America_Dawson = 110,
            Indian_Cocos = 111,
            Africa_Kinshasa = 112,
            Africa_Lubumbashi = 113,
            Africa_Bangui = 114,
            Africa_Brazzaville = 115,
            Europe_Zurich = 116,
            Africa_Abidjan = 117,
            Pacific_Rarotonga = 118,
            America_Santiago = 119,
            Pacific_Easter = 120,
            Africa_Douala = 121,
            Asia_Shanghai = 122,
            Asia_Harbin = 123,
            Asia_Chongqing = 124,
            Asia_Urumqi = 125,
            Asia_Kashgar = 126,
            America_Bogota = 127,
            America_Costa_Rica = 128,
            America_Havana = 129,
            Atlantic_Cape_Verde = 130,
            America_Curacao = 131,
            Indian_Christmas = 132,
            Asia_Nicosia = 133,
            Europe_Prague = 134,
            Europe_Berlin = 135,
            Europe_Busingen = 136,
            Africa_Djibouti = 137,
            Europe_Copenhagen = 138,
            America_Dominica = 139,
            America_Santo_Domingo = 140,
            Africa_Algiers = 141,
            America_Guayaquil = 142,
            Pacific_Galapagos = 143,
            Europe_Tallinn = 144,
            Africa_Cairo = 145,
            Africa_El_Aaiun = 146,
            Africa_Asmara = 147,
            Europe_Madrid = 148,
            Africa_Ceuta = 149,
            Atlantic_Canary = 150,
            Africa_Addis_Ababa = 151,
            Europe_Helsinki = 152,
            Pacific_Fiji = 153,
            Atlantic_Stanley = 154,
            Pacific_Chuuk = 155,
            Pacific_Pohnpei = 156,
            Pacific_Kosrae = 157,
            Atlantic_Faroe = 158,
            Europe_Paris = 159,
            Africa_Libreville = 160,
            Europe_London = 161,
            America_Grenada = 162,
            Asia_Tbilisi = 163,
            America_Cayenne = 164,
            Europe_Guernsey = 165,
            Africa_Accra = 166,
            Europe_Gibraltar = 167,
            America_Godthab = 168,
            America_Danmarkshavn = 169,
            America_Scoresbysund = 170,
            America_Thule = 171,
            Africa_Banjul = 172,
            Africa_Conakry = 173,
            America_Guadeloupe = 174,
            Africa_Malabo = 175,
            Europe_Athens = 176,
            Atlantic_South_Georgia = 177,
            America_Guatemala = 178,
            Pacific_Guam = 179,
            Africa_Bissau = 180,
            America_Guyana = 181,
            Asia_Hong_Kong = 182,
            America_Tegucigalpa = 183,
            Europe_Zagreb = 184,
            America_Port_au_Prince = 185,
            Europe_Budapest = 186,
            Asia_Jakarta = 187,
            Asia_Pontianak = 188,
            Asia_Makassar = 189,
            Asia_Jayapura = 190,
            Europe_Dublin = 191,
            Asia_Jerusalem = 192,
            Europe_Isle_of_Man = 193,
            Asia_Kolkata = 194,
            Indian_Chagos = 195,
            Asia_Baghdad = 196,
            Asia_Tehran = 197,
            Atlantic_Reykjavik = 198,
            Europe_Rome = 199,
            Europe_Jersey = 200,
            America_Jamaica = 201,
            Asia_Amman = 202,
            Asia_Tokyo = 203,
            Africa_Nairobi = 204,
            Asia_Bishkek = 205,
            Asia_Phnom_Penh = 206,
            Pacific_Tarawa = 207,
            Pacific_Enderbury = 208,
            Pacific_Kiritimati = 209,
            Indian_Comoro = 210,
            America_St_Kitts = 211,
            Asia_Pyongyang = 212,
            Asia_Seoul = 213,
            Asia_Kuwait = 214,
            America_Cayman = 215,
            Asia_Almaty = 216,
            Asia_Qyzylorda = 217,
            Asia_Aqtobe = 218,
            Asia_Aqtau = 219,
            Asia_Oral = 220,
            Asia_Vientiane = 221,
            Asia_Beirut = 222,
            America_St_Lucia = 223,
            Europe_Vaduz = 224,
            Asia_Colombo = 225,
            Africa_Monrovia = 226,
            Africa_Maseru = 227,
            Europe_Vilnius = 228,
            Europe_Luxembourg = 229,
            Europe_Riga = 230,
            Africa_Tripoli = 231,
            Africa_Casablanca = 232,
            Europe_Monaco = 233,
            Europe_Chisinau = 234,
            Europe_Podgorica = 235,
            America_Marigot = 236,
            Indian_Antananarivo = 237,
            Pacific_Majuro = 238,
            Pacific_Kwajalein = 239,
            Europe_Skopje = 240,
            Africa_Bamako = 241,
            Asia_Rangoon = 242,
            Asia_Ulaanbaatar = 243,
            Asia_Hovd = 244,
            Asia_Choibalsan = 245,
            Asia_Macau = 246,
            Pacific_Saipan = 247,
            America_Martinique = 248,
            Africa_Nouakchott = 249,
            America_Montserrat = 250,
            Europe_Malta = 251,
            Indian_Mauritius = 252,
            Indian_Maldives = 253,
            Africa_Blantyre = 254,
            America_Mexico_City = 255,
            America_Cancun = 256,
            America_Merida = 257,
            America_Monterrey = 258,
            America_Matamoros = 259,
            America_Mazatlan = 260,
            America_Chihuahua = 261,
            America_Ojinaga = 262,
            America_Hermosillo = 263,
            America_Tijuana = 264,
            America_Santa_Isabel = 265,
            America_Bahia_Banderas = 266,
            Asia_Kuala_Lumpur = 267,
            Asia_Kuching = 268,
            Africa_Maputo = 269,
            Africa_Windhoek = 270,
            Pacific_Noumea = 271,
            Africa_Niamey = 272,
            Pacific_Norfolk = 273,
            Africa_Lagos = 274,
            America_Managua = 275,
            Europe_Amsterdam = 276,
            Europe_Oslo = 277,
            Asia_Kathmandu = 278,
            Pacific_Nauru = 279,
            Pacific_Niue = 280,
            Pacific_Auckland = 281,
            Pacific_Chatham = 282,
            Asia_Muscat = 283,
            America_Panama = 284,
            America_Lima = 285,
            Pacific_Tahiti = 286,
            Pacific_Marquesas = 287,
            Pacific_Gambier = 288,
            Pacific_Port_Moresby = 289,
            Asia_Manila = 290,
            Asia_Karachi = 291,
            Europe_Warsaw = 292,
            America_Miquelon = 293,
            Pacific_Pitcairn = 294,
            America_Puerto_Rico = 295,
            Asia_Gaza = 296,
            Asia_Hebron = 297,
            Europe_Lisbon = 298,
            Atlantic_Madeira = 299,
            Atlantic_Azores = 300,
            Pacific_Palau = 301,
            America_Asuncion = 302,
            Asia_Qatar = 303,
            Indian_Reunion = 304,
            Europe_Bucharest = 305,
            Europe_Belgrade = 306,
            Europe_Kaliningrad = 307,
            Europe_Moscow = 308,
            Europe_Volgograd = 309,
            Europe_Samara = 310,
            Europe_Simferopol = 311,
            Asia_Yekaterinburg = 312,
            Asia_Omsk = 313,
            Asia_Novosibirsk = 314,
            Asia_Novokuznetsk = 315,
            Asia_Krasnoyarsk = 316,
            Asia_Irkutsk = 317,
            Asia_Yakutsk = 318,
            Asia_Khandyga = 319,
            Asia_Vladivostok = 320,
            Asia_Sakhalin = 321,
            Asia_Ust_Nera = 322,
            Asia_Magadan = 323,
            Asia_Kamchatka = 324,
            Asia_Anadyr = 325,
            Africa_Kigali = 326,
            Asia_Riyadh = 327,
            Pacific_Guadalcanal = 328,
            Indian_Mahe = 329,
            Africa_Khartoum = 330,
            Europe_Stockholm = 331,
            Asia_Singapore = 332,
            Atlantic_St_Helena = 333,
            Europe_Ljubljana = 334,
            Arctic_Longyearbyen = 335,
            Europe_Bratislava = 336,
            Africa_Freetown = 337,
            Europe_San_Marino = 338,
            Africa_Dakar = 339,
            Africa_Mogadishu = 340,
            America_Paramaribo = 341,
            Africa_Juba = 342,
            Africa_Sao_Tome = 343,
            America_El_Salvador = 344,
            America_Lower_Princes = 345,
            Asia_Damascus = 346,
            Africa_Mbabane = 347,
            America_Grand_Turk = 348,
            Africa_Ndjamena = 349,
            Indian_Kerguelen = 350,
            Africa_Lome = 351,
            Asia_Bangkok = 352,
            Asia_Dushanbe = 353,
            Pacific_Fakaofo = 354,
            Asia_Dili = 355,
            Asia_Ashgabat = 356,
            Africa_Tunis = 357,
            Pacific_Tongatapu = 358,
            Europe_Istanbul = 359,
            America_Port_of_Spain = 360,
            Pacific_Funafuti = 361,
            Asia_Taipei = 362,
            Africa_Dar_es_Salaam = 363,
            Europe_Kiev = 364,
            Europe_Uzhgorod = 365,
            Europe_Zaporozhye = 366,
            Africa_Kampala = 367,
            Pacific_Johnston = 368,
            Pacific_Midway = 369,
            Pacific_Wake = 370,
            America_New_York = 371,
            America_Detroit = 372,
            America_Kentucky_Louisville = 373,
            America_Kentucky_Monticello = 374,
            America_Indiana_Indianapolis = 375,
            America_Indiana_Vincennes = 376,
            America_Indiana_Winamac = 377,
            America_Indiana_Marengo = 378,
            America_Indiana_Petersburg = 379,
            America_Indiana_Vevay = 380,
            America_Chicago = 381,
            America_Indiana_Tell_City = 382,
            America_Indiana_Knox = 383,
            America_Menominee = 384,
            America_North_Dakota_Center = 385,
            America_North_Dakota_New_Salem = 386,
            America_North_Dakota_Beulah = 387,
            America_Denver = 388,
            America_Boise = 389,
            America_Phoenix = 390,
            America_Los_Angeles = 391,
            America_Anchorage = 392,
            America_Juneau = 393,
            America_Sitka = 394,
            America_Yakutat = 395,
            America_Nome = 396,
            America_Adak = 397,
            America_Metlakatla = 398,
            Pacific_Honolulu = 399,
            America_Montevideo = 400,
            Asia_Samarkand = 401,
            Asia_Tashkent = 402,
            Europe_Vatican = 403,
            America_St_Vincent = 404,
            America_Caracas = 405,
            America_Tortola = 406,
            America_St_Thomas = 407,
            Asia_Ho_Chi_Minh = 408,
            Pacific_Efate = 409,
            Pacific_Wallis = 410,
            Pacific_Apia = 411,
            Asia_Aden = 412,
            Indian_Mayotte = 413,
            Africa_Johannesburg = 414,
            Africa_Lusaka = 415,
            Africa_Harare = 416
        }

        public struct CountrySEnum
        {
             public static string Andorra = "AD";
             public static string United_Arab_Emirates = "AE";
             public static string Afghanistan = "AF";
             public static string Antigua_and_Barbuda = "AG";
             public static string Anguilla = "AI";
             public static string Albania = "AL";
             public static string Armenia = "AM";
             public static string Netherlands_Antilles = "AN";
             public static string Angola = "AO";
             public static string Antarctica = "AQ";
             public static string Argentina = "AR";
             public static string American_Samoa = "AS";
             public static string Austria = "AT";
             public static string Australia = "AU";
             public static string Aruba = "AW";
             public static string Aland_Islands = "AX";
             public static string Azerbaijan = "AZ";
             public static string Bosnia_and_Herzegovina = "BA";
             public static string Barbados = "BB";
             public static string Bangladesh = "BD";
             public static string Belgium = "BE";
             public static string Burkina_Faso = "BF";
             public static string Bulgaria = "BG";
             public static string Bahrain = "BH";
             public static string Burundi = "BI";
             public static string Benin = "BJ";
             public static string Saint_Barth_lemy = "BL";
             public static string Bermuda = "BM";
             public static string Brunei = "BN";
             public static string Bolivia = "BO";
             public static string Bonaire_Saint_Eustatius_and_Saba_ = "BQ";
             public static string Brazil = "BR";
             public static string Bahamas = "BS";
             public static string Bhutan = "BT";
             public static string Bouvet_Island = "BV";
             public static string Botswana = "BW";
             public static string Belarus = "BY";
             public static string Belize = "BZ";
             public static string Canada = "CA";
             public static string Cocos_Islands = "CC";
             public static string Democratic_Republic_of_the_Congo = "CD";
             public static string Central_African_Republic = "CF";
             public static string Republic_of_the_Congo = "CG";
             public static string Switzerland = "CH";
             public static string Ivory_Coast = "CI";
             public static string Cook_Islands = "CK";
             public static string Chile = "CL";
             public static string Cameroon = "CM";
             public static string China = "CN";
             public static string Colombia = "CO";
             public static string Costa_Rica = "CR";
             public static string Serbia_and_Montenegro = "CS";
             public static string Cuba = "CU";
             public static string Cape_Verde = "CV";
             public static string Cura__ao = "CW";
             public static string Christmas_Island = "CX";
             public static string Cyprus = "CY";
             public static string Czech_Republic = "CZ";
             public static string Germany = "DE";
             public static string Djibouti = "DJ";
             public static string Denmark = "DK";
             public static string Dominica = "DM";
             public static string Dominican_Republic = "DO";
             public static string Algeria = "DZ";
             public static string Ecuador = "EC";
             public static string Estonia = "EE";
             public static string Egypt = "EG";
             public static string Western_Sahara = "EH";
             public static string Eritrea = "ER";
             public static string Spain = "ES";
             public static string Ethiopia = "ET";
             public static string Finland = "FI";
             public static string Fiji = "FJ";
             public static string Falkland_Islands = "FK";
             public static string Micronesia = "FM";
             public static string Faroe_Islands = "FO";
             public static string France = "FR";
             public static string Gabon = "GA";
             public static string United_Kingdom = "GB";
             public static string Grenada = "GD";
             public static string Georgia = "GE";
             public static string French_Guiana = "GF";
             public static string Guernsey = "GG";
             public static string Ghana = "GH";
             public static string Gibraltar = "GI";
             public static string Greenland = "GL";
             public static string Gambia = "GM";
             public static string Guinea = "GN";
             public static string Guadeloupe = "GP";
             public static string Equatorial_Guinea = "GQ";
             public static string Greece = "GR";
             public static string South_Georgia_and_the_South_Sandwich_Islands = "GS";
             public static string Guatemala = "GT";
             public static string Guam = "GU";
             public static string Guinea_Bissau = "GW";
             public static string Guyana = "GY";
             public static string Hong_Kong = "HK";
             public static string Heard_Island_and_McDonald_Islands = "HM";
             public static string Honduras = "HN";
             public static string Croatia = "HR";
             public static string Haiti = "HT";
             public static string Hungary = "HU";
             public static string Indonesia = "ID";
             public static string Ireland = "IE";
             public static string Israel = "IL";
             public static string Isle_of_Man = "IM";
             public static string India = "IN";
             public static string British_Indian_Ocean_Territory = "IO";
             public static string Iraq = "IQ";
             public static string Iran = "IR";
             public static string Iceland = "IS";
             public static string Italy = "IT";
             public static string Jersey = "JE";
             public static string Jamaica = "JM";
             public static string Jordan = "JO";
             public static string Japan = "JP";
             public static string Kenya = "KE";
             public static string Kyrgyzstan = "KG";
             public static string Cambodia = "KH";
             public static string Kiribati = "KI";
             public static string Comoros = "KM";
             public static string Saint_Kitts_and_Nevis = "KN";
             public static string North_Korea = "KP";
             public static string South_Korea = "KR";
             public static string Kuwait = "KW";
             public static string Cayman_Islands = "KY";
             public static string Kazakhstan = "KZ";
             public static string Laos = "LA";
             public static string Lebanon = "LB";
             public static string Saint_Lucia = "LC";
             public static string Liechtenstein = "LI";
             public static string Sri_Lanka = "LK";
             public static string Liberia = "LR";
             public static string Lesotho = "LS";
             public static string Lithuania = "LT";
             public static string Luxembourg = "LU";
             public static string Latvia = "LV";
             public static string Libya = "LY";
             public static string Morocco = "MA";
             public static string Monaco = "MC";
             public static string Moldova = "MD";
             public static string Montenegro = "ME";
             public static string Saint_Martin = "MF";
             public static string Madagascar = "MG";
             public static string Marshall_Islands = "MH";
             public static string Macedonia = "MK";
             public static string Mali = "ML";
             public static string Myanmar = "MM";
             public static string Mongolia = "MN";
             public static string Macao = "MO";
             public static string Northern_Mariana_Islands = "MP";
             public static string Martinique = "MQ";
             public static string Mauritania = "MR";
             public static string Montserrat = "MS";
             public static string Malta = "MT";
             public static string Mauritius = "MU";
             public static string Maldives = "MV";
             public static string Malawi = "MW";
             public static string Mexico = "MX";
             public static string Malaysia = "MY";
             public static string Mozambique = "MZ";
             public static string Namibia = "NA";
             public static string New_Caledonia = "NC";
             public static string Niger = "NE";
             public static string Norfolk_Island = "NF";
             public static string Nigeria = "NG";
             public static string Nicaragua = "NI";
             public static string Netherlands = "NL";
             public static string Norway = "NO";
             public static string Nepal = "NP";
             public static string Nauru = "NR";
             public static string Niue = "NU";
             public static string New_Zealand = "NZ";
             public static string Oman = "OM";
             public static string Panama = "PA";
             public static string Peru = "PE";
             public static string French_Polynesia = "PF";
             public static string Papua_New_Guinea = "PG";
             public static string Philippines = "PH";
             public static string Pakistan = "PK";
             public static string Poland = "PL";
             public static string Saint_Pierre_and_Miquelon = "PM";
             public static string Pitcairn = "PN";
             public static string Puerto_Rico = "PR";
             public static string Palestinian_Territory = "PS";
             public static string Portugal = "PT";
             public static string Palau = "PW";
             public static string Paraguay = "PY";
             public static string Qatar = "QA";
             public static string Reunion = "RE";
             public static string Romania = "RO";
             public static string Serbia = "RS";
             public static string Russia = "RU";
             public static string Rwanda = "RW";
             public static string Saudi_Arabia = "SA";
             public static string Solomon_Islands = "SB";
             public static string Seychelles = "SC";
             public static string Sudan = "SD";
             public static string Sweden = "SE";
             public static string Singapore = "SG";
             public static string Saint_Helena = "SH";
             public static string Slovenia = "SI";
             public static string Svalbard_and_Jan_Mayen = "SJ";
             public static string Slovakia = "SK";
             public static string Sierra_Leone = "SL";
             public static string San_Marino = "SM";
             public static string Senegal = "SN";
             public static string Somalia = "SO";
             public static string Suriname = "SR";
             public static string South_Sudan = "SS";
             public static string Sao_Tome_and_Principe = "ST";
             public static string El_Salvador = "SV";
             public static string Sint_Maarten = "SX";
             public static string Syria = "SY";
             public static string Swaziland = "SZ";
             public static string Turks_and_Caicos_Islands = "TC";
             public static string Chad = "TD";
             public static string French_Southern_Territories = "TF";
             public static string Togo = "TG";
             public static string Thailand = "TH";
             public static string Tajikistan = "TJ";
             public static string Tokelau = "TK";
             public static string East_Timor = "TL";
             public static string Turkmenistan = "TM";
             public static string Tunisia = "TN";
             public static string Tonga = "TO";
             public static string Turkey = "TR";
             public static string Trinidad_and_Tobago = "TT";
             public static string Tuvalu = "TV";
             public static string Taiwan = "TW";
             public static string Tanzania = "TZ";
             public static string Ukraine = "UA";
             public static string Uganda = "UG";
             public static string United_States_Minor_Outlying_Islands = "UM";
             public static string United_States = "US";
             public static string Uruguay = "UY";
             public static string Uzbekistan = "UZ";
             public static string Vatican = "VA";
             public static string Saint_Vincent_and_the_Grenadines = "VC";
             public static string Venezuela = "VE";
             public static string British_Virgin_Islands = "VG";
             public static string U_S__Virgin_Islands = "VI";
             public static string Vietnam = "VN";
             public static string Vanuatu = "VU";
             public static string Wallis_and_Futuna = "WF";
             public static string Samoa = "WS";
             public static string Kosovo = "XK";
             public static string Yemen = "YE";
             public static string Mayotte = "YT";
             public static string South_Africa = "ZA";
             public static string Zambia = "ZM";
             public static string Zimbabwe = "ZW";
 
        }


        public enum VisitPlaceEnum : byte
        {
            Telemedicine = 0,
            FaceToFace = 1,
            Both = 2
        }


        public enum AppEntityFileUploadStatus : byte
        {
            Incomplete = 0,
            Completed = 1
        }

        public enum MobilePushTemplateType : byte
        {
            TestPushSanity = 0,
            Call_PhoneRing = 1,
            Call_Answer = 2,
            Call_Decline = 3,
            Call_End = 4
        }

        public enum MobilePushDeliveryType : byte
        {
            MobileOnly = 0,
            WebAndMobile = 1,
            WebOnly = 2
        }

        public enum CallStatus : byte
        {
            /// <summary>
            /// When Caller calls the callee, but still no answer
            /// </summary>
            Pending_NoAnswer = 0,
            /// <summary>
            /// When Callee answers the call, but it still hasn't ended
            /// </summary>
            CalleeAnswered = 1,
            /// <summary>
            /// When Callee declines to answer the phone (maybe because he is busy)
            /// </summary>
            Declined = 2,
            /// <summary>
            /// When call ended by one of the parties
            /// </summary>
            Ended = 3,
            /// <summary>
            /// When call cacelled by caller before callee answer
            /// </summary>
            Cancelled = 4
        }

        public enum TicketStatusID : byte
        {
            Open = 0,
            Closed = 1,
            Pending = 2,
            Resolved = 3
        }

        public enum TicketPriorityEnum : byte { 
            Unassigned = 0,
            Low = 1,
            Medium = 2,
            High = 3,
            Urgent = 4
        }

        public enum TicketSourceTypeEnum : byte
        {
            Unspecified = 0,
            Website = 1,
            Email = 2,
            Phone = 3,
            Text = 4,
            Facebook = 5,
            Twitter = 6,
            Youtube = 7
        }

        public enum AppFileTypeEnum : int
        {
            TestPictureUpload = 1,
            ProfilePicture = 1000,
            MedicalDocument = 1001,
            VisitAttachments = 1002
        }


        public enum UserDeviceClientAppTypeEnum : byte
        {
            Cordova = 0,
            AdobeAir = 1
        }


        public enum DailyActivityTypeEnum : int
        {
            Other = 0,
            Eating = 1,
            Sleeping = 7,
            PhysicalActivity = 8
        }

        public enum FoodServingTimeTypeEnum : byte
        {
            Other = 0,
            Breakfast = 1,
            Lunch = 2,
            Dinner = 3,
            MorningSnack = 4,
            AfternoonSnack = 5,
            EveningSnack = 6
        }

    }
}
