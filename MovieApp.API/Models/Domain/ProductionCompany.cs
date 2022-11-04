﻿namespace MovieApp.API.Models.Domain
{
    public class ProductionCompany
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LogoPath { get; set; }

        public string? OriginCountry { get; set; }
    }
}
