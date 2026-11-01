using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EsCanile
{
    public enum RazzaCane
    {
        GoldenRetriver,
        Corgi,
        Rottweiler,
        PastoreTedesco,
        BovaroBernese
    }

    public enum StatoCane
    {
        InAttesa,
        InCura,
        DisponibileAdozione
    }
    public class CCane
    {
        private string nome = "";
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Inserire un nome valido per il cane");
                nome = value;
            }
        }

        private int annoNascita;
        public int AnnoNascita
        {
            get
            {
                return annoNascita;
            }

            set
            {
                if (value <= 0 || value > DateTime.Now.Year)
                    throw new ArgumentException("L'anno di nascita del cane può essere al massimo pari all'anno attuale, non un anno futuro");
                annoNascita = value;
            }
        }

        private RazzaCane razza;

        public RazzaCane Razza
        {
            get
            {
                return razza;
            }
            set
            {
                if (value != RazzaCane.GoldenRetriver && value != RazzaCane.Corgi && value != RazzaCane.Rottweiler && value != RazzaCane.PastoreTedesco && value != RazzaCane.BovaroBernese)
                    throw new ArgumentException("La razza del cane non può esseere diversa rispetto a una di quelle già scelte");
                razza = value;

            }
        }

        private DateTime dataIngresso;

        public DateTime DataIngresso
        {
            get
            {
                return dataIngresso;
            }
            set
            {
                if (value.Date > DateTime.Now.Date)
                    throw new ArgumentException("La data inserita non è ancora passata, selezionane una valida");
                dataIngresso = value;
            }
        }

        private StatoCane statoCane;
        public StatoCane Stato
        {
            get
            {
                return statoCane;
            }
            set
            {
                if (value != StatoCane.InAttesa && value != StatoCane.InCura && value != StatoCane.DisponibileAdozione)
                    throw new ArgumentException("Lo stato del cane deve essere scelto tra uno dei tre proposti");
                statoCane = value;
            }
        }


        public string? Note { get; set; }


        public CCane() { }

        public CCane(string Nome, int AnnoNascita, RazzaCane Razza, DateTime DataIngresso, StatoCane Stato, string? Note)
        {
            this.Nome = Nome;
            this.AnnoNascita = AnnoNascita;
            this.Razza = Razza;
            this.DataIngresso = DataIngresso;
            this.Stato = Stato;
            this.Note = Note;
        }

        public string Descrizione()
        {
            string razzaString = "";
            if (Razza == RazzaCane.GoldenRetriver)
            {
                razzaString = "Golden Retriver";
            }
            else if (Razza == RazzaCane.PastoreTedesco)
            {
                razzaString = "Pastore tedesco";
            }
            else if (Razza == RazzaCane.BovaroBernese)
            {
                razzaString = "Bovaro del Bernese";
            }
            else
            {
                razzaString = Razza.ToString();
            }

            string statoCaneString = "";
            if (Stato == StatoCane.InAttesa)
            {
                statoCaneString = "in attesa di adozione";
            }
            else if (Stato == StatoCane.InCura)
            {
                statoCaneString = "in cura";
            }
            else
            {
                statoCaneString = "disponibile per l'adozione";
            }
            string noteString = "";
            if (Note == null)
            {
                noteString = "Nessuna nota aggiuntiva presente";
            }
            else
            {
                noteString = Note;
            }

            return $"Nome del cane: {Nome}, nato nel {AnnoNascita}, di razza: {razzaString}.\nData di ingresso nel canile: {DataIngresso}, stato del cane: {statoCaneString}.\nEventuali note: {noteString}\n"; 
        }


        public override string ToString()
        {
            return Descrizione();
        }
    }
}
