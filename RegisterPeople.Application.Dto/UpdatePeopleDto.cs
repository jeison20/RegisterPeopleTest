using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Dto
{
    public class UpdatePeopleDto
    {
        public int Id { get; set; }
        public string? IdentityDocument { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public List<PhoneInfoDto>? Phones { get; set; }
        public List<AddressEmailInfoDto>? EmailAddresses { get; set; }
        public List<AdressInfoDto>? Addresses { get; set; }
    }
}
