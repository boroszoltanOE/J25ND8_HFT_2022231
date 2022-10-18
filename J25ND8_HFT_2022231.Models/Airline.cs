using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Models
{
    public class Airline : Entity
    {
        [Required]
        public string Name { get; set; }
        [Range(0, 10)]
        public double SafetyPoint { get; set; }
        public DateTime CreatingTime { get; set; }
        public string BaseCountry { get; set; }
        [NotMapped]
        public virtual ICollection<Plane> Planes { get; set; }
    }
}
