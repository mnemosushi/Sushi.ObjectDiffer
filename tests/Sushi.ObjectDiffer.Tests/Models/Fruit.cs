using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests.Models
{
  class Fruit : ICloneable
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public Person Owner { get; set; }

    [CloneObjectPlaceholder]
    public Fruit CloneFruit { get; set; }

    public object Clone()
    {
      Fruit clone = (Fruit)MemberwiseClone();
      if (Owner != null)
      {
        clone.Owner = (Person)Owner.Clone();
      }
      return clone;
    }
  }
}
