Algoritmusok lépésszáma, aszimptotikus jelölések. Beszúrásos rendezés, keresések lineáris és logaritmikus lépésszámmal. Táblázatok, hash függvények, hash táblák. Gráfok, szélességi és mélységi bejárás.

---

## 1. Algoritmusok lépésszáma és aszimptotikus jelölések

### Miért fontos a lépésszám?

Az algoritmusok hatékonyságát azzal mérjük, hogy a bemenet méretének (n) növekedésével hogyan változik a futási idő. Nem a konkrét másodpercek számítanak – azt befolyásolja a hardver is –, hanem a **növekedés üteme**.

Három eset különböztetünk meg:
- **Legjobb eset** – általában nem sokat mond, senkit nem érdekel
- **Átlagos eset** – informatív, de nehéz kiszámítani
- **Legrosszabb eset** – ez a mérvadó; garantálja, hogy soha nem lesz rosszabb ennél

---

### Aszimptotikus jelölések

Ezek a jelölések azt mondják meg, hogy **elég nagy n esetén** hogyan viselkedik egy algoritmus futási ideje – a konstans szorzóktól és a kisebb tagóktól eltekintve.

**Nagy-O (O) – felső korlát:** „Az algoritmus legfeljebb ennyit lép." Pl. O(n²) azt jelenti, hogy egy adott ponttól a futási idő soha nem haladja meg valamilyen konstansszor n négyzetét. Ez a leggyakrabban használt jelölés, mert a legrosszabb esetet becsüli.

**Omega (Ω) – alsó korlát:** „Az algoritmus legalább ennyit lép." Megmondja, gyorsabban nem lehet megoldani a problémát (pl. egy rendezés nem lehet gyorsabb Ω(n log n)-nél összehasonlítás alapon).

**Theta (Θ) – éles korlát:** Ha az O és az Ω ugyanaz, akkor Theta – vagyis az algoritmus pontosan ebben a nagyságrendben fut, nem gyorsabb és nem lassabb. Ez a leginformatívabb jelölés.

### Leggyakoribb komplexitásosztályok (lassítás sorrendjében)

- **O(1) – konstans:** mindegy mekkora az input, mindig ugyanannyi lépés (pl. tömb egy elemének olvasása)
- **O(log n) – logaritmikus:** minden lépéssel felezi a problémát (pl. bináris keresés)
- **O(n) – lineáris:** végigmegy minden elemen egyszer (pl. lineáris keresés)
- **O(n log n) – lineáris-logaritmikus:** jó rendező algoritmusok (pl. Merge Sort, Quick Sort átlagosan)
- **O(n²) – négyzetes:** kettős egymásba ágyazott ciklus (pl. buborékrendezés, Insertion Sort legrosszabb esetben)
- **O(2ⁿ) – exponenciális:** minden új elem megduplázza a munkát – nagyon lassú
- **O(n!) – faktoriális:** a leglassabb, csak kis n esetén kivitelezhető

---

### Beszúrásos rendezés (Insertion Sort)

**Elve:** Képzeljük el, ahogy egy kártyalapokat kapunk egymás után. Minden új lapot beillesztjük a már a kezünkben tartott, rendezett lapok közé a megfelelő helyre.

Konkrétan: a tömb második elemétől indulva az aktuális elemet beillesztjük a tőle balra lévő, már rendezett részbe – visszafelé lépkedve addig toljuk el az elemeket, amíg meg nem találjuk a helyét.

**Lépésszám:**
- **Legjobb eset: O(n)** – ha a tömb már rendezett, minden elem rögtön a helyén van, csak végigmegyünk egyszer
- **Legrosszabb eset: O(n²)** – ha fordítva rendezett, minden elemet az egész rendezett részen végig kell tolni

Kis tömbökre és közel rendezett adatokra praktikus, nagy adathalmazon lassú.

---

## 2. Keresések

### Lineáris keresés – O(n)

Az elemeket sorban, egyenként nézzük végig az elejétől a végéig, amíg meg nem találjuk a keresett értéket – vagy végigértünk és nincs benne.

- Nem igényli, hogy az adat rendezett legyen.
- Legrosszabb eset: az elem az utolsón van, vagy egyáltalán nincs benne → n lépés.
- Egyszerű, de nagy adathalmazon lassú.

### Bináris keresés – O(log n)

**Csak rendezett tömbben működik.** A középső elemet nézzük meg: ha a keresett érték kisebb, a bal félben folytatjuk, ha nagyobb, a jobb félben – és ezt ismételjük. Minden lépésben felezzük a vizsgálandó részt.

- Legrosszabb eset: log₂(n) + 1 lépés (a +1 elhanyagolható)
- Például 1 millió elemből legfeljebb 20 összehasonlítás alatt megtalálja az elemet

---

## 3. Táblázatok és hash táblák

### Táblázat (Dictionary / Asszociatív tömb)

Olyan adatszerkezet, amelyben az elemeket **kulcs–érték párokban** tároljuk. A kulcs egyedi azonosító (mint egy szótárban a szó), az érték az ehhez tartozó adat. Műveletek: keresés, beszúrás, törlés – mindig kulcs alapján.

---

### Önátrendező tábla

