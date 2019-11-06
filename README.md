# Design patterns using c#
This is my sandbox for design patterns in c#

## Types of designe patterns


- [Design patterns using c](#design-patterns-using-c)
  - [Types of designe patterns](#types-of-designe-patterns)
    - [Creation](#creation)
    - [Structural](#structural)
      - [Adapter](#adapter)
      - [Composite](#composite)
    - [Behavioral](#behavioral)

### Creation
### Structural
In plain words:
>Structural patterns are mostly concerned with object composition or in other words how the entities can use each other. Or yet another explanation would be, they help in answering "How to build a software component?"

Wikipedia says:
>In software engineering, structural design patterns are design patterns that ease the design by identifying a simple way to realize relationships between entities.

List of patterns:
- [Adapter](#adapter)
- [Composite](#composite)
#### Adapter
Real world example:
>Consider that you have some pictures in your memory card and you need to transfer them to your computer. In order to transfer them you need some kind of adapter that is compatible with your computer ports so that you can attach memory card to your computer. In this case card reader is an adapter

In plain words:
>Adapter pattern lets you wrap an otherwise incompatible object in an adapter to make it compatible with another class.\
Umożliwia wykorzystanie klasy A implementującej interfejs A przez klienta, który oczekuje interfejsu B.\
W tym celu tworzy się klasę AdapterA implementującą imterfejs B, gdzie poszczególne metody interfejsu B są delegowane do metod interfejsu A.

Wikipedia says:
>In software engineering, the adapter pattern is a software design pattern that allows the interface of an existing class to be used as another interface. It is often used to make existing classes work with others without modifying their source code.

Application example:
>Jednym z zastosowań wzorca adapter jest zamiana zależności zewnętrznych na zależności wewnętrzne.\
Np. w usłudze mamy zależność od zewnętrznej biblioteki logującej. 
Jeśli utworzymy wewnętrzny interfejs ILogger oraz stworzymy adapter zewnętrznej biblioteki implementujący interfejs ILogger zmienimy zewnętrzną zależność na zależność wewnętrzną.

[C# Example](tp.Adapter/Program.cs)

#### Composite
Real world example:
>todo

In plain words:
>Composite pattern lets clients treat the individual objects in a uniform manner.

Wikipedia says:
>In software engineering, the composite pattern is a partitioning design pattern. The composite pattern describes that a group of objects is to be treated in the same way as a single instance of an object. The intent of a composite is to "compose" objects into tree structures to represent part-whole hierarchies. Implementing the composite pattern lets clients treat individual objects and compositions uniformly.

Application example:
>todo

[C# Example](tp.tp.Composite/Program.cs)

### Behavioral
