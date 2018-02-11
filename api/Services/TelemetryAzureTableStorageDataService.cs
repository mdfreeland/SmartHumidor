using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using aspnetCoreReactTemplate.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace aspnetCoreReactTemplate.Services
{
    public class TelemetryAzureTableStorageDataService : ITelemetryDataService
    {
        private readonly CloudStorageAccount _storageAccount;

        public TelemetryAzureTableStorageDataService(IConfiguration configuration)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(configuration.GetSection("connectionStrings")["telemetry"]);
        }

        public async Task<IList<TelemetryEvent>> GetTelemetryEvents(string deviceId, int days)
        {
            CloudTableClient cloudTableClient = _storageAccount.CreateCloudTableClient();
            CloudTable telemetryTable = cloudTableClient.GetTableReference("deviceData");

            TableQuery<TelemetryEvent> query = new TableQuery<TelemetryEvent>().Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, deviceId),
                    TableOperators.And,
                    TableQuery.GenerateFilterConditionForDate("Timestamp", QueryComparisons.GreaterThanOrEqual, DateTime.Today.AddDays(-1 * days))));
            
            return await telemetryTable.ExecuteQueryAsync(query);
        }
    }
}
