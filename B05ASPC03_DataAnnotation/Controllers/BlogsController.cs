using B05ASPC03_DataAnnotation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B05ASPC03_DataAnnotation.Controllers
{
    public class BlogsController : Controller
    {
        dbblogcontext db = new dbblogcontext();
       
        // GET: Blogs
        public ActionResult Index()
        {
            return View(db.Blogs.Include("Category").ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.BlogCategories.OrderBy(c=>c.Name).ToList(),"Id","Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Blog entity)
        {
            string erMag = "";
            if (entity.PostedFile != null)
            {
                try
                {
                    string ext = Path.GetExtension(entity.PostedFile.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                    {
                        string savePath = Path.Combine(Server.MapPath("~/Images/Blogs"), entity.Name + ext);
                        entity.PostedFile.SaveAs(savePath);
                        entity.ImagePath = "~/Images/Blogs/" + entity.Name + ext;
                        db.Blogs.Add(entity);
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
                
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            erMag += ve.PropertyName+ ve.ErrorMessage;
                        }
                    }
                    ModelState.AddModelError("", erMag);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
               
            }
            else
            {
                ModelState.AddModelError("", "Please provide image ");
            }
            ViewBag.CategoryId = new SelectList(db.BlogCategories.OrderBy(c => c.Name).ToList(), "Id", "Name");
           return View(entity);
        }

    }
}