using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ThanhAn_Group.DAL.Models
{
    public partial class GalleriesVideo
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        
        public bool Status { get; set; }
    }
}
