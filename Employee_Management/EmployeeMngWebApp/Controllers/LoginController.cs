using EmployeeMngWebApp.filter;
using EmployeeMngWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EmployeeMngWebApp.Controllers
{
    [CustomFilter]
    public class LoginController : Controller
    {

            EmployeeEntities dbObj = new EmployeeEntities();
        
        // GET: Login
        public ActionResult SignIn()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SignIn(Login loginData,string returnUrl)
        {
            var mathccount = (from emp in dbObj.EmployeeDetails
                              where emp.username == loginData.username && emp.password == loginData.password
                              select emp).Count();
            if(mathccount==1)
            {
                FormsAuthentication.SetAuthCookie(loginData.username, false);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                return Redirect("/Home/Index");

                }
            }
            else
            {
                ViewBag.LoginFailureMsg = "Username or Password is Incorrect !";
                return View();

            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Login/SignIn");
        }

        public ActionResult SignUp()
        {

            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "Emp_id,EmpName,Designation,Dept_id,Address,City_id,State_id,Country_id,Email_id,Contact_no,username,password")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                dbObj.EmployeeDetails.Add(employeeDetail);
                dbObj.SaveChanges();
               
                string emailuserName = ConfigurationManager.AppSettings["email"];
                string emailpassword = ConfigurationManager.AppSettings["password"];

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailuserName);
                mail.To.Add(employeeDetail.Email_id);
                mail.To.Add("sambhaji.bahir@gmail.com");
                mail.Subject = "WelCome to Tukaram's Website!";
                mail.Body = " <h6>" + employeeDetail.EmpName + "Thanks for choosing us ...." + " </h6>";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.Credentials = new NetworkCredential(emailuserName, emailpassword);

                smtp.EnableSsl = true;

                smtp.Send(mail);



                return RedirectToAction("SignIn");
            }
            
            return View();
        }


       
    }
}