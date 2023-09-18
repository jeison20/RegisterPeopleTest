using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterPeopleManagement.Infra.Entities
{
    [Table("Address")]
    public class AddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public int PeopleId { get; set; }

        [Required]
        [StringLength(255)]
        public string? PhysicalAddress { get; set; }

        // Clave foránea
        [ForeignKey("PeopleId")]
        public virtual PeopleEntity People { get; set; }

    }
}
