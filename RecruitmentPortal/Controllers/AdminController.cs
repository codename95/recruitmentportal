using PagedList;
using RecruitmentPortal.Models;
using RecruitmentPortal.Models.Entities;
using RecruitmentPortal.Models.ViewModel;
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
        /// <summary>
        /// Job Listing -- All Jobs - Your Can Search and Sort and Paginate
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
        /// Add New Job
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNewJob()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewJob(JobViewModel model)
        {
            //Based on your business process, you can decide to check if the job exists and then prevent user
            //from saving similar jobs or otherwise. but for the sake of this tutorial we wont be doing that
            try
            {
                var newJob = new Job
                {
                    JobTitle = model.JobTitle,
                    JobDescription = model.JobDescription,
                    ExpiryDate = model.ExpiryDate,
                    JobCategoryID = model.JobCategoryID,
                    DateCreated = DateTime.Now,
                    CreatedBy = User.Identity.Name,
                    Views = 0
                };
                _context.Jobs.Add(newJob);
                _context.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception err)
            {
                //Log Error that Occured
                return View("Error");
            }
        }

        /// <summary>
        /// View Job Detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Job JobDetails(long id)
        {
            return _context.Jobs.Find(id);
        }


        /// <summary>
        /// View Job Applications
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult Applications(string sortOrder, string currentFilter, string searchString, int? page)
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

            var application = from s in _context.Applications
                       select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                application = application.Where(s => s.Account.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    application = application.OrderByDescending(s => s.Account.FirstName);
                    break;
                case "Date":
                    application = application.OrderBy(s => s.DateApplied);
                    break;
                case "date_desc":
                    application = application.OrderByDescending(s => s.DateApplied);
                    break;
                default:
                    application = application.OrderBy(s => s.Account.FirstName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(application.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ViewApplicantProfile(long id)
        {
            var account = _context.Accounts.Find(id);
            var model = new ApplicantViewModel
            {
                Account = account,
                UserApplications = _context.Applications.Where(f => f.AccountID == id).ToList()
            };
            return View(model);
        }
    }
}