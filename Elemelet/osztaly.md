# 3. Tétel (Infó) – Felolvasható változat (PTI BSc záróvizsga)

---
Az objektumorientált paradigma alapfogalmai. Osztály, objektum, példányosítás. Öröklődés, osztályhierarchia. Polimorfizmus, metódustúlterhelés. A bezárási eszközrendszer. Absztrakt osztályok és interfészek. Típustagok.

---

## 2. Osztály és objektum

### Az osztály

Az osztály egy **tervrajz** vagy sablon, amely meghatározza, hogy az abból létrehozott objektumoknak milyen adataik (attribútumaik) és milyen viselkedésük (metódusaik) lesznek. Az osztály maga nem foglal helyet a memóriában – csak leírja, hogyan nézzen ki majd a belőle létrehozott objektum.

### Az objektum

Az objektum az osztály egy **konkrét példánya a memóriában**. Amikor az osztályból objektumot hozunk létre (`new` kulcsszóval), azt **példányosításnak** nevezzük. A létrehozott objektumnak már saját, konkrét értékei vannak az attribútumokra.


---

## 3. Az OOP négy alapelve

### Egységbezárás (Encapsulation)

Az egységbezárás azt jelenti, hogy az adatokat (attribútumokat) és az azokat kezelő műveleteket (metódusokat) **egy egységbe, az osztályba zárjuk**, és a belső adatokat elrejtjük a külvilág elől.

**Miért fontos?** Ha egy `Bankszamla` osztályban az egyenleg közvetlen eléréssel módosítható lenne, a kódban bárhonnan be lehetne állítani érvénytelen értéket. Ha viszont az egyenleg `private` (rejtett), és csak egy `penzKiveve()` metóduson keresztül módosítható – amely elvégzi az ellenőrzést is –, akkor az objektum állapota mindig érvényes marad.

**Megvalósítása:** Láthatósági módosítókkal és getter/setter metódusokkal:

- `private`: csak az osztályon belül érhető el
- `protected`: az osztályon belül és a leszármazott osztályokban
- `public`: mindenki számára elérhető

A jó gyakorlat: az attribútumok `private`-ok, az adatokhoz csak ellenőrzött `public` metódusok (getterek, setterek) adnak hozzáférést.

---

### Öröklődés (Inheritance)

Az öröklődés lehetővé teszi, hogy egy új osztályt egy már meglévő alapján hozzunk létre. Az új osztály (gyerekosztály / leszármazott) **átveszi** az ős osztály (szülőosztály) attribútumait és metódusait, és kiegészítheti vagy felülírhatja azokat.

**Miért hasznos?** Kód újrahasznosítás: amit az ősben egyszer megírunk, nem kell újra megírni minden leszármazottban. Egy `Allat` osztályból örökölhet a `Ragadozo`, abból a `Macska` – mindkettő automatikusan megkapja az `Allat` összes tulajdonságát.

**Osztályhierarchia:** Az öröklődési kapcsolatok fát alkotnak. A megfelelő hierarchia felépítése tervezési döntés – fontos, hogy valódi „IS-A" (egy X egyben Y is) kapcsolat legyen az ős és a leszármazott között. Pl. „egy Macska egyben Ragadozo, és egyben Allat is" – ez valódi öröklési hierarchia.

**Fontos részlet:** A konstruktor és destruktor nem öröklődik automatikusan, de az ős konstruktora explicit módon meghívható a leszármazottból.

---

### Polimorfizmus (Polymorphism)

A polimorfizmus azt jelenti, hogy **ugyanaz a hívás** másképp viselkedik az objektum tényleges típusától függően. Ez az OOP egyik legerőteljesebb eszköze.

**Két fajtája van:**

**Metódustúlterhelés (Overloading) – fordítási idejű polimorfizmus:**
Ugyanaz a metódusnév, de különböző paraméterlistával többször is megírható. A fordítóprogram a hívás paraméterei alapján dönti el, melyik verziót kell végrehajtani.

Például egy `osszead()` metódus megírható egész számokra és lebegőpontosokra is – a híváskor a paraméterek típusától függően a megfelelő verzió fut le. Ez fordítási időben dől el.

**Metódus-felülírás (Overriding) – futási idejű polimorfizmus:**
A leszármazott osztály felülírja az ős egy metódusát – saját implementációt ad hozzá. Amikor futás közben az objektum tényleges típusától függően dől el, melyik implementáció fut le, azt **késői kötésnek** (late binding) nevezzük.

Klasszikus példa: van egy `Allat` típusú lista, amelybe `Kutya` és `Macska` objektumokat teszünk. Ha végighívjuk rajtuk a `beszel()` metódust, minden állat a saját hangját adja ki – annak ellenére, hogy a lista típusa `Allat`. A fordítóprogram nem tudja előre, melyik futtatódik – futás közben dől el.

**Lencint (final) metódus és osztály:** Bizonyos metódusok megjelölhetők úgy, hogy nem írhatók felül a leszármazottakban. Egy lencint osztályból nem lehet tovább örököltetni.

