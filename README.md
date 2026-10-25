# Pet Shop 🐹🕷️🐦

An object-oriented model of a pet shop in C# (.NET 8). Owners and shops buy and sell animals, invoices are created for every deal that involves a shop, and the shop can report its partners and its profit for a given time period. The project includes MSTest unit tests and a design document.

## The model

- **Owners** have a name, an address, an ID number and a list of animals. They can buy and sell animals.
- **Shops** are a special kind of owner. They add a markup when selling, and they keep track of their **trading partners**.
- **Animals** come in three species, `Hamster`, `Finch` and `Tarantula`. Each has a unique ID, a color, an age and a base value.
- **Certificates (invoices)** record the buyer, seller, price, date and animal. One is created only when a shop takes part in the sale, and both sides keep a copy.

### Pricing

An animal's current value is its base value multiplied by a **color multiplier**: white ×4, grey ×2, black and brown ×1. **Tarantulas** are the exception, since they're always worth their base value. Shops add a markup on top when they sell.

## Features

The program can answer these questions:

- Does an owner have a finch of a given color?
- How many hamsters does an owner have?
- How many invoices does an owner have from a given shop?
- What is a shop's most expensive tarantula?
- How many partners does a shop have?
- Does an owner have a given animal?
- What is a shop's **profit** in a given period (sales minus purchases)?

## Design patterns

- **Visitor:** `ColorVisitor` works out each species' value, so the pricing logic stays outside the animal classes.
- **Singleton:** `PossessionReader` loads owners and their animals from text files.
- **Inheritance and polymorphism:** `Shop` extends `Owner` and overrides `Sell` and `Buy`.

The full design, with use case, object, communication and state diagrams, is in [`terv.pdf`](terv.pdf). It's written in Hungarian.

## Input file format

The first line holds the owner's details. Each line after it describes one animal:

```
<name> <address> <id>
<Species> <animalId> <COLOR> <value> <age>
```

For example:

```
bolt kisallatutca3 1234
Finch Bodri WHITE 8000 2
Finch Madarka BROWN 9000 1
```

Invalid lines are skipped with an error message: an unknown species or color, a negative value or age, a non-integer number, or missing fields. Sample files, valid and invalid, are in `Tesztfajlok/`.

## Running it

You need the [.NET 8 SDK](https://dotnet.microsoft.com/download).

The demo program reads its input files from the folder you run it in, so start it from `Tesztfajlok`:

```
cd Tesztfajlok
dotnet run --project ../Kisallatkereskedes
```

You can also open `Kisallatkereskedes.sln` in Visual Studio.

### Tests

```
dotnet test
```

The tests cover selling between owners and shops, revenue calculation, invoice counting, the color visitor, finch lookup and file reading. They look for the sample files from `Tesztfajlok/` in the test output folder.

## Project structure

```
├── Kisallatkereskedes/      # main project: Animal, Owner, Shop, Certificate, Color, ValueVisitor, PossessionReader
├── TestProject1/            # MSTest unit tests
├── Tesztfajlok/             # sample input files
├── terv.pdf                 # design document with UML diagrams (Hungarian)
└── Kisallatkereskedes.sln
```

## About

A university object-oriented programming assignment (2025). Some comments and the console output are in Hungarian.
