using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests
{
  [TestFixture(Category="Node")]
  class NodeTest
  {
    [Test]
    public void Node_FullName_Equal()
    {
      Node node = new Node();
      node.Name = "Id";
      node.OldItem = 1;
      node.NewItem = 2;
      
      string fullName = node.FullName;

      Assert.NotNull(fullName);
      Assert.AreEqual("Id", fullName);
    }

    [Test]
    public void NodeWithLeftNode_FullName_Equal()
    {
      Node leftNode = new Node();
      leftNode.Name = "Fruit";
      Node node = new Node();
      node.Name = "Name";
      node.OldItem = "Apple";
      node.NewItem = "Banana";
      node.Left = leftNode;

      string fullName = node.FullName;

      Assert.NotNull(fullName);
      Assert.NotNull(node.Left);
      Assert.AreEqual("Fruit.Name", fullName);
    }
  }
}
