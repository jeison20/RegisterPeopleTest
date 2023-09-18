using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Dto
{
    public class AdressInfoDto
    {
        public int Id { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