---

### Absztrakció (Abstraction)

Az absztrakció azt jelenti, hogy csak a lényeges részleteket tesszük láthatóvá, az implementáció részleteit elrejtjük. A felhasználónak tudnia kell, **mit** csinál egy metódus, de nem kell tudnia, **hogyan** csinálja.

---

## 4. A bezárási eszközrendszer részletesen

Az egységbezárás technikai megvalósítása:

**Láthatósági módosítók (hozzáférési szintek):**

| Módosító | Saját osztály | Csomag | Leszármazott | Mindenki |
|---|---|---|---|---|
| `private` | igen | nem | nem | nem |
| csomag szintű | igen | igen | nem | nem |
| `protected` | igen | igen | igen | nem |
| `public` | igen | igen | igen | igen |

**Getter és setter metódusok:** Az `private` attribútumokat getterekkel (olvasás) és setterekkel (írás) tesszük elérhetővé. A setter tartalmazza az érvényességi ellenőrzést – pl. egy bankszámla egyenlegét nem lehet közvetlenül negatívra állítani, de a `penzKiveve()` metódus ellenőrzi, van-e elegendő fedezet.

Ezzel garantáljuk, hogy az objektum állapota mindig érvényes és konzisztens marad – ez az objektumorientált programozás egyik legtöbbet hangoztatott előnye.

---

## 5. Absztrakt osztályok és interfészek

### Absztrakt osztály

Az absztrakt osztály olyan osztály, amelynek **van legalább egy megírás nélküli (absztrakt) metódusa**. Ezeknek az absztrakt metódusoknak csak a fejükre (nevük, paramétereik) van megadva, az implementációjuk nincs – a leszármazott osztálynak **kötelező** megírnia őket.

Absztrakt osztályból **nem lehet közvetlenül objektumot példányosítani** – csak leszármaztatni lehet belőle. Arra való, hogy közös alapot adjon a leszármazottaknak, miközben bizonyos viselkedést kötelezővé tesz.

Lehet benne teljesen implementált (konkrét) metódus is – a leszármazottak ezeket öröklik, az absztrakt metódusokat viszont kötelesek megvalósítani.

---

### Interfész

Az interfész egy **„szerződés"**: csak metódus-deklarációkat tartalmaz (esetleg konstansokat), implementációt alapvetően nem. Egy osztály, amely megvalósít (implementál) egy interfészt, köteles az interfészben deklarált összes metódust megírni.

**A legfontosabb különbség az absztrakt osztálytól:** Egy osztály csak egy osztályból örökölhet (egyszeres öröklődés), de **több interfészt is implementálhat egyszerre**. Ez lehetővé teszi, hogy egy osztály többféle „képességgel" is rendelkezzen.

Például egy `Kacsa` osztály örökölhet az `Allat` absztrakt osztályból, és egyidejűleg implementálhatja az `Uszni` és a `Repulni` interfészeket is.

**Mikor melyiket?**
- **Absztrakt osztály:** Ha a leszármazottak között valódi „IS-A" kapcsolat van, és közös alap-implementációt is szeretnénk adni.
- **Interfész:** Ha csak egy képességet, viselkedési szerződést akarunk előírni, és nincs szükség közös implementációra.

---

## 6. Típustagok (statikus tagok)

A **típustag** (statikus tag) az **osztályhoz** tartozik, nem az egyes objektumokhoz. Minden objektum osztozik rajta – az összes példány ugyanazt a statikus tagot látja. `static` kulcsszóval jelöljük.

**Mikor hasznos?** Ha az osztály összes példányára vonatkozó, közös adatot akarunk tárolni. Pl. egy „hány objektum jött létre ebből az osztályból" számlálót – ezt minden létrehozásnál növeljük, és az összes objektum közösen tárolja.

**Statikus metódus:** Szintén az osztályhoz tartozik, nem az objektumhoz. Objektum létrehozása nélkül, az osztály nevén keresztül hívható meg. Fontos korlát: statikus metódusból nem lehet hozzáférni a nem-statikus attribútumokhoz vagy metódusokhoz, mert azok csak az egyes objektumokhoz tartoznak, és itt nincs `this` referencia (nincs konkrét objektum).

Tipikus példa: a `Math.sqrt()` statikus metódus – nem kell `Math` objektumot létrehozni a négyzetgyökvonáshoz, az osztályon keresztül közvetlenül hívható.

---

## Összefoglalás – az OOP négy pillére egy mondatban

| Alapelv | Lényeg kimondva |
|---|---|
| **Egységbezárás** | Az adatokat és a rajtuk végzett műveleteket egy egységbe zárjuk, a belső részleteket elrejtjük |
| **Öröklődés** | Meglévő osztályból új osztályt hozunk létre, átvéve és kibővítve a meglévő kódot |
| **Polimorfizmus** | Ugyanaz a hívás másképp viselkedik, attól függően, milyen típusú objektumon hívjuk |
| **Absztrakció** | Csak a lényeges felületet tesszük láthatóvá, az implementáció részleteit elrejtjük |
