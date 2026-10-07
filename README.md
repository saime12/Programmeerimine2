# Daniel Ohtra
<img width="728" height="734" alt="image" src="https://github.com/user-attachments/assets/18ad0294-dade-4c3f-b531-fad07b1d5609" />
# Tööde haldamise süsteem

## Eesmärk

Süsteem aitab hallata projekte, ülesandeid, töötunde ja faile.

Süsteemi saavad kasutada ainult sisse loginud kasutajad.

## Kasutaja

Kasutaja andmed:
- nimi
- email
- parool

Kasutaja saab olla projektis, vastutada ülesande eest ja lisada tööaega.

## Projekt

Projekt sisaldab:
- nime
- alguskuupäeva
- tähtaega
- eelarvet
- tunnihinda
- töötajaid

Projektile saab lisada ülesandeid.

`ArvutaMaksumus()` arvutab, kui palju raha on projektile kulunud.

## Ülesanne

Ülesanne sisaldab:
- pealkirja
- alguskuupäeva
- arvatavat ajakulu
- kirjeldust
- kas töö on valmis
- kindlat hinda

Ülesandel on vastutaja.

Ülesande juurde saab lisada tööaega ja faile.

## TööLogi

Töölogi näitab, kui palju aega töö peale kulus.

Andmed:
- kuupäev
- ajakulu
- kirjeldus
- töötaja

## Fail

Faili andmed:
- faili nimi
- faili asukoht
- üleslaadimise aeg

## Seosed

- Kasutaja ↔ Projekt
- Projekt → Ülesanne
- Kasutaja → Ülesanne
- Ülesanne → TööLogi
- Kasutaja → TööLogi
- Ülesanne → Fail

## Maksumus

Kui ülesandel pole kindlat hinda:

```text
Maksumus = töötunnid × tunnihind
