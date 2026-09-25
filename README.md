# Daniel Ohtra
<img width="985" height="813" alt="image" src="https://github.com/user-attachments/assets/7f9728f5-d322-42c3-bda6-69821199dbdd" />
# Tööde haldamise süsteem

## Eesmärk

Süsteem aitab ettevõttel hallata projekte, ülesandeid, töötunde ja faile.

Süsteemi saavad kasutada ainult sisse loginud kasutajad.

---

## Kasutaja

Kasutaja on süsteemi kasutav töötaja.

Andmed:
- nimi
- email
- parool

Kasutaja saab olla projekti liige, ülesande vastutaja ja töölogi teostaja.

---

## Projekt

Projekt sisaldab:

- projekti nime
- alguskuupäeva
- tähtaega
- eelarvet
- tunnihinda
- projekti meeskonda

Projektile saab lisada ülesandeid.

`ArvutaMaksumus()` arvutab projekti senise maksumuse.

---

## Ülesanne

Ülesanne sisaldab:

- pealkirja
- alguskuupäeva
- eeldatavat ajakulu
- kirjeldust
- infot, kas ülesanne on valmis
- fikseeritud hinda

Ülesandel on vastutaja.

Ülesandele saab lisada:
- töölogisid
- faile

---

## TööLogi

Töölogi näitab, kui palju aega ülesandele kulus.

Andmed:
- kuupäev
- ajakulu
- kirjeldus
- teostaja

---

## Fail

Ülesande juurde saab lisada faile.

Faili andmed:
- faili nimi
- faili asukoht
- üleslaadimise aeg

---

## Seosed

- Kasutaja ↔ Projekt
- Projekt → Ülesanne
- Kasutaja → Ülesanne
- Ülesanne → TööLogi
- Kasutaja → TööLogi
- Ülesanne → Fail

---

## Maksumuse arvutamine

Kui ülesandel pole fikseeritud hinda:

```text
Maksumus = töötunnid × tunnihind
Ülesande maksumus = tegelik ajakulu × projekti tunnihind
