using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Program
{
    class Boek
    {
        public string Titel { get; set; }
        public string Auteur { get; set; }
        public async Task<float> AIScore() {
            
            // Deze 'berekening' is eigenlijk een ingewikkeld AI algoritme.
            // Pas de volgende vier regels niet aan.
            double ret = 1.0f;
            for (int i = 0; i < 10_000_000; i++)
                for (int j = 0; j < 10; j++)
                    ret = (ret + Willekeurig.Random.NextDouble()) % 1.0;
            return (float)ret;
            
        }
    }

    static class Database
    {
        private static List<Boek> lijst = new List<Boek>();
        public static async Task VoegToe(Boek b)
        {
            await Willekeurig.Pauzeer(1000); // INSERT INTO ...
            lijst.Add(b);
        }
        public static async Task<List<Boek>> HaalLijstOp()
        {
            await Willekeurig.Pauzeer(1200); // SELECT * FROM ...
            return lijst;
        }
        public static async Task Logboek(string melding)
        {
            await Willekeurig.Pauzeer(2000); // schrijf naar logbestand
        }
    }

    public class Program
    {
        static bool Backupping = false;

        static async Task VoegBoekToe() {
            Console.WriteLine("Geef de titel op: ");
            var titel = Console.ReadLine();
            Console.WriteLine("Geef de auteur op: ");
            var auteur = Console.ReadLine();
            Database.VoegToe(new Boek {Titel = titel, Auteur = auteur});
            Database.Logboek("Er is een nieuw boek!");
            Console.WriteLine("De huidige lijst met boeken is: ");
            foreach (var boek in Database.HaalLijstOp().Result) {
                Console.WriteLine(boek.Titel);
            }
        }
        static async Task ZoekBoek() {
            Console.WriteLine("Waar gaat het boek over?");
            var beschrijving = Console.ReadLine();
            Boek beste = null;
            foreach (var boek in Database.HaalLijstOp().Result)
            {
                var boekScore = await boek.AIScore();
                if (boekScore > beste?.AIScore().Result)
                    beste = boek;
                Console.WriteLine("Het boek dat het beste overeenkomt met de beschrijving is: ");
                Console.WriteLine(beste.Titel);
            }
        }
        // "Backup" kan lang duren. We willen dat de gebruiker niet hoeft te wachten,
        // en direct daarna boeken kan toevoegen en zoeken.
        static async Task Backup() {
            if (Backupping)
                return;
            Backupping = true;
            await Willekeurig.Pauzeer(3500);
            Console.WriteLine("Backup is klaar");
            Backupping = false;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Welkom bij de boeken administratie!");
            string key = null;
            while (key != "q") {
                Console.WriteLine("\n\nWat wil je doen?");
                Console.WriteLine("+) Boek toevoegen");
                Console.WriteLine("z) Boek zoeken");
                Console.WriteLine("b) Backup maken van de boeken");
                Console.WriteLine("q) Quit");

                key = Console.ReadLine();
                if (key == "+")
                    VoegBoekToe();
                else if (key == "z")
                    ZoekBoek();
                else if (key == "b")
                    Backup();
                else Console.WriteLine("Ongeldige invoer!");
            }
        }
    }
}