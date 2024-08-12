using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B05ASPC03_DataAnnotation.Models
{
    public class BlogCategory:BaseDTO
    {
       
        public string Name { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase PostedFile { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}