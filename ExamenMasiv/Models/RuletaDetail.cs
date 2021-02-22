using ExamenMasiv.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("ruletadetail")]
    public class RuletaDetail: IEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("ruletaid")]
        public int RuletaId { get; set; }
        [Column("number")]
        public int Number { get; set; }
        [Column("colourid")]
        public short ColourId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
    }
}
