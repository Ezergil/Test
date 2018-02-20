using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Abstraction
{
    public interface IRepository<TEntity> : ICrudActions<TEntity> where TEntity: BaseEntity
    {
    }
}