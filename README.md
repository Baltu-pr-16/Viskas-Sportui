# Viskas Sportui

„Viskas Sportui“ – internetinė informacinė sistema, skirta su sportu susijusios informacijos paieškai ir palyginimui vienoje vietoje.

## Paleidimas

Reikalingi [.NET 10 SDK](https://dotnet.microsoft.com/download) ir [Git](https://git-scm.com/downloads).

Projekto atsisiuntimas:

```
git clone https://github.com/Baltu-pr-16/Viskas-Sportui.git
cd Viskas-Sportui
```

Programos paleidimas:

```
dotnet run --project ViskasSportui
```

Paleista programa pasiekiama naršyklėje adresu <http://localhost:5080>, o sustabdoma terminale paspaudus `Ctrl+C`.

Projektą taip pat galima atidaryti per Visual Studio arba Rider (`ViskasSportui.sln`) ir paleisti mygtuku „Run“.

## Demonstracinės paskyros

| El. paštas | Slaptažodis | Rolė |
|---|---|---|
| admin@viskassportui.lt | admin123 | Administratorius |
| naudotojas@viskassportui.lt | naudotojas123 | Registruotas naudotojas |

## Struktūra

```
ViskasSportui/
  Controllers/    valdikliai
  Models/         sporto vietos esybė ir demonstraciniai duomenys
  Views/          langai (Shared/_Layout.cshtml – bendras meniu)
  wwwroot/css/    stilius
```

---

© 2026 komanda „Baltų pr. 16“ · Informacinių sistemų pagrindai (P170B114)
