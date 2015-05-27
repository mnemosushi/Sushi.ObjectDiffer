using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    /// <summary>
    /// Default simple INode implementation
    /// </summary>
    [DebuggerDisplay("FullName={FullName}")]
    public class Node : INode
    {
        #region INode implementation
        public string Name { get; set; }
        public string FullName { get { return GenerateFullName(); } }
        public object OldItem { get; set; }
        public object NewItem { get; set; }
        #endregion
        public INode Left { get; set; }


        private string GenerateFullName()
        {
            StringBuilder sb = new StringBuilder();
            for (Node currentNode = this; currentNode != null; currentNode = (Node)currentNode.Left)
            {
                sb.Insert(0, currentNode.Name);
                if (currentNode.Left != null)
                    sb.Insert(0, '.');
            }
            return sb.ToString();
        }
    }
}
