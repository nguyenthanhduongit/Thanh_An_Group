using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ThanhAn_Group.DAL.Models
{
    public partial class DoiTac
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NameDoiTac { get; set; }
        [Required]
        public string AdressDoiTac { get; set; }
        
        public bool Status { get; set; }
        
        public string Mst { get; set; }
        [Required]
        public string Tel { get; set; }
    }
}
