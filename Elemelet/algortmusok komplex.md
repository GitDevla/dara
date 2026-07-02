Problémák reprezentálása állapottéren. A megoldás keresése visszalépéssel. Szisztematikus és heurisztikus fa- és gráfkereső eljárások.

---


## 1. Problémák reprezentálása állapottéren

### Mi az állapottér-reprezentáció?

Ha egy problémát számítógéppel akarunk megoldani, először el kell döntenünk, hogyan írjuk le formálisan. Az állapottér-reprezentáció ezt teszi: **absztrakt módon leírja a problémát**, függetlenül minden implementációs részlettől.

Négy összetevője van:
- **Állapotok halmaza (A):** Az összes lehetséges szituáció, amelybe a probléma kerülhet.
- **Kezdőállapot (a₀):** Ahonnan indulunk.
- **Célállapot (C):** Amit el akarunk érni.
- **Operátorok (O):** Az összes lehetséges lépés – melyik állapotból melyikbe lehet jutni. Minden operátorhoz tartozik egy alkalmazási feltétel (mikor alkalmazható) és egy hatásdefiníció (mit változtat).

**Példa – Hanoi tornya:**
- Állapot: Melyik korongok vannak melyik rúdon.
- Kezdőállapot: Mindenki az első rúdon.
- Cél: Mindenki az utolsó rúdon.
- Operátor: Egy korong átmozgatása egyik rúdról a másikra – feltéve, hogy a célrúdon nincs kisebb nála.

---

## 2. Visszalépéses keresés – kényszerkielégítés (CSP)

### Mi a kényszerkielégítési feladat?

A kényszerkielégítési feladatnál (angolul CSP) van egy csomó változónk, minden változónak van egy tartománya (lehetséges értékkészlete), és vannak kényszerek, amelyek meghatározzák, hogy bizonyos változóknak milyen értékeket vehetnek fel egymás mellett.

**Cél:** Olyan értéket rendelni minden változóhoz, amely minden kényszert kielégít.

**Példa – Térképszínezés:** Az ausztrál tartományokat három színnel akarjuk kiszínezni úgy, hogy szomszédos tartományok ne kapjanak azonos színt. Változók: a tartományok; tartomány: piros, zöld, kék; kényszer: szomszéd ≠ szomszéd.

Kényszergráffal is ábrázolható: a csúcsok a változók, az élek a kényszerek.

---

### Visszalépéses keresés

A visszalépéses keresés egy mélységi keresés: egyszerre egy változóhoz rendelünk értéket, és ha ellentmondásba ütközünk (egy kényszert megsértenénk), visszalépünk és más értéket próbálunk.

**Heurisztikák, amelyek felgyorsítják:**

**1. Legkevesebb fennmaradó érték (MRV):** Először azt a változót választjuk, amelynek a legkevesebb érvényes értéke maradt. Ez gyorsan kideríti, ha valahol zsákutcába mentünk.

**2. Fokszám heurisztika:** Ha több azonos helyzetű változó van, azt válasszuk, amelyik a legtöbb kiosztlan változóval áll kényszerviszonyban. Ezzel a legtöbb jövőbeli döntésre van hatásunk.

**3. Legkevésbé korlátozó érték:** Egy változóhoz azt az értéket válasszuk, amely a többi változó lehetőségeire a legkisebb hatással van – így a legtöbb mozgásteret hagyjuk a jövőbeli döntésekhez.

**Előrecsatolás (Forward Checking):** Minden értékadás után megnézzük, hogy a hozzárendeletlen változók lehetséges értékei közül nem kellett-e kizárni mindent. Ha igen, azonnal visszalépünk, nem várjuk meg, hogy tényleg problémává váljon.

**Élkonzisztencia (Arc Consistency, AC-3):** Erősebb változat: nem csak az éppen hozzárendelt változóból indulva ellenőrizzük, hanem az összes élt konzisztenssé tesszük – ha X minden értékéhez van Y-ban is megengedett érték, az él konzisztens. Ha nem, kizárjuk az inkonzisztens értékeket.

---

## 3. Szisztematikus (nem informált) kereső eljárások

A nem informált (vak) keresések csak a probléma definícióját ismerik – nem tudnak semmit arról, milyen „közel" van egy állapot a célhoz.

**Négy értékelési szempont:**
- **Teljesség:** Ha van megoldás, megtalálja-e?
- **Optimalitás:** A legjobb (legolcsóbb) megoldást találja-e?
- **Időbonyolultság:** Hány csúcsot kell megvizsgálni?
- **Tárbonyolultság:** Egyszerre mennyi csúcsot kell memóriában tartani?

*Jelölések: b = elágazási faktor (egy csúcsból átlagosan mennyi gyerek nyílik), d = a legjobb megoldás mélysége, m = a keresési fa maximális mélysége.*

---

