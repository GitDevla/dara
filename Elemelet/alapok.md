# 2. Tétel (Infó) – Felolvasható változat (PTI BSc záróvizsga)

---
Adattípusok. Változó. Műveletek, operátorok, operandusok. Vezérlési szerkezetek. Kifejezések. Utasítások. Programegységek. Paraméterkiértékelés, paraméterátadás. Blokk. Hatáskörkezelés, láthatóság. Absztrakt adattípus. Kivételkezelés.

---

## 1. Adattípusok

### Mi az adattípus?

Az adattípus az adatabsztrakció első megjelenési formája a programozásban. Három dolog határozza meg:

- **Tartomány:** Milyen értékeket vehet fel – pl. egész számok, igaz/hamis.
- **Műveletek:** Mit lehet vele csinálni – pl. számokat összeadni, szövegeket összefűzni.
- **Reprezentáció:** Hogyan helyezkedik el a memóriában – pl. hány bájton tárolódik.

---

### Egyszerű (primitív) típusok

Minden típusos nyelvben vannak beépített alaptípusok:

- **Numerikus típusok:** Egész számok (`int`), lebegőpontos számok (`float`, `double`).
- **Karakter és szöveg:** Egyetlen karakter (`char`), szöveg (`string`).
- **Logikai típus:** Igaz vagy hamis értéket vehet fel (`boolean`).
- **Mutató (pointer):** Memóriacímet tárol – egy másik változóra mutat.
- **Felsorolás (`enum`):** Olyan típus, amelyet mi hozunk létre, és mi soroljuk fel az összes lehetséges értékét. Pl. egy hétnapjait felsoroló enum: Hétfő, Kedd, Szerda… A háttérben a fordító egészekként (0, 1, 2...) kezeli őket, de a kódban olvashatóbb nevekkel lehet velük dolgozni.

---

### Összetett típusok

Több egyszerű típust egységbe foglaló szerkezetek – pl. tömbök, rekordok, osztályok. Ezek alkotják az adatszerkezeteket.

---

## 2. Változó

A változó egy **nevesített memóriaterület**, amelynek:
- **neve** van (azonosító) – ezzel hivatkozunk rá a kódban,
- **típusa** van – meghatározza, milyen értéket tárolhat,
- **értéke** van – az aktuálisan tárolt adat.

A változókat lehet **deklarálni** (csak bejelentjük, hogy létezik, de még nem adjuk meg az értékét) vagy **definiálni** (deklarálás + értékadás egyszerre).

**Tárolás szerint:** Statikus tárolású változók a program teljes futása alatt léteznek. Dinamikus tárolású változók csak a saját programegységük (blokk, függvény) futása alatt élnek, utána felszabadulnak.

---

### Deklaráció módjai

- **Explicit:** A programozó maga írja ki a típust – `int x;`.
- **Implicit:** A fordító a változónévből következtet a típusra (régi nyelvek, pl. Fortranban az `i`-vel kezdődő nevek automatikusan egészek).
- **Automatikus:** A fordító a kontextusból, a kezdőértékből következtet a típusra – pl. C++-ban az `auto kulcsszo = 42;` automatikusan egész típusú lesz.

---

## 3. Műveletek, operátorok, operandusok

### Operátor

Az operátor egy műveleti jel, amely meghatározza, milyen számítást kell elvégezni. Típusai:

- **Aritmetikai:** Összeadás, kivonás, szorzás, osztás, maradékos osztás (`%`).
- **Összehasonlító:** Egyenlőség, különbözőség, kisebb, nagyobb stb. – eredményük logikai érték.
- **Logikai:** És (`&&`), vagy (`||`), nem (`!`) – logikai kifejezések összekapcsolására.
- **Értékadó operátorok:** Az egyszerű = mellett rövidített formák, pl. `+=` (értéket növel és visszaír), `++` (eggyel növel).

### Operandus

Az operandus az, **amin** az operátor a műveletet elvégzi. Lehet: változó, literál (konkrét szám vagy szöveg a kódban), nevesített konstans, vagy függvényhívás – lényegében bármi, aminek értéke van.

---

## 4. Kifejezések

A kifejezés egy szintaktikai eszköz, amely ismert értékekből kiszámít egy új értéket. Minden kifejezésnek van **értéke** és **típusa**.

Összetevői: operandusok, operátorok és zárójelek (amelyek a kiértékelési sorrendet befolyásolják).

**A legegyszerűbb kifejezés** egyetlen operandusból áll – pl. csak egy szám vagy változó.

---

### Kifejezések három alakja

A kifejezéseket háromféle jelölésmódban lehet felírni, attól függően, hova kerül az operátor:

