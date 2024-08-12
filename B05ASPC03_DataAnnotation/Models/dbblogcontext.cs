using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace B05ASPC03_DataAnnotation.Models
{
    public class dbblogcontext:DbContext
    {
        
        public DbSet<Blog>Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
    }
}