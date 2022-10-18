using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Models
{
    public class Plane : Entity
    {
        [Required]
        public string Type { get; set; }
        public string StartingCountry { get; set; }
        public string Destination { get; set; }
        [ForeignKey(nameof(Airline))]
        public Airline Airline { get; set; }
        [NotMapped]
        public ICollection<Passenger> Passengers { get; set; }
    }
}