- **Infix (közbeírt):** `3 * 5` – Az operátor az operandusok között van. Ez az emberek számára természetes alak.
- **Prefix (előreírt / lengyel jelölés):** `* 3 5` – Az operátor az operandusok elé kerül. Zárójelezés nélkül is egyértelmű. Számítógépes kiértékelésnél hasznos.
- **Postfix (hátulírt / fordított lengyel jelölés):** `3 5 *` – Az operátor az operandusok után kerül. Verem-alapú számítógépek (és kalkulátorok) ezt az alakot használják belül.

---

## 5. Utasítások és vezérlési szerkezetek

### Utasítástípusok

**Deklarációs utasítások:** Nem hajtódnak végre futásidőben – a fordítónak szólnak, hogy lefoglaljon memóriát egy változónak. Befolyásolják a tárgykódot, de önmagukban „nem csinálnak semmit" futás közben.

**Végrehajtható utasítások:** Ezekből generálja a fordítóprogram a tényleges futtatható kódot:
- **Értékadó utasítás:** Egy változóhoz értéket rendel.
- **Üres utasítás:** Semmit nem csinál – szintaktikai helyőrző.
- **GOTO / ugró utasítás:** Vezérlést ad át egy másik kódpontnak. Kerülendő, mert olvashatatlan kódhoz vezet.
- **Elágaztató utasítás (`if-else`, `switch`):** Feltétel alapján más-más ágat hajt végre.
- **Ciklusszervező utasítás:** Ismétlő végrehajtás.
- **Hívó utasítás:** Alprogramot (függvényt, eljárást) hív meg.
- **Vezérlésátadó utasítás:** `break` (ciklusból kilép), `return` (visszatér a hívóhoz, esetleg értékkel).

---

### Ciklusszervező utasítások

**While ciklus (előltesztelős):** A feltétel kiértékelése a ciklusmag végrehajtása **előtt** történik. Ha a feltétel már az elején hamis, a ciklusmag egyszer sem fut le.

**Do-while ciklus (hátultesztelős):** A feltétel a ciklusmag végrehajtása **után** kerül kiértékelésre. A ciklusmag legalább egyszer mindig lefut.

**For ciklus (előírt lépésszámú):** Akkor használjuk, ha előre tudjuk, hányszor kell ismételni. Tartalmaz inicializálást, feltételt és léptetőt egyetlen sorban.

---

## 6. Programegységek

A programegység a program szövegének önálló, logikailag összetartozó része. A program feladatait kisebb, kezelhetőbb egységekre tagoljuk – ez a **modularitás** alapja.

---

### Alprogramok (eljárások és függvények)

Az alprogram a **procedurális absztrakció** eszköze: bemeneti adatcsoportból kimeneti adatcsoportot állít elő. Ismerjük, mit csinál (specifikáció), de nem kell tudnunk, hogyan csinálja (implementáció). Ez a feketedoboz-elv.

**Miért jó?** Ismétlődő programrészt egyszer írunk meg, és csak hivatkozunk rá – ez az **újrafelhasználhatóság**. Az általánosítást formális paraméterekkel érjük el: a függvényt nem konkrét értékekre írjuk meg, hanem paraméterekkel, amelyeket híváskor adunk meg.

**Felépítése:**
- **Fej (specifikáció):** A név és a formális paraméterlista – ez az interfész, amit a hívónak ismernie kell.
- **Törzs (implementáció):** A deklarációk és a végrehajtható utasítások – ez a belső logika.

**Eljárás vs. függvény:**
- **Eljárás (void):** Nem ad vissza értéket – csak elvégez valamit, pl. kiír valamit a képernyőre.
- **Függvény:** Van visszatérési értéke – kiszámít valamit és visszaadja.

**Mellékhatás (side-effect):** Ha egy függvény a saját feladatán túl megváltoztatja a paramétereit vagy a globális környezetét, azt mellékhatásnak nevezzük. Általában kerülendő, mert nehezíti a kód megértését és tesztelését.

---

### Blokk (összetett utasítás)

A blokk egy másik programegység belsejébe ágyazott programegység, amelynek **nincs paramétere**. Kapcsos zárójelek (`{ }`) határolják. Tartalmazhat deklarációkat és végrehajtható utasításokat. A blokkban deklarált változók csak a blokkon belül léteznek.

---

## 7. Hatáskörkezelés és láthatóság

### Hatáskör (Scope)

Egy változó **hatásköre** (scope) a program szövegének az a része, ahol az adott névhez rendelt változó érvényes és elérhető. A hatáskör szinonimája a **láthatóság**.

**Alapszabály: a hatáskör befelé terjed, kifelé soha.** Egy belső blokkban deklarált változó nem érhető el a külső blokkból, de a belső blokkban elérhető a külső blokk változója.

