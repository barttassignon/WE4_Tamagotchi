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

        // delegates
        public delegate void LevensstadiumChanged(Levensstadium levensstadium);
        public event LevensstadiumChanged LevensstadiumChangedEvent;

        public delegate void ParameterChanged();
        public event ParameterChanged ParameterChangedEvent;

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
            timer = new Timer(1000) { AutoReset = true, Enabled = true };
            timer.Elapsed += IsLevensstadiumVeranderd;
            timer.Elapsed += VeranderParameters;
            timer.Start();
        }

        private void IsLevensstadiumVeranderd(object sender, ElapsedEventArgs e)
        {
            vorigLevensstatium = Levensstadium;
            if (vorigLevensstatium == Levensstadium.Dood)
            {
                timer.Stop();
            }

            if (LevensstadiumChangedEvent != null)
            {
                LevensstadiumChangedEvent(Levensstadium);
            }
        }

        private void VeranderParameters(object sender, ElapsedEventArgs e)
        {
            int random = new Random().Next(0, 10);
            if (random < 3)
            {
                Honger--;
            }
            if (random == 1)
            {
                Geluk--;
            }
            if (random == 3)
            {
                Intelligentie--;
            }
            if (ParameterChangedEvent != null)
            {
                ParameterChangedEvent();
            }
        }
    }
}
