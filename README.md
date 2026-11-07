## 🌐 Jazyk / Language Selection

*Klikněte na sekci níže pro zobrazení v češtině nebo angličtině.*
*Click on a section below to toggle between Czech and English.*

---

<details open>
<summary>🇨🇿 <strong>ČEŠTINA (Czech Version)</strong></summary>

# TextHelper

Knihovna pro validované zadávání vstupů od uživatele v konzolových aplikacích, s automatickým opakováním dotazu při neplatném vstupu.

## Filozofie

Metoda `ZeptejSeAUprav` odděluje zobrazení hodnoty, parsování vstupu a logiku "chci upravit / nechci upravit" od samotné aplikace. Pokud parsovací funkce vyhodí výjimku (např. z `TitleCase`, `int.Parse`, `DateOnly.Parse`), knihovna zobrazí konkrétní chybovou zprávu a vyzve uživatele k novému zadání – programátor nemusí psát vlastní `try/catch` smyčky.

## Metoda

### `UpravaVstupu.ZeptejSeAUprav<T>`

```csharp
public static T ZeptejSeAUprav<T>(
    T aktualni,
    string popis,
    Func<T, string> formatter,
    Func<string, T> parser,
    bool jeNove = false)
```

- `aktualni` – výchozí/aktuální hodnota
- `popis` – název položky pro zobrazení uživateli (např. "jméno")
- `formatter` – jak zobrazit aktuální hodnotu
- `parser` – jak zpracovat text ze vstupu; při neplatném vstupu vyhodí výjimku
- `jeNove` – `true` u zcela nové hodnoty (rovnou se zeptá na vstup), `false` u úpravy existující hodnoty (nejdřív se zeptá, zda ji chce uživatel měnit)

## Použití

```csharp
using TextHelper;

int mzda = UpravaVstupu.ZeptejSeAUprav(
    0, "mzda",
    v => v.ToString(),
    s => int.Parse(s),
    jeNove: true);
```

Při neplatném vstupu se zobrazí konkrétní chybová hláška (`ex.Message`) a uživatel je vyzván k novému zadání, dokud nezadá platnou hodnotu.

## Instalace jako NuGet balíček

Tato knihovna je dostupná také jako balíček v **GitHub Packages**. Můžete si ji snadno přidat do svého projektu:

1. Nastavte si jako zdroj balíčků váš GitHub (pokud ho ještě nemáte v NuGet.config).
2. V **Package Manager Console** spusťte příkaz:
```powershell
Install-Package TextHelper
```

</details>

---

<details>
<summary>🇺🇸 <strong>ENGLISH (English Version)</strong></summary>

# TextHelper

A library for validated user input entry in console applications, featuring automatic query re-prompting upon invalid input.

## Philosophy

The `ZeptejSeAUprav` method separates value rendering, input parsing, and the "want to edit / don't want to edit" logic from the application itself. If the parsing function throws an exception (e.g., from `TitleCase`, `int.Parse`, `DateOnly.Parse`), the library displays a specific error message and prompts the user to re-enter the input – developers do not need to write custom `try/catch` loops.

## Method

### `UpravaVstupu.ZeptejSeAUprav<T>`

```csharp
public static T ZeptejSeAUprav<T>(
    T aktualni,
    string popis,
    Func<T, string> formatter,
    Func<string, T> parser,
    bool jeNove = false)
```

- `aktualni` – default/current value
- `popis` – item name to display to the user (e.g., "name")
- `formatter` – how to render/display the current value
- `parser` – how to process text from input; throws an exception on invalid input
- `jeNove` – `true` for a brand new value (prompts for input immediately), `false` when editing an existing value (first asks if the user wants to change it)

## Usage

```csharp
using TextHelper;

int mzda = UpravaVstupu.ZeptejSeAUprav(
    0, "mzda",
    v => v.ToString(),
    s => int.Parse(s),
    jeNove: true);
```

Upon invalid input, a specific error message (ex.Message) is displayed, and the user is re-prompted until a valid value is entered.

## Installation as a NuGet Package
This library is also available as a package in GitHub Packages. You can easily add it to your project:

1. Set up your GitHub as a package source (if you do not have it in NuGet.config yet).
2. In the Package Manager Console, run the command:
```powershell
Install-Package TextHelper
```

</details>