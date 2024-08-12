using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace B05ASPC03_DataAnnotation.Models
{
    public class Blog:BaseDTO
    {
        //Scalar
        [Display(Name ="Blog Name")]
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase PostedFile { get; set; }
        //Navigation Property
        public BlogCategory Category { get; set; }
    }
}