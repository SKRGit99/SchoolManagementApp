using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementApplicationBAL;
using SchoolManagementApplicationDAL.Model;

namespace SchoolManagementApplication.Controllers
{
    public class StudentController : Controller
    {
        /* Use of the StudentDetailsBAL class to access the business logic layer for student details. 
         * This class is injected into the controller through constructor injection, allowing for better separation of concerns and easier unit testing.
        */
        private readonly StudentDetailsBAL _studentBal;
        public StudentController(StudentDetailsBAL studentBal)
        {
            _studentBal = studentBal;
        }

        //[HttpGet]
        //public IActionResult GetIndividualStudentDetailsByRegistrationId()
        //{
        //    int inputStudentId = 0;
        //    StudentDetailsBAL studentDetailsBusiness = new StudentDetailsBAL();

        //    /*This code is for getting dropdown details*/
        //    List<StudentDetailsForDropDown> studentDetailsForDrpDwn = new List<StudentDetailsForDropDown>();
        //    studentDetailsForDrpDwn = studentDetailsBusiness.GetStudentDetailsForDropdown(inputStudentId);

        //     ViewBag.studentList = new SelectList(studentDetailsForDrpDwn, "StudentIdForDrpDwn", "StudentFullNameForDrpDwn");
        //    /*code for getting dropdown details ends*/

        //    return View();
        //}


        //[HttpPost]
        public JsonResult GetIndividualStudentDetailsByRegistrationId(string value)
        {
            /*We will not be using the new StudentDetailsBAL() anymore because we are using dependency injection */

            //StudentDetailsBAL studentDetailsBusiness = new StudentDetailsBAL();

            List<StudentDetails> studentDetails = new List<StudentDetails>();


            //studentDetails = studentDetailsBusiness.GetStudentDetailsByRegistrationId(Convert.ToInt32(value));

            studentDetails = _studentBal.GetStudentDetailsByRegistrationId(Convert.ToInt32(value));

            return Json(studentDetails);
        }


        
        

        

    }
}
