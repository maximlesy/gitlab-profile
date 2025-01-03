# Documentation and/or resources

## 1 - Test Driven Development (TDD)

### Retrospective

* Het is **moeilijk om te bepalen wat de belangrijkste tests is** om éérst onder handen te nemen. Door tijdens het ontwikkelproces soms een misse keuze gemaakt te hebben, is de code bombatischer is geworden dan werkelijk nodig, waardoor er nadien **meer tijd kruipt in het refactoren**. Niettegenstaande ben je wel **zeker dat je code correct functioneert**.
* Sommige tests kunnen uitgebreid worden (bv. met parameters): het is een **moeilijke balans tussen één test voorzien of meerdere tests** schrijven.
* Het "van binnen naar buiten werken" zoals Uncle Bob het in de video op Leho vertelt (lees: eerst de grote gehelen, dan de details uitwerken) is aangenaam omdat het veel **edge cases onmiddellijk tackelt**.
* Het is moeilijk om te blijven programmeren, wetende dat je oplossing momenteel wel een oplossing biedt, maar dat het geen oplossing is op lange termijn. Zeker wanneer je lang een "dit werkt dus we kunnen voort houding aanneemt", zoals geopperd door Uncle Bob in zijn video (Leho). **Misschien heb ik hier te lang gewacht met toch onmiddellijk beginnen refactoren!** Commit e04357d (red) en f792231 (green) zijn daar een voorbeeld van: de tests houden op dit punt steek, de code not so much. De commit erna (90694c7) trekt heel de boel weer recht(er). Deze omschrijven mijn voor- en tegens voor TDD: het voelt wat wonky om te geloven in het nut van het process (het gevoel van: "schrijf ik nu geen nutteloze code?", "Is dit geen hopen extra werk?", ...). Anderszijds, wanneer je eenmaal door de 'zure appel' bent kan je wel **terugkijken naar code die (1) properder was dan tevoren, (2) code die niet plots nieuwe nieuwe bugs introduceert (want die ben je gaandeweg steeds blijven kapot slaan) en (3) uiteindelijk achter te blijven met code die robuster is dan tevoren want het refactoren bracht ook nieuwe problemen aan het licht**. 
* Terzelfdertijd bedenk ik me wel: is hier in een bedrijfcontext tijd en kapitaal voor? Misschien wel, op voorwaarde dat TDD sterkt geïncorporeerd zit in de mentaliteit van het team?
* Het strikt volgen van de Red - Green - (Refactor) stappen is een ideologie; niet iets wat je altijd in de praktijk om kan zetten. Wat indien een test onmiddellijk slaagt, bijvoorbeeld? Dan kan je niet starten met een 'red', dus moet je onmiddellijk schakelen naar 'green'?

### Wat zou je beter doen in een tweede iteratie?
Ik heb me te strikt laten leiden door Uncle Bob's advies uit de video om "zo lang als mogelijk te wachten met bijsturen". Zijn advies had ik daar meer met een korreltje zout moeten nemen, want nu heb ik té lang gewacht.
Door te lang te wachten werd het refactorwerk op het einde van de rit plots te groot. Had ik gaandeweg wél de aanpassingen gemaakt die ik wou doen (want die heb ik niet gedaan omwille van het advies), dan zou ik stukken vlotter tot het eindresultaat gekomen zijn.
Graag merk ik ook wel nog op dat ik Uncle Bob niet wil tegenspreken in zijn advies, maar misschien moeten we gewoon even beklemtonen dat hij allicht net ietsje overdreef in zijn video om een punt te kunnen maken voor de demo (in een klein project).

In een komende iteratie moet ik ook zorgvuldiger de belangrijkste tests weten te onderscheiden van de detailtests. Ik startte de opdracht met het idee om dat te doen, maar dat bleek uiteindelijke moeilijker dan verwacht.

