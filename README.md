# Documentation and/or resources

## 1 - Test Driven Development (TDD)

### Reflectie

* Het is **moeilijk om te bepalen wat de belangrijkste tests is** om éérst onder handen te nemen. Door tijdens het ontwikkelproces soms een misse keuze gemaakt te hebben, is de code bombatischer is geworden dan werkelijk nodig, waardoor er nadien **meer tijd kruipt in het refactoren**. Niettegenstaande ben je wel **zeker dat je code correct functioneert**.
* Sommige tests kunnen uitgebreid worden (bv. met parameters): het is een **moeilijke balans tussen één test voorzien of meerdere tests** schrijven.
* Het "van binnen naar buiten werken" zoals Uncle Bob het in de video op Leho vertelt (lees: eerst de grote gehelen, dan de details uitwerken) is aangenaam omdat het veel **edge cases onmiddellijk tackelt**.
* Het is moeilijk om te blijven programmeren, wetende dat je oplossing momenteel wel een oplossing biedt, maar dat het geen oplossing is op lange termijn. Zeker wanneer je lang een "dit werkt dus we kunnen voort houding aanneemt", zoals geopperd door Uncle Bob in zijn video (Leho). **Misschien heb ik hier te lang gewacht met toch onmiddellijk beginnen refactoren!** Commit e04357d (red) en f792231 (green) zijn daar een voorbeeld van: de tests houden op dit punt steek, de code not so much. De commit erna (90694c7) trekt heel de boel weer recht(er). Deze omschrijven mijn voor- en tegens voor TDD: het voelt wat wonky om te geloven in het nut van het process (het gevoel van: "schrijf ik nu geen nutteloze code?", "Is dit geen hopen extra werk?", ...). Anderszijds, wanneer je eenmaal door de 'zure appel' bent kan je wel **terugkijken naar code die (1) properder was dan tevoren, (2) code die niet plots nieuwe nieuwe bugs introduceert (want die ben je gaandeweg steeds blijven kapot slaan) en (3) uiteindelijk achter te blijven met code die robuster is dan tevoren want het refactoren bracht ook nieuwe problemen aan het licht**. 
* Terzelfdertijd bedenk ik me wel: is hier in een bedrijfcontext tijd en kapitaal voor? Misschien wel, op voorwaarde dat TDD sterkt geïncorporeerd zit in de mentaliteit van het team?
* Het strikt volgen van de Red - Green - (Refactor) stappen is een ideologie; niet iets wat je altijd in de praktijk om kan zetten. Wat indien een test onmiddellijk slaagt, bijvoorbeeld? Dan kan je niet starten met een 'red', dus moet je onmiddellijk schakelen naar 'green'?

> **Eindverdict:** De code die ik gaandeweg schreef is geenszins de code die ik standaard zou schrijven. Het eindresultaat is helemaal anders uitgedraaid dan mijn standaard stijl. Dit hoeft geen slecht gegeven te zijn: de code is getest en bevat tests die mogelijke refactors en de tand des tijds kunnen doorstaan en kunnen blijven dienen. In de huidige code base is verder refactoren zeker nog aan de orde.

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

### Reflectie
Initieel zag ik niet in waarom dit hoofdstuk 'assembly' én 'structured programming' heette.
Gaandeweg werd me dit echter helemaal duidelijk: we maakten een vertaalslag van de programmeerstijl die we gewend zijn en 
waar we van houden (en die bovendien quasi standaard 'structured' is?) naar een vorm van assembly code die telkens meer en meer 'unstructured' werd (lees: minder leesbaar),
maar natuurlijk wel nog steeds is (lees: neigt) naar machinecode.

De belangrijkste zaken die ik opstak uit deze opdracht zijn:
* **Alternatief nadenken over oplossingen** met sterke restricties (nl. het beperken van variabelen)
* Indien de beperking niet vol te houden is was het fijn om de werking van een **eigen soort stack te zien en de overhead die daarbij komt kijken**
* Moderne programmeertalen bevatten veel **syntatic sugar**: heel concreet heeft in deze opdracht een `for` lus gebruiken een nadelen omdat het nood heeft aan een extra teller,
en dus een extra variabele. Er zijn andere manieren om dit op te lossen. In die zin is een `while` 'zuiniger'. Je moet nog steeds een conditie checken om de lus te beïndigen, maar 
je kan wel berusten op constanten ipv. variabelen.
* Zelfs **arithemtiek kan opgelost worden met enkel optellingen/aftrekkingen** indien correct toegepast. In die zin is het kunnen gebruiken van `* % /` ook "syntactic sugar".
Niet letterlijk natuurlijk, maar er is iets meer 'basic'.
* `if ... else`, `for/while/..` zijn er voor het gemak. Je kan alles oplossen met `gotos`, maar dat gaat snel **ten kosten van leesbaarheid en het kunnen volgen van de flow van je code**.
* Op het einde van de rit schreven we assembly-like code. Deze is héél expressief en zéér basic, waardoor het enorm moeilijk is om de algemene logica te (blijven) volgen.

## 3 - Competitive Programming

> **!** De opdracht wordt/werd uitgevoerd tijdens het examenmoment.
> Reden: werkstudent
