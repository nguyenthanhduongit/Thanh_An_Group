using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ThanhAn_Group.DAL.Models
{
    public partial class Baiviet
    {
        public int PkbaivietId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortContent { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public string Images { get; set; }
        [Required]
        public short Types { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
