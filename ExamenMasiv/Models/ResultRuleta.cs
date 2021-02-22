using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("resultruleta")]
    public class ResultRuleta
    {
        [Column("ruletadetailid")]
        public int RuletaDetailId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
