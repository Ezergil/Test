using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject.Abstraction
{
    public interface IService<TEntity> : ICrudActions<TEntity> where TEntity : BaseEntity
    {
    }
}