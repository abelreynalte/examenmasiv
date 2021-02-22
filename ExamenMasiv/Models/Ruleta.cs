using ExamenMasiv.Repositories;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("ruleta")]
    public class Ruleta: IEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        public RuletaDetail detail { get; set; }
    }
}
