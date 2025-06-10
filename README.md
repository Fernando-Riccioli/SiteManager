# SiteManager - Progetto Advanced Programming Languages 2024-2025
- Fernando Riccioli
- Daniele Lucifora

# Descrizione
SiteManager è un'applicazione multi-piattaforma sviluppata in **C#**, **C++** e **Python** per la gestione efficiente dei cantieri edili. Offre un'interfaccia grafica intuitiva e funzionalità avanzate di analisi dei dati.

## Funzionalità Principali

- **Gestione dei Materiali**: Tracciamento e gestione dei materiali utilizzati nei cantieri.
- **Monitoraggio dei Progressi**: Controllo in tempo reale dello stato di avanzamento dei lavori.
- **Generazione di Report**: Creazione di report dettagliati per la revisione e presentazione dei dati.
- **Generazione di Statistiche**: Calcolo dei costi (materiali, personale, spese totali) e generazione di grafici a torta.

## Architettura del Sistema  

Le tecnologie principali utilizzate sono:  
- **.NET** per il backend e l'interfaccia utente (**XAML**).  
- **Docker** per la containerizzazione e la distribuzione.  

L'architettura è formata dai seguenti moduli:

| Modulo                   | Linguaggio   | Descrizione                                        |
|--------------------------|--------------|----------------------------------------------------|
| Interfaccia Utente       | C#           | UI intuitiva per la gestione dei cantieri.         |
| Logica di Business       | C#           | Gestione dati e operazioni CRUD.                   |
| Generazione Statistiche  | C++          | Calcoli sulle statistiche.                         |
| Analisi dei Dati         | Python       | Generazione report PDF.                            |  

## Build & Deploy
1. Clonare la repository e spostarsi all'interno della cartella `/SiteManager`.
2. Eseguire il comando `docker compose up -d`.
3. Spostarsi all'interno della cartella innestata `/SiteManager`.
4. Eseguire il comando `dotnet build` per compilare l'applicazione.
5. Avviare l'applicazione eseguendo:
   - MacOS: `dotnet run -f net9.0-maccatalyst`
   - Windows: `dotnet run -f net9.0-windowsv10.0.19041.0`
