using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Mvc_JobPortal_FinalProject.Models;

namespace Mvc_JobPortal_FinalProject.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult FirstPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string EmailID, string Password, bool RememberMe)
        {
            if (Membership.ValidateUser(EmailID, Password))
            {
                FormsAuthentication.SetAuthCookie(EmailID, RememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "The Email Address or Password that you've entered doesn't match any account.Sign up for an account";
                return View();
            }
        }
        [AllowAnonymous]
        public ActionResult NewUser()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });

            ViewBag.cities = Cities;
        
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewUser(JobSeekersMODEl js)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });
            ViewBag.cities = Cities;
            try
            {
                JobSeekersDAL jsDAL = new JobSeekersDAL();
                bool flag = jsDAL.NewUser(js);
                if (flag == true)
                {
                    ViewBag.newuser = "Account Created";
                }
                else
                {
                    ViewBag.newuser = "Account not Created";
                }

                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "NewEmployer", "Home"));
            }

        }
        public JsonResult CheckEmailJS(string JSEmailID)
        {
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            if (jsDAL.CheckEmailJS(JSEmailID))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
      public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");

        }
        [Authorize]
        public ActionResult AddDetails()
        {
            return View();
        }

        [Authorize]
        public ActionResult EducationalDetails()
        {
            List<SelectListItem> highesteducation = new List<SelectListItem>();
            highesteducation.Add(new SelectListItem { Text = "Doctoral Degree", Value = "Doctoral Degree" });
            highesteducation.Add(new SelectListItem { Text = "Master's Degree", Value = "Master's Degree" });
            highesteducation.Add(new SelectListItem { Text = "Bachelor's Degree", Value = "Bachelor's Degree" });
            highesteducation.Add(new SelectListItem { Text = "Associate's Degree", Value = "Associate's Degree" });
            ViewBag.highesteducation = highesteducation;

            List<SelectListItem> course = new List<SelectListItem>();
            course.Add(new SelectListItem { Text = "Ph.D", Value = "Ph.D" });
            course.Add(new SelectListItem { Text = "Pharm.D", Value = "Pharm.D" });
            course.Add(new SelectListItem { Text = "M.D", Value = "M.D" });

            course.Add(new SelectListItem { Text = "M.Tech", Value = "M.Tech" });
            course.Add(new SelectListItem { Text = "M.E", Value = "M.E" });
            course.Add(new SelectListItem { Text = "M.B.A", Value = "M.B.A" });
            course.Add(new SelectListItem { Text = "M.Acc", Value = "M.Acc" });
            course.Add(new SelectListItem { Text = "M.A", Value = "M.A" });
            course.Add(new SelectListItem { Text = "M.Ed", Value = "M.Ed" });
            course.Add(new SelectListItem { Text = "M.Agric", Value = "M.Agric" });
            course.Add(new SelectListItem { Text = "M.Com", Value = "M.Com" });
            course.Add(new SelectListItem { Text = "M.S", Value = "M.S" });
            course.Add(new SelectListItem { Text = "M.M", Value = "M.M" });

            course.Add(new SelectListItem { Text = "B.Tech", Value = "B.Tech" });
            course.Add(new SelectListItem { Text = "B.E", Value = "B.E" });
            course.Add(new SelectListItem { Text = "B.Com", Value = "B.Com" });
            course.Add(new SelectListItem { Text = "B.Ed", Value = "B.Ed" });
            course.Add(new SelectListItem { Text = "B.B.A", Value = "B.B.A" });
            course.Add(new SelectListItem { Text = "B.Sc", Value = "B.Sc" });
            course.Add(new SelectListItem { Text = "B.A", Value = "B.A" });
            course.Add(new SelectListItem { Text = "B.Arch", Value = "B.Arch" });
            course.Add(new SelectListItem { Text = "B.D.S", Value = "B.D.S" });
            course.Add(new SelectListItem { Text = "B.M", Value = "B.M" });

            course.Add(new SelectListItem { Text = "A.A.S", Value = "A.A.S" });
            course.Add(new SelectListItem { Text = "A.S", Value = "A.S" });
            course.Add(new SelectListItem { Text = "A.A", Value = "A.A" });
            course.Add(new SelectListItem { Text = "A.B.S", Value = "A.B.S" });
            course.Add(new SelectListItem { Text = "A.O.S", Value = "A.O.S" });
            course.Add(new SelectListItem { Text = "M.E", Value = "M.E" });
            course.Add(new SelectListItem { Text = "AECE", Value = "AECE" });
            ViewBag.Course = course;

            List<SelectListItem> specialization = new List<SelectListItem>();
            specialization.Add(new SelectListItem { Text = "Bio-Medical Engineering", Value = "Bio-Medical Engineering" });
            specialization.Add(new SelectListItem { Text = "Civil Engineering", Value = "Civil Engineering" });
            specialization.Add(new SelectListItem { Text = "Computer Science & Engineering", Value = "Computer Science & Engineering" });
            specialization.Add(new SelectListItem { Text = "Computer Science & Engineering", Value = "Computer Science & Engineering" });
            specialization.Add(new SelectListItem { Text = "Electronics & Communication Engineering", Value = "Electronics & Communication Engineering" });
            specialization.Add(new SelectListItem { Text = "Electrical & Electronics Engineering", Value = "Electrical & Electronics Engineering" });
            specialization.Add(new SelectListItem { Text = "Mechanical Engineering", Value = "Mechanical Engineering" });

            specialization.Add(new SelectListItem { Text = "Mathematics", Value = "Mathematics" });
            specialization.Add(new SelectListItem { Text = "Physics", Value = "Physics" });
            specialization.Add(new SelectListItem { Text = "Computer science", Value = "Computer science" });
            specialization.Add(new SelectListItem { Text = "Chemistry", Value = "Chemistry" });
            specialization.Add(new SelectListItem { Text = "Microbiology", Value = "Microbiology" });
            specialization.Add(new SelectListItem { Text = "Forensic Sciences", Value = "Forensic Sciences" });

            specialization.Add(new SelectListItem { Text = "Taxation and Insurance Law", Value = "Taxation and Insurance Law" });
            specialization.Add(new SelectListItem { Text = "Cyber Law", Value = "Cyber Law" });
            specialization.Add(new SelectListItem { Text = "Intellectual Property Rights", Value = "Intellectual Property Rights" });
            specialization.Add(new SelectListItem { Text = "Crimes and tortes", Value = "Crimes and tortes" });

            specialization.Add(new SelectListItem { Text = "Marketing", Value = "Marketing" });
            specialization.Add(new SelectListItem { Text = "Finance", Value = "Finance" });
            specialization.Add(new SelectListItem { Text = "Human Resource", Value = "Human Resource" });
            specialization.Add(new SelectListItem { Text = "Design Application", Value = "Design Application" });
            ViewBag.specialization = specialization;


            List<SelectListItem> CourseType = new List<SelectListItem>();
            CourseType.Add(new SelectListItem { Text = "Correspondence", Value = "Correspondence" });
            CourseType.Add(new SelectListItem { Text = "Full Time", Value = "Full Time" });
            ViewBag.CourseType = CourseType;

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult EducationalDetails(JobSeekersMODEl js)
        {
            List<SelectListItem> highesteducation = new List<SelectListItem>();
            highesteducation.Add(new SelectListItem { Text = "Doctoral Degree", Value = "Doctoral Degree" });
            highesteducation.Add(new SelectListItem { Text = "Master's Degree", Value = "Master's Degree" });
            highesteducation.Add(new SelectListItem { Text = "Bachelor's Degree", Value = "Bachelor's Degree" });
            highesteducation.Add(new SelectListItem { Text = "Associate's Degree", Value = "Associate's Degree" });
            ViewBag.highesteducation = highesteducation;


            List<SelectListItem> course = new List<SelectListItem>();
            course.Add(new SelectListItem { Text = "Ph.D", Value = "Ph.D" });
            course.Add(new SelectListItem { Text = "Pharm.D", Value = "Pharm.D" });
            course.Add(new SelectListItem { Text = "M.D", Value = "M.D" });

            course.Add(new SelectListItem { Text = "M.Tech", Value = "M.Tech" });
            course.Add(new SelectListItem { Text = "M.E", Value = "M.E" });
            course.Add(new SelectListItem { Text = "M.B.A", Value = "M.B.A" });
            course.Add(new SelectListItem { Text = "M.Acc", Value = "M.Acc" });
            course.Add(new SelectListItem { Text = "M.A", Value = "M.A" });
            course.Add(new SelectListItem { Text = "M.Ed", Value = "M.Ed" });
            course.Add(new SelectListItem { Text = "M.Agric", Value = "M.Agric" });
            course.Add(new SelectListItem { Text = "M.Com", Value = "M.Com" });
            course.Add(new SelectListItem { Text = "M.S", Value = "M.S" });
            course.Add(new SelectListItem { Text = "M.M", Value = "M.M" });

            course.Add(new SelectListItem { Text = "B.Tech", Value = "B.Tech" });
            course.Add(new SelectListItem { Text = "B.E", Value = "B.E" });
            course.Add(new SelectListItem { Text = "B.Com", Value = "B.Com" });
            course.Add(new SelectListItem { Text = "B.Ed", Value = "B.Ed" });
            course.Add(new SelectListItem { Text = "B.B.A", Value = "B.B.A" });
            course.Add(new SelectListItem { Text = "B.Sc", Value = "B.Sc" });
            course.Add(new SelectListItem { Text = "B.A", Value = "B.A" });
            course.Add(new SelectListItem { Text = "B.Arch", Value = "B.Arch" });
            course.Add(new SelectListItem { Text = "B.D.S", Value = "B.D.S" });
            course.Add(new SelectListItem { Text = "B.M", Value = "B.M" });

            course.Add(new SelectListItem { Text = "A.A.S", Value = "A.A.S" });
            course.Add(new SelectListItem { Text = "A.S", Value = "A.S" });
            course.Add(new SelectListItem { Text = "A.A", Value = "A.A" });
            course.Add(new SelectListItem { Text = "A.B.S", Value = "A.B.S" });
            course.Add(new SelectListItem { Text = "A.O.S", Value = "A.O.S" });
            course.Add(new SelectListItem { Text = "M.E", Value = "M.E" });
            course.Add(new SelectListItem { Text = "AECE", Value = "AECE" });
            ViewBag.Course = course;

            List<SelectListItem> specialization = new List<SelectListItem>();
            specialization.Add(new SelectListItem { Text = "Bio-Medical Engineering", Value = "Bio-Medical Engineering" });
            specialization.Add(new SelectListItem{Text="Civil Engineering",Value="Civil Engineering"});
            specialization.Add(new SelectListItem{Text="Computer Science & Engineering",Value="Computer Science & Engineering"});
            specialization.Add(new SelectListItem{Text="Computer Science & Engineering",Value="Computer Science & Engineering"});
            specialization.Add(new SelectListItem{Text="Electronics & Communication Engineering",Value="Electronics & Communication Engineering"});
            specialization.Add(new SelectListItem{Text="Electrical & Electronics Engineering",Value="Electrical & Electronics Engineering"});
            specialization.Add(new SelectListItem { Text = "Mechanical Engineering", Value = "Mechanical Engineering" });

            specialization.Add(new SelectListItem { Text = "Mathematics", Value = "Mathematics" });
            specialization.Add(new SelectListItem { Text = "Physics", Value = "Physics" });
            specialization.Add(new SelectListItem { Text = "Computer science", Value = "Computer science" });
            specialization.Add(new SelectListItem { Text = "Chemistry", Value = "Chemistry" });
            specialization.Add(new SelectListItem { Text = "Microbiology", Value = "Microbiology" });
            specialization.Add(new SelectListItem { Text = "Forensic Sciences", Value = "Forensic Sciences" });

            specialization.Add(new SelectListItem { Text = "Taxation and Insurance Law", Value = "Taxation and Insurance Law" });
            specialization.Add(new SelectListItem { Text = "Cyber Law", Value = "Cyber Law" });
            specialization.Add(new SelectListItem { Text = "Intellectual Property Rights", Value = "Intellectual Property Rights" });
            specialization.Add(new SelectListItem { Text = "Crimes and tortes", Value = "Crimes and tortes" });

            specialization.Add(new SelectListItem { Text = "Marketing", Value = "Marketing" });
            specialization.Add(new SelectListItem { Text = "Finance", Value = "Finance" });
            specialization.Add(new SelectListItem { Text = "Human Resource", Value = "Human Resource" });
            specialization.Add(new SelectListItem { Text = "Design Application", Value = "Design Application" });            
            ViewBag.specialization = specialization;
            
            List<SelectListItem> CourseType = new List<SelectListItem>();
            CourseType.Add(new SelectListItem{Text="Correspondence",Value="Correspondence"});
            CourseType.Add(new SelectListItem { Text = "Regular", Value = "Regular" });
            ViewBag.CourseType = CourseType;


            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.AddEducationDetails(js, str);
            ViewBag.addedu = "Educational Details Added Successfully...!!";
            ModelState.Clear();
            return View();
        }
        [Authorize]
        public ActionResult Preference()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });

            ViewBag.cities = Cities;

            List<SelectListItem> EmpType = new List<SelectListItem>();
            EmpType.Add(new SelectListItem { Text = "Full Time", Value = "Full Time" });
            EmpType.Add(new SelectListItem { Text = "Part Time", Value = "Part Time" });
            EmpType.Add(new SelectListItem { Text = "Freelance", Value = "Freelance" });
            EmpType.Add(new SelectListItem { Text = "Fixed Time", Value = "Fixed Time" });
            ViewBag.emptype = EmpType;
            return View();

          
        }
        [Authorize]
        [HttpPost]
        public ActionResult Preference(JobSeekersMODEl js)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });

            ViewBag.cities = Cities;

            List<SelectListItem> EmpType = new List<SelectListItem>();
            EmpType.Add(new SelectListItem { Text = "Full Time", Value = "Full Time" });
            EmpType.Add(new SelectListItem { Text = "Part Time", Value = "Part Time" });
            EmpType.Add(new SelectListItem { Text = "Freelance", Value = "Freelance" });
            EmpType.Add(new SelectListItem { Text = "Fixed Time", Value = "Fixed Time" });
            ViewBag.emptype = EmpType;

            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.AddPreference(js, str);
            ViewBag.addpref = "Preference Added Successfully...!!";
            ModelState.Clear();
            return View();
        }
        [Authorize]
        public ActionResult ExperienceDetails()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult ExperienceDetails(JobSeekersMODEl js)
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.AddExperienceDetails(js, str);            
            ViewBag.addexperience = "Experience Added Successfully...!!";
            ModelState.Clear();            
            return View();
        }
        [Authorize]
        public ActionResult SkillSet()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult SkillSet(JobSeekersMODEl js)
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.AddSkillSet(js, str);
            ViewBag.addskillset = "Skill Set Added Successfully...!!!";
            ModelState.Clear();
            return View();
        }
       [Authorize]
        public ActionResult ViewProfile()
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = new JobSeekersMODEl();
            jsDAL.ViewProfile(js, str);
            return View(js);
        }
        [Authorize]
        public ActionResult ViewEducationalDetails()
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = new JobSeekersMODEl();
            jsDAL.ViewEducationalDetails(js, str);
            return PartialView("ViewEducationalDetails", js);
        }
        [Authorize]
        public ActionResult ViewPreference()
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = jsDAL.ViewPreference(str);
            return PartialView("ViewPreference", js);
        }
        [Authorize]
        public ActionResult ViewExperience()
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            List<JobSeekersMODEl> explist = jsDAL.ViewExperience(str);
            return PartialView("ViewExperience", explist);
        }
        [Authorize]
        public ActionResult ViewSkillSet()
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            List<JobSeekersMODEl> skilllist = jsDAL.ViewSkillSet(str);
            return PartialView("ViewSkillSet", skilllist);
        }
        [Authorize]
        public ActionResult UploadDetails()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult UploadDetails(JobSeekersMODEl js,HttpPostedFileBase photo,HttpPostedFileBase resume,HttpPostedFileBase idproofdoc)
        {
            string str = @User.Identity.Name;
            JobSeekersDAL jsDAL=new JobSeekersDAL();
            jsDAL.UploadDetails(js,str);
            photo.SaveAs(Server.MapPath(js.JSPhoto));
            resume.SaveAs(Server.MapPath(js.Resume));
            idproofdoc.SaveAs(Server.MapPath(js.idproofdoc));
            ViewBag.upload = "Documents Uploaded Successfully...!!!";
            ModelState.Clear();
            return View();        
        }
        [Authorize]
        public ActionResult EditExperience(string JSCompanyName)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = jsDAL.ViewExp(str, JSCompanyName);            
            return View("EditExperience", js);          
            
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditExperience(JobSeekersMODEl js)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.Editexp(js, str);
            ViewBag.editexp = "Edited Successfully";
            return View();
        }
        [Authorize]
        public ActionResult EditSkillSet(string JSSkill)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = jsDAL.ViewSkill(str, JSSkill);
            return View("EditSkillSet", js);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditSkillSet(JobSeekersMODEl js)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.EditSkillSet(js, str);
            ViewBag.editskill = "Edited Successfully";
            return View();
        }
        [Authorize]
        public ActionResult EditPreference()
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = jsDAL.ViewPref(str);
            return View(js);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditPreference(JobSeekersMODEl js)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.EditPreference(js,str);
            ViewBag.editpref = "Edited Successfully...!!!";
            return View();        
        }
        [Authorize]
        public ActionResult EditEducation()
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            JobSeekersMODEl js = jsDAL.ViewEdu(str);
            return View(js);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditEducation(JobSeekersMODEl js)
        {
            string str = User.Identity.Name;
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            jsDAL.EditEducation(js, str);
            ViewBag.editedu = "Edited Successfully...!!!";
            return View();
        }
        [Authorize]
        public ActionResult FilterJobs()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });
            ViewBag.cities = Cities;

            List<SelectListItem> jobtitle = new List<SelectListItem>();
            jobtitle.Add(new SelectListItem { Text = "Systems Engineer", Value = "Systems Engineer" });
            jobtitle.Add(new SelectListItem { Text = "Application Support", Value = "Application Support" });
            jobtitle.Add(new SelectListItem { Text = "IRM Lead Specialist", Value = "IRM Lead Specialist" });
            jobtitle.Add(new SelectListItem { Text = "Sr App Developer", Value = "Sr App Developer" });
            jobtitle.Add(new SelectListItem { Text = "Analyst - Fund accounting Support", Value = "Analyst - Fund accounting Support" });
            jobtitle.Add(new SelectListItem { Text = "Sr Accounting Analyst", Value = "Sr Accounting Analyst" });
            jobtitle.Add(new SelectListItem { Text = "Sr Category Manager", Value = "Sr Category Manager" });
            jobtitle.Add(new SelectListItem { Text = "Partner Business Manager", Value = "Partner Business Manager" });
            jobtitle.Add(new SelectListItem { Text = "Technical Analyst", Value = "Technical Analyst" });
            jobtitle.Add(new SelectListItem { Text = "Reporting and Analyzing Specialist", Value = "Reporting and Analyzing Specialist" });
            jobtitle.Add(new SelectListItem { Text = "Data Analyst", Value = "Data Analyst" });

            ViewBag.jobtitle = jobtitle;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult FilterJobs(string joblocation, string JobTitle)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });
            ViewBag.cities = Cities;

            List<SelectListItem> jobtitle = new List<SelectListItem>();
            jobtitle.Add(new SelectListItem { Text = "Systems Engineer", Value = "Systems Engineer" });
            jobtitle.Add(new SelectListItem { Text = "Application Support", Value = "Application Support" });
            jobtitle.Add(new SelectListItem { Text = "IRM Lead Specialist", Value = "IRM Lead Specialist" });
            jobtitle.Add(new SelectListItem { Text = "Sr App Developer", Value = "Sr App Developer" });
            jobtitle.Add(new SelectListItem { Text = "Analyst - Fund accounting Support", Value = "Analyst - Fund accounting Support" });
            jobtitle.Add(new SelectListItem { Text = "Sr Accounting Analyst", Value = "Sr Accounting Analyst" });
            jobtitle.Add(new SelectListItem { Text = "Sr Category Manager", Value = "Sr Category Manager" });
            jobtitle.Add(new SelectListItem { Text = "Partner Business Manager", Value = "Partner Business Manager" });
            jobtitle.Add(new SelectListItem { Text = "Technical Analyst", Value = "Technical Analyst" });
            jobtitle.Add(new SelectListItem { Text = "Reporting and Analyzing Specialist", Value = "Reporting and Analyzing Specialist" });
            jobtitle.Add(new SelectListItem { Text = "Data Analyst", Value = "Data Analyst" });

            ViewBag.jobtitle = jobtitle;


            JobSeekersDAL jsDAL = new JobSeekersDAL();
            int count = jsDAL.CheckJobs(joblocation, JobTitle); 
            if (count == 0)
            {
                ViewBag.job = "No Results Found";
                return View();
            }
            else
            {
                List<EmployerMODEL> joblist = jsDAL.ViewJobsJS(joblocation, JobTitle);                
                return View("ViewJobJS", joblist); 
            }                    
        }
        [Authorize]
        public ActionResult ViewAllJobsJS()
        {
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            List<EmployerMODEL> joblist = jsDAL.ViewAllJobsJS();
            return View("ViewJobJS", joblist);         
        }
        
        [Authorize]
        public ActionResult ViewJobDetailsJS( string JobID )
        {
            JobSeekersDAL jsDAL = new JobSeekersDAL();
            EmployerMODEL emp = jsDAL.ViewJobDetailJS(JobID);
            return View(emp);        
        }
       [Authorize]
        public ActionResult ApplyForJob(EmployerMODEL emp, int JobID, string EmailAddress, string CompanyLogo, string CompanyName, string JobTitle, int Salary, DateTime PostedDate, DateTime LastDateToApply)
       {
           string str = User.Identity.Name;
           JobSeekersDAL jsDAL = new JobSeekersDAL();
           emp.JobID = JobID;
           emp.EmailAddress = EmailAddress;
           emp.CompanyLogo = CompanyLogo;
           emp.CompanyName = CompanyName;
           emp.JobTitle = JobTitle;
           emp.Salary = Salary;
           int count = jsDAL.ApplyForJob(emp, str, JobID, LastDateToApply);
           if (count == 0)
           {
               ViewBag.applyjob = "You have already applied for this job";
               return View();
           }
          else if (count == 1)
           {
               ViewBag.applyjob = "Sorry...Last date is over";               
               return View();
           }
           else
           {
               ViewBag.applyjob = "Applied Successfully...!!";
               return View();
           }
       }
       [Authorize]
       public ActionResult ViewAppliedJobJS(EmployerMODEL emp)
       {
           string str = User.Identity.Name;
           JobSeekersDAL jsDAL = new JobSeekersDAL();
           List<EmployerMODEL> appliedjoblist = jsDAL.ViewAppliedJobJS(str);
           return View(appliedjoblist);
       }
         
        





