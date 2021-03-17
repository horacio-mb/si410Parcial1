
namespace WebApplicationParcial1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Random
    {
        [Key]
        [DataType(DataType.DateTime)]

        public DateTime fecha { get; set; }
        [Required]
        public int random { get; set; }
    }
}
