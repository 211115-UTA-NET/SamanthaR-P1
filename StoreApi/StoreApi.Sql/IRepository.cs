

using StoreApi.Dtos;

namespace StoreApi.Sql
{
    public interface IRepository
    {
        Task<List<StoreDtos>> ReadStoreMenu();
    }
}