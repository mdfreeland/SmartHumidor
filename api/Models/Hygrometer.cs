using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnetCoreReactTemplate.Models 
{
    public class Hygrometer
    {
        public long HygrometerId { get; set; }
        
        public string DeviceId { get; set; }

        public string Label {get; set;}

        [NotMapped]
        public IList<TelemetryEvent> TelemetryEvents {get; set;}
    }
}