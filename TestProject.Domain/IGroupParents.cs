using System.Collections.Generic;

namespace TestProject.Domain
{
    public interface IGroupParents
    {
        ICollection<Group> Parents { get; set; }
    }
}