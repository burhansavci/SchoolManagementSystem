using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Models.Entities
{
    public class Period
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [MaxLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime StartDateOfTerm { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDateOfTerm { get; set; }

    }
}
