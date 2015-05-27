using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests
{
  [TestFixture(Category = "CloneObjectPlaceholderExtensions")]
  class CloneObjectPlaceholderExtensionsTest
  {
    [Test]
    public void FindClone_CloneProperty_Equal()
    {
      Models.Fruit fruit = new Models.Fruit
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };
      fruit.CloneFruit = (Models.Fruit)fruit.Clone();

      Models.Fruit clonedFruit = fruit.FindClone();

      Assert.IsNotNull(clonedFruit);
      Assert.AreEqual(fruit.CloneFruit, clonedFruit);
    }

    [Test]
    public void FindClone_CloneField_Equal()
    {
      Models.FruitFieldOnly fruit = new Models.FruitFieldOnly
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };
      fruit.CloneFruitField = (Models.FruitFieldOnly)fruit.Clone();

      Models.FruitFieldOnly clonedFruit = fruit.FindClone();

      Assert.IsNotNull(clonedFruit);
      Assert.AreEqual(fruit.CloneFruitField, clonedFruit);
    }

    [Test]
    public void FindClone_CloneObjectPlaceholderAttribute_MustBeNull()
    {
      Models.Person person = new Models.Person
      {
        Id = 1,
        Name = "John Doe"
      };

      Models.Person clonedPerson = person.FindClone();

      Assert.AreEqual(default(Models.Person), clonedPerson);
    }

    [Test]
    public void FindCloneProperty_PropertyInfo_Equal()
    {
      Models.Fruit fruit = new Models.Fruit
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };
      fruit.CloneFruit = (Models.Fruit)fruit.Clone();

      PropertyInfo propertyInfo = fruit.FindCloneProperty();

      Assert.IsNotNull(propertyInfo);
      Assert.AreEqual("CloneFruit", propertyInfo.Name);
    }

    [Test]
    public void FindCloneField_FieldInfo_Equal()
    {
      Models.FruitFieldOnly fruit = new Models.FruitFieldOnly
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };
      fruit.CloneFruitField = (Models.FruitFieldOnly)fruit.Clone();

      FieldInfo fieldInfo = fruit.FindCloneField();

      Assert.IsNotNull(fieldInfo);
      Assert.AreEqual("CloneFruitField", fieldInfo.Name);
    }

    [Test]
    public void FindCloneField_FieldInfo_MustBeNull()
    {
      Models.Person person = new Models.Person
      {
        Id = 1,
        Name = "John Doe"
      };

      FieldInfo fieldInfo = person.FindCloneField();

      Assert.IsNull(fieldInfo);
    }

    [Test]
    public void SetClone_CloneProperty_IsSet()
    {
      Models.Fruit fruit = new Models.Fruit
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };

      fruit.SetClone();

      Assert.IsNotNull(fruit.CloneFruit);
    }

    [Test]
    public void SetClone_CloneField_IsSet()
    {
      Models.FruitFieldOnly fruit = new Models.FruitFieldOnly
      {
        Id = 1,
        Name = "Apple",
        Color = "Green"
      };

      fruit.SetClone();

      Assert.IsNotNull(fruit.CloneFruitField);
    }

    [Test]
    public void SetClone_CloneField_NoException()
    {
      Models.Person person = new Models.Person
      {
        Id = 1,
        Name = "John Doe"
      };

      person.SetClone();
    }
  }
}
