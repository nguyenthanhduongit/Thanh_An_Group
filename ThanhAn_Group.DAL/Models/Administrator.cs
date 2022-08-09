using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ThanhAn_Group.DAL.Models
{
    public partial class Administrator
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
       
        public string Token { get; set; }
    }
}