//------------------------------------------------EMPLOYER-------------------------------------------------------------

        public ActionResult EmployerIndex()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult EmployerLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult EmployerLogin(string EmailID, string Password, bool RememberMe)
        {
            if (Membership.ValidateUser(EmailID, Password))
            {
                FormsAuthentication.SetAuthCookie(EmailID, RememberMe);
                return RedirectToAction("EmployerIndex", "Home");
            }
            else
            {
                ViewBag.empmsg = "The Email Address or Password that you've entered doesn't match any account.Sign up for an account";
                return View();
            }
        }
        
        [AllowAnonymous]
        public ActionResult NewEmployer()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult NewEmployer(EmployerMODEL emp, HttpPostedFileBase image)
        {
            try
            {
                EmployerDAL empDAL = new EmployerDAL();
                bool flag = empDAL.NewUser(emp);
                if (flag == true)
                {
                    ViewBag.newemp = "Account  Created";
                }
                else
                {
                    ViewBag.newemp = "Account not Created";
                }

                ModelState.Clear();
                return View();
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "NewEmployer", "Home"));
            }
        }
       [AllowAnonymous]
          public JsonResult CheckEmail(string EmailAddress)
        {
            EmployerDAL empDAL = new EmployerDAL();
            if (empDAL.CheckEmail(EmailAddress))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult EmpLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("EmployerLogin", "Home");

        }
        [Authorize]
        public ActionResult AddJob()
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });

            ViewBag.cities = Cities;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AddJob(EmployerMODEL emp)
        {
            List<SelectListItem> Cities = new List<SelectListItem>();
            Cities.Add(new SelectListItem { Text = "Chennai", Value = "Chennai" });
            Cities.Add(new SelectListItem { Text = "Pune", Value = "Pune" });
            Cities.Add(new SelectListItem { Text = "Mumbai", Value = "Mumbai" });
            Cities.Add(new SelectListItem { Text = "Delhi", Value = "Delhi" });
            Cities.Add(new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" });
            Cities.Add(new SelectListItem { Text = "Bangalore", Value = "Bangalore" });
            Cities.Add(new SelectListItem { Text = "Ahmedabad", Value = "Ahmedabad" });
            Cities.Add(new SelectListItem { Text = "Kolkata", Value = "Kolkata" });
            Cities.Add(new SelectListItem { Text = "Coimbatore", Value = "Coimbatore" });
            Cities.Add(new SelectListItem { Text = "Madurai", Value = "Madurai" });
            Cities.Add(new SelectListItem { Text = "Kochi", Value = "Kochi" });
            Cities.Add(new SelectListItem { Text = "Tokyo–Yokohama", Value = "Tokyo–Yokohama" });
            Cities.Add(new SelectListItem { Text = "New York", Value = "New York" });
            Cities.Add(new SelectListItem { Text = "Moscow", Value = "Moscow" });
            Cities.Add(new SelectListItem { Text = "Los Angeles", Value = "Los Angeles" });
            Cities.Add(new SelectListItem { Text = "Bangkok", Value = "Bangkok" });
            Cities.Add(new SelectListItem { Text = "Chicago", Value = "Chicago" });
            Cities.Add(new SelectListItem { Text = "Toronto", Value = "Toronto" });
            Cities.Add(new SelectListItem { Text = "San Francisco", Value = "San Francisco" });

            ViewBag.cities = Cities;

            string str = @User.Identity.Name;
            EmployerDAL empDAL = new EmployerDAL();
            empDAL.AddJob(emp,str);
            ViewBag.addjob = "Job Added Succesfully";
            ModelState.Clear();
            return View();
        }
        [Authorize]
        public ActionResult ViewEmpProfile(EmployerMODEL emp)
        {
            string str = @User.Identity.Name;
            EmployerDAL empDAL = new EmployerDAL();
            empDAL.ViewEmpProfile(emp, str);
            return View(emp);
        
        }
        [Authorize]
        public ActionResult ViewJob(EmployerMODEL emp)
        {
            string str = @User.Identity.Name;
            EmployerDAL empDAL=new EmployerDAL();
            List<EmployerMODEL> joblist = empDAL.ViewJob(str);
            return PartialView("ViewJob",joblist);            
        }
        [Authorize]
        public ActionResult ViewJobDetails(string JobID)
        {
            string str = @User.Identity.Name;
            EmployerDAL empDAL = new EmployerDAL();
            EmployerMODEL emp = empDAL.ViewJobDetails(str,JobID);
            return View(emp);
        
        }
        [Authorize]
        public ActionResult ViewAppliedJob(EmployerMODEL app)
        {
            string str = User.Identity.Name;
            EmployerDAL empDAL = new EmployerDAL();
            List<EmployerMODEL> appliedjoblist = empDAL.ViewAppliedJob(str);
            return View(appliedjoblist);        
        }
    }
}