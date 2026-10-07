using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolManagementApplicationBAL;
using SchoolManagementApplicationDAL.Abstract;
using SchoolManagementApplicationDAL.Model;

namespace SchoolManagementApplication.Controllers
{
    public class SuperAdminController : Controller
    {
        /* Use of the SuperAdminBAL class to access the business logic layer for super admin role. 
         * This class is injected into the controller through constructor injection, allowing for better separation of concerns and easier unit testing.
        */
        private readonly SuperAdminBAL _superAdminBal;
        public SuperAdminController(SuperAdminBAL superAdminBal)
        {
            _superAdminBal = superAdminBal;
        }

        private readonly SuperAdminBaseController<StudentDetails> _studentBase
        = new SuperAdminBaseController<StudentDetails>();
        private readonly SuperAdminBaseController<EducatorDetails> _educatorBase
            = new SuperAdminBaseController<EducatorDetails>();

        [HttpGet]
        public IActionResult GetIndividualStudentDetailsByRegistrationId()
        {
            int inputStudentId = 0;

            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */

            //SuperAdminBAL studentDetailsBusiness = new SuperAdminBAL();

            /*This code is for getting dropdown details*/
            List<StudentDetailsForDropDown> studentDetailsForDrpDwn = new List<StudentDetailsForDropDown>();
            //studentDetailsForDrpDwn = studentDetailsBusiness.GetStudentDetailsForDropdown(inputStudentId);

            studentDetailsForDrpDwn = _superAdminBal.GetStudentDetailsForDropdown(inputStudentId);

            ViewBag.studentList = new SelectList(studentDetailsForDrpDwn, "StudentIdForDrpDwn", "StudentFullNameForDrpDwn");
            /*code for getting dropdown details ends*/

            return View();
        }


        [HttpPost]
        
        public JsonResult GetIndividualStudentDetailsByRegistrationId(string value)
        {
            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */
            //SuperAdminBAL studentDetailsBusiness = new SuperAdminBAL();

            List<StudentDetails> studentDetails = new List<StudentDetails>();


            //studentDetails = studentDetailsBusiness.GetStudentDetailsByRegistrationId(Convert.ToInt32(value));

            studentDetails = _superAdminBal.GetStudentDetailsByRegistrationId(Convert.ToInt32(value));

            return Json(studentDetails);
        }


        public IActionResult GetStudentDetails(int page = 1)
        {
            int _inputStudentId = 0;

            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */
            //SuperAdminBAL studentDetailsBusiness = new SuperAdminBAL();

            var stuDet = _superAdminBal.fetchStudentDetails(_inputStudentId);

            var viewModel = stuDet.Select(S => new StudentDetails
            {
                SchoolName = S.SchoolName,
                StudentName = S.StudentName,
                RollNumber = S.RollNumber,
                StudentClass = S.StudentClass,
                StudentSectionId = S.StudentSectionId,
                StudentSectionName = S.StudentSectionName,
                StudentAddress = S.StudentAddress,
                StudentCity = S.StudentCity,
                StudentState = S.StudentState,
                StudentCountry = S.StudentCountry


            }).ToList();

            //ViewBag.TotalRecords = stuDet.Count;
            //ViewBag.CurrentPage = page;

            //var paginatedResult = PaginatedResult(studentDetails, page, 10);
            //return View(paginatedResult);

            ViewBag.TotalRecords = viewModel.Count;
            ViewBag.CurrentPage = page;

            //var paginatedResult = PaginatedResult(viewModel, page, 10);
            var paginatedResult = _studentBase.PaginatedResult(viewModel, page, 10);
            return View(paginatedResult);
        }


        [HttpGet]
        public IActionResult GetIndividualEducatorDetailsByRegistrationId()
        {
            int educatorid = 0;

            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */
            //SuperAdminBAL eduDetailsBAL = new SuperAdminBAL();

            /*This code is for grtting dropdown details*/
            List<EducatorDetailsForDropDown> educatorDetDrpDwn = new List<EducatorDetailsForDropDown>();

            //educatorDetDrpDwn = eduDetailsBAL.fetchEducatorDetailsForDropDown(educatorid);

            educatorDetDrpDwn = _superAdminBal.fetchEducatorDetailsForDropDown(educatorid);

            ViewBag.EducatorList = new SelectList(educatorDetDrpDwn, "EducatorIdForDrpDwn", "EducatorFullNameForDrpDwn");
            /*code for grtting dropdown details ends*/

            return View();
        }

        [HttpPost]
        public JsonResult GetIndividualEducatorDetailsByRegistrationId(string value)
        {
            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */

            //SuperAdminBAL eduDetailsDrpDwnBAL = new SuperAdminBAL();

            List<EducatorDetails> educatDetails = new List<EducatorDetails>();

            //educatDetails = eduDetailsDrpDwnBAL.fetchEducatorDetailsByRegistrationId(Convert.ToInt32(value));

            educatDetails = _superAdminBal.fetchEducatorDetailsByRegistrationId(Convert.ToInt32(value));

            return Json(educatDetails);
        }

        public IActionResult GetEducatorDetails(int page = 1)
        {
            int educatorId = 0;

            /*We will not be using the new SuperAdminBAL() anymore because we are using dependency injection */

            //SuperAdminBAL educatorDetailsBusiness = new SuperAdminBAL();

            //var educatorDetails = educatorDetailsBusiness.fetchEducatorDetails(educatorId);
            var educatorDetails = _superAdminBal.fetchEducatorDetails(educatorId);

            var viewModel = educatorDetails.Select(S => new EducatorDetails
            {
                EducatorId = S.EducatorId,
                EducatorName = S.EducatorName,
                EducatorDepartmentName = S.EducatorDepartmentName,
                EducatorClassesAssigned = S.EducatorClassesAssigned,
                EducatorAddress = S.EducatorAddress,
                EducatorCity = S.EducatorCity,
                EducatorState = S.EducatorState,
                EducatorCountry = S.EducatorCountry,
                EducatorPhoneNumber = S.EducatorPhoneNumber,
                EmailId = S.EmailId


            }).ToList();

            ViewBag.TotalRecords = educatorDetails.Count;
            ViewBag.CurrentPage = page;

            //var paginatedResult = PaginatedResult(educatorDetails, page, 10);
            var paginatedResult = _educatorBase.PaginatedResult(viewModel, page, 10);
            return View(paginatedResult);

        }



    }
}
