using System;
using System.Collections.Generic;

#nullable disable

namespace ThanhAn_Group.DAL.Models
{
    public partial class Slide
    {
        public int SlideId { get; set; }
        public string SlideName { get; set; }
        public string Images { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
    }
}
