using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace EsCanile
{
    public class CCanile
    {
        public List<CCane> Canile = new List<CCane>();
        public const string NomeFile = "canile.json";
        

        public void AggiungiCane(CCane cane)
        {
            Canile.Add(cane);
            
            Salva();
        }

        public bool AdottaCane(CCane cane)
        {
            bool rimosso = Canile.Remove(cane);

            if(rimosso == true)
            {
                Salva();
            }
            return rimosso;
            
        }

        public void Salva()
        {
            string json = JsonSerializer.Serialize(Canile);
            File.WriteAllText(NomeFile, json);
        }

        public void Carica()
        {
            if (!File.Exists(NomeFile))
            {
                return;
            }

            string json = File.ReadAllText(NomeFile);
            List<CCane>? cani = JsonSerializer.Deserialize<List<CCane>>(json);

            if (cani != null)
            {
                Canile = cani;
            }
        }
    }
}
