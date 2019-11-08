# Design patterns using c#
## Types of designe patterns


- [Design patterns using c](#design-patterns-using-c)
  - [Types of designe patterns](#types-of-designe-patterns)
    - [Creation](#creation)
    - [Structural](#structural)
      - [Adapter (wrapper)](#adapter-wrapper)
      - [Composite](#composite)
      - [Decorator](#decorator)
    - [Behavioral](#behavioral)
      - [Pattern](#pattern)

### Creation
### Structural
In plain words:
>Structural patterns are mostly concerned with object composition or in other words how the entities can use each other.

Wikipedia says:
>In software engineering, structural design patterns are design patterns that ease the design by identifying a simple way to realize relationships between entities.

List of patterns:
- [Adapter (wrapper)](#adapter)
- [Composite](#composite)
- [Decorator](#decorator)

#### Adapter (wrapper)
Real world example:
>Consider that you have memory card with files and you need to transfer them to your computer. In order to transfer them you need some kind of adapter that is compatible with your computer ports so that you can attach memory card to your computer. In this case card reader is an adapter.

In plain words:
>Adapter pattern lets you wrap an otherwise incompatible object in an adapter to make it compatible with another class.

Wikipedia says:
>In software engineering, the adapter pattern is a software design pattern that allows the interface of an existing class to be used as another interface. It is often used to make existing classes work with others without modifying their source code.

When to use:
>- replacing external dependencies with internal dependencies\
If we have dependence on the external Y library in class X, we can create an internal Z interface and create an external Y library adapter implementing the Z interface and use this adapter in class X.
>- adapt .net static class or custom static class to a new code\
If you have a static class used in another class that you want to test using unit tests, you can create the adapter behind which you will hide this static class.

[C# Example](tp.Adapter/Program.cs)

#### Composite
Real world example:
>The simplest example can be the directory structure in file system implementations. By deleting a given directory you will also delete all other directories inside.

In plain words:
>Composite pattern lets clients treat the individual objects in a uniform manner.

Wikipedia says:
>In software engineering, the composite pattern is a partitioning design pattern. The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

When to use:
>- application has hierarchical structure and needs generic functionality across the structure.
>- application needs to aggregate data across a hierarchy.
>- application wants to treat composite and individual objects uniformly.

[C# Example](tp.Composite/Program.cs)

#### Decorator
Real world example:
>Consider that you sell pizza. You have basic pizza. You can also order ingredients: ham and mushrooms as addition to basic pizza.
In the price list you do not put all the combinations of basic pizza and additional ingredients, but you specify the price of the basic pizza and each ingredient.\
Each ingredient is therefore a decorator that changes the price of a basic pizza.

In plain words:
>It lets you to extend the functionality of the object by dynamically adding additional behaviors.\
Its operation can be similar to inheritance, with the difference that inheritance extends class behavior during compilation and decorators extend classes during program operation.

Wikipedia says:
>In object-oriented programming, the decorator pattern is a design pattern that allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class. The decorator pattern is often useful for adhering to the Single Responsibility Principle, as it allows functionality to be divided between classes with unique areas of concern.

When to use:
>- dekorator warunkowy
>- dekorator leniwy
>- dekorator logujący
>- dekorator profilujący
>- dekorator właściwości i zdarzeń

[C# Example](tp.decorator/Program.cs)


### Behavioral


#### Pattern
Real world example:
>todo

In plain words:
>todo 

Wikipedia says:
>todo

When to use:
>todo

[C# Example]()
