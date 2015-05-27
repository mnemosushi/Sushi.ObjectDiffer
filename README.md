# Sushi.ObjectDiffer
Compare two objects of the same type

## Example usages

**Compare two objects:**

    ICollection<INode> changeNodes = ObjectDiffer.DifferByReflection<T>(itema, itemb);

**Compare two objects with custom ObjectDiffer:**

    IObjectDiffer<T> objectDiffer = new MyOwnObjectDiffer(); // Your implementation
    ICollection<INode> changeNodes = ObjectDiffer.Differ<T>(objectDiffer, itema, itemb);

**Compare with clone** 

One of the property/field in object must contains CloneObjectPlaceholder:

    ObjectDiffer.DifferCloneByReflection<T>(item);

## Clone helpers

Project includes clone helper functions which can be usefull for 
cloning objects.

**Marking clone placeholders**

You can mark property or field as object to save clone of the object itself with CloneObjectPlaceholder attribute:

    class Fruit {
        public int Id { get; set; }
        public string Name { get; set; }

        [CloneObjectPlaceholder]
        public Fruit Old { get; set; }
    }

**Get clone**

    Fruit currentFruit = new Fruit();
    Fruit oldFruit = currentFruit.FindClone();

**Set clone** 

    Fruit currentFruit = new Fruit();
    currentFruit.SetClone(); // Works only if Fruit inherits ICloneable