Tot slot geef ik graag mee dat ik in een volgend project graag standaard TDD toepas omwille van de gerustheid die het je geeft: je weet dat de code werkt zoals je zelf hebt vooropgesteld én het is stukken moeilijker om nieuwe bugs te introduceren.
Nu, die gerustheid is natuurlijk ook maar zo goed als de tests die je zelf schreef en weet te coveren. In het bestaande project zijn er allicht nog een aantal edge cases die niét gecovered zijn. Het spreek voor zich dat deze geen 'red test' zullen opleveren; de test is
niet geschreven. Dit laatste duidt dan weer op het aandachtig moeten zijn om 'volledige' tests uit te schrijven die zo veel mogelijk scenario's aftoetsen.

> **Eindverdict:** De code die ik gaandeweg schreef is geenszins de code die ik standaard zou schrijven. 
Het eindresultaat is helemaal anders uitgedraaid dan mijn standaard stijl. Dit hoeft geen slecht gegeven te zijn: de code is getest en bevat tests die mogelijke nieuwe refactors en de tand des tijds kunnen doorstaan. 
Tot slot is het relavnt om op te merken dat het zeker relevant kan zijn om de huidige code base nog verder te refactoren.

### Checklist
|Programming Boundary|Test(s) available that prove this|
|--------------------|:-------------------------------:|
|The game consists of 10 frames.| ✅ |
|In each frame the player has two rolls to knock down 10 pins. |✅|
|The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.|✅|
|A spare is when the player knocks down all 10 pins in two rolls. The bonus for that frame is the number of pins knocked down by the next roll.|✅|
|A strike is when the player knocks down all 10 pins on his first roll. The frame is then completed with a single roll. The bonus for that frame is the value of the next two rolls.|✅|
|In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However no more than three balls can be rolled in tenth frame.|✅|

