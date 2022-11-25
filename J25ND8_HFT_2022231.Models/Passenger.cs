using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Models
{
    [Table("passengers")]
    public class Passenger : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("passenger_id", TypeName = "'int")]
        public override int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int TicketRow { get; set; }
        public int TicketColumn { get; set; }
        public int TicketPrice { get; set; }
        [Required]
        public bool FirstClass { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Plane Plane { get; set; }
        [ForeignKey(nameof(Plane))]
        public int PlaneId { get; set; }
    }
}
