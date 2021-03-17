using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationParcial1.Models
{
    public class Data
    {
        [Key]
        [DataType(DataType.DateTime)]

        public DateTime fecha { get; set; }
        [Required]
        public int random { get; set; }
    }
}
