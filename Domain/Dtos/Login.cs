using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class Login
    {

        [Required]
        [DataType(DataType.Text)]
        public string? Token { get; set; }

        [Required]
        public Account? account { get; set; }

    }
}
