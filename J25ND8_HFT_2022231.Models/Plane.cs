using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Models
{
    [Table("planes")]
    public class Plane : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("plane_id", TypeName = "int") ]
        public override int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string StartingCountry { get; set; }
        public string Destination { get; set; }
        [NotMapped]
        public ICollection<Passenger> Passengers { get; set; }
        public Airline Airline { get; set; }
        [ForeignKey(nameof(Airline))]
        public int AirlineId { get; set; }
    }
}
