using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi.ObjectDiffer.Tests
{
  [TestFixture(Category = "DefaultNodeFactory")]
  class DefaultNodeFactoryTest
  {
    [Test]
    public void NodeFactory_NodeProperties_Equal()
    {
      INodeFactory nodeFactory = new DefaultNodeFactory();

      string nodeName = "Node";
      object oldItem = 1;
      object newItem = 2;
      INode generatedNode = nodeFactory.CreateNode(nodeName, null, oldItem, newItem);

      Assert.IsNotNull(generatedNode);
      Assert.IsInstanceOf<Node>(generatedNode);
      Assert.AreEqual(nodeName, generatedNode.Name);
      Assert.AreEqual(oldItem, generatedNode.OldItem);
      Assert.AreEqual(newItem, generatedNode.NewItem);
    }

    [Test]
    public void NodeFactory_NodeWithLeftNodeProperties_Equal()
    {
      INodeFactory nodeFactory = new DefaultNodeFactory();

      string leftNodeName = "Left node";
      INode generatedLeftNode = nodeFactory.CreateNode(leftNodeName, null, null, null);
      string nodeName = "Node";
      object oldItem = "One";
      object newItem = "Two";
      INode generatedNode = nodeFactory.CreateNode(nodeName, generatedLeftNode, oldItem, newItem);

      Assert.IsNotNull(generatedLeftNode);
      Assert.IsInstanceOf<Node>(generatedLeftNode);
      Assert.AreEqual(leftNodeName, generatedLeftNode.Name);
      Assert.IsNull(generatedLeftNode.OldItem);
      Assert.IsNull(generatedLeftNode.NewItem);
      Assert.IsNotNull(generatedNode);
      Assert.IsInstanceOf<Node>(generatedNode);
      Assert.AreEqual(nodeName, generatedNode.Name);
      Assert.AreEqual(oldItem, generatedNode.OldItem);
      Assert.AreEqual(newItem, generatedNode.NewItem);
    }
  }
}
