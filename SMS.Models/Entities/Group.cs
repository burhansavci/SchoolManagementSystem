using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SMS.Models.Entities
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        [Required, MaxLength(6)]
        public string Name { get; set; }

        [Required]
        public int Level { get; set; }
    }
}
