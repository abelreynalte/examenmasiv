using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("resultbet")]
    public class ResultBet
    {
        [Column("userid")]
        public int UserId { get; set; }
        [Column("ruletadetailid")]
        public int RuletadetailId { get; set; }
        [Column("awardamount")]
        public decimal AwardAmount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
