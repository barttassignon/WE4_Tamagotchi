using System;
using System.Timers;

namespace WE4_Tamagotchi
{
    enum Levensstadium
    {
        Ei,
        Baby,
        Kind,
        Puber,
        Volwassen,
        Senior,
        Dood
    }

    class Tamagotchi
    {
        // Deel 3: events
        private readonly Timer timer;
        private Levensstadium vorigLevensstatium;

        // Deel 1
        public string Naam { get; set; }
        public DateTime Geboortedatum { get; set; }

        public Levensstadium levensstadium;

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
