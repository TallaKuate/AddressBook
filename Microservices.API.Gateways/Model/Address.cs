﻿namespace Microservices.API.Gateways.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string UPRN { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
