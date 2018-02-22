using System.Collections.Generic;
using System.Linq;
using TestProject.Abstraction;

namespace TestProject.Domain
{
    public class User : BaseEntity, IGroupParents
    {
        public virtual ICollection<Group> Parents { get; set; }
        public override bool CouldBeDeleted => Parents == null || !Parents.Any();
    }
}