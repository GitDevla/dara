Adatszerkezetekkel kapcsolatos alapfogalmak: absztrakció, absztrakt adatszerkezetek. Elemi adatszerkezetek: lista, verem, sor. Halmaz, multihalmaz, tömb. Fák ábrázolása, bejárások, keresés, beszúrás, törlés.

---
## 1. Absztrakció és absztrakt adatszerkezetek

### Absztrakció

Az absztrakció azt jelenti, hogy a lényegtelen részleteket elrejtjük, és csak az elvi, logikai működéssel foglalkozunk. Nem azzal törődünk, hogy a számítógép memóriájában hol pontosan és hogyan tárolódnak az adatok – csak azzal, hogy milyen műveletek végezhetők rajtuk és milyen tulajdonságaik vannak.

### Absztrakt adatszerkezet

Az absztrakt adatszerkezet az adatelemek és köztük lévő kapcsolatok **logikai modellje**, függetlenül attól, hogy a valóságban hogyan van megvalósítva a memóriában.

Négy összetevője van:
- **Adatelemek** – milyen adatokat tárolunk
- **Kapcsolatok** – az elemek hogyan viszonyulnak egymáshoz
- **Műveletek** – mit lehet csinálni az adatszerkezettel (létrehozás, módosítás, lekérdezés, törlés)
- **Reprezentáció** – hogyan helyezkednek el az elemek a memóriában

Az adatszerkezeteket többféleképpen osztályozhatjuk:
- **Elemtípus szerint:** homogén (minden elem azonos típusú) vagy heterogén (különböző típusúak)
- **Elemszám szerint:** statikus (rögzített méret) vagy dinamikus (méret változhat)
- **Kapcsolat szerint:** lehet struktúra nélküli, szekvenciális (lánc), hierarchikus (fa) vagy hálós (gráf)
- **Memóriában való elhelyezkedés szerint:** folytonos (egymás melletti helyek) vagy szétszórt (pointerekkel összekötött szétszórt helyek)

---

## 2. Elemi adatszerkezetek

### Lista

A lista egy **egyszeresen vagy kétszeresen láncolt** adatszerkezet. Minden elem tartalmaz egy értéket és egy mutatót (pointert), amely a következő elemre mutat. Kétszeresen láncolt változatnál az előző elemre mutató pointer is megvan.

Jellemzői: homogén, dinamikus, szekvenciális, szétszórt memóriaelrendezés.

Műveletek: keresés, beszúrás, törlés.

---

### Verem (Stack)

A verem egy **LIFO** (Last In, First Out) elvű adatszerkezet – magyarul: az utoljára betett elemet vesszük ki először. Képzeljük el, mint egy tányérpaklit: mindig a legfelső tányért vesszük le.

Jellemzői: homogén, dinamikus, szekvenciális, folytonos.

Két művelete van:
- **Push** – elem tetejére rakása
- **Pop** – a legfelső elem kivétele

---

### Sor (Queue)

A sor egy **FIFO** (First In, First Out) elvű adatszerkezet – az elsőként betett elemet vesszük ki először, mint egy valódi sorban állás.

Két mutatót tartunk nyilván: a fej (head) mutat a legrégebbi elemre, a farok (tail) a legújabbra.

Jellemzői: homogén, dinamikus, szekvenciális, folytonos.

Két művelete van:
- **Enqueue** – elem hozzáadása a sor végéhez
- **Dequeue** – elem kivétele a sor elejéről

Három implementációs stratégia létezik:
- **Naiv sor:** a törlésnél minden elem eltolódik – pazarló
- **Sétáló sor:** az elemek nem tolódnak el, de a lefoglalt memória nő
- **Ciklikus sor:** a legjobb megoldás – a tömb végét elérve visszaugrik az elejére, így a memória hatékonyan újrafelhasználható

---

### Halmaz (Set)

A halmazban minden elem **csak egyszer szerepelhet**, nincs duplikáció. Ha előre ismerjük, milyen elemek kerülhetnek bele, nagyon hatékonyan tárolható bináris sorozatként: az i-edik bit 1, ha az i-edik elem benne van, 0 ha nincs.

