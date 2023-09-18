using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Dto
{
    public class InfoPeopleDto
    {
        public int Id { get; set; }        
        public string? IdentityDocument { get; set; }        
        public string? FirstName { get; set; }      
        public string? LastName { get; set; }       
        public DateTime BirthDate { get; set; }

        public List<PhoneInfoDto> PhoneInfos { get; set; }
        public List<AdressInfoDto> AdressInfos { get; set; }
        public List<AddressEmailInfoDto> addressEmailInfos  { get; set; }
    }
}
