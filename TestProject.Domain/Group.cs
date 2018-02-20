using System.Collections.Generic;
using TestProject.Abstraction;

namespace TestProject.Domain
{
    public class Group : BaseEntity, IGroupParents
    {
        public virtual ICollection<Group> Parents { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
