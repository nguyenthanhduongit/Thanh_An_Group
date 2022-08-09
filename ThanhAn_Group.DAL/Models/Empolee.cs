using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanhAn_Group.DAL.Models
{
  public  class Empolee
    {
        public int SlideId { get; set; }
        [Required]
        public string SlideName { get; set; }
        [Required]
        public IFormFile ImagesUploand { get; set; }
        [Required]
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
    }
}
