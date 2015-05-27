using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    /// <summary>
    /// Default simple INodeFactory implementation
    /// </summary>
    public class DefaultNodeFactory : INodeFactory
    {
        public INode CreateNode(string name, INode left, object oldItem, object newItem)
        {
            Node node = new Node();
            node.Name = name;
            node.Left = left;
            node.OldItem = oldItem;
            node.NewItem = newItem;

            return node;
        }
    }
}
