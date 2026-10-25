# Werhousmeneger

**Werhousmeneger** is a small, console-based warehouse and inventory management project written in **C#** using **.NET Framework 4.8**.

The project is designed as a practical exercise in object-oriented programming. It uses a shared base class for inventory items and derived classes for different product categories, while loading inventory records from a local JSON file.

> **Project status:** Early development. Basic item listing, creation, and removal are available. Search and saving changes back to JSON are not implemented yet.

## Features

- **List inventory items** and display their information in the console.
- **Add new items** by entering their details through interactive prompts.
- **Remove an item by ID**, with a confirmation prompt.
- **Handle four item categories** using C# inheritance.
- **Load starter inventory data** from `data.json` with Newtonsoft.Json.
- **Run locally** without a separate database server or graphical interface.

### Supported item categories

| Category | Shared fields | Additional fields |
| --- | --- | --- |
| General item | ID, weight, price, destination | — |
| Book | ID, weight, price, destination | Writer, title, page count, release year |
| Electronics | ID, weight, price, destination | Name, publisher, type |
| Furniture | ID, weight, price, destination | Type, height, width |

All categories inherit from the `Items` base class and provide their own way to print item details.

## Download and run

The easiest way to try the program is to download the prebuilt Windows ZIP from the [GitHub Releases page](https://github.com/CommanderW-se/Werhousmeneger/releases).

1. Open **Releases** and download the Windows ZIP asset (for example, `Werhousmeneger-v1.0.0-Windows.zip`).
2. **Extract the entire archive** into a folder of your choice.
3. Keep `Werhousmeneger.exe`, `Newtonsoft.Json.dll`, and `data.json` together with any other files supplied in the archive.
4. Run `Werhousmeneger.exe`.
5. Follow the numbered options shown in the console.

### System requirements

- **Operating system:** Windows
- **Runtime:** .NET Framework 4.8 or a compatible later .NET Framework 4.x version
- **Interface:** Console / command prompt
- **JSON dependency:** Newtonsoft.Json (included alongside the executable in the release package)
- **Database server:** Not required

Visual Studio is **not required** to run the prebuilt executable. If the necessary .NET Framework runtime is missing, you can get it from [Microsoft's official .NET Framework page](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48).

## Using the program

The main menu currently provides the following options:

```text
========================
1.) All items
2.) Searches
3.) Add item
4.) Remuve item by id
5.) Exit
========================
```

- **1 — All items:** Prints information about the items loaded from JSON and any items added during the current session.
- **2 — Searches:** Reserved for a future feature; selecting it currently performs no search.
- **3 — Add item:** Choose a category and enter the required item fields.
- **4 — Remove item by ID:** Enter the item ID and confirm removal.
- **5 — Exit:** Close the program.

**Note:** Items added or removed during a session are **not currently written back** to `data.json`. Restarting the program reloads the original JSON content.

## JSON data format

On startup, the program reads a file named `data.json` from its **current working directory**. The repository includes example inventory records.

Each top-level JSON key represents an inventory entry. Inside it, the category name maps to an ordered list of string values.

Example:

```json
{
  "1": {
    "Items": [
      "1",
      "2.5",
      "1500",
      "Budapest"
    ]
  },
  "2": {
    "Books": [
      "2",
      "0.75",
      "4500",
      "Debrecen",
      "J.R.R. Tolkien",
      "The Hobbit",
      "310",
      "1937"
    ]
  }
}
```

The shared values are stored in this order: **ID, weight, price, destination**. Additional category-specific values follow afterward.

Do not delete or rename `data.json` unless you also update the program to use a different path. The current code expects that file to exist when the application starts.

## Build from source

If you want to inspect or modify the code:

1. Clone the repository:
   ```bash
   git clone https://github.com/CommanderW-se/Werhousmeneger.git
   ```
2. Open `Werhousmeneger.slnx` in a compatible version of Visual Studio.
3. Restore the project's NuGet packages, including **Newtonsoft.Json 13.0.4**.
4. Select the **Release** build configuration.
5. Choose **Build → Build Solution**.
6. Find the executable in `Werhousmeneger/bin/Release/`.

If you move the built program elsewhere, copy any required DLLs and `data.json` with it.

### Technology and design

- **Language:** C#
- **Framework:** .NET Framework 4.8
- **Development environment:** Visual Studio
- **Data format:** JSON
- **Dependency:** Newtonsoft.Json
- **Concepts:** Classes, inheritance, polymorphism, generic collections, file reading, and JSON deserialization

The program keeps an in-memory `List<Items>`, allowing objects of the base `Items` type and its derived types to coexist in the same inventory collection.

## Current limitations and planned improvements

Werhousmeneger is an early-stage learning project, not a production inventory system.

Current limitations include:

- **Search is unfinished:** The search menu option does not currently perform a search.
- **Saving is unfinished:** Changes made through the add/remove menus are not persisted to JSON.
- **File location matters:** The program reads `data.json` relative to the working directory.
- **Input handling is basic:** Invalid input or malformed JSON may cause errors.
- **Console-only UI:** There is no graphical interface.

Potential future improvements include implementing searching, reliable JSON saving, better input validation and error messages, and a more user-friendly interface.

## Feedback

Suggestions, bug reports, and constructive feedback are welcome. You can use the repository's **Issues** section to report a problem or propose an improvement.

---

*Werhousmeneger is a C# learning project focused on building a simple inventory manager with object-oriented design and JSON data handling.*
