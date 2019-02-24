using System;
namespace Framework.Common.Logging
{
    public interface IAppLog
    {
        long AppLogID { get; set; }
        short AppLogTypeID { get; set; }
        long? ExtraBigInt { get; set; }
        double? ExtraDouble { get; set; }
        Guid? ExtraGuid { get; set; }
        int? ExtraInt { get; set; }
        string ExtraString1 { get; set; }
        string ExtraString2 { get; set; }
        DateTime InsertDate { get; set; }
        string IPAddress { get; set; }
        long? UserID { get; set; }
    }
}
