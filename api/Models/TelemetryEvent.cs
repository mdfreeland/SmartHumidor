using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace aspnetCoreReactTemplate.Models
{
    public class TelemetryEvent : TableEntity
    {
        public string DeviceId {get; set;}

        public decimal Humidity {get; set;}
        
        public decimal Temperature {get; set;}

        public DateTime EventRecorded {get; set;}
    }
}