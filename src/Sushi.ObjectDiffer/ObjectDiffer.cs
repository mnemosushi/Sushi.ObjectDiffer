using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Reflection;
using System.Collections.Generic;

namespace Sushi.ObjectDiffer
{
    public static class ObjectDiffer
    {
        /// <summary>
        /// Find property or field in given object model which has CloneObject as attribute and 
        /// compare it with given object model for changes by reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ICollection<INode> DifferClone<T>(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return DifferClone<T>(new DefaultNodeFactory(), item);
        }

        /// <summary>
        /// Find property or field in given object model which has CloneObject as attribute and 
        /// compare it with given object model for changes by reflection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static ICollection<INode> DifferClone<T>(INodeFactory nodeFactory, T item)
        {
            if (nodeFactory == null)
                throw new ArgumentNullException("nodeFactory");
            if (item == null)
                throw new ArgumentNullException("item");

            var objectDiffer = new DefaultObjectDiffer<T>(nodeFactory);
            return DifferClone<T>(objectDiffer, item);
        }

	    /// <summary>
	    /// Find property or field in given object model which has CloneObject as attribute and 
        /// compare it with given object model for changes.
	    /// </summary>
	    /// <typeparam name="T"></typeparam>
        /// <param name="nodeFactory"></param>
        /// <param name="item"></param>
	    /// <returns></returns>
        public static ICollection<INode> DifferClone<T>(IObjectDiffer<T> objectDiffer, T item)
        {
            if (objectDiffer == null)
                throw new ArgumentNullException("objectDiffer");
            if (item == null)
                throw new ArgumentNullException("item");

            T clonedItem = item.FindClone<T>();
            if (clonedItem == null)
            {
                throw new ArgumentException("Can not found CloneObject attribute in the object " + item.GetType().Name);
            }
            else
            {
                return Differ<T>(objectDiffer, clonedItem, item);
            }        
        }

        /// <summary>
        /// Compare two object model for changes by reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static ICollection<INode> Differ<T>(T oldItem, T newItem)
        {
            if (oldItem == null)
                throw new ArgumentNullException("oldItem");
            if (newItem == null)
                throw new ArgumentNullException("newItem");

            return Differ<T>(new DefaultNodeFactory(), oldItem, newItem);
        }

        /// <summary>
        /// Compare two object model for changes by reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodeFactory"></param>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static ICollection<INode> Differ<T>(INodeFactory nodeFactory, T oldItem, T newItem)
        {
            if (nodeFactory == null)
                throw new ArgumentNullException("nodeFactory");
            if (oldItem == null)
                throw new ArgumentNullException("oldItem");
            if (newItem == null)
                throw new ArgumentNullException("newItem");

            var objectDiffer = new DefaultObjectDiffer<T>(nodeFactory);
            return Differ<T>(objectDiffer, oldItem, newItem);
        }

        /// <summary>
        /// Compare two object model for changes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectDiffer"></param>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static ICollection<INode> Differ<T>(IObjectDiffer<T> objectDiffer, T oldItem, T newItem)
        {
            if (objectDiffer == null)
                throw new ArgumentNullException("objectDiffer");
            if (oldItem == null)
                throw new ArgumentNullException("oldItem");
            if (newItem == null)
                throw new ArgumentNullException("newItem");

            return objectDiffer.Differ(oldItem, newItem);
        }
    }

    
}
