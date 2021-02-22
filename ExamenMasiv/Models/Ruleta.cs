using ExamenMasiv.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("ruleta")]
    public class Ruleta: IEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("colour")]
        public string Colour { get; set; }
    }
}
