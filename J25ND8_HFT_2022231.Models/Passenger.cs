using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
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
        public string Name { get; set; }
        [Required]
        public int TicketRow { get; set; }
        [Required]
        public int TickerColumn { get; set; }
        [ForeignKey(nameof(Plane))]
        public Plane Plane { get; set; }
    }
}
