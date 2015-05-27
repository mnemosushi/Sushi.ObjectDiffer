using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    public interface IObjectDiffer<T>
    {
        ICollection<INode> Differ(T oldItem, T newItem);
    }
}
