using System;

namespace aspnetCoreReactTemplate.Models
{
    public class TelemetryEvent
    {
        public string DeviceId {get; set;}

        public decimal Humidity {get; set;}
        
        public decimal Temperature {get; set;}

        public DateTime EventRecorded {get; set;}
    }
}