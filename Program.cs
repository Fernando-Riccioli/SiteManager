using MySql.Data.MySqlClient;

namespace SiteManager
{
    class Program
    {
        static void Main()
        {   
            //Caricamento iniziale dei dati dal database
            List<Cantiere> cantieri = LettoreDatabase.OttieniCantieri();
            List<Operaio> operai = LettoreDatabase.OttieniOperai();
            List<Task> tasks = LettoreDatabase.OttieniTasks();
            List<Materiale> materiali = LettoreDatabase.OttieniMateriali();

                //PopolaCantieri riempie le liste all'interno di ciascun cantiere
            cantieri = PopolatoreCantieri.PopolaCantieri(cantieri, operai, materiali, tasks);
        }
    }

    class LettoreDatabase
    {   
        public static List<Cantiere> OttieniCantieri()   //static = posso accedere senza istanza perché appartiene alla classe
        { 
            List<Cantiere> cantieri = [];
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                string query = "SELECT * FROM cantieri";
                MySqlCommand command = new(query, connessione); //Comando = query + database
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Cantiere cantiere = new(reader.GetString("nome"), reader.GetDateTime("inizio"));
                    cantieri.Add(cantiere);
                }
                Console.WriteLine("Lista cantieri caricata.");
                Console.WriteLine();

