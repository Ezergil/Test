using System.Collections.Generic;
using TestProject.Abstraction;

namespace TestProject.Domain
{
    public class User : BaseEntity, IGroupParents
    {
        public virtual ICollection<Group> Parents { get; set; }
    }
}