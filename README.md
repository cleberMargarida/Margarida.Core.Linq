[![Latest version](https://img.shields.io/nuget/v/Margarida.Core.Attributes.svg)](https://www.nuget.org/packages?q=Margarida.Core.Attributes) [![License LGPLv3](https://img.shields.io/badge/license-LGPLv3-green.svg)](https://www.gnu.org/licenses/lgpl-3.0.html)

# Margarida Core Linq 
## Overview
Personal  **Linqs** Extensions for **.NET Core applications**

Installation
-------------

Margarida Core Linq is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package Margarida.Core.Linq
```

## Extensions
 - [ToCompare](#tocompare) 
 - [ChunkBy](#chunkby) 
 - [DistinctBy](#distinctby) 
 - [InsertAt](#insertat) 
 - [Shuffle](#shuffle) 
 - [ForEach](#foreach) 
 - [Most](#most) 
  
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
Executes a statement or a block of statements for each element in an enumerable.

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

top = list.Most((x, y) => x > y); // returns the biggest of a list.
```
