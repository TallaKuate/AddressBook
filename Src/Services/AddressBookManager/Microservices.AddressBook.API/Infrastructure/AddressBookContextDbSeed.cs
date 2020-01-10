using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.AddressBook.API.Infrastructure
{
    public static class AddressBookContextDbSeed
    {
        public static void Seed(AddressBookContext context)
        {
            context.Database.EnsureCreated();

            if (context.UserAddresses.Any())
            {
                return;   // DB has been seeded
            }

            var userData = GetData();
            context.UserAddresses.AddRange(userData);
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public static List<Model.AddressBook> GetData()
        {
            return JsonConvert.DeserializeObject<List<Model.AddressBook>>(seedData);
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
