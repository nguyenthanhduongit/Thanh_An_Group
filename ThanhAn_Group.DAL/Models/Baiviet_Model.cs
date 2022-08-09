using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhAn_Group.DAL.Models
{
   public class Baiviet_Model
    {
        public int PkbaivietId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ShortContent { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public IFormFile Images { get; set; }
        [Required]
        public short Types { get; set; }
        [Required]
        public DateTime? CreateDate { get; set; }
        public bool Status { get; set; }
    }
}
