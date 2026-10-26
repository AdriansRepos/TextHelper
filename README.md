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
