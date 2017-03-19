using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class CustomerHealth
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HealthRosterUrl { get; set; }
        public SyncRequest workersSync { get; set; }
        public SyncRequest dutiesSync { get; set; }

        public CustomerHealth(string id, string name, string url, SyncRequest work, SyncRequest duty)
        {
            this.Id = id;
            this.Name = name;
            this.HealthRosterUrl = url;
            this.workersSync = work;
            this.dutiesSync = duty;
        }
    }
}
