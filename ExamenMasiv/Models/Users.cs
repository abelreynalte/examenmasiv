using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenMasiv.Models
{
    [Table("users")]
    public class Users
    {
        [Column("userid")]
        public int UserId { get; set; }
        [Column("username")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("fullname")]
        public string FullName { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
