﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyTravel.Models
{
    public class Meteo
    {
        [Key]
        public int ID { get; set; }
        public string Stato { get; set; }
        public string Citta { get; set; }
        public List<Temperature> Temperature { get; set; }
        public List<Precipitazioni> Precipitazioni { get; set; }
        public List<OreSole> OreSole { get; set; }
        public List<Mare> Mare { get; set; }
    }

    public class Temperature
    {
        [Key]
        public int ID { get; set; }
        public string Mese { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal Media { get; set; }
    }

    public class Precipitazioni
    {
        [Key]
        public int ID { get; set; }
        public string Mese { get; set; }
        public int Quantità { get; set; }
        public int Giorni { get; set; }
    }

    public class OreSole
    {
        [Key]
        public int ID { get; set; }
        public string Mese { get; set; }
        public decimal MediaGiornaliera { get; set; }
        public int TotaleMese { get; set; }
    }

    public class Mare
    {
        [Key]
        public int ID { get; set; }
        public string Mese { get; set; }
        public decimal Temperatura { get; set; }
    }
}