                reader.Close();
                connessione.Close();
                return cantieri;
            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
                return cantieri;
            }
        }

        public static List<Operaio> OttieniOperai()
        {
            List<Operaio> operai = [];
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                string query = "SELECT * FROM operai";
                MySqlCommand command = new(query, connessione);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {   
                    Operaio operaio = new (reader.GetString("nome"), reader.GetString("cantiere"));
                    operai.Add(operaio);
                }
                Console.WriteLine("Lista operai caricata.");
                Console.WriteLine();

                reader.Close();
                connessione.Close();
                return operai;
            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
                return operai;
            }
        }

        public static List<Task> OttieniTasks()
        { 
            List<Task> tasks = [];
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                string query = "SELECT * FROM tasks";
                MySqlCommand command = new(query, connessione);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Task task = new(reader.GetString("descrizione"), reader.GetString("cantiere"));
                    tasks.Add(task);
                }
                Console.WriteLine("Lista tasks caricata.");
                Console.WriteLine();

                reader.Close();
                connessione.Close();
                return tasks;
            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
                return tasks;
            }
        }

        public static List<Materiale> OttieniMateriali()
        { 
            List<Materiale> materiali = [];
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                string query = "SELECT * FROM materiali";
                MySqlCommand command = new(query, connessione);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Materiale materiale = new(reader.GetString("nome"), reader.GetFloat("quantità"), reader.GetString("unità"), reader.GetString("cantiere"));
                    materiali.Add(materiale);
                }
                Console.WriteLine("Lista tasks caricata.");
                Console.WriteLine();

                reader.Close();
                connessione.Close();
                return materiali;
            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
                return materiali;
            }
        }
    }

    class ScrittoreDatabase
    {   
        // Pensando agli eventi: Il cantiere lo inseriamo come parametro
        // TODO: Fare il check ad uno ad uno inserendo valori sbagliati
        public static void AggiungiOperaio()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il nome del nuovo operaio: ");
                //Inserire un controllo per non avere il dato null?
                string? nome = Console.ReadLine();
                Console.WriteLine("Inserisci il nome del cantiere in cui inserirlo: "); //Così ogni operaio può avere al massimo un cantiere
                string? cantiere = Console.ReadLine();
                string query = $"INSERT INTO operai (nome, cantiere) VALUES ('{nome}', '{cantiere}')";

                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Aggiunta effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }

        public static void AggiungiTask()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il nuovo task: ");
                string? descrizione = Console.ReadLine();
                Console.WriteLine("Inserisci il nome del cantiere in cui inserirlo: "); //Così ogni operaio può avere al massimo un cantiere
                string? cantiere = Console.ReadLine();
                string query = $"INSERT INTO tasks (descrizione, cantiere) VALUES ('{descrizione}', '{cantiere}')";

                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Aggiunta effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }
        
        public static void AggiungiMateriale()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il nuovo materiale: ");
                string? nome = Console.ReadLine();
                float quantità;
                do 
                {
                    Console.WriteLine("Inserisci la quantità: ");
                }
                while (!float.TryParse(Console.ReadLine(), out quantità));
                Console.WriteLine("Inserisci l'unità di misura: ");
                string? unità = Console.ReadLine();
                Console.WriteLine("Inserisci il nome del cantiere in cui inserirlo: ");
                string? cantiere = Console.ReadLine();
                string query = $"INSERT INTO materiali (nome, quantità, unità, cantiere) VALUES ('{nome}', '{quantità}', '{unità}', '{cantiere}')";

                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Aggiunta effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }
    }

    class EliminatoreDatabase   
    {   
        // Pensando agli eventi: sia il dato che il cantiere li passiamo come parametri
        public static void EliminaOperaio()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il nome dell'operaio da eliminare: ");
                string? nome = Console.ReadLine();
                string query = $"DELETE FROM operai WHERE nome = '{nome}'";
                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Eliminazione effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }

        public static void EliminaMateriale()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il materiale da eliminare: ");
                string? nome = Console.ReadLine();
                Console.WriteLine("Inserisci il cantiere: ");
                string? cantiere = Console.ReadLine();
                string query = $"DELETE FROM materiali WHERE nome = '{nome}' AND cantiere = '{cantiere}'";
                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Eliminazione effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }

        public static void EliminaTask()
        { 
            string stringaConnessione = "Server=localhost;Database=SiteManager;User=root;Password=1234;";
            try
            {   
                MySqlConnection connessione = new(stringaConnessione);
                connessione.Open();
                Console.WriteLine("Connessione al database effettuata.");

                Console.WriteLine("Inserisci il task da eliminare: ");
                string? descrizione = Console.ReadLine();
                Console.WriteLine("Inserisci il cantiere: ");
                string? cantiere = Console.ReadLine();
                string query = $"DELETE FROM tasks WHERE descrizione = '{descrizione}' AND cantiere = '{cantiere}'";
                MySqlCommand command = new(query, connessione);
                command.ExecuteNonQuery();

                connessione.Close();
                Console.WriteLine("Eliminazione effettuata con successo.");

            }
            catch (Exception eccezione)
            {
                Console.WriteLine($"Errore: {eccezione.Message}");
            }
        }
    }

    class PopolatoreCantieri
    {
        public static List<Cantiere> PopolaCantieri(List<Cantiere> cantieri, List<Operaio> operai, List<Materiale> materiali, List<Task> tasks)
        {
            foreach(Operaio operaio in operai)
            {
                foreach(Cantiere cantiere in cantieri)
                {
                    if (operaio.Cantiere == cantiere.Nome)
                    {
                        cantiere.operai.Add(operaio);
                    }
                }
            }

            foreach(Materiale materiale in materiali)
            {
                foreach(Cantiere cantiere in cantieri)
                {
                    if (materiale.Cantiere == cantiere.Nome)
                    {
                        cantiere.materiali.Add(materiale);
                    }
                }
            }

            foreach(Task task in tasks)
            {
                foreach(Cantiere cantiere in cantieri)
                {
                    if (task.Cantiere == cantiere.Nome)
                    {
                        cantiere.tasks.Add(task);
                    }
                }
            }

            return cantieri;
        }
    }

    class Stampante
    {
        public static void StampaCantieri(List<Cantiere> cantieri)
        {
            foreach(Cantiere cantiere in cantieri)
            {   
                Console.WriteLine(cantiere);
                Console.WriteLine("Elenco Operai:");
                foreach(Operaio operaio in cantiere.operai)
                {
                    Console.WriteLine(" - " + operaio);
                }
                Console.WriteLine("Elenco Task:");
                foreach(Task task in cantiere.tasks)
                {
                    Console.WriteLine(" - " + task);
                }
                Console.WriteLine("Elenco Materiali:");
                foreach(Materiale materiale in cantiere.materiali)
                {
                    Console.WriteLine(" - " + materiale);
                }
                Console.WriteLine();
            }
        }

        public static void StampaOperai(List<Operaio> operai)
        {
            Console.WriteLine("Elenco Operai:");
            foreach(Operaio operaio in operai)
                {
                    Console.WriteLine(" - " + operaio + " (" + operaio.Cantiere + ")");
                }
        }

        public static void StampaTasks(List<Task> tasks)
        {
            Console.WriteLine("Elenco Tasks:");
            foreach(Task task in tasks)
                {
                    Console.WriteLine(" - " + task + " (" + task.Cantiere + ")");
                }
        }

        public static void StampaMateriali(List<Materiale> materiali)
        {
            Console.WriteLine("Elenco Materiali:");
            foreach(Materiale materiale in materiali)
                {
                    Console.WriteLine(" - " + materiale + " (" + materiale.Cantiere + ")");
                }
        }
    }

    //primary constructor
    class Cantiere(string nome, DateTime dataInizio)
    {
        public string Nome { get; set; } = nome;
        public DateTime DataInizio { get; set; } = dataInizio;

        public List<Operaio> operai = [];
        public List<Materiale> materiali = [];
        public List<Task> tasks = [];

        public override string ToString()
        {
            return $"Cantiere {Nome} (iniziato: {DataInizio:dd MMM yyyy})";  //$ chiama sempre ToString()
        }
    }

    class Operaio(string nome, string cantiere)
    {
        public string Nome { get; set; } = nome;
        public string Cantiere { get; set; } = cantiere;

        public override string ToString()
        {
            return $"{Nome}";
        }
    }

    class Task(string descrizione, string cantiere)
    {
        public string Descrizione { get; set; } = descrizione;
        public string Cantiere { get; set; } = cantiere;

        public override string ToString()
        {
            return $"{Descrizione}";
        }
    }

    class Materiale (string nome, float quantità, string unità, string cantiere)
    {
        public string Nome { get; set; } = nome;
        public float Quantità { get; set; } = quantità;
        public string Unità { get; set; } = unità;
        public string Cantiere { get; set; } = cantiere;

        public override string ToString()
        {
            return $"{Nome} {Quantità} {Unità}";
        }
    }
}