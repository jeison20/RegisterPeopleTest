﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterPeople.Application.Dto
{
    public class AddressEmailInfoDto
    {
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
