using B05ASPC03_DataAnnotation.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B05ASPC03_DataAnnotation.Controllers
{
    public class BlogCategoryController : Controller
    {
        dbblogcontext db=new dbblogcontext();
       
        // GET: BlogCategory
        public List<BlogCategory> CategoryList()
        {
            return db.BlogCategories.OrderBy(c=>c.Name).ToList();
        }
        public ActionResult Index()
        {
            return View(CategoryList());
        }
        public ActionResult Create()
        {
            return View( );
        }
        [HttpPost]
        public ActionResult Create(BlogCategory entity)
        {
            if (entity.PostedFile != null)
            { 
                string ext= Path.GetExtension(entity.PostedFile.FileName).ToLower();  
                if(ext ==".jpg"|| ext==".png" || ext == ".jpeg")
                {
                    string savePath =Path.Combine( Server.MapPath("~/Images"), entity.Name + ext);
                    entity.PostedFile.SaveAs(savePath);
                    entity.ImagePath = "~/Images/" + entity.Name+ext;
                    db.BlogCategories.Add(entity);
                    if (db.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please provide jpg|png|jpeg");
                    return View(entity);
                }
            }

            return View(entity);
        }
    }
}