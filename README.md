# Daniel Ohtra
<img width="985" height="813" alt="image" src="https://github.com/user-attachments/assets/7f9728f5-d322-42c3-bda6-69821199dbdd" />
# Tööde haldamise ja monitoorimise süsteemi dokumentatsioon

## 1. Süsteemi eesmärk

Süsteemi eesmärk on võimaldada ettevõttel hallata projekte, nende ülesandeid, tööaega, töötajaid ja projektidega seotud faile.

Süsteemi saavad kasutada ainult sisse loginud kasutajad.

Süsteemis saab jälgida:
- projekti eelarvet;
- projekti senist maksumust;
- ülesannete eeldatavat ajakulu;
- ülesannete tegelikku ajakulu;
- projekti edenemist.

---

## 2. Kasutaja

`Kasutaja` tähistab süsteemi kasutavat töötajat.

### Andmed

- `Nimi` – kasutaja nimi
- `Email` – kasutaja e-posti aadress
- `Parool` – kasutaja parool

Kasutaja võib:
- kuuluda projekti meeskonda;
- olla ülesande vastutaja;
- sisestada töölogisid.

---

## 3. Projekt

`Projekt` sisaldab projekti põhiandmeid.

### Andmed

- `ProjektiNimi` – projekti nimi
- `ProjektiAlgus` – projekti alguskuupäev
- `ProjektiTähtaeg` – projekti tähtaeg
- `ProjektiEelarve` – projekti planeeritud eelarve
- `TunniHind` – ühe töötunni hind
- `ProjektiMeeskond` – projektiga seotud töötajad

### Meetodid

- `ArvutaMaksumus()` – arvutab projekti senise maksumuse

Ühel projektil võib olla mitu ülesannet.

---

## 4. Ülesanne

`Ülesanne` kuulub konkreetse projekti alla ja kirjeldab tehtavat tööd.

### Andmed

- `Pealkiri` – ülesande nimetus
- `Algus` – ülesande alguskuupäev
- `EeldatavAjakulu` – ülesande planeeritud ajakulu
- `Kirjeldus` – ülesande täpsem kirjeldus
- `Valmis` – näitab, kas ülesanne on lõpetatud
- `FikseeritudHind` – ülesande fikseeritud hind

### Meetodid

- `ArvutaMaksumus()` – arvutab ülesande maksumuse

Ülesandel on vastutav kasutaja.

Ülesande juurde saab lisada:
- töölogisid;
- faile.

---

## 5. TööLogi

`TööLogi` salvestab ülesande tegemisele kulunud tööaja.

### Andmed

- `Kuupäev` – töö tegemise kuupäev
- `Ajakulu` – tööle kulunud aeg
- `Kirjeldus` – tehtud töö kirjeldus

Töölogi kuulub konkreetse ülesande juurde.

Töölogi on seotud kasutajaga, kes töö teostas.

---

## 6. Fail

`Fail` võimaldab lisada ülesande juurde dokumente, jooniseid ja muid vajalikke faile.

### Andmed

- `FailiNimi` – faili nimi
- `FailiAsukoht` – faili salvestamise asukoht
- `ÜleslaadimiseAeg` – faili üleslaadimise kuupäev ja kellaaeg

Ühe ülesande juurde võib lisada mitu faili.

---

## 7. Klasside vahelised seosed

### Kasutaja ja Projekt

`Kasutaja ↔ Projekt`

Projektiga võib olla seotud mitu kasutajat ning kasutaja võib osaleda mitmes projektis.

### Projekt ja Ülesanne

`Projekt → Ülesanne`

Ühel projektil võib olla mitu ülesannet.

### Kasutaja ja Ülesanne

`Kasutaja → Ülesanne`

Kasutaja võib olla ülesande vastutaja.

### Ülesanne ja TööLogi

`Ülesanne → TööLogi`

Ühe ülesande kohta võib olla mitu töölogi.

### Kasutaja ja TööLogi

`Kasutaja → TööLogi`

Töölogi juurde salvestatakse töö teostanud kasutaja.

### Ülesanne ja Fail

`Ülesanne → Fail`

Ühe ülesande juurde võib lisada mitu faili.

---

## 8. Maksumuse arvutamine

Kui ülesandel ei ole fikseeritud hinda, arvutatakse ülesande maksumus töötundide ja projekti tunnihinna järgi.

```text
Ülesande maksumus = tegelik ajakulu × projekti tunnihind