- A **globális változók** a program egészében láthatók.
- A **lokális változók** csak abban a programegységben (függvényben, blokkban) láthatók, amelyben deklarálták őket.

---

### Árnyékolás (Shadowing)

Ha egy belső blokkban ugyanolyan névvel deklarálunk egy változót, mint ami a külső blokkban is létezik, a belső deklaráció **eltakarja** (árnyékolja) a külsőt. A belső blokkon belül az új, belső változó érvényes; a külső blokk változója ideiglenesen elérhetetlen.

---

## 8. Paraméterkiértékelés és paraméterátadás

### Formális és aktuális paraméter

- **Formális paraméter:** A függvény definíciójában szereplő névfoglalás – pl. `void osszead(int a, int b)` esetén `a` és `b` a formális paraméterek.
- **Aktuális paraméter:** A függvény hívásakor ténylegesen átadott érték – pl. `osszead(3, 5)` esetén `3` és `5` az aktuális paraméterek.

**Paraméterkiértékelés:** Az a folyamat, amelynek során az aktuális paraméterek hozzárendelődnek a formális paraméterekhez. Ez általában pozíció szerint történik (az első aktuális paraméter az első formálishoz kerül stb.).

---

### Paraméterátadás módjai

**Érték szerinti átadás (Call by Value):** A függvény az aktuális paraméter **másolatát** kapja. Ha a függvényen belül megváltoztatjuk a paramétert, az eredeti változó **nem változik meg**. Ez a legbiztonságosabb módszer – nincs mellékhatás.

**Cím szerinti átadás (Call by Reference):** A függvény az aktuális paraméter **memóriacímét** kapja. Ha a függvényen belül megváltoztatjuk a paramétert, az eredeti változó **is megváltozik**. Hatékony nagy adatszerkezetek esetén (nem kell másolni), de mellékhatást okozhat.

**Eredmény szerinti átadás (Call by Result):** A függvény a futása végén beírja a kiszámított eredményt az átadott változóba. A hívás pillanatában az értéket nem olvassa, csak a végén írja vissza.

---

## 9. Absztrakt adattípus (ADT)

Az absztrakt adattípus (ADT) olyan adattípus, amelynek:
- ismerjük a **nevét**,
- ismerjük a **tartományát** (milyen értékeket tárolhat),
- ismerjük a **műveleteit** (mit lehet rajta elvégezni),
- de **nem ismerjük** a belső reprezentációját és a műveletek konkrét implementációját.

Ez a **bezárás** és az **információrejtés** elvének megvalósítása: kívülről csak az interfészen (a nyilvános metódusokon) keresztül lehet az adathoz hozzáférni, a belső megvalósítás el van rejtve.

**Miért hasznos?** Ha a belső megvalósítás megváltozik (pl. egy veremet eredetileg tömbben, majd láncolt listában valósítunk meg), a kód többi részét nem kell módosítani, ha az interfész változatlan marad. Ez a **program–adat függetlenség** programozási szinten.

Pl. egy verem (Stack) ADT esetén a `push()` és `pop()` metódusokat használjuk – nem tudni és nem kell tudni, hogy alatta tömb vagy láncolt lista van.

---

## 10. Kivételkezelés

### Mi a kivétel?

A program futása közben előre nem látott, rendellenes helyzetek léphetnek fel: nullával való osztás, nem létező fájl megnyitása, memória elfogytával, érvénytelen index. Ezeket **kivételeknek** (exception) nevezzük.

Ha nincs kivételkezelés, az operációs rendszer kezeli a hibát – általában egyszerűen leállítja a programot. A kivételkezelési mechanizmus lehetővé teszi, hogy **mi magunk kezeljük a hibát** program szintjén.

---

### Try-catch-finally szerkezet

A kivételkezelés klasszikus eszköze:

```
try {
    // normál kód, ami hibát dobhat
} catch (KivetelTipus e) {
    // kezelés: mit csináljunk, ha bekövetkezik
} finally {
    // mindig lefut, hiba esetén is (pl. erőforrások felszabadítása)
}
```

- A **try blokkba** kerül a normál kód, amelynél hiba léphet fel.
- Ha a try blokkban kivétel keletkezik, a vezérlés azonnal a megfelelő **catch blokkba** ugrik, ahol kezeljük a hibát.
- A **finally blokk** mindig lefut, akár volt kivétel, akár nem – tipikusan ide kerül az erőforrások felszabadítása (pl. fájl bezárása).

Ha egy kivétel keletkezik és nincs elkapva, továbbterjed a hívási láncban felfelé – ha sehol nincs kezelve, a program leáll.