### Bronnen
#### Testing
* [Red, green, refactor strategy](https://www.codecademy.com/article/tdd-red-green-refactor)
* [Should you create a 'stub' class first?](https://stackoverflow.com/questions/22293230/tdd-should-i-create-an-empty-class-needed-for-a-test-case)
* [Red, green, refactor example](https://medium.com/news-uk-technology/is-the-red-green-refactor-cycle-of-test-driven-development-good-9e2b1b52d721)
* [Tests with parameters - stackoverflow](https://stackoverflow.com/questions/61483452/parameterized-test-with-two-arguments-in-junit-5-jupiter)
* [Tests with parameters - official docs](https://junit.org/junit5/docs/current/user-guide/#writing-tests-parameterized-repeatable-sources)
* [@Before vs @BeforeAll vs @BeforeEach](https://www.baeldung.com/junit-before-beforeclass-beforeeach-beforeall)

#### Bowling rules
* [Bowling points calculator](https://www.sportcalculators.com/bowling-score-calculator)

## 2 - Assembly & Structured Programming

### Retrospective
Initieel zag ik niet in waarom dit hoofdstuk 'assembly' én 'structured programming' heette.
Gaandeweg werd me dit echter helemaal duidelijk: we maakten een vertaalslag van de programmeerstijl die we gewend zijn en 
waar we van houden (en die bovendien quasi standaard 'structured' is?) naar een vorm van assembly code die telkens meer en meer 'unstructured' werd (lees: minder leesbaar),
maar natuurlijk wel nog steeds is (lees: neigt) naar machinecode.

#### De belangrijkste zaken die ik opstak uit deze opdracht zijn:
* **Alternatief nadenken over oplossingen** met sterke restricties (nl. het beperken van variabelen)
* Indien de beperking niet vol te houden is was het fijn om de werking van een **eigen soort stack te zien en de overhead die daarbij komt kijken**
* Moderne programmeertalen bevatten veel **syntatic sugar**: heel concreet heeft in deze opdracht een `for` lus gebruiken een nadelen omdat het nood heeft aan een extra teller,
en dus een extra variabele. Er zijn andere manieren om dit op te lossen. In die zin is een `while` 'zuiniger'. Je moet nog steeds een conditie checken om de lus te beïndigen, maar 
je kan wel berusten op constanten ipv. variabelen.
* Zelfs **arithemtiek kan opgelost worden met enkel optellingen/aftrekkingen** indien correct toegepast. In die zin is het kunnen gebruiken van `* % /` ook "syntactic sugar".
Niet letterlijk natuurlijk, maar er is iets meer 'basic'.
* `if ... else`, `for/while/..` zijn er voor het gemak. Je kan alles oplossen met `gotos`, maar dat gaat snel **ten kosten van leesbaarheid en het kunnen volgen van de flow van je code**.
* Op het einde van de rit schreven we assembly-like code. Deze is héél expressief en zéér basic, waardoor het enorm moeilijk is om de algemene logica te (blijven) volgen.


#### Hoe ging ik te werk?
* Ik probeerde steeds eerst een uitwerking te schrijven die geen nood had aan de push_stack() methode, dit om me te kunnen redden met de bestaande n1, n2 en n3 variabelen die volledig als stand-alone kunnen dienen.
* Op termijn was dit echter niet houdbaar, waardoor ik een strategie toepaste richtig functioneel programmeren: de input variabele kon/mocht veranderen op voorwaarde dat de input op het einde van de rit de output bevatte.
Hierdoor creëerde is als het ware tóch een n4 variabele. Reden om dit te doen was om `nx` te kunnen vermijden omwille van de 'wispelturigheid' na een pop.
* Eenmaal toegekomen bij het verwijderen van de `*`, `/` en `%` werkte bovenstaande strategie niet meer en moet er toch een manier gevonden worden om de variabelen te laten 'dansen' door op kritische plaatsen te pushen en poppen.
Zodat de nodige waardes teruggestopt konden worden in de juiste variabelen (n1, n2, n3). De reden om toch de push/pop methodes te moeten gebruiken was omwille van de nood aan een teller die niet meer tegewezen kon worden aan de inmiddels
'fixed' `n1`, `n2` en `n3`.
* Tot het gebruik van de `gotos` kan je je programma nog vrij liniair lezen indien je "meespringt" (statements worden sequentieel uitgevoerd tenzij je versprongen bent). Vanaf het verwijderen van `*`, `/` en `%` werd dit springen echter een 
**mentale overhead en werd de code te** ***unstructured***. Omwille van die reden introduceerde ik weer lussen (doorgaans en `while`) om deze pas daarna terug te vertalen naar `gotos` e.d.

#### Waar liep je vast?
Ik heb nergens echt vast gelopen; maar beschouwde deze opdracht eerste als een uitdaging. Waar is dus op vast liep, lees je hierboven al, maar dat heb ik niet beschouwd als 'vastlopen'.
Ik liep wél vast op het kunnen compileren van de laatste stap, daar kreeg ik errors die te maken hadden met de soort compiler. Ik gebruikte `cl` om te compileren, maar enkel `gcc` kon de
`push_label()` code compileren.

### Bronnen
* [Use cl command on Windows](https://learn.microsoft.com/en-us/cpp/build/walkthrough-compile-a-c-program-on-the-command-line?view=msvc-170)
* [Structured Programming](https://en.wikipedia.org/wiki/Structured_programming)
* [Difference between structured and unstructured programming](https://www.geeksforgeeks.org/difference-between-structured-and-unstructured-programming/)
* [Swapping digits formula](https://stackoverflow.com/questions/74311104/given-a-two-digit-integer-swap-its-digits-and-print-the-result-python)
* [Swapping digits alternative formula](https://codecrucks.com/program/program-to-swap-first-and-last-digit-of-a-number-using-while-loop/)
* [Detecting (integer) overflow in C](https://stackoverflow.com/questions/55468823/how-to-detect-integer-overflow-in-c)
* [long long](https://stackoverflow.com/questions/2550345/whats-the-difference-between-unsigned-long-long-int-in-c-c)
* [redefinition; different basic types error](https://stackoverflow.com/questions/16424239/error-c2371-redefinition-different-basic-types-why)

## 3 - Competitive Programming

> **!** De opdracht wordt/werd uitgevoerd tijdens het examenmoment.
> Reden: werkstudent

## 4 - Design Patterns

### Strategy & Factory pattern (toegepast in Gilded Rose)
*Voor de opdracht 'Refactoring' werd het het Strategy pattern & het factory pattern toegepast. Zie daarvoor ook de uitwerking van de Gilded Rose.
Een van de belangrijkste redenen om design patterns toe te passen, was de noodzaak om de gecentraliseerde logica in de GildedRose-klasse te verminderen: 
Door alle logica in één klasse te centraliseren, werd de code niet alleen onoverzichtelijk, maar ook moeilijk uitbreidbaar.
De applicatie schendt (o.a.) het Open/Closed Principle, een van de SOLID-principes, die stelt dat een software-entiteit open moet zijn voor uitbreiding, maar gesloten voor modificatie.*

Om deze problemen aan te pakken, besloot ik het Strategy Pattern te gebruiken omdat dit pattern het mogelijk maakt om de **update-logica's voor verschillende itemtypes te scheiden in aparte strategieklassen**. 
Hierdoor werd de **code flexibeler en gemakkelijker te onderhouden**. Elke strategieklasse implementeerde de specifieke update-logica voor een bepaald itemtype, wat zorgde voor een **duidelijke scheiding van verantwoordelijkheden**.

Daarnaast heb ik het Factory Pattern geïmplementeerd om de creatie van de juiste strategieën te beheren. 
Dit patroon zorgde ervoor dat de logica voor het **aanmaken van strategieën gescheiden bleef van de hoofdlogica**, wat de codebase verder vereenvoudigde. 
De factory creëert de juiste strategie op basis van het type item, waardoor de GildedRose-klasse niet langer verantwoordelijk was voor het kennen van de specifieke update-logica van elk itemtype.

Door abstracte klassen en methoden te gebruiken, kon ik ervoor zorgen dat elke concrete strategie zijn eigen implementatie van de update-logica had, maar dat met een gedeelde basis.
Dit zorgde voor een consistente structuur en maakte het gemakkelijker om nieuwe strategieën toe te voegen zonder de bestaande code te wijzigen.

### Builder Pattern (met Fluent API)
Het idee van "Fleunt" code schrijven (lees: method chaining toepassen om objecten aan te maken en/of configureren) is iets wat is heel wat .NET applicaties een standaard practise is omdat het op deze manier in de 
default tools van .NET wordt voorzien.

Ik schreef dan ook een project die het .NET gedrag simuleert, waar wezenlijk neerkomt op het toepassen van het Builder Pattern.
Wat ik voornamelijk opstak uit het toepassen van het Builder Pattern is dat wordt gebruikt om complexe objecten stap voor stap te creëren, 
wat de code leesbaarder en onderhoudbaarder maakt. Het helpt ook om immutability te waarborgen en voorkomt constructor telescoping.
Bovendien kan je, wanneer je verder werkt met de Fluent manier van schrijven, als developer concrete stappen bepalen waarin een object aangemaakt mag/moet worden door het definieëren van de verschillen de stappen
om het complexere object aan te maken (deze stappen zijn de `IStages` in de code).

#### Dependency Injection Pattern
* Containers zijn complex omdat ze kennis moeten hebben van ALLE dependencies

* Mogelijke strategieën berusten op verschillende stijlen van registreren en dus ook van types bij te houden. In mijn uitwerking kan je bijvoorbeeld geen concrete types registeren en moeten ze altijd berusten 
op een interface. Concrete types extra voorzien zorgt voor extra werk en complexiteit.

* Een container is vrij "low level": je stapt volledig af van concrete types en grijpt in C# terug naar basis types (Type en object) en moet aan 'reflection' doen.

* Eenmaal de container geschreven is, is het echter heel eenvoudig om een object aan te maken die heel veel dependencies heeft, zelfs als de dependency chain heel diep is. 
Voordeel is dat je de dependency chain zelf niet meer moet opbouwen. Bovendien is het ook zo dat je de applicatie zijn manier van werken heel eenvoudig kan wijzigen door een dependency anders te registreren. 
Daardoor kan het gedrag van de applicatie plots helemaal wijzigen met maar één lijn code aan te moeten passen.

### Bronnen
* [Strategy pattern](https://refactoring.guru/design-patterns/strategy)
* [Factory pattern](https://refactoring.guru/design-patterns/factory-method)
* [Builder pattern](https://refactoring.guru/design-patterns/builder)
* [Fluent API](https://www.youtube.com/watch?v=1JAdZul-aRQ&t=588s)
* [Dependency Injection Design pattern I](https://learn.microsoft.com/en-us/previous-versions/dotnet/netframework-4.0/hh323705(v=vs.100)?redirectedfrom=MSDN)
* [Dependency Injection Design pattern II](https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/)

## 5 - Refactoring

### Gilded Rose

> **!** De commits die betrekking hebben op de Gilded Rose oefening werden gelabeled met "Gilded Rose - Step x - Commit message xxx"

Mijn strategie om de Gilded Rose te refactoren was om éérst (Acceptance) Tests te schrijven die de bestaande codebase testten.
Op die manier kon ik bevestigen dat de applicatie (1) inderdaad functioneert zoals beloofd en (2) dat mijn eigen tests de boundaries van het project testen.
Ter info: dit zijn de commits met "Gilded Rose - Aceptance test - message xxx"

Eenmaal de applicatie tests bevatte die alle requirements aftoetsten, kon ik starten met het eigenlijke refactoren. Deze commits herken je aan "Gilded Rose - Refactor - message xxx"
De eerste stap was daarbij om op zoek te gaan naar **code duplicatie in een eigen methode onder te brengen**. Vervolgens zocht ik naar nutteloze if-statements, condition checks om **onnodige nesting te verwijderen**.
Verder keerde ik veel condities om om de leesbaarheid te verhogen: bv.: `item.Name != "Aged Brie"` werd vertaald naar `item.Name == Aged Brie` omdat ik van mening men dat deze **wijzing de intentie van de code expliciteert**.

Daarna ging ik verder met het maken van een unieke methode `HandleQualityLogic`, die bedoeld was om **eerst op een gestructureerde manier de logica van de verschillende items te kunnen structuren**.
Ik koos om dit te doen om stapsgewijs verder te kunnen (op zich had ik integraal op delete kunnen drukken en de applicatie herschreven hebben), maar ik wou wijziging per wijziging kunnen aantonen dat de code bleef werken
tijdens het refactoren. De `HandleQualityLogic` bewijst dat.

Het **verwijderen van onlogische stappen en deze herformuleren** naar de `HandleQualityLogic` ging een stukje verder. In feite werd deze methode een soort van switch statement waarin de regelset van de items ondergebracht werd.
Echter, doordat de oorspronkelijke code zeer quirky geschreven was zaten er heel wat bizarre logica's verstopt in de code base, inclusief het uiteindelijk bevatten van recursieve functies.
De volgende stap was dan ook om de **recursieve functies (die ikzelf gaandeweg introduceerde) te verwijderen** om de code weer expliet te maken.
Op dit punt besloot ik om ervoor te kiezen om alle logica af te handelen in één methode: deze stap verwezenlijkt de letterlijke verschuiving van de spaghetti-code als start: naar gestructureerde(re) code in mijn eigen methode.

Met gestructureerde code in mijn nieuwe methode, kon ik **verder gaan met het refactoren door nieuwe klasses e.d. te introduceren** die elk stuk logica apart moeten afhankelen om **Seperation of Concerns** in de hand te werken.
Hiervoor werd het **Strategy en het Factory pattern** toegepast. Hierbij werd ook gedacht aan gedeelde logica die onderbracht werd (abstracte) basisklasses, e.d.

**Pas nu de oorspronkelijke code van het project helemaal gerefactored, voegde ik de nieuwe case voor Conjured items toe.** 
Daarvoor voegde ik eerst een 'red' test toe (cfr. TDD) om te bevestigen dat het Conjured item effectief niet functioneert.

Gezien de code op dit punt helemaal mooi opgeplitst is met specifieke 'UpdateStrategies', is het enkel een kwestie van een nieuwe `ConjuredItemUpdateStrategy` toe te voegen met zijn eigen logica. Deze stap was dan ook het minste werk.
Een concrete implementatie is niet slechts enkele minuten werk en mijn test kan bevestigen dat de code functioneert zoals gewenst, want ze kleurt mooi 'green'.

De applicatie is helemaal gerefactored met een aanpak die ik best kan smaken.

#### Bronnen
* [Strategy pattern](https://refactoring.guru/design-patterns/strategy)
* [Factory pattern](https://refactoring.guru/design-patterns/factory-method)