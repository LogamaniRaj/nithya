using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_JobPortal_FinalProject.Models
{
    public class JobSeekersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        /// <summary>
        /// To Check for Unique Email Address
        /// </summary>
        /// <param name="JSEmailID"></param>
        /// <returns></returns>
        public bool CheckEmailJS(string JSEmailID)
        {
            SqlCommand com_check = new SqlCommand("Select count(*) from JobSeekers where JSEmailID=@email", con);
            com_check.Parameters.AddWithValue("@email", JSEmailID);
            con.Open();
            int count = Convert.ToInt32(com_check.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }    
        /// <summary>
        /// To Create a new Job Seeker Account
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool NewUser(JobSeekersMODEl obj)
        {
            SqlCommand com_insert_new_user = new SqlCommand("insert JobSeekers values (@emailid,@name,@phone,@dob,@gender,@address,@city,@linkedid)", con);
                com_insert_new_user.Parameters.AddWithValue("@emailid", obj.JSEmailID);
                com_insert_new_user.Parameters.AddWithValue("@name", obj.JSName);
                com_insert_new_user.Parameters.AddWithValue("@phone", obj.JSPhone);
                com_insert_new_user.Parameters.AddWithValue("@dob", obj.JSDateofBirth);
                com_insert_new_user.Parameters.AddWithValue("@gender", obj.JSGender);
                com_insert_new_user.Parameters.AddWithValue("@address", obj.JSAddress);
                com_insert_new_user.Parameters.AddWithValue("@city", obj.JSCity);
                com_insert_new_user.Parameters.AddWithValue("@linkedid", obj.JSLinkedInID);
                con.Open();
                com_insert_new_user.ExecuteNonQuery();
                con.Close();
                MembershipCreateStatus status;
                Membership.CreateUser(obj.JSEmailID, obj.JSPassword, obj.JSEmailID, obj.JSSecurityQuestion, obj.JSSecurityAnswer, true, out status);

                if (status == MembershipCreateStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }             
            }  
        /// <summary>
        /// To Add educational details of the Job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool AddEducationDetails(JobSeekersMODEl js, string str)
        {
            SqlCommand com_add_educationDetails = new SqlCommand("Insert JSEducationDetails values(@email,@highesteducation,@course,@specialization,@university,@coursetype,@passoutyear,@percentage)", con);
            com_add_educationDetails.Parameters.AddWithValue("@email", str);
            com_add_educationDetails.Parameters.AddWithValue("@highesteducation", js.JSHighestEducation);
            com_add_educationDetails.Parameters.AddWithValue("@course", js.JSCourse);
            com_add_educationDetails.Parameters.AddWithValue("@specialization", js.JSSpecialization);
            com_add_educationDetails.Parameters.AddWithValue("@university", js.JSUniversity);
            com_add_educationDetails.Parameters.AddWithValue("@coursetype", js.JSCourseType);
            com_add_educationDetails.Parameters.AddWithValue("@passoutyear", js.JSPassOutYear);
            com_add_educationDetails.Parameters.AddWithValue("@percentage", js.JSPercentage);
            con.Open();
            com_add_educationDetails.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        ///  To Add Preference details of the Job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool AddPreference(JobSeekersMODEl js, string str)
        {
            SqlCommand com_add_preference = new SqlCommand("insert JSPreference values (@email,@location1,@location2,@relocation,@emptype,@expectedsalary,@status)", con);
            com_add_preference.Parameters.AddWithValue("@email", str);
            com_add_preference.Parameters.AddWithValue("@location1", js.JSLocation1);
            com_add_preference.Parameters.AddWithValue("@location2", js.JSLocation2);
            com_add_preference.Parameters.AddWithValue("@relocation", js.JSRelocation);
            com_add_preference.Parameters.AddWithValue("@emptype", js.JSEmploymentType);
            com_add_preference.Parameters.AddWithValue("@expectedsalary", js.JSExpectedSalary);
            com_add_preference.Parameters.AddWithValue("@status", js.JSStatus);
            con.Open();
            com_add_preference.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        ///  To Add experience details of the Job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool AddExperienceDetails(JobSeekersMODEl js, string str)
        {
            SqlCommand com_add_experience_details = new SqlCommand("insert JS_ExperienceDetails values(@email,@companyname,@joiningdate,@enddate,@designation,@experience)", con);
            com_add_experience_details.Parameters.AddWithValue("@email", str);
            com_add_experience_details.Parameters.AddWithValue("@companyname", js.JSCompanyName);
            com_add_experience_details.Parameters.AddWithValue("@joiningdate", js.JSJoiningDate);
            com_add_experience_details.Parameters.AddWithValue("@enddate", js.JSEndDate);
            com_add_experience_details.Parameters.AddWithValue("@designation", js.JSDesignation);
            com_add_experience_details.Parameters.AddWithValue("@experience", js.JSExperience);
            con.Open();
            com_add_experience_details.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        ///  To Add Skill Set details of the Job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool AddSkillSet(JobSeekersMODEl js, string str)
        {
            SqlCommand com_add_skillset = new SqlCommand("insert JS_SkillSet values (@email,@skill,@version,@lastused,@experience,@projecttitle,@duration)", con);
            com_add_skillset.Parameters.AddWithValue("@email", str);
            com_add_skillset.Parameters.AddWithValue("@skill", js.JSSkill);
            com_add_skillset.Parameters.AddWithValue("@version", js.JSVersion);
            com_add_skillset.Parameters.AddWithValue("@lastused", js.JSLastUsed);
            com_add_skillset.Parameters.AddWithValue("@experience", js.JSSkillExperience);
            com_add_skillset.Parameters.AddWithValue("@projecttitle", js.JSProjectTitle);
            com_add_skillset.Parameters.AddWithValue("@duration", js.JSDuration);            
            con.Open();
            com_add_skillset.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To View Profile of the Job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public JobSeekersMODEl ViewProfile(JobSeekersMODEl js, string str)
        {
            SqlCommand com_view_profile = new SqlCommand("select JSName,JSPhone,JSDateofBirth,JSGender,JSAddress,JSCity,JSLinkedInID from JobSeekers where JSEmailID=@emailid ", con);
            com_view_profile.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_profile.ExecuteReader();
            if (dr.Read())
            {
                js.JSName = dr.GetString(0);
                js.JSPhone = dr.GetString(1);
                js.JSDateofBirth = dr.GetDateTime(2);
                js.JSGender = dr.GetString(3);
                js.JSAddress = dr.GetString(4);
                js.JSCity = dr.GetString(5);
                js.JSLinkedInID = dr.GetString(6);
            }
            con.Close();
            return js;
        }
        public JobSeekersMODEl ViewEducationalDetails(JobSeekersMODEl js, string str)
        {
            SqlCommand com_view_edu_details = new SqlCommand("select JSHighestEducation,JSCourse,JSSpecialization,JSUniversity,JSCourseType,JSPassOutYear,JSPercentage from JSEducationDetails where JSEmailID=@emailid", con);
            com_view_edu_details.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_edu_details.ExecuteReader();
            if (dr.Read())
            {
                js.JSHighestEducation = dr.GetString(0);
                js.JSCourse = dr.GetString(1);
                js.JSSpecialization = dr.GetString(2);
                js.JSUniversity = dr.GetString(3);
                js.JSCourseType = dr.GetString(4);
                js.JSPassOutYear = dr.GetInt32(5);
                js.JSPercentage = dr.GetInt32(6);
            }
            con.Close();
            return js;
        }

        public JobSeekersMODEl ViewPreference(string str)
        {           
            SqlCommand com_view_preference = new SqlCommand("select JSLocation1,JSLocation2,JSRelocation,JSEmploymentType,JSExpectedSalary,JSStatus from JSPreference where JSEmailID=@emailid", con);
            com_view_preference.Parameters.AddWithValue("@emailid", str);
            con.Open();
            JobSeekersMODEl js = new JobSeekersMODEl();
            SqlDataReader dr = com_view_preference.ExecuteReader();
            if (dr.Read())
            {               
                js.JSLocation1 = dr.GetString(0);
                js.JSLocation2 = dr.GetString(1);
                js.JSRelocation = dr.GetString(2);
                js.JSEmploymentType = dr.GetString(3);
                js.JSExpectedSalary = dr.GetInt32(4);
                js.JSStatus = dr.GetString(5);
                
            }
            con.Close();
            return js;
        }
        public List<JobSeekersMODEl> ViewExperience(string str)
        {
            List<JobSeekersMODEl> Explist = new List<JobSeekersMODEl>();
            SqlCommand com_view_experience = new SqlCommand("Select JSCompanyName,JSJoiningDate,JSEndDate,JSDesignation,JSExperience from JS_ExperienceDetails where JSEmailID=@emailid", con);
            com_view_experience.Parameters.AddWithValue("@emailid", str);
            con.Open();
            
            SqlDataReader dr = com_view_experience.ExecuteReader();
            while (dr.Read())
            {
                JobSeekersMODEl js = new JobSeekersMODEl();
                js.JSCompanyName = dr.GetString(0);
                js.JSJoiningDate = dr.GetDateTime(1);
                js.JSEndDate = dr.GetDateTime(2);
                js.JSDesignation = dr.GetString(3);
                js.JSExperience = dr.GetInt32(4);
                Explist.Add(js);

            }
            con.Close();
            return Explist;
        }

        public List<JobSeekersMODEl> ViewSkillSet(string str)
        {
            List<JobSeekersMODEl> Skilllist = new List<JobSeekersMODEl>();
            SqlCommand com_view_skillset = new SqlCommand("Select JSSkill,JSVersion,JSLastUsed,JSExperience,JSProjectTitle,JSDuration from JS_SkillSet where JSEmailID=@emailid", con);
            com_view_skillset.Parameters.AddWithValue("@emailid", str);
            
            con.Open();
            SqlDataReader dr = com_view_skillset.ExecuteReader();
            while (dr.Read())
            {
                JobSeekersMODEl js = new JobSeekersMODEl();
                js.JSSkill = dr.GetString(0);
                js.JSVersion = dr.GetString(1);
                js.JSLastUsed = dr.GetDateTime(2);
                js.JSSkillExperience = dr.GetInt32(3);
                js.JSProjectTitle = dr.GetString(4);
                js.JSDuration = dr.GetInt32(5);                
                Skilllist.Add(js);
            }
            con.Close();
            return Skilllist;
        }
        /// <summary>
        /// To Load the Experience details for updating
        /// </summary>
        /// <param name="email"></param>
        /// <param name="JSCompanyName"></param>
        /// <returns></returns>
        public JobSeekersMODEl ViewExp(string email, string JSCompanyName)
        {
            JobSeekersMODEl js = new JobSeekersMODEl();
            SqlCommand com_view_experience = new SqlCommand("Select JSJoiningDate,JSEndDate,JSDesignation,JSExperience from JS_ExperienceDetails where JSEmailID=@emailid and JSCompanyName=@companyname", con);
            com_view_experience.Parameters.AddWithValue("@emailid", email);
            com_view_experience.Parameters.AddWithValue("@companyname", JSCompanyName);            
            con.Open();            
            SqlDataReader dr = com_view_experience.ExecuteReader();
            if (dr.Read())
            {                
                js.JSJoiningDate = dr.GetDateTime(0);
                js.JSEndDate = dr.GetDateTime(1);
                js.JSDesignation = dr.GetString(2);
                js.JSExperience = dr.GetInt32(3);                

            }
            con.Close();
            return js;
        }
        /// <summary>
        /// To Edit the Experience details
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool Editexp(JobSeekersMODEl js, string str)
        {
            SqlCommand com_edit_experience = new SqlCommand("Update JS_ExperienceDetails set JSCompanyName=@cmpname,JSJoiningDate=@joiningdate,JSEndDate=@enddate,JSDesignation=@desig,JSExperience=@exp where JSEmailID=@email", con);
            com_edit_experience.Parameters.AddWithValue("@email", str);
            com_edit_experience.Parameters.AddWithValue("@cmpname", js.JSCompanyName);
            com_edit_experience.Parameters.AddWithValue("@joiningdate", js.JSJoiningDate);
            com_edit_experience.Parameters.AddWithValue("@enddate", js.JSEndDate);
            com_edit_experience.Parameters.AddWithValue("@desig", js.JSDesignation);
            com_edit_experience.Parameters.AddWithValue("@exp", js.JSExperience);
            con.Open();
            com_edit_experience.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To Load the Skill Set details for updating
        /// </summary>
        /// <param name="email"></param>
        /// <param name="JSSkill"></param>
        /// <returns></returns>
        public JobSeekersMODEl ViewSkill(string email, string JSSkill)
        {
            SqlCommand com_view_skill = new SqlCommand("Select JSVersion,JSLastUsed,JSExperience,JSProjectTitle,JSDuration from JS_SkillSet where JSEmailID=@email and JSSkill=@skill", con);
            com_view_skill.Parameters.AddWithValue("@email", email);
            com_view_skill.Parameters.AddWithValue("@skill", JSSkill);
            con.Open();
            JobSeekersMODEl js = new JobSeekersMODEl();
            SqlDataReader dr = com_view_skill.ExecuteReader();
            if (dr.Read())
            {
               
                js.JSVersion = dr.GetString(0);
                js.JSLastUsed = dr.GetDateTime(1);
                js.JSSkillExperience = dr.GetInt32(2);
                js.JSProjectTitle = dr.GetString(3);
                js.JSDuration = dr.GetInt32(4);
                
            }
            con.Close();
            return js;
        }
        /// <summary>
        /// To Edit the Skill Set
        /// </summary>
        /// <param name="js"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EditSkillSet(JobSeekersMODEl js, string email)
        {
            SqlCommand com_edit_skill = new SqlCommand("Update JS_SkillSet set JSSkill=@skill,JSVersion=@version,JSLastUsed=@lastused,JSExperience=@experience,JSProjectTitle=@projecttitle,JSDuration=@duration where JSEmailID=@email", con);
            com_edit_skill.Parameters.AddWithValue("@email", email);
            com_edit_skill.Parameters.AddWithValue("@skill", js.JSSkill);
            com_edit_skill.Parameters.AddWithValue("@version", js.JSVersion);
            com_edit_skill.Parameters.AddWithValue("@lastused", js.JSLastUsed);
            com_edit_skill.Parameters.AddWithValue("@experience", js.JSSkillExperience);
            com_edit_skill.Parameters.AddWithValue("@projecttitle", js.JSProjectTitle);
            com_edit_skill.Parameters.AddWithValue("@duration", js.JSDuration);            
            con.Open();
            com_edit_skill.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To Load the Preference details for updating
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public JobSeekersMODEl ViewPref(string email)
        {
            SqlCommand com_view_pref = new SqlCommand("Select JSLocation1,JSLocation2,JSRelocation,JSEmploymentType,JSExpectedSalary,JSStatus from JSPreference where JSEmailID=@email", con);
            com_view_pref.Parameters.AddWithValue("@email",email);
            con.Open();
            JobSeekersMODEl js = new JobSeekersMODEl();
            SqlDataReader dr=com_view_pref.ExecuteReader();
            if(dr.Read())
            {
                
                js.JSLocation1=dr.GetString(0);
                js.JSLocation2=dr.GetString(1);
                js.JSRelocation=dr.GetString(2);
                js.JSEmploymentType=dr.GetString(3);
                js.JSExpectedSalary=dr.GetInt32(4);
                js.JSStatus=dr.GetString(5);            
            }
            con.Close();
            return js;        
        }
        /// <summary>
        /// To Edit preference Details
        /// </summary>
        /// <param name="js"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EditPreference(JobSeekersMODEl js, string email)
        {
            SqlCommand com_edit_pref = new SqlCommand("Update JSPreference set JSLocation1=@loc1,JSLocation2=@loc2,JSRelocation=@reloc,JSEmploymentType=@emptype,JSExpectedSalary=@expsal,JSStatus=@status where JSEmailID=@email", con);
            com_edit_pref.Parameters.AddWithValue("@email", email);
             com_edit_pref.Parameters.AddWithValue("@loc1",js.JSLocation1);
            com_edit_pref.Parameters.AddWithValue("@loc2",js.JSLocation2);
            com_edit_pref.Parameters.AddWithValue("@reloc",js.JSRelocation);
            com_edit_pref.Parameters.AddWithValue("@emptype",js.JSEmploymentType);
            com_edit_pref.Parameters.AddWithValue("@expsal",js.JSExpectedSalary);
            com_edit_pref.Parameters.AddWithValue("@status",js.JSStatus);
            con.Open();
            com_edit_pref.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To Load the Educational details for updating
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public JobSeekersMODEl ViewEdu(string email)
        {
            SqlCommand com_view_edu = new SqlCommand("Select JSHighestEducation,JSCourse,JSSpecialization,JSUniversity,JSCourseType,JSPassOutYear,JSPercentage from JSEducationDetails where JSEmailID=@email", con);
            com_view_edu.Parameters.AddWithValue("@email", email);
            con.Open();
            JobSeekersMODEl js = new JobSeekersMODEl();
            SqlDataReader dr = com_view_edu.ExecuteReader();
            if (dr.Read())
            {               
                js.JSHighestEducation = dr.GetString(0);
                js.JSCourse = dr.GetString(1);
                js.JSSpecialization = dr.GetString(2);
                js.JSUniversity = dr.GetString(3);
                js.JSCourseType = dr.GetString(4);
                js.JSPassOutYear = dr.GetInt32(5);
                js.JSPercentage=dr.GetInt32(6);
            }
            con.Close();
            return js;
        }
        /// <summary>
        /// To Edit Educational Details
        /// </summary>
        /// <param name="js"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool EditEducation(JobSeekersMODEl js, string email)
        {
            SqlCommand com_edit_edu = new SqlCommand("Update JSEducationDetails set JSHighestEducation=@highedu,JSCourse=@course,JSSpecialization=@spec,JSUniversity=@university,JSCourseType=@coursetype,JSPassOutYear=@passoutyear,JSPercentage=@percent  where JSEmailID=@email", con);
            com_edit_edu.Parameters.AddWithValue("@email", email);
            com_edit_edu.Parameters.AddWithValue("@highedu", js.JSHighestEducation);
            com_edit_edu.Parameters.AddWithValue("@course", js.JSCourse);
            com_edit_edu.Parameters.AddWithValue("@spec", js.JSSpecialization);
            com_edit_edu.Parameters.AddWithValue("@university", js.JSUniversity);
            com_edit_edu.Parameters.AddWithValue("@coursetype", js.JSCourseType);
            com_edit_edu.Parameters.AddWithValue("@passoutyear", js.JSPassOutYear);
            com_edit_edu.Parameters.AddWithValue("@percent", js.JSPercentage);
            con.Open();
            com_edit_edu.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To Upload documents of the job Seeker
        /// </summary>
        /// <param name="js"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool UploadDetails(JobSeekersMODEl js,string str)
        { 
            SqlCommand com_upload_details=new SqlCommand("insert JSUpload values(@email,null,null,@idproof,null)",con);
            com_upload_details.Parameters.AddWithValue("@email", str);
            com_upload_details.Parameters.AddWithValue("@idproof",js.idproof);
            con.Open();
            com_upload_details.ExecuteNonQuery();
            SqlCommand com_name = new SqlCommand("Select JSPhone from JobSeekers where JSEmailID=@emailid", con);
            com_name.Parameters.AddWithValue("@emailid", str);
            js.JSPhone = com_name.ExecuteScalar().ToString();
            js.JSPhoto="/JobSeekersImages/"+js.JSPhone+".jpg";
            js.Resume="/Resume/"+js.JSPhone+".pdf";
            js.idproofdoc="/IDProofDocuments/"+js.JSPhone+".jpg";
            SqlCommand com_upload_photo = new SqlCommand("Update JSUpload set JSPhoto=@img,Resume=@res,idproofdoc=@idproofdoc where JSEmailID=@emailid", con);
            com_upload_photo.Parameters.AddWithValue("@img",js.JSPhoto);
            com_upload_photo.Parameters.AddWithValue("@res",js.Resume);
            com_upload_photo.Parameters.AddWithValue("@idproofdoc", js.idproofdoc);
            com_upload_photo.Parameters.AddWithValue("@emailid", str);
            com_upload_photo.ExecuteNonQuery();
            con.Close();
            return true;
        }
        /// <summary>
        /// To Check whether Jobs are available based on your search
        /// </summary>
        /// <param name="jobloc"></param>
        /// <param name="JobTitle"></param>
        /// <returns></returns>
        public int CheckJobs(string jobloc, string JobTitle)
        {
            SqlCommand com_check = new SqlCommand("Select count(*) from JobDetails where JobLocation=@jobloc or JobTitle=@JobTitle", con);
            com_check.Parameters.AddWithValue("@jobloc", jobloc);
            com_check.Parameters.AddWithValue("@JobTitle", JobTitle);
            con.Open();
            int count = Convert.ToInt32(com_check.ExecuteScalar());
            con.Close();
            return count;
        }
        /// <summary>
        /// To Enlist all the posted Jobs
        /// </summary>
        /// <returns></returns>
        public List<EmployerMODEL> ViewAllJobsJS()
        {
            con.Open();
            List<EmployerMODEL> list = new List<EmployerMODEL>();
            SqlCommand com_view_jobs = new SqlCommand("select e.CompanyLogo,e.CompanyName,j.JobID,j.JobTitle,j.JobLocation,j.LastDateToApply from JobDetails j join Employers e on e.EmailAddress=j.EmailAddress ", con);            
            SqlDataReader dr = com_view_jobs.ExecuteReader();
            while (dr.Read())
            {
                EmployerMODEL emp = new EmployerMODEL();
                emp.CompanyLogo = dr.GetString(0);
                emp.CompanyName = dr.GetString(1);
                emp.JobID = dr.GetInt32(2);
                emp.JobTitle = dr.GetString(3);
                emp.JobLocation = dr.GetString(4);
                emp.LastDateToApply = dr.GetDateTime(5);
                list.Add(emp);
            }
            con.Close();
            return list;

        }
        /// <summary>
        /// To list the jobs based on Job Seeker's preference(Location and Title)
        /// </summary>
        /// <param name="JobLocation"></param>
        /// <param name="JobTitle"></param>
        /// <returns></returns>
        public List<EmployerMODEL> ViewJobsJS(string JobLocation, string JobTitle)
        {
            con.Open();
            List<EmployerMODEL> list = new List<EmployerMODEL>();
            SqlCommand com_view_jobs = new SqlCommand("select e.CompanyLogo,e.CompanyName,j.JobID,j.JobTitle,j.JobLocation,j.LastDateToApply from JobDetails j join Employers e on e.EmailAddress=j.EmailAddress where JobLocation=@jobloc or JobTitle=@jobtitle", con);
            com_view_jobs.Parameters.AddWithValue("@jobloc", JobLocation);
            com_view_jobs.Parameters.AddWithValue("@jobtitle", JobTitle);
                SqlDataReader dr = com_view_jobs.ExecuteReader();
                while (dr.Read())
                {
                    EmployerMODEL emp = new EmployerMODEL();
                    emp.CompanyLogo = dr.GetString(0);
                    emp.CompanyName = dr.GetString(1);
                    emp.JobID = dr.GetInt32(2);
                    emp.JobTitle = dr.GetString(3);
                    emp.JobLocation = dr.GetString(4);
                    emp.LastDateToApply = dr.GetDateTime(5);
                    list.Add(emp);
                }
                con.Close();
                return list;
            }                
        /// <summary>
        /// To View the complete details of that Job
        /// </summary>
        /// <param name="JobID"></param>
        /// <returns></returns>
        public EmployerMODEL ViewJobDetailJS(string JobID )
        {
            SqlCommand com_view_jobdetails = new SqlCommand("select e.CompanyLogo,e.CompanyName,e.CompanyWebsite,e.ContactNumber,e.EmailAddress,j.JobID,j.JobTitle,j.JobDescription,j.Qualifications,j.NumberofVacancies,j.MinExperience,j.MaxExperience,j.Salary,j.JobLocation,j.IndustryType,j.FunctionalArea,j.PostedDate,j.LastDateToApply from JobDetails j join Employers e on e.EmailAddress=j.EmailAddress where JobID=@JobID", con);            
            com_view_jobdetails.Parameters.AddWithValue("@JobID", JobID);            
            con.Open();
            EmployerMODEL emp = new EmployerMODEL();
            SqlDataReader dr = com_view_jobdetails.ExecuteReader();
            if (dr.Read())
            {                
                emp.CompanyLogo = dr.GetString(0);
                emp.CompanyName = dr.GetString(1);
                emp.CompanyWebsite = dr.GetString(2);
                emp.ContactNumber = dr.GetString(3);
                emp.EmailAddress = dr.GetString(4);
                emp.JobID = dr.GetInt32(5);
                emp.JobTitle = dr.GetString(6);
                emp.JobDesc = dr.GetString(7);
                emp.Qualifications=dr.GetString(8);
                emp.NoOfVacancies = dr.GetInt32(9);
                emp.MinExp = dr.GetInt32(10);
                emp.MaxExp = dr.GetInt32(11);
                emp.Salary = dr.GetInt32(12);
                emp.JobLocation = dr.GetString(13);
                emp.IndustryType = dr.GetString(14);
                emp.FunctionalArea = dr.GetString(15);
                emp.PostedDate = dr.GetDateTime(16);
                emp.LastDateToApply = dr.GetDateTime(17);            
            }
            con.Close();
            return emp;
        }
        /// <summary>
        /// To Check if the Job Seeker has already applied for the Job and then apply for the job
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="email"></param>
        /// <param name="JobID"></param>
        /// <returns></returns>
        public int ApplyForJob(EmployerMODEL emp, string email, int JobID, DateTime LastDateToApply)
        {
            SqlCommand com_check = new SqlCommand("Select count(*) from ApplyForJob where  JobID=@JobID and JSEmailID=@email", con);
            com_check.Parameters.AddWithValue("@email", email);
            com_check.Parameters.AddWithValue("@JobID", JobID);
            SqlCommand com_check_lastdate = new SqlCommand("select DATEDIFF(DAY,GETDATE(),lastdatetoapply) from JobDetails where JobID=@JobID", con);
            com_check_lastdate.Parameters.AddWithValue("@lastdatetoapply", LastDateToApply);
            com_check_lastdate.Parameters.AddWithValue("@JobID", JobID);
            con.Open();
            int datedifference =Convert.ToInt32(com_check_lastdate.ExecuteScalar());
            int count = Convert.ToInt32(com_check.ExecuteScalar());
            if (count > 0) 
            {
                con.Close();
                return 0;
            }
            else if (datedifference < 0)
            {
                con.Close();
                return 1;
            }
            else
            {
                SqlCommand com_apply_job = new SqlCommand("Insert ApplyForJob values(@jobid,@emailid,@empemail,@companylogo,@companyname,@jobtitle,@salary,getdate())", con);
                com_apply_job.Parameters.AddWithValue("@jobid", JobID);
                com_apply_job.Parameters.AddWithValue("@emailid", email);
                com_apply_job.Parameters.AddWithValue("@empemail", emp.EmailAddress);
                com_apply_job.Parameters.AddWithValue("@companylogo", emp.CompanyLogo);
                com_apply_job.Parameters.AddWithValue("@companyname", emp.CompanyName);
                com_apply_job.Parameters.AddWithValue("@jobtitle", emp.JobTitle);
                com_apply_job.Parameters.AddWithValue("@salary", emp.Salary);
                
                com_apply_job.ExecuteNonQuery();
                return 2;
            }
                 
        }
      /// <summary>
      /// To View the Apply History of the Job Seeker
      /// </summary>
      /// <param name="str"></param>
      /// <returns></returns>
        public List<EmployerMODEL> ViewAppliedJobJS(string str)
        {
            List<EmployerMODEL> Appliedjoblist = new List<EmployerMODEL>();
            SqlCommand com_view_applied_job = new SqlCommand("select CompanyLogo,CompanyName,JobID,JobTitle,Salary,ApplyDate from ApplyForJob where JSEmailID=@emailid", con);
            com_view_applied_job.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_applied_job.ExecuteReader();
            while (dr.Read())
            {
                EmployerMODEL emp = new EmployerMODEL();                
                emp.CompanyLogo = dr.GetString(0);
                emp.CompanyName = dr.GetString(1);
                emp.JobID = dr.GetInt32(2);
                emp.JobTitle = dr.GetString(3);
                emp.Salary = dr.GetInt32(4);
                emp.ApplyDate = dr.GetDateTime(5);
                Appliedjoblist.Add(emp);
            }
            con.Close();
            return Appliedjoblist;
       
    }
}
    }

