using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace aspnetCoreReactTemplate.Models 
{
    public class Humidor
    {
        public long HumidorId {get; set;}

        public string Label {get; set;}
        
        public ICollection<Hygrometer> Hygrometers {get; set;}
    }
}