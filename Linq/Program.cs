using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Program();
            test.Run();
        }

        public void Run()
        {
            var customers = new List<Customer>() {
                new Customer("_customer1_", "Jastrzebie", "http://jastrzebie.pl"),
                new Customer("_customer2_", "Wodzislaw", "http://jastrzebie.pl"),
                new Customer("_customer3_", "Rybnik", "http://jastrzebie.pl"),
                new Customer("_customer4_", "Katowice", "http://jastrzebie.pl")};

            var syncs = new List<SyncRequest>() { new SyncRequest("sync1", "_customer1_", SyncRequest.SyncType.Duties, 1, SyncRequest.Status.Success),
                new SyncRequest("sync2", "_customer1_", SyncRequest.SyncType.Duties, 2, SyncRequest.Status.Success),
                new SyncRequest("sync3", "_customer1_", SyncRequest.SyncType.Duties, 3, SyncRequest.Status.Unknown),
                new SyncRequest("sync4", "_customer1_", SyncRequest.SyncType.Workers, 4, SyncRequest.Status.Failed),

                new SyncRequest("sync5", "_customer2_", SyncRequest.SyncType.Duties, 5, SyncRequest.Status.Failed),
                new SyncRequest("sync6", "_customer2_", SyncRequest.SyncType.Workers, 6, SyncRequest.Status.Success),

                new SyncRequest("sync7", "_customer3_", SyncRequest.SyncType.Duties, 7, SyncRequest.Status.Failed),
                new SyncRequest("sync8", "_customer3_", SyncRequest.SyncType.Duties, 8, SyncRequest.Status.Success),
                new SyncRequest("sync9", "_customer3_", SyncRequest.SyncType.Duties, 9, SyncRequest.Status.Success),
                new SyncRequest("sync10", "_customer3_", SyncRequest.SyncType.Duties, 10, SyncRequest.Status.Success),
                new SyncRequest("sync11", "_customer3_", SyncRequest.SyncType.Duties, 11, SyncRequest.Status.Unknown)};

            var customerIds = customers.Select(customer => customer.Id);

            var top1OfGroup = syncs.Where(sync => customerIds.Contains(sync.CustomerId))
                .OrderByDescending(sync => sync.lastDate)
                .GroupBy(group => group.CustomerId)
                .Select(group => group.First()).ToList();

            var customersLastSync = syncs.Where(sync => customerIds.Contains(sync.CustomerId) && (sync.status == SyncRequest.Status.Success || sync.status == SyncRequest.Status.Failed))
                .GroupBy(group => group.CustomerId)
                .Select(group => new
                {
                    customer = group.Key,
                    syncs = group
                           .OrderByDescending(sync => sync.lastDate)
                           .GroupBy(group2 => group2.type)
                           .Select(x => x.First()).ToDictionary(x => x.type, x => x)
                }
                ).ToDictionary(x => x.customer, x => x.syncs);

            var results = customers.Select(customer => new CustomerHealth(
                customer.Id,
                customer.Name,
                customer.HealthRosterUrl,
                customersLastSync.ContainsKey(customer.Id) ? customersLastSync[customer.Id].ContainsKey(SyncRequest.SyncType.Workers) ? customersLastSync[customer.Id][SyncRequest.SyncType.Workers] : null : null,
                customersLastSync.ContainsKey(customer.Id) ? customersLastSync[customer.Id].ContainsKey(SyncRequest.SyncType.Duties) ? customersLastSync[customer.Id][SyncRequest.SyncType.Duties] : null : null)).ToList();

            var result = 1;
            result += 1;
        }
    }
}
