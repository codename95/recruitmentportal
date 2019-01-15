using PagedList;
using RecruitmentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentPortal.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Admin 
        //View All Postings
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var jobs = from s in _context.Jobs
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.JobTitle.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    jobs = jobs.OrderByDescending(s => s.JobTitle);
                    break;
                case "Date":
                    jobs = jobs.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    jobs = jobs.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    jobs = jobs.OrderBy(s => s.JobTitle);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(jobs.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddNewJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewJob(job j)
        {
            return View();
        }
    }
}