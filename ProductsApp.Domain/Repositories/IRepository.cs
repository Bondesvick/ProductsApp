
using ProductsApp.Domain.Entities;

namespace ProductsApp.Domain.Repositories
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}