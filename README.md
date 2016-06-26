# Managed Query


**Query** is a small component that is part of [**Managed.NET**](https://twitter.com/managed_dotnet). It's a simple data structure and set of helper methods to build an abstract representation of a search query. 

The easiest way to explain it's purpose is by example. The examples below use a "Lucene Compiler" which isn't part of **Query**. It's just one example of how you would make use of the Query object.

## Simple AND Field

```csharp
var luceneString = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants")
                   .ToQuery()
                   .ToLuceneString();

// OUTPUT: (firstname:"spongebob" AND lastname:"squarepants")
```

## Grouped AND Query

```csharp
var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

var age = Query.Field("age", 30).Or().Field("age", 31);

var luceneString = name.And(age).ToQuery().ToLuceneString();

// OUTPUT: (firstname:"spongebob" AND lastname:"squarepants" AND (age:30 OR age:31))
```

## Grouped AND Query with Range

```csharp
var name = Query.Field("firstname", "spongebob").And().Field("lastname", "squarepants");

var age = Query.Range("age", 30, 40);

var luceneString = name.And(age).ToQuery().ToLuceneString();

// OUTPUT: (firstname:"spongebob" AND lastname:"squarepants" AND (age:[30 TO 40]))
```