Ha az elemeket különböző gyakorisággal használjuk, érdemes a leggyakrabban keresett elemet elöl tartani. Minden sikeres keresés után a talált elemet a lista elejére hozzuk. Így a leggyakoribb elemek gyorsan elérhetők, a ritkák hátra kerülnek. Lineáris keresés alapján működik, de a gyakorlatban gyors, ha az eloszlás nem egyenletes.

---

### Közvetlen címzésű tábla

Ha a kulcsok egy kis, ismert tartományból kerülnek ki (pl. 0-tól 999-ig), akkor lefoglalunk egy tömböt, amelynek indexe maga a kulcs. Az elem elérése így egyetlen lépéses. Hátránya: ha a kulcstartomány nagy, a tömb is hatalmas lenne – rengeteg helyet pazarolunk.

---

### Hash tábla

A hash tábla a közvetlen címzés problémáját oldja meg úgy, hogy egy **hash függvénnyel** a kulcsot leképezi a tábla egy pozíciójára. A tábla mérete jóval kisebb lehet, mint az összes lehetséges kulcs száma.

**Ütközés:** Ha két különböző kulcshoz ugyanaz a pozíció tartozik, ütközés lép fel. Ez elkerülhetetlen, ha több kulcs van, mint pozíció.

**Ütközésfeloldás láncolással:** Minden táblapozíción egy láncolt lista van. Ha ütközés történik, az új elemet egyszerűen hozzáfűzzük a listához. Egyszerű, de sok ütközésnél a lista hosszú lesz és lassul a keresés.

**Nyílt címzés:** Minden elem magában a táblában tárol helyet, nincs szükség külső listákra. Ha egy pozíció foglalt, más pozíciót próbálunk:
- **Lineáris próba:** ha foglalt a hely, az eggyel arrébb lévőt próbáljuk, majd a kettővel arrébb lévőt és így tovább
- **Kvadratikus próba:** a lépések négyzetesen nőnek (1, 4, 9, 16...) – kevésbé alakulnak ki klaszterek, mint lineárisnál

---

## 4. Gráfok

### Mi a gráf?

A gráf csúcsokból (pontokból) és élekből (összeköttetésekből) áll. Rengeteg valós helyzetet modellez: városok és utak hálózata, közösségi kapcsolatok, programok közötti függőségek.

**Irányítatlan gráf:** az éleknek nincs iránya – ha A-ból vezet él B-be, akkor B-ből is vezet A-ba (pl. kétirányú út).

**Irányított gráf:** az éleknek van iránya – az él csak egyik irányban járható (pl. egyirányú utca, weboldal linkjei).

### Reprezentáció

**Szomszédsági lista:** minden csúcshoz nyilvántartjuk, melyik csúcsokkal van összekötve. Ritka gráfoknál (kevés él) memóriatakarékos.

**Szomszédsági mátrix:** n×n-es táblázat – az i-edik sor j-edik oszlopában 1 van, ha i-ből j-be vezet él, egyébként 0. Sűrű gráfoknál gyors az élkeresés, de sok helyet foglal, ha kevés él van.

Ökölszabály: **ritka gráf → lista**, **sűrű gráf → mátrix**.

---

## 5. Szélességi és mélységi bejárás

### Szélességi bejárás (BFS – Breadth-First Search)

**Alapja: Sor adatszerkezet.**

A bejárás szintenként terjed ki, mint egy kő a vízbe dobva: először a kezdőpont közvetlen szomszédait látogatjuk meg, majd azok szomszédait, és így tovább – mindig az azonos távolságra lévő csúcsokat dolgozzuk fel egyszerre.

**Lépések:**
1. Üres sort inicializálunk, betesszük a kezdőcsúcsot.
2. Kivesszük a sor elejéről az elemet, feldolgozzuk, és betesszük a sor végére az összes még nem látogatott szomszédját.
3. Ismételjük, amíg a sor üres nem lesz (vagy megtaláljuk a keresett csúcsot).

**Minden csúcs három állapotot vehet fel:** még nem látott / sorban van, de még nem dolgozták fel / már feldolgozva.

**Mire jó?** Súlyozatlan gráfban a BFS megtalálja a **legrövidebb utat** a kezdőcsúcstól bármely más csúcsig (legkevesebb élen átmenő utat).

---

### Mélységi bejárás (DFS – Depth-First Search)

**Alapja: Verem adatszerkezet.**

A bejárás egy ágon megy le a lehető legmélyebbre, és csak zsákutcába érve lép vissza, hogy más irányt próbáljon – mint egy labirintusban a fal mellett haladó stratégia.

**Lépések:**
1. Üres vermet inicializálunk, betesszük a kezdőcsúcsot.
2. Kivesszük a verem tetejéről az elemet, feldolgozzuk, és rátesszük a veremre az összes még nem látogatott szomszédját.
3. Ismételjük, amíg a verem üres nem lesz (vagy megtaláljuk a keresett csúcsot).

**Mire jó?** Teljes bejárás, körkeresés, topológiai rendezés. Nem garantálja a legrövidebb utat.

---

### BFS vs. DFS összehasonlítás

| | BFS (Szélességi) | DFS (Mélységi) |
|---|---|---|
| Adatszerkezet | Sor | Verem |
| Terjedés iránya | Szintenként, gyűrűszerűen | Mélyre, ágonként |
| Legrövidebb út | Igen (súlyozatlan gráfban) | Nem |
| Memóriaigény | Több (széles gráfban) | Kevesebb (mély gráfban) |
| Teljes bejárás | Igen | Igen |
