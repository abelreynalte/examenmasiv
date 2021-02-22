using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("userbet")]
    public class Userbet
    {
        [Column("userid")]
        public int UserId { get; set; }
        [Column("ruletadetailid")]
        public int RuletaDetailId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
