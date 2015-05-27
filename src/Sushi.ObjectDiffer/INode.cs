using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    public interface INode
    {
        string Name { get; set; }
        string FullName { get; }
        object OldItem { get; set; }
        object NewItem { get; set; }
    }
}
