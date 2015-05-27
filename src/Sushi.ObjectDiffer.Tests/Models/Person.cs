using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests.Models
{
  class Person : ICloneable
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public object Clone()
    {
      return this.MemberwiseClone();
    }
  }
}
