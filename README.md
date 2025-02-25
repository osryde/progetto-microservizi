# Progetto microservizi

Progetto per il corso di Microservizi dell'università di Parma


## Scopo del progetto

L'insieme dei microservizi consente di simulare la cattura di un Pokemon. Un microservizio si occupa della cattura mentre gli altri due vanno a rappresentare il Pokedex e l'allenatore.

<p align="center">
  <img width="400" height="150" src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/98/International_Pok%C3%A9mon_logo.svg/2560px-International_Pok%C3%A9mon_logo.svg.png">
</p>

Di seguito l'elenco dei microservizi e una breve descrizione:

- **PokemonCaptureService**: Si occupa della cattura dei Pokemon e di scovare nuovi oggetti per il TrainerService. Mediante Kafka riesce ad inviare i dati relativi a ciò che ha trovato.
- **TrainerService**: gestisce lo zaino e gli oggetti trovati. Permette anche la creazione di una squadra casuale basata sulle catture effettuate.
- **PokedexService**: gestisce i pokemon catturati fornendo dati relativi ai pokemon mancanti e ai pokemon già ottenuti.

## Esecuzione
Per eseguire il codice basta lanciare il file docker-compose. Non è quindi necessario modificare nulla.
