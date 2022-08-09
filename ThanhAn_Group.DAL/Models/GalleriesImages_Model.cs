using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhAn_Group.DAL.Models
{
   public class GalleriesImages_Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public int? ParentId { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
