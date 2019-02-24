using System.Collections.Generic;

namespace Framework.DataAccess
{
    public interface IMasterEntity
    {
        List<object> DeletedDetailObjects { get; }
    }
}
