using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mvc_JobPortal_FinalProject.Models
{
    public class EmployerMODEL
    {
        public int EmployerID { get; set; }

       [Display(Name="Company Logo")]
       [Required(ErrorMessage = "*")]
        public string CompanyLogo{get; set;}

       [Display(Name = "Enter Email")]
       [Required(ErrorMessage = "Please specify your email ID.You'll use this when you log in")]
       [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter a valid email ID")]
       [Remote("CheckEmail", "Home", ErrorMessage = "An account already exists with this email address.")]
        public string EmailAddress{get; set;}

       [Display(Name = "Company Name")]
       [Required(ErrorMessage = "*")]
        public string CompanyName{get; set;}

       [Display(Name = "Company Website")]
       [Required(ErrorMessage = "*")]
        public string CompanyWebsite{get; set;}

       [Display(Name = "Contact Number")]
       [Required(ErrorMessage = "*")]
        public string ContactNumber{get; set;}

       [Display(Name = "Choose a Password")]
       [Required(ErrorMessage = "*")]
       [StringLength(50, ErrorMessage = "Password chosen must be minimum 6 characters long.Please try another", MinimumLength = 6)]
       [DataType(DataType.Password)]
        public string EmpPassword { get; set; }

       [Display(Name = "Enter Security Question")]
       [Required(ErrorMessage = "Please Enter a Security Question.You'll use this to reset your password")]
        public string EmpSecurityQuestion { get; set; }

       [Display(Name = "Enter Security Answer")]
       [Required(ErrorMessage = "Please Enter a Security Answer")]
        public string EmpSecurityAnswer { get; set; }



        public int JobID { get; set; }

        [Display(Name = "Job Title")]
        [Required(ErrorMessage = "*")]
        public string JobTitle{get; set;}

        [Display(Name = "Job Description")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.MultilineText)]
        [StringLength(4000, ErrorMessage = "Job Description must be maximum 4000 characters long.")]
        public string JobDesc{get; set;}

        [Display(Name = "Number of Vacancies")]
        [Required(ErrorMessage = "*")]
        public int NoOfVacancies{get; set;}

        [Display(Name = "Min Experience")]
        [Required(ErrorMessage = "*")]
        public int MinExp{get; set;}

        [Display(Name = "Max Experience")]
        [Required(ErrorMessage = "*")]
        public int MaxExp{get; set;}

        [Display(Name = "Job Salary(per month)")]
        [Required(ErrorMessage = "*")]
        public int Salary{get; set;}

        [Display(Name = "Job Location")]
        [Required(ErrorMessage = "*")]
        public string JobLocation{get; set;}

        [Display(Name = "Industry Type")]
        [Required(ErrorMessage = "*")]
        public string IndustryType{get; set;}

        [Display(Name = "Functional Area")]
        [Required(ErrorMessage = "*")]
        public string FunctionalArea{get; set;}

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "*")]
        [StringLength(4000, ErrorMessage = "Job Description must be maximum 4000 characters long.")]
        public string Qualifications { get; set; }

        [Display(Name = "Posted Date")]
        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PostedDate{get; set;}

        [Display(Name = "Last Date to Apply")]
        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastDateToApply{get; set;}

        [Display(Name = "Apply Date")]
        [Required(ErrorMessage = "*")]    
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ApplyDate { get; set; }

        public string JSEmailID { get; set; }
        
    }
}
