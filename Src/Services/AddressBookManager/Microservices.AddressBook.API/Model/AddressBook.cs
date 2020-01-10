

using System.Collections.Generic;

namespace Microservices.AddressBook.API.Model
{
    public class AddressBook
    {
        public int Id { get; set; } 
        public int UserId { get; set; } 
        public int AddressId { get; set; } 
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }


    public class CountryAddressBook
    {
        public string City { get; set; }
        public List<AddressBook> userAddresses { get; set; } = new List<AddressBook>();

    }
}
