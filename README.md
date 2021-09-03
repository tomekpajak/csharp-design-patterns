# Design patterns using c#
## Types of design patterns
- [Creational](#creational)
- [Structural](#structural)
- [Behavioral](#behavioral)

### Creational
In plain words:
>Creational patterns allow to abstract the process of creating objects in an abstract form. 
These patterns encapsulate information from which specific classes we use to create an object. Additionally, the process of creating and assembling / building these objects is hidden. These patterns offer great flexibility in WHAT is created, WHO does it, HOW it's done and WHEN.

Wikipedia says:
>In software engineering, creational design patterns are design patterns that deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. The basic form of object creation could result in design problems or added complexity to the design. Creational design patterns solve this problem by somehow controlling this object creation.

Additional information:
>

List of patterns:
- [Builder](#builder)
- [Factory Method & Abstract Factory](#factories)
- [Prototype](#prototype)
- [Singleton](#singleton)

#### Builder
Real world example:
>Imagine you want to make a pizza. Pizza can consist of various ingredients. You can make basic pizza and pizzas with many different ingredients. Each pizza will have its own "builder".

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
>- helpful during writing automated tests

Builder vs Abstract Factory:
>The builder pattern describes the creation of complex objects step by step. In the abstract factory pattern, accent is placed on families of object-products

[C# Example](tp.Builder/Program.cs)

#### Factories
##### Factory Method
Real world example:
>Imagine you want to buy HP laptop. You re visiting store where you can order to various models HP laptop. When you place an order, it is sent to the factory that will produce for you the laptop you ordered.

In plain words:
>Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

Wikipedia says:
>In class-based programming, the factory method pattern is a creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of the object that will be created. This is done by creating objects by calling a factory method—either specified in an interface and implemented by child classes, or implemented in a base class and optionally overridden by derived classes—rather than by calling a constructor.

When to use:
>- for creating objects to encapsulate the instantiation logic. Client doesn’t know the actual instantiation logic of entity
>- object creation logic is sometimes too complicated and using constructors to create objects has many limitations, e.g.:
>>- the name of the constructor must be exactly the same as the class name (you cannot use the name to provide additional information on how to create the object or parameters that are used)
>>-  you cannot overload a constructor with the same sets of parameter types
>->  "optional parameters hell" may occur

[C# Example](tp.FactoryMethod/Program.cs)

##### Abstract Factory
Real world example:
>Imagine you want to buy laptop. You are visiting store where you can order two brand laptop HP and Apple. Each laptop is made by different factory and contains different processor and storage. 

In plain words:
>Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

Wikipedia says:
>The abstract factory pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.

When to use:
>- a system should be independent of how its products are created, composed, and represented
>- a system should be configured with one of multiple families of products
>- a family of related product objects is designed to be used together, and you need to enforce this constraint
>- you want to provide a class library of products, and you want to reveal just their interfaces, not their implementations

[C# Example](tp.AbstractFactory/Program.cs)

#### Factories - using abstract classes or interfaces
Consider using abstract classes if:
>- you want to share code among several closely related classes
>- you expect that classes that extend your abstract class have many common methods or fields, or require access modifiers other than public (such as protected and private)
>- you want to declare non-static or non-final fields. This enables you to define methods that can access and modify the state of the object to which they belong

Consider using interfaces if:
>- you expect that unrelated classes would implement your interface. For example, the interfaces Comparable and Cloneable are implemented by many unrelated classes
>- you want to specify the behavior of a particular data type, but not concerned about who implements its behavior
>- you want to take advantage of multiple inheritance of type


#### Prototype
Real world example:
>Do you remember a sheep named Dolly? She was cloned. Without going into details, this pattern is associated with cloning...

In plain words:
>It allows you to create a copy of an existing object and modify it to your needs, instead of going through the trouble of creating an object from scratch and setting it up 

Wikipedia says:
>The prototype pattern is a creational design pattern in software development. It is used when the type of objects to create is determined by a prototypical instance, which is cloned to produce new objects.

When to use:
>- composition, creation and representation of objects should be decoupled from the system
>- classes to be created are specified at runtime
>- you need to hide the complexity of creating new instance from the client
>- creating an object is an expensive operation and it would be more efficient to copy an object
>- objects are required that are similar to existing objects

Shallow cloning vs deep cloning:
>The **shallow copy** of an object will have the exact copy of all the fields of original object. If original object has any references to other objects as fields, then only references of those objects are copied into clone object, copy of those objects are not created. That means any changes made to those objects through clone object will be reflected in original object or vice-versa.

>**Deep copy** of an object will have exact copy of all the fields of original object just like shallow copy. But in additional, if original object has any references to other objects as fields, then copy of those objects are also created by calling clone() method on them or by creating new object and setting the original values in it. That means clone object and original object will be 100% disjoint. They will be 100% independent of each other.

ICloneable problems:
>- does not specify whether cloning should be shallow or deep so we don't know what to expect
>- return object type instead of strong type
>- description of Array.Clone: "Creates a shallow copy of the System.Array" so if we have shallow copying here, why should we do something more?

[C# Example](tp.Prototype/Program.cs)

#### Singleton
Real world example:
>Suppose you want to create a service with which you can log various information in the application. One of the implementation methods is to create a singleton object that will login.

In plain words:
>Ensure a class has only one instance and provide a global point of access to it 

Wikipedia says:
>In software engineering, the singleton pattern is a software design pattern that restricts the instantiation of a class to one "single" instance

When to use:
>useful when exactly one object is needed to coordinate actions across the system

[C# Example](tp.Singleton/Program.cs)

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
If we have dependence on the external Y library in class X, we can create an internal Z interface and create an external Y library adapter implementing the Z interface and use this adapter in class X
>- adapt .net static class or custom static class to a new code\
If you have a static class used in another class that you want to test using unit tests, you can create the adapter behind which you will hide this static class

[C# Example](tp.Adapter/Program.cs)

#### Composite
Real world example:
>The simplest example can be the directory structure in file system implementations. By deleting a given directory you will also delete all other directories inside.

In plain words:
>Composite pattern lets clients treat the individual objects in a uniform manner.

Wikipedia says:
>The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

When to use:
>- application has hierarchical structure and needs generic functionality across the structure
>- application needs to aggregate data across a hierarchy
>- application wants to treat composite and individual objects uniformly

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
[C# Example](tp.decorator/Program.cs)

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
In plain words:
> Behavioral patterns are concerned with the assignment of responsibilities between objects, or, encapsulating behavior in an object and delegating requests to it.

Wikipedia says:
> In software engineering, behavioral design patterns are design patterns that identify common communication patterns among objects and realize these patterns. By doing so, these patterns increase flexibility in carrying out this communication.

List of patterns:
- [Chain of responsibility](#chain-of-responsibility)
- [Command](#command)
- [Iterator](#iterator)
- [Mediator](#mediator)
- [Memento](#memento)
- [Observer]()
- [State]()
- [Strategy]()
- [Template method]()
- [Visitor]()

#### Chain of responsibility
Real world example:
>Let's assume that you are working in a corporation with a certain process of accepting a holiday form.
It consists of the fact that first your holiday form must be approved by the person who will replace you at work, then by your manager and finally by the HR department.
In this way, we have created a chain of responsibility, in which a request is the holiday form and the handler is each subsequent person deciding on your holiday form.  

In plain words:
>Lets you pass requests along a chain of handlers. Upon receiving a request, each handler decides either to process the request or to pass it to the next handler in the chain.

Wikipedia says:
>In object-oriented design, the chain-of-responsibility pattern is a design pattern consisting of a source of command objects and a series of processing objects. Each processing object contains logic that defines the types of command objects that it can handle; the rest are passed to the next processing object in the chain.

When to use:
>- have more than one handler for a request
>- you have reasons why a handler should pass a request on to another one in the chain
>- you have a set of handlers that varies dynamically
>- you want to retain flexibility in assigning requests to handlers

[C# Example](tp.ChainOfResponsibility/Program.cs)

#### Command
Real world example:
>Suppose you want to make a transfer from account X to account Y. You make a withdrawal on account X and you make a payment on account Y. We can treat deposit and withdrawal as Command.

In plain words:
>Command turns a request into a stand-alone object that contains all information about the request. This transformation lets you parameterize methods with different requests, delay or queue a request’s execution, and support undoable operations. 

Wikipedia says:
>In object-oriented programming, the command pattern is a behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time. This information includes the method name, the object that owns the method and values for the method parameters.

When to use:
>- you need to execute tasks, but you want to separate the tasks management from the execution of the task itself
>- you want to queue tasks, schedule their execution, or execute them remotely
>- you want to parametrize objects with tasks
>- you need to support Redo and Undo functionality

[C# Example](tp.Command/Program.cs)

#### Iterator
Real world example:
>Let's assume that you have a media player. In media players, we have a list of songs. We can traverse to the desired song by choosing the next button and play the song. It’s also an iterator example.

In plain words:
>An iterator pattern provides a way of accessing elements of a collection sequentially, without knowing how the collection is structured.

Wikipedia says:
>In object-oriented programming, the iterator pattern is a design pattern in which an iterator is used to traverse a container and access the container's elements. The iterator pattern decouples algorithms from containers; in some cases, algorithms are necessarily container-specific and thus cannot be decoupled.

When to use:
>- you want to access a collection of objects without exposing its internal representation
>- there are multiple traversals of objects need to be supported in the collection

[C# Example](tp.Iterator/Program.cs)

#### Mediator
Real world example:
>Let's assume you have many friends with whom you want to talk. For this purpose, you do not connect to each of them with a special "cable" but you use, for example, a special application for communication or use the phone network. In this case, the communication application and the phone network act as a mediator.

In plain words:
>Mediator helps in establishing loosely coupled communication between objects and helps in reducing the direct references to each other.

Wikipedia says:
>In software engineering, the mediator pattern defines an object that encapsulates how a set of objects interact. This pattern is considered to be a behavioral pattern due to the way it can alter the program's running behavior.

When to use:
>- you have communication between multiple objects is well defined but complex
>- you have too many relationships exist and a common point of control or communication is required

[C# Example](tp.Mediator/Program.cs)

#### Memento
Real world example:
>Suppose you are working on a system to handle surveys. One of the functionalities is to be able to save the current status of the survey by the user so that you can return to it later.

In plain words:
>The memento allows you to remember, store and restore the state of an object.

Wikipedia says:
>The memento pattern is a software design pattern that provides the ability to restore an object to its previous state (undo via rollback).

When to use:
>- when object’s state is continuously changing and the user of the application may decide to rollback or undo the changes changes at any point
>- when applications which must be restarted from their last known working state or draft. An example of this can be an IDE which restart from changes, user made before closing the IDE.

[C# Example](tp.Memento/Program.cs)

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
