
namespace Framework.Service
{
    public interface IAuditService
    {
        /// <summary>
        /// يك رديف آديت را در ديتابيس ايجاد ميكند
        /// </summary>
        /// <param name="entityName">نام موجوديت</param>
        /// <param name="entityID">شناسه موجوديت</param>
        /// <param name="entityTitleFieldValue">عنوان فيلد</param>
        /// <param name="personId">شناسه فرد</param>
        /// <param name="changeString"></param>
        /// <param name="operation"></param>
        void InsertAudit(string entityName, string entityID, string entityTitleFieldValue, int personId, string changeString, char operation);
    }
}
