using System.Collections.Generic;
using System.Linq;
using TestProject.Abstraction;

namespace TestProject.Domain
{
    public class Group : BaseEntity, IGroupParents
    {
        public virtual ICollection<Group> Parents { get; set; }
        public virtual ICollection<Group> Childs { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public override bool CouldBeDeleted => Parents == null && Childs == null || !Parents.Any() && !Childs.Any();
    }
}
