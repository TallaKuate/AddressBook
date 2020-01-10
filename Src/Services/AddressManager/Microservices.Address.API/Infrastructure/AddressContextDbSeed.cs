using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.Address.API.Infrastructure
{
    public static class AddressContextDbSeed
    {
        public static void Seed(AddressContext context)
        {
            context.Database.EnsureCreated();

            if (context.Addresses.Any())
            {
                return;   // DB has been seeded
            }

            context.Addresses.AddRange (GetData());
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public static List<Model.Address> GetData()
        {
            var result = new List<Model.Address>();
            var userData = JsonConvert.DeserializeObject<List<Model.Address>>(seedData);
            userData.Select(x => (x.StreetAddress, x.City, x.Country))
               .Distinct()
               .ToList()
               .ForEach(address =>
               {
                   result.Add(
                        new Model.Address
                        {
                            Country = address.Country,
                            City = address.City,
                            StreetAddress = address.StreetAddress
                        }
                        );
               });

            return result;
        }



        static string seedData = @"[   
                                    {   ""firstname"": ""John"",    ""lastname"": ""Smith"",    ""streetaddress"": ""Test St 1"",    ""city"": ""London"",    ""country"": ""England""   },  
                                    {   ""firstname"": ""Jane"",    ""lastname"": ""Doe"",    ""streetaddress"": ""Test St 2"",    ""city"": ""london"",    ""country"": ""England""   }, 
                                    {   ""firstname"": ""Tim"",    ""lastname"": ""Jones"",    ""streetaddress"": ""Test St 3"",    ""city"": ""New York"",    ""country"": ""USA""   },   
                                    {   ""firstname"": ""David"",    ""lastname"": ""Jones"",    ""streetaddress"": ""Test St 4"",    ""city"": ""New york"",    ""country"": ""USA""   },    
                                    {   ""firstname"": ""Any"",    ""lastname"": ""Body"",    ""streetaddress"": ""Test St 4"",    ""city"": ""London"",    ""country"": ""England""   },   
                                    {   ""firstname"": ""Any"",    ""lastname"": ""Body"",    ""streetaddress"": ""1765 Long Street"",    ""city"": ""boston"",    ""country"": ""USA""   }     
                                    ]";
    }
}

