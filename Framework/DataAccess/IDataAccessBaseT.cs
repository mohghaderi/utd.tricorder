using Framework.Common;

namespace Framework.DataAccess
{
    public interface IDataAccessBaseT<T, V> : IEntityCRUDFunctions<T, V> , IDataAccessBase
    {
    }
}
