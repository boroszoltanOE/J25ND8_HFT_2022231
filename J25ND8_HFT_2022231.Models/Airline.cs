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
    [Table("airlines")]
    public class Airline : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("airline_id", TypeName = "int")]
        public override int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, 10)]
        public double SafetyPoint { get; set; }
        public DateTime CreatingTime { get; set; }
        public string BaseCountry { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Plane> Planes { get; set; }
    }
}
