using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Framework.Common;

namespace UTD.Tricorder.Common
{
    public class AdobeAirCapabilities
    {

        private bool _IsNull;
        public bool IsNull { get { return _IsNull; } }


        //Sample String: A=t&SA=t&SV=t&EV=t&MP3=t&AE=t&VE=t&ACC=f&PR=t&SP=t&
         //SB=f&DEB=t&V=WIN%209%2C0%2C0%2C0&M=Adobe%20Windows&
         //R=1600x1200&DP=72&COL=color&AR=1.0&OS=Windows%20XP&
         //L=en&PT=External&AVD=f&LFD=f&WD=f&IME=t&DD=f&
         //DDP=f&DTS=f&DTE=f&DTH=f&DTM=f

        //avHardwareDisable	AVD
        //hasAccessibility	ACC
        //hasAudio	A
        //hasAudioEncoder	AE
        //hasEmbeddedVideo	EV
        //hasIME	IME
        //hasMP3	MP3
        //hasPrinting	PR
        //hasScreenBroadcast	SB
        //hasScreenPlayback	SP
        //hasStreamingAudio	SA
        //hasStreamingVideo	SV
        //hasTLS	TLS
        //hasVideoEncoder	VE
        //isDebugger	DEB
        //language	L
        //localFileReadDisable	LFD
        //manufacturer	M
        //maxLevelIDC	ML
        //os	OS
        //pixelAspectRatio	AR
        //playerType	PT
        //screenColor	COL
        //screenDPI	DP
        //screenResolutionX	R
        //screenResolutionY	R
        //version	V
        //supports Dolby Digital audio	DD
        //supports Dolby Digital Plus audio	DDP
        //supports DTS audio	DTS
        //supports DTS Express audio	DTE
        //supports DTS-HD High Resolution Audio	DTH
        //supports DTS-HD Master Audio	DTM

        private string _capabilitiesString;

        public bool IsSame(string capabilitiesString)
        {
            return _capabilitiesString == capabilitiesString;
        }


        public AdobeAirCapabilities(string capabilitiesString)
        {
            _capabilitiesString = capabilitiesString;
            ParseCapabilitiesString(capabilitiesString);
        }

        //DEVELOPER NOTE: This function shouldn't be public and call outside because
        //it doesn't reset default values. Parsing two different strings can cause unexpected results
        /// <summary>
        /// Parses adobe air's capabilities string
        /// </summary>
        /// <param name="capabilitiesString">capabilities string</param>
        private void ParseCapabilitiesString(string capabilitiesString)
        {
            if (string.IsNullOrEmpty(capabilitiesString))
            {
                _IsNull = true;
            }
            else
            {
                try
                {
                    string[] keyValues = capabilitiesString.Split('&');
                    foreach (string s in keyValues)
                    {
                        string[] sArray = s.Split('=');
                        string key = sArray[0];
                        string value = sArray[1];

                        switch (key)
                        {
                            case "AVD":
                                _avHardwareDisable = GetBooleanValue(value);
                                break;
                            case "ACC":
                                _hasAccessibility = GetBooleanValue(value);
                                break;
                            case "A":
                                _hasAudio = GetBooleanValue(value);
                                break;
                            case "AE":
                                _hasAudioEncoder = GetBooleanValue(value);
                                break;
                            case "EV":
                                _hasEmbeddedVideo = GetBooleanValue(value);
                                break;
                            case "IME":
                                _hasIME = GetBooleanValue(value);
                                break;
                            case "MP3":
                                _hasMP3 = GetBooleanValue(value);
                                break;
                            case "PR":
                                _hasPrinting = GetBooleanValue(value);
                                break;
                            case "SB":
                                _hasScreenBroadcast = GetBooleanValue(value);
                                break;
                            case "SP":
                                _hasScreenPlayback = GetBooleanValue(value);
                                break;
                            case "SA":
                                _hasStreamingAudio = GetBooleanValue(value);
                                break;
                            case "SV":
                                _hasStreamingVideo = GetBooleanValue(value);
                                break;
                            case "TLS":
                                _hasTLS = GetBooleanValue(value);
                                break;
                            case "VE":
                                _hasVideoEncoder = GetBooleanValue(value);
                                break;
                            case "DEB":
                                _isDebugger = GetBooleanValue(value);
                                break;
                            case "L":
                                _language = GetStringValue(value);
                                break;
                            case "LFD":
                                _localFileReadDisable = GetBooleanValue(value);
                                break;
                            case "M":
                                _manufacturer = GetStringValue(value);
                                break;
                            case "ML":
                                _maxLevelIDC = GetStringValue(value);
                                break;
                            case "OS":
                                _os = GetStringValue(value);
                                break;
                            case "AR":
                                _pixelAspectRatio = GetFloatValue(value);
                                break;
                            case "PT":
                                _playerType = GetStringValue(value);
                                break;
                            case "COL":
                                _screenColor = GetStringValue(value);
                                break;
                            case "DP":
                                _screenDPI = GetIntValue(value);
                                break;
                            case "R":
                                // R is like 1280x768
                                try
                                {
                                    _screenResolutionX = GetIntValue(value.Split('x')[0]);
                                    _screenResolutionY = GetIntValue(value.Split('x')[1]);
                                }
                                finally { }
                                break;
                            case "V":
                                _version = GetStringValue(value);
                                break;
                            case "DD":
                                _supportsDolbyDigitalAudio = GetBooleanValue(value);
                                break;
                            case "DDP":
                                _supportsDolbyDigitalPlusAudio = GetBooleanValue(value);
                                break;
                            case "DTS":
                                _supportsDTSAudio = GetBooleanValue(value);
                                break;
                            case "DTE":
                                _supportsDTSExpressAudio = GetBooleanValue(value);
                                break;
                            case "DTH":
                                _supportsDTS_HDHighResolutionAudio = GetBooleanValue(value);
                                break;
                            case "DTM":
                                _supportsDTS_HDMasterAudio = GetBooleanValue(value);
                                break;

                        }

                    }
                }
                catch (Exception ex)
                {
                    FWUtils.ExpLogUtils.ExceptionLogger.LogError(ex, capabilitiesString);
                }

            }
        }