Jellemzői: homogén, dinamikus, struktúra nélküli, folytonos.

Műveletek elemszinten: bennfoglaltság ellenőrzése, beszúrás, törlés.
Halmazszinten: unió, metszet, különbség.

---

### Multihalmaz

Olyan halmaz, amelyben ugyanaz az elem **többször is szerepelhet**. A tárolás nem egy igaz/hamis bittel, hanem egy számlálóval történik: megadjuk, hogy az adott elem hányszor fordul elő.

---

### Tömb (Array)

A tömb egy **előre rögzített méretű**, folytonos memóriaelrendezésű adatszerkezet, ahol minden elem egyedi indexszel érhető el.

Jellemzői: homogén, statikus, asszociatív, folytonos.

- **Vektor:** egydimenziós tömb – egyszerű soros lefoglalás a memóriában
- **Mátrix:** kétdimenziós tömb – tárolható sorfolytonosan (soronként egymás után) vagy oszlopfolytonosan (oszloponként egymás után); közvetlen hozzáférés mindkét esetben megmarad
- **Ritka mátrix:** ha a mátrix elemeinek nagy része nulla, felesleges az összes nullát tárolni. Ehelyett csak a nem-nulla elemek sor- és oszlopindexét és értékét tároljuk el (háromoszlopos reprezentáció). Hátránya, hogy elvész a közvetlen hozzáférés. Akkor éri meg, ha a nem-nulla elemek száma kevesebb, mint a mátrix elemeinek harmada.

---

## 3. Fák

### A fa fogalma

A fa egy **hierarchikus adatszerkezet**: csúcsokból és azokat összekötő élekből áll. Alapvető tulajdonsága, hogy **nincs benne kör** – bármely csúcsba pontosan egy út vezet. Van egy kitüntetett csúcsa, a **gyökér**, amelyből a többi csúcs ered.

Jellemzői: homogén, dinamikus, hierarchikus. Reprezentációja lehet folytonos (hierarchikus lista) vagy szétszórt (pointerekkel).

**Bináris fa:** olyan fa, amelyben minden csúcsnak legfeljebb két gyereke van (bal és jobb gyerek).

---

### Fa bejárások

A bejárás olyan eljárás, amely a fa minden csúcsát **pontosan egyszer** látogatja meg. Háromféle bejárást különböztetünk meg aszerint, hogy a gyökércsúcsot mikor dolgozzuk fel:

- **Preorder:** először a csúcsot dolgozzuk fel, majd a bal részfát, majd a jobb részfát *(Gyökér → Bal → Jobb)*
- **Inorder:** először a bal részfát, majd a csúcsot, majd a jobb részfát *(Bal → Gyökér → Jobb)*
- **Postorder:** először a bal részfát, majd a jobb részfát, majd a csúcsot *(Bal → Jobb → Gyökér)*

Mindhárom bejárás rekurzív módon működik.

> **Kifejezésfa:** ha a fa egy matematikai kifejezést ábrázol (csúcsokban műveleti jelek és számok), akkor az inorder bejárás az emberi szemnek szokásos infixes alakot adja (de zárójelezés nélkül nem mindig egyértelmű), a preorder a prefixes (lengyel), a postorder a postfixes (fordított lengyel) jelölést.

---

### Bináris keresőfa

Olyan bináris fa, amelyben minden csúcsra igaz: a **bal részfában kisebb, a jobb részfában nagyobb** értékek vannak.

**Keresés:** a gyökértől indulva, ha a keresett érték kisebb, mint az aktuális csúcs, balra lépünk, ha nagyobb, jobbra – egészen addig, amíg megtaláljuk az elemet vagy elérünk egy üres helyet.

**Beszúrás:** kereséshez hasonlóan járunk el, amíg el nem érünk egy üres helyet, oda szúrjuk be az új elemet.

**Törlés:** három eset:
- Ha a törlendő csúcsnak **nincs gyereke**: egyszerűen töröljük.
- Ha **egy gyereke van**: a gyerek átveszi a törölt csúcs helyét.
- Ha **két gyereke van**: a törölt csúcs helyére a bal részfa legnagyobb elemét rakjuk (ez az inorder előd).

---
