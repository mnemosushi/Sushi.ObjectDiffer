using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests
{
    [TestFixture(Category="ObjectDiffer")]
    class ObjectDifferTest
    {
        public Models.Fruit PrepareFruitWithChanges()
        {
            Models.Fruit fruit = new Models.Fruit();
            fruit.Id = 1;
            fruit.Name = "Apple";
            fruit.Color = "Green";
            fruit.Owner = new Models.Person();
            fruit.Owner.Id = 1;
            fruit.Owner.Name = "Me";
            fruit.SetClone();
            fruit.Color = "Yellow";
            fruit.Owner.Name = "You";
            return fruit;
        }

        public Models.Fruit PrepareFruitWithoutChanges()
        {
            Models.Fruit fruit = new Models.Fruit();
            fruit.Id = 1;
            fruit.Name = "Apple";
            fruit.Color = "Green";
            fruit.Owner = new Models.Person();
            fruit.Owner.Id = 1;
            fruit.Owner.Name = "Me";
            fruit.SetClone();
            return fruit;
        }

        public Models.Fruit PrepareFruitWithoutClone()
        {
            Models.Fruit fruit = new Models.Fruit();
            fruit.Id = 1;
            fruit.Name = "Apple";
            fruit.Color = "Green";
            fruit.Owner = new Models.Person();
            fruit.Owner.Id = 1;
            fruit.Owner.Name = "Me";
            return fruit;
        }

        [Test]
        public void DifferCloneByReflection_NodeCollection_NotNull()
        {
            Models.Fruit fruit = PrepareFruitWithChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.IsNotNull(nodeCollection);
        }

        [Test]
        public void DifferCloneByReflection_Item_NotNull()
        {
            Assert.Catch<ArgumentException>(() =>
            {
                ObjectDiffer.DifferCloneByReflection<Models.Fruit>(null);
            });
        }

        [Test]
        public void DifferCloneByReflection_CloneItem_NotNull()
        {
            Models.Fruit fruit = PrepareFruitWithoutClone();

            Assert.Catch<ArgumentException>(() =>
            {
                ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);
            });
        }

        [Test]
        public void DifferCloneByReflection_NodeCollection_Empty()
        {
            Models.Fruit fruit = PrepareFruitWithoutChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.AreEqual(0, nodeCollection.Count);
        }

        [Test]
        public void DifferCloneByReflection_NodeCollection_NotEmpty()
        {
            Models.Fruit fruit = PrepareFruitWithChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.AreEqual(2, nodeCollection.Count);
        }

        [Test]
        public void DifferCloneByReflection_FullName_AreEqual()
        {
            Models.Fruit fruit = PrepareFruitWithChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.AreEqual("Color", nodeCollection.First().FullName);
            Assert.AreEqual("Owner.Name", nodeCollection.Last().FullName);
        }

        [Test]
        public void DifferCloneByReflection_Name_AreEqual()
        {
            Models.Fruit fruit = PrepareFruitWithChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.AreEqual("Color", nodeCollection.First().Name);
            Assert.AreEqual("Name", nodeCollection.Last().Name);
        }

        [Test]
        public void DifferCloneByReflection_OldNewItem_AreEqual()
        {
            Models.Fruit fruit = PrepareFruitWithChanges();

            ICollection<INode> nodeCollection = ObjectDiffer.DifferCloneByReflection<Models.Fruit>(fruit);

            Assert.AreEqual("Green", nodeCollection.First().OldItem);
            Assert.AreEqual("Yellow", nodeCollection.First().NewItem);
            Assert.AreEqual("Me", nodeCollection.Last().OldItem);
            Assert.AreEqual("You", nodeCollection.Last().NewItem);
        }

        [Test]
        public void DifferByReflection_OldItem_NotNull()
        {
            Models.Fruit fruita = PrepareFruitWithoutClone();

            Assert.Catch<ArgumentNullException>(() =>
            {
                ICollection<INode> nodeCollection = ObjectDiffer.DifferByReflection(fruita, null);
            });
        }

        [Test]
        public void DifferByReflection_NewItem_NotNull()
        {
            Models.Fruit fruitb = PrepareFruitWithoutClone();

            Assert.Catch<ArgumentNullException>(() =>
            {
                ICollection<INode> nodeCollection = ObjectDiffer.DifferByReflection(null, fruitb);
            });
        }

        [Test]
        public void DifferByReflection_FullName_AreEqual()
        {
            Models.Fruit fruita = PrepareFruitWithoutClone();
            Models.Fruit fruitb = PrepareFruitWithoutClone();
            fruitb.Name = "Banana";
            fruitb.Color = "Yellow";

            ICollection<INode> nodeCollection = ObjectDiffer.DifferByReflection(fruita, fruitb);

            Assert.AreEqual("Name", nodeCollection.First().FullName);
            Assert.AreEqual("Color", nodeCollection.Last().FullName);
        }

        [Test]
        public void DifferByReflection_Name_AreEqual()
        {
            Models.Fruit fruita = PrepareFruitWithoutClone();
            Models.Fruit fruitb = PrepareFruitWithoutClone();
            fruitb.Name = "Banana";
            fruitb.Color = "Yellow";

            ICollection<INode> nodeCollection = ObjectDiffer.DifferByReflection(fruita, fruitb);

            Assert.AreEqual("Name", nodeCollection.First().Name);
            Assert.AreEqual("Color", nodeCollection.Last().Name);
        }
    }
}
