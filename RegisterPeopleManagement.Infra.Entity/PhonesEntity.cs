using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterPeopleManagement.Infra.Entities
{
    [Table("Phones")]
    public class PhonesEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        public int PeopleId { get; set; }

        [Required]
        [StringLength(20)]
        public string? Number { get; set; }

        
        [ForeignKey("PeopleId")]
        public virtual PeopleEntity People { get; set; }
    }
}
