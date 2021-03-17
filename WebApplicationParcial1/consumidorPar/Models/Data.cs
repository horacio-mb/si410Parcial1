
namespace consumidorPar.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        [DataType(DataType.DateTime)]

        public DateTime fecha { get; set; }
        [Required]
        public int random { get; set; }
    }
}

