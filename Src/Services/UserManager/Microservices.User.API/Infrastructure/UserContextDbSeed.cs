using System;
using System.Collections.Generic;
using System.Linq;
using Microservices.User.API.Model;
using Newtonsoft.Json;

namespace Microservices.User.API.Infrastructure
{
    public static class UserContextDbSeed
    {
        public static void Seed(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var result = GetData();
            context.Users.AddRange(result);

            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }

        public static List<DomainUser> GetData()
        {
            var result = new List <DomainUser>();
            var userData = JsonConvert.DeserializeObject<List<DomainUser>>(seedData);

            userData.Select(x => (x.Firstname, x.Lastname))
                .Distinct()
                .ToList()
                .ForEach(user =>
                {
                    result.Add(
                        new DomainUser
                        {
                            Firstname = user.Firstname,
                            Lastname = user.Lastname
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
