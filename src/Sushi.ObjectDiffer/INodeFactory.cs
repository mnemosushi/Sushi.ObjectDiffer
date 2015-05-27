using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    public interface INodeFactory
    {
        INode CreateNode(string name, INode left, object oldItem, object newItem);
    }
}
