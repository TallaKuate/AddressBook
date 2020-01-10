using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.API.Gateways.Config
{
    public class UrlsConfig
    {
        public class AddressOperations
        {
            public static string GetAddressById(int id) => $"/api/Address/{id}";
                  
        }

        public class AddressBookOperations
        {
            public static string GetAddressBook() => $"/api/AddressBook";

        }

        public class UserOperations
        {
            public static string GetDomainUserById(int id) => $"/api/DomainUser/{id}";
        }

      
    }
}
