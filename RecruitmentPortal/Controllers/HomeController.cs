using PagedList;
using RecruitmentPortal.Models;
using RecruitmentPortal.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecruitmentPortal.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        /// <summary>
        /// Job Listing on Home Page
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method Collects JOBID
        /// </summary>
        /// <param name="id" This is the JOB ID></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Apply(long id)
        {
            try
            {
                //Check that User has not Already Applied, If they have, redirect them or show some message
                var newApplication = new Application
                {
                    JobID = id,
                    DateApplied = DateTime.Now,
                    DateLastModified = null,
                    AccountID = GetUserAccountID()
                };
                _context.Applications.Add(newApplication);
                _context.SaveChanges();
                SendEmail(User.Identity.Name);
                return Content("Job Application Successful."); 
                //You can chose to redirect user to a new page after confirming success
                //YOu can also Send user an Email immediately
            }
            catch (Exception)
            {
                //Log Errors
                return View("Error");
            }
        }
        public ActionResult About(long id)
        {
            return View();
        }

        public ActionResult Contact(long id)
        {
            return View();
        }

        /// <summary>
        /// Code to Get LoggediN user ID
        /// </summary>
        /// <returns></returns>
        public long GetUserAccountID()
        {
            return _context.Accounts.Where(f => f.Email == User.Identity.Name).FirstOrDefault().AccountID;
        }
        /// <summary>
        /// Code to Send Email
        /// </summary>
        /// <param name="user"></param>
        public void SendEmail(string user)
        {
            //Code for Sending Email, with template, class etc
        }
    }
}