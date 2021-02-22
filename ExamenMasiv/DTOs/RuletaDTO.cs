using System;
using System.ComponentModel.DataAnnotations;

namespace ExamenMasiv.DTOs
{
    public class RuletaDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Active { get; set; }
    }
}
