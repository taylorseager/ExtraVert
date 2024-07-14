using System;
using System.Reflection.Emit;


    public class Plant
    {
        public string? Species { get; set; }
        public double? LightNeeds { get; set; }
        public decimal? AskingPrice { get; set; }
        public string? City { get; set; }
        public int? Zip { get; set; }
        public bool Sold { get; set; }
        public DateTime AvailableUntil { get; set; }

        public Plant(string species, double lightNeeds, decimal askingPrice, string city, int zip, bool sold, DateTime availableUntil)
        {
            Species = species;
            LightNeeds = lightNeeds;
            AskingPrice = askingPrice;
            City = city;
            Zip = zip;
            Sold = sold;
            AvailableUntil = availableUntil;
        }
    }