### Szélességi keresés (BFS)

Mindig a legkisebb mélységű még fel nem tárt csúcsot terjeszti ki – szintenként halad.

- **Teljes:** Igen, ha az elágazási faktor véges.
- **Optimális:** Igen, ha minden lépés azonos költségű – különben nem.
- **Idő- és tárigény:** b a (d+1)-ediken – exponenciálisan nő a mélységgel.

---

### Mélységi keresés (DFS)

Mindig a legmélyebb csúcsot terjeszti ki – egy ágon lemegy a legmélyebbre, csak zsákutcánál lép vissza.

- **Teljes:** Nem – végtelen mélységű fában könnyen elveszhet.
- **Optimális:** Nem.
- **Időigény:** b az m-ediken – rosszabb, mint a BFS, ha m nagy.
- **Tárigény:** b × m – csak az aktuális ágat kell memóriában tartani, sokkal takarékosabb.

---

### Egyenletes költségű keresés (UCS)

Mindig a legkisebb **összesített útköltséggel** rendelkező csúcsot terjeszti ki. Ha a lépések nem egyforma drágák, ez az igazi optimális keresés.

- **Teljes és optimális:** Igen.
- **Idő- és tárigény:** A legjobb megoldás összköltsége és a legolcsóbb lépés arányától függ – rosszabb esetben exponenciális.

---

### Iteratívan mélyülő mélységi keresés (IDS)

Ötvözi a BFS és DFS előnyeit: mélységkorlátozott keresést végez, de a korlátot minden körben eggyel növeli – így minden mélységet szintenként jár be, mint a BFS, de a DFS tárhatékonyságával.

Az újraindítás miatti ismétlések első ránézésre pazarlásnak tűnnek, de aszimptotikusan nem számítanak sokat, mert a legtöbb csúcs a fa legalsó szintjén van.

- **Teljes és optimális:** Igen (ha az élköltség 1).
- **Időigény:** b a d-ediken.
- **Tárigény:** b × d – a leghatékonyabb nem informált keresés.

---

### Gráfkeresés vs. fakereső

A fakereső algoritmus újra és újra bejárhatja ugyanazokat az állapotokat, ami pazarlás. A **gráfkeresés** ezért nyilván tartja a már meglátogatott állapotokat, és azokat nem vizsgálja újra – exponenciálisan hatékonyabb lehet.

---

### Összefoglalás – nem informált keresések

|                | BFS     | DFS | UCS       | IDS   |
| -------------- | ------- | --- | --------- | ----- |
| **Teljes?**    | igen*   | nem | igen*     | igen  |
| **Optimális?** | igen*   | nem | igen      | igen* |
| **Időigény**   | b^(d+1) | b^m | ~ b^(d+1) | b^d   |
| **Tárigény**   | b^(d+1) | b·m | ~ b^(d+1) | b·d   |

*(csillag: feltételekkel)*

---

## 4. Heurisztikus kereső eljárások

A heurisztikus (informált) keresések egy **becslő függvényt** használnak – h(n) –, amely megbecsüli, milyen messze van az aktuális csúcs a céltól. Ezzel a keresés sokkal hatékonyabb lehet.

---

### Mohó legjobban-először keresés (Greedy Best-First)

Mindig azt a csúcsot terjeszti ki, amelyik a heurisztika szerint a **legközelebb van a célhoz** – figyelmen kívül hagyja, mennyit tettünk már meg.

Romániai útvonaltervezés példájával: mindig azt a várost választja, amelyik légvonalban a legközelebb van Bukaresthez – de ez nem feltétlenül jelenti, hogy oda vezet a legrövidebb út.

- **Teljes:** Nem – beragadhat végtelen ciklusba.
- **Optimális:** Nem.
- **Idő- és tárigény:** Exponenciális a legrosszabb esetben.

---

### A\* keresés

Az A\* kombinálja a megtett út valódi költségét és a heurisztikus becslést:

> **f(n) = g(n) + h(n)**

ahol g(n) a kezdőponttól n-ig megtett út valódi költsége, h(n) pedig a becsült hátralévő költség n-től a célig.

**Elfogadható heurisztika:** h(n) soha nem becsüli túl a valódi hátralévő költséget – mindig alábecsül vagy pontosan becsül. Ez garantálja, hogy az A\* megtalálja az optimális megoldást.

Romániai példával: a légvonalbeli távolság elfogadható heurisztika, mert a valódi közúti távolság sosem lehet rövidebb, mint a légvonal.

- **Teljes:** Igen, ha véges sok csúcs van.
- **Optimális:** Igen, ha a heurisztika elfogadható.
- **Időigény:** Exponenciális – de jó heurisztikával hatalmas mértékben csökkenthető a vizsgált csúcsok száma.
- **Tárigény:** Az összes csúcsot memóriában tartja – ez a fő korlátja.

