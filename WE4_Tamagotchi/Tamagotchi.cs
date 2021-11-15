using System;
using System.Timers;

namespace WE4_Tamagotchi
{
    public enum Levensstadium
    {
        Ei,
        Baby,
        Kind,
        Puber,
        Volwassen,
        Senior,
        Dood
    }

    public class Tamagotchi
    {
        // Deel 3: events
        private readonly Timer timer;
        private Levensstadium vorigLevensstatium;

        // Deel 1
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }

        // Deel2: Levensstadium  met switch

        public Levensstadium Levensstadium
        {
            get
            {
                if (Honger == 0 && Geluk == 0 && Intelligentie == 0) return Levensstadium.Dood;

                TimeSpan leeftijd = DateTime.Now - Geboortedatum;

                return leeftijd.TotalMinutes switch
                {
                    double minutes when (minutes <= 1) => Levensstadium.Ei,
                    double minutes when (minutes <= 10) => Levensstadium.Baby,
                    double minutes when (minutes <= 60) => Levensstadium.Kind,
                    double minutes when (minutes <= 120) => Levensstadium.Puber,
                    double minutes when (minutes <= 300) => Levensstadium.Volwassen,
                    double minutes when (minutes <= 400) => Levensstadium.Senior,
                    _ => Levensstadium.Dood,
                };
            }
        }


        private int honger;
        public int Honger
        {
            get { return honger; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    honger = value;
                }
            }
        }

        private int geluk;
        public int Geluk
        {
            get { return geluk; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    geluk = value;
                }
            }
        }

        private int intelligentie;
        public int Intelligentie
        {
            get { return intelligentie; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    intelligentie = value;
                }
            }
        }
        // Deel 2
        public Tamagotchi(string naam = "Beestje")
        {
            Naam = naam;
            Geboortedatum = DateTime.Now;
            Honger = 4;
            Geluk = 4;
            Intelligentie = 4;

        }

    }
}
