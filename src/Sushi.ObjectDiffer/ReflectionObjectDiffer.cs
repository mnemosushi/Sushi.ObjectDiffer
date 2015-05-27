using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    public class ReflectionObjectDiffer<T> : IObjectDiffer<T>
    {
        public ReflectionObjectDiffer(INodeFactory nodeFactory)
        {
            NodeFactory = nodeFactory;
        }

        protected INodeFactory NodeFactory { get; set; }

        #region IObjectDiffer<T> implementation
        /// <summary>
        /// Inspect two objects for differ
        /// </summary>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public ICollection<INode> Differ(T oldItem, T newItem)
        {
            ICollection<INode> changedNodes = new Collection<INode>();
            DifferByReflection(oldItem, newItem, null, changedNodes);
            return changedNodes;
        }
        #endregion

        private void DifferByReflection(object oldItem, object newItem, INode leftNode, ICollection<INode> changedNodes)
        {
            Type type = newItem.GetType();

            foreach (PropertyInfo propInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                Type propertyType = propInfo.PropertyType;

                object oldItemProperty = propInfo.GetValue(oldItem);
                object newItemProperty = propInfo.GetValue(newItem);

                if (
                    propertyType.IsPrimitive ||
                    propertyType.IsValueType ||
                    propertyType == typeof(string))
                {
                    if (!newItemProperty.Equals(oldItemProperty))
                    {
                        INode leafNode = NodeFactory.CreateNode(propInfo.Name, leftNode, oldItemProperty, newItemProperty);
                        changedNodes.Add(leafNode);
                    }
                }
                else
                {
                    if (oldItemProperty != null && newItemProperty != null)
                    {
                        INode propertyNode = NodeFactory.CreateNode(propInfo.Name, leftNode, null, null);

                        DifferByReflection(
                            oldItemProperty,
                            newItemProperty,
                            propertyNode,
                            changedNodes);
                    }
                }
            }
        }
    }
}
