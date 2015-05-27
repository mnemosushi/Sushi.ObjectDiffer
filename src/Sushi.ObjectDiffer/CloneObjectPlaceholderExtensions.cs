using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer
{
    public static class CloneObjectPlaceholderExtensions
    {
        /// <summary>
        /// Find property or field in object model which has attribute CloneObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T FindClone<T>(this T source)
        {
            PropertyInfo propInfo = source.FindCloneProperty();
            if (propInfo != null)
            {
                return (T)propInfo.GetValue(source);
            }
            FieldInfo fieldInfo = source.FindCloneField();
            if(fieldInfo != null)
            {
                return (T)fieldInfo.GetValue(source);
            }
            return default(T);
        }

        /// <summary>
        /// Find property in object model which has attribute CloneObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static PropertyInfo FindCloneProperty<T>(this T source)
        {
            Type type = source.GetType();
            foreach (PropertyInfo propInfo in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                CloneObjectPlaceholderAttribute cloneAttr = propInfo.GetCustomAttribute<CloneObjectPlaceholderAttribute>();
                if (cloneAttr != null)
                {
                    return propInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// Find field in object model which has attribute CloneObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static FieldInfo FindCloneField<T>(this T source)
        {
            Type type = source.GetType();
            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                CloneObjectPlaceholderAttribute cloneAttr = fieldInfo.GetCustomAttribute<CloneObjectPlaceholderAttribute>();
                if (cloneAttr != null)
                {
                    return fieldInfo;
                }
            }
            return null;
        }

        /// <summary>
        /// Find property or field with CloneObject attribute in sourceObject and set this to clone object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="clone"></param>
        public static void SetClone(this ICloneable source)
        {
            object clone = source.Clone();
            PropertyInfo propInfo = source.FindCloneProperty();
            if (propInfo != null)
            {
                propInfo.SetValue(source, clone);
            }
            else
            {
                FieldInfo fieldInfo = source.FindCloneField();
                if (fieldInfo != null)
                {
                    fieldInfo.SetValue(source, clone);
                }
            }
        }
    }
}
