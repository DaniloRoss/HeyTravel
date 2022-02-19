using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class UserToken
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }

    }
}
