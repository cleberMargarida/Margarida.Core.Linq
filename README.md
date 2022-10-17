[![Latest version](https://img.shields.io/nuget/v/Margarida.Core.Linq.svg)](https://www.nuget.org/packages?q=Margarida.Core.Linq) [![License LGPLv3](https://img.shields.io/badge/license-Apache-blue.svg)](https://licenses.nuget.org/Apache-1.1)

# Margarida Core Linq 
## Overview

Library based on **Linq** that allows you to transform, iterate and query using extensions and also provides some utility methods for **.NET Core applications**.

Installation
-------------

Margarida Core Linq is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package Margarida.Core.Linq
```
## Extensions
 - [For](#for) 
 - [Select](#select) 
 - [ToCompare](#tocompare) 
 - [ChunkBy](#chunkby) 
 - [DistinctBy](#distinctby) 
 - [InsertAt](#insertat) 
 - [Shuffle](#shuffle) 
 - [ForEach](#foreach) 
 - [Most](#most) 

## For

### foreach using range
Using kotlin language, when you need to iterate a range there is this native function:

```kotlin
for (int i in 0..9)
    //do something 10x
```

In C# we need to use the conventional `for` or use the enumerable extension `Range` to produce the same effect.

```csharp
for (var i = 0; i <= 9; i++)
    //do something 10x
```
```csharp
foreach (var i in Enumerable.Range(0,9))
    //do something 10x
```

But using C# 9.0 we can create extensions for implicit indexes. In this package we include this improvement, and you can use that. 

#### Usage
```csharp
 foreach (var i in 0..9)
    //do something 10x
```
### foreach using multiple variables

When we need iterate two or more sequences, there are a few ways to do it, like using conventional `for` or combining `Linq` extensions.

```csharp
 for (var i = 0; i < sequence1.Count(); i++)
 {
     var itemFromSequenceOne = sequence1[i];
     var itemFromSequenceTwo = sequence2[i];
 }
```
The problem with using this is that if you have more items in sequence than one another, an out-of-range exception can be a triggered.
<br>
<br>
In this package has been created, an extension to create a tuple between the sequences, and now you can easily iterate the two.

#### Usage
```csharp
 foreach (var item in (sequence1,sequence2))
 {
     var itemFromSequence1 = item.item1;
     var itemFromSequence1 = item.item2;
 }
```

## Select

### Select with Action
Applies an action to an instance directly and project the instance.

#### Usage
```csharp
var person = new Person { Name = "jonh" };
person.Select(x => x.Name = "jonh wick"); // set person name = "Jonh Wick"
```
### Select with Function
Projects a element of a instance into a new form. </br>
Invoking a transform function on to an instance and project the instance.

#### Usage
```csharp
Person person = new Person { Name = "Jonh Wick" };
var name = person.Select(x => x.Name); // name = "Jonh Wick"
```

### Tip 💡
Sometimes we need to execute a method and keep the instance, but we can't.
```csharp
var instance = new Instance().SetPropertyValue(1); // SetPropertyValue dont have return.
// Error CS0815  Cannot assign void to an implicitly-typed variable
```
So we need to define the instance first, then call the method.
```csharp
var instance = new Instance();
instance.SetPropertyValue(1);
```
Select with Action resolve this.
```csharp
var instance = new Instance().Select(x => x.SetPropertyValue(1));
```

## ToCompare
Compare each items in one sequence with the next.

#### Usage
```csharp
var numbers = new[] { 1, 2, 3 };
var allPreviusIsLessThenNext = numbers.ToCompare((x, y) => x < y).All;  // True
var anyPreviusIsLessThenNext = numbers.ToCompare((x, y) => x < y).Any;  // True
var nonePreviusIsLessThenNext = numbers.ToCompare((x, y) => x < y).None;// False

///combining Linq.Extensions in ToCompare for bidirectional enumerables.
var first = new[] { 1, 2, 3 };
var second = new[] { 4, 5, 6 };
var sequenceList = new[] { first, second };
var noneItemInFirstAreInTheSecond = sequenceList.ToCompare((x, y) => x.Intersect(y).Any()).None;
```

## ChunkBy
Splits the elements of a sequence into chunks of size at most size.

#### Usage
```csharp
new[] { 1, 2, 3, 4 }.ChunkBy(2); // [ { 1, 2 }, { 3, 4 }]
```

## DistinctBy
Returns distinct elements from a sequence by using a comparer.

#### Usage
```csharp
new[] { 1, 1, 1, 2 }.DistinctBy(x => x); // { 1, 2 }
```


## InsertAt
Insert into specific index a value, and move the next ones forward.

#### Usage
```csharp
new[] { -1, 0, 1, 3 }.InsertAt(2, 3); // { -1, 0, 1, 2, 3 }
```

## Shuffle
Shuffle a collection randomly.

#### Usage
```csharp
new[] { -1, 0, 1, 3 }.Shuffle() // { 0, 1, 3, -1 }
```

## ForEach
A simple way to write foreach statement in single-line.<br />
Executes a action or a body-action for each element in an enumerable. 

#### Usage
```csharp
new[] { 1, 2, 3 }.ForEach(x => 
    Console.WriteLine(x)
);

Output:
1
2
3

```

## Most
```csharp
var list = new[] { 1, 3, 2, 4, 0, -1 };
int top;

top = list.Most((x, y) => x < y); // returns the smallest of a list.
Console.WriteLine(top);

top = list.Most((x, y) => x > y); // returns the biggest of a list.
Console.WriteLine(top);

Output:
-1
 4
```

