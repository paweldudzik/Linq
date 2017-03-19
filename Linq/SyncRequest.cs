using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class SyncRequest
    {
        public enum SyncType {
            Workers,
            Duties
        }

        public enum Status
        {
            Success,
            Failed,
            Unknown
        }

        public string Id { get; set; }
        public string CustomerId { get; set; }
        public SyncType type { get; }
        public int lastDate;
        public Status status { get; }

        public SyncRequest(string id, string customerId, SyncType type, int date, Status status)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.type = type;
            this.lastDate = date;
            this.status = status;
        }
    }
}
