using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests.Models
{
  class FruitFieldOnly : ICloneable
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public Person Owner { get; set; }

    [CloneObjectPlaceholder]
    public FruitFieldOnly CloneFruitField;

    public object Clone()
    {
      FruitFieldOnly clone = (FruitFieldOnly)MemberwiseClone();
      if (Owner != null)
      {
        clone.Owner = (Person)Owner.Clone();
      }
      return clone;
    }
  }
}
