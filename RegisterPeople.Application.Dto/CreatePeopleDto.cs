using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Dto
{
    public class CreatePeopleDto
    {
        [Required]
        public string? IdentityDocument { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public List<PhoneInfoDto>? Phones { get; set; }
        public List<AddressEmailInfoDto>? EmailAddresses { get; set; }
        public List<AdressInfoDto>? Addresses { get; set; }
    }
}
