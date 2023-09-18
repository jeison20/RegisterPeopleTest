using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterPeopleManagement.Infra.Entities
{
    [Table("EmailAddress")]
    public class EmailAddressEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        public int PeopleId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        // Clave foránea
        [ForeignKey("PeopleId")]
        public virtual PeopleEntity People { get; set; }
    }
}
