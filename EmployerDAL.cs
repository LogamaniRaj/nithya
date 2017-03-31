using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;


namespace Mvc_JobPortal_FinalProject.Models
{
    public class EmployerDAL
    {       
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        /// <summary>
        ///To  Check for Unique Email Address
        /// </summary>
        /// <param name="EmailAddress"></param>
        /// <returns></returns>
        public bool CheckEmail(string EmailAddress)
        {
            SqlCommand com_check = new SqlCommand("Select count(*) from Employers where EmailAddress=@email", con);
            com_check.Parameters.AddWithValue("@email", EmailAddress);
            con.Open();
            int count = Convert.ToInt32(com_check.ExecuteScalar());
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
        /// To Create a new Employer Account
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool NewUser(EmployerMODEL obj)
        {
            SqlCommand com_insert_new_employer = new SqlCommand("insert Employers values (null,@EmailAddress,@CompanyName,@CompanyWebsite,@ContactNumber)", con);
            com_insert_new_employer.Parameters.AddWithValue("@EmailAddress", obj.EmailAddress);
            com_insert_new_employer.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            com_insert_new_employer.Parameters.AddWithValue("@CompanyWebsite", obj.CompanyWebsite);
            com_insert_new_employer.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);

            con.Open();
            com_insert_new_employer.ExecuteNonQuery();
            SqlCommand com_empid = new SqlCommand("select @@identity", con);
            int empid = Convert.ToInt32(com_empid.ExecuteScalar());
            obj.EmployerID = empid;
            obj.CompanyLogo = "/CompanyLogoImages/" + empid + ".jpg";
            SqlCommand com_update_img = new SqlCommand("Update Employers set CompanyLogo=@image where EmployerID=@empid", con);
            com_update_img.Parameters.AddWithValue("@empid", obj.EmployerID);
            com_update_img.Parameters.AddWithValue("@image", obj.CompanyLogo);
            com_update_img.ExecuteNonQuery();
            con.Close();
            MembershipCreateStatus status;
            Membership.CreateUser(obj.EmailAddress, obj.EmpPassword, obj.EmailAddress, obj.EmpSecurityQuestion, obj.EmpSecurityAnswer, true, out status);

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
        /// To Add Vacancies 
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="str"></param>
        /// <returns></returns>
  
        public bool AddJob(EmployerMODEL emp, string str)
        {
            SqlCommand com_insert_job = new SqlCommand("Insert JobDetails values(@emailid,@jobtitle,@jobdesc,@joblocation,@industrytype,@funcarea,@qualifications,@minexp,@maxexp,@salary,@nomofvacancies,getdate(),@lastdate)", con);
            com_insert_job.Parameters.AddWithValue("@emailid", str);
            com_insert_job.Parameters.AddWithValue("@jobtitle", emp.JobTitle);
            com_insert_job.Parameters.AddWithValue("@jobdesc", emp.JobDesc);
            com_insert_job.Parameters.AddWithValue("@joblocation", emp.JobLocation);
            com_insert_job.Parameters.AddWithValue("@industrytype", emp.IndustryType);
            com_insert_job.Parameters.AddWithValue("@funcarea", emp.FunctionalArea);
            com_insert_job.Parameters.AddWithValue("@qualifications", emp.Qualifications);
            
            com_insert_job.Parameters.AddWithValue("@minexp", emp.MinExp);
            com_insert_job.Parameters.AddWithValue("@maxexp", emp.MaxExp);
            com_insert_job.Parameters.AddWithValue("@salary", emp.Salary);
            com_insert_job.Parameters.AddWithValue("@nomofvacancies", emp.NoOfVacancies);
            com_insert_job.Parameters.AddWithValue("@lastdate", emp.LastDateToApply);
            
            con.Open();
            com_insert_job.ExecuteNonQuery();
            con.Close();
            return true;
        }

        /// <summary>
        /// To View Employer's Profile
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public EmployerMODEL ViewEmpProfile(EmployerMODEL emp, string str)
        {
            SqlCommand com_view_emp_profile = new SqlCommand("select CompanyLogo,CompanyName,CompanyWebsite,ContactNumber from Employers where EmailAddress=@emailid", con);
            com_view_emp_profile.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_emp_profile.ExecuteReader();
            if (dr.Read())
            {
                emp.CompanyLogo = dr.GetString(0);
                emp.CompanyName = dr.GetString(1);
                emp.CompanyWebsite = dr.GetString(2);
                emp.ContactNumber = dr.GetString(3);
            }
            con.Close();
            return emp;
        }
        /// <summary>
        /// To list the Posted Jobs 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<EmployerMODEL> ViewJob(string str)
        {
            List<EmployerMODEL> joblist = new List<EmployerMODEL>();
            SqlCommand com_view_job = new SqlCommand("select JobID,JobTitle,NumberofVacancies,Salary,JobLocation,PostedDate,LastDateToApply from JobDetails where EmailAddress=@emailid", con);
            com_view_job.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_job.ExecuteReader();
            while (dr.Read())
            {
                EmployerMODEL emp = new EmployerMODEL();
                emp.JobID = dr.GetInt32(0);
                emp.JobTitle = dr.GetString(1);                
                emp.NoOfVacancies = dr.GetInt32(2);             
                emp.Salary = dr.GetInt32(3);
                emp.JobLocation = dr.GetString(4);                
                emp.PostedDate = dr.GetDateTime(5);
                emp.LastDateToApply = dr.GetDateTime(6);
                joblist.Add(emp);
            }
            con.Close();
            return joblist;
        }
        /// <summary>
        /// To view the complete details of the Job
        /// </summary>
        /// <param name="str"></param>
        /// <param name="JobID"></param>
        /// <returns></returns>
        public EmployerMODEL ViewJobDetails(string str,string JobID)
        {

            SqlCommand com_view_jobdetails = new SqlCommand("select JobTitle,JobDescription,NumberofVacancies,MinExperience,MaxExperience,Salary,JobLocation,IndustryType,FunctionalArea,PostedDate,LastDateToApply,JobID,Qualifications from JobDetails where EmailAddress=@emailid and JobID=@jobid", con);
            com_view_jobdetails.Parameters.AddWithValue("@emailid", str);
            com_view_jobdetails.Parameters.AddWithValue("@jobid", JobID);
            con.Open();
            EmployerMODEL emp = new EmployerMODEL();
            SqlDataReader dr = com_view_jobdetails.ExecuteReader();
            if (dr.Read())
            {              
                emp.JobTitle = dr.GetString(0);
                emp.JobDesc = dr.GetString(1);
                emp.NoOfVacancies = dr.GetInt32(2);
                emp.MinExp = dr.GetInt32(3);
                emp.MaxExp = dr.GetInt32(4);
                emp.Salary = dr.GetInt32(5);
                emp.JobLocation = dr.GetString(6);
                emp.IndustryType = dr.GetString(7);
                emp.FunctionalArea = dr.GetString(8);
                emp.PostedDate = dr.GetDateTime(9);
                emp.LastDateToApply = dr.GetDateTime(10);
                emp.JobID = dr.GetInt32(11);
                emp.Qualifications = dr.GetString(12);
            }
            con.Close();
            return emp;
        }
        /// <summary>
        /// To View the Job Applications
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<EmployerMODEL> ViewAppliedJob(string str)
        {
            List<EmployerMODEL> Appliedjoblist = new List<EmployerMODEL>();
            SqlCommand com_view_applied_job = new SqlCommand("select JSEmailID,CompanyName,JobTitle,Salary,ApplyDate from ApplyForJob where EmailAddress=@emailid", con);
            com_view_applied_job.Parameters.AddWithValue("@emailid", str);
            con.Open();
            SqlDataReader dr = com_view_applied_job.ExecuteReader();
            while (dr.Read())
            {
                EmployerMODEL app = new EmployerMODEL();
                app.JSEmailID = dr.GetString(0);                
                app.CompanyName = dr.GetString(1);
                app.JobTitle = dr.GetString(2);
                app.Salary = dr.GetInt32(3);
                app.ApplyDate = dr.GetDateTime(4);
                Appliedjoblist.Add(app);
            }
            con.Close();
            return Appliedjoblist;
        }
    }
}
