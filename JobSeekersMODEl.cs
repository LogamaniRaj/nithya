using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mvc_JobPortal_FinalProject.Models
{
    public class JobSeekersMODEl
    {
        [Display(Name="Your Full Name")]
        [Required(ErrorMessage = "Please Enter your Full Name")]
        public string JSName { get; set; }

        [Display(Name = "Enter Email")]
        [Required(ErrorMessage="Please specify your email ID.You'll use this when you log in")]
        [DataType(DataType.EmailAddress,ErrorMessage="Please Enter a valid email ID")]
        [Remote("CheckEmailJS", "Home", ErrorMessage = "An account already exists with this email address.")]
        public string JSEmailID { get; set; }

        [Display(Name = "Choose a Password")]
        [Required(ErrorMessage = "Please Enter a Password")]
        [StringLength(50, ErrorMessage = "Password chosen must be minimum 6 characters long.Please try another", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string JSPassword { get; set; }

        [Display(Name = "Enter Phone")]
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string JSPhone { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Select your Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public DateTime JSDateofBirth{get; set;}

        [Display(Name = "Select Gender")]
        [Required(ErrorMessage = "Please select your Gender")]
        public string JSGender{get;set;}

        [Display(Name = "Enter Your Address")]
        [Required(ErrorMessage = "*")]
        [StringLength(500, ErrorMessage = "Address must be minimum 10 characters long", MinimumLength = 10)]        
        public string JSAddress{get ;set;}

        [Display(Name = "Select City")]
        [Required(ErrorMessage = "Select a city")]
        public string JSCity{get; set;}

        [Display(Name = "Enter LinkedIn ID")]
        [Required(ErrorMessage="*")]
        [EmailAddress(ErrorMessage="Enter a valid LinkedIn ID")]
        public string JSLinkedInID{get; set;}

        [Display(Name = "Enter Security Question")]
        [Required(ErrorMessage = "Please Enter a Security Question.You'll use this to reset your password")]
        public string JSSecurityQuestion { get; set; }

        [Display(Name = "Enter Security Answer")]
        [Required(ErrorMessage = "Please Enter a Security Answer")]
        public string JSSecurityAnswer { get; set; }

        //--------------------------------------------------------------------------------------------------------------

        [Display(Name = "Highest Education")]
        [Required(ErrorMessage = "*")]
        public string JSHighestEducation {get; set;}

        [Display(Name = "Course")]
        [Required(ErrorMessage = "*")]
        public string JSCourse {get; set;}

        [Display(Name = "Specialization")]
        [Required(ErrorMessage = "*")]
        public string JSSpecialization {get; set;}

        [Display(Name = "University")]
        [Required(ErrorMessage = "*")]
        public string JSUniversity {get; set;}

        [Display(Name = "Course Type")]
        [Required(ErrorMessage = "*")]
        public string JSCourseType {get; set;}

        [Display(Name = "Pass Out Year")]
        [Required(ErrorMessage = "*")]
        public int JSPassOutYear {get; set;}

        [Display(Name = "Percentage")]
        [Required(ErrorMessage = "*")] 
        [Range(0,100,ErrorMessage="Please Enter in percentage format(%)")]
        public int JSPercentage {get;set;}

        //--------------------------------------------------------------------------------------------------------------

        [Display(Name="Preferred Location 1")]
        [Required(ErrorMessage = "*")]
        public string JSLocation1{get; set;}

        [Display(Name="Preferred Location 2")]
        [Required(ErrorMessage = "*")]
        public string JSLocation2{get; set;}

        [Display(Name="Relocation")]
        [Required(ErrorMessage = "Select Relocation")]
        public string JSRelocation{get; set;}

        [Display(Name="Employment Type")]
        [Required(ErrorMessage = "*")]
        public string JSEmploymentType{get; set;}

        [Display(Name="Expected Salary")]
        [Required(ErrorMessage = "*")]
        public int JSExpectedSalary{get; set;}

        [Display(Name="Status")]
        [Required(ErrorMessage = "Select Status")]
        public string JSStatus{get; set;}

        //--------------------------------------------------------------------------------------------------------------

        [Display(Name="CompanyName")]
        [Required(ErrorMessage = "*")]
        public string JSCompanyName{get; set;}

        [Display(Name="JoiningDate")]
        [Required(ErrorMessage = "*")]      
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public DateTime JSJoiningDate{get; set;}

        [Display(Name="EndDate")]
        [Required(ErrorMessage = "*")]       
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",ApplyFormatInEditMode=true)]
        public DateTime JSEndDate{get; set;}

        [Display(Name="Designation")]
        [Required(ErrorMessage = "*")]
        public string JSDesignation{get; set;}

        [Display(Name="Experience")]
        [Required(ErrorMessage = "*")]
        public int JSExperience{get; set;}

        //--------------------------------------------------------------------------------------------------------------

        [Display(Name="Skill")]
        [Required(ErrorMessage = "*")]
        public string JSSkill{get; set;}

        [Display(Name="Version")]
        [Required(ErrorMessage = "*")]
        public string JSVersion{get; set;}

        [Display(Name="LastUsed")]
        [Required(ErrorMessage = "*")]        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JSLastUsed{get; set;}

        [Display(Name="Experience(in yrs)")]
        [Required(ErrorMessage = "*")]
        public int JSSkillExperience {get; set;}

        [Display(Name="ProjectTitle")]
        [Required(ErrorMessage = "*")]
        public string JSProjectTitle{get; set;}

        [Display(Name="Duration(in months)")]
        [Required(ErrorMessage = "*")]
        public int JSDuration{get; set;}
      

        //--------------------------------------------------------------------------------------------------------------
        [Display(Name="Profile Picture")]
        [Required(ErrorMessage = "*")]
        public string JSPhoto{get;set;}

        [Display(Name="Upload Resume")]
        [Required(ErrorMessage = "*")]
        public string Resume{get; set;}

        [Display(Name="Id Proof")]
        [Required(ErrorMessage = "*")]
        public string idproof{get; set;}

        [Display(Name="Upload ID Proof")]
        [Required(ErrorMessage = "*")]
        public string idproofdoc{get; set;}

    }
}



