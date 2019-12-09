# Design patterns using c#
## Types of designe patterns
- [Creational](#sreational)
- [Structural](#structural)
- [Behavioral](#behavioral)

### Creational
In plain words:
>Creational patterns allow to abstract the process of creating objects in an abstract form. 
Wzorce te kapsułkują informację z któych konkretnych klas korzystamy do tworzenia obiektu. Dodatkowo ukrywany jest proces tworzenia i składania/budowania tych obiektów.
Wzorce te dają dużą elastyczność w zakresie tego CO jest tworzone, KTO to robi, JAK jest to robione i KIEDY.

Wikipedia says:
>In software engineering, creational design patterns are design patterns that deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. The basic form of object creation could result in design problems or added complexity to the design. Creational design patterns solve this problem by somehow controlling this object creation.

Additional information:
>

List of patterns:
- [Design patterns using c](#design-patterns-using-c)
  - [Types of designe patterns](#types-of-designe-patterns)
    - [Creational](#creational)
      - [Builder](#builder)
      - [Abstract Factory](#abstract-factory)
      - [Factory Method](#factory-method)
      - [Prototype](#prototype)
      - [Singleton](#singleton)
    - [Structural](#structural)
      - [Adapter (wrapper)](#adapter-wrapper)
      - [Composite](#composite)
      - [Decorator](#decorator)
      - [Proxy](#proxy)
      - [Facade](#facade)
    - [Behavioral](#behavioral)
      - [Pattern](#pattern)

#### Builder
Real world example:
>Imagine you want to make pizza. Pizza can consist of various ingredients. You can make basic pizza and pizzas with many different ingredients. Each pizza will have its own "builder".

In plain words:
>Pattern where the process of creating an object is divided into several smaller stages, and each of them can be implemented in many ways. Thanks to this solution it is possible to create different representations of objects in the same construction process. 

Wikipedia says:
>The builder pattern is a design pattern designed to provide a flexible solution to various object creation problems. The intent of the Builder design pattern is to separate the construction of a complex object from its representation.

Telescoping Constructor anti-pattern
>In this anti-pattern, your class has numerous constructors each one taking a different number of parameters, so you can instantiate that class with the correct combination of parameters on each situation, but that at the end, if the class has been properly written, all this constructors delegate to a default constructor.

So what is the problem with that?
>The problem with this is that once your class has to much constructors and constructors are 4 or more parameters long it becomes difficult to remember the required order of the parameters as well as what particular constructor you might want in a given situation. Giving yourself and your fellow developers a hard time trying to initialize that class.

When to use:
>- solve the telescoping constructor problem
>- for objects that contain flat data (e.g.: html code, SQL query, X.509 certificate)


Builder vs Abstract Factory:
>The builder pattern describes the creation of complex objects step by step. In the abstract factory pattern, accent is placed on families of object-products

[C# Example](tp.Builder/Program.cs)

#### Abstract Factory

#### Factory Method

#### Prototype

#### Singleton

### Structural
In plain words:
>Structural patterns are mostly concerned with object composition or in other words how the entities can use each other.

Wikipedia says:
>In software engineering, structural design patterns are design patterns that ease the design by identifying a simple way to realize relationships between entities.

List of patterns:
- [Adapter (wrapper)](#adapter-wrapper)
- [Composite](#composite)
- [Decorator](#decorator)
- [Proxy](#proxy)
- [Facade](#facade)

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
>The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

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

Example of using:
> - conditional decorator
> - lazy decorator
> - logging decorator
> - profiling decorator
> - decorator of properties and events
> 
[C# Example](tp.Decorator/Program.cs)

#### Proxy
Real world example:
>A company or corporate used to have a proxy which restricts few site access. The proxy first checks the host you are connecting to, if it is not a part of restricted site list, then it connects to the real internet.

In plain words:
>The pattern goal is to build a class that replaces/emulates the behavior of another class/object

Wikipedia says:
>A proxy, in its most general form, is a class functioning as an interface to something else. A proxy is a wrapper or agent object that is being called by the client to access the real serving object behind the scenes. Use of the proxy can simply be forwarding to the real object, or can provide additional logic. In the proxy extra functionality can be provided, for example caching when operations on the real object are resource intensive, or checking preconditions before operations on the real object are invoked.

When to use:
>- access control to the protected object - e.g. access to data after user authorization
>- delay of creating an expensive object, the object is created when it is necessary - creation on demand
>- remote object emulation, e.g. object data is sent over the internet
>- caching of certain object data - some class data may take a long time to convert or be converted earlier


[C# Example](tp.Proxy/Program.cs)

#### Facade 
Real world example:
>In the car we have ability to drive in two directions: forward and backward. Many complex "systems" must work inside the car to make this possible. However the car provides us the gearbox - simple interface used to choose the direction of travel. The gearbox is our facada.

In plain words:
>Façade defines a higher-level interface that makes the complex subsystem easier to use. 

Wikipedia says:
>A facade is an object that provides a simplified interface to a larger body of code, such as a class library.

When to use:
>- when we need to make complex subsystem easy to use

[C# Example](tp.Facade/Program.cs)


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
