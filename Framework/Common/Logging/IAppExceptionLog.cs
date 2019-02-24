using System;
namespace Framework.Common.Logging
{
    public interface IAppExceptionLog
    {
        long AppExceptionLogID { get; set; }
        string ClassType { get; set; }
        string DataInformation { get; set; }
        DateTime InsertDate { get; set; }
        string IPAddress { get; set; }
        string Message { get; set; }
        string Source { get; set; }
        string StackTrace { get; set; }
        string Target { get; set; }
        string Url { get; set; }
        long? UserID { get; set; }
    }
}