        private bool GetBooleanValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            value = GetStringValue(value).ToLower();
            if (value == "t" || value == "1" || value == "true")
                return true;
            else
                return false;
        }

        private float GetFloatValue(string value)
        {
            float f = 0;
            float.TryParse(value, out f);
            return f;
        }

        private int GetIntValue(string value)
        {
            int i = 0;
            int.TryParse(value, out i);
            return i;
        }

        private string GetStringValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return HttpUtility.UrlDecode(value);
        }


        private bool _avHardwareDisable;
        public bool avHardwareDisable{ get {return _avHardwareDisable;} }

        private bool _hasAccessibility;
        public bool hasAccessibility {get { return _hasAccessibility;}}

        private bool _hasAudio;
        public bool hasAudio {get{ return _hasAudio;}}

        private bool _hasAudioEncoder;
        public bool hasAudioEncoder	{get{ return _hasAudioEncoder;} }

        private bool _hasEmbeddedVideo;
        public bool hasEmbeddedVideo {get{return _hasEmbeddedVideo;}}

        private bool _hasIME;
        public bool hasIME {get{return _hasIME;}}

        private bool _hasMP3;
        public bool hasMP3 {get{ return _hasMP3;}}

        private bool _hasPrinting;
        public bool hasPrinting	{get{return _hasPrinting;}}

        private bool _hasScreenBroadcast;
        public bool hasScreenBroadcast {get { return _hasScreenBroadcast;}}

        private bool _hasScreenPlayback;
        public bool hasScreenPlayback { get { return _hasScreenPlayback;}}

        private bool _hasStreamingAudio;
        public bool hasStreamingAudio { get { return _hasStreamingAudio; } }

        private bool _hasStreamingVideo;
        public bool hasStreamingVideo { get { return _hasStreamingVideo; } }

        private bool _hasTLS;
        public bool hasTLS { get { return _hasTLS; } }

        private bool _hasVideoEncoder;
        public bool hasVideoEncoder { get { return _hasVideoEncoder; } }

        private bool _isDebugger;
        public bool isDebugger { get { return _isDebugger; } }

        private string _language;
        public string language { get { return _language; } }

        private bool _localFileReadDisable;
        public bool localFileReadDisable { get { return _localFileReadDisable; } }

        private string _manufacturer;
        public string manufacturer { get { return _manufacturer; } }

        private string _maxLevelIDC;
        public string maxLevelIDC { get { return _maxLevelIDC; } }

        private string _os;
        public string os { get { return _os; } }

        private float _pixelAspectRatio;
        public float pixelAspectRatio { get { return _pixelAspectRatio; } }

        private string _playerType;
        public string playerType { get { return _playerType; } }

        private string _screenColor;
        public string screenColor { get { return _screenColor; } }

        private int _screenDPI;
        public int screenDPI { get { return _screenDPI; } }

        private int _screenResolutionX;
        public int screenResolutionX { get { return _screenResolutionX; } }

        private int _screenResolutionY;
        public int screenResolutionY { get { return _screenResolutionY; } }

        private string _version;
        public string version { get { return _version; } }

        private bool _supportsDolbyDigitalAudio;
        public bool supportsDolbyDigitalAudio { get { return _supportsDolbyDigitalAudio; } }

        private bool _supportsDolbyDigitalPlusAudio;
        public bool supportsDolbyDigitalPlusAudio { get { return _supportsDolbyDigitalPlusAudio; } }

        private bool _supportsDTSAudio;
        public bool supportsDTSAudio { get { return _supportsDTSAudio; } }

        private bool _supportsDTSExpressAudio;
        public bool supportsDTSExpressAudio { get { return _supportsDTSExpressAudio; } }

        private bool _supportsDTS_HDHighResolutionAudio;
        public bool supportsDTS_HDHighResolutionAudio { get { return _supportsDTS_HDHighResolutionAudio; } }

        private bool _supportsDTS_HDMasterAudio;
        public bool supportsDTS_HDMasterAudio { get { return _supportsDTS_HDMasterAudio; } }


    }
}
