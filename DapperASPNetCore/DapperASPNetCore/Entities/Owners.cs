using System.ComponentModel.DataAnnotations;
using System.Net;

namespace DapperASPNetCore.Entities
{
    public class Owners
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
