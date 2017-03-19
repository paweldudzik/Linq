using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HealthRosterUrl { get; set; }

        public Customer(string id, string name, string url)
        {
            this.Id = id;
            this.Name = name;
            this.HealthRosterUrl = url;
        }
    }
}
