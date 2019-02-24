using Framework.Common;

namespace Framework.Service
{
    public interface IServiceBaseT<T, V> : IEntityCRUDFunctions<T, V>, IServiceBase
    {
    }
}
